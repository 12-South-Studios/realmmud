//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Realm.Server.Zones
//{
//    [TestClass]
//    public class PortalTest
//    {
//        [Fact]
//        public void Exit_Constructor_Test()
//        {
//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            var exit = new Portal(direction, Space, keywords);

//            Assert.IsNotNull(exit);
//            Assert.AreEqual(direction, exit.Direction);
//            Assert.AreEqual(Space, exit.Destination);
//            Assert.AreEqual(keywords, exit.Keywords);
//        }

//        //public void SetDoor(string name, Material materialType, bool closed, bool locked, bool broken, int key)
//        [Fact]
//        public void Exit_SetDoor_Test()
//        {
//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            var exit = new Portal(direction, Space, keywords);

//            const Globals.Globals.MaterialTypes material = Globals.Globals.MaterialTypes.Organic;

//            const string name = "test";
//            const bool closed = true;
//            const bool locked = true;
//            const bool broken = true;
//            const int key = 1;

//            exit.SetDoor(name, material, closed, locked, broken, key);

//            Assert.IsNotNull(exit.Door);
//        }
//    }
//}
