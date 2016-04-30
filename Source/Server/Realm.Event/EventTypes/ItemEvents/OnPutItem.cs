using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnPutItem : EventBase
    {
        public OnPutItem(string name)
        {
            Name = name;
        }
    }
}