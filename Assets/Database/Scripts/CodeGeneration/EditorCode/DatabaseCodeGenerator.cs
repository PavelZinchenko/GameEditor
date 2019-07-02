using System.Collections.Generic;
using GameDatabase.CodeGeneration.Settings;
using UnityEngine.Assertions;

namespace GameDatabase.CodeGeneration.EditorCode
{
    public class DatabaseCodeGenerator : IDatabaseCodeGenerator
    {
        public DatabaseCodeGenerator(DatabaseSchema schema, CodeWriter writer)
        {
            Assert.IsNotNull(schema);
            Assert.IsNotNull(writer);

            _codeWriter = writer;
            _schema = schema;
        }

        public void AddClass(string name, string type)
        {
            _classes.Add(new KeyValuePair<string, string>(name, type));
        }

        public void AddConfiguration(string name, string type)
        {
            _configurations.Add(new KeyValuePair<string, string>(name, type));
        }

        public void Generate(GeneratorSettings context)
        {
            GenerateDatabase(context);
            GenerateJsonDatabase(context);
        }

        private void GenerateDatabase(GeneratorSettings context)
        {
            var code = new CodeFormatter();

            code.UseNamespace("System.Collections.Generic", false);
            code.UseNamespace("System.Linq", false);
            code.UseNamespace(Constants.TypesNamespace);
            code.UseNamespace(Constants.DataSourceNamespace);
            code.UseNamespace(Constants.SerializationNamespace);
            code.UseNamespace(context.ClassesNamespace);
            code.NewLine();

            code.Namespace(Constants.DatabaseNamespace);

            code.Add("public class ", context.DatabaseClass);
            code.OpenBraces();

            code.Add("public ", context.DatabaseClass, "(IDataSource defaultDataSource, IJsonSerializer serializer)");
            code.OpenBraces();
            code.Add("_serializer = serializer;");
            code.Add("_defaultDataSource = defaultDataSource;");
            code.Add("Load();");
            code.CloseBraces();
            code.NewLine();

            code.Add("public void Load(IDataSource dataSource = null)");
            code.OpenBraces();
            code.Add("Reset();");
            code.Add("_jsonDatabase = new ", JsonDatabaseClassName, "(dataSource ?? _defaultDataSource, _serializer);");
            code.CloseBraces();
            code.NewLine();

            code.Add("private void Reset()");
            code.OpenBraces();

            code.Add("Reset();");
            foreach (var item in _classes)
                code.Add(GetMemberName(item.Key), ".Clear();");
            foreach (var item in _configurations)
                code.Add(GetConfigMemberName(item.Key), " = null;");
            code.Add("_jsonDatabase = null;");
            code.CloseBraces();
            code.NewLine();

            foreach (var item in _configurations)
            {
                var memberName = GetConfigMemberName(item.Key);
                code.Add("public ", item.Key, Constants.DataClassSuffix, " ", item.Key, " => ", memberName, " ?? (",
                    memberName, " = ", item.Key, Constants.DataClassSuffix, ".Deserialize(_jsonDatabase.", item.Key, ", this));");
            }

            code.NewLine();

            foreach (var item in _classes)
            {
                var memberName = GetMemberName(item.Key);
                var className = item.Key + Constants.DataClassSuffix;

                code.Add("public IEnumerable<ItemId<", className, ">> ", CommonCodeGenerator.DatabaseGetAllMethod(item.Key), " { get { return _jsonDatabase.", 
                    item.Key, "List.Select(item => new ItemId<", className, ">(item.Id, item.FileName)); } }");

                code.Add("public ItemId<", className, "> ", CommonCodeGenerator.DatabaseGetIdMethod(item.Key) ,"(int id) { return new ItemId<", className, 
                    ">(_jsonDatabase.", CommonCodeGenerator.DatabaseGetMethod(item.Key),"(id)); }");

                code.Add("public ", className, " ", CommonCodeGenerator.DatabaseGetMethod(item.Key), "(int id)");
                code.OpenBraces();
                code.Add("if (!", memberName, ".TryGetValue(id, out var item))");
                code.OpenBraces();
                code.Add(memberName, ".Add(id, null);");
                code.Add(memberName, "[id] = item = ", className, ".Deserialize(_jsonDatabase.Get", item.Key, "(id), this);");
                code.CloseBraces();
                code.Add("if (item == null) throw new DatabaseException(CircularDependencyText + \"", item.Key, "_\" + id);");
                code.Add("return item;");
                code.CloseBraces();
                code.NewLine();
            }

            foreach (var item in _configurations)
                code.Add("private ", item.Key, Constants.DataClassSuffix, " ", GetConfigMemberName(item.Key), ";");
            foreach (var item in _classes)
                code.Add("private readonly Dictionary<int, ", item.Key, Constants.DataClassSuffix, "> ", GetMemberName(item.Key), " = new Dictionary<int, ", item.Key, Constants.DataClassSuffix, ">();");

            code.NewLine();
            code.Add("private ", JsonDatabaseClassName, " _jsonDatabase;");
            code.Add("private readonly IJsonSerializer _serializer;");
            code.Add("private readonly IDataSource _defaultDataSource;");
            code.Add("private const string CircularDependencyText = \"Circular dependency found: \";");

            _codeWriter.Write(string.Empty, context.DatabaseClass, code.ToString());
        }

        private void GenerateJsonDatabase(GeneratorSettings context)
        {
            var code = new CodeFormatter();

            code.UseNamespace("System.Collections.Generic", false);
            code.UseNamespace(Constants.DataSourceNamespace);
            code.UseNamespace(Constants.SerializationNamespace);
            code.UseNamespace(context.SerializableNamespace);
            code.UseNamespace(context.EnumsNamespace);
            code.NewLine();

            code.Namespace(Constants.DatabaseNamespace);

            code.Add("public class ", JsonDatabaseClassName);
            code.OpenBraces();

            code.Add("public ", JsonDatabaseClassName, "(IDataSource dataSource, IJsonSerializer serializer)");
            code.OpenBraces();
            code.Add("_dataSource = dataSource;");
            code.Add("_serializer = serializer;");
            code.Add("foreach (var file in dataSource.Files)");
            code.OpenBraces();
            code.Add("var item = _serializer.FromJson<SerializableItem>(file.Content);");
            code.Add("var type = (ItemType)item.ItemType;");

            var first = true;
            foreach (var item in _classes)
                AddDeserializationCode(code, item.Key, item.Value, ref first, false);
            foreach (var item in _configurations)
                AddDeserializationCode(code, item.Key, item.Value, ref first, true);

            if (!first)
            {
                code.Add("else");
                code.OpenBraces();
                code.Add("throw new DatabaseException(\"Unknown file type - \" + type + \"(\" + file.Name + \")\");");
                code.CloseBraces();
            }

            code.CloseBraces();
            code.CloseBraces();

            code.NewLine();

            foreach (var item in _configurations)
                code.Add("public ", item.Key, Constants.SerializableClassSuffix, " ", item.Key, " { get; }");

            code.NewLine();

            foreach (var item in _classes)
                code.Add("public IEnumerable<", item.Key, Constants.SerializableClassSuffix,
                    "> ", item.Key, "List => ", GetMemberName(item.Key), ".Values;");

            code.NewLine();

            foreach (var item in _classes)
                code.Add("public ", item.Key, Constants.SerializableClassSuffix,
                    " Get", item.Key, "(int id) => ", GetMemberName(item.Key), ".TryGetValue(id, out var value) ? value : null;");

            code.NewLine();

            foreach (var item in _classes)
                code.Add("private readonly Dictionary<int, ", item.Key, Constants.SerializableClassSuffix,
                    "> ", GetMemberName(item.Key), " = new Dictionary<int, ", item.Key, Constants.SerializableClassSuffix, ">();");

            code.NewLine();

            code.Add("private readonly IDataSource _dataSource;");
            code.Add("private readonly IJsonSerializer _serializer;");

            _codeWriter.Write(string.Empty, JsonDatabaseClassName, code.ToString());
        }

        private void AddDeserializationCode(CodeFormatter code, string name, string type, ref bool isFirst, bool isUnique)
        {
            if (isFirst)
            {
                code.Add("if (type == ", DatabaseSchema.ItemTypeEnum, ".", type, ")");
                isFirst = false;
            }
            else
            {
                code.Add("else if (type == ", DatabaseSchema.ItemTypeEnum, ".", type, ")");
            }

            code.OpenBraces();
            code.Add("var data = _serializer.FromJson<", name, Constants.SerializableClassSuffix, ">(file.Content);");
            code.Add("data.FileName = file.Name;");

            if (isUnique)
            {
                code.Add("if (", name, "!= null)");
                code.Add(Constants.Indent, "throw new DatabaseException(\"Duplicate settings file found - \" + file.Name);");
                code.Add(name, " = data;");
            }
            else
            {
                code.Add(GetMemberName(name), ".Add(data.ItemType, data);");
            }

            code.CloseBraces();
        }

        private string GetMemberName(string className) { return "_" + className.ToLower() + "Map"; }
        private string GetConfigMemberName(string className) { return "_" + className.ToLower(); }

        private readonly CodeWriter _codeWriter;

        private readonly List<KeyValuePair<string, string>> _classes = new List<KeyValuePair<string, string>>();
        private readonly List<KeyValuePair<string, string>> _configurations = new List<KeyValuePair<string, string>>();
        private readonly DatabaseSchema _schema;

        private const string JsonDatabaseClassName = "JsonDatabase";
    }
}