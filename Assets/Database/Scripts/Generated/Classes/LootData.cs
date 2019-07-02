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
    public class LootData
    {
        public static LootData Deserialize(LootSerializable serializable, Database database)
        {
            return new LootData(serializable, database);
        }

        private LootData(LootSerializable serializable, Database database)
        {
            ItemId = new ItemId<LootData>(serializable.Id, serializable.FileName);
            Loot = LootContentData.Deserialize(serializable.Loot, database);
        }

        public LootSerializable Serialize()
        {
            var serializable = new LootSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Loot;
            serializable.Loot = Loot.Serialize();
            return serializable;
        }

        public readonly ItemId<LootData> ItemId;
        public LootContentData Loot;
    }
}
