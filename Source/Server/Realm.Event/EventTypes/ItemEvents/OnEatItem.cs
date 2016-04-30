using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnEatItem : EventBase
    {
        public OnEatItem(string name)
        {
            Name = name;
        }
    }
}