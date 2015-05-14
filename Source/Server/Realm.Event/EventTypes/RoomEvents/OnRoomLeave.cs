using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnSpaceLeave : EventBase
    {
        public OnSpaceLeave(string name)
        {
            Name = name;
        }
    }
}