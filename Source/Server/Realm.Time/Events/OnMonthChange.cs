using Realm.Library.Common.Events;

namespace Realm.Time.Events
{
    public class OnMonthChange : EventBase
    {
        public OnMonthChange()
        {
            Name = "OnMonthChange";
        }
    }
}