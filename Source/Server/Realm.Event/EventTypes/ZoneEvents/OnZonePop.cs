using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ZoneEvents

{
    public class OnZonePop : EventBase
    {
        public OnZonePop(string name)
        {
            Name = name;
        }
    }
}