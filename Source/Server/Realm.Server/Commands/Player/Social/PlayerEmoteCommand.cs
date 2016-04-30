//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Patterns.Command;
//using Realm.Server.NPC;
//using Realm.Server.Players;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// emote command
//    /// </summary>
//    public class PlayerEmoteCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerEmoteCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerEmoteCommand(int id, string name, Definition definition) : base(id, name, definition)
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
//            if (string.IsNullOrEmpty(keyword))
//            {
//                CommandManager.ReportToCharacter("#emote_what#", oUser);
//                return;
//            }

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
//        public void Execute(IBiota oActor, GameEntityTemplate obj1, GameEntityTemplate obj2, string aKeyword, bool aMessage = false)
//        {
//            if (aKeyword.ToLower().IndexOf("roll", System.StringComparison.Ordinal) != -1)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#emote_roll#", oActor);
//                Game.Logger.WarnFormat("{0} [{1}] attempted to use emote to falsify a ROLL command.", oActor.Name, oActor.ID);
//                return;
//            }

//            if (aMessage && oActor is Character)
//                CommandManager.ReportToCharacter("#emote_self#", oActor, null, aKeyword);
//            CommandManager.ReportToSpaceLimited("#emote_other#", oActor, null, aKeyword);
//        }
//    }
//}
