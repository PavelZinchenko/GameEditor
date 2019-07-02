using GameDatabase.CodeGeneration.Settings;

namespace GameDatabase.CodeGeneration
{
    public interface IEnumCodeGenerator
    {
        void Generate(XmlEnumItem data, GeneratorSettings settings);
    }
}
