using FluentAssertions;
using Realm.Library.Ai.Test;
using Realm.Library.Ai.Test.Fakes;
using System;
using Xunit;

namespace Realm.Library.Ai.Fact
{
    public class AiBrainFacts
    {
        [Fact]
        public void Constructor_GetsNullOwner_ThrowsException()
        {
            Action act = () => new FakeAiBrain(null, null, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_GetsNullMessageHandler_ThrowsException()
        {
            Action act = () => new FakeAiBrain(new FakeEntity(1, "Fact"), null, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_GetsNullBehavior_ThrowsException()
        {
            Action act = () => new FakeAiBrain(new FakeEntity(1, "Fact"), new MessageContext(), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void PushState_GetsNullParameter_ThrowsException()
        {
            var target = Helper.GetBrain();

            Action act = () => target.PushState(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void PushState_GetsValidState_IsNowOnTopOfStack()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            var expected = state;
            var actual = target.PopState();

            actual.Should().Be(expected);
        }

        [Fact]
        public void PopState_PopsStateFromStack_IsValidState()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            var expected = state;
            var actual = target.PopState();

            actual.Should().Be(expected);
        }

        [Fact]
        public void HasState_GetsStringParameterEmpty_ThrowsException()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            Action act = () => target.HasState(string.Empty);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void HasState_GetsStateParameterNull_ThrowsException()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            Action act = () => target.HasState((IAiState)null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void HasState_VerifiesStateIsOnStack()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.HasState(state).Should().BeTrue();
        }

        [Fact]
        public void HasState_CheckByNameIfOnStack()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.HasState("test").Should().BeTrue();
        }

        [Fact]
        public void Wake_WhenCalled_IsNoLongerAsleep()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Wake();

            target.IsAsleep.Should().BeFalse();
        }

        [Fact]
        public void Wake_WhenCalled_AfterSleep_IsNowAwake()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);
            target.Sleep();

            target.Wake();

            target.IsAsleep.Should().BeFalse();
        }

        [Fact]
        public void Wake_WHenCalled_MakesTopStateActive()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Wake();

            target.CurrentState.IsPaused.Should().BeFalse();
        }

        [Fact]
        public void Sleep_WhenCalled_IsNowAsleep()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Sleep();

            target.IsAsleep.Should().BeTrue(); 
        }

        [Fact]
        public void Sleep_WhenCalled_MakesTopStateInactive()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Sleep();

            target.CurrentState.IsPaused.Should().BeTrue();  
        }
    }
}
