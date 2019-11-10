//using System.Collections.Generic;
//using Realm.Server.Time;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Realm.Server.Test.Realm.Server.Time
//{
//    [TestClass]
//    public class MonthTest
//    {
//        private static Month GetTestMonth()
//        {
//            return new Month(1, "TestMonth", 30, Globals.Globals.SeasonTypes.Summer, true);
//        }

//        [Fact]
//        public void Month_Constructor_Test()
//        {
//            var target = GetTestMonth();

//            const int expectedId = 1;
//            const string expectedName = "TestMonth";
//            const int expectedDays = 30;
//            const Globals.Globals.SeasonTypes expectedSeason = Globals.Globals.SeasonTypes.Summer;
//            const bool expectedShrouding = true;

//            Assert.AreEqual(expectedId, target.ID);
//            Assert.AreEqual(expectedName, target.Name);
//            Assert.AreEqual(expectedDays, target.NumberDays);
//            Assert.AreEqual(expectedSeason, target.Season);
//            Assert.AreEqual(expectedShrouding, target.IsShrouding);
//        }

//        [Fact]
//        public void Month_AddEffect_Test()
//        {
//            var target = GetTestMonth();

//            const int effectId = 1;
//            target.AddEffect(effectId);

//            const bool expected = true;
//            var actual = target.HasEffect(effectId);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void Month_HasEffect_Contains_Test()
//        {
//            var target = GetTestMonth();

//            const int effectId = 1;
//            target.AddEffect(effectId);

//            const bool expected = true;
//            var actual = target.HasEffect(effectId);
//            Assert.AreEqual(expected, actual);     
//        }

//        [Fact]
//        public void Month_HasEffect_DoesNotContains_Test()
//        {
//            var target = GetTestMonth();

//            const int effectId = 1;
//            const bool expected = false;

//            var actual = target.HasEffect(effectId);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void Month_Effects_Count_Test()
//        {
//            var target = GetTestMonth();

//            target.AddEffect(1);
//            target.AddEffect(2);

//            const int expected = 2;
//            var actual = target.Effects;
//            var effectList = new List<long>(actual);
//            Assert.AreEqual(expected, effectList.Count);
//        }
//    }
//}
