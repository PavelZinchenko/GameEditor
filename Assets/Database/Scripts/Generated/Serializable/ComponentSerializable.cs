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
    public class ComponentSerializable : SerializableItem
    {
        [DefaultValue("")]
        public string Name;
        [DefaultValue("")]
        public string Description;
        public ComponentCategory DisplayCategory;
        public Availability Availability;
        public int ComponentStatsId;
        public int Faction;
        public int Level;
        [DefaultValue("")]
        public string Icon;
        [DefaultValue("")]
        public string Color;
        [DefaultValue("")]
        public string Layout;
        [DefaultValue("")]
        public string CellType;
        public int DeviceId;
        public int WeaponId;
        public int AmmunitionId;
        public int AmmunitionObsoleteId;
        [DefaultValue("")]
        public string WeaponSlotType;
        public int DroneBayId;
        public int DroneId;
        public int[] PossibleModifications;
    }
}
