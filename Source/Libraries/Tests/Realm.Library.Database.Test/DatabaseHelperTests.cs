using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Moq;
using NUnit.Framework;
using Realm.Library.Database.Test.Fakes;

namespace Realm.Library.Database.Test
{
    [TestFixture]
    public class DatabaseHelperTests
    {
        private class FakeObject
        {
            public static string Name => "Fake";
        }

        private static SqlException MakeSqlException()
        {
            SqlException exception = null;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=.;Database=GUARANTEED_TO_FAIL;Connection Timeout=1");
                conn.Open();
            }
            catch (SqlException ex)
            {
                exception = ex;
            }
            return exception;
        }

        private static FakeObject CreateFakeObject(IDataReader reader)
        {
            return new FakeObject();
        }

        [Test]
        public void ValidateArguments_TakesNullConnection_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => DatabaseHelper.ValidateArguments(null, "TestProcedure"),
                                                 "Unit test expected an ArgumentNullException to be thrown!");
        }

        [Test]
        public void ValidateArguments_TakesEmptyStoredProcedureName_ThrowsException()
        {
            var mockConnection = new Mock<IDbConnection>();

            Assert.Throws<ArgumentNullException>(
                () => DatabaseHelper.ValidateArguments(mockConnection.Object, string.Empty),
                "Unit test expected an ArgumentNullException to be thrown!");
        }

        [Test]
        public void ValidateArguments_TakesValidArguments_DoesNothing()
        {
            var mockConnection = new Mock<IDbConnection>();
            Assert.That(DatabaseHelper.ValidateArguments(mockConnection.Object, "TestProcedure"), Is.True);
        }

        [Test]
        public void SetupDbCommand_TakesParameters_PopulatesCommand()
        {
            var mockConnection = new Mock<IDbConnection>();
            var param1 = new SqlParameter("TestParam1", SqlDbType.Int);
            var param2 = new SqlParameter("TestParam2", SqlDbType.VarChar);
            var parameterList = new List<IDataParameter> { param1, param2 };
            var fakeCommand = new FakeDbCommand();

            DatabaseHelper.SetupDbCommand(mockConnection.Object, fakeCommand, "TestProcedure", parameterList);

            Assert.That(fakeCommand.Connection, Is.EqualTo(mockConnection.Object));
            Assert.That(fakeCommand.CommandText, Is.EqualTo("TestProcedure"));
            Assert.That(fakeCommand.Parameters.Count, Is.EqualTo(2));
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

            var helper = new DatabaseHelper(new Mock<Common.Logging.ILogWrapper>().Object);

            Assert.That(helper.ExecuteScalar(mockConnection.Object, "TestProcedure", null), Is.EqualTo(expected));
        }

        [Test]
        public void ExecuteScalar_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var mockLogger = new Mock<Common.Logging.ILogWrapper>();
            mockLogger.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>())).Callback(() => callback = true);

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.Setup(x => x.ExecuteScalar()).Throws(MakeSqlException());
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var helper = new DatabaseHelper(mockLogger.Object);
            helper.ExecuteScalar(mockConnection.Object, "TestProcedure", null);

            Assert.That(callback, Is.True);
        }

        [Test]
        public void ExecuteNonQuery_TakesNoParameters_Executes()
        {
            var mockCommand = new Mock<IDbCommand>();
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var helper = new DatabaseHelper(new Mock<Common.Logging.ILogWrapper>().Object);
            helper.ExecuteNonQuery(mockConnection.Object, "TestProcedure", null);
        }

        [Test]
        public void ExecuteNonQuery_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var mockLogger = new Mock<Common.Logging.ILogWrapper>();
            mockLogger.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>())).Callback(() => callback = true);

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.Setup(x => x.ExecuteNonQuery()).Throws(MakeSqlException());
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var helper = new DatabaseHelper(mockLogger.Object);
            helper.ExecuteNonQuery(mockConnection.Object, "TestProcedure", null);

            Assert.That(callback, Is.True);
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

            var helper = new DatabaseHelper(new Mock<Common.Logging.ILogWrapper>().Object);

            Assert.That(helper.ExecuteQuery(mockConnection.Object, "TestProcedure", null), Is.Not.Null);
        }

        [Test]
        public void ExecuteQuery_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var mockLogger = new Mock<Common.Logging.ILogWrapper>();
            mockLogger.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>())).Callback(() => callback = true);

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());
            mockCommand.Setup(x => x.ExecuteReader()).Throws(MakeSqlException());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var helper = new DatabaseHelper(mockLogger.Object);
            helper.ExecuteQuery(mockConnection.Object, "TestProcedure", null);

            Assert.That(callback, Is.True);
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

            var helper = new DatabaseHelper(new Mock<Common.Logging.ILogWrapper>().Object);

            var result = helper.ExecuteQuery(mockConnection.Object, "TestProcedure", null, CreateFakeObject);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeObject>());
        }

        [Test]
        public void ExecuteQueryWithFunc_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var mockLogger = new Mock<Common.Logging.ILogWrapper>();
            mockLogger.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>())).Callback(() => callback = true);

            var mockCommand = new Mock<IDbCommand>();
            mockCommand.SetupSet(x => x.Connection = It.IsAny<IDbConnection>());
            mockCommand.Setup(x => x.ExecuteReader()).Throws(MakeSqlException());

            var mockConnection = new Mock<IDbConnection>();
            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

            mockCommand.SetupGet(x => x.Connection).Returns(mockConnection.Object);

            var helper = new DatabaseHelper(mockLogger.Object);
            helper.ExecuteQuery(mockConnection.Object, "TestProcedure", null, CreateFakeObject);

            Assert.That(callback, Is.True);
        }
    } 
}
