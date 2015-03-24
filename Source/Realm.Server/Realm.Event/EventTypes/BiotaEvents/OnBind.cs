using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnBind : EventBase
    {
        public OnBind(string name)
        {
            Name = name;
        }
    }
}