using System;
using NUnit.Framework;
using Realm.Library.Common.Events;

namespace Realm.Library.Common.Test.Events
{
    [TestFixture]
    public class RealmEventArgsTest
    {
        [Test]
        public void RealmEventArgsConstructorTest()
        {
            var result = new RealmEventArgs();

            Assert.That(result.Data, Is.Not.Null);
            Assert.IsTrue(typeof(EventTable) == result.Data.GetType());
        }

        [Test]
        public void Constructor_ReturnsValidData_WhenEventTableIsPassed()
        {
            var result = new RealmEventArgs(new EventTable());
            Assert.That(result.Data, Is.Not.Null);
        }

        [Test]
        public void Constructor_ThrowsException_WhenCreateEventTableIsFalse()
        {
            Assert.Throws<ArgumentNullException>(() => new RealmEventArgs((EventTable)null));
        }

        [Test]
        public void Constructor_TypeIsAssignedProperly_WHenValidParameterIsPassed()
        {
            var result = new RealmEventArgs("test");
            Assert.That(result.Type, Is.EqualTo("test"));
        }

        [Test]
        public void Constructor_ThrowsException_WhenArgTypeIsNotProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new RealmEventArgs(string.Empty));
        }

        [Test]
        public void GetValueEmptyKeyTest()
        {
            var args = new RealmEventArgs();

            Assert.Throws<ArgumentNullException>(() => args.GetValue(string.Empty),
                                                 "Unit test expected an ArgumentNullException to be thrown");
        }

        [Test]
        public void GetValueNullTableTest()
        {
            var args = new RealmEventArgs("test");

            Assert.That(args.GetValue("key"), Is.Null);
        }

        [Test]
        public void GetValueNoKeyTest()
        {
            var table = new EventTable { { "key", 25 } };

            var args = new RealmEventArgs(table);

            Assert.That(args.GetValue("key2"), Is.Null);
        }

        [Test]
        public void GetValueSuccessTest()
        {
            const int value = 25;
            var table = new EventTable { { "key", value } };

            var args = new RealmEventArgs(table);

            Assert.That(args.GetValue("key"), Is.EqualTo(value));
        }

        [Test]
        public void HasValueNullTableTest()
        {
            var args = new RealmEventArgs("test");

            Assert.That(args.HasValue("key"), Is.False);
        }

        [Test]
        public void HasValueSuccessTest()
        {
            const int value = 25;
            var table = new EventTable { { "key", value } };

            var args = new RealmEventArgs(table);

            Assert.That(args.HasValue("key"), Is.True);
        }
    }
}
