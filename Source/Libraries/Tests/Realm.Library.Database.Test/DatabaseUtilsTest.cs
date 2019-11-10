using FluentAssertions;
using System.Data;
using Xunit;

namespace Realm.Library.Database.Test
{
    public class DatabaseUtilsTest
    {
        [Fact]
        public void CreateParameter_OneArgument_Test()
        {
            var testObject = new object();
            var param = DatabaseUtils.CreateParameter<TestDbParameter>(testObject);

            param.Should().NotBeNull();
            param.Value.Should().Be(testObject);
        }

        [Fact]
        public void CreateParamter_TwoArguments_Test()
        {
            var testObject = new object();
            var param = DatabaseUtils.CreateParameter<TestDbParameter>("TestObject", testObject);

            param.Should().NotBeNull();
            param.Value.Should().Be(testObject);
            param.ParameterName.Should().Be("TestObject");
        }

        [Fact]
        public void CreateParamter_ThreeArguments_Test()
        {
            var testObject = new object();
            var param = DatabaseUtils.CreateParameter<TestDbParameter>("TestObject", testObject, DbType.Object);

            param.Should().NotBeNull();
            param.Value.Should().Be(testObject);
            param.ParameterName.Should().Be("TestObject");
            param.DbType.Should().Be(DbType.Object);
        }

        [Fact]
        public void CreateParameterList_ArrayObjects_Test()
        {
            var objectArray = new object[5];
            objectArray[0] = new object();
            objectArray[1] = new object();
            objectArray[2] = new object();
            objectArray[3] = new object();
            objectArray[4] = new object();

            var paramList = DatabaseUtils.CreateParameterList<TestDbParameter>(objectArray);
            paramList.Count.Should().Be(5);
        }

        [Fact]
        public void CreateParameterList_ArrayParameters_Test()
        {
            var paramArray = new TestDbParameter[5];
            paramArray[0] = new TestDbParameter();
            paramArray[1] = new TestDbParameter();
            paramArray[2] = new TestDbParameter();
            paramArray[3] = new TestDbParameter();
            paramArray[4] = new TestDbParameter();

            var paramList = DatabaseUtils.CreateParameterList(paramArray);
            paramList.Count.Should().Be(5);
        }

        [Fact]
        public void CreateParameterList_IsNotNulls_Test()
        {
            var paramList = DatabaseUtils.CreateParameterList<TestDbParameter>(null);
            paramList.Count.Should().Be(0);
        }

        [Fact]
        public void GetValueOrDefault_Valid_Test()
        {
            const int value = 25;
            const int defaultValue = 1;

            var dataTable = new DataTable();
            dataTable.Columns.Add("IntTest", typeof (int));
            dataTable.Rows.Add(value);

            var result = DatabaseUtils.GetValueOrDefault(dataTable.Rows[0], "IntTest", defaultValue);
            result.Should().Be(value);
        }

        [Fact]
        public void GetValueOrDefault_Invalid_Test()
        {
            const int value = 25;
            const int defaultValue = 1;

            var dataTable = new DataTable();
            dataTable.Columns.Add("IntTest", typeof(int));
            dataTable.Rows.Add(value);

            var result = DatabaseUtils.GetValueOrDefault(dataTable.Rows[0], "IntegerTest", defaultValue);
            result.Should().Be(defaultValue);
        }
    }
}
