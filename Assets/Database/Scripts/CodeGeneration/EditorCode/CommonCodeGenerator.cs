using GameDatabase.CodeGeneration.Settings;

namespace GameDatabase.CodeGeneration.EditorCode
{
    public static class CommonCodeGenerator
    {
        public static void WriteObjectDeserializer(string objectName, GeneratorSettings settings, CodeFormatter code)
        {
            code.Add("public static ", objectName, Constants.DataClassSuffix, " ", settings.DeserializeMethod, "(",
                objectName, Constants.SerializableClassSuffix, " serializable, ", settings.DatabaseClass, " database)");
            code.OpenBraces();
        }

        public static void WriteObjectSerializer(string objectName, GeneratorSettings settings, CodeFormatter code)
        {
            code.Add("public ", objectName, Constants.SerializableClassSuffix, " ", settings.SerializeMethod, "()");
            code.OpenBraces();
        }

        public static void WriteObjectConsturctor(string objectName, GeneratorSettings settings, CodeFormatter code)
        {
            code.Add("private ", objectName, Constants.DataClassSuffix, "(", objectName, Constants.SerializableClassSuffix, " serializable, ", settings.DatabaseClass, " database)");
            code.OpenBraces();
        }

        public static string DataClass(string name) { return name + Constants.DataClassSuffix; }
        public static string SerializableClass(string name) { return name + Constants.SerializableClassSuffix; }

        public static string DatabaseGetMethod(string name) { return "Get" + name; }
        public static string DatabaseGetIdMethod(string name) { return "Get" + name + "Id"; }
        public static string DatabaseGetAllMethod(string name) { return name + "Ids"; }

        public static void WriteSerializationCode(XmlClassMember member, CodeFormatter code)
        {
            var memberName = !string.IsNullOrEmpty(member.alias) ? member.alias : member.name;
            if (member.type == Constants.TypeInt || member.type == Constants.TypeFloat)
            {
                code.Add("serializable.", member.name, " = ", memberName, ".Value;");
            }
            else if (member.type == Constants.TypeObject)
            {
                code.Add("serializable.", member.name, " = ", memberName, ".Id;");
            }
            else if (member.type == Constants.TypeObjectList)
            {
                code.Add("serializable.", member.name, " = ", memberName, "?.Select(item => item.Item.Id).ToArray();");
            }
            else if (member.type == Constants.TypeStruct)
            {
                code.Add("serializable.", member.name, " = ", memberName, ".Serialize();");
            }
            else if (member.type == Constants.TypeStructList)
            {
                code.Add("serializable.", member.name, " = ", memberName, "?.Select(item => item.Serialize()).ToArray();");
            }
            else if (member.type == Constants.TypeColor)
            {
                code.Add("serializable.", member.name, " = ", "Utils.ColorUtils.ColorToString(", memberName, ");");
            }
            else if (member.type == Constants.TypeLayout)
            {
                code.Add("serializable.", member.name, " = ", memberName, ".Data;");
            }
            else if (member.type == Constants.TypeAudioClip)
            {
                code.Add("serializable.", member.name, " = ", memberName, ".ToString();");
            }
            else if (member.type == Constants.TypeImage)
            {
                code.Add("serializable.", member.name, " = ", memberName, ".ToString();");
            }
            else
            {
                code.Add("serializable.", member.name, " = ", memberName, ";");
            }
        }

        public static void WriteDeserializationCode(XmlClassMember member, CodeFormatter code, GeneratorSettings settings)
        {
            var memberName = !string.IsNullOrEmpty(member.alias) ? member.alias : member.name;
            if (member.type == Constants.TypeObject)
            {
                code.Add(memberName, " = database.", DatabaseGetIdMethod(member.typeid), "(serializable.", member.name, ");");
            }
            else if (member.type == Constants.TypeObjectList)
            {
                code.Add(memberName, " = ", "serializable.", member.name, "?.Select(item => new Wrapper<", DataClass(member.typeid), 
                    "> { Item = database.", DatabaseGetIdMethod(member.typeid), "(item) }).ToArray();");
            }
            else if (member.type == Constants.TypeStruct)
            {
                code.Add(memberName, " = ", DataClass(member.typeid), ".", settings.DeserializeMethod,  "(serializable.", member.name, ", database);");
            }
            else if (member.type == Constants.TypeStructList)
            {
                code.Add(memberName, " = ", "serializable.", member.name, "?.Select(item => ", DataClass(member.typeid), ".", settings.DeserializeMethod, "(item, database)).ToArray();");
            }
            else if (member.type == Constants.TypeInt)
            {
                MinMaxInt(member, out var minvalue, out var maxvalue);
                code.Add(memberName, " = new NumericValue<int>(serializable.", member.name, ", ", minvalue.ToString(), ", ", maxvalue.ToString(), ");");
            }
            else if (member.type == Constants.TypeFloat)
            {
                MinMaxFloat(member, out var minvalue, out var maxvalue);
                code.Add(memberName, " = new NumericValue<float>(serializable.", member.name, ", ", minvalue.ToString(), "f, ", maxvalue.ToString(), "f);");
            }
            else if (member.type == Constants.TypeColor)
            {
                code.Add(memberName, " = Utils.ColorUtils.ColorFromString(serializable.", member.name, ");");
            }
            else if (member.type == Constants.TypeLayout)
            {
                code.Add(memberName, " = new Layout(serializable.", member.name, ");");
            }
            else if (member.type == Constants.TypeAudioClip)
            {
                code.Add(memberName, " = new AudioClipId(serializable.", member.name, ");");
            }
            else if (member.type == Constants.TypeImage)
            {
                code.Add(memberName, " = new SpriteId(serializable.", member.name, ");");
            }
            else
            {
                code.Add(memberName, " = serializable.", member.name, ";");
            }
        }

        public static void WriteSerializableMember(XmlClassMember member, CodeFormatter code, DatabaseSchema schema)
        {
            if (member.type == Constants.TypeInt)
            {
                code.Add("public int ", member.name, ";");
            }
            else if (member.type == Constants.TypeFloat)
            {
                code.Add("public float ", member.name, ";");
            }
            else if (member.type == Constants.TypeBool)
            {
                code.Add("public bool ", member.name, ";");
            }
            else if (member.type == Constants.TypeString)
            {
                code.Add(DefaultStringValue);
                code.Add("public string ", member.name, ";");
            }
            else if (member.type == Constants.TypeColor)
            {
                code.Add(DefaultStringValue);
                code.Add("public string ", member.name, ";");
            }
            else if (member.type == Constants.TypeImage)
            {
                code.Add(DefaultStringValue);
                code.Add("public string ", member.name, ";");
            }
            else if (member.type == Constants.TypeAudioClip)
            {
                code.Add(DefaultStringValue);
                code.Add("public string ", member.name, ";");
            }
            else if (member.type == Constants.TypeLayout)
            {
                code.Add(DefaultStringValue);
                code.Add("public string ", member.name, ";");
            }
            else if (member.type == Constants.TypeVector)
            {
                code.Add("public Vector ", member.name, ";");
            }
            else if (member.type == Constants.TypeEnum)
            {
                if (!schema.HasEnum(member.typeid))
                    throw new InvalidSchemaException("Unknown enum type in class member " + member.name);

                code.Add("public ", member.typeid, " ", member.name, ";");
            }
            else if (member.type == Constants.TypeObject)
            {
                if (!schema.HasObject(member.typeid))
                    throw new InvalidSchemaException("Unknown object type in class member " + member.name);

                code.Add("public int ", member.name, ";");
            }
            else if (member.type == Constants.TypeObjectList)
            {
                if (!schema.HasObject(member.typeid))
                    throw new InvalidSchemaException("Unknown object type in class member " + member.name);

                code.Add("public int[] ", member.name, ";");
            }
            else if (member.type == Constants.TypeStruct)
            {
                if (!schema.HasStruct(member.typeid))
                    throw new InvalidSchemaException("Unknown struct type in class member " + member.name);

                code.Add("public ", SerializableClass(member.typeid), " ", member.name, ";");
            }
            else if (member.type == Constants.TypeStructList)
            {
                if (!schema.HasStruct(member.typeid))
                    throw new InvalidSchemaException("Unknown struct type in class member " + member.name);

                code.Add("public ", SerializableClass(member.typeid), "[] ", member.name, ";");
            }
            else
            {
                throw new InvalidSchemaException("Invalid class member type - " + member.type);
            }
        }

        public static void WriteDataMember(XmlClassMember member, CodeFormatter code, DatabaseSchema schema)
        {
            var memberName = !string.IsNullOrEmpty(member.alias) ? member.alias : member.name;
            if (member.type == Constants.TypeInt)
            {
                MinMaxInt(member, out var minvalue, out var maxvalue);
                code.Add("public NumericValue<int> ", memberName, " = new NumericValue<int>(0,", minvalue.ToString(), ",",maxvalue.ToString(),");");
            }
            else if (member.type == Constants.TypeFloat)
            {
                MinMaxFloat(member, out var minvalue, out var maxvalue);
                code.Add("public NumericValue<float> ", memberName, " = new NumericValue<float>(0,", minvalue.ToString(), "f,", maxvalue.ToString(), "f);");
            }
            else if (member.type == Constants.TypeBool)
            {
                code.Add("public bool ", memberName, ";");
            }
            else if (member.type == Constants.TypeString)
            {
                code.Add("public string ", memberName, ";");
            }
            else if (member.type == Constants.TypeColor)
            {
                code.Add("public UnityEngine.Color ", memberName, ";");
            }
            else if (member.type == Constants.TypeImage)
            {
                code.Add("public SpriteId ", memberName, ";");
            }
            else if (member.type == Constants.TypeAudioClip)
            {
                code.Add("public AudioClipId ", memberName, ";");
            }
            else if (member.type == Constants.TypeLayout)
            {
                code.Add("public Layout ", memberName, ";");
            }
            else if (member.type == Constants.TypeVector)
            {
                code.Add("public Vector ", memberName, " = Vector.Zero;");
            }
            else if (member.type == Constants.TypeEnum)
            {
                if (!schema.HasEnum(member.typeid))
                    throw new InvalidSchemaException("Unknown enum type in class member " + member.name);

                code.Add("public ", member.typeid, " ", memberName, ";");
            }
            else if (member.type == Constants.TypeObject)
            {
                if (!schema.HasObject(member.typeid))
                    throw new InvalidSchemaException("Unknown object type in class member " + member.name);

                code.Add("public ItemId<", DataClass(member.typeid),"> ", memberName, " = ItemId<", DataClass(member.typeid), ">.Empty;");
            }
            else if (member.type == Constants.TypeObjectList)
            {
                if (!schema.HasObject(member.typeid))
                    throw new InvalidSchemaException("Unknown object type in class member " + member.name);

                code.Add("public Wrapper<", DataClass(member.typeid), ">[] ", memberName, ";");
            }
            else if (member.type == Constants.TypeStruct)
            {
                if (!schema.HasStruct(member.typeid))
                    throw new InvalidSchemaException("Unknown struct type in class member " + member.name);

                code.Add("public ", DataClass(member.typeid), " ", memberName, ";");
            }
            else if (member.type == Constants.TypeStructList)
            {
                if (!schema.HasStruct(member.typeid))
                    throw new InvalidSchemaException("Unknown struct type in class member " + member.name);

                code.Add("public ", DataClass(member.typeid), "[] ", memberName, ";");
            }
            else
            {
                throw new InvalidSchemaException("Invalid class member type - " + member.type);
            }
        }

        private static void MinMaxInt(XmlClassMember member, out int minvalue, out int maxvalue)
        {
            if (string.IsNullOrEmpty(member.minvalue) || !int.TryParse(member.minvalue, out minvalue)) minvalue = int.MinValue;
            if (string.IsNullOrEmpty(member.maxvalue) || !int.TryParse(member.maxvalue, out maxvalue)) maxvalue = int.MaxValue;
        }

        private static void MinMaxFloat(XmlClassMember member, out float minvalue, out float maxvalue)
        {
            if (string.IsNullOrEmpty(member.minvalue) || !float.TryParse(member.minvalue, out minvalue)) minvalue = int.MinValue;
            if (string.IsNullOrEmpty(member.maxvalue) || !float.TryParse(member.maxvalue, out maxvalue)) maxvalue = int.MaxValue;
        }

        private const string DefaultStringValue = "[DefaultValue(\"\")]";
    }
}