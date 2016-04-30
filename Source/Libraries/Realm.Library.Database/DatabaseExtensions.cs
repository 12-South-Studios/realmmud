using System.Collections.Generic;
using System.Data;
using System.Linq;
using Realm.Library.Common.Data;
using Realm.Library.Common.Objects;

namespace Realm.Library.Database
{
    /// <summary>
    ///
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <param name="args"></param>
        public static void PopulateCommandArgs(this IDbCommand command,
            IDictionary<string, IDataParameter> parameters,
            IDictionary<string, object> args)
        {
            args.Keys.Where(parameters.ContainsKey).ToList().ForEach(param =>
                {
                    var sqlParameter = parameters[param];
                    sqlParameter.Value = args[param];
                    command.Parameters.Add(sqlParameter);
                });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameterCollection"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        public static void AddWithValue<T>(this IDataParameterCollection parameterCollection,
            string parameterName, object parameterValue) where T : IDataParameter, new()
        {
            parameterCollection.Add(new T
                {
                    ParameterName = parameterName,
                    Value = parameterValue
                });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static bool TryOpen(this IDbConnection connection)
        {
            bool returnVal = true;

            if (connection.IsNull()) returnVal = false;
            else if (connection.State != ConnectionState.Closed) returnVal = false;
            else
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }

            return returnVal;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="actionToTake"></param>
        public static void RollbackOrCommit(this IDbTransaction transaction, TransactionAction actionToTake)
        {
            if (transaction.IsNull()) return;
            using (transaction)
            {
                if (actionToTake == TransactionAction.Rollback) transaction.Rollback();
                else transaction.Commit();
            }
        }

        /// <summary>
        /// Converts a datatable to a listatom
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static ListAtom ToListAtom(this DataTable table)
        {
            var resultList = new ListAtom();

            table.Rows.OfType<DataRow>().ToList().ForEach(row =>
                {
                    var rowResult = new DictionaryAtom();
                    table.Columns.OfType<DataColumn>().ToList().ForEach(col => rowResult.Set(col.ColumnName, row[col]));
                    resultList.Add(rowResult);
                });

            return resultList;
        }
    }
}