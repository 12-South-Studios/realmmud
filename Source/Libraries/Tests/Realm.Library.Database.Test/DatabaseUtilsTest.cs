using System.Data;
using NUnit.Framework;

namespace Realm.Library.Database.Test
{
    [TestFixture]
    public class DatabaseUtilsTest
    {
        [Test]
        public void CreateParameter_OneArgument_Test()
        {
            var testObject = new object();
            var param = DatabaseUtils.CreateParameter<TestDbParameter>(testObject);

            Assert.That(param, Is.Not.Null);
            Assert.That(param.Value, Is.EqualTo(testObject));
        }

        [Test]
        public void CreateParamter_TwoArguments_Test()
        {
            var testObject = new object();
            var param = DatabaseUtils.CreateParameter<TestDbParameter>("TestObject", testObject);

            Assert.That(param, Is.Not.Null);
            Assert.That(param.Value, Is.EqualTo(testObject));
            Assert.That(param.ParameterName, Is.EqualTo("TestObject"));
        }

        [Test]
        public void CreateParamter_ThreeArguments_Test()
        {
            var testObject = new object();
            var param = DatabaseUtils.CreateParameter<TestDbParameter>("TestObject", testObject, DbType.Object);

            Assert.That(param, Is.Not.Null);
            Assert.That(param.Value, Is.EqualTo(testObject));
            Assert.That(param.ParameterName, Is.EqualTo("TestObject"));
            Assert.That(param.DbType, Is.EqualTo(DbType.Object));
        }

        [Test]
        public void CreateParameterList_ArrayObjects_Test()
        {
            var objectArray = new object[5];
            objectArray[0] = new object();
            objectArray[1] = new object();
            objectArray[2] = new object();
            objectArray[3] = new object();
            objectArray[4] = new object();
            var paramList = DatabaseUtils.CreateParameterList<TestDbParameter>(objectArray);

            Assert.That(paramList.Count, Is.EqualTo(5));
        }

        [Test]
        public void CreateParameterList_ArrayParameters_Test()
        {
            var paramArray = new TestDbParameter[5];
            paramArray[0] = new TestDbParameter();
            paramArray[1] = new TestDbParameter();
            paramArray[2] = new TestDbParameter();
            paramArray[3] = new TestDbParameter();
            paramArray[4] = new TestDbParameter();
            var paramList = DatabaseUtils.CreateParameterList(paramArray);

            Assert.That(paramList.Count, Is.EqualTo(5));
        }

        [Test]
        public void CreateParameterList_IsNotNulls_Test()
        {
            var paramList = DatabaseUtils.CreateParameterList<TestDbParameter>(null);

            Assert.That(paramList.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetValueOrDefault_Valid_Test()
        {
            const int value = 25;
            const int defaultValue = 1;

            var dataTable = new DataTable();
            dataTable.Columns.Add("IntTest", typeof (int));
            dataTable.Rows.Add(value);

            Assert.That(DatabaseUtils.GetValueOrDefault(dataTable.Rows[0], "IntTest", defaultValue), Is.EqualTo(value));
        }

        [Test]
        public void GetValueOrDefault_Invalid_Test()
        {
            const int value = 25;
            const int defaultValue = 1;

            var dataTable = new DataTable();
            dataTable.Columns.Add("IntTest", typeof(int));
            dataTable.Rows.Add(value);

            Assert.That(DatabaseUtils.GetValueOrDefault(dataTable.Rows[0], "IntegerTest", defaultValue), Is.EqualTo(defaultValue));
        }
    }
}
