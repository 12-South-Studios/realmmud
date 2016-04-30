using Realm.Library.Common.Events;

namespace Realm.Time.Events
{
    public class OnTimeChange : EventBase
    {
        public OnTimeChange()
        {
            Name = "OnTimeChange";
        }
    }
}