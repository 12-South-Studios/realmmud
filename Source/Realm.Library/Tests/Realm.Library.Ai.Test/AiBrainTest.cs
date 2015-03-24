using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Realm.Library.Ai.Test
{
    [TestClass]
    public class AiBrainTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiBrain_Constructor_NullOwner_Test()
        {
            new FakeAiBrain(null, null, null);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiBrain_Constructor_NullMessageHandler_Test()
        {
            new FakeAiBrain(new FakeEntity(1, "test"), null, null);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiBrain_Constructor_NullBehavior_Test()
        {
            new FakeAiBrain(new FakeEntity(1, "test"), new MessageContext(), null);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiBrain_PushState_NullParameter_Test()
        {
            var target = Helper.GetBrain();
            target.PushState(null);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }

        [TestMethod]
        public void AiBrain_PushState_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            var expected = state;
            var actual = target.PopState();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AiBrain_PopState_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            var expected = state;
            var actual = target.PopState();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiBrain_HasState_StringParameterEmpty_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.HasState(string.Empty);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiBrain_HasState_StateParameterNull_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            target.HasState((IAiState)null);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }

        [TestMethod]
        public void AiBrain_HasState_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            const bool expected = true;
            var actual = target.HasState(state);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AiBrain_HasState_Name_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            const string value = "Test";
            const bool expected = true;
            var actual = target.HasState(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AiBrain_Wake_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            const bool expected = true;
            target.Wake();

            Assert.AreNotEqual(expected, target.IsAsleep);
        }

        [TestMethod]
        public void AiBrain_Wake_AlreadySleep_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);
            target.Sleep();

            const bool expected = false;
            target.Wake();

            Assert.AreEqual(expected, target.IsAsleep);
        }

        [TestMethod]
        public void AiBrain_Wake_StateActive_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            const bool expected = true;
            target.Wake();

            Assert.AreNotEqual(expected, target.CurrentState.IsPaused);
        }

        [TestMethod]
        public void AiBrain_Sleep_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            const bool expected = true;
            target.Sleep();

            Assert.AreEqual(expected, target.IsAsleep); 
        }

        [TestMethod]
        public void AiBrain_Sleep_StatePaused_Test()
        {
            var target = Helper.GetBrain();
            var state = target.NeedState();
            target.PushState(state);

            const bool expected = true;
            target.Sleep();

            Assert.AreEqual(expected, target.CurrentState.IsPaused);  
        }
    }
}
