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
//    public class PlayerFillCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerFillCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerFillCommand(int id, string name, Definition definition)
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
//            var destination = aKeyword.FirstWord();
//            var source = aKeyword.SecondWord();

//            // Find the destination somewhere
//            var validLocs = Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue()
//                | Globals.Globals.EntityLocationTypes.Space.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, destination, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#no_item#", oActor);
//                return;
//            }

//            var oContainer = result.FoundEntity as ItemInstance;
//            if (oContainer.IsNull()) return;

//            if (!oContainer.IsType("drink container"))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#not_dcon_target#", oActor, null, oContainer);
//                return;
//            }

//            // Find the source
//            validLocs = Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue()
//                | Globals.Globals.EntityLocationTypes.Space.GetValue();
//            result = TargetLocation.FindTargetEntity(oActor, source, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#no_item#", oActor);
//                return;
//            }

//            var oSource = result.FoundEntity as ItemInstance;
//            if (oSource.IsNull()) return;

//            if (!oSource.IsType("drink container"))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#not_dcont_source#", oActor, null, oSource);
//                return;
//            }

//            var drinkDest = oContainer as DrinkContainerItemInstance;
//            var sourceDest = oSource as DrinkContainerItemInstance;
//            if (drinkDest.IsNull() || sourceDest.IsNull()) return;

//            // is the destination full?
//            if (drinkDest.IsFull)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_full#", oActor, null, oContainer);
//                return;
//            }

//            // is the source empty?
//            if (sourceDest.IsEmpty)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_empty#", oActor, null, oSource);
//                return;
//            }

//            // is the destination container empty?
//            if (drinkDest.IsEmpty)
//                drinkDest.FilledWith = sourceDest.FilledWith;

//            // source and destination liquids must be the same
//            if (drinkDest.FilledWith != sourceDest.FilledWith)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_cannot_mix#",
//                        oActor, null, drinkDest.FilledWith.Name, sourceDest.FilledWith.Name);
//                return;
//            }

//            // fill the container
//            var needed = drinkDest.MaxCharges - drinkDest.CurrentCharges;

//            // -1 for max charges means its an infinite source (lake, river, fountain)
//            if (sourceDest.MaxCharges == -1)
//            {
//                drinkDest.CurrentCharges = needed;

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_fill_infinite_self#", oActor,
//                        oContainer, oSource, sourceDest.FilledWith.Name);
//                CommandManager.ReportToSpaceLimited("#dcon_fill_infinite_other#", oActor,
//                    oContainer, oSource, sourceDest.FilledWith.Name);
//            }

//            // Amount left in source is equal to amount needed in destination
//            else if (needed == sourceDest.CurrentCharges)
//            {
//                drinkDest.CurrentCharges = needed;
//                sourceDest.CurrentCharges = 0;

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_empty_source_self#",
//                        oActor, null, oContainer, oSource);
//                CommandManager.ReportToSpaceLimited("#dcon_empty_source_other#",
//                    oActor, null, oContainer, oSource);
//            }

//             // Amount left in source is less than the amount needed in destination
//            else if (needed > sourceDest.CurrentCharges)
//            {
//                drinkDest.CurrentCharges = sourceDest.CurrentCharges;
//                sourceDest.CurrentCharges = 0;

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_fill_target_self#",
//                        oActor, null, oContainer, oSource);
//                CommandManager.ReportToSpaceLimited("#dcon_fill_target_other#",
//                    oActor, null, oContainer, oSource);
//            }

//            // Amount left in source is more than the amount needed in destination
//            else
//            {
//                drinkDest.CurrentCharges = needed;
//                sourceDest.CurrentCharges -= needed;

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#dcon_fill_self#", oActor,
//                        oContainer, oSource, sourceDest.FilledWith.Name);
//                CommandManager.ReportToSpaceLimited("#dcon_fill_other#", oActor,
//                    oContainer, oSource, sourceDest.FilledWith.Name);
//            }

//            Game.SetProperty("last filled", oContainer);
//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnFillItem>(oActor, new EventTable
//                                                            {
//                                                                {"Space", Space},
//                                                                {"item", oContainer}
//                                                            });
//        }
//    }
//}
