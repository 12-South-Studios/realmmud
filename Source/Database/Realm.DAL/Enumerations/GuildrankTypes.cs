using Realm.Library.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum GuildRankTypes
    {
        [Enum("Leader", ExtraData = "1;2;3;4;5;6;7;8")]
        Leader = 1,

        [Enum("Officer", ExtraData = "1,2,3,4,5,6,7,8")]
        Officer = 2,

        [Enum("Member", ExtraData = "6,7")]
        Member = 3,

        [Enum("Recruit", ExtraData = "7")]
        Recruit = 4
    }
}
