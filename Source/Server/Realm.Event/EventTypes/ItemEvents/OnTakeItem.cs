using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnTakeItem : EventBase
    {
        public OnTakeItem(string name)
        {
            Name = name;
        }
    }
}