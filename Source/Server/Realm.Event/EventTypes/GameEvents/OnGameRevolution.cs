using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameRevolution : EventBase
    {
        public OnGameRevolution()
        {
            Name = "OnGameRevolution";
        }
    }
}