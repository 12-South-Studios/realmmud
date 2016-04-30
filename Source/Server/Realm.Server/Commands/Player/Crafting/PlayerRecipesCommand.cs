//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Item;
//using Realm.Library.Network.Mxp;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Change Password command
//    /// </summary>
//    public class PlayerRecipesCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerRecipesCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerRecipesCommand(int id, string name, Definition definition) : base(id, name, definition)
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

//            var sb = new StringBuilder();
//            sb.Append("#recipes#");
//            sb.Append(Environment.NewLine);

//            if (character.RecipeRepository.Count == 0)
//            {
//                sb.Append(Environment.NewLine);
//                sb.Append("  #nothing#");
//                CommandManager.ReportToCharacter(sb.ToString(), oUser);
//                return;
//            }

//            foreach(var recipeId in character.RecipeRepository.Keys)
//            {
//                var formula = EntityManager.LuaGetTemplate(recipeId) as FormulaItemTemplate;
//                if (formula.IsNull()) continue;

//                var beginMxpTag = ("Recipe '" + formula.ID + "' '" + formula.Name + "'").MxpTag();
//                var endMxpTag = "/Recipe".MxpTag();

//                if (character.Flags.IsBuilder())
//                {
//                    sb.AppendFormat("{0}  {1}{2}{3}", Environment.NewLine, beginMxpTag, formula.Name.AddArticle(), endMxpTag);
//                    sb.AppendFormat(" (#{0}{1}{2}{3})", ("WizItem '" + formula.ID + "'").MxpTag(), formula.ID, formula.GetFlags(), 
//                        "/WizItem".MxpTag());
//                }
//                else
//                    sb.AppendFormat("{0}  {1}{2}{3}", Environment.NewLine, beginMxpTag, formula.Name.AddArticle(), endMxpTag);
//            }

//            CommandManager.ReportToCharacter(sb.ToString(), oUser);
//        }
//    }
//}
