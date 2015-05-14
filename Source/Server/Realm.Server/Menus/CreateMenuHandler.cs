//// ----------------------------------------------------------------------
//// <copyright file="CreateMenuHandler.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Command;
//using Realm.Library.Common;
//using Realm.Server.Commands;
//using Realm.Server.Properties;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Players
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Handles Character Creation
//    /// </summary>
//    public class CreateMenuHandler : IMenuHandler
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        public void Execute()
//        {
//            Execute(Game.Instance.CurrentUser());
//        }

//        /// <summary>
//        /// Executes the handler
//        /// </summary>
//        public void Execute(GameUser oUser)
//        {
//            var keyword = oUser.GetRawCommand();
//            var verb = keyword.FirstWord();
//            if (string.IsNullOrEmpty(verb))
//            {
//                CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.Character, MessageResources.MSG_NOT_UNDERSTAND, oUser);
//                return;
//            }

//            switch (verb.ToLower())
//            {
//                case "quit":
//                case "logout":
//                case "q":
//                    Quit(oUser);
//                    break;
//                default:
//                    CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.Character, MessageResources.MSG_INVALID_MENU, oUser);
//                    break;
//            }
//        }

//        private static void Quit(GameUser user)
//        {
//            user.UserState = Globals.Globals.UserStateTypes.Quitting;
//            user.SendText(Game.Instance.Properties.GetProperty<string>("quit"));
//            user.TcpUser.Disconnect();
//        }
//    }
//}
