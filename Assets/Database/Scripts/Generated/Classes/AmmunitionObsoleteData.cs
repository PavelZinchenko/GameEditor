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
    public class AmmunitionObsoleteData
    {
        public static AmmunitionObsoleteData Deserialize(AmmunitionObsoleteSerializable serializable, Database database)
        {
            return new AmmunitionObsoleteData(serializable, database);
        }

        private AmmunitionObsoleteData(AmmunitionObsoleteSerializable serializable, Database database)
        {
            ItemId = new ItemId<AmmunitionObsoleteData>(serializable.Id, serializable.FileName);
            AmmunitionClass = serializable.AmmunitionClass;
            DamageType = serializable.DamageType;
            Impulse = new NumericValue<float>(serializable.Impulse, 0f, 10f);
            Recoil = new NumericValue<float>(serializable.Recoil, 0f, 10f);
            Size = new NumericValue<float>(serializable.Size, 0f, 1000f);
            InitialPosition = serializable.InitialPosition;
            AreaOfEffect = new NumericValue<float>(serializable.AreaOfEffect, 0f, 1000f);
            Damage = new NumericValue<float>(serializable.Damage, 0f, 1000f);
            Range = new NumericValue<float>(serializable.Range, 0f, 1000f);
            Velocity = new NumericValue<float>(serializable.Velocity, 0f, 1000f);
            LifeTime = new NumericValue<float>(serializable.LifeTime, 0f, 1000f);
            HitPoints = new NumericValue<int>(serializable.HitPoints, 0, 1000);
            IgnoresShipVelocity = serializable.IgnoresShipVelocity;
            EnergyCost = new NumericValue<float>(serializable.EnergyCost, 0f, 1000f);
            CoupledAmmunitionId = database.GetAmmunitionObsoleteId(serializable.CoupledAmmunitionId);
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            FireSound = new AudioClipId(serializable.FireSound);
            HitEffectPrefab = serializable.HitEffectPrefab;
            BulletPrefab = serializable.BulletPrefab;
        }

        public AmmunitionObsoleteSerializable Serialize()
        {
            var serializable = new AmmunitionObsoleteSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.AmmunitionObsolete;
            serializable.AmmunitionClass = AmmunitionClass;
            serializable.DamageType = DamageType;
            serializable.Impulse = Impulse.Value;
            serializable.Recoil = Recoil.Value;
            serializable.Size = Size.Value;
            serializable.InitialPosition = InitialPosition;
            serializable.AreaOfEffect = AreaOfEffect.Value;
            serializable.Damage = Damage.Value;
            serializable.Range = Range.Value;
            serializable.Velocity = Velocity.Value;
            serializable.LifeTime = LifeTime.Value;
            serializable.HitPoints = HitPoints.Value;
            serializable.IgnoresShipVelocity = IgnoresShipVelocity;
            serializable.EnergyCost = EnergyCost.Value;
            serializable.CoupledAmmunitionId = CoupledAmmunitionId.Id;
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.FireSound = FireSound.ToString();
            serializable.HitEffectPrefab = HitEffectPrefab;
            serializable.BulletPrefab = BulletPrefab;
            return serializable;
        }

        public readonly ItemId<AmmunitionObsoleteData> ItemId;
        public AmmunitionClassObsolete AmmunitionClass;
        public DamageType DamageType;
        public NumericValue<float> Impulse = new NumericValue<float>(0,0f,10f);
        public NumericValue<float> Recoil = new NumericValue<float>(0,0f,10f);
        public NumericValue<float> Size = new NumericValue<float>(0,0f,1000f);
        public Vector InitialPosition = Vector.Zero;
        public NumericValue<float> AreaOfEffect = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Damage = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Range = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Velocity = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> LifeTime = new NumericValue<float>(0,0f,1000f);
        public NumericValue<int> HitPoints = new NumericValue<int>(0,0,1000);
        public bool IgnoresShipVelocity;
        public NumericValue<float> EnergyCost = new NumericValue<float>(0,0f,1000f);
        public ItemId<AmmunitionObsoleteData> CoupledAmmunitionId = ItemId<AmmunitionObsoleteData>.Empty;
        public UnityEngine.Color Color;
        public AudioClipId FireSound;
        public string HitEffectPrefab;
        public string BulletPrefab;
    }
}
