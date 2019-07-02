//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Collections.Generic;
using GameDatabase.DataSource;
using GameDatabase.Serialization;
using GameDatabase.Serializable;
using GameDatabase.Enums;

namespace GameDatabase
{
    public class JsonDatabase
    {
        public JsonDatabase(IDataSource dataSource, IJsonSerializer serializer)
        {
            _dataSource = dataSource;
            _serializer = serializer;
            foreach (var file in dataSource.Files)
            {
                var item = _serializer.FromJson<SerializableItem>(file.Content);
                var type = (ItemType)item.ItemType;
                if (type == ItemType.AmmunitionObsolete)
                {
                    var data = _serializer.FromJson<AmmunitionObsoleteSerializable>(file.Content);
                    data.FileName = file.Name;
                    _ammunitionobsoleteMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Component)
                {
                    var data = _serializer.FromJson<ComponentSerializable>(file.Content);
                    data.FileName = file.Name;
                    _componentMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.ComponentMod)
                {
                    var data = _serializer.FromJson<ComponentModSerializable>(file.Content);
                    data.FileName = file.Name;
                    _componentmodMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.ComponentStats)
                {
                    var data = _serializer.FromJson<ComponentStatsSerializable>(file.Content);
                    data.FileName = file.Name;
                    _componentstatsMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Device)
                {
                    var data = _serializer.FromJson<DeviceSerializable>(file.Content);
                    data.FileName = file.Name;
                    _deviceMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.DroneBay)
                {
                    var data = _serializer.FromJson<DroneBaySerializable>(file.Content);
                    data.FileName = file.Name;
                    _dronebayMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Faction)
                {
                    var data = _serializer.FromJson<FactionSerializable>(file.Content);
                    data.FileName = file.Name;
                    _factionMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Character)
                {
                    var data = _serializer.FromJson<CharacterSerializable>(file.Content);
                    data.FileName = file.Name;
                    _characterMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Fleet)
                {
                    var data = _serializer.FromJson<FleetSerializable>(file.Content);
                    data.FileName = file.Name;
                    _fleetMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Loot)
                {
                    var data = _serializer.FromJson<LootSerializable>(file.Content);
                    data.FileName = file.Name;
                    _lootMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Quest)
                {
                    var data = _serializer.FromJson<QuestSerializable>(file.Content);
                    data.FileName = file.Name;
                    _questMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.QuestItem)
                {
                    var data = _serializer.FromJson<QuestItemSerializable>(file.Content);
                    data.FileName = file.Name;
                    _questitemMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Satellite)
                {
                    var data = _serializer.FromJson<SatelliteSerializable>(file.Content);
                    data.FileName = file.Name;
                    _satelliteMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.SatelliteBuild)
                {
                    var data = _serializer.FromJson<SatelliteBuildSerializable>(file.Content);
                    data.FileName = file.Name;
                    _satellitebuildMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Ship)
                {
                    var data = _serializer.FromJson<ShipSerializable>(file.Content);
                    data.FileName = file.Name;
                    _shipMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.ShipBuild)
                {
                    var data = _serializer.FromJson<ShipBuildSerializable>(file.Content);
                    data.FileName = file.Name;
                    _shipbuildMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Technology)
                {
                    var data = _serializer.FromJson<TechnologySerializable>(file.Content);
                    data.FileName = file.Name;
                    _technologyMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Ammunition)
                {
                    var data = _serializer.FromJson<AmmunitionSerializable>(file.Content);
                    data.FileName = file.Name;
                    _ammunitionMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.BulletPrefab)
                {
                    var data = _serializer.FromJson<BulletPrefabSerializable>(file.Content);
                    data.FileName = file.Name;
                    _bulletprefabMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.VisualEffect)
                {
                    var data = _serializer.FromJson<VisualEffectSerializable>(file.Content);
                    data.FileName = file.Name;
                    _visualeffectMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.Weapon)
                {
                    var data = _serializer.FromJson<WeaponSerializable>(file.Content);
                    data.FileName = file.Name;
                    _weaponMap.Add(data.ItemType, data);
                }
                else if (type == ItemType.GalaxySettings)
                {
                    var data = _serializer.FromJson<GalaxySettingsSerializable>(file.Content);
                    data.FileName = file.Name;
                    if (GalaxySettings!= null)
                        throw new DatabaseException("Duplicate settings file found - " + file.Name);
                    GalaxySettings = data;
                }
                else if (type == ItemType.ShipSettings)
                {
                    var data = _serializer.FromJson<ShipSettingsSerializable>(file.Content);
                    data.FileName = file.Name;
                    if (ShipSettings!= null)
                        throw new DatabaseException("Duplicate settings file found - " + file.Name);
                    ShipSettings = data;
                }
                else
                {
                    throw new DatabaseException("Unknown file type - " + type + "(" + file.Name + ")");
                }
            }
        }

        public GalaxySettingsSerializable GalaxySettings { get; }
        public ShipSettingsSerializable ShipSettings { get; }

        public IEnumerable<AmmunitionObsoleteSerializable> AmmunitionObsoleteList => _ammunitionobsoleteMap.Values;
        public IEnumerable<ComponentSerializable> ComponentList => _componentMap.Values;
        public IEnumerable<ComponentModSerializable> ComponentModList => _componentmodMap.Values;
        public IEnumerable<ComponentStatsSerializable> ComponentStatsList => _componentstatsMap.Values;
        public IEnumerable<DeviceSerializable> DeviceList => _deviceMap.Values;
        public IEnumerable<DroneBaySerializable> DroneBayList => _dronebayMap.Values;
        public IEnumerable<FactionSerializable> FactionList => _factionMap.Values;
        public IEnumerable<CharacterSerializable> CharacterList => _characterMap.Values;
        public IEnumerable<FleetSerializable> FleetList => _fleetMap.Values;
        public IEnumerable<LootSerializable> LootList => _lootMap.Values;
        public IEnumerable<QuestSerializable> QuestList => _questMap.Values;
        public IEnumerable<QuestItemSerializable> QuestItemList => _questitemMap.Values;
        public IEnumerable<SatelliteSerializable> SatelliteList => _satelliteMap.Values;
        public IEnumerable<SatelliteBuildSerializable> SatelliteBuildList => _satellitebuildMap.Values;
        public IEnumerable<ShipSerializable> ShipList => _shipMap.Values;
        public IEnumerable<ShipBuildSerializable> ShipBuildList => _shipbuildMap.Values;
        public IEnumerable<TechnologySerializable> TechnologyList => _technologyMap.Values;
        public IEnumerable<AmmunitionSerializable> AmmunitionList => _ammunitionMap.Values;
        public IEnumerable<BulletPrefabSerializable> BulletPrefabList => _bulletprefabMap.Values;
        public IEnumerable<VisualEffectSerializable> VisualEffectList => _visualeffectMap.Values;
        public IEnumerable<WeaponSerializable> WeaponList => _weaponMap.Values;

        public AmmunitionObsoleteSerializable GetAmmunitionObsolete(int id) => _ammunitionobsoleteMap.TryGetValue(id, out var value) ? value : null;
        public ComponentSerializable GetComponent(int id) => _componentMap.TryGetValue(id, out var value) ? value : null;
        public ComponentModSerializable GetComponentMod(int id) => _componentmodMap.TryGetValue(id, out var value) ? value : null;
        public ComponentStatsSerializable GetComponentStats(int id) => _componentstatsMap.TryGetValue(id, out var value) ? value : null;
        public DeviceSerializable GetDevice(int id) => _deviceMap.TryGetValue(id, out var value) ? value : null;
        public DroneBaySerializable GetDroneBay(int id) => _dronebayMap.TryGetValue(id, out var value) ? value : null;
        public FactionSerializable GetFaction(int id) => _factionMap.TryGetValue(id, out var value) ? value : null;
        public CharacterSerializable GetCharacter(int id) => _characterMap.TryGetValue(id, out var value) ? value : null;
        public FleetSerializable GetFleet(int id) => _fleetMap.TryGetValue(id, out var value) ? value : null;
        public LootSerializable GetLoot(int id) => _lootMap.TryGetValue(id, out var value) ? value : null;
        public QuestSerializable GetQuest(int id) => _questMap.TryGetValue(id, out var value) ? value : null;
        public QuestItemSerializable GetQuestItem(int id) => _questitemMap.TryGetValue(id, out var value) ? value : null;
        public SatelliteSerializable GetSatellite(int id) => _satelliteMap.TryGetValue(id, out var value) ? value : null;
        public SatelliteBuildSerializable GetSatelliteBuild(int id) => _satellitebuildMap.TryGetValue(id, out var value) ? value : null;
        public ShipSerializable GetShip(int id) => _shipMap.TryGetValue(id, out var value) ? value : null;
        public ShipBuildSerializable GetShipBuild(int id) => _shipbuildMap.TryGetValue(id, out var value) ? value : null;
        public TechnologySerializable GetTechnology(int id) => _technologyMap.TryGetValue(id, out var value) ? value : null;
        public AmmunitionSerializable GetAmmunition(int id) => _ammunitionMap.TryGetValue(id, out var value) ? value : null;
        public BulletPrefabSerializable GetBulletPrefab(int id) => _bulletprefabMap.TryGetValue(id, out var value) ? value : null;
        public VisualEffectSerializable GetVisualEffect(int id) => _visualeffectMap.TryGetValue(id, out var value) ? value : null;
        public WeaponSerializable GetWeapon(int id) => _weaponMap.TryGetValue(id, out var value) ? value : null;

        private readonly Dictionary<int, AmmunitionObsoleteSerializable> _ammunitionobsoleteMap = new Dictionary<int, AmmunitionObsoleteSerializable>();
        private readonly Dictionary<int, ComponentSerializable> _componentMap = new Dictionary<int, ComponentSerializable>();
        private readonly Dictionary<int, ComponentModSerializable> _componentmodMap = new Dictionary<int, ComponentModSerializable>();
        private readonly Dictionary<int, ComponentStatsSerializable> _componentstatsMap = new Dictionary<int, ComponentStatsSerializable>();
        private readonly Dictionary<int, DeviceSerializable> _deviceMap = new Dictionary<int, DeviceSerializable>();
        private readonly Dictionary<int, DroneBaySerializable> _dronebayMap = new Dictionary<int, DroneBaySerializable>();
        private readonly Dictionary<int, FactionSerializable> _factionMap = new Dictionary<int, FactionSerializable>();
        private readonly Dictionary<int, CharacterSerializable> _characterMap = new Dictionary<int, CharacterSerializable>();
        private readonly Dictionary<int, FleetSerializable> _fleetMap = new Dictionary<int, FleetSerializable>();
        private readonly Dictionary<int, LootSerializable> _lootMap = new Dictionary<int, LootSerializable>();
        private readonly Dictionary<int, QuestSerializable> _questMap = new Dictionary<int, QuestSerializable>();
        private readonly Dictionary<int, QuestItemSerializable> _questitemMap = new Dictionary<int, QuestItemSerializable>();
        private readonly Dictionary<int, SatelliteSerializable> _satelliteMap = new Dictionary<int, SatelliteSerializable>();
        private readonly Dictionary<int, SatelliteBuildSerializable> _satellitebuildMap = new Dictionary<int, SatelliteBuildSerializable>();
        private readonly Dictionary<int, ShipSerializable> _shipMap = new Dictionary<int, ShipSerializable>();
        private readonly Dictionary<int, ShipBuildSerializable> _shipbuildMap = new Dictionary<int, ShipBuildSerializable>();
        private readonly Dictionary<int, TechnologySerializable> _technologyMap = new Dictionary<int, TechnologySerializable>();
        private readonly Dictionary<int, AmmunitionSerializable> _ammunitionMap = new Dictionary<int, AmmunitionSerializable>();
        private readonly Dictionary<int, BulletPrefabSerializable> _bulletprefabMap = new Dictionary<int, BulletPrefabSerializable>();
        private readonly Dictionary<int, VisualEffectSerializable> _visualeffectMap = new Dictionary<int, VisualEffectSerializable>();
        private readonly Dictionary<int, WeaponSerializable> _weaponMap = new Dictionary<int, WeaponSerializable>();

        private readonly IDataSource _dataSource;
        private readonly IJsonSerializer _serializer;
    }
}
