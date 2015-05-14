using System;

namespace Realm.Command.Interfaces
{
    public interface ICommandHelper
    {
        void RegisterCommands();
        Action GetCommand(string var);
    }
}