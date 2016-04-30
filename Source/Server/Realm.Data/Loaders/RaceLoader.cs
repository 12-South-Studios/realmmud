using System.Collections.Generic;
using Ninject;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Database.Framework;

namespace Realm.Data.Loaders
{
    /// <summary>
    ///
    /// </summary>
    public class RaceLoader : Loader<RaceDef>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"> </param>
        public RaceLoader([Named("StaticDataLoader")]IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, string schema, ILogWrapper log)
            : base(owner, loadBalancer, staticDataRepository, log, schema, Globals.SystemTypes.Race)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="boolSet"></param>
        /// <returns></returns>
        public override bool Load(BooleanSet boolSet)
        {
            var commands = new Dictionary<string, string>
                               {
                                   {"game_GetRaces", ""},
                                   {"game_GetRaceAbilities", "Abilities"},
                                   {"game_GetRaceHitLocations", "HitLocations"},
                                   {"game_GetRaceStatistics", "Statistics"}
                               };

            return BuildAndExecuteTransaction(boolSet, commands);
        }
    }
}