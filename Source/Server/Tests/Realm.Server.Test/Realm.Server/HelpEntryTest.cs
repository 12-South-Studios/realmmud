using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realm.Help;
using Xunit;

namespace Realm.Server.Test.Realm.Server
{
    public class HelpEntryTest
    {
        [Fact]
        public void HelpEntry_Constructor1_Test()
        {
            var entry = new HelpEntry(1, "test");

            entry.Should().NotBeNull();
            entry.ID.Should().Be(1);
            entry.Name.Should().Be("test");
        }

        [Fact]
        public void HelpEntry_Constructor2_Test()
        {
            var entry = new HelpEntry(1, "test", "testing", "data", "category");

            entry.Should().NotBeNull();
            entry.ID.Should().Be(1);
            entry.Name.Should().Be("test");
            entry.Keyword.Should().Be("testing");
            entry.Data.Should().Be("data");
            entry.Category.Should().Be("category");
        }
    }
}
