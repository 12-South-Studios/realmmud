/*
using System;
using Realm.Command;
using Realm.Data.Definitions;
using Realm.Library.Common;
using Realm.Library.Common.Exceptions;


namespace Realm.Server.Players

{
    /// <summary>
    /// Login Player command
    /// </summary>
    public class LoginPlayerCommand : GameCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPlayerCommand"/> class
        /// </summary>
        /// <param name="name">Name of the command</param>
        /// <param name="keywords">Keywords of the command</param>
        /// <param name="action">Log action to take when executed</param>
        public LoginPlayerCommand(int id, string name, Definition definition)
            : base(id, name, definition)
        {
            // do nothing
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <exception cref="GeneralException">GeneralException is thrown if the current user object is null</exception>
        public override void Execute()
        {
            var oUser = Game.CurrentUser();
            try
            {
                if (oUser.IsNull())
                    throw new GeneralException("Null user");

                var keyword = oUser.GetRawCommand();
                if (string.IsNullOrEmpty(keyword))
                {
                    // TODO: LoginPlayer, no string data entered
                    return;
                }

                var uname = keyword.SecondWord();
                if (string.IsNullOrEmpty(uname))
                    uname = " ";
                if (!ValidateAndNotifyUsername(oUser, uname))
                    return;

                var pass = keyword.ThirdWord();
                if (string.IsNullOrEmpty(pass))
                {
                    CommandManager.ReportToCharacter(MessageResources.MSG_NOT_UNDERSTAND, oUser);
                    return;
                }

                //// Valid user check
                // TODO: Fix this
                /*var user = DatabaseManager.LiveContext.GetUser(uname);
                if (user.IsNull())
                {
                    CommandManager.ReportToCharacter("#invalid_login#", oUser);
                    return;
                }

                //// Backdoor password check
                if (!pass.Equals(Game.GetStringConstant("adminBackdoorPassword")))
                {
                    var preHash = NetworkManager.Hashes.GetHash(user.PreHashID);
                    var postHash = NetworkManager.Hashes.GetHash(user.PostHashID);

                    if (!Password.ValidatePasswordHashV1(pass, user.Password, preHash.Name, postHash.Name))
                    {
                        CommandManager.ReportToCharacter("#invalid_password#", oUser);
                        return;
                    }

                    oUser.Properties.SetProperty("PreHashID", user.PreHashID);
                    oUser.Properties.SetProperty("PostHashID", user.PostHashID);
                }

                //// Record the login
                DatabaseManager.LiveContext.LoginUser(user.UserID, oUser.TcpUser.IpAddress);
                oUser.ID = user.UserID;
                oUser.Load();*/
/*            }
            catch (Exception ex)
            {
                Game.Logger.Error(ex);
            }
        }

        public bool ValidateAndNotifyUsername(GameUser oUser, string username)
        {
            //if (username.Length > Game.Instance.Properties.GetIntProperty("username_max_len"))
            if (username.Length > Game.GetIntConstant("maximumUsernameLength").GetValueOrDefault(64))
            {
                CommandManager.ReportToCharacter(MessageResources.MSG_USERNAME_LONG, oUser);
                return false;
            }

            if (username.Length < Game.GetIntConstant("minimumUsernameLength").GetValueOrDefault(3))
            {
                CommandManager.ReportToCharacter(MessageResources.MSG_USERNAME_SHORT, oUser);
                return false;
            }
            return true;
        }
    }
}*/