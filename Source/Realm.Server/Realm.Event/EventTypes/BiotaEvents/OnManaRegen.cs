using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnManaRegen : EventBase
    {
        public OnManaRegen(string name)
        {
            Name = name;
        }
    }
}