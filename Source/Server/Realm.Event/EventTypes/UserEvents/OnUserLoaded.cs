using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.UserEvents

{
    public class OnUserLoaded : EventBase
    {
        public OnUserLoaded()
        {
            Name = "OnUserLoaded";
        }
    }
}