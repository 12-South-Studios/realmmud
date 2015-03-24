using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnXpGain : EventBase
    {
        public OnXpGain(string name)
        {
            Name = name;
        }
    }
}