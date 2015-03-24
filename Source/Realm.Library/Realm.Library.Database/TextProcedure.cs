using System.Data;

namespace Realm.Library.Database
{
    /// <summary>
    /// Class that defines a text procedure in a sql database
    /// </summary>
    public class TextProcedure<T> : Procedure<T>
        where T : IDataParameter, new()
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="schema"> </param>
        /// <param name="name"></param>
        public TextProcedure(string schema, string name)
            : base(schema, name, CommandType.Text) { }
    }
}