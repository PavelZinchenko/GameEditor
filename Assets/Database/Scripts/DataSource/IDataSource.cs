using System.Collections.Generic;

namespace GameDatabase.DataSource
{
    public interface IDataSource
    {
        IEnumerable<JsonFile> Files { get; }
    }

    public struct JsonFile
    {
        public string Name;
        public string Content;
    }
}
