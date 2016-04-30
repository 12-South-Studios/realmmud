using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ZoneEvents

{
    public class OnZoneEnter : EventBase
    {
        public OnZoneEnter(string name)
        {
            Name = name;
        }
    }
}