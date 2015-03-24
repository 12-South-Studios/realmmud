using System;

namespace Realm.Command.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface ICommandHelper
    {
        /// <summary>
        ///
        /// </summary>
        void RegisterCommands();

        /// <summary>
        ///
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        Action GetCommand(string var);
    }
}