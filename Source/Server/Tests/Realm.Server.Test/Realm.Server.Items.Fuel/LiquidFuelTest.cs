//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Item;

//namespace Realm.Server.Test.Realm.Server.Items.Fuel
//{
//    [TestClass]
//    public class LiquidFuelTest
//    {
//        [TestMethod]
//        public void LiquidFuel_Constructor_Test()
//        {
//            var liquid = new Liquid(1, "Test");

//            const int charges = 10;
//            const int rate = 2;
//            const string type = "liquid";

//            var actual = new LiquidFuel(rate, charges, liquid);
//            Assert.AreEqual(rate, actual.BurnRate);
//            Assert.AreEqual(charges, actual.Charges);
//            Assert.AreEqual(liquid, actual.Fuel);
//            Assert.AreEqual(type, actual.FuelType);
//        }
//    }
//}
