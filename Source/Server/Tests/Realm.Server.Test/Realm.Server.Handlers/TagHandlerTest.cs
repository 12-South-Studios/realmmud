//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Library.Common;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Handlers
//{
//    [TestClass]
//    public class TagContextTest
//    {
//        [TestMethod]
//        public void HasTagTest()
//        {
//            var target = new TagContext(null);

//            target.AddTag(new Tag(1, "TestTag"));

//            const bool expected = true;
//            var actual = target.HasTag("TestTag");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void AddTagTest()
//        {
//            var dataManager = TestHelper.MockDataManager;
//            dataManager.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>()))
//                .Returns(new Tag(1, "TestTag"));

//            var target = new TagContext(null);

//            target.AddTag(new Tag(1, "TestTag"));

//            const bool expected = true;
//            var actual = target.HasTag("TestTag");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void RemoveTagTest()
//        {
//            var target = new TagContext(null);

//            target.AddTag(new Tag(1, "TestTag"));
//            target.RemoveTag("TestTag");

//            const bool expected = false;
//            var actual = target.HasTag("TestTag");
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetTagsTest()
//        {
//            var target = new TagContext(null);
//            target.AddTag(new Tag(1, "TestTag"));
//            target.AddTag(new Tag(2, "TesterTag"));

//            const int expected = 2;
//            var actual = target.Tags;
//            Assert.AreEqual(expected, actual.Count);
//        }
//    }
//}
