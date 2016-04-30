using Realm.Library.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum MerchantStatementTypes
    {
        Welcome = 1,

        [Enum("Nothing For Sale")]
        NothingForSale = 2,

        [Enum("Stuff For Sale")]
        StuffForSale = 3,

        [Enum("Buy No Keyword")]
        BuyNoKeyword = 4,

        [Enum("Buy No Item")]
        BuyNoItem = 5,

        [Enum("BuyCannotAfford")]
        BuyCannotAfford = 6,

        [Enum("Buy Complete")]
        BuyComplete = 7,

        [Enum("Sell No Keyword")]
        SellNoKeyword = 8,

        [Enum("Sell No Item")]
        SellNoItem = 9,

        [Enum("Sell No Interest")]
        SellNoInterest = 10,

        [Enum("SellCannotAfford")]
        SellCannotAfford = 11,

        [Enum("Sell Complete")]
        SellComplete = 12,

        [Enum("Appraise No Keyword")]
        AppraiseNoKeyword = 13,

        [Enum("Appraise No Item")]
        AppraiseNoItem = 14,

        [Enum("Appraise No Interest")]
        AppraiseNoInterest = 15,

        [Enum("Appraise Complete")]
        AppraiseComplete = 16,

        Restock = 17
    }
}
