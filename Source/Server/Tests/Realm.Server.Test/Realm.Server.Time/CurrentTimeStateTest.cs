//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Server.Test.Helpers;
//using Realm.Server.Time;

//namespace Realm.Server.Test.Realm.Server.Time
//{
//    [TestClass]
//    public class CurrentTimeStateTest
//    {
//        [Fact]
//        public void CurrentTimeState_Constructor_Test()
//        {
//            var timeManager = TestHelper.MockTimeManager;
//            timeManager.Setup(s => s.GetMonth(It.IsAny<long>()))
//                .Returns(new Month(9, "Test", 30, Globals.Globals.SeasonTypes.Summer, true));

//            var target = new GameState(timeManager.Object, 2012, 09, 19, 12, 30, "Dusk");

//            const int expectedYear = 2012;
//            const int expectedMonth = 9;
//            const int expectedDay = 19;
//            const int expectedHour = 12;
//            const int expectedMinute = 30;
//            const Globals.Globals.DayStateTypes expectedState = Globals.Globals.DayStateTypes.Dusk;

//            Assert.AreEqual(expectedYear, target.Year);
//            Assert.IsNotNull(target.Month);
//            Assert.AreEqual(expectedMonth, target.Month.ID);
//            Assert.AreEqual(expectedDay, target.Day);
//            Assert.AreEqual(expectedHour, target.Hour);
//            Assert.AreEqual(expectedMinute, target.Minute);
//            Assert.AreEqual(expectedState, target.DayState);
//        }

//        [Fact]
//        public void CurrentTimeState_DateTime_Test()
//        {
//            var timeManager = TestHelper.MockTimeManager;
//            timeManager.Setup(s => s.GetMonth(It.IsAny<long>()))
//                .Returns(new Month(9, "Test", 30, Globals.Globals.SeasonTypes.Summer, true));

//            var target = new GameState(timeManager.Object, 2012, 09, 19, 12, 30, "Dusk");

//            const string expected = "2012.9.19 12:30";
//            Assert.AreEqual(expected, target.DateTime);
//        }
//    }
//}
