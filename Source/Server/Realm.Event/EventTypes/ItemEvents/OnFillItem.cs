using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnFillItem : EventBase
    {
        public OnFillItem(string name)
        {
            Name = name;
        }
    }
}