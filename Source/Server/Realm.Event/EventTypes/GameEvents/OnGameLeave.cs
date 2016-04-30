using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameLeave : EventBase
    {
        public OnGameLeave()
        {
            Name = "OnGameLeave";
        }
    }
}