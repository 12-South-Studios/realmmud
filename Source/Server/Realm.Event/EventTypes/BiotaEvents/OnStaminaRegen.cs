using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.BiotaEvents

{
    public class OnStaminaRegen : EventBase
    {
        public OnStaminaRegen(string name)
        {
            Name = name;
        }
    }
}