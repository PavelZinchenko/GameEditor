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
    public class ShipBuildData
    {
        public static ShipBuildData Deserialize(ShipBuildSerializable serializable, Database database)
        {
            return new ShipBuildData(serializable, database);
        }

        private ShipBuildData(ShipBuildSerializable serializable, Database database)
        {
            ItemId = new ItemId<ShipBuildData>(serializable.Id, serializable.FileName);
            ShipId = database.GetShipId(serializable.ShipId);
            NotAvailableInGame = serializable.NotAvailableInGame;
            DifficultyClass = serializable.DifficultyClass;
            BuildFaction = database.GetFactionId(serializable.BuildFaction);
            Components = serializable.Components?.Select(item => InstalledComponentData.Deserialize(item, database)).ToArray();
        }

        public ShipBuildSerializable Serialize()
        {
            var serializable = new ShipBuildSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.ShipBuild;
            serializable.ShipId = ShipId.Id;
            serializable.NotAvailableInGame = NotAvailableInGame;
            serializable.DifficultyClass = DifficultyClass;
            serializable.BuildFaction = BuildFaction.Id;
            serializable.Components = Components?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<ShipBuildData> ItemId;
        public ItemId<ShipData> ShipId = ItemId<ShipData>.Empty;
        public bool NotAvailableInGame;
        public DifficultyClass DifficultyClass;
        public ItemId<FactionData> BuildFaction = ItemId<FactionData>.Empty;
        public InstalledComponentData[] Components;
    }
}
