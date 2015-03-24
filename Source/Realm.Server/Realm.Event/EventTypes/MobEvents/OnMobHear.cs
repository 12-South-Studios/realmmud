using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnMobHear : EventBase
    {
        public OnMobHear(string name)
        {
            Name = name;
        }
    }
}