using System;
using System.Collections;
using System.Reflection;
using Realm.Library.Common;

namespace Realm.Library.Lua
{
    /// <summary>
    /// Defines a description for a Lua Function
    /// </summary>
    public sealed class LuaFunctionDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the LuaFunctionDescriptor class.
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <param name="description">Description of the function</param>
        /// <param name="parameters">Hashtable of parameter strings</param>
        /// <param name="info"></param>
        public LuaFunctionDescriptor(string name, string description, IDictionary parameters, MethodInfo info)
        {
            Validation.IsNotNullOrEmpty(name, "name");
            Validation.IsNotNullOrEmpty(description, "description");
            Validation.IsNotNull(parameters, "parameters");
            Validation.IsNotNull(info, "info");

            Name = name;
            Description = description;
            Parameters = parameters;
            Info = info;

            var strFunctionHeader = $"{name}(%params%) - {description}";
            var strFunctionBody = "\n\n";
            var strFunctionParams = string.Empty;

            var first = true;
            foreach (DictionaryEntry entry in parameters)
            {
                if (!first)
                    strFunctionParams += ", ";

                strFunctionParams += entry.Key;
                strFunctionBody += $"\t{entry.Key}\t\t{entry.Value}\n";
                first = false;
            }

            strFunctionBody = strFunctionBody.Substring(0, strFunctionBody.Length - 1);
            if (first)
                strFunctionBody = strFunctionBody.Substring(0, strFunctionBody.Length - 1);

            FullDescription = strFunctionHeader.Replace("%params%", strFunctionParams) + strFunctionBody;
        }

        /// <summary>
        /// Gets the name of the function
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the function
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the parameter list of the function
        /// </summary>
        public IDictionary Parameters { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public MethodInfo Info { get; private set; }

        /// <summary>
        /// Gets the header of the function
        /// </summary>
        public string Header => FullDescription.IndexOf("\n", StringComparison.Ordinal) == -1
            ? FullDescription
            : FullDescription.Substring(0, FullDescription.IndexOf("\n", StringComparison.Ordinal));

        /// <summary>
        /// Gets the full description
        /// </summary>
        public string FullDescription { get; private set; }
    }
}