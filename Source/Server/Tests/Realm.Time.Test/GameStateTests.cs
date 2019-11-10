using FakeItEasy;
using FluentAssertions;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common.Data;
using Xunit;

namespace Realm.Time.Test
{
    public class GameStateTests
    {
        [Fact]
        public void MonthPropertyReturnsValidMonthDef()
        {
            var monthDef = new MonthDef(1, "Test", new DictionaryAtom());

            var dataManager = A.Fake<IStaticDataManager>();
            A.CallTo(() => dataManager.GetStaticData(A<Globals.SystemTypes>.Ignored, A<string>.Ignored)).Returns(monthDef);

            var mudTime = new MudTime {Month = 1};
            var gameState = new GameState(mudTime)
            {
                StaticDataManager = dataManager
            };

            gameState.Month.Should().Be(monthDef);
        }
    }
}
