//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Contexts;
//using Realm.Server.Entities;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Handlers
//{
//    [TestClass]
//    public class ContentsHandlerTest
//    {
//        [TestMethod]
//        public void ContentsHandler_Constructor_Test()
//        {
//            var fakeEntity = new FakeGameEntity();
//            var handler = new ContentsHandler(fakeEntity);
//            Assert.IsNotNull(handler);
//            Assert.AreEqual(fakeEntity, handler.Owner);
//        }

//        [TestMethod]
//        public void ContentsHandler_GetEntityByName_NotFound_Test()
//        {
//            var fakeEntity = new FakeGameEntity();
//            var handler = new ContentsHandler(fakeEntity);

//            var actual = handler.GetEntity("Test");
//            Assert.IsNull(actual);
//        }

//        [TestMethod]
//        public void ContentsHandler_GetEntityByName_Found_Test()
//        {
//            const int id = 1;
//            const string name = "Test";

//            var fakeEntity = new FakeGameEntity { ID = id, Name = name };
//            var handler = new ContentsHandler(fakeEntity);
//            handler.AddEntity(fakeEntity);

//            var actual = handler.GetEntity(name);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(id, actual.ID);
//            Assert.AreEqual(name, actual.Name);
//        }

//        [TestMethod]
//        public void ContentsHandler_Contains_Found_Test()
//        {
//            const int id = 1;
//            const string name = "Test";

//            var fakeEntity = new FakeGameEntity { ID = id, Name = name };
//            var handler = new ContentsHandler(fakeEntity);
//            handler.AddEntity(fakeEntity);

//            const bool expected = true;
//            var actual = handler.Contains(name);
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void ContentsHandler_GetEntityByTemplate_Test()
//        {
//            const int id = 1;
//            const string name = "Test";
//            var fakeTemplate = new FakeGameTemplate { ID = id, Name = name };

//            var fakeInstance = new FakeGameInstance { Parent = fakeTemplate, ID = id };

//            var handler = new ContentsHandler(fakeInstance);
//            handler.AddEntity(fakeInstance);

//            var actual = handler.GetEntity(fakeTemplate);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(id, actual.ID);
//            Assert.IsInstanceOfType(actual, typeof(FakeGameInstance));

//            var instance = actual as FakeGameInstance;
//            if (instance == null)
//                throw new Exception("Failed to convert to FakeGameInstance");
//            Assert.AreEqual(fakeTemplate, instance.Parent);
//        }

//        [TestMethod]
//        public void ContentsHandler_GetEntities_Test()
//        {
//            const int id = 1;
//            const string name = "Test";
//            var fakeTemplate = new FakeGameTemplate { ID = id, Name = name };

//            var fakeInstance = new FakeGameInstance { Parent = fakeTemplate, ID = id };

//            var handler = new ContentsHandler(fakeInstance);
//            handler.AddEntity(fakeInstance);

//            var actual = handler.GetEntities(fakeTemplate);
//            var entityList = new List<IGameEntity>(actual);

//            const int expected = 1;
//            Assert.AreEqual(expected, entityList.Count);
//        }
//    }
//}
