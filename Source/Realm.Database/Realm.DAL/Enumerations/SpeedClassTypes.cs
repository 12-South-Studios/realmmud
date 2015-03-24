using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum SpeedClassTypes
    {
        [Enum("Very Fast")]
        VeryFast = 1,
        Fast = 2,
        Average = 3,
        Slow = 4,

        [Enum("Very Slow")]
        VerySlow = 5
    }
}
