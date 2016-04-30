using System.Collections.Generic;
using System.Data;
using Realm.Library.Database.Properties;

namespace Realm.Library.Database
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Procedure<T> : IProcedure
        where T : IDataParameter, new()
    {
        private readonly IDictionary<string, IDataParameter> _parameters = new Dictionary<string, IDataParameter>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="schema"> </param>
        /// <param name="name"></param>
        /// <param name="commandType"></param>
        protected Procedure(string schema, string name, CommandType commandType)
        {
            Schema = schema;
            Name = name;
            CommandType = commandType;
        }

        /// <summary>
        /// Gets the schema of the procedure
        /// </summary>
        public string Schema { get; private set; }

        /// <summary>
        /// Gets the name of the procedure
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the text of the procedure
        /// </summary>
        public string CommandText { get; set; }

        /// <summary>
        ///
        /// </summary>
        public CommandType CommandType { get; }

        /// <summary>
        /// Gets the number of parameters
        /// </summary>
        public int NumberParameters => _parameters.Count;

        /// <summary>
        /// Gets an enumerable list of parameters
        /// </summary>
        public IEnumerable<IDataParameter> ParameterList => _parameters.Values;

        /// <summary>
        ///
        /// </summary>
        public IDictionary<string, IDataParameter> Parameters => _parameters;

        /// <summary>
        /// Adds a parameter to the procedure
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="paramType"></param>
        public void AddParameter(string parameterName, DbType paramType)
        {
            if (_parameters.ContainsKey(parameterName)) return;
            var param = DatabaseUtils.CreateParameter<T>();
            param.DbType = paramType;
            param.ParameterName = parameterName;
            _parameters[parameterName] = param;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        public void AddParameter(IDbParameter parameter)
        {
            if (!_parameters.ContainsKey(parameter.ParameterName))
                _parameters[parameter.ParameterName] = parameter;
        }

        /// <summary>
        /// Converts the procedure to a string
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return string.Format(Resources.MSG_PROC_TOSTRING, GetType(), Name, NumberParameters);
        }
    }
}