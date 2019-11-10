using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FakeItEasy;
using FluentAssertions;
using Realm.Library.Common.Logging;
using Realm.Library.Database.Test.Fakes;
using Xunit;

namespace Realm.Library.Database.Test
{
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

        [Fact]
        public void ValidateArguments_TakesNullConnection_ThrowsException()
        {
            Action act = () => DatabaseHelper.ValidateArguments(null, "TestProcedure");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ValidateArguments_TakesEmptyStoredProcedureName_ThrowsException()
        {
            var connection = A.Fake<IDbConnection>();

            Action act = () => DatabaseHelper.ValidateArguments(connection, string.Empty);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ValidateArguments_TakesValidArguments_DoesNothing()
        {
            var connection = A.Fake<IDbConnection>();
            DatabaseHelper.ValidateArguments(connection, "TestProcedure").Should().BeTrue();
        }

        [Fact]
        public void SetupDbCommand_TakesParameters_PopulatesCommand()
        {
            var connection = A.Fake<IDbConnection>();
            var param1 = new SqlParameter("TestParam1", SqlDbType.Int);
            var param2 = new SqlParameter("TestParam2", SqlDbType.VarChar);
            var parameterList = new List<IDataParameter> { param1, param2 };
            var fakeCommand = new FakeDbCommand();

            DatabaseHelper.SetupDbCommand(connection, fakeCommand, "TestProcedure", parameterList);

            fakeCommand.Connection.Should().Be(connection);
            fakeCommand.CommandText.Should().Be("TestProcedure");
            fakeCommand.Parameters.Count.Should().Be(2);
        }

        [Fact]
        public void ExecuteScalar_TakesNoParameters_ReturnsValidResult()
        {
            const string expected = "This is a test result";

            var command = A.Fake<IDbCommand>();
            A.CallTo(() => command.ExecuteScalar()).Returns(expected);
            A.CallToSet(() => command.Connection).DoesNothing();

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(A.Fake<ILogWrapper>());

            var result = helper.ExecuteScalar(connection, "TestProcedure", null);
            result.Should().Be(expected);
        }

        [Fact]
        public void ExecuteScalar_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var logger = A.Fake<ILogWrapper>();
            A.CallTo(() => logger.Error(A<string>.Ignored, A<Exception>.Ignored))
                .Invokes(() => callback = true);

            var command = A.Fake<IDbCommand>();
            A.CallTo(() => command.ExecuteScalar()).Throws(MakeSqlException());
            A.CallToSet(() => command.Connection).DoesNothing();

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(logger);
            helper.ExecuteScalar(connection, "TestProcedure", null);

            callback.Should().BeTrue();
        }

        [Fact]
        public void ExecuteNonQuery_TakesNoParameters_Executes()
        {
            var command = A.Fake<IDbCommand>();
            A.CallToSet(() => command.Connection).DoesNothing();

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(A.Fake<ILogWrapper>());
            helper.ExecuteNonQuery(connection, "TestProcedure", null);
        }

        [Fact]
        public void ExecuteNonQuery_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var logger = A.Fake<ILogWrapper>();
            A.CallTo(() => logger.Error(A<string>.Ignored, A<Exception>.Ignored))
                .Invokes(() => callback = true);

            var command = A.Fake<IDbCommand>();
            A.CallTo(() => command.ExecuteNonQuery()).Throws(MakeSqlException());
            A.CallToSet(() => command.Connection).DoesNothing();

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(logger);
            helper.ExecuteNonQuery(connection, "TestProcedure", null);

            callback.Should().BeTrue();
        }

        [Fact]
        public void ExecuteQuery_TakesNoParameters_ReturnsValidDataTable()
        {
            var reader = A.Fake<IDataReader>();

            var command = A.Fake<IDbCommand>();
            A.CallToSet(() => command.Connection).DoesNothing();
            A.CallTo(() => command.ExecuteReader()).Returns(reader);

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(A.Fake<ILogWrapper>());

            var result = helper.ExecuteQuery(connection, "TestProcedure", null);
            result.Should().NotBeNull();
        }

        [Fact]
        public void ExecuteQuery_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var logger = A.Fake<ILogWrapper>();
            A.CallTo(() => logger.Error(A<string>.Ignored, A<Exception>.Ignored))
                .Invokes(() => callback = true);

            var command = A.Fake<IDbCommand>();
            A.CallToSet(() => command.Connection).DoesNothing();
            A.CallTo(() => command.ExecuteReader()).Throws(MakeSqlException());

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(logger);
            helper.ExecuteQuery(connection, "TestProcedure", null);

            callback.Should().BeTrue();
        }

        [Fact]
        public void ExecuteQueryWithFunc_TakesNoParameters_ReturnsValidObject()
        {
            var reader = A.Fake<IDataReader>();

            var command = A.Fake<IDbCommand>();
            A.CallToSet(() => command.Connection).DoesNothing();
            A.CallTo(() => command.ExecuteReader()).Throws(MakeSqlException());

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(A.Fake<ILogWrapper>());

            var result = helper.ExecuteQuery(connection, "TestProcedure", null, CreateFakeObject);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<FakeObject>();
        }

        [Fact]
        public void ExecuteQueryWithFunc_TakesNoParameters_ThrowsException()
        {
            bool callback = false;

            var logger = A.Fake<ILogWrapper>();
            A.CallTo(() => logger.Error(A<string>.Ignored, A<Exception>.Ignored))
                .Invokes(() => callback = true);

            var command = A.Fake<IDbCommand>();
            A.CallToSet(() => command.Connection).DoesNothing();
            A.CallTo(() => command.ExecuteReader()).Throws(MakeSqlException());

            var connection = A.Fake<IDbConnection>();
            A.CallTo(() => connection.CreateCommand()).Returns(command);

            A.CallTo(() => command.Connection).Returns(connection);

            var helper = new DatabaseHelper(logger);
            helper.ExecuteQuery(connection, "TestProcedure", null, CreateFakeObject);

            callback.Should().BeTrue();
        }
    } 
}
