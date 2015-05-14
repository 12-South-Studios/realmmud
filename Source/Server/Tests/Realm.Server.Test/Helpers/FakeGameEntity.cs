//using System;
//using log4net;
//using Realm.Library.Common;
//using Realm.Library.Common.Data;
//using Realm.Server.Channels;
//using Realm.Server.Commands;
//using Realm.Server.Contexts;
//using Realm.Server.Database;
//using Realm.Server.Entities;
//using Realm.Server.Events;
//using Realm.Server.Managers;
//using Realm.Server.Pathfinding;
//using Realm.Server.Players;
//using Realm.Server.Time;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Helpers
//{
//    public class FakeGameEntity : FakeEntity, IGameEntity
//    {
//        public string Description { get; set; }
//        public string LongName { get; set; }
//        public string PluralName { get; set; }
//        public int Value { get; set; }
//        public IGameEntity Location { get; set; }
//        public Zone MyZone { get; private set; }
//        public Globals.Globals.SizeTypes Size { get; set; }
//        public int Access { get; set; }

//        public bool Is(Globals.Globals.SystemTypes aType)
//        {
//            return true;
//        }

//        public bool HasMudProg(Type eventType)
//        {
//            return true;
//        }

//        public bool ExecuteMudProg(Type eventType)
//        {
//            return true;
//        }

//        public void OnInit()
//        {
//            // do nothing
//        }

//        public void OnInitHandlers()
//        {
//            throw new NotImplementedException();
//        }

//        public void OnInit(DictionaryAtom def)
//        {
//            throw new NotImplementedException();
//        }

//        public void OnInitContexts()
//        {
//            // do nothing
//        }

//        public IPropertyContext Properties { get; set; }
//        public IFlagContext Flags { get; set; }
//        public IBitContext Bits { get; set; }
//        public ITagContext Tags { get; set; }
//        public IContentsHandler Contents { get; set; }
//        public IMudProgHandler MudProgs { get; set; }

//        public object GetProperty(string aName)
//        {
//            return null;
//        }
//        public string GetStringProperty(string aName)
//        {
//            return string.Empty;
//        }
//        public int GetIntProperty(string aName)
//        {
//            return 0;
//        }
//        public bool GetBoolProperty(string aName)
//        {
//            return false;
//        }
//        public long GetLongProperty(string aName)
//        {
//            return 0;
//        }
//        public double GetRealProperty(string aName)
//        {
//            return 0.0f;
//        }

//        public IDataManager DataManager { get; set; }
//        public IEntityManager EntityManager { get; set; }
//        public ICommandManager CommandManager { get; set; }
//        public IEventManager EventManager { get; set; }
//        public ILuaManager LuaManager { get; set; }
//        public LogWrapper Log { get; set; }
//        public IDatabaseManager DatabaseManager { get; set; }
//        public ICombatManager CombatManager { get; set; }
//        public IPathManager PathManager { get; set; }
//        public IHelpManager HelpManager { get; set; }
//        public ITimeManager TimeManager { get; set; }
//        public INetworkManager NetworkManager { get; set; }
//        public IChannelManager ChannelManager { get; set; }
//        public IGame Game { get; set; }
//    }
//}
