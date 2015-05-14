using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Realm.Library.Database
{
    /// <summary>
    /// Declares a contract for a database wrapper
    /// </summary>
    public interface IDatabaseWrapper
    {
        /// <summary>
        /// Gets the connection string
        /// </summary>
        ConnectionStringSettings ConnectionString { get; set; }

        /// <summary>
        /// Executes a database procedure with a dictionary of arguments
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        int Execute(string procedureName, IDictionary<string, object> args);

        /// <summary>
        /// Executes a database procedure with a dictionary of arguments and a datatable
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="dataTable"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        int Execute(string procedureName, ref DataTable dataTable, IDictionary<string, object> args);

        /// <summary>
        /// Registers a database procedure with the wrapper
        /// </summary>
        /// <param name="procedure"></param>
        void RegisterProcedure(IProcedure procedure);

        /// <summary>
        /// Gets if the wrapper has a procedure with the given name
        /// </summary>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        bool HasProcedure(string procedureName);
    }
}