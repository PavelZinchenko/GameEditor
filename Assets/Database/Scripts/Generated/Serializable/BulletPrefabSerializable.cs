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
    public class BulletPrefabSerializable : SerializableItem
    {
        public BulletShape Shape;
        [DefaultValue("")]
        public string Image;
        public float Size;
        public float Margins;
        [DefaultValue("")]
        public string MainColor;
        public ColorMode MainColorMode;
        [DefaultValue("")]
        public string SecondColor;
        public ColorMode SecondColorMode;
    }
}
