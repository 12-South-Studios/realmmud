using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnOpenItem : EventBase
    {
        public OnOpenItem(string name)
        {
            Name = name;
        }
    }
}