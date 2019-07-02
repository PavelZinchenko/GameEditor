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
    public class RequirementData : IDataAdapter
    {
        public static RequirementData Deserialize(RequirementSerializable serializable, Database database)
        {
            var data = new RequirementData(serializable, database); 
            data.CreateContent(serializable, database);
            return data;
        }

        private RequirementData(RequirementSerializable serializable, Database database)
        {
            Type = serializable.Type;
        }

        private void CreateContent(RequirementSerializable serializable, Database database)
        {
            if (serializable.Type == RequirementType.HaveItemById)
                Content = new Content_HaveItemById(serializable, database);
            else if (serializable.Type == RequirementType.HaveQuestItem)
                Content = new Content_HaveQuestItem(serializable, database);
            else if (serializable.Type == RequirementType.QuestCompleted)
                Content = new Content_QuestCompleted(serializable, database);
            else if (serializable.Type == RequirementType.QuestActive)
                Content = new Content_QuestActive(serializable, database);
            else if (serializable.Type == RequirementType.PlayerPosition)
                Content = new Content_PlayerPosition(serializable, database);
            else if (serializable.Type == RequirementType.RandomStarSystem)
                Content = new Content_RandomStarSystem(serializable, database);
            else if (serializable.Type == RequirementType.CharacterRelations)
                Content = new Content_CharacterRelations(serializable, database);
            else if (serializable.Type == RequirementType.FactionRelations)
                Content = new Content_FactionRelations(serializable, database);
            else if (serializable.Type == RequirementType.Faction)
                Content = new Content_Faction(serializable, database);
            else if (serializable.Type == RequirementType.HaveItem)
                Content = new Content_HaveItem(serializable, database);
            else if (serializable.Type == RequirementType.All)
                Content = new Content_All(serializable, database);
            else if (serializable.Type == RequirementType.Any)
                Content = new Content_Any(serializable, database);
            else if (serializable.Type == RequirementType.None)
                Content = new Content_None(serializable, database);
            else
                Content = new Content_Empty();
        }

        public RequirementSerializable Serialize()
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

        public RequirementType Type;

        private interface IContent { RequirementSerializable Serialize(); }

        private class Content_Empty : IContent
        {
            public RequirementSerializable Serialize()
            {
                return new RequirementSerializable();
            }
        }
        private class Content_HaveItemById : IContent
        {
            public Content_HaveItemById(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Loot = database.GetLootId(serializable.ItemId);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.ItemId = Loot.Id;
                return serializable;
            }

            public ItemId<LootData> Loot = ItemId<LootData>.Empty;
        }

        private class Content_HaveQuestItem : IContent
        {
            public Content_HaveQuestItem(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                QuestItem = database.GetQuestItemId(serializable.ItemId);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.ItemId = QuestItem.Id;
                return serializable;
            }

            public ItemId<QuestItemData> QuestItem = ItemId<QuestItemData>.Empty;
        }

        private class Content_QuestCompleted : IContent
        {
            public Content_QuestCompleted(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Quest = database.GetQuestId(serializable.ItemId);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.ItemId = Quest.Id;
                return serializable;
            }

            public ItemId<QuestData> Quest = ItemId<QuestData>.Empty;
        }

        private class Content_QuestActive : IContent
        {
            public Content_QuestActive(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Quest = database.GetQuestId(serializable.ItemId);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.ItemId = Quest.Id;
                return serializable;
            }

            public ItemId<QuestData> Quest = ItemId<QuestData>.Empty;
        }

        private class Content_PlayerPosition : IContent
        {
            public Content_PlayerPosition(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinValue = new NumericValue<int>(serializable.MinValue, 0, 1000);
                MaxValue = new NumericValue<int>(serializable.MaxValue, 0, 1000);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.MinValue = MinValue.Value;
                serializable.MaxValue = MaxValue.Value;
                return serializable;
            }

            public NumericValue<int> MinValue = new NumericValue<int>(0,0,1000);
            public NumericValue<int> MaxValue = new NumericValue<int>(0,0,1000);
        }

        private class Content_RandomStarSystem : IContent
        {
            public Content_RandomStarSystem(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinValue = new NumericValue<int>(serializable.MinValue, 0, 1000);
                MaxValue = new NumericValue<int>(serializable.MaxValue, 0, 1000);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.MinValue = MinValue.Value;
                serializable.MaxValue = MaxValue.Value;
                return serializable;
            }

            public NumericValue<int> MinValue = new NumericValue<int>(0,0,1000);
            public NumericValue<int> MaxValue = new NumericValue<int>(0,0,1000);
        }

        private class Content_CharacterRelations : IContent
        {
            public Content_CharacterRelations(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinValue = new NumericValue<int>(serializable.MinValue, -100, 100);
                MaxValue = new NumericValue<int>(serializable.MaxValue, -100, 100);
                Character = database.GetCharacterId(serializable.Character);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.MinValue = MinValue.Value;
                serializable.MaxValue = MaxValue.Value;
                serializable.Character = Character.Id;
                return serializable;
            }

            public NumericValue<int> MinValue = new NumericValue<int>(0,-100,100);
            public NumericValue<int> MaxValue = new NumericValue<int>(0,-100,100);
            public ItemId<CharacterData> Character = ItemId<CharacterData>.Empty;
        }

        private class Content_FactionRelations : IContent
        {
            public Content_FactionRelations(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                MinValue = new NumericValue<int>(serializable.MinValue, -100, 100);
                MaxValue = new NumericValue<int>(serializable.MaxValue, -100, 100);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.MinValue = MinValue.Value;
                serializable.MaxValue = MaxValue.Value;
                return serializable;
            }

            public NumericValue<int> MinValue = new NumericValue<int>(0,-100,100);
            public NumericValue<int> MaxValue = new NumericValue<int>(0,-100,100);
        }

        private class Content_Faction : IContent
        {
            public Content_Faction(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Faction = database.GetFactionId(serializable.Faction);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.Faction = Faction.Id;
                return serializable;
            }

            public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
        }

        private class Content_HaveItem : IContent
        {
            public Content_HaveItem(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Loot = LootContentData.Deserialize(serializable.Loot, database);
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.Loot = Loot.Serialize();
                return serializable;
            }

            public LootContentData Loot;
        }

        private class Content_All : IContent
        {
            public Content_All(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Requirements = serializable.Requirements?.Select(item => RequirementData.Deserialize(item, database)).ToArray();
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.Requirements = Requirements?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public RequirementData[] Requirements;
        }

        private class Content_Any : IContent
        {
            public Content_Any(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Requirements = serializable.Requirements?.Select(item => RequirementData.Deserialize(item, database)).ToArray();
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.Requirements = Requirements?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public RequirementData[] Requirements;
        }

        private class Content_None : IContent
        {
            public Content_None(RequirementSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Requirements = serializable.Requirements?.Select(item => RequirementData.Deserialize(item, database)).ToArray();
            }

            public RequirementSerializable Serialize()
            {
                var serializable = new RequirementSerializable();
                serializable.Requirements = Requirements?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public RequirementData[] Requirements;
        }

    }
}
