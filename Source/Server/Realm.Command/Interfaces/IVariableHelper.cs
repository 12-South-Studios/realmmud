using System;

namespace Realm.Command.Interfaces
{
    public interface IVariableHelper
    {
        void RegisterVariables();
        Delegate GetDelegate(string var);
        int Count { get; }
    }
}