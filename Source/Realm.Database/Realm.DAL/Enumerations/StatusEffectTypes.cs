using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum StatusEffectTypes
    {
        [Value(0)]
        None = 1,

        [Value(1)]
        Mesmerize = 2,

        [Value(2)]
        Stun = 3,

        [Value(4)]
        Blind = 4,

        [Value(8)]
        Mute = 5,

        [Value(16)]
        Immobilized = 6,

        [Value(32)]
        Unconcious = 7
    }
}
