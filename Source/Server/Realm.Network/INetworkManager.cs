using Realm.Library.Network;

namespace Realm.Network
{
    public interface INetworkManager
    {
        TcpServer Server { get; }

        Hash.Hash GetRandomValue();
    }
}