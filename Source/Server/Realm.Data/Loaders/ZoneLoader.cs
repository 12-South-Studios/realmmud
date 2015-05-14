using System.Collections.Generic;
using Ninject;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Logging;
using Realm.Library.Database.Framework;

namespace Realm.Data.Loaders
{
    /// <summary>
    ///
    /// </summary>
    public class ZoneLoader : Loader<ZoneDef>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"> </param>
        public ZoneLoader([Named("StaticDataLoader")]IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, string schema, ILogWrapper log)
            : base(owner, loadBalancer, staticDataRepository, log, schema, Globals.Globals.SystemTypes.Zone)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="boolSet"></param>
        /// <returns></returns>
        public override bool Load(BooleanSet boolSet)
        {
            return BuildAndExecuteTransaction(boolSet, new Dictionary<string, string>
                {
                    {"game_GetZones", ""},
                    {"game_GetZoneAccesses", "Accesses"},
                    {"game_GetZoneDynamics", "Dynamics"},
                    {"game_GetZoneResets", "Resetss"},
                    {"game_GetZoneSpaces", "Spaces"},
                    {"game_GetZoneSpawns", "Spawns"}
                });
        }
    }
}