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
    public class BulletTriggerData
    {
        public static BulletTriggerData Deserialize(BulletTriggerSerializable serializable, Database database)
        {
            return new BulletTriggerData(serializable, database);
        }

        private BulletTriggerData(BulletTriggerSerializable serializable, Database database)
        {
            Condition = serializable.Condition;
            EffectType = serializable.EffectType;
            VisualEffect = database.GetVisualEffectId(serializable.VisualEffect);
            AudioClip = new AudioClipId(serializable.AudioClip);
            Ammunition = database.GetAmmunitionId(serializable.Ammunition);
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            ColorMode = serializable.ColorMode;
            Quantity = new NumericValue<int>(serializable.Quantity, 0, 1000);
            Size = new NumericValue<float>(serializable.Size, 0.01f, 100f);
            Lifetime = new NumericValue<float>(serializable.Lifetime, 0f, 1000f);
            Cooldown = new NumericValue<float>(serializable.Cooldown, 0f, 1000f);
            RandomFactor = new NumericValue<float>(serializable.RandomFactor, 0f, 1f);
            PowerMultiplier = new NumericValue<float>(serializable.PowerMultiplier, 0f, 1000f);
        }

        public BulletTriggerSerializable Serialize()
        {
            var serializable = new BulletTriggerSerializable();
            serializable.Condition = Condition;
            serializable.EffectType = EffectType;
            serializable.VisualEffect = VisualEffect.Id;
            serializable.AudioClip = AudioClip.ToString();
            serializable.Ammunition = Ammunition.Id;
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.ColorMode = ColorMode;
            serializable.Quantity = Quantity.Value;
            serializable.Size = Size.Value;
            serializable.Lifetime = Lifetime.Value;
            serializable.Cooldown = Cooldown.Value;
            serializable.RandomFactor = RandomFactor.Value;
            serializable.PowerMultiplier = PowerMultiplier.Value;
            return serializable;
        }

        public BulletTriggerCondition Condition;
        public BulletEffectType EffectType;
        public ItemId<VisualEffectData> VisualEffect = ItemId<VisualEffectData>.Empty;
        public AudioClipId AudioClip;
        public ItemId<AmmunitionData> Ammunition = ItemId<AmmunitionData>.Empty;
        public UnityEngine.Color Color;
        public ColorMode ColorMode;
        public NumericValue<int> Quantity = new NumericValue<int>(0,0,1000);
        public NumericValue<float> Size = new NumericValue<float>(0,0.01f,100f);
        public NumericValue<float> Lifetime = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Cooldown = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> RandomFactor = new NumericValue<float>(0,0f,1f);
        public NumericValue<float> PowerMultiplier = new NumericValue<float>(0,0f,1000f);
    }
}
