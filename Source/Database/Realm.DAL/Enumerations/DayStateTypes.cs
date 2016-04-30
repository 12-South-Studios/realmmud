using Realm.Library.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum DayStateTypes
    {
        [Value(1)]
        Dawn = 1,

        [Value(2)]
        Daylight = 2,

        [Value(4)]
        Dusk = 3,

        [Value(8)]
        Night = 4
    }
}
