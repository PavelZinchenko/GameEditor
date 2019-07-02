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
    public class QuestItemData
    {
        public static QuestItemData Deserialize(QuestItemSerializable serializable, Database database)
        {
            return new QuestItemData(serializable, database);
        }

        private QuestItemData(QuestItemSerializable serializable, Database database)
        {
            ItemId = new ItemId<QuestItemData>(serializable.Id, serializable.FileName);
            Name = serializable.Name;
            Description = serializable.Description;
            Icon = new SpriteId(serializable.Icon);
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            Price = new NumericValue<int>(serializable.Price, 0, 100000000);
        }

        public QuestItemSerializable Serialize()
        {
            var serializable = new QuestItemSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.QuestItem;
            serializable.Name = Name;
            serializable.Description = Description;
            serializable.Icon = Icon.ToString();
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.Price = Price.Value;
            return serializable;
        }

        public readonly ItemId<QuestItemData> ItemId;
        public string Name;
        public string Description;
        public SpriteId Icon;
        public UnityEngine.Color Color;
        public NumericValue<int> Price = new NumericValue<int>(0,0,100000000);
    }
}
