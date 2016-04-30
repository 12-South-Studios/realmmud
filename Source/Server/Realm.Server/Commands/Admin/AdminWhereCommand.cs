//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Players;
//using Realm.Server.Properties;
//using Realm.Server.Zones;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Admin Create command
//    /// </summary>
//    public class AdminWhereCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminWhereCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminWhereCommand(int id, string name, Definition definition)
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
//            var keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword))
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_WHERE_NO_CHAR, oUser);
//                return;
//            }

//            var entity = EntityManager.LuaGetInstance(keyword);
//            if (entity.IsNull())
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_WHERE_NO_CHAR, oUser);
//                return;
//            }

//            if (!(entity is Character))
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_WHERE_NOT_PLAYER, oUser, null, keyword);
//                return;
//            }

//            var space = character.Location as Space;
//            CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_WHERE, oUser, character, null, null, space, space.ID);
//        }
//    }
//}
