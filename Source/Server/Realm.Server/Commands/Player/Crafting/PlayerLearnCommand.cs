//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Item;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Learn command
//    /// </summary>
//    public class PlayerLearnCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerLearnCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerLearnCommand(int id, string name, Definition definition) : base(id, name, definition)
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

//            // Find the target somewhere
//            var validLocs = Globals.Globals.EntityLocationTypes.Space.GetValue();
//            var result = TargetLocation.FindTargetEntity(oUser.GetCurrentCharacter(), word1, validLocs);
//            if (null == result.FoundEntity)
//            {
//                CommandManager.ReportToCharacter("#nothing_here#", oUser);
//                return;
//            }
//            var oItem = result.FoundEntity as ItemInstance;
//            if (oItem.IsNull()) return;

//            // Is it a formula?
//            if (!oItem.IsType("formula"))
//            {
//                CommandManager.ReportToCharacter("#cannot_learn#", oUser);
//                return;
//            }

//            //// Do you already know it?
//            var character = oUser.GetCurrentCharacter();
//            if (character.RecipeRepository.Contains(oItem.Parent.ID))
//            {
//                CommandManager.ReportToCharacter("#already_know_recipe#", oUser);
//                return;
//            }

//            // TODO: : Can you learn it (skill, level, race, faction check)?

//            //// Learn it!
//            character.RecipeRepository.Add(oItem.Parent.ID, oItem.Parent as FormulaItemTemplate);
//            character.Inventory.Contents.RemoveEntity(oItem);

//            CommandManager.ReportToCharacter("#learn_self#", oUser, null, oItem);
//            CommandManager.ReportToCharacter("#learn_other#", oUser, null, oItem);

//            EntityManager.RecycleEntity(oItem);
//        }
//    }
//}
