using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ShopEvents

{
    public class OnShopReplenish : EventBase
    {
        public OnShopReplenish(string name)
        {
            Name = name;
        }
    }
}