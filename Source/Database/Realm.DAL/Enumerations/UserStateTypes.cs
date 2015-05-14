using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum UserStateTypes
    {
        None = 1,

        [Enum("Main Menu")]
        MainMenu = 2,

        [Enum("Character Menu")]
        CharacterMenu = 3,

        [Enum("Create Character")]
        CreateCharacter = 4,

        [Enum("Delete Character")]
        DeleteCharacter = 5,
        
        [Enum("Logged In")]
        LoggedIn = 6,

        Quitting = 7
    }
}
