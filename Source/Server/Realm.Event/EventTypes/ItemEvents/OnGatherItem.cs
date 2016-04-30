using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnGatherItem : EventBase
    {
        public OnGatherItem(string name)
        {
            Name = name;
        }
    }
}