//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Item;
//using Realm.Server.Properties;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Admin Create command
//    /// </summary>
//    public class AdminCreateCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminCreateCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminCreateCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
//        {
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
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            var item = EntityManager.LuaGetTemplate(keyword) as ItemTemplate;
//            if (item.IsNull())
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_NO_ITEM, oUser);
//                return;
//            }

//            if (!item.IsTakeable)
//            {
//                var instance = Game.CreateAndPlaceItemInstance(EntityManager, Log,
//                    character.Location, item);
//                if (instance.IsNull())
//                {
//                    Log.ErrorFormat("Failed to create a new item[{0}] for Character[{1}, {2}]", keyword,
//                        character.ID, character.Name);
//                    CommandManager.ReportToCharacter(MessageResources.MSG_ERR, oUser);
//                    return;
//                }

//                CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_CREATE_SELF, oUser, null, instance);
//                CommandManager.ReportToSpaceLimited(MessageResources.MSG_ADMIN_CREATE_OTHER, oUser, null, instance);
//            }
//            else
//            {
//                var instance = Game.CreateAndPlaceItemInstance(EntityManager, Log, character, item);
//                if (instance.IsNull())
//                {
//                    Log.ErrorFormat("Failed to create a new item[{0}] for Character[{1}, {2}]", keyword,
//                        character.ID, character.Name);
//                    CommandManager.ReportToCharacter(MessageResources.MSG_ERR, oUser);
//                    return;
//                }

//                CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_CREATE_INV, oUser, null, instance);
//            }
//        }
//    }
//}
