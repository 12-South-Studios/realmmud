//using System;
//using System.Text;
//using Realm.Data.Definitions;
//using Realm.Library.Patterns.Command;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// who command
//    /// </summary>
//    public class PlayerWhoCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerWhoCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerWhoCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            // do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();

//            //// Header
//            var sb = new StringBuilder();
//            sb.Append("====================");
//            sb.Append(" ONLINE PLAYER LIST ");
//            sb.Append("====================");
//            sb.Append(Environment.NewLine);

//            var hiddenCount = 0;
//            var totalCount = Game.UserRepository.Count;

//            //// Body
//            foreach(var user in Game.UserRepository.Values)
//            {
//                if (user.UserState != Globals.Globals.UserStateTypes.LoggedIn) 
//                {
//                    hiddenCount++;
//                    continue;
//                }

//                var character = oUser.GetCurrentCharacter();
//                var name = character.Name;
//                var title = character.GetStringProperty("title");
//                var note = character.Note;

//                if (!string.IsNullOrEmpty(title))
//                    name += title;
//                name = name.PadRight(30, ' ');

//                if (character.Flags.HasFlag("F"))
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append(" [AFK] ");
//                }
//                else if (character.Flags.IsAdmin())
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append(" [ADM] ");
//                }
//                else if (character.Flags.IsWizard())
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append(" [WIZ] ");
//                }

//                sb.Append(name);
//                sb.Append(" | ");
//                sb.Append(note);
//            }

//            //// Footer
//            sb.Append(Environment.NewLine);
//            sb.Append(Environment.NewLine);
//            sb.Append("============================================================");

//            totalCount -= hiddenCount;
//            var msg = Environment.NewLine + "There {0} {1} {2} online.";
//            switch (totalCount)
//            {
//                case 0:
//                    sb.AppendFormat(msg, "are", "no", "characters");
//                    break;
//                case 1:
//                    sb.AppendFormat(msg, "is", "1", "character");
//                    break;
//                default:
//                    sb.AppendFormat(msg, "are", totalCount, "characters");
//                    break;
//            }
//            oUser.SendText(sb.ToString());
//        }
//    }
//}
