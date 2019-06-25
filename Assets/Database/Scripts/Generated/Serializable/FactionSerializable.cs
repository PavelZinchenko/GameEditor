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
public class FactionSerializable : SerializableItem {
    [DefaultValue("")]
    public string Type;
    [DefaultValue("")]
    public string Color;
    public int HomeStarDistance;
    public int WanderingShipsDistance;
    public bool Hidden;
}

}
