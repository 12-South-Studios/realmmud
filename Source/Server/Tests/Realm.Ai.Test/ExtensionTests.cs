using System;
using NUnit.Framework;
using Moq;
using Realm.Ai.Test.Fakes;
using Realm.Entity;
using Realm.Library.Common;

namespace Realm.Ai.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void GetDeadState_Returns_Valid_State()
        {
            var fakeState = new FakeAiState();

            var mockEntityMgr = new Mock<IEntityManager>();
            mockEntityMgr.Setup(x => x.Create(It.IsAny<IHelper<Type>>(), It.Is<string>(s => s == "dead"), 
                It.IsAny<object[]>())).Returns(fakeState);

            Assert.That(mockEntityMgr.Object.GetDeadState(new FakeMob()), Is.EqualTo(fakeState));
        }
    }
}
