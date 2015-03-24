using System.Data;

namespace Realm.Library.Database
{
    /// <summary>
    /// Class that defines a stored procedure in a sql database
    /// </summary>
    public class StoredProcedure<T> : Procedure<T>
        where T : IDataParameter, new()
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="schema"> </param>
        /// <param name="name"></param>
        public StoredProcedure(string schema, string name)
            : base(schema, name, CommandType.StoredProcedure) { }
    }
}