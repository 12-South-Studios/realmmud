using System.Data;

namespace Realm.Library.Database
{
    /// <summary>
    /// Class that implements IDbParameter
    /// </summary>
    public class DbParameter : IDbParameter
    {
        /// <summary>
        /// Gets the db type
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// Gets the parameter direction
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// Gets if this parameter is nullable
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Gets the name of the parameter
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets the source column of the parameter
        /// </summary>
        public string SourceColumn { get; set; }

        /// <summary>
        /// Gets the data row version
        /// </summary>
        public DataRowVersion SourceVersion { get; set; }

        /// <summary>
        /// Gets the value of the parameter
        /// </summary>
        public object Value { get; set; }
    }
}