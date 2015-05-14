using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Realm.Server.Test.Realm.Server
{
    [TestClass]
    public class DiceTest
    {
        private static void AssertBetween(int actual, int min, int max)
        {
            Assert.IsTrue(actual >= min && actual <= max);
        }

        [TestMethod]
        public void Dice_Between_Test()
        {
            var target = new Dice();
            const int aMinimum = 1;
            const int aMaximum = 4;
            var actual = target.Between(aMinimum, aMaximum);
            AssertBetween(actual, aMinimum, aMaximum);
        }

        [TestMethod]
        public void Dice_D10_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D10(aTimes);
            AssertBetween(actual, 2, 20);
        }

        [TestMethod]
        public void Dice_D100_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D100(aTimes);
            AssertBetween(actual, 2, 200);
        }

        [TestMethod]
        public void Dice_D12_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D12(aTimes);
            AssertBetween(actual, 2, 24);
        }

        [TestMethod]
        public void Dice_D20_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D20(aTimes);
            AssertBetween(actual, 2, 40);
        }

        [TestMethod]
        public void Dice_D4_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D4(aTimes);
            AssertBetween(actual, 2, 8);
        }

        [TestMethod]
        public void Dice_D6_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D6(aTimes);
            AssertBetween(actual, 2, 12);
        }

        [TestMethod]
        public void Dice_D8_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            var actual = target.D8(aTimes);
            AssertBetween(actual, 2, 16);
        }

        [TestMethod]
        public void Dice_Roll_Test()
        {
            Dice target = new Dice();
            const int aTimes = 2;
            const int aSize = 5;
            var actual = target.Roll(aSize, aTimes);
            AssertBetween(actual, aTimes, aSize * aTimes);
        }

        [TestMethod]
        public void Dice_RollSeriesCount_Test()
        {
            Dice target = new Dice();
            const int aTimes = 3;
            const int aSize = 5;
            const int expected = 3;
            var seriesList = target.RollSeries(aSize, aTimes);
            Assert.AreEqual(expected, seriesList.Count);
        }

        [TestMethod]
        public void Dice_RollSeriesTotal_Test()
        {
            Dice target = new Dice();
            const int aTimes = 3;
            const int aSize = 5;
            var seriesList = target.RollSeries(aSize, aTimes);
            var total = seriesList.Sum();
            AssertBetween(total, aTimes, aSize * aTimes);
        }
    }
}
