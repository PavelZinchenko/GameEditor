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
    public class DeviceData
    {
        public static DeviceData Deserialize(DeviceSerializable serializable, Database database)
        {
            return new DeviceData(serializable, database);
        }

        private DeviceData(DeviceSerializable serializable, Database database)
        {
            ItemId = new ItemId<DeviceData>(serializable.Id, serializable.FileName);
            DeviceClass = serializable.DeviceClass;
            EnergyConsumption = new NumericValue<float>(serializable.EnergyConsumption, 0f, 1000f);
            PassiveEnergyConsumption = new NumericValue<float>(serializable.PassiveEnergyConsumption, 0f, 1000f);
            Power = new NumericValue<float>(serializable.Power, 0f, 1000f);
            Range = new NumericValue<float>(serializable.Range, 0f, 1000f);
            Size = new NumericValue<float>(serializable.Size, 0f, 1000f);
            Cooldown = new NumericValue<float>(serializable.Cooldown, 0f, 1000f);
            Offset = serializable.Offset;
            ActivationType = serializable.ActivationType;
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            Sound = new AudioClipId(serializable.Sound);
            EffectPrefab = serializable.EffectPrefab;
            ObjectPrefab = serializable.ObjectPrefab;
            ControlButtonIcon = serializable.ControlButtonIcon;
        }

        public DeviceSerializable Serialize()
        {
            var serializable = new DeviceSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Device;
            serializable.DeviceClass = DeviceClass;
            serializable.EnergyConsumption = EnergyConsumption.Value;
            serializable.PassiveEnergyConsumption = PassiveEnergyConsumption.Value;
            serializable.Power = Power.Value;
            serializable.Range = Range.Value;
            serializable.Size = Size.Value;
            serializable.Cooldown = Cooldown.Value;
            serializable.Offset = Offset;
            serializable.ActivationType = ActivationType;
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.Sound = Sound.ToString();
            serializable.EffectPrefab = EffectPrefab;
            serializable.ObjectPrefab = ObjectPrefab;
            serializable.ControlButtonIcon = ControlButtonIcon;
            return serializable;
        }

        public readonly ItemId<DeviceData> ItemId;
        public DeviceClass DeviceClass;
        public NumericValue<float> EnergyConsumption = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> PassiveEnergyConsumption = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Power = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Range = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Size = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Cooldown = new NumericValue<float>(0,0f,1000f);
        public Vector Offset = Vector.Zero;
        public ActivationType ActivationType;
        public UnityEngine.Color Color;
        public AudioClipId Sound;
        public string EffectPrefab;
        public string ObjectPrefab;
        public string ControlButtonIcon;
    }
}
