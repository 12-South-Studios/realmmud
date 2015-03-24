-- COMMANDS.LUA
-- This is the commands data file
-- Revised: 2012.09.10
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("================== REALMMUD SETUP - MAIN MENU COMMANDS ==================");
newCommand = createNewCommand("playerquit", "PlayerQuit", "logout;quit;q", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.MainMenu);
command.this:AddUserState(GameUserState.CharacterMenu);
command.this:AddUserState(GameUserState.LoggedIn);

newCommand = createNewCommand("playerloginaccount", "PlayerLoginAccount", "login;connect", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.MainMenu);

newCommand = createNewCommand("playerwho", "PlayerWho", "who", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.MainMenu);
command.this:AddUserState(GameUserState.LoggedIn);

newCommand = createNewCommand("playercreateaccount", "PlayerCreateAccount", "newaccount;newacct", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.MainMenu); 

systemLog("================== REALMMUD SETUP - CHARACTER MENU COMMANDS ==================");
newCommand = createNewCommand("playerdeletecharacter", "DeleteCharacter", "deleteChar", LogAction.Always);
command.this = newCommand;
command.this:AddUserState(GameUserState.CharacterMenu);

newCommand = createNewCommand("playerlogincharacter", "SelectCharacter", "selectChar", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.CharacterMenu);

newCommand = createNewCommand("playercreatecharacter", "CreateCharacter", "createChar", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.CharacterMenu);

systemLog("================== REALMMUD SETUP - SPECIAL COMMANDS ==================");
newCommand = createNewCommand("playerchangepassword", "ChangePassword", "@changePass", LogAction.Never);
command.this = newCommand;
command.this:AddUserState(GameUserState.LoggedIn);


systemLog("=================== REALMMUD SETUP - ADMIN COMMANDS ===================");
newCommand = createNewCommand("adminshutdown", "@Shutdown", "@sh;@shutdown", LogAction.Always);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("adminsave", "@Save", "@save", LogAction.Always);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("adminexamine", "@Examine", "@examine;@exa", LogAction.Normal);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("adminteleport", "@Teleport", "@tel;@teleport;@t", LogAction.Normal);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("adminwhere", "@Where", "@wh;@where", LogAction.Normal);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("admindetail", "@Detail", "@details;@det", LogAction.Normal);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddRestriction("B");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("admincreate", "@Create", "@create;@cr", LogAction.Always);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddRestriction("B");
command.this:AddPosition(PositionType.Any);

newCommand = createNewCommand("adminspawn", "@Spawn", "@spawn;@sp", LogAction.Always);
command.this = newCommand;
command.this:AddRestriction("W");
command.this:AddRestriction("A");
command.this:AddRestriction("B");
command.this:AddPosition(PositionType.Any);


systemLog("=================== REALMMUD SETUP - PLAYER COMMANDS ===================");
newCommand = createCommand(51, "look", "look;l;exa;examine", LogAction.Never, "PlayerLook");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(53, "sit", "sit", LogAction.Never, "PlayerSit");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(54, "stand", "st;stand", LogAction.Never, "PlayerStand");
command.this = newCommand;
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Crouching);

newCommand = createCommand(55, "save", "save", LogAction.Normal, "PlayerSave");
command.this = newCommand;
command.this:AddPosition(PositionType.Any);

newCommand = createCommand(56, "time", "time", LogAction.Never, "PlayerTime");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(57, "help", "help", LogAction.Never, "PlayerHelp");
command.this = newCommand;
command.this:AddPosition(PositionType.Any);

createCommand(58, "score", "score;sc", LogAction.Never, "PlayerScore");
newCommand = createCommand(59, "chpass", "chpass;changepassword;changepass;chpassword;cpass", LogAction.Never, "PlayerChangePassword");
command.this = newCommand;
command.this:AddPosition(PositionType.Any);

newCommand = createCommand(60, "bind", "bind", LogAction.Normal, "PlayerBind");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

--newCommand = createCommand(61, "remove", "remove;rem", LogAction.Normal, "PlayerRemove");
--command.this = newCommand;
--command.this:AddPosition(PositionType.Standing);
--command.this:AddPosition(PositionType.Sitting);
--command.this:AddPosition(PositionType.Prone);
--command.this:AddPosition(PositionType.Flying);
--command.this:AddPosition(PositionType.Climbing);
--command.this:AddPosition(PositionType.Swimming);
--command.this:AddPosition(PositionType.Crawling);
--command.this:AddPosition(PositionType.Crouching);
--command.this:AddPosition(PositionType.Riding);

-- Combat Verbs
newCommand = createCommand(62, "kill", "kill;k;attack;att", LogAction.Normal, "PlayerKill");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crouching);

-- Crafting Verbs
newCommand = createCommand(63, "gather", "gather", LogAction.Normal, "PlayerGather");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);

newCommand = createCommand(64, "create", "create;cr", LogAction.Normal, "PlayerCreate");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(65, "learn", "learn;lrn", LogAction.Normal, "PlayerLearn");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(66, "unlearn", "unlearn;unlrn", LogAction.Normal, "PlayerUnlearn");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(67, "recipes", "recipes", LogAction.Normal, "PlayerRecipes");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

-- Recipe

-- Item Verbs
newCommand = createCommand(68, "drink", "drink;dr", LogAction.Normal, "PlayerDrink");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(69, "fill", "fill", LogAction.Normal, "PlayerFill");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(70, "put", "put", LogAction.Normal, "PlayerPut");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(71, "close", "close;cl", LogAction.Normal, "PlayerClose");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(72, "open", "open;op", LogAction.Normal, "PlayerOpen");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(73, "equipment", "eq;equipment", LogAction.Never, "PlayerEquipment");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(74, "inventory", "i;inv;inventory", LogAction.Never, "PlayerInventory");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(75, "take", "take;get", LogAction.Normal, "PlayerTake");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(76, "drop", "drop;dr", LogAction.Normal, "PlayerDrop");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(77, "equip", "wear;we;hold;wield;equip", LogAction.Normal, "PlayerEquip");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(78, "unequip", "unequip;uneq;ue", LogAction.Normal, "PlayerUnequip");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

-- Shop Verbs
newCommand = createCommand(79, "appraise", "appraise;appr", LogAction.Normal, "PlayerAppraise");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(80, "buy", "buy", LogAction.Normal, "PlayerBuy");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(81, "sell", "sell", LogAction.Normal, "PlayerSell");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

newCommand = createCommand(82, "greet", "greet;gr", LogAction.Normal, "PlayerGreet");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);

-- Social Verbs
newCommand = createCommand(83, "emote", "em;emote", LogAction.Never, "PlayerEmote");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(84, "say", "say", LogAction.Normal, "PlayerSay");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(85, "shout", "sh;shout", LogAction.Normal, "PlayerShout");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

newCommand = createCommand(86, "whisper", "wh;whisper", LogAction.Normal, "PlayerWhisper");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Sitting);
command.this:AddPosition(PositionType.Prone);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

-- Special
newCommand = createCommand(87, "move", "move", LogAction.Never, "PlayerMove");
command.this = newCommand;
command.this:AddPosition(PositionType.Standing);
command.this:AddPosition(PositionType.Flying);
command.this:AddPosition(PositionType.Climbing);
command.this:AddPosition(PositionType.Swimming);
command.this:AddPosition(PositionType.Crawling);
command.this:AddPosition(PositionType.Crouching);
command.this:AddPosition(PositionType.Riding);

-- EOF