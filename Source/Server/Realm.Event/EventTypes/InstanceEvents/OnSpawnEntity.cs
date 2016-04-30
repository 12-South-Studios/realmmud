using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.InstanceEvents

{
    public class OnSpawnEntity : EventBase
    {
        public OnSpawnEntity(string name)
        {
            Name = name;
        }
    }
}