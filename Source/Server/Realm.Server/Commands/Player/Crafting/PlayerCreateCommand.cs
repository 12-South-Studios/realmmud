//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Attributes;
//using Realm.Server.Events;
//using Realm.Server.Factories;
//using Realm.Server.Item;
//using Realm.Server.Zones;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// create command
//    /// </summary>
//    public class PlayerCreateCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerCreateCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerCreateCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
//        {
//            // do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var keyword = oUser.GetLastCommand();
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            //// Find the formula matching the given product
//            var character = oUser.GetCurrentCharacter();
//            var formula = character.GetRecipeByProduct(keyword);
//            if (null == formula)
//            {
//                CommandManager.ReportToCharacter("#no_recipe#", oUser);
//                return;
//            }
//            var product = EntityManager.LuaGetTemplate(formula.Product) as ItemTemplate;

//            //// is there a machine required and present?
//            if (formula.Machine > 0)
//            {
//                var machine = EntityManager.LuaGetTemplate(formula.Machine) as ItemTemplate;
//                var space = character.Location as ISpace;
//                if (!space.Contains(machine))
//                {
//                    CommandManager.ReportToCharacter("#no_machine#", oUser, null, machine);
//                    return;
//                }
//            }

//            //// is there a tool required and does the biote have it?
//            if (formula.Tool > 0)
//            {
//                var tool = EntityManager.LuaGetTemplate(formula.Tool) as ItemTemplate;
//                if (!character.IsWearing(tool))
//                {
//                    CommandManager.ReportToCharacter("#no_tool#", oUser, null, tool);
//                    return;
//                }
//            }

//            //// does the player have the matching skill?
//            var skill = character.StatisticHandler.GetSkill(formula.Skill.Name);
//            if (skill.IsNull())
//            {
//                CommandManager.ReportToCharacter("#insuf_skill#", oUser);
//                return;
//            }

//            //// does the player have sufficient quantity of required resources?
//            foreach (var resourceId in formula.ResourceKeys)
//            {
//                var resourceTemplate = EntityManager.LuaGetTemplate(resourceId) as ItemTemplate;
//                var instances = character.GetItemFromBackpack(resourceTemplate);
//                if (instances.IsNull() || instances.Count == 0)
//                {
//                    CommandManager.ReportToCharacter("#insuf_resource#", oUser, null, resourceTemplate);
//                    return;
//                }

//                if (instances[0].StackSize >= formula.GetResource(resourceId)) continue;
//                CommandManager.ReportToCharacter("#insuf_resource#", oUser, null, resourceTemplate);
//                return;
//            }

//            //// Reduce the quantities of the resources
//            foreach (var resourceId in formula.ResourceKeys)
//            {
//                var resourceTemplate = EntityManager.LuaGetTemplate(resourceId) as ItemTemplate;
//                var instances = character.GetItemFromBackpack(resourceTemplate);
//                if (instances.IsNull() || instances.Count == 0)
//                    continue;
//                var qty = formula.GetResource(resourceId);

//                instances[0].StackSize -= qty;
//                if (instances[0].StackSize > 0) continue;

//                character.RemoveItem(instances[0]);
//                EntityManager.RecycleEntity(instances[0]);
//            }

//            //// execute and create the product
//            var factory = new GameItemFactory();
//            var newProduct = factory.CreateInstance(string.Empty, product) as ItemInstance;
//            Game.SetManagerReferences(newProduct);
//            if (formula.ProductQuantity > 1)
//                newProduct.StackSize = formula.ProductQuantity;
//            character.HoldItem(newProduct);

//            CommandManager.ReportToCharacter("#create_self#", oUser, null, newProduct, null, null, formula.ProductQuantity);
//            CommandManager.ReportToSpaceLimited("#create_other#", oUser, null, newProduct, null, null, formula.ProductQuantity);

//            Game.SetProperty("last created", newProduct);
//            EventManager.ThrowEvent<OnCreateItem>(oUser.Characters.Character, new EventTable
//                                                                                  {
//                                                                                      {"item", newProduct}
//                                                                                  });

//            //// update skill
//            AttributeUtils.SkillCheck(skill.Rating, formula.SkillValue, formula.XpValue, true);
//            CommandManager.ReportToCharacter("#create_xp#", oUser, null, skill.TotalXp, skill.Name);
//        }
//    }
//}
