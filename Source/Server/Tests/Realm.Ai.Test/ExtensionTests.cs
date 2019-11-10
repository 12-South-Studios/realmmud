using System;
using FakeItEasy;
using Realm.Ai.Test.Fakes;
using Realm.Entity.Interfaces;
using Realm.Library.Common.Entities;
using Xunit;
using FluentAssertions;

namespace Realm.Ai.Test
{
    public class ExtensionTests
    {
        [Fact]
        public void GetDeadState_Returns_Valid_State()
        {
            var fakeState = new FakeAiState();

            var entityMgr = A.Fake<IEntityManager>();
            A.CallTo(() => entityMgr.Create(A<IHelper<Type>>.Ignored, "dead", A<object[]>.Ignored)).Returns(fakeState);

            var result = entityMgr.GetDeadState(new FakeMob());
            result.Should().Be(fakeState);
        }
    }
}
