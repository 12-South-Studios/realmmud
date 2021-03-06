﻿using System.Net.Sockets;

namespace Realm.Library.Network
{
    /// <summary>
    /// Defines the contract for a formatter object
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Formats the source string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        string Format(string source);

        /// <summary>
        /// 
        /// </summary>
        void Enable(ITcpUser tcpUser, NetworkStream clientStream);
    }
}