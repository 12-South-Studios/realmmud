using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Moq;
using NUnit.Framework;
using Realm.Library.Common.Logging;
using Realm.Library.SmallDb.Test.Fakes;

namespace Realm.Library.SmallDb.Test
{
    [TestFixture]
    public class SmallDbTests
    {
        private class FakeObject
        {
            public static string Name => "Fake";
        }  

        [Test]
        public void ValidateArguments_TakesNullConnection_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => SmallDb.ValidateArguments(null, "TestProcedure"), 
                "Unit test expected an ArgumentNullException to be thrown!");
        }

        [Test]
        public void ValidateArguments_TakesEmptyStoredProcedureName_ThrowsException()
        {
            var mockConnection = new Mock<IDbConnection>();

            Assert.Throws<ArgumentNullException>(() => SmallDb.ValidateArguments(mockConnection.Object, string.Empty),
                "Unit test expected an ArgumentNullException to be thrown!");
        }

        [Test]
        public void ValidateArguments_TakesValidArguments_DoesNothing()
        {
            var mockConnection = new Mock<IDbConnection>();

            Assert.DoesNotThrow(() => SmallDb.ValidateArguments(mockConnection.Object, "TestProcedure"),
                "Unit Test threw an exception that was not expected!");
        }

        [Test]
        public void SetupDbCommand_TakesParameters_PopulatesCommand()
        {
            var parameterList = new List<IDataParameter>
                {
                    new SqlParameter("TestParam1", SqlDbType.Int),
                    new SqlParameter("TestParam2", SqlDbType.VarChar)
                };

            var fakeCommand = new FakeDbCommand();

            var mockConnection = new Mock<IDbConnection>();

            SmallDb.SetupDbCommand(mockConnection.Object, fakeCommand, "TestProcedure", parameterList);

            Assert.That(fakeCommand.Connection, Is.EqualTo(mockConnection.Object));
            Assert.That(fakeCommand.CommandText, Is.EqualTo("TestProcedure"));
            Assert.That(fakeCommand.Parameters.Count == 2, Is.True);
        }

        [Test]
        public void ExecuteScalar_TakesNoParameters_ReturnsValidResult()
        {
            const string expected = "This is a test result";

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.Setup(x => x.ExecuteScalar()).Returns(expected);
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var mockLogger = new Mock<ILogWrapper>();

            var helper = new SmallDb(mockLogger.Object);
            var actualResult = helper.ExecuteScalar(mockConnection.Object, "TestProcedure");

            Assert.That(expected, Is.EqualTo(actualResult));
        }

        [Test]
        public void ExecuteNonQuery_TakesNoParameters_Executes()
        {
            var mockCommand = new Mock<IDbCommand>();
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var mockLogger = new Mock<ILogWrapper>();

            var helper = new SmallDb(mockLogger.Object);

            Assert.DoesNotThrow(() =>  helper.ExecuteNonQuery(mockConnection.Object, "TestProcedure"),
                "Unit Test threw an exception that was not expected!");
        }

        [Test]
        public void ExecuteQuery_TakesNoParameters_ReturnsValidDataTable()
        {
            var mockReader = new Mock<IDataReader>();

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());
            mockCommand.Setup(x => x.ExecuteReader()).Returns(mockReader.Object);

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var mockLogger = new Mock<ILogWrapper>();

            var helper = new SmallDb(mockLogger.Object);
            var result = helper.ExecuteQuery(mockConnection.Object, "TestProcedure");

            Assert.That(result, Is.Not.Null);
        }

        /// <summary>
        /// Helper function to pass into ExecuteQuery as a delegate
        /// </summary>
        private static FakeObject CreateFakeObject(IDataReader reader)
        {
            return new FakeObject();
        }

        [Test]
        public void ExecuteQueryWithFunc_TakesNoParameters_ReturnsValidObject()
        {
            var mockReader = new Mock<IDataReader>();

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());
            mockCommand.Setup(x => x.ExecuteReader()).Returns(mockReader.Object);

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var mockLogger = new Mock<ILogWrapper>();

            var helper = new SmallDb(mockLogger.Object);

            var result = helper.ExecuteQuery(mockConnection.Object, "TestProcedure", CreateFakeObject);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeObject>());
            Assert.That(FakeObject.Name, Is.EqualTo("Fake"));
        }

        [TestCase("select something from table", true)]
        [TestCase("drop table", false)]
        [TestCase("whatever this is", false)]
        public void IsInternalSql(string sql, bool expectedValue)
        {
            Assert.That(SmallDb.IsInternalSql(sql), Is.EqualTo(expectedValue));
        }
   }
}
