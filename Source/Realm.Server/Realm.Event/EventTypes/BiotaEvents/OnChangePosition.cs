using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnChangePosition : EventBase
    {
        public OnChangePosition(string name)
        {
            Name = name;
        }
    }
}