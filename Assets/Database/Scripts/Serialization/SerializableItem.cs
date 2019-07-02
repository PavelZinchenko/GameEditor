using System;

namespace GameDatabase.Serialization
{
    [Serializable]
    public class SerializableItem
    {
        public string FileName { get; set; }
        public int ItemType;
        public int Id;
    }
}
