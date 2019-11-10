using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Realm.Command.Interfaces;
using Realm.Entity.Entities.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Objects;

namespace Realm.Command.Parsers
{
    public class CommandParser : Parser
    {
        private IVariableHelper Helper { get; }

        private readonly Dictionary<string, Func<string, IGameEntity, string>> _functionMap = new Dictionary
            <string, Func<string, IGameEntity, string>>
            {
                {"timestamp", GetTimestamp},
                {"datestamp", GetDatestamp},
                {"property", GetProperty}
            };

        public CommandParser(IVariableHelper helper, ICommandManager commandManager)
            : base(commandManager)
        {
            Helper = helper;
        }

        /// <summary>
        /// Populates the command argument dictionary with the given data
        /// </summary>
        public IDictionary<string, object> PopulateCommandArgs(IBiota oActor, IEntity obj1,
            IEntity obj2, string aKeyword, bool aMessage = false)
        {
            return new Dictionary<string, object>
                {
                    {"actor", oActor},
                    {"object1", obj1},
                    {"object2", obj2},
                    {"keyword", aKeyword},
                    {"message", aMessage}
                };
        }

        /// <summary>
        /// Takes incoming data and populates the ReportData object
        /// </summary>
        public static ReportData ToReportData(IEntity oActor = null, IEntity oVictim = null,
            object oDirectObject = null, object oIndirectObject = null, object oSpace = null, object oExtra = null)
        {
            return new ReportData
                {
                    Actor = oActor,
                    Victim = oVictim,
                    DirectObject = oDirectObject,
                    IndirectObject = oIndirectObject,
                    Extra = oExtra,
                    Space = oSpace
                };
        }

        /// <summary>
        /// Parses incoming data for the given variable
        /// </summary>
        public string ParseVariable(string var, ReportData data)
        {
            Validation.IsNotNull(data, "data");

            var returnVal = string.Empty;

            var func = Helper.GetDelegate(var);
            if (func != null)
                returnVal = (string)func.DynamicInvoke(data);

            return returnVal;
        }

        /// <summary>
        /// Replaces any occurrences of a #string# entry with the property value
        /// </summary>
        public string ParseRegex(string str, IGameEntity entity = null)
        {
            var newText = str;

            const string pattern = "(?<=\\#)[A-Z_a-z]+(?=\\#)";
            while (Regex.IsMatch(newText, pattern, RegexOptions.IgnoreCase))
            {
                var match = Regex.Match(newText, pattern, RegexOptions.IgnoreCase);
                var foundString = newText.Substring(match.Index, match.Length);

                var func = GetFunction(foundString);
                newText = newText.Replace("#" + foundString + "#", func.Invoke(foundString, entity));
            }
            return newText;
        }

        /// <summary>
        /// Retrieves the matching function out of the table or returns the default
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        private Func<string, IGameEntity, string> GetFunction(string function)
        {
            Func<string, IGameEntity, string> func;
            try
            {
                func = _functionMap[function] ?? _functionMap["property"];
            }
            catch
            {
                func = _functionMap["property"];
            }
            return func;
        }
        private static string GetTimestamp(string text, IGameEntity entity)
        {
            return DateTime.Now.TimeOfDay.ToString();
        }
        private static string GetDatestamp(string text, IGameEntity entity)
        {
            return DateTime.Now.ToString();
        }
        private static string GetProperty(string text, IGameEntity entity)
        {
            var returnVal = string.Empty;

            if (entity == null) return returnVal;
            var ctx = entity.GetContext("PropertyContext");
            if (ctx == null) return returnVal;
            var obj = ctx.CastAs<PropertyContext>().GetProperty<object>(text);
            if (obj != null)
                returnVal = obj.ToString();

            return returnVal;
        }
    }
}