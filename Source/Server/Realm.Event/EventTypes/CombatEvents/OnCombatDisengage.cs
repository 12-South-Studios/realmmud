using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.CombatEvents

{
    public class OnCombatDisengage : EventBase
    {
        public OnCombatDisengage(string name)
        {
            Name = name;
        }
    }
}