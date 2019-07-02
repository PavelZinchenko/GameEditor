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
    public class QuestData
    {
        public static QuestData Deserialize(QuestSerializable serializable, Database database)
        {
            return new QuestData(serializable, database);
        }

        private QuestData(QuestSerializable serializable, Database database)
        {
            ItemId = new ItemId<QuestData>(serializable.Id, serializable.FileName);
            Name = serializable.Name;
            QuestType = serializable.QuestType;
            StartCondition = serializable.StartCondition;
            Weight = new NumericValue<float>(serializable.Weight, 0f, 1000f);
            Requirement = RequirementData.Deserialize(serializable.Requirement, database);
            Level = new NumericValue<int>(serializable.Level, 0, 1000);
            Nodes = serializable.Nodes?.Select(item => NodeData.Deserialize(item, database)).ToArray();
        }

        public QuestSerializable Serialize()
        {
            var serializable = new QuestSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Quest;
            serializable.Name = Name;
            serializable.QuestType = QuestType;
            serializable.StartCondition = StartCondition;
            serializable.Weight = Weight.Value;
            serializable.Requirement = Requirement.Serialize();
            serializable.Level = Level.Value;
            serializable.Nodes = Nodes?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<QuestData> ItemId;
        public string Name;
        public QuestType QuestType;
        public StartCondition StartCondition;
        public NumericValue<float> Weight = new NumericValue<float>(0,0f,1000f);
        public RequirementData Requirement;
        public NumericValue<int> Level = new NumericValue<int>(0,0,1000);
        public NodeData[] Nodes;
    }
}
