//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Management.Instrumentation;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Abilities;
//using Realm.Server.Attributes;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Properties;
//using Realm.Library.Common;

//
//namespace Realm.Server
//
//{
//    /// <summary>
//    /// Extension class that handles functions for Biota
//    /// </summary>
//    public static class BiotaExtensions
//    {
//        #region Skill and Stat Functions

//        public static int CalculateSkill(this IBiota biote, Skill skill)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.StatisticHandler, "biote.StatisticHandler");

//            return biote.StatisticHandler.CalculateSkill(skill.Name);
//        }

//        public static int CalculateStatistic(this IBiota biote, Globals.Globals.Statistics statistic)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.StatisticHandler, "biote.StatisticHandler");

//            return biote.StatisticHandler.CalculateStat(statistic);
//        }

//        #endregion

//        #region Combat Functions

//        public static Globals.Globals.CombatHitResultTypes HitCheck(this IBiota attacker,
//            IBiota defender, AbilityTemplate ability)
//        {
//            Validation.IsNotNull(attacker, "attacker");
//            Validation.IsNotNull(defender, "defender");
//            Validation.IsNotNull(ability, "ability");
//            Validation.Validate<GeneralException>(attacker is IRegularMob || attacker is ICharacter,
//                                              ErrorResources.ERR_BIOTA_NOT_ATTACKABLE, attacker.ID, attacker.Name);
//            Validation.Validate<GeneralException>(defender is IRegularMob || defender is ICharacter,
//                                              ErrorResources.ERR_BIOTA_NOT_ATTACKABLE, defender.ID, defender.Name);

//            //// (Attack Score + 1D100) - (Defense Score) = Result.

//            //// If Result > 0 then process as a potential hit (process dodge, block and parry).  Otherwise its a miss.
//            //// If Result >= 100 then it is considered a Devastating Hit (25 - 50% additional damage).
//            //// If Result >= 10 then it is considered a Glancing Blow (50% normal damage).

//            //// Attack Score is a combined score of Weapon Skill, Stat Bonuses, Weapon Bonuses, and Spell Bonuses.
//            //// Defense Score is a combined score of Armor Bonuses, Defense Skill, Stat Bonuses, and Spell Bonuses.
//            //// Each component that contributes to the score has a maximum value of 50.
//            var attackScore = attacker.CalculateStatistic(ability.OffensiveStat);
//            var defenseScore = defender.CalculateStatistic(ability.DefensiveStat);
//            var result = (attackScore + Library.Common.Random.D100(1)) - defenseScore;

//            if (defender.CheckDodge())
//                return Globals.Globals.CombatHitResultTypes.Dodge;
//            if (defender.CheckParry())
//                return Globals.Globals.CombatHitResultTypes.Parry;
//            if (defender.CheckBlock())
//                return Globals.Globals.CombatHitResultTypes.Block;
//            if (result >= 100)
//                return Globals.Globals.CombatHitResultTypes.Devastate;
//            return result <= 10 ? Globals.Globals.CombatHitResultTypes.Glance : Globals.Globals.CombatHitResultTypes.Hit;
//        }

//        public static bool CheckDodge(this IBiota defender)
//        {
//            Validation.IsNotNull(defender, "defender");
//            Validation.Validate<GeneralException>(defender is IRegularMob || defender is ICharacter,
//                                              ErrorResources.ERR_BIOTA_NOT_ATTACKABLE, defender.ID, defender.Name);
//            Validation.IsNotNull(defender.StatisticHandler, "defender.StatisticHandler");

//            return Library.Common.Random.D100(1) < defender.StatisticHandler.Dodge;
//        }

//        public static bool CheckParry(this IBiota defender)
//        {
//            Validation.IsNotNull(defender, "defender");
//            Validation.Validate<GeneralException>(defender is IRegularMob || defender is ICharacter,
//                                              ErrorResources.ERR_BIOTA_NOT_ATTACKABLE, defender.ID, defender.Name);
//            Validation.IsNotNull(defender.StatisticHandler, "defender.StatisticHandler");

//            float parryRating = defender.StatisticHandler.Parry;
//            var item = defender.GetEquippedItem("wear_hand_right");
//            if (null == item || !item.IsType("weapon")) return false;

//            var weapon = item as WeaponItemInstance;
//            if (weapon.IsNotNull() && !weapon.CanParry) return false;
//            return Library.Common.Random.D100(1) < parryRating;
//        }

//        public static bool CheckBlock(this IBiota defender)
//        {
//            Validation.IsNotNull(defender, "defender");
//            Validation.Validate<GeneralException>(defender is IRegularMob || defender is ICharacter,
//                                              ErrorResources.ERR_BIOTA_NOT_ATTACKABLE, defender.ID, defender.Name);
//            Validation.IsNotNull(defender.StatisticHandler, "defender.StatisticHandler");

//            var blockRating = defender.StatisticHandler.Block;
//            var item = defender.GetEquippedItem("wear_hand_left");
//            if (null == item || !item.IsType("armor")) return false;

//            var shield = item as ArmorItemInstance;
//            if (shield.IsNotNull() && !shield.CanBlock) return false;
//            return Library.Common.Random.D100(1) < blockRating;
//        }

//        public static Globals.Globals.WearLocations GetRandomWearLocation(this IBiota target)
//        {
//            Validation.IsNotNull(target, "target");
//            Validation.Validate<GeneralException>(target is IRegularMob || target is ICharacter,
//                                              ErrorResources.ERR_BIOTA_NOT_ATTACKABLE, target.ID, target.Name);
//            Validation.IsNotNull(target.Race, "target.Race");

//            return Library.Common.Random.D100(1) >= 25 ? target.Race.CommonHitLocation : target.Race.RareHitLocation;
//        }

//        #endregion

//        #region Inventory Functions

//        public static bool IsWearing(this IBiota biote, Globals.Globals.WearLocations wearLocation)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");

//            return biote.Inventory.IsWearing(wearLocation.GetName());  
//        }

//        public static bool IsWearing(this IBiota biote, string wearLocation)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");
//            Validation.IsNotNullOrEmpty(wearLocation, "wearLocation");

//            return biote.Inventory.IsWearing(wearLocation);
//        }

//        public static bool IsWearing(this IBiota biote, GameEntityInstance entityInstance)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");
//            Validation.IsNotNull(entityInstance, "entityInstance");

//            return biote.Inventory.IsWearing(entityInstance);
//        }

//        public static bool IsWearing(this IBiota biote, ItemTemplate template)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");
//            Validation.IsNotNull(template, "template");

//            return biote.Inventory.IsWearing(template);
//        }

//        public static bool IsNaked(this IBiota biote)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");

//            return biote.Inventory.IsNaked;
//        }

//        public static ItemInstance GetEquippedItem(this IBiota biote, string wearLocation)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");
//            Validation.IsNotNullOrEmpty(wearLocation, "wearLocation");

//            return biote.Inventory.GetEquippedItem(wearLocation);
//        }

//        public static ItemInstance GetEquippedItem(this IBiota biote, Globals.Globals.WearLocations wearLocation)
//        {
//            Validation.IsNotNull(biote, "biote");
//            Validation.IsNotNull(biote.Inventory, "biote.Inventory");

//            return biote.Inventory.GetEquippedItem(wearLocation.GetName());
//        }

//        public static IList<ItemInstance> GetEquippedItems(this IBiota biote)
//        {
//            return biote.Inventory.Equipment.Values.ToList();
//        }

//        public static IList<Globals.Globals.WearLocations> GetEquippedWearLocations(this IBiota biote)
//        {
//            return biote.Inventory.Equipment.Keys.ToList();
//        }

//        public static IList<ItemInstance> GetItemFromBackpack(this IBiota biote, ItemTemplate template)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.GetItemFromBackpack(template);
//        }

//        public static ItemInstance GetItemFromBackpack(this IBiota biote, long id)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.GetItemFromBackpack(id);
//        }

//        public static ItemInstance GetItemFromBackpack(this IBiota biote, string name)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.GetItemFromBackpack(name);
//        }

//        public static IList<ItemInstance> GetItems(this IBiota biote, Globals.Globals.ItemTypes aType)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.GetItems(aType);
//        }

//        public static IList<ItemInstance> GetItems(this IBiota biote)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.Items;
//        }

//        public static bool Contains(this IBiota biote, ItemInstance aEntity)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.Contains(aEntity);
//        }

//        public static bool Contains(this IBiota biote, long aId)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.Contains(aId);
//        }

//        public static bool Contains(this IBiota biote, string aName)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.Contains(aName);
//        }

//        public static bool Contains(this IBiota biote, ItemTemplate aTemplate)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.Contains(aTemplate);
//        }

//        public static long UnequipItem(this IBiota biote, long id)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.UnequipItem(id);
//        }

//        public static long UnequipItem(this IBiota biote, ItemInstance aItem)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.UnequipItem(aItem);
//        }

//        public static long HoldItem(this IBiota biote, long id)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(id);
//        }

//        public static long HoldItem(this IBiota biote, long id, int quantity)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(id, quantity);
//        }

//        public static long HoldItem(this IBiota biote, string name)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(name);
//        }

//        public static long HoldItem(this IBiota biote, string name, int quantity)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(name, quantity);
//        }

//        public static long HoldItem(this IBiota biote, ItemInstance item)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(item);
//        }

//        public static long HoldItem(this IBiota biote, ItemTemplate template)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(template);
//        }

//        public static long HoldItem(this IBiota biote, ItemTemplate template, int quantity)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.HoldItem(template, quantity);
//        }

//        public static long EquipItem(this IBiota biote, long id)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.EquipItem(id);
//        }

//        public static long EquipItem(this IBiota biote, string name)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.EquipItem(name);
//        }

//        public static long EquipItem(this IBiota biote, ItemInstance item)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.EquipItem(item);
//        }

//        public static long EquipItem(this IBiota biote, ItemTemplate template)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.EquipItem(template);
//        }

//        public static bool RemoveItem(this IBiota biote, ItemInstance instance)
//        {
//            if (biote.Inventory.IsNull())
//                throw new InstanceNotFoundException("Inventory not found");

//            return biote.Inventory.Contents.RemoveEntity(instance);
//        }

//        #endregion
//    }
//}
