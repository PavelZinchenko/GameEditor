namespace GameDatabase.CodeGeneration.Settings
{
    public class GeneratorSettings
    {
        public string DatabaseClass = "Database";

        public string SerializeMethod = "Serialize";
        public string DeserializeMethod = "Deserialize";

        public string EnumsNamespace = "Enums";
        public string ClassesNamespace = "Classes";
        public string SerializableNamespace = "Serializable";
        public string DatabaseNamespace = "";

        public bool ReadOnlyDatabase { get; set; }
    }
}
