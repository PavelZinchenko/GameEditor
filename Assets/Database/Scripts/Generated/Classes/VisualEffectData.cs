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
    public class VisualEffectData
    {
        public static VisualEffectData Deserialize(VisualEffectSerializable serializable, Database database)
        {
            return new VisualEffectData(serializable, database);
        }

        private VisualEffectData(VisualEffectSerializable serializable, Database database)
        {
            ItemId = new ItemId<VisualEffectData>(serializable.Id, serializable.FileName);
            Elements = serializable.Elements?.Select(item => VisualEffectElementData.Deserialize(item, database)).ToArray();
        }

        public VisualEffectSerializable Serialize()
        {
            var serializable = new VisualEffectSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.VisualEffect;
            serializable.Elements = Elements?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<VisualEffectData> ItemId;
        public VisualEffectElementData[] Elements;
    }
}
