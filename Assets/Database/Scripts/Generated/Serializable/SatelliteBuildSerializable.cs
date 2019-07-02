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
    public class SatelliteBuildSerializable : SerializableItem
    {
        public int SatelliteId;
        public bool NotAvailableInGame;
        public DifficultyClass DifficultyClass;
        public InstalledComponentSerializable[] Components;
    }
}
