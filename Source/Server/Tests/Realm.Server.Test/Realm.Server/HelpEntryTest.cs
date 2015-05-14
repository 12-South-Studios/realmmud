using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realm.Help;

namespace Realm.Server.Test.Realm.Server
{
    [TestClass]
    public class HelpEntryTest
    {
        [TestMethod]
        public void HelpEntry_Constructor1_Test()
        {
            var entry = new HelpEntry(1, "test");

            Assert.IsNotNull(entry);
            Assert.AreEqual(1, entry.ID);
            Assert.AreEqual("test", entry.Name);
        }

        [TestMethod]
        public void HelpEntry_Constructor2_Test()
        {
            var entry = new HelpEntry(1, "test", "testing", "data", "category");

            Assert.IsNotNull(entry);
            Assert.AreEqual(1, entry.ID);
            Assert.AreEqual("test", entry.Name);
            Assert.AreEqual("testing", entry.Keyword);
            Assert.AreEqual("data", entry.Data);
            Assert.AreEqual("category", entry.Category);
        }
    }
}
