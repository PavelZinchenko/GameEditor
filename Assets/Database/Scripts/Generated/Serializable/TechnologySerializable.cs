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
    public class TechnologySerializable : SerializableItem
    {
        public TechType Type;
        public int Component;
        public int Satellite;
        public int Ship;
        public int Faction;
        public int Price;
        public bool Hidden;
        public bool Special;
        public int[] Dependencies;
    }
}
