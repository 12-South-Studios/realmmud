using System;
using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public interface IEntityManager
    {
        /// <summary>
        ///
        /// </summary>
        DictionaryAtom InitializationAtom { get; }

        #region Entity Factory

        object Create(IHelper<Type> helper, string type, params object[] args);

        object Create(Type type, params object[] args);

        T Create<T>(params object[] args) where T : IEntity;

        T Clone<T>(T source, params object[] args) where T : IEntity;

        bool Register(Type type);

        #endregion Entity Factory

        #region Entity Recycler

        bool RecycleEntity(IGameEntity entity);

        bool SaveRecycledEntity(IGameEntity entity, IGameEntity location);

        #endregion Entity Recycler

        #region Entity Repository

        bool AddEntity(long key, IGameEntity entity);

        bool DeleteEntity(long key);

        bool ContainsEntity(long key);

        IGameEntity GetEntity(long key);

        void ClearEntities();

        int EntityCount { get; }

        IEnumerable<long> GetEntityKeys();

        IEnumerable<IGameEntity> GetEntities();

        #endregion Entity Repository
    }
}