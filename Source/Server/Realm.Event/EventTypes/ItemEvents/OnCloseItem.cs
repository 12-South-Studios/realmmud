using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnCloseItem : EventBase
    {
        public OnCloseItem(string name)
        {
            Name = name;
        }
    }
}