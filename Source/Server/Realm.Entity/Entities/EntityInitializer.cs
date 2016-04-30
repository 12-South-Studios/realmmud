using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Ninject;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Entity.Events;
using Realm.Entity.Interfaces;
using Realm.Entity.Properties;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class EntityInitializer : IEntityInitializer
    {
        private readonly IEntityManager _entityManager;
        private readonly IStaticDataManager _staticDataManager;
        private DictionaryAtom _initAtom;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityManager"></param>
        /// <param name="staticDataManager"></param>
        public EntityInitializer(IEntityManager entityManager, IStaticDataManager staticDataManager)
        {
            _entityManager = entityManager;
            _staticDataManager = staticDataManager;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            _initAtom = initAtom;
        }

        /// <summary>
        ///
        /// </summary>
        public void RegisterEntityTypes(IEnumerable<Type> typesToInitialize)
        {
            typesToInitialize.ToList().ForEach(type => _entityManager.Register(type));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="startupSet"></param>
        /// <param name="zoneList"></param>
        public void LoadStartupEntities(BooleanSet startupSet, IEnumerable<int> zoneList)
        {
            Log.DebugFormat("Beginning to load {0} startup entities.", zoneList.Count());

            Validation.IsNotNull(zoneList, "zoneList");

            var count = 0;
            zoneList.ToList().ForEach(id =>
                {
                    var def = _staticDataManager.GetStaticData(Globals.SystemTypes.Zone.GetValue(),
                                                               id.ToString(CultureInfo.InvariantCulture));
                    if (def.IsNull())
                        throw new InvalidDataException(string.Format(Resources.ERR_ZONE_DEF_NOT_FOUND, id));

                    var zoneDef = def.CastAs<ZoneDef>();
                    if (zoneDef.IsNull())
                        throw new InvalidDataException(string.Format(Resources.ERR_DEF_WAS_NOT_ZONE_DEF, id));
                    Log.DebugFormat("Zone Definition {0} loaded.", zoneDef.ID);

                    var obj = _entityManager.Create<Zone>(id, zoneDef.Name, zoneDef);
                    if (obj.IsNull())
                        throw new InstantiationException(Resources.ERR_FAILURE_INSTANTIATE, typeof(Zone), id,
                                                         zoneDef.ID);

                    Log.DebugFormat("Zone {0} loaded.", id);
                    startupSet.AddItem($"Zone{id}");
                    obj.OnInit(_initAtom);
                    count++;
                });

            Log.InfoFormat(Resources.MSG_ZONE_STARTUP, count);
            EventManager.ThrowEvent<OnStartupEntitiesLoaded>(this, new EventTable { { "BooleanSet", startupSet } });
        }
    }
}