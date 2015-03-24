using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnFillItem : EventBase
    {
        public OnFillItem(string name)
        {
            Name = name;
        }
    }
}