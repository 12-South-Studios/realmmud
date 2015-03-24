//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerDropCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerDropCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerDropCommand(int id, string name, Definition definition)
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
//            var validLocs = Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, aKeyword, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#no_item#", oActor);
//                return;
//            }
//            var oDropItem = result.FoundEntity as ItemInstance;
//            if (oDropItem.IsNull()) return;

//            // TODO: : Can the item be unequipped (cursed)?

//            if (oActor.IsWearing(oDropItem))
//                oActor.UnequipItem(oDropItem);

//            // TODO: : Can the item be dropped (cursed)?

//            // Insufficient quantity
//            if (result.Quantity > oDropItem.StackSize)
//                result.Quantity = oDropItem.StackSize;

//            // You drop them all
//            if (result.Quantity == oDropItem.StackSize)
//            {
//                oActor.Inventory.DropItem(oDropItem);
//                oActor.Location.AddEntity(oDropItem);
//                Game.SetProperty("last dropped", oDropItem);
//            }
//            else
//            {
//                oDropItem.StackSize -= result.Quantity;

//                var newItem = Game.CreateItemInstance(EntityManager, Game.Logger,
//                    oDropItem.Parent as ItemTemplate);
//                newItem.StackSize = result.Quantity;
//                oActor.Location.AddEntity(newItem);
//                Game.SetProperty("last dropped", newItem);
//            }

//            if (result.Quantity > 1)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#drop_item_stack_self#", oActor, null, oDropItem, null, null, result.Quantity);
//                CommandManager.ReportToSpaceLimited("#drop_item_stack_other#", oActor, null, oDropItem, null, null, result.Quantity);
//            }
//            else
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#drop_item_self#", oActor, null, oDropItem);
//                CommandManager.ReportToSpaceLimited("#drop_item_other#", oActor, null, oDropItem);
//            }

//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnDropItem>(oActor, new EventTable
//                                                            {
//                                                                { "Space", Space },
//                                                                { "item", oDropItem }
//                                                            });
//        }
//    }
//}
