using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using log4net;

namespace Realm.Library.Ai.Test
{
    [TestClass]
    public class MessageHandlerTest
    {
        [TestMethod]
        public void MessageHandler_AddTest()
        {
            var target = new MessageContext();
            const string value = "test";
            target.Add(value);
            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new Exception("Failed");

            const int expected = 1;
            Assert.AreEqual(expected, messageList.Count);
        }

        [TestMethod]
        public void MessageHandler_ClearTest()
        {
            var target = new MessageContext();
            const string value = "test";
            target.Add(value);
            target.Clear();

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new Exception("Failed");
            const int expected = 0;
            Assert.AreEqual(expected, messageList.Count);
        }

        [TestMethod]
        public void MessageHandler_GetTest()
        {
            var target = new MessageContext();
            const string value = "test";
            target.Add(value);
            var messageList = target.Get() as IList<string>;
            Assert.IsTrue(messageList != null);
        }

        [TestMethod]
        public void MessageHandler_DumpTest()
        {
            var target = new MessageContext();
            const string value = "test";
            target.Add(value);
            
            target.Dump(new Mock<ILog>().Object);

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new Exception("Failed");
            const int expected = 0;
            Assert.AreEqual(expected, messageList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MessageHandler_Dump_NullParameter_Test()
        {
            var target = new MessageContext();
            const string value = "test";
            target.Add(value);

            target.Dump(null);

            Assert.Fail("Unit Test expected an ArgumentNullException to be thrown");
        }
    }
}
