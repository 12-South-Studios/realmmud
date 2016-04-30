using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.RoomEvents

{
    public class OnSpaceEnter : EventBase
    {
        public OnSpaceEnter(string name)
        {
            Name = name;
        }
    }
}