using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnUnequipItem : EventBase
    {
        public OnUnequipItem(string name)
        {
            Name = name;
        }
    }
}