using System;

namespace Database.Types
{
    [Serializable]
    public class SerializableItem
    {
        public string FileName { get; set; }
        public int ItemType;
        public int Id;
    }
}
