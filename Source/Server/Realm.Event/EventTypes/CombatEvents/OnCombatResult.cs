using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnCombatResult : EventBase
    {
        public OnCombatResult(string name)
        {
            Name = name;
        }
    }
}