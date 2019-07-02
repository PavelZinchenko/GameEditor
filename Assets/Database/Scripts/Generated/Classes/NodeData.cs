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
    public class NodeData : IDataAdapter
    {
        public static NodeData Deserialize(NodeSerializable serializable, Database database)
        {
            var data = new NodeData(serializable, database); 
            data.CreateContent(serializable, database);
            return data;
        }

        private NodeData(NodeSerializable serializable, Database database)
        {
            Id = new NumericValue<int>(serializable.Id, 1, 1000);
            Type = serializable.Type;
        }

        private void CreateContent(NodeSerializable serializable, Database database)
        {
            if (serializable.Type == NodeType.ShowDialog)
                Content = new Content_ShowDialog(serializable, database);
            else if (serializable.Type == NodeType.Switch)
                Content = new Content_Switch(serializable, database);
            else if (serializable.Type == NodeType.Condition)
                Content = new Content_Condition(serializable, database);
            else if (serializable.Type == NodeType.Random)
                Content = new Content_Random(serializable, database);
            else if (serializable.Type == NodeType.Retreat)
                Content = new Content_Retreat(serializable, database);
            else if (serializable.Type == NodeType.DestroyOccupants)
                Content = new Content_DestroyOccupants(serializable, database);
            else if (serializable.Type == NodeType.SuppressOccupants)
                Content = new Content_SuppressOccupants(serializable, database);
            else if (serializable.Type == NodeType.ReceiveItem)
                Content = new Content_ReceiveItem(serializable, database);
            else if (serializable.Type == NodeType.RemoveItem)
                Content = new Content_RemoveItem(serializable, database);
            else if (serializable.Type == NodeType.Trade)
                Content = new Content_Trade(serializable, database);
            else if (serializable.Type == NodeType.StartQuest)
                Content = new Content_StartQuest(serializable, database);
            else if (serializable.Type == NodeType.ChangeFactionRelations)
                Content = new Content_ChangeFactionRelations(serializable, database);
            else if (serializable.Type == NodeType.SetFactionRelations)
                Content = new Content_SetFactionRelations(serializable, database);
            else if (serializable.Type == NodeType.ChangeCharacterRelations)
                Content = new Content_ChangeCharacterRelations(serializable, database);
            else if (serializable.Type == NodeType.SetCharacterRelations)
                Content = new Content_SetCharacterRelations(serializable, database);
            else if (serializable.Type == NodeType.OpenShipyard)
                Content = new Content_OpenShipyard(serializable, database);
            else if (serializable.Type == NodeType.AttackFleet)
                Content = new Content_AttackFleet(serializable, database);
            else if (serializable.Type == NodeType.AttackOccupants)
                Content = new Content_AttackOccupants(serializable, database);
            else
                Content = new Content_Empty();
        }

        public NodeSerializable Serialize()
        {
            var serializable = Content.Serialize();
            serializable.Id = Id.Value;
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
                yield return new Property(this, type.GetField("Id"), DataChangedEvent);
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

        public NumericValue<int> Id = new NumericValue<int>(0,1,1000);
        public NodeType Type;

        private interface IContent { NodeSerializable Serialize(); }

        private class Content_Empty : IContent
        {
            public NodeSerializable Serialize()
            {
                return new NodeSerializable();
            }
        }
        private class Content_ShowDialog : IContent
        {
            public Content_ShowDialog(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                RequiredView = serializable.RequiredView;
                Message = serializable.Message;
                Enemy = database.GetFleetId(serializable.Enemy);
                Loot = database.GetLootId(serializable.Loot);
                Character = database.GetCharacterId(serializable.Character);
                Actions = serializable.Actions?.Select(item => NodeActionData.Deserialize(item, database)).ToArray();
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.RequiredView = RequiredView;
                serializable.Message = Message;
                serializable.Enemy = Enemy.Id;
                serializable.Loot = Loot.Id;
                serializable.Character = Character.Id;
                serializable.Actions = Actions?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public RequiredViewMode RequiredView;
            public string Message;
            public ItemId<FleetData> Enemy = ItemId<FleetData>.Empty;
            public ItemId<LootData> Loot = ItemId<LootData>.Empty;
            public ItemId<CharacterData> Character = ItemId<CharacterData>.Empty;
            public NodeActionData[] Actions;
        }

        private class Content_Switch : IContent
        {
            public Content_Switch(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Message = serializable.Message;
                DefaultTransition = new NumericValue<int>(serializable.DefaultTransition, 0, 1000);
                Transitions = serializable.Transitions?.Select(item => NodeTransitionData.Deserialize(item, database)).ToArray();
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.Message = Message;
                serializable.DefaultTransition = DefaultTransition.Value;
                serializable.Transitions = Transitions?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public string Message;
            public NumericValue<int> DefaultTransition = new NumericValue<int>(0,0,1000);
            public NodeTransitionData[] Transitions;
        }

        private class Content_Condition : IContent
        {
            public Content_Condition(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Message = serializable.Message;
                Transitions = serializable.Transitions?.Select(item => NodeTransitionData.Deserialize(item, database)).ToArray();
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.Message = Message;
                serializable.Transitions = Transitions?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public string Message;
            public NodeTransitionData[] Transitions;
        }

        private class Content_Random : IContent
        {
            public Content_Random(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Message = serializable.Message;
                DefaultTransition = new NumericValue<int>(serializable.DefaultTransition, 0, 1000);
                Transitions = serializable.Transitions?.Select(item => NodeTransitionData.Deserialize(item, database)).ToArray();
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.Message = Message;
                serializable.DefaultTransition = DefaultTransition.Value;
                serializable.Transitions = Transitions?.Select(item => item.Serialize()).ToArray();
                return serializable;
            }

            public string Message;
            public NumericValue<int> DefaultTransition = new NumericValue<int>(0,0,1000);
            public NodeTransitionData[] Transitions;
        }

        private class Content_Retreat : IContent
        {
            public Content_Retreat(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
        }

        private class Content_DestroyOccupants : IContent
        {
            public Content_DestroyOccupants(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
        }

        private class Content_SuppressOccupants : IContent
        {
            public Content_SuppressOccupants(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
        }

        private class Content_ReceiveItem : IContent
        {
            public Content_ReceiveItem(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Loot = database.GetLootId(serializable.Loot);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Loot = Loot.Id;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public ItemId<LootData> Loot = ItemId<LootData>.Empty;
        }

        private class Content_RemoveItem : IContent
        {
            public Content_RemoveItem(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Loot = database.GetLootId(serializable.Loot);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Loot = Loot.Id;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public ItemId<LootData> Loot = ItemId<LootData>.Empty;
        }

        private class Content_Trade : IContent
        {
            public Content_Trade(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Loot = database.GetLootId(serializable.Loot);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Loot = Loot.Id;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public ItemId<LootData> Loot = ItemId<LootData>.Empty;
        }

        private class Content_StartQuest : IContent
        {
            public Content_StartQuest(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Quest = database.GetQuestId(serializable.Quest);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Quest = Quest.Id;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public ItemId<QuestData> Quest = ItemId<QuestData>.Empty;
        }

        private class Content_ChangeFactionRelations : IContent
        {
            public Content_ChangeFactionRelations(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Value = new NumericValue<int>(serializable.Value, -100, 100);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Value = Value.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public NumericValue<int> Value = new NumericValue<int>(0,-100,100);
        }

        private class Content_SetFactionRelations : IContent
        {
            public Content_SetFactionRelations(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Value = new NumericValue<int>(serializable.Value, -100, 100);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Value = Value.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public NumericValue<int> Value = new NumericValue<int>(0,-100,100);
        }

        private class Content_ChangeCharacterRelations : IContent
        {
            public Content_ChangeCharacterRelations(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Value = new NumericValue<int>(serializable.Value, -100, 100);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Value = Value.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public NumericValue<int> Value = new NumericValue<int>(0,-100,100);
        }

        private class Content_SetCharacterRelations : IContent
        {
            public Content_SetCharacterRelations(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Value = new NumericValue<int>(serializable.Value, -100, 100);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Value = Value.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public NumericValue<int> Value = new NumericValue<int>(0,-100,100);
        }

        private class Content_OpenShipyard : IContent
        {
            public Content_OpenShipyard(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                Transition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                Faction = database.GetFactionId(serializable.Faction);
                Level = new NumericValue<int>(serializable.Value, 0, 1000);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = Transition.Value;
                serializable.Faction = Faction.Id;
                serializable.Value = Level.Value;
                return serializable;
            }

            public NumericValue<int> Transition = new NumericValue<int>(0,1,1000);
            public ItemId<FactionData> Faction = ItemId<FactionData>.Empty;
            public NumericValue<int> Level = new NumericValue<int>(0,0,1000);
        }

        private class Content_AttackFleet : IContent
        {
            public Content_AttackFleet(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                VictoryTransition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                FailureTransition = new NumericValue<int>(serializable.FailureTransition, 1, 1000);
                Enemy = database.GetFleetId(serializable.Enemy);
                Loot = database.GetLootId(serializable.Loot);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = VictoryTransition.Value;
                serializable.FailureTransition = FailureTransition.Value;
                serializable.Enemy = Enemy.Id;
                serializable.Loot = Loot.Id;
                return serializable;
            }

            public NumericValue<int> VictoryTransition = new NumericValue<int>(0,1,1000);
            public NumericValue<int> FailureTransition = new NumericValue<int>(0,1,1000);
            public ItemId<FleetData> Enemy = ItemId<FleetData>.Empty;
            public ItemId<LootData> Loot = ItemId<LootData>.Empty;
        }

        private class Content_AttackOccupants : IContent
        {
            public Content_AttackOccupants(NodeSerializable serializable, Database database)
            {
                if (serializable == null || database == null) return;
                VictoryTransition = new NumericValue<int>(serializable.DefaultTransition, 1, 1000);
                FailureTransition = new NumericValue<int>(serializable.FailureTransition, 1, 1000);
            }

            public NodeSerializable Serialize()
            {
                var serializable = new NodeSerializable();
                serializable.DefaultTransition = VictoryTransition.Value;
                serializable.FailureTransition = FailureTransition.Value;
                return serializable;
            }

            public NumericValue<int> VictoryTransition = new NumericValue<int>(0,1,1000);
            public NumericValue<int> FailureTransition = new NumericValue<int>(0,1,1000);
        }

    }
}
