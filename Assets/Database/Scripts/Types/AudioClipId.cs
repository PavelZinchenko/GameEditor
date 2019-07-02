namespace GameDatabase.Types
{
    public struct AudioClipId
    {
        public AudioClipId(string name)
        {
            var pos = string.IsNullOrEmpty(name) ? -1 : name.IndexOf('*');
            Id = pos >= 0 ? name.Remove(pos, 1) : name;
            Loop = pos >= 0;
        }

        public string Id { get; }
        public bool Loop { get; }

        public override string ToString()
        {
            return Loop ? "*" + Id : Id;
        }

        public static implicit operator bool(AudioClipId prefabId)
        {
            return !string.IsNullOrEmpty(prefabId.Id);
        }

        public static readonly AudioClipId None = new AudioClipId();
    }
}
