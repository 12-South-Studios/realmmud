using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnSellItem : EventBase
    {
        public OnSellItem(string name)
        {
            Name = name;
        }
    }
}