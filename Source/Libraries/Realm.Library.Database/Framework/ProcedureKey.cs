using System;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    ///
    /// </summary>
    public class ProcedureKey
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        public ProcedureKey(string schema, string name)
        {
            Schema = schema;
            Name = name;
        }

        /// <summary>
        ///
        /// </summary>
        public string Schema { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsEqual(string schema, string name)
        {
            return (Schema.Equals(schema, StringComparison.OrdinalIgnoreCase)
                    && Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}