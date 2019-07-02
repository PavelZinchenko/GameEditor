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
    public class VisualEffectElementData
    {
        public static VisualEffectElementData Deserialize(VisualEffectElementSerializable serializable, Database database)
        {
            return new VisualEffectElementData(serializable, database);
        }

        private VisualEffectElementData(VisualEffectElementSerializable serializable, Database database)
        {
            Type = serializable.Type;
            Image = new SpriteId(serializable.Image);
            ColorMode = serializable.ColorMode;
            Color = Utils.ColorUtils.ColorFromString(serializable.Color);
            Size = new NumericValue<float>(serializable.Size, 0.001f, 100f);
            StartTime = new NumericValue<float>(serializable.StartTime, 0f, 100f);
            Lifetime = new NumericValue<float>(serializable.Lifetime, 0f, 100f);
        }

        public VisualEffectElementSerializable Serialize()
        {
            var serializable = new VisualEffectElementSerializable();
            serializable.Type = Type;
            serializable.Image = Image.ToString();
            serializable.ColorMode = ColorMode;
            serializable.Color = Utils.ColorUtils.ColorToString(Color);
            serializable.Size = Size.Value;
            serializable.StartTime = StartTime.Value;
            serializable.Lifetime = Lifetime.Value;
            return serializable;
        }

        public VisualEffectType Type;
        public SpriteId Image;
        public ColorMode ColorMode;
        public UnityEngine.Color Color;
        public NumericValue<float> Size = new NumericValue<float>(0,0.001f,100f);
        public NumericValue<float> StartTime = new NumericValue<float>(0,0f,100f);
        public NumericValue<float> Lifetime = new NumericValue<float>(0,0f,100f);
    }
}
