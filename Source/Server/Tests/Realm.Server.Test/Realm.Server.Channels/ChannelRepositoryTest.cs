//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Channels;

//namespace Realm.Server.Test.Realm.Server.Channels
//{
//    [TestClass]
//    public class ChannelRepositoryTest
//    {
//        private static Channel GetChannel()
//        {
//            return new Channel(1, "test", Globals.Globals.ChannelTypes.System, true, true, true, string.Empty, 0);
//        }

//        [Fact]
//        public void ChannelRepository_Add_Test()
//        {
//            var repository = new ChannelRepository();
//            repository.Add(1, GetChannel());

//            const int count = 1;
//            var actual = repository.Count;

//            Assert.AreEqual(count, actual);
//        }

//        [Fact]
//        public void ChannelRepository_AddNullChannel_Test()
//        {
//            var repository = new ChannelRepository();
//            repository.Add(1, null);

//            const int count = 0;
//            var actual = repository.Count;

//            Assert.AreEqual(count, actual);
//        }

//        [Fact]
//        public void ChannelRepository_AddDuplicateChannelTest()
//        {
//            var repository = new ChannelRepository();
//            repository.Add(1, GetChannel());
//            repository.Add(1, GetChannel());

//            const int count = 1;
//            var actual = repository.Count;

//            Assert.AreEqual(count, actual);
//        }

//        [Fact]
//        public void ChannelRepository_Delete_Test()
//        {
//            var repository = new ChannelRepository();
//            repository.Add(1, GetChannel());

//            Assert.AreEqual(1, repository.Count);

//            repository.Delete(1);

//            Assert.AreEqual(0, repository.Count);            
//        }

//        [Fact]
//        public void ChannelRepository_GetByName_Test()
//        {
//            var repository = new ChannelRepository();
//            repository.Add(1, GetChannel());

//            var channel = repository.Get("test");
//            Assert.IsNotNull(channel);

//            const int id = 1;
//            Assert.AreEqual(id, channel.ID);

//            const string name = "test";
//            Assert.AreEqual(name, channel.Name);
//        }

//        [Fact]
//        public void ChannelRepository_GetById_Test()
//        {
//            var repository = new ChannelRepository();
//            repository.Add(1, GetChannel());

//            var channel = repository.Get(1);
//            Assert.IsNotNull(channel);

//            const int id = 1;
//            Assert.AreEqual(id, channel.ID);

//            const string name = "test";
//            Assert.AreEqual(name, channel.Name);
//        }


//    }
//}
