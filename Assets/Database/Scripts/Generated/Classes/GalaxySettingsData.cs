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
    public class GalaxySettingsData
    {
        public static GalaxySettingsData Deserialize(GalaxySettingsSerializable serializable, Database database)
        {
            return new GalaxySettingsData(serializable, database);
        }

        private GalaxySettingsData(GalaxySettingsSerializable serializable, Database database)
        {
            ItemId = new ItemId<GalaxySettingsData>(serializable.Id, serializable.FileName);
            AbandonedStarbaseFaction = database.GetFactionId(serializable.AbandonedStarbaseFaction);
            StartingShipBuilds = serializable.StartingShipBuilds?.Select(item => new Wrapper<ShipBuildData> { Item = database.GetShipBuildId(item) }).ToArray();
        }

        public GalaxySettingsSerializable Serialize()
        {
            var serializable = new GalaxySettingsSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.GalaxySettings;
            serializable.AbandonedStarbaseFaction = AbandonedStarbaseFaction.Id;
            serializable.StartingShipBuilds = StartingShipBuilds?.Select(item => item.Item.Id).ToArray();
            return serializable;
        }

        public readonly ItemId<GalaxySettingsData> ItemId;
        public ItemId<FactionData> AbandonedStarbaseFaction = ItemId<FactionData>.Empty;
        public Wrapper<ShipBuildData>[] StartingShipBuilds;
    }
}
