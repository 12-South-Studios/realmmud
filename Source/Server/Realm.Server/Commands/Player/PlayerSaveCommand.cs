//using System;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Patterns.Command;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Save command
//    /// </summary>
//    public class PlayerSaveCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerSaveCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerSaveCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            // do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var character = oUser.GetCurrentCharacter();

//            string keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword)
//                || keyword.Equals("me", StringComparison.OrdinalIgnoreCase)
//                || keyword.Equals(character.Name, StringComparison.OrdinalIgnoreCase)
//                || keyword.Equals(character.ID.ToString(), StringComparison.OrdinalIgnoreCase))
//            {
//                if (oUser.Save())
//                    CommandManager.ReportToCharacter("#save#", oUser, null, DateTime.Now.ToString());
//            }
//        }
//    }
//}
