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
public class BulletTriggerSerializable {
    public BulletTriggerCondition Condition;
    public BulletEffectType EffectType;
    public int VisualEffect;
    [DefaultValue("")]
    public string AudioClip;
    public int Ammunition;
    [DefaultValue("")]
    public string Color;
    public ColorMode ColorMode;
    public int Quantity;
    public float Size;
    public float Lifetime;
    public float Cooldown;
    public float RandomFactor;
    public float PowerMultiplier;
}

}
