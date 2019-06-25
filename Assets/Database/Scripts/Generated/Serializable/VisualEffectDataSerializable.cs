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
public class VisualEffectDataSerializable {
    public VisualEffectType Type;
    [DefaultValue("")]
    public string Image;
    public ColorMode ColorMode;
    [DefaultValue("")]
    public string Color;
    public float Size;
    public float StartTime;
    public float Lifetime;
}

}
