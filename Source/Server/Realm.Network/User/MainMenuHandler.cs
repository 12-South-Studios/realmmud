using System;
using System.Collections.Generic;
using log4net;
using Ninject;
using Ninject.Parameters;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Database.Framework;
using Realm.Library.Lua;

namespace Realm.Network.User
{
    /// <summary>
    /// Handles the Main Menu
    /// </summary>
    public class MainMenuHandler : IMenuHandler
    {
        private readonly ILuaLoadBalancer _luaLoadBalancer;
        private readonly IDatabaseLoadBalancer _dbLoadBalancer;
        private readonly ILog _log;

        private const string ScriptFile = "OnClientEnter.lua";
        private readonly string _dataPath;
        private readonly IKernel _kernel;

        private readonly Dictionary<string, Action<GameUser, string>> _commands;

        /// <summary>
        ///
        /// </summary>
        /// <param name="luaLoadBalancer"></param>
        /// <param name="dbLoadBalancer"> </param>
        /// <param name="log"> </param>
        /// <param name="initAtom"> </param>
        public MainMenuHandler(ILuaLoadBalancer luaLoadBalancer, IDatabaseLoadBalancer dbLoadBalancer,
            ILog log, DictionaryAtom initAtom)
        {
            _luaLoadBalancer = luaLoadBalancer;
            _dbLoadBalancer = dbLoadBalancer;
            _log = log;
            _dataPath = initAtom.GetObject("DataPath").ToString();
            _kernel = (IKernel) initAtom.GetObject("Ninject.Kernel");

            _commands = new Dictionary<string, Action<GameUser, string>>
                            {
                                {"createaccount", Create},
                                {"connect", Login},
                                {"login", Login},
                                {"credits", Credits},
                                {"who", Who},
                                {"quit", Quit},
                                {"logout", Quit},
                                {"q", Quit}
                            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        public void SendMenu(GameUser user)
        {
            _luaLoadBalancer.ExecuteScript(new LuaScript
                                               {
                                                   Name = "MainMenu",
                                                   Path = _dataPath,
                                                   Script = ScriptFile,
                                                   IsFile = true
                                               });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        /// <param name="messageToEvaluate"></param>
        /// <returns></returns>
        public bool Execute(GameUser user, string messageToEvaluate)
        {
            bool handled = false;
            var verb = messageToEvaluate.FirstWord();

            if (string.IsNullOrEmpty(verb))
            {
                // TODO: Send "Do not understand" message
            }
            else if (_commands.ContainsKey(verb.ToLower()))
            {
                _commands[verb.ToLower()].Invoke(user, messageToEvaluate);
                handled = true;
            }
            else
            {
                // TODO: Send "Invalid menu command" message
            }

            return handled;
        }

        private DictionaryAtom _dataSet;

        private void Login(GameUser user, string message)
        {
            // Syntax: login/connect username password
            _dataSet = new DictionaryAtom();
            _dataSet.Set("Username", message.SecondWord());
            _dataSet.Set("Password", message.ThirdWord());
            _dataSet.Set("Message", message);
            _dataSet.Set("User", user);

            //var loader = new GameUserLoader(user, _dbLoadBalancer, _log);
            var loader = _kernel.Get<IGameUserLoader>(new Parameter("owner", user, false));
            var processor = new GameUserLoginProcessor((GameUserLoader)loader, string.Empty, 30, 3);
            processor.Execute(user, message.SecondWord(), message.ThirdWord(), OnLoginComplete);
        }

        private void OnLoginComplete(RealmEventArgs args)
        {
            if (args.HasValue("errors"))
            {
                // TODO: Handle a login error

            }


        }

        private void Create(GameUser user, string message)
        {
            // TODO: Execute playercreateaccount command
        }

        private void Who(GameUser user, string message)
        {
            // TODO: Execute playerwho command
        }

        private void Credits(GameUser user, string message)
        {
            // TOdO: Execute playercredits command
        }

        private void Quit(GameUser user, string message)
        {
            // TODO: Update the game state          _user.UserState = Globals.Globals.UserStateTypes.Quitting;
            // TODO: send text to the user object   user.SendText(Game.Instance.Properties.GetProperty<string>("quit"));
            user.TcpClient.Disconnect();
        }

        /*private static void LoginUser(GameUser user, string verb, string keyword)
        {
            CommandManager.Instance.Execute(user, verb, keyword);
        }

        private static void CreateUser(GameUser user)
        {
            CommandManager.Instance.Execute(user, "playercreateaccount");
        }

        private static void Who(GameUser user)
        {
            CommandManager.Instance.Execute(user, "playerwho");
        }

        private static void Credits(GameUser user)
        {
            //LuaManager.Instance.Execute("Credits.lua", true);
        }

        private static void Quit(GameUser user)
        {
            user.UserState = Globals.Globals.UserStateTypes.Quitting;
            user.SendText(Game.Instance.Properties.GetProperty<string>("quit"));
            user.TcpUser.Disconnect();
        }*/
    }
}