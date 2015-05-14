using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnLevelGain : EventBase
    {
        public OnLevelGain(string name)
        {
            Name = name;
        }
    }
}