//using System;
//using System.Collections.Generic;
//using Realm.Library.Common;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Commands;
//using Realm.Server.Players;
//using Realm.Server.Properties;

//namespace Realm.Server.Factories
//{
//    public class GameCommandFactory : GameObjectFactory
//    {        
//        private readonly static Dictionary<string, Type> _commandTable = new Dictionary<string, Type>()
//            {
//                // Admin Commands
//                { "admincreate", typeof (AdminCreateCommand) },
//                { "admindetail", typeof(AdminDetailCommand) },
//                { "adminexamine", typeof(AdminExamineCommand) },
//                { "adminheal", typeof(AdminHealCommand) },
//                { "adminsave", typeof(AdminSaveCommand) },
//                { "adminsetattribute", typeof(AdminSetAttributeCommand) },
//                { "adminsetproperty", typeof(AdminSetPropertyCommand) },
//                { "adminshutdown", typeof(AdminShutdownCommand) },
//                { "adminspawn", typeof(AdminSpawnCommand) },
//                { "adminteleport", typeof(AdminTeleportCommand) },
//                { "adminwhere", typeof(AdminWhereCommand) },

//                // Main Menu Commands
//                { "playerquit", typeof(PlayerQuitCommand) },
//                { "playerloginaccount", typeof(LoginPlayerCommand) },
//                { "playercreateaccount", typeof(CreatePlayerCommand) },
//                { "playerwho", typeof(PlayerWhoCommand) },

//                // Character Menu Commands
//                { "playerdeletecharacter", typeof(DeleteCharacterCommand) },
//                { "playerchangepassword", typeof(PlayerChangePasswordCommand) },
//                { "playerlogincharacter", typeof(SelectCharacterCommand) },
//                { "playercreatecharacter", typeof(CreateCharacterCommand) },

//                // General Commands
//                { "playerhelp", typeof(PlayerHelpCommand) },
//                { "playersave", typeof(PlayerSaveCommand) },
//                { "playertime", typeof(PlayerTimeCommand) },
//                { "playerscore", typeof(PlayerScoreCommand) },
//                { "playerlook", typeof(PlayerLookCommand) },
//                { "playersit", typeof(PlayerSitCommand) },
//                { "playerstand", typeof(PlayerStandCommand) },
//                { "playerbind", typeof(PlayerBindCommand) },
//                { "playermove", typeof(PlayerMoveCommand) },
//                { "playersleep", typeof(PlayerSleepCommand) },
//                { "playerwake", typeof(PlayerWakeCommand) },

//                // Combat Commands
//                { "playerkill", typeof(PlayerKillCommand) },

//                // Crafting Commands
//                { "playercreate", typeof(PlayerCreateCommand) },
//                { "playerrecipes", typeof(PlayerRecipesCommand) },
//                { "playerlearn", typeof(PlayerLearnCommand) },
//                { "playerunlearn", typeof(PlayerUnearnCommand) },
//                { "playergather", typeof(PlayerGatherCommand) },

//                // Item Commands
//                { "playerinventory", typeof(PlayerInventoryCommand) },
//                { "playerequipment", typeof(PlayerEquipmentCommand) },
//                { "playerequip", typeof(PlayerEquipCommand) },
//                { "playerunequip", typeof(PlayerUnequipCommand) },
//                { "playertake", typeof(PlayerTakeCommand) },
//                { "playerdrop", typeof(PlayerDropCommand) },
//                { "playerput", typeof(PlayerPutCommand) },
//                { "playerfill", typeof(PlayerFillCommand) },
//                { "playerdrink", typeof(PlayerDrinkCommand) },
//                { "playeropen", typeof(PlayerOpenCommand) },
//                { "playerclose", typeof(PlayerCloseCommand) },

//                // Shop Commands
//                { "playergreet", typeof(PlayerGreetCommand) },
//                { "playerappraise", typeof(PlayerAppraiseCommand) },
//                { "playerbuy", typeof(PlayerBuyCommand) },
//                { "playersell", typeof(PlayerSellCommand) },

//                // Social Commands
//                { "playeremote", typeof(PlayerEmoteCommand) },
//                { "playersay", typeof(PlayerSayCommand) },
//                { "playershout", typeof(PlayerShoutCommand) },
//                { "playerwhisper", typeof(PlayerWhisperCommand) }
//            };

//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            Validation.IsNotNullOrEmpty(type, "type");
//            Validation.IsNotNull(args, "args");
//            Validation.Validate(args.Length >= 3, ErrorResources.ERR_INSUF_ARGUMENTS);
//            Validation.Validate(Convert.ToInt32(args[0]) >= 1);
//            Validation.IsNotNullOrEmpty(args[1].ToString(), "arg1");
//            Validation.IsNotNullOrEmpty(args[2].ToString(), "arg2");
//            Validation.IsNotNull(args[3], "arg3");

//            var id = Convert.ToInt32(args[0]);
//            var name = args[1].ToString();
//            var keywords = args[2].ToString();
//            var action = EnumerationExtensions.GetEnum<Globals.Globals.LogActionTypes>(args[3].ToString());

//            var obj = _commandTable.ContainsKey(type.ToLower())
//                ? _commandTable[type.ToLower()].Instantiate<GameCommand>(id, name, keywords, action)
//                : null;

//            if (obj.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_INSTANCE, GetType(), id, name);

//            // TODO: Add the GameCommand to something

//            Game.Instance.SetManagerReferences(obj);

//            return obj;
//        }

//        public override ICell CreateInstance(string type, params object[] args)
//        {
//            throw new NotImplementedException();
//        }

//        public override ICell CreateConcrete(string type, params object[] args)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
