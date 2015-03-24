using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnGatherItem : EventBase
    {
        public OnGatherItem(string name)
        {
            Name = name;
        }
    }
}