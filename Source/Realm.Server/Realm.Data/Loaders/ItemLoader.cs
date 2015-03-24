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
    public class ItemLoader : Loader<ItemDef>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"> </param>
        public ItemLoader([Named("StaticDataLoader")]IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, string schema, ILogWrapper log)
            : base(owner, loadBalancer, staticDataRepository, log, schema, Globals.Globals.SystemTypes.Item)
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
                                   {"game_GetItems", ""},
                                   {"game_GetItemBooks", "Books"},
                                   {"game_GetItemContainers", "Containers"},
                                   {"game_GetItemDrinkContainers", "DrinkContainers"},
                                   {"game_GetItemFoods", "Foods"},
                                   {"game_GetItemFormulaResources", "FormulaResources"},
                                   {"game_GetItemFormulas", "Formulas"},
                                   {"game_GetItemFurnitures", "Furnitures"},
                                   {"game_GetItemLights", "Lights"},
                                   {"game_GetItemLocks", "Locks"},
                                   {"game_GetItemMachines", "Machines"},
                                   {"game_GetItemMagicalNodes", "MagicalNodes"},
                                   {"game_GetItemMudProgs", "MudProgs"},
                                   {"game_GetItemPortals", "Portals"},
                                   {"game_GetItemPotions", "Potions"},
                                   {"game_GetItemPrerequisites", "Prerequisites"},
                                   {"game_GetItemResourceNodes", "ResourceNodes"},
                                   {"game_GetItemStatistics", "Statistics"},
                                   {"game_GetItemTools", "Tools"},
                                   {"game_GetItemTraps", "Traps"},
                                   {"game_GetItemTreasures", "Treasures"},
                                   {"game_GetItemVehicles", "Vehicles"},
                                   {"game_GetItemVehicleTerrains", "VehicleTerrains"},
                                   {"game_GetItemWeapons", "Weapons"},
                                   {"game_GetItemWearLocations", "WearLocations"}
                               };

            return BuildAndExecuteTransaction(boolSet, commands);
        }
    }
}