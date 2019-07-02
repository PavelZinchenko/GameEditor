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
    public class NodeTransitionData
    {
        public static NodeTransitionData Deserialize(NodeTransitionSerializable serializable, Database database)
        {
            return new NodeTransitionData(serializable, database);
        }

        private NodeTransitionData(NodeTransitionSerializable serializable, Database database)
        {
            TargetNode = new NumericValue<int>(serializable.TargetNode, 1, 1000);
            Requirement = RequirementData.Deserialize(serializable.Requirement, database);
            Weight = new NumericValue<float>(serializable.Weight, 0f, 1000f);
        }

        public NodeTransitionSerializable Serialize()
        {
            var serializable = new NodeTransitionSerializable();
            serializable.TargetNode = TargetNode.Value;
            serializable.Requirement = Requirement.Serialize();
            serializable.Weight = Weight.Value;
            return serializable;
        }

        public NumericValue<int> TargetNode = new NumericValue<int>(0,1,1000);
        public RequirementData Requirement;
        public NumericValue<float> Weight = new NumericValue<float>(0,0f,1000f);
    }
}
