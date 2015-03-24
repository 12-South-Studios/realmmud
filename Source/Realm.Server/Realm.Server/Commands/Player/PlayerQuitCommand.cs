//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Quit command
//    /// </summary>
//    public class PlayerQuitCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerQuitCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerQuitCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            // do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            if (oUser.IsNull()) return;

//            oUser.UserState = Globals.Globals.UserStateTypes.Quitting;
//            CommandManager.ReportToSpaceLimited("#quit_other#", oUser, null, null, null, oUser.GetCurrentCharacter().Location);
//            oUser.Quit(true);
//        }
//    }
//}
