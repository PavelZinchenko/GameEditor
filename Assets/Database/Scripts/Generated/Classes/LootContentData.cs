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
    public class LootContentData : IDataAdapter
    {
        public static LootContentData Deserialize(LootContentSerializable serializable, Database database)
        {
            var data = new LootContentData(serializable, database); 
            data.CreateContent(serializable, database);
            return data;
        }

        private LootContentData(LootContentSerializable serializable, Database database)
        {
            Type = serializable.Type;
        }

        private void CreateContent(LootContentSerializable serializable, Database database)
        {
            if (serializable.Type == LootItemType.QuestItem)
                Content = new Content_QuestItem(serializable, database);
            else if (serializable.Type == LootItemType.EmptyShip)
                Content = new Content_EmptyShip(serializable, database);
            else if (serializable.Type == LootItemType.Ship)
                Content = new Content_Ship(serializable, database);
            else if (serializable.Type == LootItemType.Component)
                Content = new Content_Component(serializable, database);
            else if (serializable.Type == LootItemType.Money)
                Content = new Content_Money(serializable, database);
            else if (serializable.Type == LootItemType.Fuel)
                Content = new Content_Fuel(serializable, database);
            else if (serializable.Type == LootItemType.Stars)
                Content = new Content_Stars(serializable, database);
            else if (serializable.Type == LootItemType.RandomComponents)
                Content = new Content_RandomComponents(serializable, database);
            else if (serializable.Type == LootItemType.RandomItems)
                Content = new Content_RandomItems(serializable, database);
            else if (serializable.Type == LootItemType.SomeMoney)
                Content = new Content_SomeMoney(serializable, database);
            else if (serializable.Type == LootItemType.AllItems)
                Content = new Content_AllItems(serializable, database);
            else if (serializable.Type == LootItemType.ItemsWithChance)
                Content = new Content_ItemsWithChance(serializable, database);
            else
                Content = new Content_Empty();
        }

        public LootContentSerializable Serialize()
        {
            var serializable = Content.Serialize();
            serializable.Type = Type;
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

        public LootItemType Type;

        private interface IContent { LootContentSerializable Serialize(); }

        private class Content_Empty : IContent
        {
            public LootContentSerializable Serialize()
            {
                return new LootContentSerializable();
            }
        }
        private class Content_QuestItem : IContent
        {
            public Content_QuestItem(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                QuestItem = database.GetQuestItemId(serializable.ItemId);
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.ItemId = QuestItem.Id;
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                return serializable;
            }

            public ItemId<QuestItemData> QuestItem = ItemId<QuestItemData>.Empty;
            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
        }

        private class Content_EmptyShip : IContent
        {
            public Content_EmptyShip(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Ship = database.GetShipId(serializable.ItemId);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.ItemId = Ship.Id;
                return serializable;
            }

            public ItemId<ShipData> Ship = ItemId<ShipData>.Empty;
        }

        private class Content_Ship : IContent
        {
            public Content_Ship(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                ShipBuild = database.GetShipBuildId(serializable.ItemId);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.ItemId = ShipBuild.Id;
                return serializable;
            }

            public ItemId<ShipBuildData> ShipBuild = ItemId<ShipBuildData>.Empty;
        }

        private class Content_Component : IContent
        {
            public Content_Component(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Component = database.GetComponentId(serializable.ItemId);
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.ItemId = Component.Id;
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                return serializable;
            }

            public ItemId<ComponentData> Component = ItemId<ComponentData>.Empty;
            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
        }

        private class Content_Money : IContent
        {
            public Content_Money(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                return serializable;
            }

            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
        }

        private class Content_Fuel : IContent
        {
            public Content_Fuel(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                return serializable;
            }

            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
        }

        private class Content_Stars : IContent
        {
            public Content_Stars(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                return serializable;
            }

            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
        }

        private class Content_RandomComponents : IContent
        {
            public Content_RandomComponents(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
                ValueRatio = new NumericValue<float>(serializable.ValueRatio, 0.001f, 1000f);
                Factions = FactionFilterData.Deserialize(serializable.Factions, database);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                serializable.ValueRatio = ValueRatio.Value;
                serializable.Factions = Factions.Serialize();
                return serializable;
            }

            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<float> ValueRatio = new NumericValue<float>(0,0.001f,1000f);
            public FactionFilterData Factions;
        }

        private class Content_RandomItems : IContent
        {
            public Content_RandomItems(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinAmount = new NumericValue<int>(serializable.MinAmount, 0, 100000000);
                MaxAmount = new NumericValue<int>(serializable.MaxAmount, 0, 100000000);
                Items = serializable.Items?.Select(item => LootItemData.Deserialize(item, database)).ToArray();
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.MinAmount = MinAmount.Value;
                serializable.MaxAmount = MaxAmount.Value;
                serializable.Items = Items?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public NumericValue<int> MinAmount = new NumericValue<int>(0,0,100000000);
            public NumericValue<int> MaxAmount = new NumericValue<int>(0,0,100000000);
            public LootItemData[] Items;
        }

        private class Content_SomeMoney : IContent
        {
            public Content_SomeMoney(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                ValueRatio = new NumericValue<float>(serializable.ValueRatio, 0.001f, 1000f);
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.ValueRatio = ValueRatio.Value;
                return serializable;
            }

            public NumericValue<float> ValueRatio = new NumericValue<float>(0,0.001f,1000f);
        }

        private class Content_AllItems : IContent
        {
            public Content_AllItems(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Items = serializable.Items?.Select(item => LootItemData.Deserialize(item, database)).ToArray();
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.Items = Items?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public LootItemData[] Items;
        }

        private class Content_ItemsWithChance : IContent
        {
            public Content_ItemsWithChance(LootContentSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Items = serializable.Items?.Select(item => LootItemData.Deserialize(item, database)).ToArray();
            }

            public LootContentSerializable Serialize()
            {
                var serializable = new LootContentSerializable();
                serializable.Items = Items?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public LootItemData[] Items;
        }

    }
}
