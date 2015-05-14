//using log4net;
//using Moq;
//using NUnit.Framework;
//using Realm.Library.Common.Data;
//using Realm.Library.DatabaseEdmx;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;

//namespace Realm.Data.Test
//{
//    [TestFixture]
//    [ExcludeFromCodeCoverage]
//    public class GameConstantDalTest
//    {
//        [Test]
//        [ExpectedException(typeof(Exception))]
//        public void GetGameConstants_Exception_Test()
//        {
//            var mockRefContext = new Mock<IRefContext>();
//            var mockDboContext = new Mock<IDboContext>();
//            mockDboContext.Setup(x => x.GetGameConstants()).Throws(new Exception());
//            var mockLog = new Mock<ILog>();
//            mockLog.Setup(x => x.Error(It.IsAny<object>()));

//            var dal = new GameConstantDal(string.Empty, mockLog.Object, mockDboContext.Object, mockRefContext.Object);

//            dal.GetGameConstants();

//            Assert.Fail("Unit test expected an exception of type Exception to be thrown");
//        }

//        [TestCase(1, true, null, null, "")]
//        [TestCase(2, null, 25, null, "")]
//        [TestCase(3, null, null, 1.52f, "")]
//        [TestCase(4, null, null, null, "testing 1 2 3")]
//        public void GetGameConstants_Test(int id, bool? boolValue, int? intValue, float? floatValue, string stringValue)
//        {
//            var constantList = new List<Library.DatabaseEdmx.Dbo.GetGameConstants_Result>
//                {
//                    new Library.DatabaseEdmx.Dbo.GetGameConstants_Result
//                        {
//                            GameConstantID = Convert.ToInt16(id), 
//                            BoolValue = boolValue,
//                            IntValue = intValue,
//                            FloatValue = floatValue,
//                            StringValue = stringValue
//                        }
//                };

//            var mockRefContext = new Mock<IRefContext>();
//            var mockDboContext = new Mock<IDboContext>();
//            mockDboContext.Setup(x => x.GetGameConstants()).Returns(constantList);
//            var mockLog = new Mock<ILog>();

//            var dal = new GameConstantDal(string.Empty, mockLog.Object, mockDboContext.Object, mockRefContext.Object);

//            var resultList = dal.GetGameConstants().ToList();

//            Assert.IsNotNull(resultList);
//            Assert.IsTrue(resultList.Any());

//            var atom = resultList[0];
//            var constantAtom = (DictionaryAtom) atom;

//            Assert.AreEqual(id, constantAtom.GetInt("ID"));
//            Assert.AreEqual(boolValue.GetValueOrDefault(false), constantAtom.GetBool("BoolValue"));
//            Assert.AreEqual(intValue.GetValueOrDefault(0), constantAtom.GetInt("IntValue"));
//            Assert.AreEqual(floatValue.GetValueOrDefault(0.0f), constantAtom.GetReal("FloatValue"));
//            Assert.AreEqual(stringValue, constantAtom.GetString("StringValue"));
//        }

//        [Test]
//        [ExpectedException(typeof(Exception))]
//        public void GetGameRefConstants_Exception_Test()
//        {
//            var mockRefContext = new Mock<IRefContext>();
//            mockRefContext.Setup(x => x.GetGameConstants()).Throws(new Exception());
//            var mockDboContext = new Mock<IDboContext>();
//            var mockLog = new Mock<ILog>();
//            mockLog.Setup(x => x.Error(It.IsAny<object>()));

//            var dal = new GameConstantDal(string.Empty, mockLog.Object, mockDboContext.Object, mockRefContext.Object);

//            dal.GetGameRefConstants();

//            Assert.Fail("Unit test expected an exception of type Exception to be thrown");
//        }

//        [TestCase(1, "Test", "Tester", "Testing 1 2 3")]
//        public void GetGameRefConstants_Test(int id, string name, string type, string description)
//        {
//            var constantList = new List<Library.DatabaseEdmx.Ref.GetGameConstants_Result>
//                {
//                    new Library.DatabaseEdmx.Ref.GetGameConstants_Result
//                        {
//                            GameConstantID = Convert.ToInt16(id),
//                            Name = name,
//                            Type = type,
//                            Description = description
//                        }
//                };

//            var mockRefContext = new Mock<IRefContext>();
//            mockRefContext.Setup(x => x.GetGameConstants()).Returns(constantList);
//            var mockDboContext = new Mock<IDboContext>();
//            var mockLog = new Mock<ILog>();

//            var dal = new GameConstantDal(string.Empty, mockLog.Object, mockDboContext.Object, mockRefContext.Object);

//            var resultList = dal.GetGameRefConstants().ToList();

//            Assert.IsNotNull(resultList);
//            Assert.IsTrue(resultList.Any());

//            var atom = resultList[0];
//            var constantAtom = (DictionaryAtom)atom;

//            Assert.AreEqual(id, constantAtom.GetInt("ID"));
//            Assert.AreEqual(name, constantAtom.GetString("Name"));
//            Assert.AreEqual(type, constantAtom.GetString("Type"));
//            Assert.AreEqual(description, constantAtom.GetString("Description"));
//        }
//    }
//}
