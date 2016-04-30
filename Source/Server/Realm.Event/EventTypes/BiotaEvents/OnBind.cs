using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.BiotaEvents

{
    public class OnBind : EventBase
    {
        public OnBind(string name)
        {
            Name = name;
        }
    }
}