namespace Realm.Entity.Entities
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