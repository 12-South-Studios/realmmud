//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Attributes;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Zones;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Learn command
//    /// </summary>
//    public class PlayerGatherCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerGatherCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerGatherCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
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

//            Execute(oUser.GetCurrentCharacter(), null, null, keyword, true);
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        /// <param name="oActor"><see cref="Biota"/> object doing the action</param>
//        /// <param name="obj1">first object being acted upon</param>
//        /// <param name="obj2">second object being acted upon</param>
//        /// <param name="aKeyword">Phrase or keyword string</param>
//        /// <param name="aMessage">Flag indicating whether or not to send the message to the client</param>
//        public void Execute(IBiota oActor, IGameEntity obj1, IGameEntity obj2, string aKeyword, bool aMessage = false)
//        {
//            // parse the words and get the items (must be on the ground)
//            var word1 = aKeyword.FirstWord();

//            // Find the target somewhere
//            var validLocs = Globals.Globals.EntityLocationTypes.Space.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, word1, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#nothing_here#", oActor);
//                return;
//            }
//            var oGatherItem = result.FoundEntity as ItemInstance;
//            if (oGatherItem.IsNull()) return;

//            if (!oGatherItem.IsType("resource node"))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("", oActor, null, oGatherItem);
//                return;
//            }

//            // do you have the proper tool equipped?
//            var oEquippedItem = oActor.GetEquippedItem(Globals.Globals.WearLocations.wearhandright);
//            if (null == oEquippedItem)
//            {
//                oEquippedItem = oActor.GetEquippedItem(Globals.Globals.WearLocations.wearhandleft);
//                if (null == oEquippedItem)
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#not_holding_tool#", oActor);
//                    return;
//                }
//            }

//            if (!oEquippedItem.IsType("tool"))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#not_tool#", oActor, null, oEquippedItem);
//                return;
//            }

//            // grab the decorators
//            var node = oGatherItem as ResourceNodeItemInstance;
//            if (node.IsNull()) return;
//            var tool = oEquippedItem as ToolItemInstance;
//            if (tool.IsNull()) return;

//            // is this tool the proper skill?
//            var rtt = node.GetToolType(tool.ToolTypes[0]);
//            if (null == rtt)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#cannot_gather_tool#", 
//                        oActor, null, oEquippedItem, oGatherItem);
//                return;
//            }

//            // does the biote have the proper skill?
//            var skill = oActor.StatisticHandler.GetSkill(tool.ToolTypes[0].GetName());
//            if (skill.IsNull())
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#insuf_skill#", 
//                        oActor, null, oEquippedItem, oGatherItem);
//                return;
//            }

//            // okay, all set, now lets gather
//            var oResource = EntityManager.LuaGetTemplate(rtt.ResourceId) as ItemTemplate;
//            if (oResource.IsNull())
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#cannot_gather#", oActor, null, oGatherItem);
//                return;
//            }

//            // - give it to the player
//            if (oResource.IsStackable)
//                oActor.HoldItem(oResource, rtt.GatherAmount);
//            else
//            {
//                var id = oActor.Inventory.HoldItem(oResource);
//                var instance = EntityManager.LuaGetInstance(id) as ItemInstance;
//                if (instance.IsNull()) return;
//                instance.StackSize = rtt.GatherAmount;
//            }

//            if ((aMessage) && (oActor is Character))
//            {
//                if (rtt.GatherAmount > 1)
//                    CommandManager.ReportToCharacter("#gather_self#", oActor, null, oResource, oGatherItem, null, rtt.GatherAmount);
//                else
//                    CommandManager.ReportToCharacter("#gather_single_self#", oActor, null, oResource, oGatherItem);
//            }

//            if (rtt.GatherAmount > 1)
//                CommandManager.ReportToSpaceLimited("#gather_other#", oActor, null, oResource, oGatherItem, null, rtt.GatherAmount);
//            else
//                CommandManager.ReportToSpaceLimited("#gather_single_other#", oActor, null, oResource, oGatherItem);

//            Game.SetProperty("last gathered", oGatherItem);

//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnGatherItem>(oActor, new EventTable
//                                                              {
//                                                                  {"Space", Space}, 
//                                                                  {"item", oGatherItem}
//                                                              });

//            // do the skill gain, base for ALL gather actions is 5 XP
//            // calculate skill mods
//            // skill.SkillCheck(skill rating + skill mods + att mods + spell mods, rtt.mMinSkill, 5);
//            AttributeUtils.SkillCheck(skill.Rating, rtt.MinimumSkill, 5, true);
//        }
//    }
//}
