using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Realm.Library.Common.Logging;

namespace Realm.Library.SmallDb
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SmallDb : ISmallDb
    {
        private static readonly List<string> SqlCommands = new List<string>
            {
                "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "MERGE", "ALTER", "CREATE"
            };
        private static readonly List<string> DisallowedCommands = new List<string>
            {
                "DROP", "ALTER", "CREATE"
            };

        private readonly ILogWrapper _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logWrapper"></param>
        public SmallDb(ILogWrapper logWrapper)
        {
            _log = logWrapper;
        }

 
        /// <summary>
        /// Executes a scalar query and returns the result
        /// </summary>
        public object ExecuteScalar(IDbConnection dbConnection,
                                    string storedProcedureName,
                                    IEnumerable<IDataParameter> parameters = null,
                                    string errorMessage = "",
                                    bool throwException = true)
        {
            ValidateArguments(dbConnection, storedProcedureName);

            object result = null;
            try
            {
                using (var dbCommand = dbConnection.CreateCommand())
                {
                    SetupDbCommand(dbConnection, dbCommand, storedProcedureName, parameters);
                    dbCommand.Connection.Open();
                    result = dbCommand.ExecuteScalar();

                    dbCommand.Connection.CleanupConnection();
                }
            }
            catch (DbException ex)
            {
                dbConnection.CleanupConnection();
                _log.Error(string.IsNullOrEmpty(errorMessage)
                               ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);

                if (throwException)
                    throw;
            }

            return result;
        }

        /// <summary>
        /// Executes a non-query
        /// </summary>
        public void ExecuteNonQuery(IDbConnection dbConnection,
                                    string storedProcedureName,
                                    IEnumerable<IDataParameter> parameters = null,
                                    string errorMessage = "", bool throwException = true)
        {
            ValidateArguments(dbConnection, storedProcedureName);

            try
            {
                using (var dbCommand = dbConnection.CreateCommand())
                {
                    SetupDbCommand(dbConnection, dbCommand, storedProcedureName, parameters);
                    dbCommand.Connection.Open();
                    dbCommand.ExecuteNonQuery();

                    dbCommand.Connection.CleanupConnection();
                }
            }
            catch (DbException ex)
            {
                dbConnection.CleanupConnection();
                _log.Error(string.IsNullOrEmpty(errorMessage)
                               ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);

                if (throwException)
                    throw;
            }
        }

        /// <summary>
        /// Executes a query and returns a populated DataTable
        /// </summary>
        public DataTable ExecuteQuery(IDbConnection dbConnection,
                                      string storedProcedureName,
                                      IEnumerable<IDataParameter> parameters = null,
                                      string errorMessage = "", bool throwException = true)
        {
            ValidateArguments(dbConnection, storedProcedureName);

            var table = new DataTable();

            try
            {
                using (var dbCommand = dbConnection.CreateCommand())
                {
                    SetupDbCommand(dbConnection, dbCommand, storedProcedureName, parameters);
                    dbConnection.Open();

                    using (var dbReader = dbCommand.ExecuteReader())
                    {
                        table.Load(dbReader);
                    }

                    dbCommand.Connection.CleanupConnection();
                }
            }
            catch (DbException ex)
            {
                dbConnection.CleanupConnection();
                _log.Error(string.IsNullOrEmpty(errorMessage)
                               ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);

                if (throwException)
                    throw;
            }

            return table;
        }

        /// <summary>
        /// Executes a query and returns an object of type T
        /// </summary>
        public T ExecuteQuery<T>(IDbConnection dbConnection,
                                 string storedProcedureName,
                                 Func<IDataReader, T> translateFunction,
                                 IEnumerable<IDataParameter> parameters = null,
                                 string errorMessage = "", bool throwException = true) where T : class, new()
        {
            ValidateArguments(dbConnection, storedProcedureName);
            if (translateFunction == null) throw new ArgumentNullException(nameof(translateFunction));

            try
            {
                using (var dbCommand = dbConnection.CreateCommand())
                {
                    SetupDbCommand(dbConnection, dbCommand, storedProcedureName, parameters);
                    dbConnection.Open();
                    using (var dbReader = dbCommand.ExecuteReader())
                    {
                        var result = translateFunction.Invoke(dbReader);

                        dbCommand.Connection.CleanupConnection();

                        return result;
                    }
                }
            }
            catch (DbException ex)
            {
                dbConnection.CleanupConnection();
                _log.Error(string.IsNullOrEmpty(errorMessage)
                               ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);

                if (throwException)
                    throw;
            }

            return null;
        }

        /// <summary>
        /// Sets up the DbCommand parameters that are needed and also populates the parameter collection
        /// </summary>
        internal static void SetupDbCommand(IDbConnection dbConnection,
                                            IDbCommand dbCommand,
                                            string storedProcedureName,
                                            IEnumerable<IDataParameter> parameters)
        {
            dbCommand.Connection = dbConnection;
            dbCommand.CommandText = storedProcedureName;
            dbCommand.CommandType = IsInternalSql(storedProcedureName) ? CommandType.Text : CommandType.StoredProcedure;
            if (parameters != null && parameters.Any())
                parameters.ToList().ForEach(parameter => dbCommand.Parameters.Add(parameter));
        }

        /// <summary>
        /// Validates the basic arguments that execute functions utilize
        /// </summary>
        internal static void ValidateArguments(IDbConnection dbConnection, string storedProcedureName)
        {
            if (dbConnection == null) throw new ArgumentNullException(nameof(dbConnection));
            if (string.IsNullOrWhiteSpace(storedProcedureName)) throw new ArgumentNullException(nameof(storedProcedureName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        internal static bool IsInternalSql(string sqlString)
        {
            var words = sqlString.ToUpper().Split(' ');
            return SqlCommands.Contains(words[0]) && !DisallowedCommands.Contains(words[0]);
        }
    }
}
