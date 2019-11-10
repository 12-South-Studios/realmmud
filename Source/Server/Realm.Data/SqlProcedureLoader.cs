using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Realm.Data.Properties;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Database;
using Realm.Library.Database.Framework;

namespace Realm.Data
{
    /// <summary>
    ///
    /// </summary>
    public class SqlProcedureLoader : ProcedureLoader<SqlConnection>
    {
        private readonly string _catalog;
        private readonly string _schema;
        private readonly string _prefix;

        /// <summary>
        ///
        /// </summary>
        /// <param name="log"></param>
        /// <param name="connectionString"></param>
        /// <param name="catalog"></param>
        /// <param name="schema"></param>
        /// <param name="prefix"></param>
        public SqlProcedureLoader(LogWrapper log, string connectionString, string catalog, string schema, string prefix)
            : base(connectionString, log)
        {
            _catalog = catalog;
            _schema = schema;
            _prefix = prefix;
        }

        /// <summary>
        /// Generates and populates a procedure repository by reading from the indicated
        /// database and creating procedure objects for each procedure found.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")]
        public override IProcedureRepository ProcedureRepository
        {
            get
            {
                IProcedureRepository repository = null;
                var procedureList = new List<string>();
                try
                {
                    Connection.TryOpen();

                    using (var command = Connection.CreateCommand())
                    {
                        var sb = new StringBuilder(Resources.SQL_PROCEDURE_QUERY);
                        sb = sb.Replace("@Catalog", _catalog);
                        sb = sb.Replace("@Schema", _schema);
                        sb = sb.Replace("@SpecificName", _prefix);
                        command.CommandText = sb.ToString();
                        command.CommandType = CommandType.Text;

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            procedureList.Add(reader["SPECIFIC_NAME"].ToString());
                        }
                        reader.Dispose();
                    }

                    repository = PopulateProcedureRepository(procedureList);
                }
                catch (SqlException ex)
                {
                    ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
                }
                finally
                {
                    if (Connection != null && Connection.State != ConnectionState.Closed)
                        Connection.Close();
                }

                return repository;
            }
        }

        /// <summary>
        /// Populates and returns a new procedure repository from the provided list
        /// </summary>
        /// <param name="procedureList"></param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")]
        private IProcedureRepository PopulateProcedureRepository(IEnumerable<string> procedureList)
        {
            IProcedureRepository procedureRepo = new ProcedureRepository();

            try
            {
                Connection.TryOpen();
                procedureList.ToList().ForEach(proc => ProcessProcedure(proc, procedureRepo));
            }
            catch (SqlException ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            return procedureRepo;
        }

        private void ProcessProcedure(string proc, IProcedureRepository procedureRepo)
        {
            var procedure = new StoredProcedure<SqlParameter>(_schema, proc);
            using (var command = Connection.CreateCommand())
            {
                var sb = new StringBuilder(Resources.SQL_PARAMETER_QUERY);
                sb = sb.Replace("@Catalog", _catalog);
                sb = sb.Replace("@Schema", _schema);
                sb = sb.Replace("@ProcName", proc);
                command.CommandText = sb.ToString();
                command.CommandType = CommandType.Text;


                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    procedure.AddParameter(CreateParameter(reader));
                }
                reader.Dispose();
            }

            procedureRepo.Add(new ProcedureKey(_schema, proc), procedure);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static IDbParameter CreateParameter(IDataRecord reader)
        {
            var param = DatabaseUtils.CreateParameter<DbParameter>();
            var tc = new DatabaseTypeConverter();

            param.DbType = tc.GetDbType(reader["DATA_TYPE"].ToString());

            var paramMode = reader["PARAMETER_MODE"].ToString();
            switch (paramMode.ToUpper())
            {
                case "IN": param.Direction = ParameterDirection.Input;
                    break;
                case "OUT": param.Direction = ParameterDirection.Output;
                    break;
                default: param.Direction = ParameterDirection.InputOutput;
                    break;
            }
            param.ParameterName = reader["PARAMETER_NAME"].ToString();

            return param;
        }
    }
}