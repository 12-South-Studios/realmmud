using System.Linq;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Common;

namespace Realm.Command
{
    /// <summary>
    /// Class used for locating targets
    /// </summary>
    public static class TargetLocation
    {
        /// <summary>
        ///  Helper function that quickly populates the TargetResult object with data
        /// </summary>
        internal static TargetResult Populate(this TargetResult value, IGameEntity entity, IGameEntity biote,
            Globals.Globals.EntityLocationTypes type)
        {
            value.FoundEntity = entity;
            value.FoundEntityLocation = biote;
            value.FoundEntityLocationType = type;
            return value;
        }

        /// <summary>
        /// Parse the quantity if one was provided
        /// </summary>
        internal static TargetResult ParseQuantity(TargetResult result)
        {
            if (!result.FirstParameter.StartsWith("#")) return result;
            result.Quantity = result.FirstParameter.ParseQuantity();
            if (result.Quantity <= 0)
                result.Quantity = 1;
            result.FirstParameter = result.FirstParameter.Remove(0, result.FirstParameter.IndexOf('#') + 1);
            return result;
        }

        internal static TargetResult ParseFirstParameter(TargetResult result, IGameEntity entity, int allowedLocations)
        {
            IGameEntity target;

            //// Look in inventory first
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Inventory.GetValue()) != 0)
            {
                target = FindEntityInInventory(entity, result.FirstParameter);
                if (target.IsNotNull())
                    return result.Populate(target, entity, Globals.Globals.EntityLocationTypes.Inventory);
            }

            //// Look in equipment second
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Equipment.GetValue()) != 0)
            {
                target = FindEntityInEquipment(entity, result.FirstParameter);
                if (target.IsNotNull())
                    return result.Populate(target, entity, Globals.Globals.EntityLocationTypes.Equipment);
            }

            //// Look on ground third
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Space.GetValue()) != 0)
            {
                target = FindEntity(entity.Location, result.FirstParameter);
                if (target.IsNotNull())
                    return result.Populate(target, entity.Location, Globals.Globals.EntityLocationTypes.Space);
            }

            //// look in abilities
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Ability.GetValue()) != 0)
                return result;

            //// look in Effects
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Effects.GetValue()) != 0)
                return result;

            //// Look in Recipes
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Recipes.GetValue()) != 0)
            {
                target = FindEntityInRecipes(entity, result.FirstParameter);
                if (target.IsNotNull())
                    return result.Populate(target, null, Globals.Globals.EntityLocationTypes.Recipes);
            }
            return result;
        }

        internal static TargetResult ParseSecondParameter(TargetResult result, IGameEntity entity, int allowedLocations)
        {
            IGameEntity secondTarget;
            IGameEntity target;

            //// second parameter could be a container, check inventory
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Inventory.GetValue()) != 0)
            {
                secondTarget = FindEntityInInventory(entity, result.SecondParameter);
                if (secondTarget.IsNotNull())
                {
                    target = FindEntity(secondTarget, result.SecondParameter);
                    if (target.IsNotNull())
                        return result.Populate(target, secondTarget, Globals.Globals.EntityLocationTypes.Container);
                }
            }

            //// second parameter in equipment
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Equipment.GetValue()) != 0)
            {
                secondTarget = FindEntityInEquipment(entity, result.SecondParameter);
                if (secondTarget.IsNotNull())
                {
                    target = FindEntity(secondTarget, result.SecondParameter);
                    if (target.IsNotNull())
                        return result.Populate(target, secondTarget, Globals.Globals.EntityLocationTypes.Container);
                }
            }

            //// second parameter on ground
            if ((allowedLocations & Globals.Globals.EntityLocationTypes.Space.GetValue()) == 0) return result;
            secondTarget = FindEntity(entity.Location, result.SecondParameter);

            if (!secondTarget.IsNotNull()) return result;
            if (secondTarget is Mobile)
            {
                //// NPC Inventory
                if ((allowedLocations & Globals.Globals.EntityLocationTypes.MobileInventory.GetValue()) != 0)
                {
                    target = FindEntityInInventory(secondTarget.CastAs<IBiota>(), result.FirstParameter);
                    if (target.IsNotNull())
                        return result.Populate(target, secondTarget, Globals.Globals.EntityLocationTypes.MobileInventory);
                }

                //// NPC Equipment
                if ((allowedLocations & Globals.Globals.EntityLocationTypes.MobileEquipment.GetValue()) != 0)
                {
                    target = FindEntityInEquipment(secondTarget.CastAs<IBiota>(), result.FirstParameter);
                    if (target.IsNotNull())
                        return result.Populate(target, secondTarget, Globals.Globals.EntityLocationTypes.MobileEquipment);
                }

                //// NPC Shop
                if ((allowedLocations & Globals.Globals.EntityLocationTypes.Shop.GetValue()) == 0) return result;
                target = FindEntityInShop(secondTarget, result.FirstParameter);
                if (target.IsNotNull())
                    return result.Populate(target, secondTarget, Globals.Globals.EntityLocationTypes.Shop);
            }
            else
            {
                target = FindEntity(secondTarget, result.SecondParameter);
                if (target.IsNotNull())
                    return result.Populate(target, secondTarget, Globals.Globals.EntityLocationTypes.Container);
            }

            return result;
        }

        /// <summary>
        /// Function used to parse a phrase and attempt to locate an object matching
        /// the given parameters.
        /// </summary>
        public static TargetResult FindTargetEntity(this Biota biote, string phrase, int allowedLocations)
        {
            var result = new TargetResult
                {
                    FirstParameter = phrase.FirstWord(),
                    SecondParameter = phrase.SecondWord(),
                    Quantity = 1
                };

            if (string.IsNullOrEmpty(result.FirstParameter) || allowedLocations == 0) return result;

            result = ParseQuantity(result);
            result = ParseFirstParameter(result, biote, allowedLocations);

            //// no optional parameters were supplied, return the results
            if (string.IsNullOrEmpty(result.SecondParameter))
                return result;

            result = ParseSecondParameter(result, biote, allowedLocations);

            return result;
        }

        /// <summary>
        /// Attempts to locate the given name from inventory
        /// </summary>
        internal static IGameEntity FindEntityInInventory(IGameEntity biote, string name)
        {
            return biote.GetContentsContext().Entities.Select(entity => entity as Item)
                .FirstOrDefault(item => item.CompareName(name));
        }

        /// <summary>
        /// Attempts to locate the given name from equipment
        /// </summary>
        internal static IGameEntity FindEntityInEquipment(IGameEntity entity, string name)
        {
            IGameEntity foundEntity = null;
            if (entity is IBiota)
            {
                var biote = entity.CastAs<IBiota>();
                // TODO: Check the Biote's equipment for the item
                //return biote.Inventory.Equipment.Values.FirstOrDefault(item => item.CompareName(name));
            }
            return foundEntity;
        }

        /// <summary>
        /// Attempts to locate the given name from the contents
        /// </summary>
        internal static IGameEntity FindEntity(IGameEntity entity, string name)
        {
            return entity.GetContentsContext().GetEntity(name);
        }

        /// <summary>
        /// Attempts to locate the given name from the vendor's shop contents
        /// </summary>
        internal static IGameEntity FindEntityInShop(IGameEntity entity, string name)
        {
            IGameEntity foundItem = null;
            if (entity is IVendorNpc)
            {
                var vendor = entity.CastAs<IVendorNpc>();
                
                // TODO: Check the Vendor's shop for the sale item
            }
            return foundItem;
        }

        /// <summary>
        /// Attempts to locate the given name from the entity's recipe list
        /// </summary>
        internal static IGameEntity FindEntityInRecipes(IGameEntity entity, string name)
        {
            IGameEntity foundItem = null;
            if (entity is ICharacter)
            {
                var character = entity.CastAs<ICharacter>();
                // TODO: Check the Character's Recipes for the item
                /*return character.RecipeRepository.Keys.Select(recipeId => character.RecipeRepository.Get(recipeId))
                .FirstOrDefault(formula => formula.CompareName(name));*/
            }
            return foundItem;
        }
    }
}