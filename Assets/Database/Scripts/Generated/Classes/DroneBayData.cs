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
    public class DroneBayData
    {
        public static DroneBayData Deserialize(DroneBaySerializable serializable, Database database)
        {
            return new DroneBayData(serializable, database);
        }

        private DroneBayData(DroneBaySerializable serializable, Database database)
        {
            ItemId = new ItemId<DroneBayData>(serializable.Id, serializable.FileName);
            EnergyConsumption = new NumericValue<float>(serializable.EnergyConsumption, 0f, 1000f);
            PassiveEnergyConsumption = new NumericValue<float>(serializable.PassiveEnergyConsumption, 0f, 1000f);
            Range = new NumericValue<float>(serializable.Range, 1f, 100f);
            DamageMultiplier = new NumericValue<float>(serializable.DamageMultiplier, 0.01f, 100f);
            DefenseMultiplier = new NumericValue<float>(serializable.DefenseMultiplier, 0.01f, 100f);
            SpeedMultiplier = new NumericValue<float>(serializable.SpeedMultiplier, 0.01f, 100f);
            ImprovedAi = serializable.ImprovedAi;
            Capacity = new NumericValue<int>(serializable.Capacity, 1, 100);
            ActivationType = serializable.ActivationType;
            LaunchSound = new AudioClipId(serializable.LaunchSound);
            LaunchEffectPrefab = serializable.LaunchEffectPrefab;
            ControlButtonIcon = serializable.ControlButtonIcon;
        }

        public DroneBaySerializable Serialize()
        {
            var serializable = new DroneBaySerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.DroneBay;
            serializable.EnergyConsumption = EnergyConsumption.Value;
            serializable.PassiveEnergyConsumption = PassiveEnergyConsumption.Value;
            serializable.Range = Range.Value;
            serializable.DamageMultiplier = DamageMultiplier.Value;
            serializable.DefenseMultiplier = DefenseMultiplier.Value;
            serializable.SpeedMultiplier = SpeedMultiplier.Value;
            serializable.ImprovedAi = ImprovedAi;
            serializable.Capacity = Capacity.Value;
            serializable.ActivationType = ActivationType;
            serializable.LaunchSound = LaunchSound.ToString();
            serializable.LaunchEffectPrefab = LaunchEffectPrefab;
            serializable.ControlButtonIcon = ControlButtonIcon;
            return serializable;
        }

        public readonly ItemId<DroneBayData> ItemId;
        public NumericValue<float> EnergyConsumption = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> PassiveEnergyConsumption = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Range = new NumericValue<float>(0,1f,100f);
        public NumericValue<float> DamageMultiplier = new NumericValue<float>(0,0.01f,100f);
        public NumericValue<float> DefenseMultiplier = new NumericValue<float>(0,0.01f,100f);
        public NumericValue<float> SpeedMultiplier = new NumericValue<float>(0,0.01f,100f);
        public bool ImprovedAi;
        public NumericValue<int> Capacity = new NumericValue<int>(0,1,100);
        public ActivationType ActivationType;
        public AudioClipId LaunchSound;
        public string LaunchEffectPrefab;
        public string ControlButtonIcon;
    }
}
