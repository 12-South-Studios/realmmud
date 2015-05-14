//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Library.Common;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Realm.Server.Zones
//{
//    [TestClass]
//    public class TerrainTest
//    {
//        [TestMethod]
//        public void Terrain_Cost_Test()
//        {
//            var terrain = new Terrain(1, "test", new PropertyContext(null));
//            Assert.IsNotNull(terrain);

//            terrain.Cost = 50;
//            Assert.AreEqual(50, terrain.Cost);
//        }

//        [TestMethod]
//        public void Terrain_IsLitBySun_Test()
//        {
//            var terrain = new Terrain(1, "test", new PropertyContext(null));
//            Assert.IsNotNull(terrain);

//            terrain.IsLitBySun = true;
//            Assert.AreEqual(true, terrain.IsLitBySun);
//        }

//        [TestMethod]
//        public void Terrain_Description_Test()
//        {
//            var terrain = new Terrain(1, "test", new PropertyContext(null));
//            Assert.IsNotNull(terrain);

//            terrain.Description = "This is a test";
//            Assert.AreEqual("This is a test", terrain.Description);
//        }

//        [TestMethod]
//        public void Terrain_Skill_Test()
//        {
//            var terrain = new Terrain(1, "test", new PropertyContext(null));
//            Assert.IsNotNull(terrain);

//            terrain.Skill = "Testing";
//            Assert.AreEqual("Testing", terrain.Skill);
//        }

//        [TestMethod]
//        public void Terrain_AddRestrictedMovementModeTypes_Negative_Test()
//        {
//            var terrain = new Terrain(1, "Test", new PropertyContext(null));

//            const bool expected = false;
//            var actual = terrain.HasMovementMode(Globals.Globals.MovementModeTypes.Flying);
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void Terrain_AddRestricted_MovementModeTypes_Positive_Test()
//        {
//            var terrain = new Terrain(1, "Test", new PropertyContext(null));
//            terrain.AddRestrictedMovementMode(Globals.Globals.MovementModeTypes.Flying);

//            const bool expected = true;
//            var actual = terrain.HasMovementMode(Globals.Globals.MovementModeTypes.Flying);
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void Terrain_Disallowed_MovementModeTypes_Test()
//        {
//            var terrain = new Terrain(1, "Test", new PropertyContext(null));
//            terrain.AddRestrictedMovementMode(Globals.Globals.MovementModeTypes.Flying);
//            terrain.AddRestrictedMovementMode(Globals.Globals.MovementModeTypes.Climbing);

//            const int expected = 2;
//            var modeList = new List<Globals.Globals.MovementModeTypes>(terrain.DisallowedMovementModes);
//            Assert.AreEqual(expected, modeList.Count);
//        }
//    }
//}
