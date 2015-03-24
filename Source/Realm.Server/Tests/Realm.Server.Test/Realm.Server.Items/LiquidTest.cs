//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Item;

//namespace Realm.Server.Test.Realm.Server.Items
//{
//    [TestClass]
//    public class LiquidTest
//    {
//        [TestMethod]
//        public void Liquid_Constructor_Test()
//        {
//            const int id = 1;
//            const string name = "test";

//            var actual = new Liquid(id, name);
//            Assert.AreEqual(id, actual.ID);
//            Assert.AreEqual(name, actual.Name);
//            Assert.IsNotNull(actual.Properties);
//        }

//        [TestMethod]
//        public void Liquid_Color_Test()
//        {
//            const int id = 1;
//            const string name = "test";
//            const string color = "Blue";

//            var actual = new Liquid(id, name)
//                             {
//                                 Color = color
//                             };

//            Assert.AreEqual(color, actual.Color);
//        }

//        [TestMethod]
//        public void Liquid_ThirstPoints_Test()
//        {
//            const int id = 1;
//            const string name = "test";
//            const int points = 5;

//            var actual = new Liquid(id, name)
//            {
//                ThirstPoints = points
//            };

//            Assert.AreEqual(points, actual.ThirstPoints);
//        }

//        [TestMethod]
//        public void Liquid_DrunkPoints_Test()
//        {
//            const int id = 1;
//            const string name = "test";
//            const int points = 5;

//            var actual = new Liquid(id, name)
//            {
//                DrunkPoints = points
//            };

//            Assert.AreEqual(points, actual.DrunkPoints);
//        }

//        [TestMethod]
//        public void Liquid_CostPerCharge_Test()
//        {
//            const int id = 1;
//            const string name = "test";
//            const float cost = 5.2f;

//            var actual = new Liquid(id, name)
//            {
//                CostPerCharge = cost
//            };

//            Assert.AreEqual(cost, actual.CostPerCharge);
//        }

//        [TestMethod]
//        public void Liquid_Description_Test()
//        {
//            const int id = 1;
//            const string name = "test";
//            const string desc = "this is a test";

//            var actual = new Liquid(id, name)
//            {
//                Description = desc
//            };

//            Assert.AreEqual(desc, actual.Description);
//        }

//        [TestMethod]
//        public void Liquid_Flammability_Test()
//        {
//            const int id = 1;
//            const string name = "test";
//            const int points = 5;

//            var actual = new Liquid(id, name)
//            {
//                Flammability = points
//            };

//            Assert.AreEqual(points, actual.Flammability);
//        }
//    }
//}
