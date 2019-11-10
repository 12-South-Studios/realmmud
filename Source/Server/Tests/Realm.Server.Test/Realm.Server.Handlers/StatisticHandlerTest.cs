//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Library.Common;
//using Realm.Server.Attributes;
//using Realm.Server.Contexts;
//using Realm.Server.Managers;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Handlers
//{
//    [TestClass]
//    public class StatisticHandlerTest
//    {
//        [Fact]
//        public void StatisticHandler_Constructor_Test()
//        {
//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity);

//            Assert.IsNotNull(handler);
//            Assert.IsNotNull(handler.Stats);
//            Assert.IsNotNull(handler.Skills);
//            Assert.AreEqual(fakeEntity, handler.Owner);
//        }

//        [Fact]
//        public void StatisticHandler_AddSkill_SkillNotFound_Test()
//        {
//            var mockData = new Mock<IDataManager>();
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>()))
//                .Returns((Skill)null);

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//                              {
//                                  DataManager = mockData.Object
//                              };

//            const bool expected = false;
//            var actual = handler.AddSkill("Test", 5, 5);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void StatisticHandler_AddSkill_Success_Test()
//        {
//            var skill = new Skill(1, "Test", new SkillCategory(1, "Test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 25, true, null);

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(skill);

//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                DataManager = mockData.Object,
//                Log = mockLog.Object
//            };

//            const bool expected = true;
//            var actual = handler.AddSkill("Test", 5, 5);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void StatisticHandler_AddSkill_AlreadyContains_Test()
//        {
//            var skill = new Skill(1, "Test", new SkillCategory(1, "Test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 25, true, null);

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(skill);

//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                DataManager = mockData.Object,
//                Log = mockLog.Object
//            };

//            handler.AddSkill("Test", 5, 5);

//            const bool expected = false;
//            var actual = handler.AddSkill("Test", 5, 5);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void StatisticHandler_GetSkill_Success_Test()
//        {
//            var skill = new Skill(1, "Test", new SkillCategory(1, "Test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 25, true, null);

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(skill);

//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                DataManager = mockData.Object,
//                Log = mockLog.Object
//            };

//            handler.AddSkill("Test", 5, 5);

//            var actual = handler.GetSkill("Test");
//            Assert.IsNotNull(actual);
//        }

//        [Fact]
//        public void StatisticHandler_GetSkill_NotFound_Test()
//        {
//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>())).Returns((Skill)null);

//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                DataManager = mockData.Object,
//                Log = mockLog.Object
//            };

//            var actual = handler.GetSkill("Tester");
//            Assert.IsNull(actual);
//        }

//        [Fact]
//        public void StatisticHandler_AddStat_StatNotFound_Test()
//        {
//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity);

//            const bool expected = false;
//            var actual = handler.AddStat("FakeStat", 5, 5);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void StatisticHandler_AddStat_Success_Test()
//        {
//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                Log = mockLog.Object
//            };

//            const bool expected = true;
//            var actual = handler.AddStat("Strength", 5, 5);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void StatisticHandler_AddStat_AlreadyContains_Test()
//        {
//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                Log = mockLog.Object
//            };

//            handler.AddStat("Strength", 5, 5);

//            const bool expected = false;
//            var actual = handler.AddStat("Strength", 5, 5);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void StatisticHandler_GetStat_Success_Test()
//        {
//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                Log = mockLog.Object
//            };

//            handler.AddStat("Strength", 5, 5);

//            var actual = handler.GetStat(Globals.Globals.Statistics.Strength);
//            Assert.IsNotNull(actual);
//        }

//        [Fact]
//        public void StatisticHandler_GetStat_NotFound_Test()
//        {
//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var fakeEntity = new FakeGameEntity();
//            var handler = new StatisticHandler(fakeEntity)
//            {
//                Log = mockLog.Object
//            };

//            var actual = handler.GetStat(Globals.Globals.Statistics.Strength);
//            Assert.IsNull(actual);
//        }

//        [Fact]
//        public void StatisticHandler_CalculateCoreStat_Test()
//        {
//            var mockProperties = new Mock<IPropertyContext>();
//            mockProperties.Setup(s => s.GetProperty<int>(It.IsAny<string>())).Returns(5);

//            var mockGame = TestHelper.MockGame;
//            mockGame.SetupGet(s => s.Properties).Returns(mockProperties.Object);

//            var mockLog = TestHelper.MockLogger;
//            mockLog.Setup(s => s.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));

//            var handler = new StatisticHandler(null)
//            {
//                Game = mockGame.Object,
//                Log = mockLog.Object
//            };

//            handler.AddStat("Strength", 5, 5);

//            const int expected = 30;
//            var actual = handler.CalculateCoreStat(Globals.Globals.Statistics.Strength);
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
