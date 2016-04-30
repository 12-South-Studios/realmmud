using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.CharacterEvents

{
    public class OnXpGain : EventBase
    {
        public OnXpGain(string name)
        {
            Name = name;
        }
    }
}