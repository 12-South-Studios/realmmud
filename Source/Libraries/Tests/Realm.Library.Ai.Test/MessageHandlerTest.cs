using System;
using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Realm.Library.Common.Logging;
using Xunit;
using Xunit.Sdk;

namespace Realm.Library.Ai.Fact
{
    public class MessageHandlerFact
    {
        [Fact]
        public void Add_ProperlyAddsMessagesToList()
        {
            var target = new MessageContext();
            target.Add("Fact");

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new XunitException("Message list was null.");

            messageList.Count.Should().Be(1);
        }

        [Fact]
        public void Clear_RemovesMessages()
        {
            var target = new MessageContext();
            target.Add("Fact");
            target.Clear();

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new XunitException("Message list was null.");

            messageList.Count.Should().Be(0);
        }

        [Fact]
        public void Get_ReturnsValidMessageList()
        {
            var target = new MessageContext();
            target.Add("Fact");

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new XunitException("Message list was null.");

            messageList.Should().NotBeNull();
        }

        [Fact]
        public void Dump_GetsMessageList_OutputsCorrectNumberOfEntries()
        {
            var target = new MessageContext();
            target.Add("Fact");

            var callbackTimes = 0;

            var logger = A.Fake<ILogWrapper>();
            A.CallTo(() => logger.Info(A<object>.Ignored)).Invokes(() => callbackTimes++);

            target.Dump(logger);

            var messageList = target.Get() as IList<string>;
            if (messageList == null)
                throw new XunitException("Message list was null.");

            messageList.Count.Should().Be(0);
            callbackTimes.Should().Be(1);
        }

        [Fact]
        public void Dump_GetsNullParameter_ThrowsException()
        {
            var target = new MessageContext();
            target.Add("Fact");

            Action act = () => target.Dump(null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
