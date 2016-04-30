using Realm.Library.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum PositionTypes
    {
        [Value(1)]
        Any = 1,

        [Value(2)]
        Standing = 2,

        [Value(4)]
        Sitting = 3,

        [Value(8)]
        Prone = 4,

        [Value(16)]
        Crouching = 5,

        [Value(32)]
        Immobilized = 6,

        [Value(64)]
        Incapacitated = 7,

        [Value(128)]
        Sleeping = 8
    }
}
