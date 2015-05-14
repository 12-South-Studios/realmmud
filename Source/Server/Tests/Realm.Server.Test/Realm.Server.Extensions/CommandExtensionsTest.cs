//using NUnit.Framework;
//using Moq;
//using Realm.Library.Common;
//using Realm.Server.Entities;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Extensions
//{
//    [TestFixture]
//    public class CommandExtensionsTest
//    {
//        [TestCase("Wizard", true)]
//        [TestCase("Admin", true)]
//        [TestCase("", false)]
//        public void IsAdmin_Test(string flag, bool expected)
//        {
//            var FlagContext = new FlagContext(null);
//            FlagContext.SetFlag(flag);

//            Assert.AreEqual(expected, FlagContext.IsAdmin());
//        }

//        [TestCase("Wizard", true)]
//        [TestCase("Admin", true)]
//        [TestCase("Builder", true)]
//        [TestCase("", false)]
//        public void IsBuilder_Test(string flag, bool expected)
//        {
//            var FlagContext = new FlagContext(null);
//            FlagContext.SetFlag(flag);

//            Assert.AreEqual(expected, FlagContext.IsBuilder());
//        }

//        [Test]
//        public void KeywordCheckAndNotify_NullUser_Test()
//        {
//            var mockCommand = TestHelper.MockCommandManager;

//            const bool expected = false;
//            var actual = mockCommand.Object.KeywordCheckAndNotify(null, "testing");
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void KeywordCheckAndNotify_ValidKeyword_Test()
//        {
//            var mockCommand = TestHelper.MockCommandManager;

//            const bool expected = false;
//            var actual = mockCommand.Object.KeywordCheckAndNotify(new FakeGameUser(), "testing");
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void KeywordCheckAndNotify_InvalidKeyword_Test()
//        {
//            var mockCommand = TestHelper.MockCommandManager;
//            mockCommand.Setup(s => s.Report(It.IsAny<Globals.Globals.MessageScopeTypes>(), It.IsAny<string>(), It.IsAny<IEntity>(), 
//                It.IsAny<IEntity>(), It.IsAny<object>(), It.IsAny<object>(), It.IsAny<IGameEntity>(), It.IsAny<object>()));

//            const bool expected = true;
//            var actual = mockCommand.Object.KeywordCheckAndNotify(new FakeGameUser(), string.Empty);
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void AdminFlagCheckAndNotify_NullUser_Test()
//        {
//            var FlagContext = new FlagContext(null);
//            FlagContext.SetFlag("Wizard");

//            const bool expected = false;
//            var actual = TestHelper.MockCommandManager.Object.AdminFlagCheckAndNotify(null, FlagContext);
//            Assert.AreEqual(expected, actual); 
//        }

//        [Test]
//        public void AdminFlagCheckAndNotify_NullFlagContext_Test()
//        {
//            var gameUser = new FakeGameUser();

//            const bool expected = false;
//            var actual = TestHelper.MockCommandManager.Object.AdminFlagCheckAndNotify(gameUser, null);
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void AdminFlagCheckAndNotify_IsAdmin_Test()
//        {
//            var gameUser = new FakeGameUser();
//            var FlagContext = new FlagContext(null);
//            FlagContext.SetFlag("Wizard");

//            const bool expected = false;
//            var actual = TestHelper.MockCommandManager.Object.AdminFlagCheckAndNotify(gameUser, FlagContext);
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
