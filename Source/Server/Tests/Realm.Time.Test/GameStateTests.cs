using Moq;
using NUnit.Framework;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common.Data;

namespace Realm.Time.Test
{
    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void MonthPropertyReturnsValidMonthDef()
        {
            var monthDef = new MonthDef(1, "Test", new DictionaryAtom());

            var mockStaticDataManager = new Mock<IStaticDataManager>();
            mockStaticDataManager.Setup(x => x.GetStaticData(It.IsAny<Globals.Globals.SystemTypes>(), 
                It.IsAny<string>())).Returns(monthDef);

            var mudTime = new MudTime {Month = 1};
            var gameState = new GameState(mudTime)
            {
                StaticDataManager = mockStaticDataManager.Object
            };

            Assert.That(gameState.Month, Is.EqualTo(monthDef));
        }
    }
}
