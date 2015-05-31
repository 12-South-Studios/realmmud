using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Realm.Library.Common.Logging;

namespace Realm.Library.Ai.Test
{
    [TestFixture]
    public class MessageHandlerTest
    {
        [Test]
        public void Add_ProperlyAddsMessagesToList()
        {
            var target = new MessageContext();
            target.Add("test");

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                Assert.Fail("Message list was null.");

            Assert.That(messageList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Clear_RemovesMessages()
        {
            var target = new MessageContext();
            target.Add("test");
            target.Clear();

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                Assert.Fail("Message list was null.");

            Assert.That(messageList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Get_ReturnsValidMessageList()
        {
            var target = new MessageContext();
            target.Add("test");

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                Assert.Fail("Message list was null.");

            Assert.That(messageList, Is.Not.Null);
        }

        [Test]
        public void Dump_GetsMessageList_OutputsCorrectNumberOfEntries()
        {
            var target = new MessageContext();
            target.Add("test");

            var callbackTimes = 0;

            var mockLogger = new Mock<ILogWrapper>();
            mockLogger.Setup(x => x.Info(It.IsAny<object>())).Callback(() => callbackTimes++);

            target.Dump(mockLogger.Object);

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                Assert.Fail("Message list was null.");

            Assert.That(messageList.Count, Is.EqualTo(0));
            Assert.That(callbackTimes, Is.EqualTo(1));
        }

        [Test]
        public void Dump_GetsNullParameter_ThrowsException()
        {
            var target = new MessageContext();
            target.Add("test");

            Assert.Throws<ArgumentNullException>(() => target.Dump(null), 
                "Unit Test expected an ArgumentNullException to be thrown");
        }
    }
}
