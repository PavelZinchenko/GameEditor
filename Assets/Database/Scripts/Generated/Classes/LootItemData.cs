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
    public class LootItemData
    {
        public static LootItemData Deserialize(LootItemSerializable serializable, Database database)
        {
            return new LootItemData(serializable, database);
        }

        private LootItemData(LootItemSerializable serializable, Database database)
        {
            Weight = new NumericValue<float>(serializable.Weight, -2.147484E+09f, 2.147484E+09f);
            Loot = LootContentData.Deserialize(serializable.Loot, database);
        }

        public LootItemSerializable Serialize()
        {
            var serializable = new LootItemSerializable();
            serializable.Weight = Weight.Value;
            serializable.Loot = Loot.Serialize();
            return serializable;
        }

        public NumericValue<float> Weight = new NumericValue<float>(0,-2.147484E+09f,2.147484E+09f);
        public LootContentData Loot;
    }
}
