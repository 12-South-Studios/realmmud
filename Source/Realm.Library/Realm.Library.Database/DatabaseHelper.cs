﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using log4net;

namespace Realm.Library.Database
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DatabaseHelper
    {
        private readonly ILog Log;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseHelper()
        {
            Log = LogManager.GetLogger(typeof(DatabaseHelper));
        }

        internal DatabaseHelper(ILog log)
        {
            Log = log;
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
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            catch (DbException ex)
            {
                Log.Error(string.IsNullOrEmpty(errorMessage)
                              ? string.Format("{0} threw an Exception: {1}", storedProcedureName, ex.Message)
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
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                Log.Error(string.IsNullOrEmpty(errorMessage)
                              ? string.Format("{0} threw an Exception: {1}", storedProcedureName, ex.Message)
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

            DataTable table = new DataTable();

            try
            {
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                            table.Load(reader);
                    }
                }
            }
            catch (DbException ex)
            {
                Log.Error(string.IsNullOrEmpty(errorMessage)
                              ? string.Format("{0} threw an Exception: {1}", storedProcedureName, ex.Message)
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
            if (translateFunction == null) throw new ArgumentNullException("translateFunction");

            try
            {
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    SetupDbCommand(connection, cmd, storedProcedureName, parameters);

                    cmd.Connection.Open();
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        var newObject = new T();
                        if (reader != null)
                            newObject = translateFunction.Invoke(reader);
                        return newObject;
                    }
                }
            }
            catch (DbException ex)
            {
                Log.Error(string.IsNullOrEmpty(errorMessage)
                              ? string.Format("{0} threw an Exception: {1}", storedProcedureName, ex.Message)
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
            if (connection == null) throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(storedProcedureName)) throw new ArgumentNullException("storedProcedureName");
            return true;
        }
    }
}
