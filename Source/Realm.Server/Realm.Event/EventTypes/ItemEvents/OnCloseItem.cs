using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnCloseItem : EventBase
    {
        public OnCloseItem(string name)
        {
            Name = name;
        }
    }
}