using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameStop : EventBase
    {
        public OnGameStop()
        {
            Name = "OnGameStop";
        }
    }
}