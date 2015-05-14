using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnStaminaRegen : EventBase
    {
        public OnStaminaRegen(string name)
        {
            Name = name;
        }
    }
}