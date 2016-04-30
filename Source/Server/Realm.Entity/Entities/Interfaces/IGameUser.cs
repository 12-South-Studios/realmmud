using Realm.Entity.Interfaces;

namespace Realm.Entity.Entities.Interfaces
{
    public interface IGameUser : IGameEntity
    {
        void SendText(string text);

        ICharacter CurrentCharacter { get; }

        //int AccountId { get; set; }

        //IPropertyContext Properties { get; }
        //ICharacterHandler Characters { get; }

        //Globals.Globals.UserStateTypes UserState { get; set; }

        //bool Save();
    }
}