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
    public class TechnologyData : IDataAdapter
    {
        public static TechnologyData Deserialize(TechnologySerializable serializable, Database database)
        {
            var data = new TechnologyData(serializable, database); 
            data.CreateContent(serializable, database);
            return data;
        }

        private TechnologyData(TechnologySerializable serializable, Database database)
        {
            ItemId = new ItemId<TechnologyData>(serializable.Id, serializable.FileName);
            Type = serializable.Type;
            Price = new NumericValue<int>(serializable.Price, 0, 1000);
            Hidden = serializable.Hidden;
            Special = serializable.Special;
            Dependencies = serializable.Dependencies?.Select(item => new Wrapper<TechnologyData> { Item = database.GetTechnologyId(item) }).ToArray();
        }

        private void CreateContent(TechnologySerializable serializable, Database database)
        {
            if (serializable.Type == TechType.Component)
                Content = new Content_Component(serializable, database);
            else if (serializable.Type == TechType.Satellite)
                Content = new Content_Satellite(serializable, database);
            else if (serializable.Type == TechType.Ship)
                Content = new Content_Ship(serializable, database);
            else
                Content = new Content_Empty();
        }

        public TechnologySerializable Serialize()
        {
            var serializable = Content.Serialize();
            serializable.Id = ItemId.Id;
            serializable.FileName = ItemId.Name;
            serializable.ItemType = (int)ItemType.Technology;
            serializable.Type = Type;
            serializable.Price = Price.Value;
            serializable.Hidden = Hidden;
            serializable.Special = Special;
            serializable.Dependencies = Dependencies?.Select(item => item.Item.Id).ToArray();
            return serializable;
        }

        public event Action LayoutChangedEvent;
        public event Action DataChangedEvent;
        public IEnumerable<IProperty> Properties
        {
            get
            {
                var type = GetType();
                yield return new Property(this, type.GetField("Type"), OnTypeChanged);
                yield return new Property(this, type.GetField("Price"), DataChangedEvent);
                yield return new Property(this, type.GetField("Hidden"), DataChangedEvent);
                yield return new Property(this, type.GetField("Special"), DataChangedEvent);
                yield return new Property(this, type.GetField("Dependencies"), DataChangedEvent);
                foreach (var item in Content.GetType().GetFields().Where(f => f.IsPublic && !f.IsStatic))
                    yield return new Property(Content, item, DataChangedEvent);
            }
        }

        private void OnTypeChanged()
        {
            CreateContent(null, null);
            DataChangedEvent?.Invoke();
            LayoutChangedEvent?.Invoke();
        }

        private IContent Content { get; set; }

        public readonly ItemId<TechnologyData> ItemId;
        public TechType Type;
        public NumericValue<int> Price = new NumericValue<int>(0,0,1000);
        public bool Hidden;
        public bool Special;
        public Wrapper<TechnologyData>[] Dependencies;

        private interface IContent { TechnologySerializable Serialize(); }

        private class Content_Empty : IContent
        {
            public TechnologySerializable Serialize()
            {
                return new TechnologySerializable();
            }
        }
        private class Content_Component : IContent
        {
            public Content_Component(TechnologySerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Component = database.GetComponentId(serializable.Component);
                Faction = database.GetFactionId(serializable.Faction);
            }

            public TechnologySerializable Serialize()
            {
                var serializable = new TechnologySerializable();
                serializable.Component = Component.Id;
                serializable.Faction = Faction.Id;
                return serializable;
            }

            public ItemId<ComponentData> Component = ItemId<ComponentData>.Empty;
            public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
        }

        private class Content_Satellite : IContent
        {
            public Content_Satellite(TechnologySerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Satellite = database.GetSatelliteId(serializable.Satellite);
                Faction = database.GetFactionId(serializable.Faction);
            }

            public TechnologySerializable Serialize()
            {
                var serializable = new TechnologySerializable();
                serializable.Satellite = Satellite.Id;
                serializable.Faction = Faction.Id;
                return serializable;
            }

            public ItemId<SatelliteData> Satellite = ItemId<SatelliteData>.Empty;
            public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
        }

        private class Content_Ship : IContent
        {
            public Content_Ship(TechnologySerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Ship = database.GetShipId(serializable.Ship);
            }

            public TechnologySerializable Serialize()
            {
                var serializable = new TechnologySerializable();
                serializable.Ship = Ship.Id;
                return serializable;
            }

            public ItemId<ShipData> Ship = ItemId<ShipData>.Empty;
        }

    }
}
