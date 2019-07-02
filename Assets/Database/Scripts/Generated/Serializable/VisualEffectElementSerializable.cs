//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using GameDatabase.Types;
using GameDatabase.Serialization;
using GameDatabase.Enums;

namespace GameDatabase.Serializable
{
    [Serializable]
    public class VisualEffectElementSerializable
    {
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
