//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Properties;
//using Realm.Library.Network.Mxp;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Help command
//    /// </summary>
//    public class PlayerHelpCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerHelpCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerHelpCommand(int id, string name, Definition definition) : base(id, name, definition)
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

//            HelpEntry oHelp;
//            var sb = new StringBuilder();

//            var keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword))
//            {
//                oHelp = HelpManager.Get(string.Empty);
//                if (oHelp.IsNull())
//                {
//                    CommandManager.ReportToCharacter(MessageResources.MSG_HELP_NO_DEFAULT, oUser);
//                    return;
//                }

//                sb.Append(oHelp.Data);
//                while (sb.IndexOf("##$") > -1)
//                {
//                    var start = sb.IndexOf("##$") + 3;
//                    var end = sb.IndexOf("$##");
//                    var entry = sb.Substring(start, end - start);
//                    var helpEntry = MxpResources.MXP_TAG_HELPENTRY_OPEN.MxpTag(entry) + entry +
//                                    MxpResources.MXP_TAG_HELPENTRY_CLOSE.MxpTag();
//                    sb.Replace("##$" + entry + "$##", helpEntry);
//                }

//                CommandManager.ReportToCharacter(MessageResources.MSG_HELP_ENTRY, oUser, null,
//                                                 oHelp.Keyword.CapitalizeFirst(), sb.ToString());
//                return;
//            }

//            // find the help entry
//            oHelp = HelpManager.Get(keyword);
//            if (oHelp.IsNull())
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_HELP_NO_ENTRY, oUser);
//                return;
//            }

//            if (oHelp.Category.IsNotNull())
//            {
//                if (oHelp.Category.Equals("admin", StringComparison.OrdinalIgnoreCase) 
//                    && !oUser.GetCurrentCharacter().Flags.IsAdmin())
//                {
//                    CommandManager.ReportToCharacter(MessageResources.MSG_NOT_AUTHORIZED, oUser);
//                    return;
//                }
//            }

//            sb.Append(oHelp.Data);
//            while (sb.IndexOf("##$") > -1)
//            {
//                if (sb.IndexOf("##$") <= -1) continue;
//                var start = sb.IndexOf("##$") + 3;
//                var end = sb.IndexOf("$##") - 1;
//                var entry = sb.Substring(start, end - start);
//                var helpEntry = MxpResources.MXP_TAG_HELPENTRY_OPEN.MxpTag(entry) + entry +
//                                MxpResources.MXP_TAG_HELPENTRY_CLOSE.MxpTag();
//                sb.Replace("##$" + entry + "$##", helpEntry);
//            }

//            CommandManager.ReportToCharacter(MessageResources.MSG_HELP_ENTRY, oUser, null,
//                                             oHelp.Keyword.CapitalizeFirst(), sb.ToString());
//        }
//    }
//}
