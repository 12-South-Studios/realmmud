using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnUnequipItem : EventBase
    {
        public OnUnequipItem(string name)
        {
            Name = name;
        }
    }
}