// ReSharper disable CheckNamespace
namespace Realm.Server.Commands
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSelectCharacterCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Execute()
        {
            /*var oUser = Game.CurrentUser();
            if (oUser.IsNull()) return;

            var keyword = oUser.GetRawCommand();
            if (String.IsNullOrEmpty(keyword))
            {
                Log.Error("No raw command found");
                return;
            }

            var verb = keyword.FirstWord();
            if (String.IsNullOrEmpty(verb))
            {
                Log.ErrorFormat("No verb found {0}", keyword);
                return;
            }

            var character = keyword.SecondWord();
            if (String.IsNullOrEmpty(character))
            {
                CommandManager.ReportToCharacter("#invalid_character#", oUser);
                return;
            }

            if (!oUser.Characters.SelectCharacter(character))
            {
                Log.ErrorFormat("Failure to load character[{0}]", character);
                CommandManager.ReportToCharacter("#character_load_failure#", oUser);
                return;
            }

            oUser.UserState = Globals.Globals.UserStateTypes.LoggedIn;
            Game.Properties.SetProperty("last entered game", oUser);
            //Game.Instance.ThrowOnGameEnter(oUser.Characters.Character, new RealmEventArgs("GameEnter"));*/
        }
    }
}
