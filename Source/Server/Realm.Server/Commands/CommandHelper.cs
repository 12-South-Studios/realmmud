using System;
using System.Collections.Generic;
using Realm.Library.Common;

namespace Realm.Server.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CommandHelper : IHelper<Action>
    {
        private readonly Dictionary<string, Action> _adminCommandTable = new Dictionary<string, Action>
                                                                             {
                                                                                 {"@heal", AdminHealCommand.Execute}
                                                                             };

        private readonly Dictionary<string, Action> _userCommandTable = new Dictionary<string, Action>
                                                                            {
                                                                                {
                                                                                    "createcharacter",
                                                                                    UserCreateCharacterCommand.Execute
                                                                                },
                                                                                {
                                                                                    "selectcharacter",
                                                                                    UserSelectCharacterCommand.Execute
                                                                                },
                                                                                {
                                                                                    "createuser",
                                                                                    UserCreatePlayerCommand.Execute
                                                                                },
                                                                                {
                                                                                    "deletecharacter",
                                                                                    UserDeleteCharacterCommand.Execute
                                                                                }
                                                                            };

        private readonly Dictionary<string, Action> _playerCommandTable = new Dictionary<string, Action>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Action Get(string key)
        {
            var command = _adminCommandTable.ContainsKey(key) ? _adminCommandTable[key] : null;
            if (command.IsNull())
                command = _userCommandTable.ContainsKey(key) ? _userCommandTable[key] : null;
            if (command.IsNull())
                command = _playerCommandTable.ContainsKey(key) ? _playerCommandTable[key] : null;
            return command;
        }
    }
}