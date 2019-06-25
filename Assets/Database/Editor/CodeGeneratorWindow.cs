using UnityEditor;
using UnityEngine;

namespace Database.CodeGeneration
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
            CodeGenerator.Generate("Schema", "Assets/Database/Scripts/Generated");
        }
    }
}
