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
public class WeaponSerializable : SerializableItem {
    public WeaponClass WeaponClass;
    public float FireRate;
    public float Spread;
    public int Magazine;
    public float Range;
    public ActivationType ActivationType;
    [DefaultValue("")]
    public string ShotSound;
    [DefaultValue("")]
    public string ChargeSound;
    [DefaultValue("")]
    public string ShotEffectPrefab;
    [DefaultValue("")]
    public string ControlButtonIcon;
}

}
