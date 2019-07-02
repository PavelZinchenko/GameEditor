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
    public class FleetData
    {
        public static FleetData Deserialize(FleetSerializable serializable, Database database)
        {
            return new FleetData(serializable, database);
        }

        private FleetData(FleetSerializable serializable, Database database)
        {
            ItemId = new ItemId<FleetData>(serializable.Id, serializable.FileName);
            Factions = FactionFilterData.Deserialize(serializable.Factions, database);
            LevelBonus = new NumericValue<int>(serializable.LevelBonus, -100, 100);
            NoRandomShips = serializable.NoRandomShips;
            CombatTimeLimit = new NumericValue<int>(serializable.CombatTimeLimit, 0, 999);
            LootCondition = serializable.LootCondition;
            ExpCondition = serializable.ExpCondition;
            SpecificShips = serializable.SpecificShips?.Select(item => new Wrapper<ShipBuildData> { Item = database.GetShipBuildId(item) }).ToArray();
        }

        public FleetSerializable Serialize()
        {
            var serializable = new FleetSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Fleet;
            serializable.Factions = Factions.Serialize();
            serializable.LevelBonus = LevelBonus.Value;
            serializable.NoRandomShips = NoRandomShips;
            serializable.CombatTimeLimit = CombatTimeLimit.Value;
            serializable.LootCondition = LootCondition;
            serializable.ExpCondition = ExpCondition;
            serializable.SpecificShips = SpecificShips?.Select(item => item.Item.Id).ToArray();
            return serializable;
        }

        public readonly ItemId<FleetData> ItemId;
        public FactionFilterData Factions;
        public NumericValue<int> LevelBonus = new NumericValue<int>(0,-100,100);
        public bool NoRandomShips;
        public NumericValue<int> CombatTimeLimit = new NumericValue<int>(0,0,999);
        public RewardCondition LootCondition;
        public RewardCondition ExpCondition;
        public Wrapper<ShipBuildData>[] SpecificShips;
    }
}
