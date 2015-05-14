using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnSpaceEnter : EventBase
    {
        public OnSpaceEnter(string name)
        {
            Name = name;
        }
    }
}