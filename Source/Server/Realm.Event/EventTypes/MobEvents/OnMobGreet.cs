using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.MobEvents

{
    public class OnMobGreet : EventBase
    {
        public OnMobGreet(string name)
        {
            Name = name;
        }
    }
}