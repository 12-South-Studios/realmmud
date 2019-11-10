//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Players;

//namespace Realm.Server.Test.Realm.server.Players.Network
//{
//    [TestClass]
//    public class HashRepositoryTest
//    {
//        [Fact]
//        public void HashRepository_GetRandomHash_Test()
//        {
//            var repository = new HashRepository();

//            var hash1 = new Hash(1, "test1");
//            repository.Add(1, hash1);

//            var hash2 = new Hash(2, "test2");
//            repository.Add(2, hash2);

//            var actual = repository.GetRandomValue();
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(hash1, actual);
//        }
//    }
//}
