using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnTakeItem : EventBase
    {
        public OnTakeItem(string name)
        {
            Name = name;
        }
    }
}