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
    public class BulletBodyData
    {
        public static BulletBodyData Deserialize(BulletBodySerializable serializable, Database database)
        {
            return new BulletBodyData(serializable, database);
        }

        private BulletBodyData(BulletBodySerializable serializable, Database database)
        {
            Type = serializable.Type;
            Size = new NumericValue<float>(serializable.Size, 0f, 1000f);
            Velocity = new NumericValue<float>(serializable.Velocity, 0f, 1000f);
            Range = new NumericValue<float>(serializable.Range, 0f, 1000f);
            Lifetime = new NumericValue<float>(serializable.Lifetime, 0f, 1000f);
            Weight = new NumericValue<float>(serializable.Weight, 0f, 1000f);
            HitPoints = new NumericValue<int>(serializable.HitPoints, 0, 1000);
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            BulletPrefab = database.GetBulletPrefabId(serializable.BulletPrefab);
            EnergyCost = new NumericValue<float>(serializable.EnergyCost, 0f, 1000f);
            CanBeDisarmed = serializable.CanBeDisarmed;
            FriendlyFire = serializable.FriendlyFire;
        }

        public BulletBodySerializable Serialize()
        {
            var serializable = new BulletBodySerializable();
            serializable.Type = Type;
            serializable.Size = Size.Value;
            serializable.Velocity = Velocity.Value;
            serializable.Range = Range.Value;
            serializable.Lifetime = Lifetime.Value;
            serializable.Weight = Weight.Value;
            serializable.HitPoints = HitPoints.Value;
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.BulletPrefab = BulletPrefab.Id;
            serializable.EnergyCost = EnergyCost.Value;
            serializable.CanBeDisarmed = CanBeDisarmed;
            serializable.FriendlyFire = FriendlyFire;
            return serializable;
        }

        public BulletType Type;
        public NumericValue<float> Size = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Velocity = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Range = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Lifetime = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Weight = new NumericValue<float>(0,0f,1000f);
        public NumericValue<int> HitPoints = new NumericValue<int>(0,0,1000);
        public UnityEngine.Color Color;
        public ItemId<BulletPrefabData> BulletPrefab = ItemId<BulletPrefabData>.Empty;
        public NumericValue<float> EnergyCost = new NumericValue<float>(0,0f,1000f);
        public bool CanBeDisarmed;
        public bool FriendlyFire;
    }
}
