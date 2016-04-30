using Realm.Library.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum GuildActionTypes
    {
        [Enum("Promote Member")]
        PromoteMember = 1,

        [Enum("Demote Member")]
        DemoteMember = 2,

        [Enum("Recruit New Member")]
        RecruitNewMember = 3,

        [Enum("Update Guild Information")]
        UpdateGuildInformation = 4,

        [Enum("Upgrade Bank Level")]
        UpgradeBankLevel = 5,

        [Enum("Withdraw From Bank")]
        WithdrawFromBank = 6,

        [Enum("Deposit To Bank")]
        DepositToBank = 7,

        [Enum("Kick From Guild")]
        KickFromGuild = 8
    }
}
