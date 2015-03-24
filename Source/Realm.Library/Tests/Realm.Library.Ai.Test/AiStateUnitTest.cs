using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Realm.Library.Ai.Test
{
    /*[TestClass]
    public class AiStateUnitTest
    {
        internal class FakeAiStateInstance : AiStateInstance
        {
            public FakeAiStateInstance(IAiStateTemplate template, IAiAgent parent)
                : base(template, parent)
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiStateInstance_Constructor_NullTemplate_Test()
        {
            new FakeAiStateInstance(null, null);

            Assert.Fail("Unit Test expected an ArgumnetNullException to be thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiStateInstance_Constructor_NullBrain_Test()
        {
            new FakeAiStateInstance(new FakeAiStateTemplate(1, "test"), null);

            Assert.Fail("Unit Test expected an ArgumnetNullException to be thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AiStateInstance_IsValid_NullParameter_Test()
        {
            var state = new FakeAiStateInstance(new FakeAiStateTemplate(1, "test"), Helper.GetBrain());

            state.IsValid(null);

            Assert.Fail("Unit Test expected an ArgumnetNullException to be thrown");
        }

        [TestMethod]
        public void AiStateInstance_IsValid_Test()
        {
            var state = new FakeAiStateInstance(new FakeAiStateTemplate(1, "test"), Helper.GetBrain());

            const bool expected = true;
            var actual = state.IsValid(new FakeEntity(1, "test"));

            Assert.AreEqual(expected, actual);
        }
    }*/
}
