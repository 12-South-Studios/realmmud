using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.MobEvents

{
    public class OnMobHear : EventBase
    {
        public OnMobHear(string name)
        {
            Name = name;
        }
    }
}