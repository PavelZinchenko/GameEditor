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
    public class SatelliteBuildData
    {
        public static SatelliteBuildData Deserialize(SatelliteBuildSerializable serializable, Database database)
        {
            return new SatelliteBuildData(serializable, database);
        }

        private SatelliteBuildData(SatelliteBuildSerializable serializable, Database database)
        {
            ItemId = new ItemId<SatelliteBuildData>(serializable.Id, serializable.FileName);
            SatelliteId = database.GetSatelliteId(serializable.SatelliteId);
            NotAvailableInGame = serializable.NotAvailableInGame;
            DifficultyClass = serializable.DifficultyClass;
            Components = serializable.Components?.Select(item => InstalledComponentData.Deserialize(item, database)).ToArray();
        }

        public SatelliteBuildSerializable Serialize()
        {
            var serializable = new SatelliteBuildSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.SatelliteBuild;
            serializable.SatelliteId = SatelliteId.Id;
            serializable.NotAvailableInGame = NotAvailableInGame;
            serializable.DifficultyClass = DifficultyClass;
            serializable.Components = Components?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<SatelliteBuildData> ItemId;
        public ItemId<SatelliteData> SatelliteId = ItemId<SatelliteData>.Empty;
        public bool NotAvailableInGame;
        public DifficultyClass DifficultyClass;
        public InstalledComponentData[] Components;
    }
}
