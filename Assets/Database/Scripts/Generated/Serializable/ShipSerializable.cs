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
    public class ShipSerializable : SerializableItem
    {
        public ShipCategory ShipCategory;
        [DefaultValue("")]
        public string Name;
        public int Faction;
        public SizeClass SizeClass;
        [DefaultValue("")]
        public string IconImage;
        public float IconScale;
        [DefaultValue("")]
        public string ModelImage;
        public float ModelScale;
        public Vector EnginePosition;
        [DefaultValue("")]
        public string EngineColor;
        public float EngineSize;
        public float EnergyResistance;
        public float KineticResistance;
        public float HeatResistance;
        public bool Regeneration;
        public float BaseWeightModifier;
        public int[] BuiltinDevices;
        [DefaultValue("")]
        public string Layout;
        public BarrelSerializable[] Barrels;
    }
}
