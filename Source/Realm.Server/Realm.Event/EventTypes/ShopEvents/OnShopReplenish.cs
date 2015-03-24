using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnShopReplenish : EventBase
    {
        public OnShopReplenish(string name)
        {
            Name = name;
        }
    }
}