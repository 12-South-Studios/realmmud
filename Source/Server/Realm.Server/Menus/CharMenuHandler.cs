//// ----------------------------------------------------------------------
//// <copyright file="CharMenuHandler.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Command;
//using Realm.Library.Common;
//using Realm.Server.Channels;
//using Realm.Server.Commands;
//using Realm.Server.Properties;

//
//namespace Realm.Server.Players
//
//{
//    /// <summary>
//    /// Handles the Character Menu
//    /// </summary>
//    public class CharMenuHandler : IMenuHandler
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
//        public void Execute(GameUser user)
//        {
//            var keyword = user.GetRawCommand();
//            var verb = keyword.FirstWord();
//            if (string.IsNullOrEmpty(verb))
//            {
//                CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.Character, MessageResources.MSG_NOT_UNDERSTAND, user);
//                return;
//            }

//            switch (verb.ToLower())
//            {
//                case "@createChar":
//                    CreateCharacter(user);
//                    break;
//                case "@selectChar":
//                    LoginCharacter(user);
//                    break;
//                case "@deleteChar":
//                    DeleteCharacter(user);
//                    break;
//                case "quit":
//                case "logout":
//                case "q":
//                    Quit(user);
//                    break;
//                default:
//                    CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.Character, MessageResources.MSG_INVALID_MENU, user);
//                    break;
//            }
//        }

//        private static void CreateCharacter(GameUser user)
//        {
//            CommandManager.Instance.Execute(user, "playercreatecharacter");
//        }

//        private static void LoginCharacter(GameUser user)
//        {
//            CommandManager.Instance.Execute(user, "playerlogincharacter");
//        }

//        private static void DeleteCharacter(GameUser user)
//        {
//            CommandManager.Instance.Execute(user, "playerdeletecharacter");
//        }

//        private static void Quit(GameUser user)
//        {
//            user.UserState = Globals.Globals.UserStateTypes.Quitting;
//            user.SendText(Game.Instance.Properties.GetProperty<string>("quit"));
//            user.TcpUser.Disconnect();
//        }
//    }
//}
