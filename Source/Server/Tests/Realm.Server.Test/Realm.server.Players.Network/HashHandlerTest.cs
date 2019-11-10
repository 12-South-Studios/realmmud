//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Players;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.server.Players.Network
//{
//    [TestClass]
//    public class HashHandlerTest
//    {
//        [Fact]
//        public void HashHandler_Constructor_NonNullRepository_Test()
//        {
//            var handler = new HashHandler(TestHelper.MockLogger.Object, new HashRepository());
//            Assert.IsNotNull(handler);
//            Assert.IsNotNull(handler.Hashes);
//        }

//        [Fact]
//        public void HashHandler_Constructor_NullRepository_Test()
//        {
//            var handler = new HashHandler(TestHelper.MockLogger.Object, null);
//            Assert.IsNotNull(handler);
//            Assert.IsNotNull(handler.Hashes);
//        }

//        [Fact]
//        public void HashHandler_GetHash_Valid_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetHash(1);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(1, actual.ID);
//            Assert.AreEqual("test", actual.Name);
//        }

//        [Fact]
//        public void HashHandler_GetHash_Invalid_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetHash(2);
//            Assert.IsNull(actual);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_OneParam_NoHash_Test()
//        {
//            var handler = new HashHandler(TestHelper.MockLogger.Object, null);

//            var actual = handler.GetRandomHash();
//            Assert.IsNull(actual);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_OneParam_OneHash_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetRandomHash();
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(1, actual.ID);
//            Assert.AreEqual("test", actual.Name);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_OneParam_TwoHash_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test1"));
//            repository.Add(2, new Hash(2, "test2"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetRandomHash();
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(1, actual.ID);
//            Assert.AreEqual("test1", actual.Name);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_TwoParam_NoHash_Test()
//        {
//            var handler = new HashHandler(TestHelper.MockLogger.Object, null);

//            var actual = handler.GetRandomHash(1, 5);
//            Assert.IsNull(actual);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_TwoParam_OneHash_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetRandomHash(1, 5);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(1, actual.ID);
//            Assert.AreEqual("test", actual.Name);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_TwoParam_TwoHash_LessThanMaxTries_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test1"));
//            repository.Add(2, new Hash(2, "test2"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetRandomHash(1, 5);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(2, actual.ID);
//            Assert.AreEqual("test2", actual.Name);
//        }

//        [Fact]
//        public void HashHandler_GetRandomHash_TwoParam_TwoHash_GreaterThanMaxTries_Test()
//        {
//            var repository = new HashRepository();
//            repository.Add(1, new Hash(1, "test1"));
//            repository.Add(2, new Hash(2, "test2"));
//            var handler = new HashHandler(TestHelper.MockLogger.Object, repository);

//            var actual = handler.GetRandomHash(1, 5);
//            Assert.IsNull(actual);
//        }
//    }
//}
