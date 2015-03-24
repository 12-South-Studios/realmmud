//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Library.Common;

//namespace Realm.Server.Test.Realm.Server.Handlers
//{
//    [TestClass]
//    public class FlagContextTest
//    {
//        [TestMethod]
//        public void SetFlagTest()
//        {
//            var target = new FlagContext(null);
//            target.SetFlag("a");

//            const bool expected = true;
//            var actual = target.HasFlag("a");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void HasFlagTest()
//        {
//            var target = new FlagContext(null);
//            target.SetFlag("a");

//            const bool expected = true;
//            var actual = target.HasFlag("a");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void UnsetFlagTest()
//        {
//            var target = new FlagContext(null);
//            target.SetFlag("a");
//            target.UnsetFlag("a");

//            const bool expected = false;
//            var actual = target.HasFlag("a");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void SetFlagListTest()
//        {
//            var target = new FlagContext(null) { FlagList = new List<string> { "a", "b" } };

//            const bool expected = true;
//            var actual = target.HasFlag("a");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetFlagListTest()
//        {
//            var target = new FlagContext(null) { FlagList = new List<string> { "a", "b" } };

//            const int expected = 2;
//            var actual = target.FlagList as List<string>;
//            if (actual == null)
//                throw new Exception("Null flag list");
//            Assert.AreEqual(expected, actual.Count);
//        }

//        [TestMethod]
//        public void GetFlagsTest()
//        {
//            var target = new FlagContext(null) { FlagList = new List<string> { "a", "b" } };

//            const string expected = "ab";
//            var actual = target.Flags;
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
