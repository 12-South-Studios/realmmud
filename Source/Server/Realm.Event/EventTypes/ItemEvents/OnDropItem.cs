using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnDropItem : EventBase
    {
        public OnDropItem(string name)
        {
            Name = name;
        }
    }
}