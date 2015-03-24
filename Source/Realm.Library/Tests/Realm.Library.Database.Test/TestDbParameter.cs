using System.Data;

namespace Realm.Library.Database.Test
{
    public class TestDbParameter : IDbParameter
    {
        #region Implementation of IDataParameter

        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsNullable { get; private set; }
        public string ParameterName { get; set; }
        public string SourceColumn { get; set; }
        public DataRowVersion SourceVersion { get; set; }
        public object Value { get; set; }

        #endregion
    }
}
