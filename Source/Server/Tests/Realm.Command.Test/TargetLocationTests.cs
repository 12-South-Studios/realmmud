using NUnit.Framework;
using Realm.Data;

namespace Realm.Command.Test
{
    [TestFixture]
    public class TargetLocationTests
    {
        [Test]
        public void Populate_Returns_Valid_Object()
        {
            var entity1 = new Fakes.FakeGameEntity {ID = 1, Name = "Fake1"};
            var entity2 = new Fakes.FakeGameEntity {ID = 2, Name = "Fake2"};

            var result = new TargetResult();

            var actual = result.Populate(entity1, entity2, Globals.EntityLocationTypes.Space);

            Assert.That(actual.FoundEntity, Is.EqualTo(entity1));
            Assert.That(actual.FoundEntityLocation, Is.EqualTo(entity2));
            Assert.That(actual.FoundEntityLocationType, Is.EqualTo(Globals.EntityLocationTypes.Space));
        }

        [TestCase("#5", 5)]
        [TestCase("#-1", 1)]
        [TestCase("#0", 1)]
        [TestCase("abc", 0)]
        public void ParseQuantity_Returns_Valid_Number(string firstParam, int expectedValue)
        {
            var result = new TargetResult {FirstParameter = firstParam};

            Assert.That(TargetLocation.ParseQuantity(result).Quantity, Is.EqualTo(expectedValue));
        }
    }
}
