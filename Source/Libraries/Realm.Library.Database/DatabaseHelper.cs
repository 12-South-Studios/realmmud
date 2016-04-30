using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Realm.Library.Common.Logging;

namespace Realm.Library.Database
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DatabaseHelper
    {
        private readonly ILogWrapper _log;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseHelper(ILogWrapper log)
        {
            _log = log;
        }

        /// <summary>
        /// 
        /// </summary>
        public object ExecuteScalar(IDbConnection connection, string storedProcedureName,
                                            List<IDataParameter> parameters, string errorMessage = "")
        {
            ValidateArguments(connection, storedProcedureName);

            object result = null;
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            catch (DbException ex)
            {
                _log.Error(string.IsNullOrEmpty(errorMessage)
                              ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExecuteNonQuery(IDbConnection connection, string storedProcedureName,
                                        List<IDataParameter> parameters, string errorMessage = "")
        {
            ValidateArguments(connection, storedProcedureName);

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                _log.Error(string.IsNullOrEmpty(errorMessage)
                              ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        /// <summary>
        /// Executes a query and returns a populated DataTable
        /// </summary>
        public DataTable ExecuteQuery(IDbConnection connection, string storedProcedureName,
                                        List<IDataParameter> parameters, string errorMessage = "")
        {
            ValidateArguments(connection, storedProcedureName);

            var table = new DataTable();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            catch (DbException ex)
            {
                _log.Error(string.IsNullOrEmpty(errorMessage)
                              ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return table;
        }

        /// <summary>
        /// Executes a query and returns an object of type T
        /// </summary>
        public T ExecuteQuery<T>(IDbConnection connection, string storedProcedureName,
                                        List<IDataParameter> parameters, Func<IDataReader, T> translateFunction,
                                        string errorMessage = "") where T : class, new()
        {
            ValidateArguments(connection, storedProcedureName);
            if (translateFunction == null) throw new ArgumentNullException(nameof(translateFunction));

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var newObject = translateFunction.Invoke(reader);
                        return newObject;
                    }
                }
            }
            catch (DbException ex)
            {
                _log.Error(string.IsNullOrEmpty(errorMessage)
                              ? $"{storedProcedureName} threw an Exception: {ex.Message}"
                    : errorMessage, ex);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return null;
        }

        /// <summary>
        /// Sets up the DbCommand parameters that are needed and also populates the parameter collection
        /// </summary>
        internal static void SetupDbCommand(IDbConnection connection, IDbCommand cmd,
                                            string storedProcedureName, List<IDataParameter> parameters)
        {
            cmd.Connection = connection;
            cmd.CommandText = storedProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Any())
                parameters.ForEach(parameter => cmd.Parameters.Add(parameter));
        }

        /// <summary>
        /// Validates the basic arguments that execute functions utilize
        /// </summary>
        internal static bool ValidateArguments(IDbConnection connection, string storedProcedureName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (string.IsNullOrWhiteSpace(storedProcedureName)) throw new ArgumentNullException(nameof(storedProcedureName));
            return true;
        }
    }
}
