using System;
using System.Collections.Generic;
using Realm.Library.Common.Events;

namespace Realm.Entity.Interfaces
{
    /// <summary>
    /// The entity initializer interface defines a contract for an object
    /// that instantiates and loads a provided list of objects
    /// </summary>
    public interface IEntityInitializer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="startupSet"></param>
        /// <param name="zoneList"></param>
        void LoadStartupEntities(BooleanSet startupSet, IEnumerable<int> zoneList);

        /// <summary>
        ///
        /// </summary>
        /// <param name="typesToInitialize"></param>
        void RegisterEntityTypes(IEnumerable<Type> typesToInitialize);
    }
}