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
    public class RitualLoader : Loader<RitualDef>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"> </param>
        public RitualLoader([Named("StaticDataLoader")]IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, string schema, ILogWrapper log)
            : base(owner, loadBalancer, staticDataRepository, log, schema, Globals.Globals.SystemTypes.Ritual)
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
                                   {"game_GetRituals", ""},
                                   {"game_GetRitualEffects", "Effects"},
                                   {"game_GetRitualParticipants", "Participants"},
                                   {"game_GetRitualReagants", "Reagants"},
                                   {"game_GetRitualRequirements", "Requirements"}
                               };

            return BuildAndExecuteTransaction(boolSet, commands);
        }
    }
}