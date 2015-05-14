//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Test.Helpers;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Realm.Server.Zones
//{
//    [TestClass]
//    public class PortalHandlerTest
//    {
//        [TestMethod]
//        public void ExitHandler_Constructor_Test()
//        {
//            var handler = new PortalHandler();
//            Assert.IsNotNull(handler);
//            Assert.IsNotNull(handler.Portals);
//        }

//        [TestMethod]
//        public void ExitHandler_AddExit_HappyPath_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            const bool expected = true;
//            var actual = handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void ExitHandler_AddExit_AlreadyExists_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            const bool expected = false;
//            var actual = handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void ExitHandler_NumberOfExits_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            const int expected = 1;
//            var actual = handler.Count;
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void ExitHandler_GetExitString_NoMatchingKeyword_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            var actual = handler.GetPortal("nogood");
//            Assert.IsNull(actual);
//        }

//        [TestMethod]
//        public void ExitHandler_GetExitString_MatchingKeyword_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            var actual = handler.GetPortal("testing");
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(direction, actual.Direction);
//            Assert.AreEqual(Space, actual.Destination);
//        }

//        [TestMethod]
//        public void ExitHandler_GetExitSpace_NoMatchingSpace_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");
//            var fakeSpace = new Space(2, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            var actual = handler.GetPortal(fakeSpace);
//            Assert.IsNull(actual);
//        }

//        [TestMethod]
//        public void ExitHandler_GetExitSpace_MatchingSpace_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            var actual = handler.GetPortal(Space);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(Space, actual.Destination);
//        }

//        [TestMethod]
//        public void ExitHandler_GetExitSpace_MatchingDirection_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            var actual = handler.GetPortal(direction);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(Space, actual.Destination);
//        }

//        [TestMethod]
//        public void ExitHandler_GetExitSpace_NoMatchingDirection_Test()
//        {
//            var handler = new PortalHandler();

//            var Space = new Space(1, "test");

//            const Globals.Globals.Directions direction = Globals.Globals.Directions.North;
//            const string keywords = "testing";

//            handler.AddExit(TestHelper.MockLogger.Object, direction, Space, keywords);

//            var actual = handler.GetPortal(Globals.Globals.Directions.East);
//            Assert.IsNull(actual);
//        }
//    }
//}
