using System.Globalization;
using System.IO;
using System.Linq;
using System.Timers;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity.Events;
using Realm.Entity.Resets;
using Realm.Event.EventTypes.ZoneEvents;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

namespace Realm.Entity.Entities
{
    /// <summary>
    /// Class that handles Zone objects
    /// </summary>
    public class Zone : GameEntity
    {
        private readonly ITimer _timer;
        private BooleanSet _loadingSet;
        private BooleanSet _startupSet;
        private ResetRepository _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Zone(long id, string name, Definition def)
            : base(id, name, def)
        {
            _timer = new CommonTimer();
            _timer.Elapsed += ResetTimerElapsed;
        }

        /// <summary>
        /// Dispose of any internal resources
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_timer.IsNotNull())
                    _timer.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///
        /// </summary>
        public ZoneDef ZoneDef => Definition.CastAs<ZoneDef>();

        /// <summary>
        ///
        /// </summary>
        public new void OnInit(DictionaryAtom initAtom)
        {
            base.OnInit(initAtom);

            _timer.Interval = ZoneDef.RecycleTime;

            EventManager.RegisterListener(this, typeof(OnStartupEntitiesLoaded), OnInitComplete);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        private void OnInitComplete(RealmEventArgs args)
        {
            var booleanSet = args.GetValue("BooleanSet").CastAs<BooleanSet>();
            if (booleanSet.IsNull())
                throw new InvalidDataException("BooleanSet not found");

            _startupSet = booleanSet;
            _loadingSet = new BooleanSet("LoadingSet", OnSpaceLoadingComplete);

            var count = LoadSpaces(ZoneDef);
            if (count <= 0)
                throw new InitializationException("Failed to load Spaces for Zone {0}", ID);
            Logger.InfoFormat("{0} spaces instantiated for Zone {1}.", count, ID);

            count = LoadResets(ZoneDef);
            if (count <= 0)
                throw new InitializationException("Failed to load Resets for Zone {0}", ID);
            Logger.InfoFormat("{0} resets instantiated for Zone {1}.", count, ID);

            EventManager.ThrowEvent<OnStartupEntitiesInitiated>(this, new EventTable { { "BooleanSet", _loadingSet } });
        }

        /// <summary>
        /// Loads the spaces for this zone
        /// </summary>
        /// <param name="zoneDef"></param>
        /// <returns></returns>
        private int LoadSpaces(ZoneDef zoneDef)
        {
            var count = 0;
            zoneDef.Spaces.OfType<DictionaryAtom>().ToList().ForEach(space =>
                {
                    var id = space.GetInt("ID");
                    var def = StaticDataManager.GetStaticData(Globals.SystemTypes.Space.GetValue(),
                                                              id.ToString(CultureInfo.InvariantCulture));
                    if (def.IsNull())
                        throw new InvalidDataException($"Definition for Space {id} not found.");

                    var spaceDef = def.CastAs<SpaceDef>();
                    if (spaceDef.IsNull())
                        throw new InvalidDataException($"Definition file {id} was not a SpaceDef file.");

                    var obj = EntityManager.Create<Space>(id, spaceDef.Name, spaceDef);
                    if (obj.IsNull())
                        throw new InstantiationException("Space {0} could not be instantiated.", id);

                    _loadingSet.AddItem($"Space{obj.ID}");
                    obj.OnInit(InitializationAtom);
                    count++;
                });

            return count;
        }

        /// <summary>
        /// Loads the resets for this zone
        /// </summary>
        /// <param name="zoneDef"></param>
        /// <returns></returns>
        private int LoadResets(ZoneDef zoneDef)
        {
            _repository = new ResetRepository();

            var count = 0;
            zoneDef.Resets.OfType<DictionaryAtom>().ToList().ForEach(reset =>
                {
                    var id = reset.GetInt("ID");

                    var def = StaticDataManager.GetStaticData(Globals.SystemTypes.Reset.GetValue(),
                                                              id.ToString(CultureInfo.InvariantCulture));
                    if (def.IsNull())
                        throw new InvalidDataException($"Definition for Reset {id} not found.");

                    var resetDef = def.CastAs<ResetDef>();
                    if (resetDef.IsNull())
                        throw new InvalidDataException($"Definition file {id} was not a ResetDef file.");
                    var obj = EntityManager.Create(new ResetFactoryHelper(), resetDef.ResetType.ToString(), id, resetDef.Name, resetDef);
                    if (obj.IsNull())
                        throw new InstantiationException("Reset {0} {1} could not be instantiated.", resetDef.ResetType,
                                                         id);

                    var newReset = obj.CastAs<Reset>();
                    newReset.OnInit(this, InitializationAtom);
                    _repository.Add(newReset.ID, newReset);
                    count++;
                });

            return count;
        }

        /// <summary>
        /// Callback function when all entities this Zone instantiates are loaded
        /// </summary>
        /// <param name="args"></param>
        private void OnSpaceLoadingComplete(RealmEventArgs args)
        {
            _startupSet.CompleteItem($"Zone{ID}");
        }

        /// <summary>
        /// Fires the OnZonePop event on each pulse of the timer
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void ResetTimerElapsed(object o, ElapsedEventArgs e)
        {
            EventManager.ThrowEvent<OnZonePop>(this, null);
        }

        /*private readonly List<AccessLevel> _accessLevels;
        private ITimer _resetTimer;

        #region GameEntityConcrete

        public override void OnInit()
        {
            base.OnInit();

            Effects = new EffectsHandler(Game, EntityManager, Log, this);

            AiContext = new AiAgentContext(new RealmTimer(),
                Game.GetIntConstant("aiBuckets").GetValueOrDefault(10),
                Game.GetIntConstant("aiProcessFrequency").GetValueOrDefault(200));

            Resets = new ResetRepository();

            var flag = (Flag)DataManager.Get("Flags", "zone");
            if (flag.IsNull())
            {
                Log.ErrorFormat("Flag {0} does not exist.", "Zone");
                return;
            }

            Flags.SetFlag(flag.Abbrev);
            EventManager.RegisterListener(this, this, typeof(OnZoneEnter), Zone_OnZoneEnter);
            EventManager.RegisterListener(this, this, typeof(OnZoneLeave), Zone_OnZoneLeave);
            EventManager.RegisterListener(this, Game, typeof(OnGameRound), Instance_OnGameRound);
            EventManager.RegisterListener(this, Game, typeof(OnGameStart), Instance_OnGameStartup);
            EventManager.RegisterListener(this, Game, typeof(OnGameStop), Instance_OnGameStop);
            Game.OnServerStatusChanged += Instance_OnServerStatusChanged;
        }

        new public Zone MyZone { get { return this; } }

        #endregion GameEntityConcrete

        #region IZoneDef

        public int RecycleTime
        {
            get { return Properties.GetProperty<int>("RecycleTime"); }
            set
            {
                Properties.SetProperty("RecycleTime", value);
                if (_resetTimer.IsNotNull())
                    _resetTimer.Stop();

                if (value <= 0) return;
                _resetTimer = new RealmTimer { Interval = Convert.ToDouble(value) };
                _resetTimer.Elapsed += ResetTimerElapsed;
            }
        }
        public bool IsDynamic
        {
            get { return Properties.GetProperty<bool>("IsDynamic"); }
            set { Properties.SetProperty("IsDynamic", value); }
        }
        public bool SpellCanClose
        {
            get { return Properties.GetProperty<bool>("SpellCanClose"); }
            set { Properties.SetProperty("SpellCanClose", value); }
        }
        public bool BossDeathCanClose
        {
            get { return Properties.GetProperty<bool>("BossDeathCanClose"); }
            set { Properties.SetProperty("BossDeathCanClose", value); }
        }
        public bool RefreshPortals
        {
            get { return Properties.GetProperty<bool>("RefreshPortals"); }
            set { Properties.SetProperty("RefreshPortals", value); }
        }
        public int MaxDynamicZones
        {
            get { return Properties.GetProperty<int>("MaxDynamicZones"); }
            set { Properties.SetProperty("MaxDynamicZones", value); }
        }
        public int MinDynamicZoneFrequency
        {
            get { return Properties.GetProperty<int>("MinDynamicZoneFrequency"); }
            set { Properties.SetProperty("MinDynamicZoneFrequency", value); }
        }
        public int TagSet
        {
            get { return Properties.GetProperty<int>("TagSet"); }
            set { Properties.SetProperty("TagSet", value); }
        }
        public IEnumerable<AccessLevel> AccessLevels
        {
            get { return _accessLevels; }
        }
        public IList<Space> Spaces
        {
            get { return Contents.Entities.OfType<Space>().ToList(); }
        }

        #endregion IZoneDef

        #region IZone

        public int UserCount
        {
            get { return Game.UserRepository.Values.Count(user => user.Characters.Character.MyZone == this); }
        }
        public ResetRepository Resets { get; private set; }
        public AiAgentContext AiContext { get; private set; }
        public EffectsHandler Effects { get; private set; }
        public Graph Graph { get; private set; }

        #endregion IZone

        public IList<Space> GetSpacesByAccess(int access)
        {
            return Contents.Entities.OfType<Space>().Select(entity => entity).Where(Space => (access & Space.Access) != 0).ToList();
        }

        private void AddAccessLevel(string name, int value)
        {
            var level = new AccessLevel(name, value);
            if (_accessLevels.Contains(level)) return;
            _accessLevels.Add(level);
            Log.InfoFormat("Zone[{0}, {1}] added AccessLevel[{2}]", ID, Name, name);
        }
        private void AddAccessLevel(AccessLevel level)
        {
            if (_accessLevels.Contains(level)) return;
            _accessLevels.Add(level);
            Log.InfoFormat("Zone[{0}, {1}] added AccessLevel[{2}]", ID, Name, level.Name);
        }

        #region Events

        void Instance_OnGameStartup(RealmEventArgs e)
        {
            Graph = PathManager.BuildGraph(this);
            Log.InfoFormat("Zone[{0}, {1}] -> Processing {2} resets.", ID, Name, Resets.Count);
            foreach (var reset in Resets.Values)
                reset.Process();
        }
        void Instance_OnGameStop(RealmEventArgs e)
        {
            if (_resetTimer.IsNotNull())
                _resetTimer.Stop();
            AiContext.SleepMobs();
        }
        void Zone_OnZoneEnter(RealmEventArgs e)
        {
            var biote = e.Sender as Biota;
            if (biote.IsNull()) return;

            if (!Contents.Contains(biote))
            {
                Contents.AddEntity(biote);

                if (Contents.Count > 1)
                    AiContext.WakeMobs();
            }
        }
        void Zone_OnZoneLeave(RealmEventArgs e)
        {
            var biote = e.Sender as Biota;
            if (biote.IsNull()) return;

            if (Contents.Contains(biote))
            {
                Contents.RemoveEntity(biote);

                if (Contents.Count <= 0)
                    AiContext.SleepMobs();
            }
        }
        private void ResetTimerElapsed(object o, ElapsedEventArgs e)
        {
            EventManager.ThrowEvent(this, new OnZonePop("OnZonePop"));
            Game.Properties.SetProperty("last zone", this);

            Log.InfoFormat("Zone[{0}, {1}] processing {2} resets.", ID, Name, Resets.Count);
            foreach (var reset in Resets.Values)
                reset.Process();
        }
        void Instance_OnServerStatusChanged(object sender, NetworkEventArgs e)
        {
            if (e.ServerStatus == TcpServerStatus.Starting || e.ServerStatus == TcpServerStatus.Listening)
            {
                if (RecycleTime > 0 && _resetTimer.IsNotNull())
                    _resetTimer.Start(_resetTimer.Interval);
                AiContext.Pause = true;
            }
            else
            {
                if (_resetTimer.IsNotNull())
                    _resetTimer.Stop();
                AiContext.Pause = false;
            }
        }
        void Instance_OnGameRound(RealmEventArgs e)
        {
            var deleteList = new List<EffectInstance>();
            foreach (var augment in Effects.Entities.OfType<EffectInstance>().Select(entity => entity))
            {
                augment.OnGameTick();
                if (augment.TimeLeft > 0) continue;
                deleteList.Add(augment);

                var table = new EventTable { { "effect", augment } };
                EventManager.ThrowEvent(this, new OnEffectExpire("OnEffectExpire"), table);
            }
            if (deleteList.Count <= 0) return;

            foreach (var t in deleteList)
                EntityManager.RecycleEntity(t);
            deleteList.Clear();
        }

        #endregion Events*/
    }
}