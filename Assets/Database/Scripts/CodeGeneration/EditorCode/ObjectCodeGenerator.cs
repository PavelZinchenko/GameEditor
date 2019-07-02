using System;
using System.Collections.Generic;
using System.Linq;
using GameDatabase.CodeGeneration.Settings;
using UnityEngine.Assertions;

namespace GameDatabase.CodeGeneration.EditorCode
{
    public class ObjectCodeGenerator : IObjectCodeGenerator
    {
        public ObjectCodeGenerator(
            DatabaseSchema schema,
            CodeWriter writer)
        {
            Assert.IsNotNull(schema);
            Assert.IsNotNull(writer);

            _codeWriter = writer;
            _schema = schema;
        }

        public void Generate(XmlClassItem data, ObjectType type, GeneratorSettings context)
        {
            switch (type)
            {
                case ObjectType.SimpleObject:
                    CreateSerializable(data, context, true);
                    CreateData(data, context, true);
                    break;
                case ObjectType.SimpleStruct:
                    CreateSerializable(data, context, false);
                    CreateData(data, context, false);
                    break;
                case ObjectType.MutableObject:
                    CreateSerializable(data, context, true);
                    CreateMutableData(data, context, true);
                    break;
                case ObjectType.MutableStruct:
                    CreateSerializable(data, context, false);
                    CreateMutableData(data, context, false);
                    break;
            }
        }

        private void CreateSerializable(XmlClassItem data, GeneratorSettings context, bool isSerializableItem)
        {
            var code = new CodeFormatter();
            var name = data.name + Constants.SerializableClassSuffix;

            code.UseNamespace("System", false);
            code.UseNamespace("System.ComponentModel", false);
            code.UseNamespace(Constants.TypesNamespace);
            code.UseNamespace(Constants.SerializationNamespace);
            code.UseNamespace(context.EnumsNamespace);
            code.NewLine();
            code.Namespace(context.SerializableNamespace);
            code.Add("[Serializable]");
            if (isSerializableItem)
                code.Class(name, true, "SerializableItem");
            else
                code.Class(name);

            var members = new HashSet<string>();
            foreach (var item in data.members)
            {
                if (!members.Add(item.name)) continue;
                CommonCodeGenerator.WriteSerializableMember(item, code, _schema);
            }

            _codeWriter.Write(context.SerializableNamespace, name, code.ToString());
        }

        private void CreateData(XmlClassItem data, GeneratorSettings settings, bool isSerializableItem)
        {
            var code = new CodeFormatter();
            var name = data.name + Constants.DataClassSuffix;

            code.UseNamespace("System", false);
            code.UseNamespace("System.Collections.Generic", false);
            code.UseNamespace("System.Linq", false);
            code.UseNamespace(Constants.TypesNamespace);
            code.UseNamespace(Constants.UtilsNamespace);
            code.UseNamespace(settings.SerializableNamespace);
            code.UseNamespace(settings.EnumsNamespace);
            code.NewLine();
            code.Namespace(settings.ClassesNamespace);
            code.Class(name);

            CommonCodeGenerator.WriteObjectDeserializer(data.name, settings, code);
            code.Add("return new ", name, "(serializable, database);");
            code.CloseBraces();
            code.NewLine();

            CommonCodeGenerator.WriteObjectConsturctor(data.name, settings, code);
            if (isSerializableItem)
                code.Add("ItemId = new ItemId<", name, ">(serializable.Id, serializable.FileName);");
            foreach (var item in data.members)
                CommonCodeGenerator.WriteDeserializationCode(item, code, settings);
            code.CloseBraces();
            code.NewLine();

            CommonCodeGenerator.WriteObjectSerializer(data.name, settings, code);
            code.Add("var serializable = new ", data.name, Constants.SerializableClassSuffix, "();");
            SerializeMembers(data.members, data.typeid, code, isSerializableItem);
            code.Add("return serializable;");
            code.CloseBraces();
            code.NewLine();

            if (isSerializableItem)
                code.Add("public readonly ItemId<", name, "> ItemId;");

            foreach (var item in data.members)
                CommonCodeGenerator.WriteDataMember(item, code, _schema);

            _codeWriter.Write(settings.ClassesNamespace, name, code.ToString());
        }

        private void CreateMutableData(XmlClassItem data, GeneratorSettings settings, bool isSerializableItem)
        {
            SortMembers(data, out var baseMembers, out var extraMembers);

            var code = new CodeFormatter();
            var name = data.name + Constants.DataClassSuffix;
            var switchEnumType = baseMembers.First(item => item.name.Equals(data.switchEnum, StringComparison.Ordinal)).typeid;

            code.UseNamespace("System", false);
            code.UseNamespace("System.Collections.Generic", false);
            code.UseNamespace("System.Linq", false);
            code.UseNamespace(Constants.TypesNamespace);
            code.UseNamespace(Constants.UtilsNamespace);
            code.UseNamespace(settings.SerializableNamespace);
            code.UseNamespace(settings.EnumsNamespace);
            code.NewLine();
            code.Namespace(settings.ClassesNamespace);
            code.Class(name, true, "IDataAdapter");

            CommonCodeGenerator.WriteObjectDeserializer(data.name, settings, code);
            code.Add("var data = new ", name, "(serializable, database); ");
            code.Add("data.CreateContent(serializable, database);");
            code.Add("return data;");
            code.CloseBraces();
            code.NewLine();

            CommonCodeGenerator.WriteObjectConsturctor(data.name, settings, code);
            if (isSerializableItem)
                code.Add("ItemId = new ItemId<", name, ">(serializable.Id, serializable.FileName);");
            foreach (var item in baseMembers)
                CommonCodeGenerator.WriteDeserializationCode(item, code, settings);
            code.CloseBraces();
            code.NewLine();
            
            code.Add("private void ", CreateContentMethodName, "(", CommonCodeGenerator.SerializableClass(data.name), " serializable, ", settings.DatabaseClass, " database)");
            code.OpenBraces();
            var first = true;
            foreach (var item in extraMembers)
            {
                code.Add(first ? "if (" : "else if (", "serializable.", data.switchEnum, " == ", switchEnumType, ".", item.Key, ")");
                code.Add(Constants.Indent, ContentPropertyName, " = new ", GetContentClassName(item.Key), "(serializable, database);");
                first = false;
            }
            if (!first) code.Add("else");
            code.Add(first ? string.Empty : Constants.Indent, ContentPropertyName, " = new ", EmptyContentClassName, "();");
            code.CloseBraces();
            code.NewLine();

            CommonCodeGenerator.WriteObjectSerializer(data.name, settings, code);
            code.Add("var serializable = Content.Serialize();");
            SerializeMembers(baseMembers, data.typeid, code, isSerializableItem);
            code.Add("return serializable;");
            code.CloseBraces();
            code.NewLine();

            AddDataAdapterImplementation(baseMembers, data.switchEnum, code);

            if (isSerializableItem)
                code.Add("public readonly ItemId<", name, "> ItemId;");
            foreach (var item in baseMembers)
                CommonCodeGenerator.WriteDataMember(item, code, _schema);
            code.NewLine();

            AddContentClasses(data.name, extraMembers, settings, code);

            _codeWriter.Write(settings.ClassesNamespace, name, code.ToString());
        }

        private void AddContentClasses(string objectName, Dictionary<string, List<XmlClassMember>> members, GeneratorSettings settings, CodeFormatter code)
        {
            var serializableName = CommonCodeGenerator.SerializableClass(objectName);

            code.Add("private interface ", ContentInterfaceName, " { ", serializableName, " ", settings.SerializeMethod, "(); }");
            code.NewLine();

            code.Class(EmptyContentClassName, false, ContentInterfaceName);
            CommonCodeGenerator.WriteObjectSerializer(objectName, settings, code);
            code.Add("return new ", serializableName, "();");
            code.CloseBraces();
            code.CloseBraces();

            foreach (var item in members)
            {
                var className = GetContentClassName(item.Key);
                code.Class(className, false, ContentInterfaceName);

                code.Add("public ", className, "(", serializableName, " serializable, ", settings.DatabaseClass, " database)");
                code.OpenBraces();
                code.Add("if (serializable == null || database == null) return;");
                foreach (var member in item.Value)
                    CommonCodeGenerator.WriteDeserializationCode(member, code, settings);
                code.CloseBraces();
                code.NewLine();

                CommonCodeGenerator.WriteObjectSerializer(objectName, settings, code);
                code.Add("var serializable = new ", serializableName, "();");
                foreach (var member in item.Value)
                    CommonCodeGenerator.WriteSerializationCode(member, code);
                code.Add("return serializable;");
                code.CloseBraces();
                code.NewLine();

                foreach (var member in item.Value)
                    CommonCodeGenerator.WriteDataMember(member, code, _schema);

                code.CloseBraces();
                code.NewLine();
            }
        }

        private static void AddDataAdapterImplementation(IEnumerable<XmlClassMember> baseMembers, string switchMemberName, CodeFormatter code)
        {
            code.Add("public event Action LayoutChangedEvent;");
            code.Add("public event Action DataChangedEvent;");

            code.Add("public IEnumerable<IProperty> Properties");
            code.OpenBraces();
            code.Add("get");
            code.OpenBraces();
            code.Add("var type = GetType();");
            //if (isSerializableItem)
            //    code.Add("yield return new Property(this, type.GetField(\"ItemId\"), DataChangedEvent);");
            foreach (var item in baseMembers)
                code.Add("yield return new Property(this, type.GetField(\"", item.name, "\"), ", item.name == switchMemberName ? "OnTypeChanged" : "DataChangedEvent", ");");
            code.Add("foreach (var item in ", ContentPropertyName, ".GetType().GetFields().Where(f => f.IsPublic && !f.IsStatic))");
            code.Add(Constants.Indent, "yield return new Property(Content, item, DataChangedEvent);");
            code.CloseBraces();
            code.CloseBraces();
            code.NewLine();

            code.Add("private void OnTypeChanged()");
            code.OpenBraces();
            code.Add(CreateContentMethodName, "(null, null);");
            code.Add("DataChangedEvent?.Invoke();");
            code.Add("LayoutChangedEvent?.Invoke();");
            code.CloseBraces();
            code.NewLine();

            code.Add("private ", ContentInterfaceName, " ", ContentPropertyName, " { get; set; }");
            code.NewLine();
        }

        private static void SerializeMembers(IEnumerable<XmlClassMember> members, string dataTypeId, CodeFormatter code, bool isSerializableItem)
        {
            if (isSerializableItem)
            {
                code.Add("serializable.Id = ItemId.Id;");
                code.Add("serializable.FileName = ItemId.Name;");
                code.Add("serializable.ItemType = (int)ItemType.", dataTypeId, ";");
            }
            foreach (var item in members)
                CommonCodeGenerator.WriteSerializationCode(item, code);
        }

        private static void SortMembers(XmlClassItem data, out List<XmlClassMember> baseMembers, out Dictionary<string, List<XmlClassMember>> extraMembers)
        {
            extraMembers = new Dictionary<string, List<XmlClassMember>>();
            baseMembers = new List<XmlClassMember>();

            foreach (var item in data.members)
            {
                if (string.IsNullOrEmpty(item.caseValue))
                {
                    baseMembers.Add(item);
                    continue;
                }

                var caseValues = item.caseValue.Split(Constants.ValueSeparators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var value in caseValues)
                {
                    if (!extraMembers.TryGetValue(value, out var list))
                        extraMembers.Add(value, list = new List<XmlClassMember>());

                    list.Add(item);
                }
            }
        }

        private static string GetContentClassName(string name) { return "Content_" + name; }

        private readonly DatabaseSchema _schema;
        private readonly CodeWriter _codeWriter;

        private const string ContentInterfaceName = "IContent";
        private const string EmptyContentClassName = "Content_Empty";
        private const string ContentPropertyName = "Content";
        private const string CreateContentMethodName = "CreateContent";
    }
}
