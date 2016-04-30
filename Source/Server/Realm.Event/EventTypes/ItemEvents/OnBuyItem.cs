using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnBuyItem : EventBase
    {
        public OnBuyItem(string name)
        {
            Name = name;
        }
    }
}