using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnDropItem : EventBase
    {
        public OnDropItem(string name)
        {
            Name = name;
        }
    }
}