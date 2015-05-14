//// -----------------------------------------------------------------------
//// <copyright file="LuaHelper.cs" company="">
//// //     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// -----------------------------------------------------------------------

//using System;
//using LuaInterface;
//using Realm.Command;
//using Realm.Data;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Lua;
//using Realm.Library.Network;
//using Realm.Library.Patterns.Singleton;
//using Realm.Server.Channels;
//using Realm.Server.Commands;
//using Realm.Server.Events;
//using Realm.Server.Managers;
//using Realm.Server.NPC;
//using Realm.Server.Pathfinding;
//using Realm.Server.Players;
//using Realm.Server.Time;
//using Realm.Server.Zones;

//namespace Realm.Server
//{
//    public static class LuaHelper
//    {
//        /*[LuaFunction("MxpTag", "wraps the string in a mxptag", "string")]
//        public static string LuaMxpTag(string str)
//        {
//            return str.MxpTag();
//        }*/

//        [Obsolete("Zones are no longer loaded by file, but from the database")]
//        [LuaFunction("loadZone", "Loads a zone file", "Zone to load")]
//        public static bool LuaLoadZone(Zone zone)
//        {
//            //return zone.IsNotNull() && LuaManager.Instance.Execute(zone.Filename.ToLower(), true);
//            return false;
//        }

//        [LuaFunction("GetAppSetting", "Gets the data value of the app setting", "Setting name")]
//        public static string LuaGetAppSetting(string settingName)
//        {
//            return Game.Instance.GetStringConstant(settingName);
//        }

//        [LuaFunction("errorLog", "(deprecated) Logs text to the Error Channel", "Log Message")]
//        public static void LuaErrorLog(string str)
//        {
//            Game.Instance.Logger.Error(str);
//        }

//        [LuaFunction("playerLog", "(deprecated) Logs text to the Player Channel", "Log Message")]
//        public static void LuaPlayerLog(string str)
//        {
//            Game.Instance.Logger.Info("[Player]" + str);
//        }

//        [LuaFunction("systemLog", "(deprecated) Logs text to the System Channel", "Log Message")]
//        public static void LuaSystemLog(string str)
//        {
//            Game.Instance.Logger.Info("[System]" + str);
//        }

//        [LuaFunction("networkLog", "(deprecated) Logs text to the Network Channel", "Log Message")]
//        public static void LuaNetworkLog(string str)
//        {
//            Game.Instance.Logger.Info("[Network]" + str);
//        }

//        [LuaFunction("ExecuteCommand", "Attempts to execute a player command", "User that is executing the command", "The command to execute")]
//        public static void LuaExecuteCommand(GameUser oUser, string command)
//        {
//            Game.Instance.Properties.SetProperty("current user", oUser);
//            oUser.Properties.SetProperty("raw command", command);
//            oUser.Execute(command);
//        }

//        [LuaFunction("printString", "Prints the give message to the user", "Message Scope", "Message to send", "The Actor object", "The victim object", "The direct object", "the indirect object", "The Space")]
//        public static void LuaPrintString(Globals.Globals.MessageScopeTypes scope, string msg, IEntity actor, IEntity victim, object directObject, object indirectObject, IGameEntity Space)
//        {
//            CommandManager.Instance.Report(scope, msg, actor, victim, directObject, indirectObject, Space);
//        }

//        [LuaFunction("connectSpaces", "Connects two Spaces", "Source Space ID", "Destination Space ID", "Direction", "Keywords")]
//        public static bool LuaConnectSpaces(long sourceID, long destinationID, Globals.Globals.Directions dir, string keywords)
//        {
//            var sourceSpace = EntityManager.Instance.LuaGetConcrete(sourceID) as Space;
//            if (sourceSpace.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("Invalid Source Space[{0}]", sourceID);
//                return false;
//            }
//            var destSpace = EntityManager.Instance.LuaGetConcrete(destinationID) as Space;
//            if (destSpace.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("Invalid Destination Space[{0}]", destinationID);
//                return false;
//            }

//            var exit = sourceSpace.Portals.AddExit(Game.Instance.Logger, dir, destSpace, keywords);
//            //LuaManager.Instance.Lua.CreateTable("exit");
//            return exit;
//        }

//        [LuaFunction("createChatNode", "Creates a chat node", "number", "parent", "keywords", "text", "type")]
//        public static ConversationNode LuaCreateChatNode(int number, int parent, string keywords, string txt, int type)
//        {
//            var node = new ConversationNode(number, parent, keywords, txt, type);
//            Game.Instance.Logger.InfoFormat("Created new ConversationNode[{0}, {1}]", number, parent);
//            return node;
//        }

//        [LuaFunction("getCharacters", "Gets the characters for a user", "Lua Table", "User")]
//        public static LuaTable LuaGetCharacters(LuaTable aCharacters, GameUser user)
//        {
//            foreach (var charData in user.UserCharacters)
//            {
//                if (charData.IsNull()) continue;

//                /*var charTable = LuaManager.Instance.Lua.CreateTable(charData.Name);
//                charTable["character_id"] = charData.ID;
//                charTable["character_name"] = charData.Name;
//                charTable["last_login"] = string.IsNullOrEmpty(charData.LastLogin) ? "Never" : charData.LastLogin;
//                charTable["level"] = charData.Level;
//                charTable["archetype"] = charData.Archetype;
//                charTable["gender"] = charData.Gender;
//                charTable["race"] = charData.Race;
//                aCharacters[charData.ID] = charTable;*/
//            }
//            return aCharacters;
//        }

//        [LuaFunction("CreateCharacter", "Creates a new Character instance", "ID", "Name", "User Object")]
//        public static ICharacter LuaCreateCharacter(IGameUser user, long id, string name)
//        {
//            return CharacterHandler.CreateCharacter(EntityManager.Instance, user, id, name);
//        }

//        [LuaFunction("GetSingleton", "Retrieves a reference to a game singleton", "Name")]
//        public static ISingleton GetSingleton(string name)
//        {
//            switch (name.ToLower())
//            {
//                case "game":
//                    return Game.Instance;
//                case "channelmanager":
//                    return ChannelManager.Instance;
//                case "combatmanager":
//                    return CombatManager.Instance;
//                case "commandmanager":
//                    return CommandManager.Instance;
//                case "datamanager":
//                    return DataManager.Instance;
//                case "databasemanager":
//                    return DatabaseManager.Instance;
//                case "entitymanager":
//                    return EntityManager.Instance;
//                case "eventmanager":
//                    return EventManager.Instance;
//                case "helpmanager":
//                    return HelpManager.Instance;
//                case "luamanager":
//                    return LuaManager.Instance;
//                case "networkmanager":
//                    return NetworkManager.Instance;
//                case "pathmanager":
//                    return PathManager.Instance;
//                case "timemanager":
//                    return TimeManager.Instance;
//            }
//            return null;
//        }

//        /*
//        /// <summary>
//        /// Initializes a given enum into a Lua Table
//        /// </summary>
//        /// <param name="tableName">name of the table</param>
//        /// <param name="enumType">The enum type</param>
//        public void CreateEnumTable(string tableName, Type enumType)
//        {
//            var table = Lua.CreateTable(tableName);
//            foreach (var value in Enum.GetValues(enumType))
//                table[value.ToString()] = value;
//        }*/
//    }
//}
