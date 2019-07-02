namespace GameDatabase.Types
{
    public struct SpriteId
    {
        //public enum Type
        //{
        //    Default,
        //    Ship,
        //    ShipIcon,
        //    Component,
        //    Satellite,
        //    ActionButton,
        //    GuiIcon,
        //    SkillIcon,
        //    AvatarIcon,
        //    ArtifactIcon,
        //    Ammunition,
        //    Effect,
        //}

        public SpriteId(string name/*, Type type*/)
        {
            Id = name;
            //Category = type;
        }

        public override string ToString()
        {
            return Id;
        }

        public static implicit operator bool(SpriteId spriteId)
        {
            return !string.IsNullOrEmpty(spriteId.Id);
        }

        //public Type Category { get; }
        public string Id { get; }

        public static readonly SpriteId Empty = new SpriteId();
    }
}
