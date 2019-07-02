using GameDatabase.CodeGeneration.Settings;

namespace GameDatabase.CodeGeneration
{
    public interface IDatabaseCodeGenerator
    {
        void AddClass(string name, string type);
        void AddConfiguration(string name, string type);
        void Generate(GeneratorSettings context);
    }
}