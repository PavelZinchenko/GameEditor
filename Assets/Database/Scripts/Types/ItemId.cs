using GameDatabase.Serialization;

namespace GameDatabase.Types
{
    public interface IItemId
    {
        int Id { get; }
        string Name { get; }
        bool IsNull { get; }
    }

    public class ItemId<T> : IItemId
    {
        public ItemId(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ItemId(SerializableItem item)
        {
            if (item == null)
            {
                Id = 0;
                Name = string.Empty;
                return;
            }

            Id = item.Id;
            Name = item.FileName;
        }

        public int Id { get; }
        public string Name { get; }

        public bool IsNull => Id <= 0;

        public override int GetHashCode() { return Id; }

        public override bool Equals(object obj)
        {
            if (obj is ItemId<T>)
            {
                return Id == ((ItemId<T>)obj).Id;
            }

            if (obj is int)
            {
                return Id == (int)obj;
            }

            return false;
        }

        public override string ToString() { return string.IsNullOrEmpty(Name) ? "[EMPTY]" : Name; }

        public static readonly ItemId<T> Empty = new ItemId<T>(0, string.Empty);
    }
}
