using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum ConditionTypes
    {
        [Value(1)]
        Pristine = 1,

        [Value(2)]
        SlightlyDamaged = 2,

        [Value(4)]
        Damaged = 3,

        [Value(8)]
        HeavilyDamaged = 4,

        [Value(16)]
        DrinkContainer = 5,

        [Value(32)]
        Destroyed = 6
    }
}
