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
    public class WeaponData
    {
        public static WeaponData Deserialize(WeaponSerializable serializable, Database database)
        {
            return new WeaponData(serializable, database);
        }

        private WeaponData(WeaponSerializable serializable, Database database)
        {
            ItemId = new ItemId<WeaponData>(serializable.Id, serializable.FileName);
            WeaponClass = serializable.WeaponClass;
            FireRate = new NumericValue<float>(serializable.FireRate, 0.001f, 100f);
            Spread = new NumericValue<float>(serializable.Spread, 0f, 180f);
            Magazine = new NumericValue<int>(serializable.Magazine, 0, 1000);
            ActivationType = serializable.ActivationType;
            ShotSound = new AudioClipId(serializable.ShotSound);
            ChargeSound = new AudioClipId(serializable.ChargeSound);
            ShotEffectPrefab = serializable.ShotEffectPrefab;
            ControlButtonIcon = serializable.ControlButtonIcon;
        }

        public WeaponSerializable Serialize()
        {
            var serializable = new WeaponSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Weapon;
            serializable.WeaponClass = WeaponClass;
            serializable.FireRate = FireRate.Value;
            serializable.Spread = Spread.Value;
            serializable.Magazine = Magazine.Value;
            serializable.ActivationType = ActivationType;
            serializable.ShotSound = ShotSound.ToString();
            serializable.ChargeSound = ChargeSound.ToString();
            serializable.ShotEffectPrefab = ShotEffectPrefab;
            serializable.ControlButtonIcon = ControlButtonIcon;
            return serializable;
        }

        public readonly ItemId<WeaponData> ItemId;
        public WeaponClass WeaponClass;
        public NumericValue<float> FireRate = new NumericValue<float>(0,0.001f,100f);
        public NumericValue<float> Spread = new NumericValue<float>(0,0f,180f);
        public NumericValue<int> Magazine = new NumericValue<int>(0,0,1000);
        public ActivationType ActivationType;
        public AudioClipId ShotSound;
        public AudioClipId ChargeSound;
        public string ShotEffectPrefab;
        public string ControlButtonIcon;
    }
}
