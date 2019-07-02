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
    public class ComponentModData
    {
        public static ComponentModData Deserialize(ComponentModSerializable serializable, Database database)
        {
            return new ComponentModData(serializable, database);
        }

        private ComponentModData(ComponentModSerializable serializable, Database database)
        {
            ItemId = new ItemId<ComponentModData>(serializable.Id, serializable.FileName);
            Type = serializable.Type;
        }

        public ComponentModSerializable Serialize()
        {
            var serializable = new ComponentModSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.ComponentMod;
            serializable.Type = Type;
            return serializable;
        }

        public readonly ItemId<ComponentModData> ItemId;
        public ComponentModType Type;
    }
}
