using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnCombatEngage : EventBase
    {
        public OnCombatEngage(string name)
        {
            Name = name;
        }
    }
}