using FluentAssertions;
using Realm.Data;
using Xunit;

namespace Realm.Command.Test
{
    public class TargetLocationTests
    {
        [Fact]
        public void Populate_Returns_Valid_Object()
        {
            var entity1 = new Fakes.FakeGameEntity {ID = 1, Name = "Fake1"};
            var entity2 = new Fakes.FakeGameEntity {ID = 2, Name = "Fake2"};

            var result = new TargetResult();

            var actual = result.Populate(entity1, entity2, Globals.EntityLocationTypes.Space);

            actual.FoundEntity.Should().Be(entity1);
            actual.FoundEntityLocation.Should().Be(entity2);
            actual.FoundEntityLocationType.Should().Be(Globals.EntityLocationTypes.Space);
        }

        [Theory]
        [InlineData("#5", 5)]
        [InlineData("#-1", 1)]
        [InlineData("#0", 1)]
        [InlineData("abc", 0)]
        public void ParseQuantity_Returns_Valid_Number(string firstParam, int expectedValue)
        {
            var result = new TargetResult {FirstParameter = firstParam};

            var quantity = TargetLocation.ParseQuantity(result).Quantity;
            quantity.Should().Be(expectedValue);
        }
    }
}
