//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Server.Abilities;
//using Realm.Server.Players;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Players
//{
//    [TestClass]
//    public class AbilityRepositoryTest
//    {
//        internal class FakeAbilityTemplate : FakeGameTemplate { }

//        [Fact]
//        public void AbilityRepository_AddAbility_AlreadyExists_Test()
//        {
//            var repository = new AbilityRepository(TestHelper.MockGame.Object, TestHelper.MockEntityManager.Object);

//            const bool expected = false;
//            var actual = repository.AddAbility(1);
//            Assert.AreEqual(expected, actual);
//        }

//        [Fact]
//        public void AbilityRepository_AddAbility_NullTemplate_Test()
//        {
//            var mockEntity = TestHelper.MockEntityManager;
//            mockEntity.Setup(s => s.LuaGetTemplate(It.IsAny<long>())).Returns((AbilityTemplate)null);

//            var repository = new AbilityRepository(TestHelper.MockGame.Object, mockEntity.Object);

//            const bool expected = false;
//            var actual = repository.AddAbility(1);
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
