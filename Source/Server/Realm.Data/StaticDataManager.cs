using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Data.Loaders;
using Realm.Data.Properties;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Database.Framework;

namespace Realm.Data
{
    /// <summary>
    ///
    /// </summary>
    public sealed class StaticDataManager : GameSingleton, IStaticDataManager
    {
        private readonly StaticDataRepository _staticDataRepository;
        private readonly StaticDataLoader _loader;
        private readonly LoaderRepository _loaderRepository;
        private BooleanSet _loadingSet;
        private BooleanSet _startupSet;
        private Dictionary<Globals.Globals.SystemTypes, Type> _loaders;

        public StaticDataManager(IStaticDataLoader staticDataLoader, ILoaderRepository loaderRepository, 
            IStaticDataRepository staticDataRepository)
        {
            _loader = (StaticDataLoader) staticDataLoader;
            _loaderRepository = (LoaderRepository) loaderRepository;
            _staticDataRepository = (StaticDataRepository) staticDataRepository;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        [Inject]
        public IDatabaseManager DatabaseManager { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            Log.DebugFormat("{0} setup.", GetType());
            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            try
            {
                _startupSet = args.GetValue("BooleanSet").CastAs<BooleanSet>();
                RegisterLoaders();
                Log.DebugFormat("{0} StaticData Loaders registered.", _loaders.Count);

                SetupLoaders();
                Log.DebugFormat("{0} created and set up.", _loaderRepository.Count);

                _loadingSet = new BooleanSet("StaticDataLoading", OnStaticDataLoaded);
                _loadingSet.AddItem("StaticDataLoader");
                _loader.Load(_loadingSet);
            }
            catch(Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordOnly, Log);
                throw new InitializationException(Resources.ERR_FAIL_INITIALIZE_MANAGER, GetType());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        private void OnStaticDataLoaded(RealmEventArgs args)
        {
            Log.DebugFormat("Static Data Types Loaded: {0}", _staticDataRepository.Count);

            _loadingSet = null;
            args.Data["BooleanSet"] = _startupSet;
            base.Instance_OnGameInitialize(args);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Dictionary<string, Definition> GetStaticData(Globals.Globals.SystemTypes category)
        {
            return GetStaticData(category.GetValue());
        }

        /// <summary>
        /// Retrieves all static data by category, indexed by Id
        /// </summary>
        public Dictionary<string, Definition> GetStaticData(int category)
        {
            return _staticDataRepository.Contains(category) ? _staticDataRepository.Get(category) : null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <param name="dataId"></param>
        /// <returns></returns>
        public Definition GetStaticData(Globals.Globals.SystemTypes category, string dataId)
        {
            return GetStaticData(category.GetValue(), dataId);
        }

        /// <summary>
        /// Retrieves a specific object's data from the static data by category and Id
        /// </summary>
        public Definition GetStaticData(int category, string dataId)
        {
            return _staticDataRepository.Contains(category)
                       ? _staticDataRepository.GetSubtype(category, dataId)
                       : null;
        }

        /// <summary>
        /// Sets up a dictionary of loaders
        /// </summary>
        private void RegisterLoaders()
        {
            _loaders = new Dictionary<Globals.Globals.SystemTypes, Type>
                          {
                              {Globals.Globals.SystemTypes.Ability, typeof (AbilityLoader)},
                              {Globals.Globals.SystemTypes.Archetype, typeof (ArchetypeLoader)},
                              {Globals.Globals.SystemTypes.Barrier, typeof (BarrierLoader)},
                              {Globals.Globals.SystemTypes.Behavior, typeof (BehaviorLoader)},
                              {Globals.Globals.SystemTypes.Channel, typeof (ChannelLoader)},
                              {Globals.Globals.SystemTypes.Effect, typeof(EffectLoader)},
                              {Globals.Globals.SystemTypes.Faction, typeof(FactionLoader)},
                              {Globals.Globals.SystemTypes.GameCommand, typeof(GameCommandLoader)},
                              {Globals.Globals.SystemTypes.HelpLookup, typeof (HelpLoader)},
                              {Globals.Globals.SystemTypes.Item, typeof(ItemLoader)},
                              {Globals.Globals.SystemTypes.ItemSet, typeof(ItemSetLoader)},
                              {Globals.Globals.SystemTypes.Liquid, typeof (LiquidLoader)},
                              {Globals.Globals.SystemTypes.Mobile, typeof (MobileLoader)},
                              {Globals.Globals.SystemTypes.Month, typeof(MonthLoader)},
                              {Globals.Globals.SystemTypes.MudProg, typeof (MudProgLoader)},
                              {Globals.Globals.SystemTypes.Quest, typeof(QuestLoader)},
                              {Globals.Globals.SystemTypes.Race, typeof(RaceLoader)},
                              {Globals.Globals.SystemTypes.Reset, typeof (ResetLoader)},
                              {Globals.Globals.SystemTypes.Ritual, typeof(RitualLoader)},
                              {Globals.Globals.SystemTypes.Shop, typeof(ShopLoader)},
                              {Globals.Globals.SystemTypes.SkillCategory, typeof (SkillCategoryLoader)},
                              {Globals.Globals.SystemTypes.Skill, typeof (SkillLoader)},
                              {Globals.Globals.SystemTypes.Social, typeof (SocialLoader)},
                              {Globals.Globals.SystemTypes.Space, typeof (SpaceLoader)},
                              {Globals.Globals.SystemTypes.Spawn, typeof(SpawnLoader)},
                              {Globals.Globals.SystemTypes.Terrain, typeof (TerrainLoader)},
                              {Globals.Globals.SystemTypes.Treasure, typeof(TreasureLoader)},
                              {Globals.Globals.SystemTypes.Zone, typeof (ZoneLoader)}
                          };
        }

        /// <summary>
        /// Helper function to create a loader based on the given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ILoader CreateLoader(Type type)
        {
            var parameters = new object[]
                                 {
                                     _loader, DatabaseManager as IDatabaseLoadBalancer,
                                     _staticDataRepository, "dbo", Log
                                 };
            return (ILoader)Activator.CreateInstance(type, parameters);
        }

        /// <summary>
        /// Sets up the loaders that have been registered
        /// </summary>
        private void SetupLoaders()
        {
            _loaders.Keys.ToList().ForEach(key => _loaderRepository.Add(key.GetValue(), CreateLoader(_loaders[key])));
        }
    }
}