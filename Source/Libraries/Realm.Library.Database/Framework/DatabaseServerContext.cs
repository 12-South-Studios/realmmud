using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Logging;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Maintains a thread-safe queue of database server objects
    /// </summary>
    public sealed class DatabaseServerContext : Entity
    {
        private readonly ConcurrentQueue<DatabaseServer> _dbServers = new ConcurrentQueue<DatabaseServer>();

        // ReSharper disable PossibleMultipleEnumeration
        /// <summary>
        ///
        /// </summary>
        /// <param name="log"></param>
        /// <param name="connectionString"></param>
        /// <param name="numberServers"></param>
        /// <param name="procedureLoaders"></param>
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope",
                 Justification = "DatabaseServers are disposed in Context finalizer")]
        public DatabaseServerContext(ILogWrapper log, string connectionString, int numberServers,
            IEnumerable<IProcedureLoader> procedureLoaders)
            : base(1, "DatabaseServerContext")
        {
            Validation.IsNotNull(log, "log");
            Validation.IsNotNullOrEmpty(connectionString, "connectionString");
            Validation.Validate<ArgumentOutOfRangeException>(numberServers > 0);
            Validation.IsNotNull(procedureLoaders, "procedureLoaders");

            Validation.Validate(procedureLoaders.Any());

            Enumerable.Range(0, numberServers)
                      .ToList()
                      .ForEach(
                          i => _dbServers.Enqueue(new DatabaseServer(i + 1, connectionString, log, procedureLoaders)));

            log.DebugFormat("{0} database servers in the queue.", _dbServers.Count);
        }

        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// Gets the number of servers on the queue
        /// </summary>
        public int ServerCount { get { return _dbServers.Count; } }

        /// <summary>
        /// Gets the next server on the queue and then re-enqueues the chosen server.
        /// </summary>
        /// <returns></returns>
        public DatabaseServer NextServer
        {
            get
            {
                DatabaseServer server;

                _dbServers.TryDequeue(out server);

                if (server.IsNotNull())
                    _dbServers.Enqueue(server);

                return server;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                while (_dbServers.Count > 0)
                {
                    DatabaseServer server;
                    _dbServers.TryDequeue(out server);
                    server.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}