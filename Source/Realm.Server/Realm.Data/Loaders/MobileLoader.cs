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
    public class MobileLoader : Loader<MobileDef>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"> </param>
        public MobileLoader([Named("StaticDataLoader")]IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, string schema, ILogWrapper log)
            : base(owner, loadBalancer, staticDataRepository, log, schema, Globals.Globals.SystemTypes.Mobile)
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
                                   {"game_GetMobiles", ""},
                                   {"game_GetMobileAbilities", "Abilities"},
                                   {"game_GetMobileEquipment", "Equipment"},
                                   {"game_GetMobileMudProgs", "MudProgs"},
                                   {"game_GetMobileRegular", "Regular"},
                                   {"game_GetMobileResources", "Resources"},
                                   {"game_GetMobileStatistics", "Statistics"},
                                   {"game_GetMobileTreasures", "Treasures"},
                                   {"game_GetMobileTreasureTables", "TreasureTables"},
                                   {"game_GetMobileVendor", "Vendor"}
                               };

            return BuildAndExecuteTransaction(boolSet, commands);
        }
    }
}