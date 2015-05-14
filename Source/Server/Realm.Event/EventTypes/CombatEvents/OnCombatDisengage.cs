using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnCombatDisengage : EventBase
    {
        public OnCombatDisengage(string name)
        {
            Name = name;
        }
    }
}