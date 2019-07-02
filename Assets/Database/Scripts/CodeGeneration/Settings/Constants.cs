namespace GameDatabase.CodeGeneration.Settings
{
    public static class Constants
    {
        public const string TypeInt = "int";
        public const string TypeFloat = "float";
        public const string TypeBool = "bool";
        public const string TypeEnum = "enum";
        public const string TypeString = "string";
        public const string TypeObject = "object";
        public const string TypeStruct = "struct";
        public const string TypeObjectList = "object_list";
        public const string TypeStructList = "struct_list";
        public const string TypeImage = "image";
        public const string TypeVector = "vector";
        public const string TypeColor = "color";
        public const string TypeLayout = "layout";
        public const string TypeAudioClip = "audioclip";

        public const string RootNamespace = "GameDatabase";
        public const string TypesNamespace = "Types";
        public const string UtilsNamespace = "Utils";
        public const string SerializationNamespace = "Serialization";
        public const string DataSourceNamespace = "DataSource";
        public const string DatabaseNamespace = "";

        public const string SerializableClassSuffix = "Serializable";
        public const string DataClassSuffix = "Data";

        public static readonly char[] ValueSeparators = { ',','|',';',' ','\n','\r' };

        public const string Indent = "    ";
        public const string NewLine = "\r\n";
        public const string GeneratedCodeWarning =
            "//-------------------------------------------------------------------------------" + NewLine +
            "//                                                                               " + NewLine +
            "//    This code was automatically generated.                                     " + NewLine +
            "//    Changes to this file may cause incorrect behavior and will be lost if      " + NewLine +
            "//    the code is regenerated.                                                   " + NewLine +
            "//                                                                               " + NewLine +
            "//-------------------------------------------------------------------------------" + NewLine;
    }
}
