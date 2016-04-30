//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Item;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Unlearn command
//    /// </summary>
//    public class PlayerUnearnCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerUnearnCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerUnearnCommand(int id, string name, Definition definition)
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

//            //// parse the words and get the items (must be on the ground)
//            var word1 = keyword.FirstWord();

//            // Do you know this formula?
//            var entity = EntityManager.LuaGetTemplate(word1);
//            if (null == entity)
//            {
//                CommandManager.ReportToCharacter("#no_recipe#", oUser);
//                return;
//            }

//            // Do you already know it?
//            var oItem = entity as ItemTemplate;
//            if (oItem.IsNull()) return;
//            if (oUser.GetCurrentCharacter().RecipeRepository.Contains(oItem.ID))
//            {
//                CommandManager.ReportToCharacter("#dont_know_recipe#", oUser);
//                return;
//            }

//            // Unlearn it!
//            oUser.GetCurrentCharacter().RecipeRepository.Delete(oItem.ID);

//            CommandManager.ReportToCharacter("#unlearn_self#", oUser, null, oItem);
//            CommandManager.ReportToCharacter("#unlearn_other#", oUser, null, oItem);
//        }
//    }
//}
