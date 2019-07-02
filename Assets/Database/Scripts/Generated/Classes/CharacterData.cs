//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using GameDatabase.Types;
using GameDatabase.Utils;
using GameDatabase.Serializable;
using GameDatabase.Enums;

namespace GameDatabase.Classes
{
    public class CharacterData
    {
        public static CharacterData Deserialize(CharacterSerializable serializable, Database database)
        {
            return new CharacterData(serializable, database);
        }

        private CharacterData(CharacterSerializable serializable, Database database)
        {
            ItemId = new ItemId<CharacterData>(serializable.Id, serializable.FileName);
            Name = serializable.Name;
            AvatarIcon = new SpriteId(serializable.AvatarIcon);
            Faction = database.GetFactionId(serializable.Faction);
            Inventory = database.GetLootId(serializable.Inventory);
            Fleet = database.GetFleetId(serializable.Fleet);
            Relations = new NumericValue<int>(serializable.Relations, 0, 100);
            IsUnique = serializable.IsUnique;
        }

        public CharacterSerializable Serialize()
        {
            var serializable = new CharacterSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Character;
            serializable.Name = Name;
            serializable.AvatarIcon = AvatarIcon.ToString();
            serializable.Faction = Faction.Id;
            serializable.Inventory = Inventory.Id;
            serializable.Fleet = Fleet.Id;
            serializable.Relations = Relations.Value;
            serializable.IsUnique = IsUnique;
            return serializable;
        }

        public readonly ItemId<CharacterData> ItemId;
        public string Name;
        public SpriteId AvatarIcon;
        public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
        public ItemId<LootData> Inventory = ItemId<LootData>.Empty;
        public ItemId<FleetData> Fleet = ItemId<FleetData>.Empty;
        public NumericValue<int> Relations = new NumericValue<int>(0,0,100);
        public bool IsUnique;
    }
}
