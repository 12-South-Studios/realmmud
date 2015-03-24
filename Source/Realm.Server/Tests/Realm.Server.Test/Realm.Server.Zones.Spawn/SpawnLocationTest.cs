//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Realm.Server.Zones.Spawn
//{
//    [TestClass]
//    public class SpawnLocationTest
//    {
//        [TestMethod]
//        public void SpawnLocation_Constructor_Test()
//        {
//            var loc = new SpawnLocation(1, "test", Globals.Globals.SpawnTypes.None, 1000, 50);

//            Assert.IsNotNull(loc);
//            Assert.AreEqual(1, loc.ID);
//            Assert.AreEqual("test", loc.Name);
//            Assert.AreEqual(Globals.Globals.SpawnTypes.None, loc.Type);
//            Assert.AreEqual(1000, loc.Value);
//            Assert.AreEqual(50, loc.Density);
//        }

//        [TestMethod]
//        public void SpawnLocation_SetTypeDefault_Test()
//        {
//            var loc = new SpawnLocation(1, "test", Globals.Globals.SpawnTypes.Space, 1000, 50);

//            loc.SetType("whatever");
//            Assert.AreEqual(Globals.Globals.SpawnTypes.None, loc.Type);
//        }

//        [TestMethod]
//        public void SpawnLocation_SetTypeSpace_Test()
//        {
//            var loc = new SpawnLocation(1, "test", Globals.Globals.SpawnTypes.None, 1000, 50);

//            loc.SetType("Space");
//            Assert.AreEqual(Globals.Globals.SpawnTypes.Space, loc.Type);
//        }

//        [TestMethod]
//        public void SpawnLocation_SetTypeAccess_Test()
//        {
//            var loc = new SpawnLocation(1, "test", Globals.Globals.SpawnTypes.None, 1000, 50);

//            loc.SetType("Access");
//            Assert.AreEqual(Globals.Globals.SpawnTypes.Access, loc.Type);
//        }
//    }
//}
