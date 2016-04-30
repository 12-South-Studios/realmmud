using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnDrinkItem : EventBase
    {
        public OnDrinkItem(string name)
        {
            Name = name;
        }
    }
}