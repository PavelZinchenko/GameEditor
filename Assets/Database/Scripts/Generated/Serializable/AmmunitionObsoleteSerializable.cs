//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using Database.Types;
using Database.Enums;

namespace Database.Serializable {

[Serializable]
public class AmmunitionObsoleteSerializable : SerializableItem {
    public AmmunitionClassObsolete AmmunitionClass;
    public DamageType DamageType;
    public float Impulse;
    public float Recoil;
    public float Size;
    [DefaultValue("")]
    public Vector InitialPosition;
    public float AreaOfEffect;
    public float Damage;
    public float Range;
    public float Velocity;
    public float LifeTime;
    public int HitPoints;
    public bool IgnoresShipVelocity;
    public float EnergyCost;
    public int CoupledAmmunitionId;
    [DefaultValue("")]
    public string Color;
    [DefaultValue("")]
    public string FireSound;
    [DefaultValue("")]
    public string HitEffectPrefab;
    [DefaultValue("")]
    public string BulletPrefab;
}

}
