using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Logging;

namespace Realm.Library.Ai
{
    /// <summary>
    /// Message handler class which manages the internal messages for the Aibrain
    /// </summary>
    public sealed class MessageContext : IMessageContext
    {
        private readonly IList<string> _messageList = new List<string>();

        /// <summary>
        /// Adds a message to the internal stack
        /// </summary>
        public void Add(string value)
        {
            Validation.IsNotNullOrEmpty(value, "value");

            _messageList.Add(value);
        }

        /// <summary>
        /// Gets the list of messages
        /// </summary>
        public IEnumerable<string> Get()
        {
            return _messageList;
        }

        /// <summary>
        /// Clears all messages
        /// </summary>
        public void Clear()
        {
            _messageList.Clear();
        }

        /// <summary>
        /// Outputs the messages to the given ILog
        /// </summary>
        public void Dump(ILogWrapper log)
        {
            Validation.IsNotNull(log, "log");

            ((List<string>)_messageList).ForEach(log.Info);

            _messageList.Clear();
        }
    }
}