//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using log4net;
//using log4net.Core;

//namespace Realm.Test
//{
//    [TestClass]
//    public class LogWrapperTest
//    {
//        [TestMethod]
//        public void LogWrapper_Constructor_Test()
//        {
//            var mockLogger = new Mock<ILogger>();

//            var mockLog = new Mock<ILog>();
//            mockLog.SetupGet(s => s.Logger).Returns(mockLogger.Object);

//            var wrapper = new LogWrapper(mockLog.Object, LogLevel.Fatal);

//            const int expected = 5;
//            Assert.IsNotNull(wrapper);
//            Assert.AreEqual(mockLog.Object, wrapper.Log);
//            Assert.AreEqual(expected, wrapper.MinLoggingLevel);
//            Assert.IsNotNull(wrapper.Logger);
//        }

//        [TestMethod]
//        public void LogWrapper_LogThis_Test()
//        {
//            var mockLog = new Mock<ILog>();

//            var wrapper = new LogWrapper(mockLog.Object, LogLevel.Fatal);

//            const bool expected = false;
//            Assert.AreEqual(expected, wrapper.LogThis(LogLevel.Info));
//        }
//    }
//}
