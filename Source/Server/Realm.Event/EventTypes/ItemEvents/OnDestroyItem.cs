using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnDestroyItem : EventBase
    {
        public OnDestroyItem(string name)
        {
            Name = name;
        }
    }
}