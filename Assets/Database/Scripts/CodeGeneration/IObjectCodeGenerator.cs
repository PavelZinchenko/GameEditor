using GameDatabase.CodeGeneration.Settings;

namespace GameDatabase.CodeGeneration
{
    public enum ObjectType
    {
        SimpleObject,
        SimpleStruct,
        MutableObject,
        MutableStruct,
    }

    public interface IObjectCodeGenerator
    {
        void Generate(XmlClassItem data, ObjectType type, GeneratorSettings settings);
    }
}
