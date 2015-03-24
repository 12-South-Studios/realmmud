-- STRINGS.LUA
-- This is the strings data file
-- Revised: 2012.03.06
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - STATIC STRINGS ===================");
setGameProperty("quit", "Thank you for playing!  Good-bye.");

-- Basic Command Feedback
setGameProperty("not_authorized", "You are not authorized to execute that command.");
setGameProperty("not_understand", "I do not understand you...");
setGameProperty("nothing_here", "There is nothing with that name here.");
setGameProperty("no_object", "What did you want to act upon?");
setGameProperty("not_in_Space", "$N is not in the same Space as you.");
setGameProperty("no_item", "The item cannot be found!");
setGameProperty("no_mob", "The mob cannot be found!");
setGameProperty("not_container", "$o is not a container.");
setGameProperty("nothing", "Nothing");
setGameProperty("cant_do_that", "You can't do that!");
setGameProperty("not_takeable", "Cannot be picked up.");
setGameProperty("noone_here", "You don't see anyone by that name here.");
setGameProperty("not_functional", "This command is not functional yet.");
setGameProperty("error", "The game encountered an error.  Please notify an Administrator.");

-- Admin Commands
setGameProperty("admin_not_item", "$o is not an item.");
setGameProperty("admin_not_mob", "$o is not a mob.");
setGameProperty("admin_create_self", "You place $o into the Space.");
setGameProperty("admin_create_other", "$n places $o into the Space.");
setGameProperty("admin_create_inv", "You create $o into inventory.");
setGameProperty("admin_spawn_self", "You spawn $o into the Space.");
setGameProperty("admin_detail_off", "Admin Details disabled.");
setGameProperty("admin_detail_on", "Admin Details enabled.");
setGameProperty("admin_not_entity", "That is not a valid Entity ID.");
setGameProperty("admin_monitor_on", "You are now monitoring mob #%t.");
setGameProperty("admin_monitor_off", "You are no longer monitoring mob #%t.");
setGameProperty("cannot_monitor", "You cannot monitor this object.");
setGameProperty("admin_save", "$n initiated a MUD-wide character save.");
setGameProperty("admin_save_self", "$N character data successfully saved at %s.");
setGameProperty("admin_save_target", "$n character data successfully saved at %s.");
setGameProperty("admin_save_not_found", "Character '%s' not found.");
setGameProperty("admin_save_other", "$N character data successfully saved at %s.");
setGameProperty("tel_invalid_dest", "You must enter a destination to teleport to!");
setGameProperty("tel_cannot_enter", "The destination you have chosen is restricted and you cannot enter!");
setGameProperty("where_no_char", "No player by that name found!  Check the name and verify the player is online.");
setGameProperty("where_not_player", "%s is not a player.");
setGameProperty("admin_where", "Player ($N, $I) is currently in Space ($o, %D).");
setGameProperty("datadump_begin", "Beginning DataDump of Game Data. %d entities. %S.");
setGameProperty("datadump_save", "Completed DataDump of Game Data.  %s. %S.");

-- Bind
setGameProperty("Space_not_shrine", "This Space is not a shrine and cannot be bound to.");
setGameProperty("Space_bind_self", "You bind yourself to $N.");
setGameProperty("cannot_bind_state", "You cannot bind yourself to a shrine in your current state.");

-- Look
setGameProperty("look_dark", "You look around, but it is dark...");
setGameProperty("you_look_at", "You look at $N...");
setGameProperty("looks_at_you", "$n takes a good long look at you.");
setGameProperty("look_dir", "You look to the $d...");
setGameProperty("look_dir_updown", "Looking $d you see '$O'.");
setGameProperty("look_dir_other", "To the $d you see '$O'.");
setGameProperty("look_npc_item_self", "You look at $N's $o...");
setGameProperty("look_npc_item_other", "$n looks at $N's $o.");
setGameProperty("look_item_shop", "You examine the $o in $N's shop...");
setGameProperty("look_item_formula", "You examine $o...");
setGameProperty("look_item_self", "You look at $o...");
setGameProperty("look_item_other", "$n looks at $o.");

-- Move
setGameProperty("cannot_move", "You cannot move because you are %s.");
setGameProperty("move_self", "You $y $d.");
setGameProperty("move_other", "$n $ys to the $d.");
setGameProperty("arrive_other", "$n $ys from the $D.");
setGameProperty("cannot_move_fighting", "The only way to turn from a fight is to FLEE!");
setGameProperty("cannot_move_dead", "You can't move... you're DEAD!");
setGameProperty("cannot_move_noexits", "There are no exits in this Space!");
setGameProperty("cannot_move_position", "You are in no position to move!");
setGameProperty("cannot_move_nodir", "You must supply a valid direction!");
setGameProperty("cannot_move_dir", "You can't move in that direction!");
setGameProperty("cannot_move_notallow", "You aren't allowed to enter there!");
setGameProperty("cannot_move_insufstamina", "You do not have sufficient stamina to move there.");
setGameProperty("cannot_move_terrain", "You cannot $y to the $d.");

-- Sit/Stand
setGameProperty("already_sitting", "You are already sitting.");
setGameProperty("cannot_sit", "You are $p!  You cannot sit from this position.");
setGameProperty("sit_self", "You sit down to rest.");
setGameProperty("sit_other", "$n sits.");
setGameProperty("already_standing", "You are already standing.");
setGameProperty("cannot_stand", "You cannot stand from this position.");
setGameProperty("stand_self", "You stand up.");
setGameProperty("stand_other", "$n stands.");

-- Open/Close
setGameProperty("no_door", "You see no door to the %s.");
setGameProperty("door_already_closed", "The %s is already closed.");
setGameProperty("door_already_open", "The %s is already open.");
setGameProperty("door_broken", "The %s is broken and cannot be acted upon.");
setGameProperty("door_close_self", "You close the %s.");
setGameProperty("door_open_self", "You open the %s.");
setGameProperty("door_close_other", "$n closes the %s.");
setGameProperty("door_open_other", "$n opens the %s.");
setGameProperty("item_cannot_close", "$o cannot be closed.");
setGameProperty("item_cannot_open", "$o cannot be opened.");
setGameProperty("item_already_closed", "$o is already closed.");
setGameProperty("item_already_open", "$o is already open.");
setGameProperty("item_close_self", "You close $t.");
setGameProperty("item_open_self", "You open $t.");
setGameProperty("item_close_other", "$n closes $t.");
setGameProperty("item_open_other", "$n opens $t.");

-- Inventory/Equipment
setGameProperty("wearing", "You are wearing:");
setGameProperty("holding", "You are holding:");
setGameProperty("carrying", "You are carrying %c.");

-- Take/Drop/Put
setGameProperty("item_not_takeable", "The $o cannot be picked up.");
setGameProperty("item_closed", "$o is closed.");
setGameProperty("take_item_stack_container_self", "You get %q $q out of $a $O.");
setGameProperty("take_item_stack_container_other", "$n gets %q $q out of $a $O.");
setGameProperty("take_item_container_self", "You get $o out of $a $O.");
setGameProperty("take_item_container_other", "$n gets $o out of $a $O.");
setGameProperty("take_item_stack_self", "You pick %q $q up off the ground.");
setGameProperty("take_item_stack_other", "$n picks %q $q up off the ground.");
setGameProperty("take_item_self", "You pick $o up off the ground.");
setGameProperty("take_item_other", "$n picks $o up off the ground.");
setGameProperty("drop_item_stack_self", "You drop %q $q.");
setGameProperty("drop_item_stack_other", "$n drops %q $q.");
setGameProperty("drop_item_self", "You drop $o.");
setGameProperty("drop_item_other", "$n drops $o.");
setGameProperty("item_too_big", "$o is too big to fit into $O.");
setGameProperty("container_full", "$o is already holding as much as it can hold.");
setGameProperty("put_item_self", "You put $o into $O.");
setGameProperty("put_item_other", "$n puts $o into $O.");

-- Equip/Unequip
setGameProperty("cannot_wear", "You cannot wear $t.");
setGameProperty("unable_wear", "You are unable to wear $t.");
setGameProperty("wear_2h_self", "You grasp $t with both hands.");
setGameProperty("wear_2h_other", "$n grasps $t with both hands.");
setGameProperty("wear_left_self", "You grasp $t in your left hand.");
setGameProperty("wear_left_other", "$n grasps $t in $s left hand.");
setGameProperty("wear_right_self", "You grasp $t in your right hand.");
setGameProperty("wear_right_other", "$n grasps $t in $s right hand.");
setGameProperty("wear_loc_self", "You wear $t on your $w.");
setGameProperty("wear_loc_other", "$n wears $t on $s $w.");
setGameProperty("not_wearing", "You aren't wearing anything by that name.");
setGameProperty("cannot_remove", "You are unable to remove $t.");
setGameProperty("remove_armor_self", "You take off $t.");
setGameProperty("remove_armor_other", "$n takes off $t.");
setGameProperty("remove_weapon_self", "You sheathe $t.");
setGameProperty("remove_weapon_other", "$n sheathes $t.");
setGameProperty("remove_item_self", "You remove $t.");
setGameProperty("remove_item_other", "$n removes $t.");

-- Fill
setGameProperty("not_dcon_target", "You can't put any type of liquid into $t.");
setGameProperty("not_dcon_source", "$t does not hold any type of liquid.");
setGameProperty("dcon_full", "$t is already full.");
setGameProperty("dcon_empty", "$t is empty.");
setGameProperty("dcon_cannot_mix", "You can't mix two different liquids together (%s and %S).");
setGameProperty("dcon_fill_infinite_self", "You fill $N with %s from $o.");
setGameProperty("dcon_fill_infinite_other", "$n fills $N with %s from $o.");
setGameProperty("dcon_empty_source_self", "You fill $o with the contents of $O.");
setGameProperty("dcon_empty_source_other", "$n fills $o with the contents of $O.");
setGameProperty("dcon_fill_target_self", "You empty the contents of $o into $O.");
setGameProperty("dcon_fill_target_other", "$n empties the contents of $o into $O.");
setGameProperty("dcon_fill_self", "You fill $N with %s from $o.");
setGameProperty("dcon_fill_other", "$n fills $N with %s from $o.");

-- Drink
setGameProperty("cannot_drink", "You can't drink from $t.");
setGameProperty("too_satiated", "You are too satiated to drink any more.");
setGameProperty("drink_remainder_self", "You drink the remaining contents of $t.");
setGameProperty("drink_remainder_other", "$n drinks the remaining contents of $t.");
setGameProperty("drink_self", "You take a drink of %S from $t.");
setGameProperty("drink_other", "$n takes a drink of %S from $t.");

-- Greet/Buy/Sell/Appraise
setGameProperty("no_greet", "Who did you want to greet?");
setGameProperty("cannot_greet_self", "You can't greet yourself!");
setGameProperty("cannot_greet_player", "You can't <greet> other players!");
setGameProperty("greet_not_merchant", "$N is not a merchant and cannot be greeted.");
setGameProperty("must_greet", "You must greet a shopkeeper first.");
setGameProperty("buy_self", "You hand $N some coins and $E hands you $o.");
setGameProperty("buy_other", "$n purchases $o from $N.");
setGameProperty("sell_self", "$N hands you some coins and you hand $o to $M.");
setGameProperty("sell_other", "$N purchases $o from $n.");

-- Say
setGameProperty("say_what", "What did you want to say?");
setGameProperty("say_self", "You say, \"%s\"");
setGameProperty("say_other", "$n says, \"%s\"");
setGameProperty("cannot_speak_self", "You cannot speak to yourself.");
setGameProperty("say_target_self", "You say to $N, \"%s\"");
setGameProperty("say_target_target", "$N says to you, \"%s\"");
setGameProperty("say_target_other", "$n says to $N, \"%s\"");
setGameProperty("cannot_speak_mob", "You cannot speak to $N.");

-- Whisper
setGameProperty("whisper_what", "What did you want to whisper?");
setGameProperty("whisper_noone_self", "You mutter under your breath to no one in particular.");
setGameProperty("whisper_noone_other", "$n mutters under $s breath to no one in particular.");
setGameProperty("cannot_whisper_self", "You cannot whisper to yourself.");
setGameProperty("whisper_target_self", "You whisper to $N, \"%s\"");
setGameProperty("whisper_target_target", "$N whispers to you, \"%s\"");
setGameProperty("whisper_target_other","$n whispers something to $N.");
setGameProperty("cannot_whisper_mob", "You cannot whisper to $N.");

-- Shout
setGameProperty("shout_what", "What did you want to shout?");
setGameProperty("shout_self", "You shout, \"%s\"");
setGameProperty("shout_other", "$n shouts, \"%s\"");

-- Emote
setGameProperty("emote_what", "What did you want to emote?");
setGameProperty("emote_roll", "You may not use emote to falsify the results of a ROLL command. Your attempt has been logged.");
setGameProperty("emote_self", "You emote, \"%s\"");
setGameProperty("emote_other", "$n %s");

-- Create
setGameProperty("no_recipe", "You possess no recipe for this product!");
setGameProperty("no_machine", "You do not see $a here.");
setGameProperty("no_tool", "You do not have $a equipped.");
setGameProperty("insuf_skill", "You do not possess the requisite skill for this action.");
setGameProperty("insuf_resource", "You are not carrying any $q.");
setGameProperty("create_self", "You create %q $q.");
setGameProperty("create_other", "$n creates %q $q.");
setGameProperty("create_xp", "You gain %d experience for your %S skill.");

-- Gather
setGameProperty("not_resource", "$o is not a resource node.");
setGameProperty("not_holding_tool", "You aren't holding anything!");
setGameProperty("not_tool", "$o is not a tool.");
setGameProperty("cannot_gather_tool", "$o cannot be used to gather from $O.");
setGameProperty("cannot_gather", "You are unable to gather from $o at this time.");
setGameProperty("gather_self", "You gather %t $q from $O.");
setGameProperty("gather_single_self", "You gather 1 $o from $O.");
setGameProperty("gather_other", "$n gathers %t $q from $O.");
setGameProperty("gather_single_other", "$n gathers 1 $o from $O.");

-- Learn/Unlearn/Recipes
setGameProperty("cannot_learn", "You can't learn that!");
setGameProperty("already_know_recipe", "You already know this recipe!");
setGameProperty("learn_self", "You learn $o.");
setGameProperty("learn_other", "$n learns $o.");
setGameProperty("no_recipe", "There is no such recipe.");
setGameProperty("dont_know_recipe", "You don't know that recipe!");
setGameProperty("unlearn_self", "You unlearn $o.");
setGameProperty("unlearn_other", "$n unlearns $o.");
setGameProperty("recipes", "You have memorized:");

-- Kill
setGameProperty("no_weapon", "You have no weapon equipped.");
setGameProperty("not_weapon", "$o is not a weapon.");
setGameProperty("cannot_attack_self", "You can't attack yourself!");
setGameProperty("attack_with_what", "What are you using to attack with?");
setGameProperty("cannot_attack_postdelay", "You cannot use this ability yet!");
setGameProperty("cannot_attack_safe", "You cannot attack while inside a SAFE area.");
setGameProperty("attack_self", "You attack $N.");
setGameProperty("attack_target", "$N attacks you.");
setGameProperty("attack_other", "$n attacks $N.");
setGameProperty("attack_miss_self", "You swing at $N and miss.");
setGameProperty("attack_miss_target", "$N swings at you and misses.");
setGameProperty("attack_miss_other", "$n swings at $N and misses.");
setGameProperty("attack_dodge_self", "You swing at $N, but $E dodges!");
setGameProperty("attack_dodge_target", "$N swings at you, but you dodge!");
setGameProperty("attack_dodge_other", "$n swings at $N, but $E dodges!");
setGameProperty("attack_parry_self", "You swing at $N, but $E parries the attack!");
setGameProperty("attack_parry_target", "$N swings at you, but you parry the attack!");
setGameProperty("attack_parry_other", "$n swings at $N, but $E parries the attack!");
setGameProperty("attack_block_self", "You swing at $N, but $E blocks the attack with $S shield!");
setGameProperty("attack_block_target", "$N swings at you, but you block the attack with your shield!");
setGameProperty("attack_block_other", "$n swings at $N, but $E blocks the attack with $S shield!");
setGameProperty("attack_devastate_self", "You swing at $N and score a mighty hit on $S %s ($G)!");
setGameProperty("attack_devastate_target", "$N swings at you and scores a mighty hit on your %s ($G)!");
setGameProperty("attack_devastate_other", "$n swings at $N and scores a mighty hit on $S %s ($G)!");
setGameProperty("attack_devastate_resist_self", "You swing at $N and score a mighty hit on $S %s, but $E resists ($G)!");
setGameProperty("attack_devastate_resist_target", "$N swings at you and scores a mighty hit on your %s, but you resist ($G)!");
setGameProperty("attack_devastate_resist_other", "$n swings at $N and scores a mighty hit on $S %s, but $E resists ($G)!");
setGameProperty("attack_glance_self", "You swing at $N and score a glancing blow on $S %s ($G)!");
setGameProperty("attack_glance_target", "$N swings at you and scores a glancing blow on  your %s ($G)!");
setGameProperty("attack_glance_other", "$n swings at $N and scores a glancing blow on $S %s ($G)!");
setGameProperty("attack_glance_resist_self", "You swing at $N and score a glancing blow on $S %s, but $E resists ($G)!");
setGameProperty("attack_glance_resist_target", "$N swings at you and scores a glancing blow on your %s, but you resist ($G)!");
setGameProperty("attack_glance_resist_other", "$n swings at $N and scores a glancing blow on $S %s, but $E resists ($G)!");
setGameProperty("attack_hit_self", "You swing at $N and hit $S %s ($G)!");
setGameProperty("attack_hit_target", "$N swings at you and hits your %s ($G)!");
setGameProperty("attack_hit_other", "$n swings at $N and hits $S %s ($G)!");
setGameProperty("attack_hit_resist_self", "You swing at $N and hit $S %s, but $E resists ($G)!");
setGameProperty("attack_hit_resist_target", "$N swings at you and hits your %s, but you resist ($G)!");
setGameProperty("attack_hit_resist_other", "$n swings at $N and hits $S %s, but $E resists ($G)!");

-- Container / Drink Container
setGameProperty("con_closed", "The container is closed.");
setGameProperty("drink_con_infinite", "Container is overflowing with %s.");
setGameProperty("drink_con_100", "Container is full of %s.");
setGameProperty("drink_con_75", "Container is mostly full of %s.");
setGameProperty("drink_con_50", "Container is half-full of %s.");
setGameProperty("drink_con_25", "Container is barely full of %s.");
setGameProperty("drink_con_less_25", "Container is mostly empty of %s.");
setGameProperty("drink_con_0", "Container is empty.");
setGameProperty("con_contents", "Inside the container you see:");

-- Other
setGameProperty("quit_other", "$n just left the game.");
setGameProperty("login_other", "$n has entered the game.");
setGameProperty("save", "Character data successfully saved at %s.");				
setGameProperty("no_password", "A new password was not supplied.");
setGameProperty("password_short", "Your password is too short. Passwords must be at least #minimumPasswordLength# characters long.");
setGameProperty("password_long", "Your password is too long. Passwords must not be more than #maximumPasswordLength# characters long.");
setGameProperty("password_fail", "Unable to change your password.");
setGameProperty("password_success", "Your password has been successfully changed.");
setGameProperty("username_long", "Usernames must be shorter than #maximumUsernameLength# characters.");
setGameProperty("invalid_login", "Invalid login.  Try again.");
setGameProperty("invalid_menu", "Invalid menu option.  Try again.");
setGameProperty("invalid_password", "Invalid password. Unable to change your password.");

-- Help
setGameProperty("help_no_default", "No default help entry found.  Notify an Administrator.");
setGameProperty("help_no_entry", "There is no such entry in the help files.");
setGameProperty("help_entry", "%s\r\n%S");

-- Channels
setGameProperty("channel_noinput", "Channel '$o' does not accept input.");
setGameProperty("channel_nouser", "[$o] %S");
setGameProperty("channel_emote_self", "[$o] You %S");
setGameProperty("channel_say_self", "[$o] You say, \"%S\"");
setGameProperty("channel_emote_other", "[$o] $n %S");
setGameProperty("channel_say_other", "[$o] $n says, \"%S\"");


--========== MERCHANT STATEMENTS ==========
--=========================================
systemLog("=================== REALMMUD SETUP - MERCHANT STATEMENTS ===================");
setEnumGameProperty(MerchantStatementType.MerchantWelcome, "Welcome to my shop, $n!");
setEnumGameProperty(MerchantStatementType.MerchantNothingForSale, "I have nothing for sale at this time.");
setEnumGameProperty(MerchantStatementType.MerchantStuffForSale, "I have ");
setEnumGameProperty(MerchantStatementType.BuyNoKeyword, "$n, what did you want to buy?");
setEnumGameProperty(MerchantStatementType.BuyNoItem, "I do not have anything like that for sale.");
setEnumGameProperty(MerchantStatementType.BuyCannotAfford, "$n, you cannot afford to purchase $a.");
setEnumGameProperty(MerchantStatementType.BuyComplete, "$n, thank you.  It has been a pleasure doing business with you.");
setEnumGameProperty(MerchantStatementType.SellNoKeyword, "$n, what did you want to sell?");
setEnumGameProperty(MerchantStatementType.SellNoItem, "You don't have anything by that name.");
setEnumGameProperty(MerchantStatementType.SellNoInterest, "$n, I have no interest in things like $a.");
setEnumGameProperty(MerchantStatementType.SellCannotAfford, "$n, I cannot afford to purchase $a.");
setEnumGameProperty(MerchantStatementType.SellComplete, "$n, thank you.  It has been a pleasure doing business with you.");
setEnumGameProperty(MerchantStatementType.AppraiseNoKeyword, "$n, what did you want to have appraised?");
setEnumGameProperty(MerchantStatementType.AppraiseNoItem, "You don't have anything by that name.");
setEnumGameProperty(MerchantStatementType.AppraiseNoInterest, "$n, I have no interest in things like $a.");
setEnumGameProperty(MerchantStatementType.AppraiseComplete, "$n, I would be willing to buy $a from you for %c. What do you say?");
setEnumGameProperty(MerchantStatementType.Restock, "$n begins restocking $s shelves.");


--================ STATS ==================
--=========================================
systemLog("================= REALMMUD SETUP - STAT DESCRIPTIONS =================");
setEnumGameProperty(Statistic.Dexterity, "A Mental Statistic, Dexterity represents mental quickness, how quickly a player or monster can think of solutions for puzzles or problems.");
setEnumGameProperty(Statistic.Vitality, "A mental statistic, Vitality represents mental strength, how strong of personality the player or monster is.");
setEnumGameProperty(Statistic.Willpower, "A mental statistic, Willpower represents mental resistance, which is a measure of how resilient the player or monster’s mind is.");
setEnumGameProperty(Statistic.Agility, "A physical statistic, Agility represents physical quickness which is a measure of how quickly the player or monster can move and react to outside stimuli.");
setEnumGameProperty(Statistic.Endurance, "A physical statistic, Endurance represents physical resistance, a measure of how resilient the player or monster is to physical damage.");
setEnumGameProperty(Statistic.Strength, "A physical statistic, Strength represents physical power, which is a measure of how powerful a player or monster is.  Physical strength is typically equated with large muscles, heavy lifting, and hard punches.");
setEnumGameProperty(Statistic.Luck, "A generic statistic, Luck is a measure of a player or monster’s random chance.  Luck can swing skill checks one way or another, it can tip the scales of a tie, but a player has very little control over it.");
setEnumGameProperty(Statistic.Spirit, "A generic statistic, Spirit represents spiritual strength.  Like Strength is to the physical and Vitality is to the mental, Spirit is to the Spiritual.");
setEnumGameProperty(Statistic.Defense, "A measure of physical defense or resistance, Defense measures the player or monster’s ability to defend (to prevent, to stop) incoming attacks of a physical nature.  Defense is an amalgam of Endurance and Agility.");
setEnumGameProperty(Statistic.Faith, "A measure of spiritual defense or resistance, Faith measures the player or monster’s ability to defend incoming attacks of a spiritual nature.  Faith is an amalgam of Spirit and Willpower.");
setEnumGameProperty(Statistic.Fortitude, "A measure of mental defense or resistance, Fortitude measures the player or monster’s ability to defend incoming attacks of a mental nature.  Fortitude is an amalgam of Willpower and Dexterity.");
setEnumGameProperty(Statistic.Warding, "A measure of magical defense or resistance, Warding measures the player or monster’s ability to defend incoming attacks of a magical nature.  Warding is an amalgam of Willpower and Endurance.");
setEnumGameProperty(Statistic.Health, "Health is a measure of a player or monsters physical condition.  If health drops to zero then the player or monster falls unconscious and will soon (if unaided) die. Health is an amalgam of Endurance and Willpower.");
setEnumGameProperty(Statistic.Mana, "Mana is a measure of a player or monster’s capability to focus mentally and cast spells.  Every spell has an associated mana cost and so long as a player has sufficient mana then that spell may be attempted.  If mana falls to zero then no spells may be cast.  Mana is an amalgam of Vitality and Willpower.");
setEnumGameProperty(Statistic.Stamina, "Stamina is a measure of a player or monster’s capability to perform actions physically (represents exhaustion and physical exertion).  Every ability has an associated stamina cost and as long as a player has sufficient stamina then that action or ability may be attempted.  If stamina falls to zero then no actions may be attempted.  Stamina is an amalgam of Endurance and Strength.");
setEnumGameProperty(Statistic.Dodge, "Dodge represents the player or monster’s ability to evade incoming attacks and avoid the attack altogether.  Dodge is an amalgam of Agility and Dexterity.");
setEnumGameProperty(Statistic.Block, "Block represents the player or monster’s ability to block incoming attacks and in so doing reduce the amount of damage taken.  This is typically only available with a shield, but some weapons or monsters might possess the capability to use Block in other situations.  Block is an amalgam of Strength and Endurance.");
setEnumGameProperty(Statistic.Parry, "Parry represents the player or monster’s ability to parry or deflect incoming weapon attacks using a weapon and in so doing reduce the amount of damage taken.  To use this skill, the weapon itself must allow for parrying.  Parry is an amalgam of Agility and Strength.");


--=============== ELEMENTS ================
--=========================================
systemLog("================= REALMMUD SETUP - ELEMENT DESCRIPTIONS =================");


--=============== DEITIES =================
--=========================================
systemLog("================= REALMMUD SETUP - DEITY DESCRIPTIONS =================");


-- EOF