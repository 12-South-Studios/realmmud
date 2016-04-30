using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.BiotaEvents

{
    public class OnHealthRegen : EventBase
    {
        public OnHealthRegen(string name)
        {
            Name = name;
        }
    }
}