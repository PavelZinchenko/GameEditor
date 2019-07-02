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
    public class ShipSettingsData
    {
        public static ShipSettingsData Deserialize(ShipSettingsSerializable serializable, Database database)
        {
            return new ShipSettingsData(serializable, database);
        }

        private ShipSettingsData(ShipSettingsSerializable serializable, Database database)
        {
            ItemId = new ItemId<ShipSettingsData>(serializable.Id, serializable.FileName);
            DefaultWeightPerCell = new NumericValue<float>(serializable.DefaultWeightPerCell, 1f, 1000f);
            MinimumWeightPerCell = new NumericValue<float>(serializable.MinimumWeightPerCell, 1f, 1000f);
            BaseArmorPoints = new NumericValue<float>(serializable.BaseArmorPoints, 0f, 10000f);
            ArmorPointsPerCell = new NumericValue<float>(serializable.ArmorPointsPerCell, 0f, 10000f);
            ArmorRepairCooldown = new NumericValue<float>(serializable.ArmorRepairCooldown, 0f, 60f);
            BaseEnergyPoints = new NumericValue<float>(serializable.BaseEnergyPoints, 0f, 1000f);
            BaseEnergyRechargeRate = new NumericValue<float>(serializable.BaseEnergyRechargeRate, 0f, 100f);
            EnergyRechargeCooldown = new NumericValue<float>(serializable.EnergyRechargeCooldown, 0f, 60f);
            BaseShieldRechargeRate = new NumericValue<float>(serializable.BaseShieldRechargeRate, 0f, 100f);
            ShieldRechargeCooldown = new NumericValue<float>(serializable.ShieldRechargeCooldown, 0f, 60f);
            BaseDroneReconstructionSpeed = new NumericValue<float>(serializable.BaseDroneReconstructionSpeed, 0f, 1f);
            MaxVelocity = new NumericValue<float>(serializable.MaxVelocity, 5f, 30f);
            MaxTurnRate = new NumericValue<float>(serializable.MaxTurnRate, 5f, 30f);
        }

        public ShipSettingsSerializable Serialize()
        {
            var serializable = new ShipSettingsSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.ShipSettings;
            serializable.DefaultWeightPerCell = DefaultWeightPerCell.Value;
            serializable.MinimumWeightPerCell = MinimumWeightPerCell.Value;
            serializable.BaseArmorPoints = BaseArmorPoints.Value;
            serializable.ArmorPointsPerCell = ArmorPointsPerCell.Value;
            serializable.ArmorRepairCooldown = ArmorRepairCooldown.Value;
            serializable.BaseEnergyPoints = BaseEnergyPoints.Value;
            serializable.BaseEnergyRechargeRate = BaseEnergyRechargeRate.Value;
            serializable.EnergyRechargeCooldown = EnergyRechargeCooldown.Value;
            serializable.BaseShieldRechargeRate = BaseShieldRechargeRate.Value;
            serializable.ShieldRechargeCooldown = ShieldRechargeCooldown.Value;
            serializable.BaseDroneReconstructionSpeed = BaseDroneReconstructionSpeed.Value;
            serializable.MaxVelocity = MaxVelocity.Value;
            serializable.MaxTurnRate = MaxTurnRate.Value;
            return serializable;
        }

        public readonly ItemId<ShipSettingsData> ItemId;
        public NumericValue<float> DefaultWeightPerCell = new NumericValue<float>(0,1f,1000f);
        public NumericValue<float> MinimumWeightPerCell = new NumericValue<float>(0,1f,1000f);
        public NumericValue<float> BaseArmorPoints = new NumericValue<float>(0,0f,10000f);
        public NumericValue<float> ArmorPointsPerCell = new NumericValue<float>(0,0f,10000f);
        public NumericValue<float> ArmorRepairCooldown = new NumericValue<float>(0,0f,60f);
        public NumericValue<float> BaseEnergyPoints = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> BaseEnergyRechargeRate = new NumericValue<float>(0,0f,100f);
        public NumericValue<float> EnergyRechargeCooldown = new NumericValue<float>(0,0f,60f);
        public NumericValue<float> BaseShieldRechargeRate = new NumericValue<float>(0,0f,100f);
        public NumericValue<float> ShieldRechargeCooldown = new NumericValue<float>(0,0f,60f);
        public NumericValue<float> BaseDroneReconstructionSpeed = new NumericValue<float>(0,0f,1f);
        public NumericValue<float> MaxVelocity = new NumericValue<float>(0,5f,30f);
        public NumericValue<float> MaxTurnRate = new NumericValue<float>(0,5f,30f);
    }
}
