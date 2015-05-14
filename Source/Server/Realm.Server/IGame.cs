using System;
using Realm.Entity;
using Realm.Library.Network;

namespace Realm.Server
{
    public interface IGame : IGameEntity
    {
        event EventHandler<NetworkEventArgs> OnUserStatusChanged;
        event EventHandler<NetworkEventArgs> OnServerStatusChanged;

        void StartServer();
        void StopServer();

        bool IsRunning { get; }
    }
}
