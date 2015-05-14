//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerUnequipCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerUnequipCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerUnequipCommand(int id, string name, Definition definition)
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
//            var validLocs = Globals.Globals.EntityLocationTypes.Equipment.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, aKeyword, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#not_wearing#", oActor);
//                return;
//            }
//            var oItem = result.FoundEntity as ItemInstance;
//            if (oItem.IsNull()) return;

//            // unequip it
//            if (oActor.UnequipItem(oItem) == 0)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#cannot_remove#", oActor, null, oItem);
//                return;
//            }

//            string actorMsg;
//            string otherMsg;

//            if (oItem.IsType("armor"))
//            {
//                actorMsg = "#remove_armor_self#";
//                otherMsg = "#remove_armor_other#";
//            }
//            else if (oItem.IsType("weapon"))
//            {
//                actorMsg = "#remove_weapon_self#";
//                otherMsg = "#remove_weapon_other#";
//            }
//            else
//            {
//                actorMsg = "#remove_item_self#";
//                otherMsg = "#remove_item_other#";
//            }

//            if ((aMessage) && (oActor is Character))
//                CommandManager.ReportToCharacter(actorMsg, oActor, null, oItem);
//            CommandManager.ReportToSpaceLimited(otherMsg, oActor, null, oItem);

//            Game.SetProperty("last unequipped", oItem);
//        }
//    }
//}
