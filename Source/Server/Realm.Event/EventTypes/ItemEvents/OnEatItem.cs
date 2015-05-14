using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnEatItem : EventBase
    {
        public OnEatItem(string name)
        {
            Name = name;
        }
    }
}