using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.CombatEvents

{
    public class OnCombatResult : EventBase
    {
        public OnCombatResult(string name)
        {
            Name = name;
        }
    }
}