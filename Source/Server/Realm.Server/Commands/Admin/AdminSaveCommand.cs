//using System;
//using System.Linq;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Players;
//using Realm.Server.Properties;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Admin Save command
//    /// </summary>
//    public class AdminSaveCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminSaveCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminSaveCommand(int id, string name, Definition definition)
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

//            if (CommandManager.AdminFlagCheckAndNotify(oUser, character.Flags)) return;

//            string keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword) || keyword.Equals("all", StringComparison.OrdinalIgnoreCase))
//            {
//                CommandManager.Report(Globals.Globals.MessageScopeTypes.Game,
//                    MessageResources.MSG_ADMIN_SAVE, oUser);
//                foreach (var oTarget in Game.UserRepository.Values.Where(oTarget => oTarget.Save()))
//                {
//                    CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_SAVE_SELF, oUser, oTarget, DateTime.Now.ToString());
//                    CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_SAVE_TARGET, oTarget, null, DateTime.Now.ToString());
//                }
//            }
//            else
//            {
//                var oTarget = EntityManager.LuaGetInstance(keyword) as Character;
//                if (oTarget.IsNull())
//                {
//                    CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_SAVE_NOT_FOUND, oUser, null, keyword);
//                    return;
//                }

//                if (oTarget.User.Save())
//                    CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_SAVE_OTHER, oUser, oTarget, DateTime.Now.ToString());
//            }
//        }
//    }
//}
