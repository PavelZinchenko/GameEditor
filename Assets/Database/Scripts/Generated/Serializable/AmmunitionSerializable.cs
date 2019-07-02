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
    public class AmmunitionSerializable : SerializableItem
    {
        public BulletBodySerializable Body;
        public BulletTriggerSerializable[] Triggers;
        public BulletImpactType ImpactType;
        public ImpactEffectSerializable[] Effects;
    }
}
