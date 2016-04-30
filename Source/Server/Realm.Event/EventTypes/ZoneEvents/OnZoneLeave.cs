using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ZoneEvents

{
    public class OnZoneLeave : EventBase
    {
        public OnZoneLeave(string name)
        {
            Name = name;
        }
    }
}