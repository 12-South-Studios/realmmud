using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnDrinkItem : EventBase
    {
        public OnDrinkItem(string name)
        {
            Name = name;
        }
    }
}