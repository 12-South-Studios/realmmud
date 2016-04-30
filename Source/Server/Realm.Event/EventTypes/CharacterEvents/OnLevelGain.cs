using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.CharacterEvents

{
    public class OnLevelGain : EventBase
    {
        public OnLevelGain(string name)
        {
            Name = name;
        }
    }
}