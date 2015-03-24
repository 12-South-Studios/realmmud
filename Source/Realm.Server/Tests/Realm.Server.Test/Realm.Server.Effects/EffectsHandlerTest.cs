//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Effects;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Effects
//{
//    [TestClass]
//    public class EffectsHandlerTest
//    {
//        [TestMethod]
//        public void EffectsHandler_Constructor_Test()
//        {
//            var gameEntity = new FakeGameEntity();
//            var handler = new EffectsHandler(TestHelper.MockGame.Object,
//                TestHelper.MockEntityManager.Object, TestHelper.MockLogger.Object,
//                gameEntity);

//            Assert.IsNotNull(handler);
//            Assert.AreEqual(gameEntity, handler.Owner);
//        }
//    }
//}
