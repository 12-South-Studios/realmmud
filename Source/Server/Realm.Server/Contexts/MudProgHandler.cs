//using System;
//using System.Collections.Generic;
//using Realm.Command;
//using Realm.Command.Interfaces;
//using Realm.Data;
//using Realm.Server.Channels;
//using Realm.Server.Commands;
//using Realm.Server.Events;
//using Realm.Server.Interfaces;
//using Realm.Server.Managers;
//using Realm.Server.Pathfinding;
//using Realm.Server.Players;
//using Realm.Server.Time;
//using log4net;

//namespace Realm.Server.Contexts
//{
//    public class MudProgHandler : IMudProgHandler, IManagerReference, ILogging
//    {
//        private readonly IDictionary<Type, string> _mudprogs = new Dictionary<Type, string>();

//        #region IMudProgHandler
//        public MudProg Get(Type eventType)
//        {
//            if (_mudprogs.ContainsKey(eventType))
//                return DataManager.Get("MudProgs", _mudprogs[eventType]) as MudProg;
//            return null;
//        }

//        public bool Contains(Type eventType)
//        {
//            return _mudprogs.ContainsKey(eventType);
//        }

//        public bool Add(Type eventType, string progName)
//        {
//            if (_mudprogs.ContainsKey(eventType))
//            {
//                if (_mudprogs[eventType].Equals(progName))
//                    return false;
//            }
//            _mudprogs[eventType] = progName;
//            return true;
//        }

//        public bool Remove(Type eventType)
//        {
//            return _mudprogs.ContainsKey(eventType) && _mudprogs.Remove(eventType);
//        }
//        #endregion

//        #region IManagerReference
//        public IDataManager DataManager { get; set; }
//        public IEntityManager EntityManager { get; set; }
//        public ICommandManager CommandManager { get; set; }
//        public IEventManager EventManager { get; set; }
//        public ILuaManager LuaManager { get; set; }
//        public IDatabaseManager DatabaseManager { get; set; }
//        public ICombatManager CombatManager { get; set; }
//        public IPathManager PathManager { get; set; }
//        public IHelpManager HelpManager { get; set; }
//        public ITimeManager TimeManager { get; set; }
//        public INetworkManager NetworkManager { get; set; }
//        public IChannelManager ChannelManager { get; set; }
//        public IGame Game { get; set; }
//        #endregion

//        #region ILogging
//        public LogWrapper Log { get; set; }
//        #endregion
//    }
//}
