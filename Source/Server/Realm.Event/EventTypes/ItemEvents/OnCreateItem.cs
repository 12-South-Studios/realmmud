using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnCreateItem : EventBase
    {
        public OnCreateItem(string name)
        {
            Name = name;
        }
    }
}