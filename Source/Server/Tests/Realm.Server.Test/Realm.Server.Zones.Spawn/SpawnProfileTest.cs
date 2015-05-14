//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Server.Test.Helpers;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Realm.Server.Zones.Spawn
//{
//    [TestClass]
//    public class SpawnProfileTest
//    {
//        [TestMethod]
//        public void SpawnProfile_Constructor_Test()
//        {
//            var profile = new SpawnProfile(1, "test", 1, 2, 100);

//            Assert.IsNotNull(profile);
//            Assert.AreEqual(1, profile.ID);
//            Assert.AreEqual("test", profile.Name);
//            Assert.AreEqual(1, profile.MinQuantity);
//            Assert.AreEqual(2, profile.MaxQuantity);
//            Assert.AreEqual(100, profile.Chance);
//        }

//        [TestMethod]
//        public void SpawnProfile_SetMinQuantity_Test()
//        {
//            var profile = new SpawnProfile(1, "test", 1, 10, 100);

//            Assert.IsNotNull(profile);

//            profile.MinQuantity = 5;
//            Assert.AreEqual(5, profile.MinQuantity);
//        }

//        [TestMethod]
//        public void SpawnProfile_SetMinQuantityGreaterThanMax_Test()
//        {
//            var profile = new SpawnProfile(1, "test", 1, 10, 100);

//            Assert.IsNotNull(profile);

//            profile.MinQuantity = 15;
//            Assert.AreEqual(15, profile.MaxQuantity);
//        }

//        [TestMethod]
//        public void SpawnProfile_AddEntity_Test()
//        {
//            var mockEntityManager = TestHelper.MockEntityManager;
//            mockEntityManager.Setup(s => s.LuaGetTemplate(It.IsAny<long>())).Returns(new FakeGameTemplate());

//            var profile = new SpawnProfile(1, "test", 1, 10, 100);

//            profile.AddEntity(mockEntityManager.Object, 1);

//            Assert.AreEqual(1, profile.EntityCount);
//        }

//        [TestMethod]
//        public void SpawnProfile_AddEntityAlreadyExists_Test()
//        {
//            var mockEntityManager = TestHelper.MockEntityManager;
//            mockEntityManager.Setup(s => s.LuaGetTemplate(It.IsAny<long>())).Returns(new FakeGameTemplate());

//            var profile = new SpawnProfile(1, "test", 1, 10, 100);
//            profile.AddEntity(mockEntityManager.Object, 1);

//            profile.AddEntity(mockEntityManager.Object, 1);
//            Assert.AreEqual(1, profile.EntityCount);
//        }

//        [TestMethod]
//        public void SpawnProfile_PickTemplateRandom_Test()
//        {
//            var mockEntityManager = TestHelper.MockEntityManager;
//            mockEntityManager.Setup(s => s.LuaGetTemplate(It.IsAny<long>())).Returns(new FakeGameTemplate());

//            var profile = new SpawnProfile(1, "test", 1, 10, 100);
//            profile.AddEntity(mockEntityManager.Object, 1);

//            var actual = profile.PickTemplate();
//            Assert.IsNotNull(actual);
//        }

//        [TestMethod]
//        public void SpawnProfile_PickTemplateRoundRobin_Test()
//        {
//            var mockEntityManager = TestHelper.MockEntityManager;
//            mockEntityManager.Setup(s => s.LuaGetTemplate(It.IsAny<long>())).Returns(new FakeGameTemplate());

//            var profile = new SpawnProfile(1, "test", 1, 10, 100);
//            profile.AddEntity(mockEntityManager.Object, 1);

//            var actual = profile.PickTemplate();
//            Assert.IsNotNull(actual);
//        }
//    }
//}
