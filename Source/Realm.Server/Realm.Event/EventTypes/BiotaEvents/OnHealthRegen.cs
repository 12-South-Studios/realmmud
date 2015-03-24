using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnHealthRegen : EventBase
    {
        public OnHealthRegen(string name)
        {
            Name = name;
        }
    }
}