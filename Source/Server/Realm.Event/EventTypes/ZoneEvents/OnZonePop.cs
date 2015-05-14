using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnZonePop : EventBase
    {
        public OnZonePop(string name)
        {
            Name = name;
        }
    }
}