//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
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
//    /// Bind command
//    /// </summary>
//    public class PlayerDrinkCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerDrinkCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerDrinkCommand(int id, string name, Definition definition)
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
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue()
//                | Globals.Globals.EntityLocationTypes.Space.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, aKeyword, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#no_item#", oActor);
//                return;
//            }
//            var oTakeItem = result.FoundEntity as ItemInstance;
//            if (oTakeItem.IsNull()) return;

//            // is it a drink container?
//            if (!oTakeItem.IsType("drink container"))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#cannot_drink#", oActor, null, oTakeItem);
//                return;
//            }

//            // is it empty?
//            var drink = oTakeItem as DrinkContainerItemInstance;
//            if (drink.IsNull()) return;

//            var currentCharges = drink.CurrentCharges;
//            if (currentCharges <= 0)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_empty#", oActor, null, oTakeItem);
//                return;
//            }

//            // are you satiated?
//            int thirst = oActor.GetIntProperty("thirst counter");
//            int maxThirst = Game.GetProperty<int>("max thirst");

//            if (thirst >= maxThirst)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#too_satiated#", oActor);
//                return;
//            }

//            // TODO: :  Is it a potion?

//            // TODO: :  Is it a poison?

//            // -1 max charges means its infinite (like a river or stream)
//            if (drink.MaxCharges > -1)
//                drink.CurrentCharges -= 1;

//            // if you drink while you're dying of thirst, you get back to 0
//            if (oActor is Character)
//            {
//                if (thirst < 0)
//                    oActor.SetProperty("thirst counter", 0);
//                else
//                {
//                    thirst = drink.FilledWith.ThirstPoints * 60;
//                    if (thirst >= maxThirst)
//                        thirst = maxThirst;
//                    oActor.SetProperty("thirst counter", thirst);
//                }
//            }

//            // TODO: : Handle Drunkenness

//            // check for an empty container
//            if ((drink.MaxCharges > -1) && (currentCharges == 0))
//            {
//                drink.FilledWith = null;

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#drink_remainder_self#", oActor, null, oTakeItem);
//                CommandManager.ReportToSpaceLimited("#drink_remainder_other#", oActor, null, oTakeItem);
//            }
//            else
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#drink_self#", oActor, null, oTakeItem, drink.FilledWith);
//                CommandManager.ReportToSpaceLimited("#drink_other#", oActor, null, oTakeItem, drink.FilledWith);
//            }

//            Game.SetProperty("last drank", oTakeItem);
//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnDrinkItem>(oActor, new EventTable
//                                                             {
//                                                                 {"Space", Space}, 
//                                                                 {"item", oTakeItem}
//                                                             });
//        }
//    }
//}
