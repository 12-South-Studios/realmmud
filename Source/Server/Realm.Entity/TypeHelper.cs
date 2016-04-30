using System;
using Realm.Library.Common.Entities;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public abstract class TypeHelper : IHelper<Type>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract Type Get(string type);
    }
}