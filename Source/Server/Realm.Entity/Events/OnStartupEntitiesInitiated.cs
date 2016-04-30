using Realm.Library.Common.Events;

namespace Realm.Entity.Events
{
    /// <summary>
    ///
    /// </summary>
    public class OnStartupEntitiesInitiated : EventBase
    {
        /// <summary>
        ///
        /// </summary>
        public OnStartupEntitiesInitiated()
        {
            Name = "OnEntityStartup";
        }
    }
}