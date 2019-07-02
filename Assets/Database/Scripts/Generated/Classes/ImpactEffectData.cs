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
    public class ImpactEffectData
    {
        public static ImpactEffectData Deserialize(ImpactEffectSerializable serializable, Database database)
        {
            return new ImpactEffectData(serializable, database);
        }

        private ImpactEffectData(ImpactEffectSerializable serializable, Database database)
        {
            Type = serializable.Type;
            DamageType = serializable.DamageType;
            Power = new NumericValue<float>(serializable.Power, 0f, 1000f);
            Factor = new NumericValue<float>(serializable.Factor, 0f, 1f);
        }

        public ImpactEffectSerializable Serialize()
        {
            var serializable = new ImpactEffectSerializable();
            serializable.Type = Type;
            serializable.DamageType = DamageType;
            serializable.Power = Power.Value;
            serializable.Factor = Factor.Value;
            return serializable;
        }

        public ImpactEffectType Type;
        public DamageType DamageType;
        public NumericValue<float> Power = new NumericValue<float>(0,0f,1000f);
        public NumericValue<float> Factor = new NumericValue<float>(0,0f,1f);
    }
}
