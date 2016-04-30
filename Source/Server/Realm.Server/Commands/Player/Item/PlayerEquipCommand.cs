//using System;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerEquipCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerEquipCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerEquipCommand(int id, string name, Definition definition)
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
//            var validLocs = Globals.Globals.EntityLocationTypes.Inventory.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, aKeyword, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#no_item#", oActor);
//                return;
//            }
//            var oItem = result.FoundEntity as ItemInstance;
//            if (oItem.IsNull()) return;

//            // is it wearable?
//            if (!oItem.CanBeWorn(oActor))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#cannot_wear#", oActor, null, oItem);
//                return;
//            }

//            // failed to equip it
//            if (oActor.EquipItem(oItem) == 0)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#unable_wear#", oActor, null, oItem);
//                return;
//            }

//            var wearLoc = oItem.GetWearLocation(1);
//            string actorMsg;
//            string otherMsg;

//            if (wearLoc.GetName().ToLower().IndexOf("both", StringComparison.Ordinal) > -1)
//            {
//                actorMsg = "#wear_2h_self#";
//                otherMsg = "#wear_2h_other#";
//            }
//            else if (wearLoc.GetName().ToLower().IndexOf("left", StringComparison.Ordinal) > -1)
//            {
//                actorMsg = "#wear_left_self#";
//                otherMsg = "#wear_left_other#";
//            }
//            else if (wearLoc.GetName().ToLower().IndexOf("right", StringComparison.Ordinal) > -1)
//            {
//                actorMsg = "#wear_right_self#";
//                otherMsg = "#wear_right_other#";
//            }
//            else
//            {
//                actorMsg = "#wear_loc_self#";
//                otherMsg = "#wear_loc_other#";
//            }

//            if ((aMessage) && (oActor is Character))
//                CommandManager.ReportToCharacter(actorMsg, oActor, null, oItem);
//            CommandManager.ReportToSpaceLimited(otherMsg, oActor, null, oItem);

//            Game.SetProperty("last equipped", oItem);

//            EventManager.ThrowEvent<OnEquipItem>(oActor, new EventTable
//                                                             {
//                                                                 {"item", oItem}, 
//                                                                 {"wear_location", wearLoc},
//                                                                 {"biote", oActor}
//                                                             });
//        }
//    }
//}
