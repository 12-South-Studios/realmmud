using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum MerchantScopeTypes
    {
        [Value(1)]
        Character = 1,

        [Value(2)]
        Victim = 2,

        [Value(4)]
        SpaceLimited = 3,

        [Value(8)]
        Space = 4,

        [Value(16)]
        Zone = 5,

        [Value(32)]
        Game = 6
    }
}
