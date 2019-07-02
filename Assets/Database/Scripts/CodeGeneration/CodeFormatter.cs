using System.Text;
using GameDatabase.CodeGeneration.Settings;
using UnityEngine.Assertions;

namespace GameDatabase.CodeGeneration
{
    public class CodeFormatter
    {
        public CodeFormatter()
        {
            _sb = new StringBuilder();
            _sb.AppendLine(Constants.GeneratedCodeWarning);
        }

        public void OpenBraces()
        {
            Indent();
            _sb.AppendLine("{");
            _nestingCounter++;
        }

        public void CloseBraces()
        {
            Assert.IsTrue(_nestingCounter > 0);
            _nestingCounter--;
            Indent();
            _sb.AppendLine("}");
        }

        public void Add(params string[] items)
        {
            Indent();
            foreach (var item in items)
                _sb.Append(item);
            _sb.AppendLine();
        }

        public void Class(string name, bool isPublic = true, params string[] interfaces)
        {
            Indent();
            _sb.Append(isPublic ? "public " : "private ");
            _sb.Append("class ");
            _sb.Append(name);
            if (interfaces != null && interfaces.Length > 0)
            {
                var first = true;
                foreach (var item in interfaces)
                {
                    _sb.Append(first ? " : " : ", ");
                    _sb.Append(item);
                    first = false;
                }
            }

            _sb.AppendLine();
            OpenBraces();
        }

        public void NewLine()
        {
            _sb.AppendLine();
        }

        public void UseNamespace(string name, bool isRelative = true)
        {
            Assert.AreEqual(_nestingCounter, 0);
            if (string.IsNullOrEmpty(name)) return;

            _sb.Append("using ");
            if (isRelative) _sb.Append(Constants.RootNamespace);

            if (!string.IsNullOrEmpty(name))
            {
                if (isRelative) _sb.Append(".");
                _sb.Append(name);
            }

            _sb.AppendLine(";");
        }

        public void Namespace(string name)
        {
            Assert.AreEqual(_nestingCounter, 0);

            _sb.Append("namespace ");
            _sb.Append(Constants.RootNamespace);

            if (!string.IsNullOrEmpty(name))
            {
                _sb.Append(".");
                _sb.Append(name);
            }

            _sb.AppendLine();
            OpenBraces();
        }

        public override string ToString()
        {
            while (_nestingCounter > 0)
                CloseBraces();

            return _sb.ToString(); 
        }

        private void Indent()
        {
            for (var i = 0; i < _nestingCounter; ++i)
                _sb.Append(Constants.Indent);
        }

        private int _nestingCounter;
        private readonly StringBuilder _sb;
    }
}
