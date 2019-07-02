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
    public class InstalledComponentData
    {
        public static InstalledComponentData Deserialize(InstalledComponentSerializable serializable, Database database)
        {
            return new InstalledComponentData(serializable, database);
        }

        private InstalledComponentData(InstalledComponentSerializable serializable, Database database)
        {
            ComponentId = database.GetComponentId(serializable.ComponentId);
            Modification = serializable.Modification;
            Quality = serializable.Quality;
            Locked = serializable.Locked;
            X = new NumericValue<int>(serializable.X, -128, 127);
            Y = new NumericValue<int>(serializable.Y, -128, 127);
            BarrelId = new NumericValue<int>(serializable.BarrelId, 0, 32);
            Behaviour = new NumericValue<int>(serializable.Behaviour, 0, 10);
            KeyBinding = new NumericValue<int>(serializable.KeyBinding, -10, 10);
        }

        public InstalledComponentSerializable Serialize()
        {
            var serializable = new InstalledComponentSerializable();
            serializable.ComponentId = ComponentId.Id;
            serializable.Modification = Modification;
            serializable.Quality = Quality;
            serializable.Locked = Locked;
            serializable.X = X.Value;
            serializable.Y = Y.Value;
            serializable.BarrelId = BarrelId.Value;
            serializable.Behaviour = Behaviour.Value;
            serializable.KeyBinding = KeyBinding.Value;
            return serializable;
        }

        public ItemId<ComponentData> ComponentId = ItemId<ComponentData>.Empty;
        public ComponentModType Modification;
        public ModificationQuality Quality;
        public bool Locked;
        public NumericValue<int> X = new NumericValue<int>(0,-128,127);
        public NumericValue<int> Y = new NumericValue<int>(0,-128,127);
        public NumericValue<int> BarrelId = new NumericValue<int>(0,0,32);
        public NumericValue<int> Behaviour = new NumericValue<int>(0,0,10);
        public NumericValue<int> KeyBinding = new NumericValue<int>(0,-10,10);
    }
}
