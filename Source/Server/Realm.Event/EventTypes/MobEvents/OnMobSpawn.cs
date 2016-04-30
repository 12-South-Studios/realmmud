using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.MobEvents

{
    public class OnMobSpawn : EventBase
    {
        public OnMobSpawn(string name)
        {
            Name = name;
        }
    }
}