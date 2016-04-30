using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.RoomEvents

{
    public class OnSpaceLeave : EventBase
    {
        public OnSpaceLeave(string name)
        {
            Name = name;
        }
    }
}