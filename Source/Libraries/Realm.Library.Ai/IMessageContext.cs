using System.Collections.Generic;
using Realm.Library.Common.Logging;


namespace Realm.Library.Ai

{
    /// <summary>
    /// Declares the contract for a message handler
    /// </summary>
    public interface IMessageContext
    {
        /// <summary>
        /// Adds a message to the internal stack
        /// </summary>
        void Add(string value);

        /// <summary>
        /// Clears all messages
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the list of messages
        /// </summary>
        IEnumerable<string> Get();

        /// <summary>
        /// Outputs the messages to the given ILogWrapper
        /// </summary>
        void Dump(ILogWrapper log);
    }
}