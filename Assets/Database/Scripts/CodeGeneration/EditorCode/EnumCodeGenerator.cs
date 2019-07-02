using GameDatabase.CodeGeneration.Settings;
using UnityEngine.Assertions;

namespace GameDatabase.CodeGeneration.EditorCode
{
    public class EnumCodeGenerator : IEnumCodeGenerator
    {
        public EnumCodeGenerator(CodeWriter writer)
        {
            Assert.IsNotNull(writer);
            _codeWriter = writer;
        }

        public void Generate(XmlEnumItem data, GeneratorSettings settings)
        {
            var code = new CodeFormatter();
            var ns = settings.EnumsNamespace;

            code.Namespace(settings.EnumsNamespace);
            code.Add("public enum ", data.name);
            code.OpenBraces();

            foreach (var item in data.items)
            {
                if (string.IsNullOrEmpty(item.value))
                    code.Add(item.name, ",");
                else
                    code.Add(item.name, " = ", item.value, ",");
            }

            _codeWriter.Write(ns, data.name, code.ToString());
        }

        private readonly CodeWriter _codeWriter;
    }
}
