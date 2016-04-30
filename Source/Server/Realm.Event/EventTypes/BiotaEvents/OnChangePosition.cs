using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.BiotaEvents

{
    public class OnChangePosition : EventBase
    {
        public OnChangePosition(string name)
        {
            Name = name;
        }
    }
}