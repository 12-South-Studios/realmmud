using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.ItemEvents

{
    public class OnEquipItem : EventBase
    {
        public OnEquipItem(string name)
        {
            Name = name;
        }
    }
}