using System;
using NUnit.Framework;

namespace Realm.Library.Ai.Test
{
    [TestFixture]
    public class AiBrainTests
    {
        [Test]
        public void Constructor_GetsNullOwner_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new FakeAiBrain(null, null, null), 
                "Unit Test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void Constructor_GetsNullMessageHandler_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new FakeAiBrain(new FakeEntity(1, "test"), null, null), 
                "Unit Test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void Constructor_GetsNullBehavior_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new FakeAiBrain(new FakeEntity(1, "test"), 
                new MessageContext(), null), "Unit Test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void PushState_GetsNullParameter_ThrowsException()
        {
            var target = Helper.GetBrain();
            Assert.Throws<ArgumentNullException>(() => target.PushState(null), 
                "Unit Test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void PushState_GetsValidState_IsNowOnTopOfStack()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            var expected = state;
            var actual = target.PopState();

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void PopState_PopsStateFromStack_IsValidState()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            var expected = state;
            var actual = target.PopState();

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void HasState_GetsStringParameterEmpty_ThrowsException()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            Assert.Throws<ArgumentNullException>(() => target.HasState(string.Empty), 
                "Unit Test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void HasState_GetsStateParameterNull_ThrowsException()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            Assert.Throws<ArgumentNullException>(() => target.HasState((IAiState)null), 
                "Unit Test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void HasState_VerifiesStateIsOnStack()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            Assert.That(target.HasState(state), Is.True);
        }

        [Test]
        public void HasState_CheckByNameIfOnStack()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            Assert.That(target.HasState("Test"), Is.True);
        }

        [Test]
        public void Wake_WhenCalled_IsNoLongerAsleep()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Wake();

            Assert.That(target.IsAsleep, Is.False);
        }

        [Test]
        public void Wake_WhenCalled_AfterSleep_IsNowAwake()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);
            target.Sleep();

            target.Wake();

            Assert.That(target.IsAsleep, Is.False);
        }

        [Test]
        public void Wake_WHenCalled_MakesTopStateActive()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Wake();

            Assert.That(target.CurrentState.IsPaused, Is.False);
        }

        [Test]
        public void Sleep_WhenCalled_IsNowAsleep()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Sleep();

            Assert.That(target.IsAsleep, Is.True); 
        }

        [Test]
        public void Sleep_WhenCalled_MakesTopStateInactive()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.Sleep();

            Assert.That(target.CurrentState.IsPaused, Is.True);  
        }
    }
}
