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
    public class FactionFilterData
    {
        public static FactionFilterData Deserialize(FactionFilterSerializable serializable, Database database)
        {
            return new FactionFilterData(serializable, database);
        }

        private FactionFilterData(FactionFilterSerializable serializable, Database database)
        {
            Type = serializable.Type;
            List = serializable.List?.Select(item => new Wrapper<FactionData> { Item = database.GetFactionId(item) }).ToArray();
        }

        public FactionFilterSerializable Serialize()
        {
            var serializable = new FactionFilterSerializable();
            serializable.Type = Type;
            serializable.List = List?.Select(item => item.Item.Id).ToArray();
            return serializable;
        }

        public FactionFilterType Type;
        public Wrapper<FactionData>[] List;
    }
}
