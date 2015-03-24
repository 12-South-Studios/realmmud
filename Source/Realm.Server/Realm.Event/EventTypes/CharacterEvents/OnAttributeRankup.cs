using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnAttributeRankup : EventBase
    {
        public OnAttributeRankup(string name)
        {
            Name = name;
        }
    }
}