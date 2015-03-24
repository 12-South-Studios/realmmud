using NUnit.Framework;

namespace Realm.Server.Test.Realm.Server
{
    [TestFixture]
    public class CurrencyTest
    {
        [TestCase(5555555, true, "5 platinum 55 gold 55 silver 55 copper")]
        [TestCase(5555555, false, "5p 55g 55s 55c")]
        public void ConvertCurrency_Test(int amount, bool isLongForm, string expected)
        {
            var actual = Currency.ConvertCurrency(amount, isLongForm);
            Assert.AreEqual(expected, actual);
        }
    }
}
