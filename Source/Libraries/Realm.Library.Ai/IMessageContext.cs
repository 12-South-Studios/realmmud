using System.Collections.Generic;
using log4net;

// ReSharper disable CheckNamespace
namespace Realm.Library.Ai
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Declares the contract for a message handler
    /// </summary>
    public interface IMessageContext
    {
        /// <summary>
        /// Adds a message to the internal stack
        /// </summary>
        /// <param name="value"></param>
        void Add(string value);

        /// <summary>
        /// Clears all messages
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the list of messages
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Get();

        /// <summary>
        /// Outputs the messages to the given ILog
        /// </summary>
        /// <param name="log"></param>
        void Dump(ILog log);
    }
}