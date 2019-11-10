using System.Collections.Generic;
using System.Linq;
using Ninject;
using Realm.Data;
using Realm.Data.Interfaces;
using Realm.Entity.Entities;
using Realm.Entity.Interfaces;
using Realm.Event;
using Realm.Library.Common.Caching;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Pathing.Core;
using Realm.Pathing.Interfaces;

namespace Realm.Pathing
{
    /// <summary>
    ///
    /// </summary>
    public sealed class PathManager : GameSingleton, IPathManager
    {
        private CachedObjectRepository<KeyValuePair<long, long>, Path> _pathRepository;
        private readonly GraphRepository _graphRepository;

        private StaticDataRepository _staticDataRepository;
        private BooleanSet _startupSet;
        private PathBuilder _pathBuilder;

        public PathManager(IStaticDataRepository staticDataRepository, IGraphRepository graphRepository)
        {
            _staticDataRepository = (StaticDataRepository)staticDataRepository;
            _graphRepository = (GraphRepository)graphRepository;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        [Inject]
        public IDatabaseManager DatabaseManager { get; set; }

        [Inject]
        public IEntityManager EntityManager { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int MaxMobileMovementCost { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            var cacheDuration = initAtom.GetInt("PathCacheDuration");
            MaxMobileMovementCost = initAtom.GetInt("MaxMobileMovementCost");

            _pathRepository = new CachedObjectRepository<KeyValuePair<long, long>, Path>(cacheDuration);
            _pathBuilder = new PathBuilder(initAtom, EntityManager);

            Log.DebugFormat("PathManager initialized with PathCacheDuration of {0} and MaxMobileMovementCost of {1}",
                             cacheDuration, MaxMobileMovementCost);

            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        #region Graph Repository

        public bool RegisterGraph(Zone zone, Graph graph)
        {
            return _graphRepository.Add(zone.ID, graph);
        }

        public Graph GetGraph(long id)
        {
            return _graphRepository.Get(id);
        }

        public bool HasGraph(long id)
        {
            return _graphRepository.Contains(id);
        }

        #endregion Graph Repository

        public Path GetPath(long sourceId, long targetId)
        {
            var path = GetCachedPath(sourceId, targetId);
            return path ?? _pathBuilder.GeneratePath(sourceId, targetId);
        }

        private Path GetCachedPath(long sourceId, long targetId)
        {
            return _pathRepository.Keys.Where(keyValuePair => keyValuePair.Key == sourceId
                                                              && keyValuePair.Value == targetId)
                .Select(keyValuePair => _pathRepository.Get(keyValuePair)).FirstOrDefault();
        }
    }
}