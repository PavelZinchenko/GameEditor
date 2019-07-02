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
    public class BarrelData
    {
        public static BarrelData Deserialize(BarrelSerializable serializable, Database database)
        {
            return new BarrelData(serializable, database);
        }

        private BarrelData(BarrelSerializable serializable, Database database)
        {
            Type = serializable.Type;
            Position = serializable.Position;
            Rotation = new NumericValue<float>(serializable.Rotation, -360f, 360f);
            Offset = new NumericValue<float>(serializable.Offset, 0f, 1f);
            PlatformType = serializable.PlatformType;
            WeaponClass = serializable.WeaponClass;
            Image = new SpriteId(serializable.Image);
            Size = new NumericValue<float>(serializable.Size, 0f, 10f);
        }

        public BarrelSerializable Serialize()
        {
            var serializable = new BarrelSerializable();
            serializable.Type = Type;
            serializable.Position = Position;
            serializable.Rotation = Rotation.Value;
            serializable.Offset = Offset.Value;
            serializable.PlatformType = PlatformType;
            serializable.WeaponClass = WeaponClass;
            serializable.Image = Image.ToString();
            serializable.Size = Size.Value;
            return serializable;
        }

        public string Type;
        public Vector Position = Vector.Zero;
        public NumericValue<float> Rotation = new NumericValue<float>(0,-360f,360f);
        public NumericValue<float> Offset = new NumericValue<float>(0,0f,1f);
        public PlatformType PlatformType;
        public string WeaponClass;
        public SpriteId Image;
        public NumericValue<float> Size = new NumericValue<float>(0,0f,10f);
    }
}
