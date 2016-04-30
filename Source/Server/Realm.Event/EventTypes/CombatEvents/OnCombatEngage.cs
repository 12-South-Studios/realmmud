using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.CombatEvents

{
    public class OnCombatEngage : EventBase
    {
        public OnCombatEngage(string name)
        {
            Name = name;
        }
    }
}