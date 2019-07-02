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
    public class SatelliteData
    {
        public static SatelliteData Deserialize(SatelliteSerializable serializable, Database database)
        {
            return new SatelliteData(serializable, database);
        }

        private SatelliteData(SatelliteSerializable serializable, Database database)
        {
            ItemId = new ItemId<SatelliteData>(serializable.Id, serializable.FileName);
            Name = serializable.Name;
            ModelImage = new SpriteId(serializable.ModelImage);
            ModelScale = new NumericValue<float>(serializable.ModelScale, 0.1f, 100f);
            SizeClass = serializable.SizeClass;
            Layout = new Layout(serializable.Layout);
            Barrels = serializable.Barrels?.Select(item => BarrelData.Deserialize(item, database)).ToArray();
        }

        public SatelliteSerializable Serialize()
        {
            var serializable = new SatelliteSerializable();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Satellite;
            serializable.Name = Name;
            serializable.ModelImage = ModelImage.ToString();
            serializable.ModelScale = ModelScale.Value;
            serializable.SizeClass = SizeClass;
            serializable.Layout = Layout.Data;
            serializable.Barrels = Barrels?.Select(item => item.Serialize()).ToArray();
            return serializable;
        }

        public readonly ItemId<SatelliteData> ItemId;
        public string Name;
        public SpriteId ModelImage;
        public NumericValue<float> ModelScale = new NumericValue<float>(0,0.1f,100f);
        public SizeClass SizeClass;
        public Layout Layout;
        public BarrelData[] Barrels;
    }
}
