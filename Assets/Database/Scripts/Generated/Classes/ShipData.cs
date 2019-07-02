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
    public class ShipData
    {
        public static ShipData Deserialize(ShipSerializable serializable, Database database)
        {
            return new ShipData(serializable, database);
        }

        private ShipData(ShipSerializable serializable, Database database)
        {
            ItemId = new ItemId<ShipData>(serializable.Id, serializable.FileName);
            ShipCategory = serializable.ShipCategory;
            Name = serializable.Name;
            Faction = database.GetFactionId(serializable.Faction);
            SizeClass = serializable.SizeClass;
            IconImage = new SpriteId(serializable.IconImage);
            IconScale = new NumericValue<float>(serializable.IconScale, 0.1f, 100f);
            ModelImage = new SpriteId(serializable.ModelImage);
            ModelScale = new NumericValue<float>(serializable.ModelScale, 0.1f, 100f);
            EnginePosition = serializable.EnginePosition;
            EngineColor = Utils.ColorUtils.ColorFromString(serializable.EngineColor);
            EngineSize = new NumericValue<float>(serializable.EngineSize, 0f, 1f);
            EnergyResistance = new NumericValue<float>(serializable.EnergyResistance, 0f, 100f);
            KineticResistance = new NumericValue<float>(serializable.KineticResistance, 0f, 100f);
            HeatResistance = new NumericValue<float>(serializable.HeatResistance, 0f, 100f);
            Regeneration = serializable.Regeneration;
            BaseWeightModifier = new NumericValue<float>(serializable.BaseWeightModifier, -0.9f, 100f);
            BuiltinDevices = serializable.BuiltinDevices?.Select(item => new Wrapper<DeviceData> { Item = database.GetDeviceId(item) }).ToArray();
            Layout = new Layout(serializable.Layout);
            Barrels = serializable.Barrels?.Select(item => BarrelData.Deserialize(item, database)).ToArray();
        }

        public ShipSerializable Serialize()
        {
            var serializable = new ShipSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Ship;
            serializable.ShipCategory = ShipCategory;
            serializable.Name = Name;
            serializable.Faction = Faction.Id;
            serializable.SizeClass = SizeClass;
            serializable.IconImage = IconImage.ToString();
            serializable.IconScale = IconScale.Value;
            serializable.ModelImage = ModelImage.ToString();
            serializable.ModelScale = ModelScale.Value;
            serializable.EnginePosition = EnginePosition;
            serializable.EngineColor = Utils.ColorUtils.ColorToString(EngineColor);
            serializable.EngineSize = EngineSize.Value;
            serializable.EnergyResistance = EnergyResistance.Value;
            serializable.KineticResistance = KineticResistance.Value;
            serializable.HeatResistance = HeatResistance.Value;
            serializable.Regeneration = Regeneration;
            serializable.BaseWeightModifier = BaseWeightModifier.Value;
            serializable.BuiltinDevices = BuiltinDevices?.Select(item => item.Item.Id).ToArray();
            serializable.Layout = Layout.Data;
            serializable.Barrels = Barrels?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<ShipData> ItemId;
        public ShipCategory ShipCategory;
        public string Name;
        public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
        public SizeClass SizeClass;
        public SpriteId IconImage;
        public NumericValue<float> IconScale = new NumericValue<float>(0,0.1f,100f);
        public SpriteId ModelImage;
        public NumericValue<float> ModelScale = new NumericValue<float>(0,0.1f,100f);
        public Vector EnginePosition = Vector.Zero;
        public UnityEngine.Color EngineColor;
        public NumericValue<float> EngineSize = new NumericValue<float>(0,0f,1f);
        public NumericValue<float> EnergyResistance = new NumericValue<float>(0,0f,100f);
        public NumericValue<float> KineticResistance = new NumericValue<float>(0,0f,100f);
        public NumericValue<float> HeatResistance = new NumericValue<float>(0,0f,100f);
        public bool Regeneration;
        public NumericValue<float> BaseWeightModifier = new NumericValue<float>(0,-0.9f,100f);
        public Wrapper<DeviceData>[] BuiltinDevices;
        public Layout Layout;
        public BarrelData[] Barrels;
    }
}
