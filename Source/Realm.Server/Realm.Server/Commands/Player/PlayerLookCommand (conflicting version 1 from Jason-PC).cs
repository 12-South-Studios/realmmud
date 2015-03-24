// ----------------------------------------------------------------------
// <copyright file="PlayerLookCommand.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
// </copyright>
// <summary>
//
// </summary>
// ------------------------------------------------------------------------
using System;
using System.Text;
using Realm.Core.Enums;
using Realm.Core.Extensions;
using Realm.Objects;
using Realm.Singletons;
using System.Collections;

namespace Realm.Commands.Player
{
    /// <summary>
    /// Look command
    /// </summary>
    public class PlayerLookCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerLookCommand"/> class
        /// </summary>
        /// <param name="id">ID of the command</param>
        /// <param name="name">Name of the command</param>
        /// <param name="keywords">Keywords of the command</param>
        /// <param name="action">Log action to take when executed</param>
        public PlayerLookCommand(int id, string name, string keywords, LogAction action)
            : base(id, name, keywords, action)
        {
            // do nothing
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public override void Execute()
        {
            User.User oUser = GameManager.instance.GetProperty("current user") as User.User;

            string phrase = oUser.GetProperty("last command string").ToString();
            if (string.IsNullOrEmpty(phrase))
            {
                this.LookArea(oUser.character, oUser.character.location);
                return;
            }

            // if phrase is a valid direction, look at it
            Room r = oUser.character.location as Room;
            if (r.getExit(phrase) != null)
            {
                this.LookDirection(oUser.character, oUser.character.location, phrase);
                return;
            }

            this.LookObject(oUser.character, oUser.character.location, phrase);
        }

        /// <summary>
        /// Displays the output of the current Room
        /// </summary>
        /// <param name="character"></param>
        /// <param name="location"></param>
        public void LookArea(Character character, Entity location)
        {
            if (null == location || !location.Is(EntityType.ROOM))
            {
                return;
            }

            Room room = location as Room;
            if (!character.canSee(null))
            {
                CommandManager.instance.report(MessageScope.CHAR, "#look_dark#", character);
                return;
            }

            StringBuilder sb = new StringBuilder();

            // HEADER LINE
            sb.Append(Server.Client.MXP_TAG("RName"));
            sb.Append(room.Name);
            sb.Append(Server.Client.MXP_TAG("/RName"));
            if (character.canSeeExtendedDetails)
            {
                sb.Append(Server.Client.MXP_TAG("Id"));
                sb.Append(" (#");
                sb.Append(Server.Client.MXP_TAG("WizEntity '" + room.ID + "' '" + room.Name + "'"));
                sb.Append(room.ID);
                sb.Append(room.GetFlags());
                sb.Append(Server.Client.MXP_TAG("/WizEntity"));
                sb.Append(") ");
                sb.Append(Server.Client.MXP_TAG("/Id"));
            }
            sb.AppendFormat("[{0}]", room.location.Name.CapitalizeFirst());
            // TODO: If its a shrouding, show something after the Room name
            sb.AppendFormat(" ({0}){1}", TimeManager.instance.currentMonth.season.ToString().ToLower().CapitalizeFirst(), Environment.NewLine);

            // DESCRIPTION
            sb.Append(Server.Client.MXP_TAG("RDesc"));
            sb.Append(room.description);
            sb.Append(Server.Client.MXP_TAG("/RDesc"));
            sb.Append(Environment.NewLine);
            character.user.sendText(sb.ToString());

            // REMAINDER
            room.describeExits(character);
            room.describeOccupants(character);
        }

        /// <summary>
        /// Looks in a given direction
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="location"></param>
        /// <param name="dir"></param>
        private void LookDirection(Character oUser, Entity location, string dir)
        {
            if (!location.Is(EntityType.ROOM))
            {
                return;
            }

            Room currentRoom = location as Room;
            Exit e = currentRoom.getExit(dir);
            Room destRoom = e.destination;

            CommandManager.instance.report(MessageScope.CHAR, "#look_dir#", oUser, null, e);

            if (e.direction == DirectionType.UP || e.direction == DirectionType.DOWN)
            {
                CommandManager.instance.report(MessageScope.CHAR, "#look_dir_updown#", oUser, null, e, destRoom);
            }
            else
            {
                CommandManager.instance.report(MessageScope.CHAR, "#look_dir_other#", oUser, null, e, destRoom);
            }
        }

        /// <summary>
        /// Looks at a given object
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="location"></param>
        /// <param name="obj"></param>
        private void LookObject(Character oUser, Entity location, string obj)
        {
            if (!oUser.canSee(null))
            {
                CommandManager.instance.report(MessageScope.CHAR, "#look_dark#", oUser);
                return;
            }

            // Find the target somewhere
            int validLocs = 
                (int)EntityLocationType.LOC_ROOM | 
                (int)EntityLocationType.LOC_INVENTORY | 
                (int)EntityLocationType.LOC_EQUIPMENT | 
                (int)EntityLocationType.LOC_CONTAINER | 
                (int)EntityLocationType.LOC_SHOP | 
                (int)EntityLocationType.LOC_NPC_INVENTORY |
                (int)EntityLocationType.LOC_NPC_EQUIPMENT | 
                (int)EntityLocationType.LOC_RECIPES;
            TargetResult result = TargetLocation.findTargetEntity(oUser, obj, validLocs);
            if (null == result._foundEntity)
            {
                CommandManager.instance.report(MessageScope.CHAR, "#nothing_here#", oUser);
                return;
            }
            Entity entity = result._foundEntity;

            if (entity == oUser)
            {
                CommandManager.instance.report(MessageScope.CHAR, "#cant_do_that#", oUser);
                return;
            }

            #region Looking at a Player/Mob
            if (entity.Is(EntityType.BIOTA))
            {
                if (entity.Is(EntityType.PLAYER))
                {
                    CommandManager.instance.report(MessageScope.CHAR, "#looks_at_you#", oUser, entity);
                }

                Biota biote = null;
                StringBuilder sb = new StringBuilder();
                if (entity.Is(EntityType.PLAYER))
                {
                    Character user = entity as Character;
                    sb.Append("#you_look_at#");
                    sb.Append(Environment.NewLine);
                    sb.Append(user.description);
                    sb.Append(Environment.NewLine);
                    biote = user;
                }
                else
                {
                    MobInstance mob = entity as MobInstance;
                    sb.Append("#you_look_at#");
                    sb.Append(Environment.NewLine);
                    sb.Append(mob.description);
                    sb.Append(Environment.NewLine);
                    biote = (MobInstance)entity;
                }

                if (biote.isNaked)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(" #nothing#");
                    CommandManager.instance.report(MessageScope.CHAR, sb.ToString(), oUser, biote);
                }
                else
                {
                    IEnumerable equipment = biote.getEquipment();
                    foreach (DictionaryEntry entry in equipment)
                    {
                        ItemInstance instance = (ItemInstance)entry.Value;
                        WearLocation loc = instance.getWearLocation(1);

                        sb.Append(Environment.NewLine);
                        sb.AppendFormat(" {0}", loc.longName.PadRight(30, '.'));

                        if (oUser.HasFlag("Admin") || oUser.HasFlag("Builder") || oUser.HasFlag("Wizard"))
                        {
                            sb.Append(Server.Client.MXP_TAG("Item"));
                            sb.Append(instance.Name);
                            sb.Append(Server.Client.MXP_TAG("/Item"));
                            sb.Append(Server.Client.MXP_TAG("Id"));
                            sb.Append(" (#");
                            sb.Append(Server.Client.MXP_TAG("WizItem '" + instance.ID + "'"));
                            sb.Append(instance.ID);
                            sb.Append(instance.GetFlags());
                            sb.Append(Server.Client.MXP_TAG("/WizItem"));
                            sb.Append(")");
                            sb.Append(Server.Client.MXP_TAG("/Id"));
                        }
                        else
                        {
                            sb.Append(Server.Client.MXP_TAG("Item"));
                            sb.Append(instance.Name);
                            sb.Append(Server.Client.MXP_TAG("/Item"));
                        }
                    }

                    CommandManager.instance.report(MessageScope.CHAR, sb.ToString(), oUser, biote);
                }
            }
            #endregion

            #region Looking at an Item
            else if (entity.Is(EntityType.ITEM))
            {
                StringBuilder sb = new StringBuilder();
                if (result._foundEntityLocationType == EntityLocationType.LOC_NPC_INVENTORY || 
                    result._foundEntityLocationType == EntityLocationType.LOC_NPC_EQUIPMENT)
                {
                    // Item is on a NPC's Inventory/Equipment
                    ItemInstance instance = entity as ItemInstance;
                    MobInstance mob = result._foundEntityLocation as MobInstance;

                    sb.Append("#look_npc_item_self#");
                    sb.Append(Environment.NewLine);
                    sb.Append(this.LookItem(oUser, instance));
                    sb.Append(Environment.NewLine);

                    CommandManager.instance.report(MessageScope.CHAR, sb.ToString(), oUser, mob, instance);
                    CommandManager.instance.report(MessageScope.ROOM_LIMITED, "#look_npc_item_other#", oUser, mob, instance);
                }
                else if (result._foundEntityLocationType == EntityLocationType.LOC_SHOP)
                {
                    // Item is in a Shop
                    ShopkeeperMobInstance mob = result._foundEntityLocation as ShopkeeperMobInstance;

                    sb.Append("#look_item_shop#");
                    sb.Append(Environment.NewLine);
                    // @TODO: Finish looking at items in shops
                }

                else if (result._foundEntityLocationType == EntityLocationType.LOC_RECIPES)
                {
                    // Item is memorized as a recipe
                    FormulaItemTemplate formula = result._foundEntity as FormulaItemTemplate;

                    string msg = "#look_item_formula#";

                    ItemTemplate product = EntityManager.instance.getTemplateByID(formula.product) as ItemTemplate;
                    msg += Environment.NewLine + "  Product: " + product.Name;
                    if (oUser.HasFlag("Admin") || oUser.HasFlag("Builder") || oUser.HasFlag("Wizard"))
                    {
                        msg += Server.Client.MXP_TAG("Id") + " (#" + Server.Client.MXP_TAG("WizItem '" + product.ID + "'");
                        msg += product.ID + product.GetFlags() + Server.Client.MXP_TAG("/WizItem") + ")" + Server.Client.MXP_TAG("/Id");
                    }

                    msg += Environment.NewLine + "  Skill: " + formula.skill.Name + " (" + formula.skillValue + ")";
                    if (oUser.HasFlag("Admin") || oUser.HasFlag("Builder") || oUser.HasFlag("Wizard"))
                    {
                        msg += Server.Client.MXP_TAG("Id") + " (#" + formula.skill.ID + ")" + Server.Client.MXP_TAG("/Id");
                    }

                    ItemTemplate machine = EntityManager.instance.getTemplateByID(formula.machine) as ItemTemplate;
                    msg += Environment.NewLine + "  Machine: " + EntityManager.instance.getTemplateByID(formula.machine).Name;
                    if (oUser.HasFlag("Admin") || oUser.HasFlag("Builder") || oUser.HasFlag("Wizard"))
                    {
                        msg += Server.Client.MXP_TAG("Id") + " (#" + Server.Client.MXP_TAG("WizItem '" + machine.ID + "'");
                        msg += machine.ID + machine.GetFlags() + Server.Client.MXP_TAG("/WizItem") + ")" + Server.Client.MXP_TAG("/Id");
                    }

                    ItemTemplate tool = EntityManager.instance.getTemplateByID(formula.tool) as ItemTemplate;
                    msg += Environment.NewLine + "  Tool: " + EntityManager.instance.getTemplateByID(formula.tool).Name;
                    if (oUser.HasFlag("Admin") || oUser.HasFlag("Builder") || oUser.HasFlag("Wizard"))
                    {
                        msg += Server.Client.MXP_TAG("Id") + " (#" + Server.Client.MXP_TAG("WizItem '" + tool.ID + "'");
                        msg += tool.ID + tool.GetFlags() + Server.Client.MXP_TAG("/WizItem") + ")" + Server.Client.MXP_TAG("/Id");
                    }

                    msg += Environment.NewLine + "  Resources:";
                    foreach (int resourceId in formula.resourceKeys)
                    {
                        ResourceItemTemplate resource = EntityManager.instance.getTemplateByID(resourceId) as ResourceItemTemplate;
                        msg += Environment.NewLine + "   " + resource.Name + " (x" + formula.getResource(resourceId) + ")";
                        if (oUser.HasFlag("Admin") || oUser.HasFlag("Builder") || oUser.HasFlag("Wizard"))
                        {
                            msg += Server.Client.MXP_TAG("Id") + " (#" + Server.Client.MXP_TAG("WizItem '" + resource.ID + "'");
                            msg += resource.ID + resource.GetFlags() + Server.Client.MXP_TAG("/WizItem") + ")" + Server.Client.MXP_TAG("/Id");
                        }
                    }

                    CommandManager.instance.report(MessageScope.CHAR, msg, oUser, null, formula); 
                }

                else
                {
                    ItemInstance instance = entity as ItemInstance;
                    sb.Append("#look_item_self#");
                    sb.Append(Environment.NewLine);
                    sb.Append(this.LookItem(oUser, instance));
                    sb.Append(Environment.NewLine);

                    CommandManager.instance.report(MessageScope.CHAR, sb.ToString(), oUser, null, instance);
                    CommandManager.instance.report(MessageScope.ROOM_LIMITED, "#look_item_other#", oUser, null, instance);
                }
            }
            #endregion

            else
            {
                this.LogError("LookObject", "User[" + oUser.ID + "], Object[" + entity.ID + "] had no known type.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private string LookItem(Character oUser, ItemInstance item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(item.description.CapitalizeFirst());
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            
            // returns details based upon the type of object
            switch (item.itemType.Name.ToLower())
            {
                case "formula":
                    sb.Append(item.explore(oUser));
                    break;

                case "resource node":
                    sb.Append(item.explore(oUser));
                    break;

                case "container":
                    sb.Append(item.explore(oUser));
                    break;

                case "drink container":
                    sb.Append(item.explore(oUser));
                    break;

                // TODO: Other types that might be needing extra details are Armor, Lights, Potions, and Weapons

                default:
                    break;
            }

            sb.Append(Environment.NewLine);
            sb.Append("Properties:");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  Size is {0}.", item.size.convert());
            if (item.material != null)
            {
                sb.AppendFormat("{0}  Composed of {1}.", Environment.NewLine, item.material.Name);
            }
            if (!item.isTakeable)
            {
                sb.AppendFormat("{0}  #not_takeable#", Environment.NewLine);
            }

            // TODO: If Wearable, display the locations
            // TODO: Durability
            
            return sb.ToString();
        }
    }
}
