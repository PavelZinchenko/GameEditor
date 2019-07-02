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
    public class ComponentData
    {
        public static ComponentData Deserialize(ComponentSerializable serializable, Database database)
        {
            return new ComponentData(serializable, database);
        }

        private ComponentData(ComponentSerializable serializable, Database database)
        {
            ItemId = new ItemId<ComponentData>(serializable.Id, serializable.FileName);
            Name = serializable.Name;
            Description = serializable.Description;
            DisplayCategory = serializable.DisplayCategory;
            Availability = serializable.Availability;
            ComponentStatsId = database.GetComponentStatsId(serializable.ComponentStatsId);
            Faction = database.GetFactionId(serializable.Faction);
            Level = new NumericValue<int>(serializable.Level, 0, 500);
            Icon = new SpriteId(serializable.Icon);
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            Layout = new Layout(serializable.Layout);
            CellType = serializable.CellType;
            DeviceId = database.GetDeviceId(serializable.DeviceId);
            WeaponId = database.GetWeaponId(serializable.WeaponId);
            AmmunitionId = database.GetAmmunitionId(serializable.AmmunitionId);
            AmmunitionObsoleteId = database.GetAmmunitionObsoleteId(serializable.AmmunitionObsoleteId);
            WeaponSlotType = serializable.WeaponSlotType;
            DroneBayId = database.GetDroneBayId(serializable.DroneBayId);
            DroneId = database.GetShipBuildId(serializable.DroneId);
            PossibleModifications = serializable.PossibleModifications?.Select(item => new Wrapper<ComponentModData> { Item = database.GetComponentModId(item) }).ToArray();
        }

        public ComponentSerializable Serialize()
        {
            var serializable = new ComponentSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Component;
            serializable.Name = Name;
            serializable.Description = Description;
            serializable.DisplayCategory = DisplayCategory;
            serializable.Availability = Availability;
            serializable.ComponentStatsId = ComponentStatsId.Id;
            serializable.Faction = Faction.Id;
            serializable.Level = Level.Value;
            serializable.Icon = Icon.ToString();
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.Layout = Layout.Data;
            serializable.CellType = CellType;
            serializable.DeviceId = DeviceId.Id;
            serializable.WeaponId = WeaponId.Id;
            serializable.AmmunitionId = AmmunitionId.Id;
            serializable.AmmunitionObsoleteId = AmmunitionObsoleteId.Id;
            serializable.WeaponSlotType = WeaponSlotType;
            serializable.DroneBayId = DroneBayId.Id;
            serializable.DroneId = DroneId.Id;
            serializable.PossibleModifications = PossibleModifications?.Select(item => item.Item.Id).ToArray();
            return serializable;
        }

        public readonly ItemId<ComponentData> ItemId;
        public string Name;
        public string Description;
        public ComponentCategory DisplayCategory;
        public Availability Availability;
        public ItemId<ComponentStatsData> ComponentStatsId = ItemId<ComponentStatsData>.Empty;
        public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
        public NumericValue<int> Level = new NumericValue<int>(0,0,500);
        public SpriteId Icon;
        public UnityEngine.Color Color;
        public Layout Layout;
        public string CellType;
        public ItemId<DeviceData> DeviceId = ItemId<DeviceData>.Empty;
        public ItemId<WeaponData> WeaponId = ItemId<WeaponData>.Empty;
        public ItemId<AmmunitionData> AmmunitionId = ItemId<AmmunitionData>.Empty;
        public ItemId<AmmunitionObsoleteData> AmmunitionObsoleteId = ItemId<AmmunitionObsoleteData>.Empty;
        public string WeaponSlotType;
        public ItemId<DroneBayData> DroneBayId = ItemId<DroneBayData>.Empty;
        public ItemId<ShipBuildData> DroneId = ItemId<ShipBuildData>.Empty;
        public Wrapper<ComponentModData>[] PossibleModifications;
    }
}
