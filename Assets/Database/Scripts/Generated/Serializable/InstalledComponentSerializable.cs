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
    public class InstalledComponentSerializable
    {
        public int ComponentId;
        public ComponentModType Modification;
        public ModificationQuality Quality;
        public bool Locked;
        public int X;
        public int Y;
        public int BarrelId;
        public int Behaviour;
        public int KeyBinding;
    }
}
