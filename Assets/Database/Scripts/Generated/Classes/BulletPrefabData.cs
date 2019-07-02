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
    public class BulletPrefabData
    {
        public static BulletPrefabData Deserialize(BulletPrefabSerializable serializable, Database database)
        {
            return new BulletPrefabData(serializable, database);
        }

        private BulletPrefabData(BulletPrefabSerializable serializable, Database database)
        {
            ItemId = new ItemId<BulletPrefabData>(serializable.Id, serializable.FileName);
            Shape = serializable.Shape;
            Image = new SpriteId(serializable.Image);
            Size = new NumericValue<float>(serializable.Size, 0.01f, 100f);
            Margins = new NumericValue<float>(serializable.Margins, 0f, 1f);
            MainColor = Utils.ColorUtils.ColorFromString(serializable.MainColor);
            MainColorMode = serializable.MainColorMode;
            SecondColor = Utils.ColorUtils.ColorFromString(serializable.SecondColor);
            SecondColorMode = serializable.SecondColorMode;
        }

        public BulletPrefabSerializable Serialize()
        {
            var serializable = new BulletPrefabSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.BulletPrefab;
            serializable.Shape = Shape;
            serializable.Image = Image.ToString();
            serializable.Size = Size.Value;
            serializable.Margins = Margins.Value;
            serializable.MainColor = Utils.ColorUtils.ColorToString(MainColor);
            serializable.MainColorMode = MainColorMode;
            serializable.SecondColor = Utils.ColorUtils.ColorToString(SecondColor);
            serializable.SecondColorMode = SecondColorMode;
            return serializable;
        }

        public readonly ItemId<BulletPrefabData> ItemId;
        public BulletShape Shape;
        public SpriteId Image;
        public NumericValue<float> Size = new NumericValue<float>(0,0.01f,100f);
        public NumericValue<float> Margins = new NumericValue<float>(0,0f,1f);
        public UnityEngine.Color MainColor;
        public ColorMode MainColorMode;
        public UnityEngine.Color SecondColor;
        public ColorMode SecondColorMode;
    }
}
