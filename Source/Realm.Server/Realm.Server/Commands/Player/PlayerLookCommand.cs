//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Properties;
//using Realm.Server.Zones;
//using Realm.Library.Network.Mxp;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Look command
//    /// </summary>
//    public class PlayerLookCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerLookCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerLookCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Displays the output of the current Space
//        /// </summary>
//        /// <param name="character">Character looking</param>
//        /// <param name="location">Character's location</param>
//        public void LookArea(ICharacter character, IGameEntity location)
//        {
//            if (null == location || !(location is Space)) return;

//            var Space = location as Space;

//            if (!character.CanSee(null))
//            {
//                CommandManager.ReportToCharacter("#look_dark#", character);
//                return;
//            }

//            var sb = new StringBuilder();

//            //// HEADER LINE
//            sb.Append(MxpResources.MXP_TAG_RNAME_OPEN.MxpTag());
//            sb.Append(Space.Name);
//            sb.Append(MxpResources.MXP_TAG_RNAME_CLOSE.MxpTag());
//            if (character.CanSeeExtendedDetails)
//            {
//                sb.Append(MxpResources.MXP_TAG_ID_OPEN.MxpTag());
//                sb.Append(" (#");
//                sb.Append(MxpResources.MXP_TAG_WIZENTITY_OPEN.MxpTag(Space.ID, Space.Name));
//                sb.Append(Space.ID);
//                sb.Append(Space.GetFlags());
//                sb.Append(MxpResources.MXP_TAG_WIZENTITY_CLOSE.MxpTag());
//                sb.Append(") ");
//                sb.Append(MxpResources.MXP_TAG_ID_CLOSE.MxpTag());
//            }
//            sb.AppendFormat("[{0}]", Space.MyZone.Name.CapitalizeFirst());
//            // TODO: : If its a shrouding, show something after the Space name
//            sb.AppendFormat(" ({0}){1}", TimeManager.GetSeason().ToString().ToLower().CapitalizeFirst(), Environment.NewLine);

//            //// DESCRIPTION
//            sb.Append(MxpResources.MXP_TAG_RDESC_OPEN.MxpTag());
//            sb.Append(Space.Description);
//            sb.Append(MxpResources.MXP_TAG_RDESC_CLOSE.MxpTag());
//            sb.Append(Environment.NewLine);
//            character.User.SendText(sb.ToString());

//            //// REMAINDER
//            Space.DescribePortals(character);
//            Space.DescribeOccupants(character);
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var character = oUser.GetCurrentCharacter();

//            var phrase = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(phrase))
//            {
//                LookArea(character, character.Location);
//                return;
//            }

//            //// if phrase is a valid direction, look at it
//            var space = character.Location as Space;
//            if (space.IsNull()) return;

//            if (space.GetPortal(phrase).IsNotNull())
//            {
//                LookDirection(character, space, phrase);
//                return;
//            }

//            LookObject(character, space, phrase);
//        }

//        /// <summary>
//        /// Looks in a given direction
//        /// </summary>
//        /// <param name="oUser">Character looking</param>
//        /// <param name="location">Character's location</param>
//        /// <param name="dir">Direction name</param>
//        private void LookDirection(ICharacter oUser, IGameEntity location, string dir)
//        {
//            if (!(location is Space)) return;

//            var currentSpace = location as Space;

//            var exit = currentSpace.GetPortal(dir);
//            var destSpace = exit.Destination;

//            CommandManager.ReportToCharacter("#look_dir#", oUser, null, exit);

//            if (exit.Direction == Globals.Globals.Directions.Up || exit.Direction == Globals.Globals.Directions.Down)
//                CommandManager.ReportToCharacter("#look_dir_updown#", oUser, null, exit, destSpace);
//            else
//                CommandManager.ReportToCharacter("#look_dir_other#", oUser, null, exit, destSpace);
//        }

//        /// <summary>
//        /// Looks at a given object
//        /// </summary>
//        /// <param name="oUser">Object looking</param>
//        /// <param name="location">Object's location</param>
//        /// <param name="obj">String phrase</param>
//        private void LookObject(ICharacter oUser, IGameEntity location, string obj)
//        {
//            if (!oUser.CanSee(null))
//            {
//                CommandManager.ReportToCharacter("#look_dark#", oUser);
//                return;
//            }

//            //// Find the target somewhere
//            var validLocs = 
//                Globals.Globals.EntityLocationTypes.Space.GetValue() |
//                Globals.Globals.EntityLocationTypes.Inventory.GetValue() |
//                Globals.Globals.EntityLocationTypes.Equipment.GetValue() |
//                Globals.Globals.EntityLocationTypes.Container.GetValue() |
//                Globals.Globals.EntityLocationTypes.Shop.GetValue() |
//                Globals.Globals.EntityLocationTypes.MobileInventory.GetValue() |
//                Globals.Globals.EntityLocationTypes.MobileEquipment.GetValue() |
//                Globals.Globals.EntityLocationTypes.Recipes.GetValue();
//            var result = TargetLocation.FindTargetEntity(oUser, obj, validLocs);
//            if (null == result.FoundEntity)
//            {
//                CommandManager.ReportToCharacter("#nothing_here#", oUser);
//                return;
//            }
//            var entity = result.FoundEntity;
//            if (entity == oUser)
//            {
//                CommandManager.ReportToCharacter("#cant_do_that#", oUser);
//                return;
//            }

//            if (entity is Biota)
//            {
//                if (entity is Character)
//                    CommandManager.ReportToCharacter("#looks_at_you#", oUser, entity);

//                IBiota biote;
//                var sb = new StringBuilder();
//                if (entity is Character)
//                {
//                    var user = entity as ICharacter;
//                    sb.Append("#you_look_at#");
//                    sb.Append(Environment.NewLine);
//                    sb.Append(oUser.Description);
//                    sb.Append(Environment.NewLine);
//                    biote = user;
//                }
//                else
//                {
//                    var mob = entity as IMobInstance;
//                    if (mob.IsNull()) return;

//                    sb.Append("#you_look_at#");
//                    sb.Append(Environment.NewLine);
//                    sb.Append(mob.Description);
//                    sb.Append(Environment.NewLine);
//                    biote = entity as IMobInstance;
//                }
//                if (biote.IsNull()) return;

//                if (biote.Inventory.IsNaked)
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append(" #nothing#");
//                    CommandManager.ReportToCharacter(sb.ToString(), oUser, biote);
//                }
//                else
//                {
//                    foreach (var wearLocation in biote.Inventory.Equipment.Keys)
//                    {
//                        var instance = biote.GetEquippedItem(wearLocation);
//                        sb.Append(Environment.NewLine);
//                        sb.AppendFormat(" {0}", wearLocation.GetExtraData().PadRight(30, '.'));

//                        if (biote.Flags.IsAdmin())
//                        {
//                            sb.Append(MxpResources.MXP_TAG_ITEM_OPEN.MxpTag());
//                            sb.Append(instance.Name);
//                            sb.Append(MxpResources.MXP_TAG_ITEM_CLOSE.MxpTag());
//                            sb.Append(MxpResources.MXP_TAG_ID_OPEN.MxpTag());
//                            sb.Append(" (#");
//                            sb.Append(MxpResources.MXP_TAG_WIZITEM_OPEN.MxpTag(instance.ID, instance.Name));
//                            sb.Append(instance.ID);
//                            sb.Append(instance.GetFlags());
//                            sb.Append(MxpResources.MXP_TAG_WIZITEM_CLOSE.MxpTag());
//                            sb.Append(")");
//                            sb.Append(MxpResources.MXP_TAG_ID_CLOSE.MxpTag());
//                        }
//                        else
//                        {
//                            sb.Append(MxpResources.MXP_TAG_ITEM_OPEN.MxpTag());
//                            sb.Append(instance.Name);
//                            sb.Append(MxpResources.MXP_TAG_ITEM_CLOSE.MxpTag());
//                        }
//                    }

//                    CommandManager.ReportToCharacter(sb.ToString(), oUser, biote);
//                }
//            }
//            else if (entity is IItem)
//            {
//                var sb = new StringBuilder();
//                switch (result.FoundEntityLocationType)
//                {
//                    case Globals.Globals.EntityLocationTypes.MobileEquipment:
//                    case Globals.Globals.EntityLocationTypes.MobileInventory:
//                        {
//                            //// Item is on a NPC's Inventory/Equipment
//                            var instance = entity as ItemInstance;
//                            var mob = result.FoundEntityLocation as IMobInstance;

//                            sb.Append("#look_npc_item_self#");
//                            sb.Append(Environment.NewLine);
//                            sb.Append(LookItem(oUser, instance));
//                            sb.Append(Environment.NewLine);

//                            CommandManager.ReportToCharacter(sb.ToString(), oUser, mob, instance);
//                            CommandManager.ReportToSpaceLimited("#look_npc_item_other#", oUser, mob, instance);
//                        }
//                        break;
//                    case Globals.Globals.EntityLocationTypes.Shop:
//                        {
//                            //// Item is in a Shop
//                            var mob = result.FoundEntityLocation as VendorNpcInstance;

//                            sb.Append("#look_item_shop#");
//                            sb.Append(Environment.NewLine);
//                            // TODO: : Finish looking at items in shops
//                        }
//                        break;
//                    case Globals.Globals.EntityLocationTypes.Recipes:
//                        {
//                            //// Item is memorized as a recipe
//                            var formula = result.FoundEntity as FormulaItemTemplate;
//                            if (formula.IsNull()) return;

//                            var msg = "#look_item_formula#";

//                            var product = EntityManager.LuaGetTemplate(formula.Product) as ItemTemplate;
//                            if (product.IsNull()) return;

//                            msg += Environment.NewLine + "  Product: " + product.Name;
//                            if (oUser.Flags.IsAdmin())
//                            {
//                                msg += MxpResources.MXP_TAG_ID_OPEN.MxpTag() + " (#" + MxpResources.MXP_TAG_WIZITEM_OPEN.MxpTag(product.ID, product.Name);
//                                msg += product.ID + product.GetFlags() + MxpResources.MXP_TAG_WIZITEM_CLOSE.MxpTag() + ")" + 
//                                    MxpResources.MXP_TAG_ID_CLOSE.MxpTag();
//                            }

//                            msg += Environment.NewLine + "  Skill: " + formula.Skill.Name + " (" + formula.SkillValue + ")";
//                            if (oUser.Flags.IsAdmin())
//                            {
//                                msg += MxpResources.MXP_TAG_ID_OPEN.MxpTag() + " (#" + formula.Skill.ID + ")" + 
//                                    MxpResources.MXP_TAG_ID_CLOSE.MxpTag();
//                            }

//                            var machine = EntityManager.LuaGetTemplate(formula.Machine) as ItemTemplate;
//                            if (machine.IsNull()) return;

//                            msg += Environment.NewLine + "  Machine: " + EntityManager.LuaGetTemplate(formula.Machine).Name;
//                            if (oUser.Flags.IsAdmin())
//                            {
//                                msg += MxpResources.MXP_TAG_ID_OPEN.MxpTag() + " (#" + ("WizItem '" + machine.ID + "'").MxpTag();
//                                msg += machine.ID + machine.GetFlags() + "/WizItem".MxpTag() + ")" + MxpResources.MXP_TAG_ID_CLOSE.MxpTag();
//                            }

//                            var tool = EntityManager.LuaGetTemplate(formula.Tool) as ItemTemplate;
//                            if (tool.IsNull()) return;

//                            msg += Environment.NewLine + "  Tool: " + EntityManager.LuaGetTemplate(formula.Tool).Name;
//                            if (oUser.Flags.IsAdmin())
//                            {
//                                msg += MxpResources.MXP_TAG_ID_OPEN.MxpTag() + " (#" + ("WizItem '" + tool.ID + "'").MxpTag();
//                                msg += tool.ID + tool.GetFlags() + "/WizItem".MxpTag() + ")" + MxpResources.MXP_TAG_ID_CLOSE.MxpTag();
//                            }

//                            msg += Environment.NewLine + "  Resources:";
//                            foreach (int resourceId in formula.ResourceKeys)
//                            {
//                                var resource = EntityManager.LuaGetTemplate(resourceId) as ResourceItemTemplate;
//                                if (resource.IsNull()) continue;

//                                msg += Environment.NewLine + "   " + resource.Name + " (x" + formula.GetResource(resourceId) + ")";
//                                if (!oUser.Flags.IsAdmin()) continue;

//                                msg += MxpResources.MXP_TAG_ID_OPEN.MxpTag() + " (#" + ("WizItem '" + resource.ID + "'").MxpTag();
//                                msg += resource.ID + resource.GetFlags() + "/WizItem".MxpTag() + ")" + MxpResources.MXP_TAG_ID_CLOSE.MxpTag();
//                            }

//                            CommandManager.ReportToCharacter(msg, oUser, null, formula); 
//                        }
//                        break;
//                    default:
//                        {
//                            var instance = entity as ItemInstance;
//                            if (instance.IsNull()) return;

//                            sb.Append("#look_item_self#");
//                            sb.Append(Environment.NewLine);
//                            sb.Append(LookItem(oUser, instance));
//                            sb.Append(Environment.NewLine);

//                            CommandManager.ReportToCharacter(sb.ToString(), oUser, null, instance);
//                            CommandManager.ReportToSpaceLimited("#look_item_other#", oUser, null, instance);
//                        }
//                        break;
//                }
//            }
//            else
//            {
//                Log.ErrorFormat("User[{0}], Object[{1}] had no known type.", oUser.ID, entity.ID);
//            }
//        }

//        /// <summary>
//        /// Looks at a given item
//        /// </summary>
//        /// <param name="oUser">Object looking</param>
//        /// <param name="item">Item being looked at</param>
//        /// <returns>Returns a generated string</returns>
//        private string LookItem(ICharacter oUser, ItemInstance item)
//        {
//            var sb = new StringBuilder();
//            sb.Append(item.Description.CapitalizeFirst());
//            sb.Append(Environment.NewLine);
//            sb.Append(Environment.NewLine);

//            //// returns details based upon the type of object
//            switch (item.ItemType.GetName().ToLower())
//            {
//                case "formula":
//                case "resource node":
//                case "container":
//                case "drink container":
//                    sb.Append(item.Explore(oUser));
//                    break;

//                // TODO: : Other types that might be needing extra details are Armor, Lights, Potions, and Weapons
//            }

//            sb.Append(Environment.NewLine);
//            sb.Append("Properties:");
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("  Size is {0}.", item.Size.GetName());
//            sb.AppendFormat("{0}  Composed of {1}.", Environment.NewLine, item.Material.GetName());
//            if (!item.IsTakeable)
//                sb.AppendFormat("{0}  #not_takeable#", Environment.NewLine);

//            // TODO: : If Wearable, display the locations
//            // TODO: : Durability

//            return sb.ToString();
//        }
//    }
//}
