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
    public class RequirementSerializable
    {
        public RequirementType Type;
        public int ItemId;
        public int MinValue;
        public int MaxValue;
        public int Character;
        public int Faction;
        public LootContentSerializable Loot;
        public RequirementSerializable[] Requirements;
    }
}
