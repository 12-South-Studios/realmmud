using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnSellItem : EventBase
    {
        public OnSellItem(string name)
        {
            Name = name;
        }
    }
}