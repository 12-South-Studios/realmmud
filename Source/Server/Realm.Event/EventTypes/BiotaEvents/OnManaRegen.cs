using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.BiotaEvents

{
    public class OnManaRegen : EventBase
    {
        public OnManaRegen(string name)
        {
            Name = name;
        }
    }
}