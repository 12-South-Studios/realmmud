using Realm.Library.Common.Events;

namespace Realm.Entity.Events
{
    /// <summary>
    ///
    /// </summary>
    public class OnEntityCreated : EventBase
    {
        /// <summary>
        ///
        /// </summary>
        public OnEntityCreated()
        {
            Name = "OnInstanceCreated";
        }
    }
}