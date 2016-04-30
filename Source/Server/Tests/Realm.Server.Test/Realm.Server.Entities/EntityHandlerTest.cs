using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realm.Library.Common.Entities;
using Realm.Server.Test.Helpers;

namespace Realm.Server.Test.Realm.Server.Entities
{
    [TestClass]
    public class EntityContextTest
    {
        internal class FakeEntityContext : EntityContext<FakeEntity>
        {
            public FakeEntityContext(FakeEntity parent)
                : base(parent)
            {
            }
        }

        [TestMethod]
        public void EntityContext_Constructor_Test()
        {
            var handler = new FakeEntityContext(new FakeEntity());
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void EntityContext_AddEntity_Success_Test()
        {
            var handler = new FakeEntityContext(new FakeEntity());

            const bool expected = true;
            var actual = handler.AddEntity(new FakeEntity());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityContext_AddEntity_AlreadyExists_Test()
        {
            var entity = new FakeEntity();
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntity(entity);

            const bool expected = true;
            var actual = handler.Contains(entity);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityContext_AddEntities_Test()
        {
            var entityList = new List<FakeEntity> { new FakeEntity(), new FakeEntity() };
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntities(entityList);

            const int expected = 2;
            var actual = handler.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityContext_ContainsId_Success_Test()
        {
            const long id = 1;

            var entity = new FakeEntity { ID = id };
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntity(entity);

            const bool expected = true;
            var actual = handler.Contains(id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityContext_GetEntities_Test()
        {
            var entityList = new List<FakeEntity> { new FakeEntity(), new FakeEntity() };
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntities(entityList);

            const int expected = 2;
            var actual = handler.Entities;
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
