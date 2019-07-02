using GameDatabase.CodeGeneration.EditorCode;
using UnityEditor;
using UnityEngine;

namespace GameDatabase.CodeGeneration
{
    public class CodeGeneratorWindow : EditorWindow
    {
        [MenuItem("Window/Code Generator")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(CodeGeneratorWindow));
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Generate from XML"))
                GenerateCode();
        }

        private void GenerateCode()
        {
            var schema = DatabaseSchema.Load("Schema");
            var writer = new CodeWriter { RootFolder = "Assets/Database/Scripts/Generated" };

            var enumGenerator = new EnumCodeGenerator(writer);
            var databaseGenerator = new DatabaseCodeGenerator(schema, writer);
            var objectCodeGenerator = new ObjectCodeGenerator(schema, writer);

            var builder = new CodeBuilder(schema, writer, enumGenerator, databaseGenerator, objectCodeGenerator);

            builder.Build();
        }
    }
}
