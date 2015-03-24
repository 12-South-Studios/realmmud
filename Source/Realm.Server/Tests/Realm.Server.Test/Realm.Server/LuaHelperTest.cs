using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Realm.Server.Test.Realm.Server
{
    [TestClass]
    public class LuaHelperTest
    {
        [TestMethod]
        public void LuaHelper_LuaMxpTag_Test()
        {
            const string value = "test";
            const string expected = "\x03test\x04";

            //var actual = LuaHelper.LuaMxpTag(value);
            //Assert.AreEqual(expected, actual);
        }

        // PadString
        // ParseWord
        // RemoveWord
        // ToLower
        // Toupper
        // EnumToString
    }
}
