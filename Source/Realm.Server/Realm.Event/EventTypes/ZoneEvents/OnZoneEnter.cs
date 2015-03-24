using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnZoneEnter : EventBase
    {
        public OnZoneEnter(string name)
        {
            Name = name;
        }
    }
}