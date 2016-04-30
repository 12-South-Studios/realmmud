using Realm.Library.Common.Events;

namespace Realm.Entity.Events
{
    /// <summary>
    ///
    /// </summary>
    public class OnEntityDisposed : EventBase
    {
        /// <summary>
        ///
        /// </summary>
        public OnEntityDisposed()
        {
            Name = "OnInstanceDisposed";
        }
    }
}