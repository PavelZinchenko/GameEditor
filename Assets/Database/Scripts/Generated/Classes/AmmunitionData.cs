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
    public class AmmunitionData
    {
        public static AmmunitionData Deserialize(AmmunitionSerializable serializable, Database database)
        {
            return new AmmunitionData(serializable, database);
        }

        private AmmunitionData(AmmunitionSerializable serializable, Database database)
        {
            ItemId = new ItemId<AmmunitionData>(serializable.Id, serializable.FileName);
            Body = BulletBodyData.Deserialize(serializable.Body, database);
            Triggers = serializable.Triggers?.Select(item => BulletTriggerData.Deserialize(item, database)).ToArray();
            ImpactType = serializable.ImpactType;
            Effects = serializable.Effects?.Select(item => ImpactEffectData.Deserialize(item, database)).ToArray();
        }

        public AmmunitionSerializable Serialize()
        {
            var serializable = new AmmunitionSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Ammunition;
            serializable.Body = Body.Serialize();
            serializable.Triggers = Triggers?.Select(item => item.Serialize()).ToArray();
            serializable.ImpactType = ImpactType;
            serializable.Effects = Effects?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<AmmunitionData> ItemId;
        public BulletBodyData Body;
        public BulletTriggerData[] Triggers;
        public BulletImpactType ImpactType;
        public ImpactEffectData[] Effects;
    }
}
