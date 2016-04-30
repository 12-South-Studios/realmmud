using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnOpenItem : EventBase
    {
        public OnOpenItem(string name)
        {
            Name = name;
        }
    }
}