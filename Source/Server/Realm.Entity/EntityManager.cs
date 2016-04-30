using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ninject;
using Realm.Entity.Interfaces;
using Realm.Entity.Properties;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public sealed class EntityManager : GameSingleton, IEntityManager
    {
        private readonly EntityRecycler _recycler;
        private readonly IEntityRepository _repository;
        private readonly EntityLoader _loader;
        private readonly EntityFactory _factory;
        private BooleanSet _startupSet;
        public IEntityInitializer EntityInitializer { get; private set; }

        public EntityManager(IEntityRecycler entityRecycler, 
            IEntityLoader entityLoader, IEntityRepository entityRepository, IEntityFactory entityFactory)
        {
            _loader = (EntityLoader)entityLoader;
            _recycler = (EntityRecycler)entityRecycler;
            _repository = entityRepository;
            _factory = (EntityFactory)entityFactory;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        /// <summary>
        ///
        /// </summary>
        ~EntityManager()
        {
            _recycler.Dispose();
            _loader.Dispose();
            _factory.Dispose();
        }

        /// <summary>
        ///
        /// </summary>
        public DictionaryAtom InitializationAtom { get; private set; }

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="initAtom"></param>
        /// <param name="entityInitializer"></param>
        public void OnInit(DictionaryAtom initAtom, IEntityInitializer entityInitializer)
        {
            EntityInitializer = entityInitializer;
            InitializationAtom = initAtom;

            var recycleFrequency = initAtom.GetInt("RecycleFrequency");
            Validation.Validate<ArgumentOutOfRangeException>(recycleFrequency > 0);
            Log.DebugFormat("EntityManager initialized with Recycle Frequency of {0}", recycleFrequency);

            _recycler.Timer.Interval = recycleFrequency;

            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        /// <summary>
        /// Initialization event
        /// </summary>
        /// <param name="args"></param>
        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("EntityManager loading startup entities.");
            _loader.LoadStartupEntities(OnStartupEntitiesLoaded);
        }

        /// <summary>
        /// Callback function from the EntityLoader
        /// </summary>
        /// <param name="args"></param>
        private void OnStartupEntitiesLoaded(RealmEventArgs args)
        {
            var zoneList = args.Data["zones"].CastAs<List<int>>();
            if (zoneList.IsNull())
                throw new InvalidDataException(Resources.ERR_NO_STARTUP_ZONES);

            Log.DebugFormat("{0} Zones to be loaded at startup.", zoneList.Count);

            _startupSet = new BooleanSet("StartupSet", OnStartupLoadingComplete);
            EntityInitializer.LoadStartupEntities(_startupSet, zoneList);
        }

        /// <summary>
        /// Completes the loading of startup data and the entity cascade
        /// </summary>
        /// <param name="args"></param>
        private void OnStartupLoadingComplete(RealmEventArgs args)
        {
            Log.Debug("Startup Entities have been loaded.");

            args.Data["BooleanSet"] = _startupSet;
            base.Instance_OnGameInitialize(args);
        }

        #region Entity Factory

        /// <summary>
        ///
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Create(IHelper<Type> helper, string type, params object[] args)
        {
            return _factory.Create(helper, type, args);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Create(Type type, params object[] args)
        {
            return _factory.Create(type, args);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Create<T>(params object[] args) where T : IEntity
        {
            return _factory.Create<T>(args);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Clone<T>(T source, params object[] args) where T : IEntity
        {
            return _factory.Clone(source, args);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Register(Type type)
        {
            return _factory.Register(type);
        }

        #endregion Entity Factory

        #region Entity Recycler

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool RecycleEntity(IGameEntity entity)
        {
            return _recycler.RecycleEntity(entity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool SaveRecycledEntity(IGameEntity entity, IGameEntity location)
        {
            return _recycler.SaveRecycledEntity(entity, location);
        }

        #endregion Entity Recycler

        #region Entity Repository

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(long key, IGameEntity entity)
        {
            return _repository.Add(key, entity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteEntity(long key)
        {
            return _repository.Delete(key);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsEntity(long key)
        {
            return _repository.Contains(key);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IGameEntity GetEntity(long key)
        {
            return _repository.Get(key).CastAs<IGameEntity>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<IGameEntity> GetEntityByDefinitionId(long id)
        {
            return _repository.Values.OfType<IGameEntity>()
                .Where(x => x.Definition.ID == id)
                .Select(entity => entity.CastAs<IGameEntity>()).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        public void ClearEntities()
        {
            _repository.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        public int EntityCount => _repository.Count;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<long> GetEntityKeys()
        {
            return _repository.Keys;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGameEntity> GetEntities()
        {
            return _repository.Values.Select(value => value.CastAs<IGameEntity>()).ToList();
        }

        #endregion Entity Repository
    }
}