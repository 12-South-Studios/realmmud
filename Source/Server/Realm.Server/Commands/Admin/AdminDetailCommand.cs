//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Server.Properties;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Admin Detail command
//    /// </summary>
//    public class AdminDetailCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminDetailCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminDetailCommand(int id, string name, Definition definition)
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
//            var character = oUser.GetCurrentCharacter();

//            if (CommandManager.AdminFlagCheckAndNotify(oUser, character.Flags))
//                return;

//            if (character.GetProperty<bool>("Admin Details"))
//            {
//                character.SetProperty("Admin Details", false);
//                CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_DETAIL_OFF, oUser);
//            }
//            else
//            {
//                character.SetProperty("Admin Details", true);
//                CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_DETAIL_ON, oUser);
//            }
//        }
//    }
//}
