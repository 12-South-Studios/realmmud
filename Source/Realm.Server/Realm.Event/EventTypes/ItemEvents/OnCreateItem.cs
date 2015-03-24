using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnCreateItem : EventBase
    {
        public OnCreateItem(string name)
        {
            Name = name;
        }
    }
}