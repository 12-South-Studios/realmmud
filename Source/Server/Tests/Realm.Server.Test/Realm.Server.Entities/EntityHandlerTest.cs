using System.Collections.Generic;
using FluentAssertions;
using Realm.Library.Common.Entities;
using Realm.Server.Test.Helpers;
using Xunit;

namespace Realm.Server.Test.Realm.Server.Entities
{
    public class EntityContextTest
    {
        internal class FakeEntityContext : EntityContext<FakeEntity>
        {
            public FakeEntityContext(FakeEntity parent)
                : base(parent)
            {
            }
        }

        [Fact]
        public void EntityContext_Constructor_Test()
        {
            var handler = new FakeEntityContext(new FakeEntity());
            handler.Should().NotBeNull();
        }

        [Fact]
        public void EntityContext_AddEntity_Success_Test()
        {
            var handler = new FakeEntityContext(new FakeEntity());

            const bool expected = true;
            var actual = handler.AddEntity(new FakeEntity());

            actual.Should().Be(expected);
        }

        [Fact]
        public void EntityContext_AddEntity_AlreadyExists_Test()
        {
            var entity = new FakeEntity();
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntity(entity);

            const bool expected = true;
            var actual = handler.Contains(entity);
            actual.Should().Be(expected);
        }

        [Fact]
        public void EntityContext_AddEntities_Test()
        {
            var entityList = new List<FakeEntity> { new FakeEntity(), new FakeEntity() };
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntities(entityList);

            const int expected = 2;
            var actual = handler.Count;
            actual.Should().Be(expected);
        }

        [Fact]
        public void EntityContext_ContainsId_Success_Test()
        {
            const long id = 1;

            var entity = new FakeEntity { ID = id };
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntity(entity);

            const bool expected = true;
            var actual = handler.Contains(id);
            actual.Should().Be(expected);
        }

        [Fact]
        public void EntityContext_GetEntities_Test()
        {
            var entityList = new List<FakeEntity> { new FakeEntity(), new FakeEntity() };
            var handler = new FakeEntityContext(new FakeEntity());
            handler.AddEntities(entityList);

            const int expected = 2;
            var actual = handler.Entities;
            actual.Count.Should().Be(expected);
        }
    }
}
