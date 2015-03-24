using System;
using LuaInterface;
using Realm.Library.Lua;

namespace Realm.Server.Managers
{
    public interface ILuaManager
    {
        void RegisterLuaFunctions(Object aObject);
        bool Execute(string script, bool isFile);
        bool Execute(string script, string function, LuaTable e);
        void CreateEnumTable(string tableName, Type enumType);
        void ExecuteScript(LuaScript script);
    }
}
