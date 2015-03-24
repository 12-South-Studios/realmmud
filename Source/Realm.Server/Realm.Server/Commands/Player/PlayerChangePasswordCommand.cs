//using System;
//using System.Configuration;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Common.Security;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Change Password command
//    /// </summary>
//    public class PlayerChangePasswordCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerChangePasswordCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerChangePasswordCommand(int id, string name, Definition definition)
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
//            if (oUser.IsNull()) return;

//            var keyword = oUser.GetLastCommand();
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            var oldPass = keyword.SecondWord();
//            if (string.IsNullOrEmpty(oldPass))
//            {
//                CommandManager.ReportToCharacter("#no_password#", oUser);
//                return;
//            }

//            var newPass = keyword.ThirdWord();
//            if (string.IsNullOrEmpty(newPass))
//            {
//                CommandManager.ReportToCharacter("#no_password#", oUser);
//                return;
//            }

//            var minLength = Game.GetIntConstant("minimumPasswordLength");
//            if (newPass.Length < minLength)
//            {
//                CommandManager.ReportToCharacter("#password_short#", oUser);
//                return;
//            }

//            var maxLength = Game.GetIntConstant("maximumPasswordLength");
//            if (newPass.Length > maxLength)
//            {
//                CommandManager.ReportToCharacter("#password_long#", oUser);
//                return;
//            }

//            // Encrypt the old password
//            var encryptedOldPassword = Password.ComputeHashV1(new PasswordRequestv1
//            {
//                PlainPassword = oldPass,
//                PreHash = oUser.GetProperty<string>("preHashId"),
//                PostHash = oUser.GetProperty<string>("postHashId")
//            });

//            // TODO: Fix this
//            /*var user = DatabaseManager.LiveContext.GetUser((int)oUser.ID);
//            if (user.IsNull() || !user.Password.Equals(encryptedOldPassword))
//            {
//                CommandManager.ReportToCharacter("#invalid_password#", oUser);
//                return;  
//            }*/

//            var maxTries = Convert.ToInt32(ConfigurationManager.AppSettings["maxRandomHashAttempts"]);

//            //// Gets a random Hash entry to append to the front of the new password
//            var preHash = NetworkManager.Hashes.GetRandomHash();
//            //// Gets a random Hash entry (that doesn't match the previous) to append to the 
//            //// end of the new password.
//            var postHash = NetworkManager.Hashes.GetRandomHash(preHash.ID, maxTries);

//            // Encrypt the new password
//            var encryptedNewPassword = Password.ComputeHashV1(new PasswordRequestv1
//            {
//                PlainPassword = newPass,
//                PreHash = preHash.Name,
//                PostHash = postHash.Name
//            });

//            // TODO: Fix this
//            /*if (!DatabaseManager.LiveContext.UpdatePassword((int)oUser.ID, (int)preHash.ID,
//                (int)postHash.ID, encryptedNewPassword))
//            {
//                CommandManager.ReportToCharacter("#invalid_password#", oUser);
//                return;  
//            }*/

//            CommandManager.ReportToCharacter("#password_success#", oUser);
//        }
//    }
//}
