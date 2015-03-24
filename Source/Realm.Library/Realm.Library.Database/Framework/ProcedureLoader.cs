using System;
using System.Data;
using Realm.Library.Common.Logging;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Builds a repository of stored procedures indexed by procedure name
    /// </summary>
    public abstract class ProcedureLoader<T> : IProcedureLoader where T : IDbConnection
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="log"></param>
        protected ProcedureLoader(string connectionString, LogWrapper log)
        {
            Connection = (T)Activator.CreateInstance(typeof(T), new object[] { connectionString });
            Log = log;
        }

        /// <summary>
        ///
        /// </summary>
        protected IDbConnection Connection { get; private set; }

        /// <summary>
        ///
        /// </summary>
        protected LogWrapper Log { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract IProcedureRepository ProcedureRepository { get; }
    }
}