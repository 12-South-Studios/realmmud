namespace Realm.Entity
{
    public interface IGame : IGameEntity
    {
        //event EventHandler<NetworkEventArgs> OnUserStatusChanged;
        //event EventHandler<NetworkEventArgs> OnServerStatusChanged;

        //void SetManagerReferences(object obj);
        void StartServer();
        void StopServer();
        bool IsRunning { get; }

        //GameUserRepository UserRepository { get; }
        //EffectsHandler Effects { get; }
        //IPropertyContext Properties { get; }

        //ILog Logger { get; }
    }
}
