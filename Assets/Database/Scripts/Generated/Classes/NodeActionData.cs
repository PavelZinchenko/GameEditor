//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using GameDatabase.Types;
using GameDatabase.Utils;
using GameDatabase.Serializable;
using GameDatabase.Enums;

namespace GameDatabase.Classes
{
    public class NodeActionData
    {
        public static NodeActionData Deserialize(NodeActionSerializable serializable, Database database)
        {
            return new NodeActionData(serializable, database);
        }

        private NodeActionData(NodeActionSerializable serializable, Database database)
        {
            TargetNode = new NumericValue<int>(serializable.TargetNode, 1, 1000);
            Requirement = RequirementData.Deserialize(serializable.Requirement, database);
            ButtonText = serializable.ButtonText;
        }

        public NodeActionSerializable Serialize()
        {
            var serializable = new NodeActionSerializable();
            serializable.TargetNode = TargetNode.Value;
            serializable.Requirement = Requirement.Serialize();
            serializable.ButtonText = ButtonText;
            return serializable;
        }

        public NumericValue<int> TargetNode = new NumericValue<int>(0,1,1000);
        public RequirementData Requirement;
        public string ButtonText;
    }
}
