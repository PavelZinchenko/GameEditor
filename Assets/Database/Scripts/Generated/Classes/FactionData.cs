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
    public class FactionData
    {
        public static FactionData Deserialize(FactionSerializable serializable, Database database)
        {
            return new FactionData(serializable, database);
        }

        private FactionData(FactionSerializable serializable, Database database)
        {
            ItemId = new ItemId<FactionData>(serializable.Id, serializable.FileName);
            Type = serializable.Type;
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            HomeStarDistance = new NumericValue<int>(serializable.HomeStarDistance, 0, 1000);
            WanderingShipsDistance = new NumericValue<int>(serializable.WanderingShipsDistance, 0, 1000);
            Hidden = serializable.Hidden;
        }

        public FactionSerializable Serialize()
        {
            var serializable = new FactionSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Faction;
            serializable.Type = Type;
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.HomeStarDistance = HomeStarDistance.Value;
            serializable.WanderingShipsDistance = WanderingShipsDistance.Value;
            serializable.Hidden = Hidden;
            return serializable;
        }

        public readonly ItemId<FactionData> ItemId;
        public string Type;
        public UnityEngine.Color Color;
        public NumericValue<int> HomeStarDistance = new NumericValue<int>(0,0,1000);
        public NumericValue<int> WanderingShipsDistance = new NumericValue<int>(0,0,1000);
        public bool Hidden;
    }
}
