//using NUnit.Framework;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Realm.Server.Zones
//{
//    [TestFixture]
//    public class BarrierTest
//    {
//        [Test]
//        public void Door_Constructor_Test()
//        {
//            const Globals.Globals.MaterialTypes material = Globals.Globals.MaterialTypes.Organic;

//            const string name = "test";
//            const bool closed = true;
//            const bool locked = true;
//            const bool broken = true;
//            const int key = 1;

//            var door = new Barrier(name, material, closed, locked, broken, key);

//            Assert.IsNotNull(door);
//            Assert.AreEqual(name, door.Name);
//            Assert.AreEqual(material, door.MaterialType);
//            Assert.AreEqual(closed, door.IsClosed);
//            Assert.AreEqual(locked, door.IsLocked);
//            Assert.AreEqual(broken, door.IsBroken);
//            Assert.AreEqual(key, door.Key);
//        }

//        [TestCase("test", true, false, false, 1, false)]
//        [TestCase("test", false, false, true, 1, false)]
//        [TestCase("test", false, false, false, 1, true)]
//        public void Close_Test(string name, bool closed, bool locked, bool broken, int key, bool expected)
//        {
//            const Globals.Globals.MaterialTypes material = Globals.Globals.MaterialTypes.Organic;

//            var barrier = new Barrier(name, material, closed, locked, broken, key);

//            Assert.AreEqual(expected, barrier.Close());
//        }

//        [TestCase("test", false, false, false, 1, false)]
//        [TestCase("test", false, true, false, 1, false)]
//        [TestCase("test", false, false, true, 1, false)]
//        [TestCase("test", true, false, false, 1, true)]
//        public void Open_Test(string name, bool closed, bool locked, bool broken, int key, bool expected)
//        {
//            const Globals.Globals.MaterialTypes material = Globals.Globals.MaterialTypes.Organic;

//            var barrier = new Barrier(name, material, closed, locked, broken, key);

//            Assert.AreEqual(expected, barrier.Open());
//        }

//        [TestCase("test", false, false, false, 1, false)]
//        [TestCase("test", false, false, true, 1, false)]
//        [TestCase("test", true, true, false, 1, false)]
//        [TestCase("test", true, false, false, 1, true)]
//        public void ToggleLock_Test(string name, bool closed, bool locked, bool broken, int key, bool expected)
//        {
//            const Globals.Globals.MaterialTypes material = Globals.Globals.MaterialTypes.Organic;

//            var barrier = new Barrier(name, material, closed, locked, broken, key);

//            Assert.AreEqual(expected, barrier.ToggleLock());  
//        }
//    }
//}
