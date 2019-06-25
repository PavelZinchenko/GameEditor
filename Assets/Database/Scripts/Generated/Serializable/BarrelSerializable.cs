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
public class BarrelSerializable {
    [DefaultValue("")]
    public string Type;
    [DefaultValue("")]
    public Vector Position;
    public float Rotation;
    public float Offset;
    public PlatformType PlatformType;
    [DefaultValue("")]
    public string WeaponClass;
    [DefaultValue("")]
    public string Image;
    public float Size;
}

}
