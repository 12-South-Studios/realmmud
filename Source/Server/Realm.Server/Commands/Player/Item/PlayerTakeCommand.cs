//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Properties;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerTakeCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerTakeCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerTakeCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
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
//            // Find the target somewhere
//            var validLocs = Globals.Globals.EntityLocationTypes.Space.GetValue()
//                | Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue()
//                | Globals.Globals.EntityLocationTypes.Container.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, aKeyword, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter(MessageResources.MSG_NO_ITEM, oActor);
//                return;
//            }
//            var oTakeItem = result.FoundEntity as ItemInstance;
//            if (oTakeItem.IsNull()) return;
//            ItemInstance oFromItem = null;

//            if (result.FoundEntityLocationType == Globals.Globals.EntityLocationTypes.Container)
//                oFromItem = result.FoundEntityLocation as ItemInstance;

//            // the items can't be the same
//            if (oTakeItem == oFromItem)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#cant_do_that#", oActor);
//                return;
//            }

//            // is the item takeable?
//            if (!oTakeItem.IsTakeable)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#item_not_takeable#", oActor, null, oTakeItem);
//                return;
//            }

//            // Insufficient quantity
//            if (result.Quantity > oTakeItem.StackSize)
//                result.Quantity = oTakeItem.StackSize;

//            if (null != oFromItem)
//            {
//                // from item is not a container
//                if (!oFromItem.IsType("container"))
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#not_container#", oActor, null, oFromItem);
//                    return;
//                }

//                // is the container closed?
//                var container = oFromItem as ContainerItemInstance;
//                if (container.IsNull()) return;
//                if (container.IsClosed)
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#item_closed#", oActor, null, oFromItem);
//                    return;
//                }

//                // TODO: : can the biote carry this much weight?

//                // TODO: : if the item is on fire, you must have free hands (can't put a flaming item into inventory)

//                // You take them all
//                if (result.Quantity == oTakeItem.StackSize)
//                {
//                    oFromItem.RemoveEntity(oTakeItem);
//                    oActor.HoldItem(oTakeItem);
//                    Game.SetProperty("last taken", oTakeItem);
//                }
//                else
//                {
//                    oTakeItem.StackSize -= result.Quantity;

//                    var newItem = Game.CreateItemInstance(EntityManager, Game.Logger,
//                        oTakeItem.Parent as ItemTemplate);
//                    newItem.StackSize = result.Quantity;
//                    oActor.HoldItem(newItem);
//                    Game.SetProperty("last taken", newItem);

//                    if (oTakeItem.StackSize == 0)
//                    {
//                        oTakeItem.Location.RemoveEntity(oTakeItem);
//                        EntityManager.RecycleEntity(oTakeItem);
//                    }
//                }

//                if (result.Quantity > 1)
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#take_item_stack_container_self#",
//                            oActor, null, oTakeItem, oFromItem, null, result.Quantity);
//                    CommandManager.ReportToSpaceLimited("#take_item_stack_container_other#",
//                        oActor, null, oTakeItem, oFromItem, null, result.Quantity);
//                }
//                else
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#take_item_container_self#", oActor, null, oTakeItem, oFromItem);
//                    CommandManager.ReportToSpaceLimited("#take_item_container_other#", oActor, null, oTakeItem, oFromItem);
//                }
//            }
//            else
//            {
//                // TODO: : can the biote carry this much weight?

//                // TODO: : if the item is on fire, you must have free hands (can't put a flaming item into inventory)

//                // You take them all
//                if (result.Quantity == oTakeItem.StackSize)
//                {
//                    oActor.Location.RemoveEntity(oTakeItem);
//                    oActor.HoldItem(oTakeItem);
//                    Game.SetProperty("last taken", oTakeItem);
//                }
//                else
//                {
//                    oTakeItem.StackSize -= result.Quantity;

//                    var newItem = Game.CreateItemInstance(EntityManager, Game.Logger,
//                        oTakeItem.Parent as ItemTemplate);
//                    newItem.StackSize = result.Quantity;
//                    oActor.HoldItem(newItem);
//                    Game.SetProperty("last taken", newItem);
//                }

//                if (result.Quantity > 1)
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#take_item_stack_self#", oActor, null, oTakeItem, null, null, result.Quantity);
//                    CommandManager.ReportToSpaceLimited("#take_item_stack_other#", oActor, null, oTakeItem, null, null, result.Quantity);
//                }
//                else
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#take_item_self#", oActor, null, oTakeItem);
//                    CommandManager.ReportToSpaceLimited("#take_item_other#", oActor, null, oTakeItem);
//                }
//            }

//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnTakeItem>(oActor, new EventTable
//                                                            {
//                                                                { "Space", Space }, 
//                                                                { "item", oTakeItem }
//                                                            });
//        }
//    }
//}
