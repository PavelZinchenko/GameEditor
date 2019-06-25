using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Database.Utils;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace Database.CodeGeneration
{
    public class CodeGenerator
    {
        private CodeGenerator(string xmlPath, string codePath)
        {
            _xmlPath = xmlPath;
            _codePath = codePath;
        }

        public static void Generate(string xmlPath, string codePath)
        {
            var generator = new CodeGenerator(xmlPath, codePath);
            generator.Build();
        }

        private void Build()
        {
            LoadResources();
            GenerateCode();

            Debug.Log("Done!");
        }

        private void LoadResources()
        {
            var assets = Resources.LoadAll<TextAsset>(_xmlPath);
            if (assets.Length == 0)
                throw new InvalidDataException("No xml files found at " + _xmlPath);

            var typeSerializer = new XmlSerializer(typeof(XmlTypeInfo));
            var enumSerializer = new XmlSerializer(typeof(XmlEnumItem));
            var classSerializer = new XmlSerializer(typeof(XmlClassItem));

            foreach (var resource in assets)
            {
                try
                {
                    XmlTypeInfo typeInfo;
                    using (var reader = new System.IO.StringReader(resource.text))
                        typeInfo = typeSerializer.Deserialize(reader) as XmlTypeInfo;

                    if (string.IsNullOrEmpty(typeInfo.name))
                        throw new InvalidDataException("Object name cannot be empty - " + resource.name);
                    if (string.IsNullOrEmpty(typeInfo.type))
                        throw new InvalidDataException("Object type cannot be empty - " + resource.name);

                    using (var reader = new System.IO.StringReader(resource.text))
                    {
                        if (typeInfo.type == "enum")
                        {
                            var item = enumSerializer.Deserialize(reader) as XmlEnumItem;
                            Assert.IsNotNull(item);
                            _enums.Add(item.name, item);
                        }
                        else if (typeInfo.type == "object")
                        {
                            var item = classSerializer.Deserialize(reader) as XmlClassItem;
                            Assert.IsNotNull(item);
                            _classes.Add(item.name, item);
                        }
                        else if (typeInfo.type == "struct")
                        {
                            var item = classSerializer.Deserialize(reader) as XmlClassItem;
                            Assert.IsNotNull(item);
                            _structs.Add(item.name, item);
                        }
                        else if (typeInfo.type == "settings")
                        {
                            var item = classSerializer.Deserialize(reader) as XmlClassItem;
                            Assert.IsNotNull(item);
                            _settings.Add(item.name, item);
                        }
                        else
                        {
                            throw new InvalidDataException("Unknown item type: " + typeInfo.type + " in " + resource.name);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Unable to load asset: " + e.Message);
                }
            }
        }

        private void GenerateCode()
        {
            DeleteGeneratedFiles();
            ParseItemTypes();

            foreach (var item in _enums.Values)
                CreateEnum(item);
            foreach (var item in _classes.Values)
                CreateClass(item, true);
            foreach (var item in _structs.Values)
                CreateClass(item, false);
            foreach (var item in _settings.Values)
                CreateClass(item, true);
        }

        private void DeleteGeneratedFiles()
        {
            if (!Directory.Exists(_codePath)) return;
            var root = new DirectoryInfo(_codePath);

            foreach (var file in root.GetFiles())
                file.Delete();
            foreach (var dir in root.GetDirectories())
                dir.Delete(true);
        }

        private void ParseItemTypes()
        {
            XmlEnumItem itemTypeEnum;
            if (!_enums.TryGetValue(ItemTypeEnum, out itemTypeEnum))
                throw new InvalidDataException(ItemTypeEnum + " enum must be defined");

            var index = 0;
            foreach (var item in itemTypeEnum.items)
            {
                int value;
                if (string.IsNullOrEmpty(item.value))
                    _itemTypes.Add(index++, item.name);
                else if (int.TryParse(item.value, out value))
                    _itemTypes.Add(value, item.name);
                else
                    throw new InvalidDataException("Wrong enum value - " + item.value);
            }
        }

        private void CreateEnum(XmlEnumItem data)
        {
            const string scope = "Enums";
            var sb = new StringBuilder();

            sb.AppendLine(GeneratedCodeWarning);
            sb.AppendLine(NameSpace + scope + BracesOpen);
            sb.AppendLine();
            sb.AppendLine("public enum " + data.name + BracesOpen);

            foreach (var item in data.items)
            {
                if (string.IsNullOrEmpty(item.value))
                    sb.AppendLine(Indent + item.name + ",");
                else
                    sb.AppendLine(Indent + item.name + " = " + item.value + ",");
            }

            sb.AppendLine(BracesClose);
            sb.AppendLine();
            sb.AppendLine(BracesClose);
            WriteFile(scope, data.name, sb.ToString());
        }

        private void CreateClass(XmlClassItem data, bool isSerializableItem)
        {
            if (isSerializableItem)
            {
                if (string.IsNullOrEmpty(data.typeid))
                    throw new InvalidDataException("Object typeid cannot be empty");
                if (!_itemTypes.ContainsValue(data.typeid))
                    throw new InvalidDataException("Object typeid cannot be empty");
            }

            const string scope = "Serializable";
            var sb = new StringBuilder();
            var name = data.name + "Serializable";

            sb.AppendLine(GeneratedCodeWarning);
            sb.AppendLine("using System;");
            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using Database.Types;");
            sb.AppendLine("using Database.Enums;");
            sb.AppendLine();
            sb.AppendLine(NameSpace + scope + BracesOpen);
            sb.AppendLine();
            sb.AppendLine("[Serializable]");

            if (isSerializableItem)
                sb.AppendLine("public class " + name + " : SerializableItem" + BracesOpen);
            else
                sb.AppendLine("public class " + name + BracesOpen);

            foreach (var item in data.members)
            {
                WriteMember(item, sb);
            }

            sb.AppendLine(BracesClose);
            sb.AppendLine();
            sb.AppendLine(BracesClose);

            WriteFile(scope, name, sb.ToString());
        }

        private void WriteMember(XmlClassMember member, StringBuilder stringBuilder)
        {
            if (string.IsNullOrEmpty(member.name))
                throw new InvalidDataException("Member name cannot be empty");
            if (string.IsNullOrEmpty(member.type))
                throw new InvalidDataException("Member type cannot be empty - " + member.name);

            if (member.type == "int")
            {
                stringBuilder.AppendLine(Indent + "public int " + member.name + ";");
            }
            else if (member.type == "float")
            {
                stringBuilder.AppendLine(Indent + "public float " + member.name + ";");
            }
            else if (member.type == "bool")
            {
                stringBuilder.AppendLine(Indent + "public bool " + member.name + ";");
            }
            else if (member.type == "string")
            {
                stringBuilder.AppendLine(Indent + "[DefaultValue(\"\")]");
                stringBuilder.AppendLine(Indent + "public string " + member.name + ";");
            }
            else if (member.type == "color")
            {
                stringBuilder.AppendLine(Indent + "[DefaultValue(\"\")]");
                stringBuilder.AppendLine(Indent + "public string " + member.name + ";");
            }
            else if (member.type == "image")
            {
                stringBuilder.AppendLine(Indent + "[DefaultValue(\"\")]");
                stringBuilder.AppendLine(Indent + "public string " + member.name + ";");
            }
            else if (member.type == "audioclip")
            {
                stringBuilder.AppendLine(Indent + "[DefaultValue(\"\")]");
                stringBuilder.AppendLine(Indent + "public string " + member.name + ";");
            }
            else if (member.type == "layout")
            {
                stringBuilder.AppendLine(Indent + "[DefaultValue(\"\")]");
                stringBuilder.AppendLine(Indent + "public string " + member.name + ";");
            }
            else if (member.type == "vector")
            {
                stringBuilder.AppendLine(Indent + "[DefaultValue(\"\")]");
                stringBuilder.AppendLine(Indent + "public Vector " + member.name + ";");
            }
            else if (member.type == "enum")
            {
                if (!_enums.ContainsKey(member.typeid))
                    throw new InvalidDataException("Unknown enum type in class member " + member.name);

                stringBuilder.AppendLine(Indent + "public " + member.typeid + " " + member.name + ";");
            }
            else if (member.type == "object")
            {
                if (!_classes.ContainsKey(member.typeid))
                    throw new InvalidDataException("Unknown object type in class member " + member.name);

                stringBuilder.AppendLine(Indent + "public int " + member.name + ";");
            }
            else if (member.type == "object_list")
            {
                if (!_classes.ContainsKey(member.typeid))
                    throw new InvalidDataException("Unknown object type in class member " + member.name);

                stringBuilder.AppendLine(Indent + "public int[] " + member.name + ";");
            }
            else if (member.type == "struct")
            {
                if (!_structs.ContainsKey(member.typeid))
                    throw new InvalidDataException("Unknown struct type in class member " + member.name);

                stringBuilder.AppendLine(Indent + "public " + member.typeid + Serializable + " " + member.name + ";");
            }
            else if (member.type == "struct_list")
            {
                if (!_structs.ContainsKey(member.typeid))
                    throw new InvalidDataException("Unknown struct type in class member " + member.name);   

                stringBuilder.AppendLine(Indent + "public " + member.typeid + Serializable + "[] " + member.name + ";");
            }
            else
            {
                throw new InvalidDataException("Invalid class member type - " + member.type);
            }
        }

        private void WriteFile(string path, string filename, string content)
        {
            var fullpath = Path.Combine(_codePath, path);
            Directory.CreateDirectory(fullpath);
            File.WriteAllText(Path.Combine(fullpath, filename + ".cs"), content);
        }

        private readonly TwoWayDictionary<int, string> _itemTypes = new TwoWayDictionary<int, string>();
        private readonly Dictionary<string, XmlEnumItem> _enums = new Dictionary<string, XmlEnumItem>();
        private readonly Dictionary<string, XmlClassItem> _structs = new Dictionary<string, XmlClassItem>();
        private readonly Dictionary<string, XmlClassItem> _classes = new Dictionary<string, XmlClassItem>();
        private readonly Dictionary<string, XmlClassItem> _settings = new Dictionary<string, XmlClassItem>();

        private readonly string _xmlPath;
        private readonly string _codePath;

        private const string ItemTypeEnum = "ItemType";
        private const string Indent = "    ";
        private const string BracesOpen = " {";
        private const string BracesClose = "}";
        private const string NameSpace = "namespace Database.";
        private const string Serializable = "Serializable";
        private const string NewLine = "\r\n";
        private const string GeneratedCodeWarning =
            "//-------------------------------------------------------------------------------" + NewLine +
            "//                                                                               " + NewLine +
            "//    This code was automatically generated.                                     " + NewLine +
            "//    Changes to this file may cause incorrect behavior and will be lost if      " + NewLine +
            "//    the code is regenerated.                                                   " + NewLine +
            "//                                                                               " + NewLine +
            "//-------------------------------------------------------------------------------" + NewLine;
    }

    public class InvalidDataException : Exception
    {
        public InvalidDataException()
        {
        }

        public InvalidDataException(string message)
            : base(message)
        {
        }

        public InvalidDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    [XmlRootAttribute("data")]
    public class XmlTypeInfo
    {
        [XmlAttribute]
        public string type = string.Empty;
        [XmlAttribute]
        public string name = string.Empty;
        [XmlText]
        public string value = string.Empty;
    }

    public class XmlKeyValuePair
    {
        [XmlAttribute]
        public string name = string.Empty;
        [XmlText]
        public string value = string.Empty;
    }

    [XmlRootAttribute("data")]
    public class XmlEnumItem
    {
        [XmlAttribute]
        public string name = string.Empty;
        [XmlElement("item")]
        public List<XmlKeyValuePair> items = new List<XmlKeyValuePair>();
    }

    public class XmlClassMember
    {
        [XmlAttribute]
        public string name = string.Empty;
        [XmlAttribute]
        public string type = string.Empty;
        [XmlAttribute]
        public string typeid = string.Empty;
        [XmlAttribute]
        public string minvalue = string.Empty;
        [XmlAttribute]
        public string maxvalue = string.Empty;
    }

    [XmlRootAttribute("data")]
    public class XmlClassItem
    {
        [XmlAttribute]
        public string name = string.Empty;
        [XmlAttribute]
        public string typeid = string.Empty;
        [XmlElement("member")]
        public List<XmlClassMember> members = new List<XmlClassMember>();
    }
}
