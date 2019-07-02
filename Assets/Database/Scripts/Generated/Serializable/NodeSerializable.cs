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
    public class NodeSerializable
    {
        public int Id;
        public NodeType Type;
        public RequiredViewMode RequiredView;
        [DefaultValue("")]
        public string Message;
        public int DefaultTransition;
        public int FailureTransition;
        public int Enemy;
        public int Loot;
        public int Quest;
        public int Character;
        public int Faction;
        public int Value;
        public NodeActionSerializable[] Actions;
        public NodeTransitionSerializable[] Transitions;
    }
}
