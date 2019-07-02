using System.IO;

namespace GameDatabase.CodeGeneration
{
    public class CodeWriter
    {
        public string RootFolder { get; set; }

        public void Write(string ns, string filename, string content)
        {
            var fullpath = Path.Combine(RootFolder, ns.Replace(".", "/"));
            Directory.CreateDirectory(fullpath);
            File.WriteAllText(Path.Combine(fullpath, filename + Ext), content);
        }

        public void DeleteGeneratedFiles()
        {
            if (!Directory.Exists(RootFolder)) return;
            var root = new DirectoryInfo(RootFolder);

            foreach (var file in root.GetFiles())
                file.Delete();
            foreach (var dir in root.GetDirectories())
                dir.Delete(true);
        }

        private const string Ext = ".cs";
    }
}
