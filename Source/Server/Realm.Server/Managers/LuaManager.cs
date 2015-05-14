using System;
using LuaInterface;
using Ninject;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Lua;
using Realm.Server.Properties;

namespace Realm.Server.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LuaManager : GameSingleton, ILuaManager, ILuaLoadBalancer
    {
        private string _dataPath;
        private LuaVirtualMachineContext _luaVmContext;
        private int _numberVMs;

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            Validation.IsNotNull(initAtom, "initAtom");

            _numberVMs = initAtom.GetInt("NumberLuaVMs");
            Validation.Validate<ArgumentOutOfRangeException>(_numberVMs >= 1 && _numberVMs <= Int32.MaxValue);

            _dataPath = initAtom.GetString("DataPath");

            Log.DebugFormat("{0} asked to initialize {1} LuaVMs.", GetType(), _numberVMs);

            var kernel = (IKernel)initAtom.GetObject("Ninject.Kernel");
            EventManager.RegisterListener(this, kernel.Get<IGame>(), typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            try
            {
                _luaVmContext = new LuaVirtualMachineContext(Log, _numberVMs, new LuaFunctionRepository());
                RegisterLuaFunctions(this);
                Log.InfoFormat("Initialized Lua VM Context with {0} VM objects.", _luaVmContext.VMCount);

                base.Instance_OnGameInitialize(args);
            }
            catch (Exception ex)
            {
                ex.Handle<InitializationException>(ExceptionHandlingOptions.RecordAndThrow, Log,
                                                   ErrorResources.ERR_FAIL_INITIALIZE_MANAGER, GetType());
            }
        }

        /// <summary>
        /// Wraps execution of a lua script so that the virtual machines can be load-balanced.
        /// </summary>
        /// <param name="script"></param>
        public void ExecuteScript(LuaScript script)
        {
            Validation.IsNotNull(script, "script");

            var vm = _luaVmContext.NextVM;
            if (vm.IsNull())
                throw new GeneralException("Failed to find a Virtual Machine for Script {0}", script.Name);

            script.Path = _dataPath;
            vm.ExecuteScript(script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aObject"></param>
        public void RegisterLuaFunctions(Object aObject)
        {
            Log.Info("Registering LuaFunctions for " + aObject);

            try
            {
                _luaVmContext.RegisterLuaFunctions(aObject);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Log);
            }
        }

        public bool Execute(string script, bool isFile)
        {
            throw new NotImplementedException();
        }
        public bool Execute(string script, string function, LuaTable e)
        {
            throw new NotImplementedException();
        }
        public void CreateEnumTable(string tableName, Type enumType)
        {
            throw new NotImplementedException();
        }
    }
}
