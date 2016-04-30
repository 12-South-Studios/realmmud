using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Realm.Library.Common.Logging;
using Realm.Library.Common;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

namespace Realm.Library.Network
{
    /// <summary>
    /// Abstract class wraps the TcpClient and exposes additional functionality
    /// </summary>
    public abstract class TcpClientWrapper : ITcpClientWrapper
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="tcpClient"></param>
        /// <param name="formatters"></param>
        [ExcludeFromCodeCoverage]
        protected TcpClientWrapper(ILogWrapper log, TcpClient tcpClient, IEnumerable<IFormatter> formatters)
        {
            Validation.IsNotNull(log, "log");
            Validation.IsNotNull(tcpClient, "tcpClient");
            Validation.IsNotNull(formatters, "formatters");

            Log = log;
            TcpClient = tcpClient;
            Formatters = formatters;

            var ip = tcpClient.Client.RemoteEndPoint as IPEndPoint;
            if (ip.IsNotNull())
                IpAddress = ip.Address.ToString();

            ClientStream = tcpClient.GetStream();
            ConnectedOn = DateTime.Now;
        }

        /// <summary>
        /// Gets a reference to the ILog interface
        /// </summary>
        protected ILogWrapper Log { get; private set; }

        /// <summary>
        /// Gets a reference to the TcpClient attached to this object
        /// </summary>
        protected TcpClient TcpClient { get; private set; }

        /// <summary>
        ///
        /// </summary>
        protected IEnumerable<IFormatter> Formatters { get; private set; }

        /// <summary>
        /// Gets the IpAddress of the connected user
        /// </summary>
        public string IpAddress { get; protected set; }

        /// <summary>
        /// Gets the datetime when a connection occurred
        /// </summary>
        public DateTime ConnectedOn { get; protected set; }

        /// <summary>
        /// Gets a reference to the NetworkStream object
        /// </summary>
        public NetworkStream ClientStream { get; protected set; }

        /// <summary>
        /// Writes a given message to the buffer which will be queued to send to the client stream.
        /// </summary>
        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.Maintainability", "CA1502")]
        public void WriteToBuffer(string msg)
        {
            Validation.IsNotNull(msg, "msg");

            var encoder = new ASCIIEncoding();
            var clientStream = TcpClient.GetStream();

            try
            {
                foreach (var formattedString in Formatters.Select(formatter => formatter.Format(msg)))
                {
                    clientStream.Write(encoder.GetBytes(formattedString), 0, formattedString.Length);
                }

                clientStream.Flush();
            }
            catch (ArgumentNullException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
            catch (IOException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
            catch (ObjectDisposedException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
            catch (InvalidOperationException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
        }
    }
}