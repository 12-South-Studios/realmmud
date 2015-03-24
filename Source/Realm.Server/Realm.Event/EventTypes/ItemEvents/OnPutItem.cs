using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnPutItem : EventBase
    {
        public OnPutItem(string name)
        {
            Name = name;
        }
    }
}