//// ----------------------------------------------------------------------
//// <copyright file="DataManager.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using Realm.Library.Common;
//using Realm.Library.Lua;
//using Realm.Library.Patterns.Singleton;
//using Realm.Server.Ai;
//using Realm.Server.Events;
//using Realm.Server.Factories;
//using Realm.Server.Resets;
//using Realm.Server.Zones;
//using log4net;

//namespace Realm.Server.Managers
//{
//    public sealed class DataManager : Singleton, IDataManager
//    {
//        static DataManager _instance;
//        static readonly object Padlock = new object();

//        private readonly IDictionary<string, List<ICell>> _lookups;
//        private readonly IDictionary<string, object> _factories;

//        private IEventManager _eventManager;
//        private ILog _log;
//        private ILuaManager _luaManager;

//        private DataManager()
//        {
//            _lookups = new ConcurrentDictionary<string, List<ICell>>();
//            _factories = new ConcurrentDictionary<string, object>();
//        }

//        public void OnInit(IEventManager eventManager, ILog log, ILuaManager luaManager)
//        {
//            _eventManager = eventManager;
//            _log = log;
//            _luaManager = luaManager;

//            _eventManager.RegisterListener(this, Game.Instance, typeof(OnGameInitialize), Instance_OnGameInitialize);
//            _luaManager.RegisterLuaFunctions(this);
//        }

//        void Instance_OnGameInitialize(RealmEventArgs args)
//        {
//            var booleanSet = args.GetValue("BooleanSet") as BooleanSet;
//            if (booleanSet.IsNull()) return;

//            _log.Info("DataManager initialized.");
//            booleanSet.CompleteItem("DataManager");
//        }

//        private void RegisterFactory(string name, object factory)
//        {
//            if (_factories.ContainsKey(name.ToLower()))
//                return;
//            _factories.Add(name.ToLower(), factory);
//        }

//        public object GetFactory(string name)
//        {
//            if (!_factories.ContainsKey(name.ToLower()))
//                return null;
//            object factory;
//            _factories.TryGetValue(name.ToLower(), out factory);
//            return factory;
//        }

//        public static DataManager Instance
//        {
//            get
//            {
//                lock (Padlock)
//                {
//                    return _instance ?? (_instance = new DataManager());
//                }
//            }
//        }

//        public bool Add(string aList, ICell aObject)
//        {
//            List<ICell> cellList;

//            if (!_lookups.ContainsKey(aList.ToLower()))
//            {
//                cellList = new List<ICell>();
//                _lookups[aList.ToLower()] = cellList;
//            }

//            cellList = _lookups[aList.ToLower()];
//            if (cellList.Contains(aObject)) return false;
//            cellList.Add(aObject);
//            return true;
//        }

//        public bool Remove(string aList, ICell aObject)
//        {
//            if (!_lookups.ContainsKey(aList.ToLower())) return false;

//            var cellList = _lookups[aList.ToLower()];
//            return cellList.Contains(aObject) && cellList.Remove(aObject);
//        }

//        public bool Has(string aList, ICell aObject)
//        {
//            if (!_lookups.ContainsKey(aList.ToLower())) return false;
//            var cellList = _lookups[aList.ToLower()];
//            return cellList.Contains(aObject);
//        }

//        public IList<ICell> GetList(string aList)
//        {
//            return !_lookups.ContainsKey(aList.ToLower()) ? new List<ICell>() : new List<ICell>(_lookups[aList]);
//        }

//        public ICell Get(string aList, int aId)
//        {
//            var cellList = GetList(aList.ToLower());
//            return cellList.FirstOrDefault(cell => cell.ID == aId);
//        }

//        public ICell Get(string aList, long aId)
//        {
//            var cellList = GetList(aList.ToLower());
//            return cellList.FirstOrDefault(cell => cell.ID == aId);
//        }

//        public ICell Get(string aList, string aName)
//        {
//            var cellList = GetList(aList.ToLower());
//            return cellList.FirstOrDefault(cell => cell.Name.Equals(aName, StringComparison.OrdinalIgnoreCase) 
//                || cell.ID.ToString().Equals(aName, StringComparison.OrdinalIgnoreCase));
//        }

//        public int GetListCount(string aList)
//        {
//            return GetList(aList.ToLower()).Count;
//        }

//        public IEnumerable<string> TableKeys
//        {
//            get { return _lookups.Keys; }
//        }

//        [LuaFunction("GetStaticData", "Gets Static Data", "List to retrieve from", "Name of the Static Data")]
//        public ICell LuaGetStaticData(string list, string name)
//        {
//            return Get(list, name);
//        }





//        /*[LuaFunction("cloneRace", "Clones a Race", "Existing Race Name", "New Race ID", "New Race Name")]
//        public Race LuaCloneRace(string existingRaceName, int newRaceId, string newRaceName)
//        {
//            Race oldRace = GetRace(existingRaceName);
//            if (Utils.IsNull(oldRace))
//            {
//                return null;
//            }
//            if (existingRaceName.Equals(newRaceName))
//            {
//                return null;
//            }
//            if (oldRace.Id == newRaceId)
//            {
//                return null;
//            }

//            Race newRace = new Race(newRaceId, oldRace);
//            if (Utils.IsNull(newRace))
//            {
//                LogError("cloneRace", "Failed to clone new Race[" + newRaceId + "] from old Race[" + existingRaceName + "]");
//                return null;
//            }

//            newRace.SetName(newRaceName);
//            Add("Race", newRace);
//            LogSystem("cloneRace", "Race[" + newRaceId + ", " + newRaceName + "]");
//            return newRace;
//        }*/
//    }
//}
