using System;
using System.Net;

namespace Realm.Library.Network
{
    /// <summary>
    /// Defines the contract for a Tcp Server
    /// </summary>
    public interface ITcpServer
    {
        /// <summary>
        /// Event on a TcpUser status change
        /// </summary>
        event EventHandler<NetworkEventArgs> OnTcpUserStatusChanged;

        /// <summary>
        /// Event on a TcpServer status change
        /// </summary>
        event EventHandler<NetworkEventArgs> OnTcpServerStatusChanged;

        /// <summary>
        /// Event on a TcpServer status change
        /// </summary>
        event EventHandler<NetworkEventArgs> OnNetworkMessageReceived;

        TcpServerStatus Status { get; }

        void Startup(int port, IPAddress host);
        void Shutdown(string message);
        bool DisconnectUser(string id);
    }
}