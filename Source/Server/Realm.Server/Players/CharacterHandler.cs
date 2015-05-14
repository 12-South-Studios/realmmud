//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Realm.Command;
//using Realm.Command.Interfaces;
//using Realm.Data;
//using Realm.Library.Common;
//using Realm.Server.Channels;
//using Realm.Server.Commands;
//using Realm.Server.Events;
//using Realm.Server.Interfaces;
//using Realm.Server.Managers;
//using Realm.Server.Pathfinding;
//using Realm.Server.Time;
//using log4net;

//namespace Realm.Server.Players
//{
//    public class CharacterHandler : ICharacterHandler, IManagerReference, ILogging
//    {
//        private readonly IGameUser _user;
//        private readonly Dictionary<long, CharacterData> _characters = new Dictionary<long, CharacterData>();

//        public CharacterHandler(IGameUser user)
//        {
//            _user = user;
//        }

//        public ICharacter Character { get; set; }

//        public IEnumerable<CharacterData> Characters
//        {
//            get { return _characters.Values; }
//        }

//        /// <summary>
//        /// Creates a new character as if a factory
//        /// </summary>
//        public static ICharacter CreateCharacter(IEntityManager entityManager, IGameUser user, long id, string name)
//        {
//            if (user.IsNull()) return null;
//            if (id <= 0 || string.IsNullOrEmpty(name)) return null;

//            var newChar = new Character(id, user);
//            newChar.Name = name;
//            entityManager.Register(newChar);
//            return newChar as ICharacter;
//        }

//        public bool LoadCharacters()
//        {
//            try
//            {
//                // TODO: Fix this
//                /*var characters = DatabaseManager.LiveContext.GetCharacters((int)_user.ID);
//                if (characters.IsNull())
//                {
//                    Log.ErrorFormat("No characters were returned for User {0}", _user.ID);
//                    CommandManager.ReportToCharacter("#error#", _user);
//                    return false; 
//                }

//                foreach (var charMap in characters)
//                {
//                    var character = DatabaseManager.LiveContext.GetCharacter(charMap.CharacterID);

//                    var lastLogin = charMap.LastLoginDate.IsNotNull()
//                                        ? charMap.LastLoginDate.Value.ToString()
//                                        : string.Empty;

//                    IDictionary<string, object> property = DatabaseManager.LiveContext.GetCharacterProperty(character.CharacterID, "Level");
//                    int level = 1;
//                    if (property.IsNotNull())
//                        level = Convert.ToInt32(property["Value"]);

//                    property = DatabaseManager.LiveContext.GetCharacterProperty(character.CharacterID, "Archetype");
//                    string archetype = "Citizen";
//                    if (property.IsNotNull())
//                        archetype = property["Value"].ToString();

//                    property = DatabaseManager.LiveContext.GetCharacterProperty(character.CharacterID, "Gender");
//                    string gender = "Male";
//                    if (property.IsNotNull())
//                        gender = property["Value"].ToString();

//                    property = DatabaseManager.LiveContext.GetCharacterProperty(character.CharacterID, "Race");
//                    string race = "Human";
//                    if (property.IsNotNull())
//                        race = property["Value"].ToString();

//                    var charData = new CharacterData
//                                       {
//                                           ID = charMap.CharacterID,
//                                           Name = character.Name,
//                                           LocationID = character.LocationID.GetValueOrDefault(0),
//                                           LastLogin = lastLogin,
//                                           Level = level,
//                                           Archetype = archetype,
//                                           Gender = gender,
//                                           Race = race
//                                       };

//                    _characters.Add(charMap.CharacterID, charData);
//                    Log.InfoFormat("User[{0}, {1}] added Character[{2}, {3}]", _user.ID, _user.Name, charData.ID, charData.Name);
//                }*/
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex);
//                return false;
//            }
//        }

//        public bool SelectCharacter(string name)
//        {
//            if (Character.IsNotNull()) return false;

//            CharacterData charData = _characters.Values.FirstOrDefault(data => data.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
//            if (charData.IsNull())
//            {
//                // TODO: Error
//                return false;
//            }
//            Character = CreateCharacter(EntityManager, _user, charData.ID, charData.Name);
//            if (Character.IsNull())
//            {
//                // TODO: Error
//                return false;
//            }

//            // TODO: Get Character dictionaryatom data
//            Character.OnInit();

//            bool error = !LoadCharacterFlags(charData.ID);
//            if (!LoadCharacterProperties(charData.ID))
//                error = true;
//            if (!Character.Channels.LoadChannels(charData.ID))
//                error = true;
//            if (LoadCharacterInventory(charData.ID))
//                error = true;
//            return error;
//        }

//        private bool LoadCharacterFlags(long characterId)
//        {
//            try
//            {
//                // TODO: Fix this
//                /*var flags = DatabaseManager.LiveContext.GetCharacterFlags(characterId);
//                if (flags.IsNull())
//                {
//                    Log.ErrorFormat("No flags returned for Character {0}", characterId);
//                    CommandManager.ReportToCharacter("#error#", _user);
//                    return false;
//                }

//                foreach (var flag in flags)
//                {
//                    Character.Flags.SetFlag(flag);

//                    Log.InfoFormat("Character[{0}, {1}] added Flag[{2}]",
//                        Character.ID, Character.Name, flag);
//                }*/
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex);
//                return false;
//            }
//        }
//        private bool LoadCharacterProperties(long characterId)
//        {
//            try
//            {
//                // TODO: Fix this
//                /*var properties = DatabaseManager.LiveContext.GetCharacterProperties(characterId);
//                if (properties.IsNull())
//                {
//                    Log.ErrorFormat("No properties were returned for Character {0}", characterId);
//                    CommandManager.ReportToCharacter("#error#", _user);
//                    return false; 
//                }

//                foreach (var prop in properties)
//                {
//                    Character.Properties.SetProperty(
//                        prop["Name"].ToString(),
//                        prop["Value"],
//                        Convert.ToBoolean(prop["IsPersistable"]),
//                        Convert.ToBoolean(prop["IsVolatile"]),
//                        Convert.ToBoolean(prop["IsVisible"]));
//                    Log.InfoFormat("Character[{0}, {1}] => SetProperty[{2}]", Character.ID, Character.Name, prop["Name"]);
//                }*/
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex);
//                return false;
//            }
//        }
//        private bool LoadCharacterInventory(long characterId)
//        {
//            return true;
//        }

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
