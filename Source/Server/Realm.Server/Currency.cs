using System.Text;
using Realm.Server.Properties;

namespace Realm.Server
{
    /// <summary>
    /// Static currency class that handles basic conversions
    /// </summary>
    public static class Currency
    {
        /// <summary>
        /// Converts an amount of currency into a string-like format
        /// </summary>
        /// <param name="aAmount">Amount of coin</param>
        /// <param name="isLongForm">Indicates whether or not to display long or short form</param>
        /// <returns>Returns a string value</returns>
        public static string ConvertCurrency(int aAmount, bool isLongForm)
        {
            //// copper
            //// silver (1=100 copper)
            //// gold (1=100 silver or 10000 copper)
            //// platinum (1=100 gold or 10000 silver or 1000000 copper)
            var sb = new StringBuilder();
            var remainingCoins = aAmount;

            var platinumAmount = aAmount / 1000000;
            if (platinumAmount > 0)
            {
                sb.AppendFormat(" " + (isLongForm ? MessageResources.MSG_PLATINUM_LONG
                    : MessageResources.MSG_PLATINUM_SHORT), platinumAmount);
                remainingCoins = remainingCoins - platinumAmount * 1000000;
            }

            var goldAmount = remainingCoins / 10000;
            if (goldAmount > 0)
            {
                sb.AppendFormat(" " + (isLongForm ? MessageResources.MSG_GOLD_LONG
                    : MessageResources.MSG_GOLD_SHORT), goldAmount);
                remainingCoins = remainingCoins - goldAmount * 10000;
            }

            var silverAmount = remainingCoins / 100;
            if (silverAmount > 0)
            {
                sb.AppendFormat(" " + (isLongForm ? MessageResources.MSG_SILVER_LONG
                    : MessageResources.MSG_SILVER_SHORT), silverAmount);
                remainingCoins = remainingCoins - silverAmount * 100;
            }

            if (remainingCoins > 0)
                sb.AppendFormat(" " + (isLongForm ? MessageResources.MSG_COPPER_LONG
                    : MessageResources.MSG_COPPER_SHORT), remainingCoins);

            return sb.ToString().Trim();
        }
    }
}
