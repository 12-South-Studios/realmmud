//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Library.Ai;
//using Realm.Library.Common;
//using Realm.Server.Ai;
//using Realm.Server.Test.Helpers;
//using log4net;

//namespace Realm.Server.Test.Realm.Server.Ai
//{
//    [TestClass]
//    public class MobBrainTest
//    {
//        internal class FakeBehavior : IBehavior
//        {
//            public IBitContext Bits { get; set; }
//            public IPropertyContext Properties { get; set; }
//            public IAiState NeedState()
//            {
//                return null;
//            }
//        }

//        [TestMethod]
//        public void MobBrain_Constructor_Test()
//        {
//            var fakeEntity = new FakeEntity();
//            var fakeBehavior = new FakeBehavior();

//            var mockLog = new Mock<ILog>();

//            var actual = new MobBrain(fakeEntity, new MessageContext(), fakeBehavior, mockLog.Object);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(fakeEntity, actual.Owner);
//            Assert.AreEqual(fakeBehavior, actual.Behavior);
//        }
//    }
//}
