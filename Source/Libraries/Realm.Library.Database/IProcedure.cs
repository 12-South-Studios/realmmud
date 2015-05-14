using System.Collections.Generic;
using System.Data;

namespace Realm.Library.Database
{
    /// <summary>
    /// Declares a contract for a database procedure
    /// </summary>
    public interface IProcedure
    {
        /// <summary>
        /// Gets the name of the procedure
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the text of the procedure
        /// </summary>
        string CommandText { get; set; }

        /// <summary>
        ///
        /// </summary>
        CommandType CommandType { get; }

        /// <summary>
        /// Gets the number of parameters
        /// </summary>
        int NumberParameters { get; }

        /// <summary>
        /// Gets an enumerable list of parameters
        /// </summary>
        IEnumerable<IDataParameter> ParameterList { get; }

        /// <summary>
        ///
        /// </summary>
        IDictionary<string, IDataParameter> Parameters { get; }

        /// <summary>
        /// Adds a parameter to the procedure
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="paramType"></param>
        void AddParameter(string parameterName, DbType paramType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        void AddParameter(IDbParameter parameter);

        /// <summary>
        /// Converts the procedure to a string
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}