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
    public class GameCommandLoader : Loader<GameCommandDef>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"> </param>
        public GameCommandLoader([Named("StaticDataLoader")]IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, string schema, ILogWrapper log)
            : base(owner, loadBalancer, staticDataRepository, log, schema, Globals.SystemTypes.GameCommand)
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
                    {"game_GetGameCommands", ""},
                    {"game_GetGameCommandPositions", "Positions"},
                    {"game_GetGameCommandUserStates", "UserStates"}
                });
        }
    }
}