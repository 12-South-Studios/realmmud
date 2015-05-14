using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum SkillTestResultTypes
    {
        Failure = 1,
        Success = 2,

        [Enum("Critical Success")]
        CriticalSuccess = 3,

        [Enum("Critical Failure")]
        CriticalFailure = 4
    }
}
