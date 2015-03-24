using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnZoneLeave : EventBase
    {
        public OnZoneLeave(string name)
        {
            Name = name;
        }
    }
}