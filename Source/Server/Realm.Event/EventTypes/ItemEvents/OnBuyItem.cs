using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnBuyItem : EventBase
    {
        public OnBuyItem(string name)
        {
            Name = name;
        }
    }
}