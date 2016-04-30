using System.Collections.Generic;
using Realm.Entity.Interfaces;

namespace Realm.Entity.Contexts
{
    public interface IContentsContext
    {
        bool Contains(IGameEntity aEntity);

        bool Contains(long aId);

        bool Contains(string aName);

        bool AddEntity(IGameEntity aEntity);

        void AddEntities(IEnumerable<IGameEntity> entityList);

        bool RemoveEntity(IGameEntity aEntity);

        IList<IGameEntity> Entities { get; }

        //IList<IGameEntity> GetEntities(IGameTemplate aTemplate);

        IGameEntity GetEntity(long aId);

        IGameEntity GetEntity(string aName);

        //IGameEntity GetEntity(IGameTemplate aTemplate);

        int Count { get; }
    }
}