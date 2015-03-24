using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnDestroyItem : EventBase
    {
        public OnDestroyItem(string name)
        {
            Name = name;
        }
    }
}