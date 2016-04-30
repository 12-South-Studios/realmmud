using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Data.Properties;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Database.Framework;

namespace Realm.Data.Loaders
{
    /// <summary>
    ///
    /// </summary>
    public abstract class Loader<T> : DatabaseClient, ILoader
        where T : Definition
    {
        private Dictionary<string, string> _commands;

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="staticDataRepository"></param>
        /// <param name="log"></param>
        /// <param name="schema"> </param>
        /// <param name="systemType"></param>
        protected Loader(IEntity owner,  IDatabaseLoadBalancer loadBalancer,
            IStaticDataRepository staticDataRepository, ILogWrapper log, string schema,
            Globals.SystemTypes systemType)
            : base(owner, loadBalancer)
        {
            Repository = (StaticDataRepository)staticDataRepository;
            Log = log;
            SystemType = systemType;
            IdColumn = systemType + "ID";
            NameColumn = "DisplayName";
            Schema = schema;
            _commands = new Dictionary<string, string>();
        }

        /// <summary>
        ///
        /// </summary>
        private BooleanSet LoadingSet { get; set; }

        /// <summary>
        ///
        /// </summary>
        private StaticDataRepository Repository { get; set; }

        /// <summary>
        ///
        /// </summary>
        private ILogWrapper Log { get; set; }

        /// <summary>
        ///
        /// </summary>
        private Globals.SystemTypes SystemType { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string IdColumn { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public string NameColumn { get; private set; }

        /// <summary>
        ///
        /// </summary>
        private string Schema { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="boolSet"></param>
        /// <returns></returns>
        public abstract bool Load(BooleanSet boolSet);

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnLoadComplete(RealmEventArgs args)
        {
            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
            {
                Log.ErrorFormat(Resources.ERR_LOADER_FAILURE, GetType());
                return;
            }

            var commandResults = data.GetAtom<ListAtom>("commandResult");
            var it = commandResults.GetEnumerator();
            while (it.MoveNext())
            {
                var commandResult = it.Current.CastAs<DictionaryAtom>();
                var commandName = commandResult.GetString("CommandName");
                var results = commandResult.GetAtom<ListAtom>("Results");

                if (!_commands.ContainsKey(commandName))
                {
                    Log.ErrorFormat(Resources.ERR_CMD_NOT_FOUND, commandName, GetType());
                    continue;
                }

                if (string.IsNullOrEmpty(_commands[commandName]))
                    LoadPrimitive(results);
                else
                    AddToSubList(commandResults, _commands[commandName]);
            }

            LoadingSet.CompleteItem(IdColumn);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="booleanSet"></param>
        /// <param name="commands"></param>
        /// <returns></returns>
        protected bool BuildAndExecuteTransaction(BooleanSet booleanSet, Dictionary<string, string> commands)
        {
            LoadingSet = booleanSet;

            BeginTransaction();

            _commands = commands;
            foreach (var command in commands.Keys)
                AddCommand(Schema, command);

            PerformTransaction(OnLoadComplete, null);

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="commandResults"></param>
        /// <param name="subListName"></param>
        private void AddToSubList(IEnumerable<Atom> commandResults, string subListName)
        {
            var itResult = commandResults.GetEnumerator();
            while (itResult.MoveNext())
            {
                var result = itResult.Current.CastAs<DictionaryAtom>();
                var def = Repository.GetSubtype(SystemType.GetValue(), result.GetInt(IdColumn).ToString(CultureInfo.InvariantCulture));
                if (def.IsNull())
                    throw new ObjectNotFoundException(string.Format(Resources.ERR_PRIMITIVE_NOT_FOUND, result.GetInt(IdColumn)));

                var newsubList = false;
                var subList = def.Def.GetAtom<ListAtom>(subListName);
                if (subList.IsNull())
                {
                    subList = new ListAtom();
                    newsubList = true;
                }

                subList.Add(result);
                if (newsubList)
                    def.Def.Set(subListName, subList);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="commandResults"></param>
        private void LoadPrimitive(IEnumerable<Atom> commandResults)
        {
            Validation.IsNotNull(commandResults, "commandResults");

            var itResult = commandResults.GetEnumerator();
            while (itResult.MoveNext())
            {
                var result = itResult.Current.CastAs<DictionaryAtom>();
                var defType = typeof(T);
                var def = (T)Activator.CreateInstance(defType, result.GetInt(IdColumn), result.GetString(NameColumn), result);
                Repository.AddSubtype(SystemType.GetValue(), result.GetInt(IdColumn).ToString(CultureInfo.InvariantCulture), def);
            }
        }
    }
}