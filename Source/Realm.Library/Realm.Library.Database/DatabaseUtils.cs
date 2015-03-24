using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Realm.Library.Common;

namespace Realm.Library.Database
{
    /// <summary>
    /// Utility class for database functions
    /// </summary>
    public static class DatabaseUtils
    {
        /// <summary>
        /// Creates a parameter of the type
        /// </summary>
        public static T CreateParameter<T>() where T : IDataParameter, new()
        {
            return new T();
        }

        /// <summary>
        /// Creates a parameter of the type using the given object
        /// </summary>
        public static T CreateParameter<T>(object o) where T : IDataParameter, new()
        {
            return new T { Value = o, DbType = DbType.Object };
        }

        /// <summary>
        /// Creates a paramter with the given name and object
        /// </summary>
        public static T CreateParameter<T>(string name, object o) where T : IDataParameter, new()
        {
            return new T { ParameterName = name, Value = o, DbType = DbType.Object };
        }

        /// <summary>
        /// Creates a parameter with the given name, object and type
        /// </summary>
        public static T CreateParameter<T>(string name, object o, DbType t) where T : IDataParameter, new()
        {
            return new T { ParameterName = name, Value = o, DbType = t };
        }

        /// <summary>
        /// Creates a parameter list using the provided objects
        /// </summary>
        public static IList<T> CreateParameterList<T>(params object[] objects)
            where T : IDataParameter, new()
        {
            var paramList = new List<T>();
            if (objects.IsNull()) return paramList;

            paramList.AddRange(objects.Select(CreateParameter<T>));
            return paramList;
        }

        /// <summary>
        /// Creates a parameter list using the provided parameter objects
        /// </summary>
        public static IList<T> CreateParameterList<T>(params T[] parameters)
            where T : IDataParameter, new()
        {
            var paramList = new List<T>();
            if (parameters.IsNull()) return paramList;

            paramList.AddRange(parameters);
            return paramList;
        }

        /// <summary>
        /// Retrieves a value from the given DataRow and Column or returns
        /// the default if the column is not present.
        /// </summary>
        public static T GetValueOrDefault<T>(DataRow dataRow, string columnName, T defaultValue)
        {
            Validation.IsNotNull(dataRow, "dataRow");
            Validation.IsNotNullOrEmpty(columnName, "columnName");

            if (dataRow.Table.Columns.Contains(columnName) && dataRow[columnName] != DBNull.Value)
                return dataRow[columnName].CastAs<T>();
            return defaultValue;
        }
    }
}