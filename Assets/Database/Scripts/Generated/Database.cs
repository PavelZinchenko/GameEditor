//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GameDatabase.Types;
using GameDatabase.DataSource;
using GameDatabase.Serialization;
using GameDatabase.Classes;

namespace GameDatabase
{
    public class Database
    {
        public Database(IDataSource defaultDataSource, IJsonSerializer serializer)
        {
            _serializer = serializer;
            _defaultDataSource = defaultDataSource;
            Load();
        }

        public void Load(IDataSource dataSource = null)
        {
            Reset();
            _jsonDatabase = new JsonDatabase(dataSource ?? _defaultDataSource, _serializer);
        }

        private void Reset()
        {
            Reset();
            _ammunitionobsoleteMap.Clear();
            _componentMap.Clear();
            _componentmodMap.Clear();
            _componentstatsMap.Clear();
            _deviceMap.Clear();
            _dronebayMap.Clear();
            _factionMap.Clear();
            _characterMap.Clear();
            _fleetMap.Clear();
            _lootMap.Clear();
            _questMap.Clear();
            _questitemMap.Clear();
            _satelliteMap.Clear();
            _satellitebuildMap.Clear();
            _shipMap.Clear();
            _shipbuildMap.Clear();
            _technologyMap.Clear();
            _ammunitionMap.Clear();
            _bulletprefabMap.Clear();
            _visualeffectMap.Clear();
            _weaponMap.Clear();
            _galaxysettings = null;
            _shipsettings = null;
            _jsonDatabase = null;
        }

        public GalaxySettingsData GalaxySettings => _galaxysettings ?? (_galaxysettings = GalaxySettingsData.Deserialize(_jsonDatabase.GalaxySettings, this));
        public ShipSettingsData ShipSettings => _shipsettings ?? (_shipsettings = ShipSettingsData.Deserialize(_jsonDatabase.ShipSettings, this));

        public IEnumerable<ItemId<AmmunitionObsoleteData>> AmmunitionObsoleteIds { get { return _jsonDatabase.AmmunitionObsoleteList.Select(item => new ItemId<AmmunitionObsoleteData>(item.Id, item.FileName)); } }
        public ItemId<AmmunitionObsoleteData> GetAmmunitionObsoleteId(int id) { return new ItemId<AmmunitionObsoleteData>(_jsonDatabase.GetAmmunitionObsolete(id)); }
        public AmmunitionObsoleteData GetAmmunitionObsolete(int id)
        {
            if (!_ammunitionobsoleteMap.TryGetValue(id, out var item))
            {
                _ammunitionobsoleteMap.Add(id, null);
                _ammunitionobsoleteMap[id] = item = AmmunitionObsoleteData.Deserialize(_jsonDatabase.GetAmmunitionObsolete(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "AmmunitionObsolete_" + id);
            return item;
        }

        public IEnumerable<ItemId<ComponentData>> ComponentIds { get { return _jsonDatabase.ComponentList.Select(item => new ItemId<ComponentData>(item.Id, item.FileName)); } }
        public ItemId<ComponentData> GetComponentId(int id) { return new ItemId<ComponentData>(_jsonDatabase.GetComponent(id)); }
        public ComponentData GetComponent(int id)
        {
            if (!_componentMap.TryGetValue(id, out var item))
            {
                _componentMap.Add(id, null);
                _componentMap[id] = item = ComponentData.Deserialize(_jsonDatabase.GetComponent(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Component_" + id);
            return item;
        }

        public IEnumerable<ItemId<ComponentModData>> ComponentModIds { get { return _jsonDatabase.ComponentModList.Select(item => new ItemId<ComponentModData>(item.Id, item.FileName)); } }
        public ItemId<ComponentModData> GetComponentModId(int id) { return new ItemId<ComponentModData>(_jsonDatabase.GetComponentMod(id)); }
        public ComponentModData GetComponentMod(int id)
        {
            if (!_componentmodMap.TryGetValue(id, out var item))
            {
                _componentmodMap.Add(id, null);
                _componentmodMap[id] = item = ComponentModData.Deserialize(_jsonDatabase.GetComponentMod(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "ComponentMod_" + id);
            return item;
        }

        public IEnumerable<ItemId<ComponentStatsData>> ComponentStatsIds { get { return _jsonDatabase.ComponentStatsList.Select(item => new ItemId<ComponentStatsData>(item.Id, item.FileName)); } }
        public ItemId<ComponentStatsData> GetComponentStatsId(int id) { return new ItemId<ComponentStatsData>(_jsonDatabase.GetComponentStats(id)); }
        public ComponentStatsData GetComponentStats(int id)
        {
            if (!_componentstatsMap.TryGetValue(id, out var item))
            {
                _componentstatsMap.Add(id, null);
                _componentstatsMap[id] = item = ComponentStatsData.Deserialize(_jsonDatabase.GetComponentStats(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "ComponentStats_" + id);
            return item;
        }

        public IEnumerable<ItemId<DeviceData>> DeviceIds { get { return _jsonDatabase.DeviceList.Select(item => new ItemId<DeviceData>(item.Id, item.FileName)); } }
        public ItemId<DeviceData> GetDeviceId(int id) { return new ItemId<DeviceData>(_jsonDatabase.GetDevice(id)); }
        public DeviceData GetDevice(int id)
        {
            if (!_deviceMap.TryGetValue(id, out var item))
            {
                _deviceMap.Add(id, null);
                _deviceMap[id] = item = DeviceData.Deserialize(_jsonDatabase.GetDevice(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Device_" + id);
            return item;
        }

        public IEnumerable<ItemId<DroneBayData>> DroneBayIds { get { return _jsonDatabase.DroneBayList.Select(item => new ItemId<DroneBayData>(item.Id, item.FileName)); } }
        public ItemId<DroneBayData> GetDroneBayId(int id) { return new ItemId<DroneBayData>(_jsonDatabase.GetDroneBay(id)); }
        public DroneBayData GetDroneBay(int id)
        {
            if (!_dronebayMap.TryGetValue(id, out var item))
            {
                _dronebayMap.Add(id, null);
                _dronebayMap[id] = item = DroneBayData.Deserialize(_jsonDatabase.GetDroneBay(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "DroneBay_" + id);
            return item;
        }

        public IEnumerable<ItemId<FactionData>> FactionIds { get { return _jsonDatabase.FactionList.Select(item => new ItemId<FactionData>(item.Id, item.FileName)); } }
        public ItemId<FactionData> GetFactionId(int id) { return new ItemId<FactionData>(_jsonDatabase.GetFaction(id)); }
        public FactionData GetFaction(int id)
        {
            if (!_factionMap.TryGetValue(id, out var item))
            {
                _factionMap.Add(id, null);
                _factionMap[id] = item = FactionData.Deserialize(_jsonDatabase.GetFaction(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Faction_" + id);
            return item;
        }

        public IEnumerable<ItemId<CharacterData>> CharacterIds { get { return _jsonDatabase.CharacterList.Select(item => new ItemId<CharacterData>(item.Id, item.FileName)); } }
        public ItemId<CharacterData> GetCharacterId(int id) { return new ItemId<CharacterData>(_jsonDatabase.GetCharacter(id)); }
        public CharacterData GetCharacter(int id)
        {
            if (!_characterMap.TryGetValue(id, out var item))
            {
                _characterMap.Add(id, null);
                _characterMap[id] = item = CharacterData.Deserialize(_jsonDatabase.GetCharacter(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Character_" + id);
            return item;
        }

        public IEnumerable<ItemId<FleetData>> FleetIds { get { return _jsonDatabase.FleetList.Select(item => new ItemId<FleetData>(item.Id, item.FileName)); } }
        public ItemId<FleetData> GetFleetId(int id) { return new ItemId<FleetData>(_jsonDatabase.GetFleet(id)); }
        public FleetData GetFleet(int id)
        {
            if (!_fleetMap.TryGetValue(id, out var item))
            {
                _fleetMap.Add(id, null);
                _fleetMap[id] = item = FleetData.Deserialize(_jsonDatabase.GetFleet(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Fleet_" + id);
            return item;
        }

        public IEnumerable<ItemId<LootData>> LootIds { get { return _jsonDatabase.LootList.Select(item => new ItemId<LootData>(item.Id, item.FileName)); } }
        public ItemId<LootData> GetLootId(int id) { return new ItemId<LootData>(_jsonDatabase.GetLoot(id)); }
        public LootData GetLoot(int id)
        {
            if (!_lootMap.TryGetValue(id, out var item))
            {
                _lootMap.Add(id, null);
                _lootMap[id] = item = LootData.Deserialize(_jsonDatabase.GetLoot(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Loot_" + id);
            return item;
        }

        public IEnumerable<ItemId<QuestData>> QuestIds { get { return _jsonDatabase.QuestList.Select(item => new ItemId<QuestData>(item.Id, item.FileName)); } }
        public ItemId<QuestData> GetQuestId(int id) { return new ItemId<QuestData>(_jsonDatabase.GetQuest(id)); }
        public QuestData GetQuest(int id)
        {
            if (!_questMap.TryGetValue(id, out var item))
            {
                _questMap.Add(id, null);
                _questMap[id] = item = QuestData.Deserialize(_jsonDatabase.GetQuest(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Quest_" + id);
            return item;
        }

        public IEnumerable<ItemId<QuestItemData>> QuestItemIds { get { return _jsonDatabase.QuestItemList.Select(item => new ItemId<QuestItemData>(item.Id, item.FileName)); } }
        public ItemId<QuestItemData> GetQuestItemId(int id) { return new ItemId<QuestItemData>(_jsonDatabase.GetQuestItem(id)); }
        public QuestItemData GetQuestItem(int id)
        {
            if (!_questitemMap.TryGetValue(id, out var item))
            {
                _questitemMap.Add(id, null);
                _questitemMap[id] = item = QuestItemData.Deserialize(_jsonDatabase.GetQuestItem(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "QuestItem_" + id);
            return item;
        }

        public IEnumerable<ItemId<SatelliteData>> SatelliteIds { get { return _jsonDatabase.SatelliteList.Select(item => new ItemId<SatelliteData>(item.Id, item.FileName)); } }
        public ItemId<SatelliteData> GetSatelliteId(int id) { return new ItemId<SatelliteData>(_jsonDatabase.GetSatellite(id)); }
        public SatelliteData GetSatellite(int id)
        {
            if (!_satelliteMap.TryGetValue(id, out var item))
            {
                _satelliteMap.Add(id, null);
                _satelliteMap[id] = item = SatelliteData.Deserialize(_jsonDatabase.GetSatellite(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Satellite_" + id);
            return item;
        }

        public IEnumerable<ItemId<SatelliteBuildData>> SatelliteBuildIds { get { return _jsonDatabase.SatelliteBuildList.Select(item => new ItemId<SatelliteBuildData>(item.Id, item.FileName)); } }
        public ItemId<SatelliteBuildData> GetSatelliteBuildId(int id) { return new ItemId<SatelliteBuildData>(_jsonDatabase.GetSatelliteBuild(id)); }
        public SatelliteBuildData GetSatelliteBuild(int id)
        {
            if (!_satellitebuildMap.TryGetValue(id, out var item))
            {
                _satellitebuildMap.Add(id, null);
                _satellitebuildMap[id] = item = SatelliteBuildData.Deserialize(_jsonDatabase.GetSatelliteBuild(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "SatelliteBuild_" + id);
            return item;
        }

        public IEnumerable<ItemId<ShipData>> ShipIds { get { return _jsonDatabase.ShipList.Select(item => new ItemId<ShipData>(item.Id, item.FileName)); } }
        public ItemId<ShipData> GetShipId(int id) { return new ItemId<ShipData>(_jsonDatabase.GetShip(id)); }
        public ShipData GetShip(int id)
        {
            if (!_shipMap.TryGetValue(id, out var item))
            {
                _shipMap.Add(id, null);
                _shipMap[id] = item = ShipData.Deserialize(_jsonDatabase.GetShip(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Ship_" + id);
            return item;
        }

        public IEnumerable<ItemId<ShipBuildData>> ShipBuildIds { get { return _jsonDatabase.ShipBuildList.Select(item => new ItemId<ShipBuildData>(item.Id, item.FileName)); } }
        public ItemId<ShipBuildData> GetShipBuildId(int id) { return new ItemId<ShipBuildData>(_jsonDatabase.GetShipBuild(id)); }
        public ShipBuildData GetShipBuild(int id)
        {
            if (!_shipbuildMap.TryGetValue(id, out var item))
            {
                _shipbuildMap.Add(id, null);
                _shipbuildMap[id] = item = ShipBuildData.Deserialize(_jsonDatabase.GetShipBuild(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "ShipBuild_" + id);
            return item;
        }

        public IEnumerable<ItemId<TechnologyData>> TechnologyIds { get { return _jsonDatabase.TechnologyList.Select(item => new ItemId<TechnologyData>(item.Id, item.FileName)); } }
        public ItemId<TechnologyData> GetTechnologyId(int id) { return new ItemId<TechnologyData>(_jsonDatabase.GetTechnology(id)); }
        public TechnologyData GetTechnology(int id)
        {
            if (!_technologyMap.TryGetValue(id, out var item))
            {
                _technologyMap.Add(id, null);
                _technologyMap[id] = item = TechnologyData.Deserialize(_jsonDatabase.GetTechnology(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Technology_" + id);
            return item;
        }

        public IEnumerable<ItemId<AmmunitionData>> AmmunitionIds { get { return _jsonDatabase.AmmunitionList.Select(item => new ItemId<AmmunitionData>(item.Id, item.FileName)); } }
        public ItemId<AmmunitionData> GetAmmunitionId(int id) { return new ItemId<AmmunitionData>(_jsonDatabase.GetAmmunition(id)); }
        public AmmunitionData GetAmmunition(int id)
        {
            if (!_ammunitionMap.TryGetValue(id, out var item))
            {
                _ammunitionMap.Add(id, null);
                _ammunitionMap[id] = item = AmmunitionData.Deserialize(_jsonDatabase.GetAmmunition(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Ammunition_" + id);
            return item;
        }

        public IEnumerable<ItemId<BulletPrefabData>> BulletPrefabIds { get { return _jsonDatabase.BulletPrefabList.Select(item => new ItemId<BulletPrefabData>(item.Id, item.FileName)); } }
        public ItemId<BulletPrefabData> GetBulletPrefabId(int id) { return new ItemId<BulletPrefabData>(_jsonDatabase.GetBulletPrefab(id)); }
        public BulletPrefabData GetBulletPrefab(int id)
        {
            if (!_bulletprefabMap.TryGetValue(id, out var item))
            {
                _bulletprefabMap.Add(id, null);
                _bulletprefabMap[id] = item = BulletPrefabData.Deserialize(_jsonDatabase.GetBulletPrefab(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "BulletPrefab_" + id);
            return item;
        }

        public IEnumerable<ItemId<VisualEffectData>> VisualEffectIds { get { return _jsonDatabase.VisualEffectList.Select(item => new ItemId<VisualEffectData>(item.Id, item.FileName)); } }
        public ItemId<VisualEffectData> GetVisualEffectId(int id) { return new ItemId<VisualEffectData>(_jsonDatabase.GetVisualEffect(id)); }
        public VisualEffectData GetVisualEffect(int id)
        {
            if (!_visualeffectMap.TryGetValue(id, out var item))
            {
                _visualeffectMap.Add(id, null);
                _visualeffectMap[id] = item = VisualEffectData.Deserialize(_jsonDatabase.GetVisualEffect(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "VisualEffect_" + id);
            return item;
        }

        public IEnumerable<ItemId<WeaponData>> WeaponIds { get { return _jsonDatabase.WeaponList.Select(item => new ItemId<WeaponData>(item.Id, item.FileName)); } }
        public ItemId<WeaponData> GetWeaponId(int id) { return new ItemId<WeaponData>(_jsonDatabase.GetWeapon(id)); }
        public WeaponData GetWeapon(int id)
        {
            if (!_weaponMap.TryGetValue(id, out var item))
            {
                _weaponMap.Add(id, null);
                _weaponMap[id] = item = WeaponData.Deserialize(_jsonDatabase.GetWeapon(id), this);
            }
            if (item == null) throw new DatabaseException(CircularDependencyText + "Weapon_" + id);
            return item;
        }

        private GalaxySettingsData _galaxysettings;
        private ShipSettingsData _shipsettings;
        private readonly Dictionary<int, AmmunitionObsoleteData> _ammunitionobsoleteMap = new Dictionary<int, AmmunitionObsoleteData>();
        private readonly Dictionary<int, ComponentData> _componentMap = new Dictionary<int, ComponentData>();
        private readonly Dictionary<int, ComponentModData> _componentmodMap = new Dictionary<int, ComponentModData>();
        private readonly Dictionary<int, ComponentStatsData> _componentstatsMap = new Dictionary<int, ComponentStatsData>();
        private readonly Dictionary<int, DeviceData> _deviceMap = new Dictionary<int, DeviceData>();
        private readonly Dictionary<int, DroneBayData> _dronebayMap = new Dictionary<int, DroneBayData>();
        private readonly Dictionary<int, FactionData> _factionMap = new Dictionary<int, FactionData>();
        private readonly Dictionary<int, CharacterData> _characterMap = new Dictionary<int, CharacterData>();
        private readonly Dictionary<int, FleetData> _fleetMap = new Dictionary<int, FleetData>();
        private readonly Dictionary<int, LootData> _lootMap = new Dictionary<int, LootData>();
        private readonly Dictionary<int, QuestData> _questMap = new Dictionary<int, QuestData>();
        private readonly Dictionary<int, QuestItemData> _questitemMap = new Dictionary<int, QuestItemData>();
        private readonly Dictionary<int, SatelliteData> _satelliteMap = new Dictionary<int, SatelliteData>();
        private readonly Dictionary<int, SatelliteBuildData> _satellitebuildMap = new Dictionary<int, SatelliteBuildData>();
        private readonly Dictionary<int, ShipData> _shipMap = new Dictionary<int, ShipData>();
        private readonly Dictionary<int, ShipBuildData> _shipbuildMap = new Dictionary<int, ShipBuildData>();
        private readonly Dictionary<int, TechnologyData> _technologyMap = new Dictionary<int, TechnologyData>();
        private readonly Dictionary<int, AmmunitionData> _ammunitionMap = new Dictionary<int, AmmunitionData>();
        private readonly Dictionary<int, BulletPrefabData> _bulletprefabMap = new Dictionary<int, BulletPrefabData>();
        private readonly Dictionary<int, VisualEffectData> _visualeffectMap = new Dictionary<int, VisualEffectData>();
        private readonly Dictionary<int, WeaponData> _weaponMap = new Dictionary<int, WeaponData>();

        private JsonDatabase _jsonDatabase;
        private readonly IJsonSerializer _serializer;
        private readonly IDataSource _defaultDataSource;
        private const string CircularDependencyText = "Circular dependency found: ";
    }
}
