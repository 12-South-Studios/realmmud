using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnEquipItem : EventBase
    {
        public OnEquipItem(string name)
        {
            Name = name;
        }
    }
}