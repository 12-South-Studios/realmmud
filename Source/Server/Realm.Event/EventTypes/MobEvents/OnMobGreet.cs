using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnMobGreet : EventBase
    {
        public OnMobGreet(string name)
        {
            Name = name;
        }
    }
}