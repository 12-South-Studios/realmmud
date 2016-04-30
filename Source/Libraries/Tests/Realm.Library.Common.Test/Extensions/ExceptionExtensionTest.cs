using System;
using Moq;
using NUnit.Framework;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Exceptions;

namespace Realm.Library.Common.Test.Extensions
{
    [TestFixture]
    public class ExceptionExtensionTests
    {
        private class TestException : Exception
        {
            public TestException(string msg, Exception innerException) : base(msg, innerException) { }
        }

        [TestCase(ExceptionHandlingOptions.RecordOnly, "Test", false)]
        [TestCase(ExceptionHandlingOptions.RecordOnly, "", false)]
        [TestCase(ExceptionHandlingOptions.Suppress, "Test", true)]
        public void HandleGenericTest(ExceptionHandlingOptions options, string msg, bool throwLoggingException)
        {
            var mockLog = new Mock<ILogWrapper>();
            if (throwLoggingException)
                mockLog.Setup(x => x.Error(It.IsAny<object>(), It.IsAny<Exception>()))
                    .Throws(new InvalidOperationException("Unit test should not get an exception of this type"));
            else
                mockLog.Setup(x => x.Error(It.IsAny<object>(), It.IsAny<Exception>()));

            try
            {
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                ex.Handle<TestException>(options, mockLog.Object, msg);
            }
        }

        [Test]
        public void Handle_ReThrowsException_WhenRecordAndThrowIsOption()
        {
            var mockLog = new Mock<ILogWrapper>();
            mockLog.Setup(x => x.Error(It.IsAny<object>(), It.IsAny<Exception>()));

            try
            {
                throw new Exception("Test");
            }
            catch (Exception ex)
            {
                Assert.Throws<TestException>(
                    () => ex.Handle<TestException>(ExceptionHandlingOptions.RecordAndThrow, mockLog.Object, "Test"));
            }
        }

        [Test]
        public void Handle_ReThrowsException_WhenThrowOnlyIsOption()
        {
            var mockLog = new Mock<ILogWrapper>();
            mockLog.Setup(x => x.Error(It.IsAny<object>(), It.IsAny<Exception>()))
                .Throws(new InvalidOperationException("Unit test should not get an exception of this type"));

            try
            {
                throw new Exception("Test");
            }
            catch (Exception ex)
            {
                Assert.Throws<TestException>(
                    () => ex.Handle<TestException>(ExceptionHandlingOptions.ThrowOnly, mockLog.Object, "Test"));
            }
        }

        [TestCase(ExceptionHandlingOptions.RecordOnly, "Test", false)]
        [TestCase(ExceptionHandlingOptions.RecordOnly, "", false)]
        [TestCase(ExceptionHandlingOptions.Suppress, "Test", true)]
        public void HandleTest(ExceptionHandlingOptions options, string msg, bool throwLoggingException)
        {
            var mockLog = new Mock<ILogWrapper>();
            if (throwLoggingException)
                mockLog.Setup(x => x.Error(It.IsAny<object>(), It.IsAny<Exception>()))
                    .Throws(new InvalidOperationException("Unit test should not get an exception of this type"));
            else
                mockLog.Setup(x => x.Error(It.IsAny<object>(), It.IsAny<Exception>()));

            try
            {
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                ex.Handle(options, mockLog.Object, msg);
            }
        }
    }
}
