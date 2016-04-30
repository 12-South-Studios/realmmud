//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Properties;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Quit command
//    /// </summary>
//    public class PlayerTimeCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerTimeCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerTimeCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var gameState = TimeManager.GameState;

//            var sb = new StringBuilder();
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat(MessageResources.MSG_TIME, gameState.Hour.ConvertHour(), gameState.Hour.ToPeriodOfDay());

//            sb.Append(Environment.NewLine);
//            if (gameState.Month.IsShrouding)
//                sb.AppendFormat(MessageResources.MSG_DATE_SHROUDING, gameState.Month.Name, gameState.Year);
//            else
//            {
//                sb.AppendFormat(MessageResources.MSG_DATE_NOT_SHROUDING, gameState.Day.GetOrdinal(),
//                    gameState.Month.Name, gameState.Year);
//            }

//            CommandManager.ReportToCharacter(sb.ToString(), oUser);
//        }
//    }
//}
