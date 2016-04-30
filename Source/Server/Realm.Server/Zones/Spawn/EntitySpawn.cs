//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Factories;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Properties;

//
//namespace Realm.Server.Zones
//
//{
//    public class EntitySpawn : GameEntityConcrete
//    {
//        private readonly IList<SpawnProfile> _spawnProfiles;
//        private readonly IList<SpawnLocation> _spawnLocations;
//        private readonly IList<IGameInstance> _spawned;
//        private readonly Hashtable _spawnedMap;

//        private readonly IList<string> _logHistory;
//        private readonly int _maximumLogLength;
//        private readonly IList<GameUser> _monitors;

//        public EntitySpawn(long id, string name)
//            : base(id, name, null)
//        {
//            _spawned = new List<IGameInstance>();
//            _spawnProfiles = new List<SpawnProfile>();
//            _spawnLocations = new List<SpawnLocation>();
//            _spawnedMap = new Hashtable();

//            _logHistory = new List<string>();
//            _maximumLogLength = 100;
//            _monitors = new List<GameUser>();
//        }

//        /// <summary>
//        /// Override this so that we listen to the zonepop event when the zone is set
//        /// </summary>
//        public override IGameEntity Location
//        {
//            get
//            {
//                return base.Location;
//            }
//            set
//            {
//                base.Location = value;
//                var zone = value as Zone;
//                EventManager.RegisterListener(this, zone, typeof(OnZonePop), SpawnOnZonePop);
//            }
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//            //    base.OnInit();
//            var flag = (Flag)DataManager.Get("Flags", "spawn");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat(ErrorResources.ERR_FLAG_NOT_FOUND, "spawn");
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public int NumberSpawned { get { return _spawned.Count; } }

//        public IEnumerable<string> LogHistory { get { return _logHistory; } }

//        public IEnumerable<SpawnProfile> SpawnProfiles { get { return _spawnProfiles; } }

//        public IEnumerable<SpawnLocation> SpawnLocations { get { return _spawnLocations; } }

//        public void AddMessage(string msg)
//        {
//            if (_logHistory.Count >= _maximumLogLength)
//                _logHistory.RemoveAt(0);

//            foreach (GameUser user in _monitors)
//                user.SendText(string.Format(MessageResources.MSG_ADMIN_MONITOR_SPAWN, Name, ID, msg));

//            _logHistory.Add(msg);
//        }

//        public void ClearHistory()
//        {
//            _logHistory.Clear();
//        }

//        public void AddMonitor(GameUser oUser)
//        {
//            if (_monitors.Contains(oUser)) return;
//            _monitors.Add(oUser);
//        }

//        public void RemoveMonitor(GameUser oUser)
//        {
//            if (!_monitors.Contains(oUser)) return;
//            _monitors.Remove(oUser);
//        }

//        public bool IsMonitoring(GameUser oUser)
//        {
//            return _monitors.Contains(oUser);
//        }

//        public bool AddProfile(SpawnProfile profile)
//        {
//            if (_spawnProfiles.Contains(profile)) return false;
//            _spawnProfiles.Add(profile);
//            AddMessage(string.Format("Profile[{0}, {1}] added.", profile.ID, profile.Name));
//            return true;
//        }

//        public bool AddLocation(SpawnLocation loc)
//        {
//            if (_spawnLocations.Contains(loc)) return false;
//            _spawnLocations.Add(loc);
//            AddMessage(string.Format("Location[{0}, {1}] added.", loc.ID, loc.Name));
//            return true;
//        }

//        public SpawnProfile CreateProfile(int id, string name)
//        {
//            var profile = new SpawnProfile(id, name, 1, 1, 100);
//            //LuaManager.Lua.CreateTable("profile");
//            return !AddProfile(profile) ? null : profile;
//        }

//        public SpawnLocation CreateLocation(int id, string name)
//        {
//            var loc = new SpawnLocation(id, name, Globals.Globals.SpawnTypes.None, 0, -1);
//            //LuaManager.Lua.CreateTable("location");
//            return !AddLocation(loc) ? null : loc;
//        }

//        public bool Execute()
//        {
//            AddMessage(string.Format("Executing spawn[{0}]", ID));

//            try
//            {
//                foreach (var profile in _spawnProfiles)
//                {
//                    IGameInstance spawnedEntity = null;
//                    switch (profile.Location.Type)
//                    {
//                        case Globals.Globals.SpawnTypes.Space:
//                            Space Space = EntityManager.LuaGetConcrete(profile.Location.Value) as Space;
//                            if (Space.IsNull())
//                            {
//                                Log.ErrorFormat("Spawn[{0}] has an invalid Space ID.", ID);
//                                return false;
//                            }

//                            if (NumberSpawned >= profile.MaxQuantity) return false;

//                            bool ignorePctChance = false;
//                            int diff;
//                            if (NumberSpawned < profile.MinQuantity)
//                            {
//                                //// spawn right now, no matter the percent chance
//                                diff = profile.MinQuantity - NumberSpawned;
//                                ignorePctChance = true;
//                            }
//                            else
//                            {
//                                //// just get the standard difference
//                                diff = profile.MaxQuantity - profile.MinQuantity;
//                            }

//                            for (var j = 0; j < diff; j++)
//                            {
//                                //// pick a template to spawn
//                                IGameTemplate entity = profile.PickTemplate();

//                                if (ignorePctChance)
//                                    spawnedEntity = SpawnFromTemplate(entity, Space);
//                                else
//                                {
//                                    if (Library.Common.Random.D100(1) >= profile.Chance)
//                                        spawnedEntity = SpawnFromTemplate(entity, Space);
//                                }

//                                if (spawnedEntity.IsNotNull())
//                                {
//                                    _spawned.Add(spawnedEntity);
//                                    EventManager.RegisterListener(this, spawnedEntity, typeof(OnInstanceDisposed), SpawnedEntityOnInstanceDisposed);
//                                }
//                            }
//                            break;
//                        case Globals.Globals.SpawnTypes.Access:
//                            // TODO: Fix this to get Spaces with access, not SpaceId
//                            /*var validSpaces = GetSpacesWithAccess(profile.Location.Value);
//                            if (validSpaces.Count == 0)
//                            {
//                                Log.ErrorFormat("Spawn[{0}] found no Spaces with matching access ({1})", ID, profile.Location.Value);
//                                return false;
//                            }

//                            if (NumberSpawned >= profile.MaxQuantity) return false;

//                            ignorePctChance = false;
//                            if (NumberSpawned < profile.MinQuantity)
//                            {
//                                //// spawn right now, no matter the percent chance
//                                diff = profile.MinQuantity - NumberSpawned;
//                                ignorePctChance = true;
//                            }
//                            else
//                            {
//                                //// just get the standard difference
//                                diff = profile.MaxQuantity - profile.MinQuantity;
//                            }

//                            for (var j = 0; j < diff; j++)
//                            {
//                                //// pick a template to spawn
//                                entity = profile.PickTemplate();

//                                // get a Space from the list
//                                var bValidSpace = false;
//                                int count;
//                                var loopCount = 0;

//                                do
//                                {
//                                    if (loopCount > validSpaces.Count)
//                                    {
//                                        Log.ErrorFormat("Spawn[{0}] exceeded max attempts to find a valid Space.", ID);
//                                        return false;
//                                    }

//                                    Space = validSpaces[d.Between(1, validSpaces.Count)];
//                                    if (!_spawnedMap.Contains(Space.ID))
//                                        _spawnedMap[Space.ID] = 0;

//                                    count = (int)_spawnedMap[Space.ID];
//                                    if (count < profile.Location.Density || profile.Location.Density == -1)
//                                        bValidSpace = true;
//                                    loopCount++;

//                                } while (!bValidSpace);

//                                _spawnedMap[Space.ID] = count + 1;
//                                if (ignorePctChance)
//                                    spawnedEntity = SpawnFromTemplate(entity, Space);
//                                else
//                                {
//                                    if (d.D100(1) >= profile.Chance)
//                                        spawnedEntity = SpawnFromTemplate(entity, Space);
//                                }

//                                if (spawnedEntity.IsNotNull())
//                                {
//                                    _spawned.Add(spawnedEntity);
//                                    EventManager.Instance.RegisterListener(this, spawnedEntity, typeof(OnInstanceDisposed), SpawnedEntityOnInstanceDisposed);
//                                }
//                            }*/
//                            break;
//                        default:
//                            Log.ErrorFormat("Spawn[{0}] has no SpawnType assigned.", ID);
//                            return false;
//                    }
//                }
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex);
//                return false;
//            }
//        }

//        private static bool IsItemTemplate(IGameTemplate entity)
//        {
//            return entity is ItemTemplate || entity.Flags.HasFlag("I");
//        }

//        private static bool IsMobTemplate(IGameTemplate entity)
//        {
//            return entity is MobTemplate || entity.Flags.HasFlag("M");
//        }

//        private IGameInstance SpawnFromTemplate(IGameTemplate entity, IGameEntity Space)
//        {
//            if (entity.IsNull() || Space.IsNull()) return null;

//            try
//            {
//                IGameInstance newInstance;
//                if (IsItemTemplate(entity))
//                {
//                    var template = entity as ItemTemplate;
//                    if (template.IsNull()) return null;

//                    var factory = new GameItemFactory();
//                    var instance = factory.CreateInstance(string.Empty, template) as ItemInstance;
//                    if (!Space.Contents.AddEntity(instance))
//                    {
//                        Log.ErrorFormat("Error adding entity[{0}] to Space[{1}]", instance.ID, Space.ID);
//                        return null;
//                    }

//                    Game.SetManagerReferences(instance);

//                    Log.InfoFormat("Spawn[{0}] is spawning item[{1}, {2}] into Space[{3}]", ID, instance.ID, instance.Name, Space.ID);
//                    AddMessage(string.Format("Item[{0}, {1}] spawned at Space[{2}]", instance.ID, instance.Name, Space.ID));
//                    newInstance = instance;
//                }
//                else
//                {
//                    var template = entity as MobTemplate;
//                    if (template.IsNull()) return null;

//                    var factory = new GameMobileFactory();
//                    var instance = factory.CreateInstance(string.Empty, template) as MobInstance;
//                    if (!Space.Contents.AddEntity(instance))
//                    {
//                        Log.ErrorFormat("Error adding entity[{0}] to Space[{1}]", instance.ID, Space.ID);
//                        return null;
//                    }

//                    Game.SetManagerReferences(instance);

//                    var location = Space.Location as Zone;
//                    if (location.IsNull()) return null;
//                    location.AiContext.Register(instance.CastAs<IRegularMob>().AiBrain);

//                    Log.InfoFormat("Spawn[{0}] is spawning mob[{1}, {2}] into Space[{3}]", ID, instance.ID, instance.Name, Space.ID);
//                    AddMessage(string.Format("Mob[{0}, {1}] spawned at Space[{2}]", instance.ID, instance.Name, Space.ID));
//                    newInstance = instance;

//                    var mob = newInstance as MobInstance;
//                    EventManager.ThrowEvent(this, new OnMobSpawn("OnMobSpawn"), new EventTable { { "mob", mob } });
//                }

//                return newInstance;
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex);
//                return null;
//            }
//        }

//        private List<Space> GetSpacesWithAccess(int access)
//        {
//            var z = Location as Zone;
//            if (z.IsNull())
//                return new List<Space>();
//            var zoneEntities = z.Contents.Entities;
//            return (from entity in zoneEntities.OfType<Space>() select entity into Space let value = access & Space.Access where value > 0 select Space).ToList();
//        }

//        #region Events
//        void SpawnOnZonePop(RealmEventArgs e)
//        {
//            if (Execute())
//                Log.InfoFormat("Spawn[{0}] handled ZonePop event.", ID);
//        }
//        void SpawnedEntityOnInstanceDisposed(RealmEventArgs e)
//        {
//            var instance = e.Sender as IGameInstance;
//            if (instance.IsNull()) return;

//            if (_spawned.Contains(instance))
//            {
//                _spawned.Remove(instance);
//                if (_spawnedMap.ContainsKey(instance.Location.ID))
//                    _spawnedMap[instance.Location.ID] = (int)_spawnedMap[instance.Location.ID] - 1;
//            }
//        }
//        #endregion
//    }
//}
