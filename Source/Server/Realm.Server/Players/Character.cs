using System.Collections.Generic;
using System.Linq;
using Realm.Communication;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity.Entities;
using Realm.Entity.Entities.Interfaces;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Objects;
using Realm.Server.Attributes;

namespace Realm.Server.Players
{
    /// <summary>
    /// 
    /// </summary>
    public class Character : Biota, ICharacter
    {
        private List<Ability> Abilities { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        ///<param name="user"> </param>
        public Character(long id, string name, IGameUser user)
            : base(id, name, null)
        {
            User = user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initAtom"></param>
        public override void OnInit(DictionaryAtom initAtom)
        {
            base.OnInit(initAtom);

            Contexts.Add(new PlayerChannelContext(this));
            Contexts.Add(new AttributeContext(this));
        }

        /// <summary>
        /// 
        /// </summary>
        public IGameUser User { get; private set; }

        public override Globals.PositionTypes Position
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override Globals.GenderTypes Gender
        {
            get { throw new System.NotImplementedException(); }
        }

        public override RaceDef Race
        {
            get { throw new System.NotImplementedException(); }
        }

        public override Globals.MovementModeTypes Movement
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadCharacter()
        {
            var args = new DictionaryAtom();
            args.Set("CharacterID", ID);

            DbClient.BeginTransaction();
            DbClient.AddCommand("live", "game_GetCharacterAbilities", args, OnCharacterAbilitiesLoaded);
            DbClient.AddCommand("live", "game_GetCharacterChannels", args, OnCharacterChannelsLoaded);
            DbClient.AddCommand("live", "game_GetCharacterFactions", args, OnCharacterFactionsLoaded);
            DbClient.AddCommand("live", "game_GetCharacterItems", args, OnCharacterItemsLoaded);
            DbClient.AddCommand("live", "game_GetCharacterProperties", args, OnCharacterPropertiesLoaded);
            DbClient.AddCommand("live", "game_GetCharacterStatistics", args, OnCharacterStatisticsLoaded);
            DbClient.AddCommand("live", "game_GetCharacterMail", args, OnCharacterMailLoaded);
            DbClient.PerformTransaction(null, null);
        }

        private void OnCharacterAbilitiesLoaded(RealmEventArgs args)
        {
            var success = args.Data["success"].CastAs<bool>();
            if (!success)
            {
                Logger.InfoFormat("game_GetCharacterAbilities failed");
                return;
            }

            Abilities = new List<Ability>();

            var results = args.Data["commandResult"].CastAs<ListAtom>();
            foreach (var result in results.Select(atom => atom.CastAs<DictionaryAtom>()))
            {
                var abilityId = result.GetInt("AbilityID");
                var abilityDef = StaticDataManager.GetStaticData(Globals.SystemTypes.Ability,
                                                                 abilityId.ToString());

                Abilities.Add(EntityManager.Create<Ability>(abilityId, abilityDef.Name, abilityDef));
            }
        }

        private void OnCharacterChannelsLoaded(RealmEventArgs args)
        {

        }

        private void OnCharacterFactionsLoaded(RealmEventArgs args)
        {

        }

        private void OnCharacterItemsLoaded(RealmEventArgs args)
        {

        }

        private void OnCharacterPropertiesLoaded(RealmEventArgs args)
        {

        }

        private void OnCharacterStatisticsLoaded(RealmEventArgs args)
        {

        }

        private void OnCharacterMailLoaded(RealmEventArgs args)
        {

        }
        private void OnCharacterMailMapLoaded(RealmEventArgs args)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loadGuildbank"></param>
        public void LoadBank(bool loadGuildbank = false)
        {
            var args = new DictionaryAtom();
            if (loadGuildbank)
                args.Set("GuildID", 0); // TODO: Insert GuildID here
            else
                args.Set("UserID", User.ID);

            var data = new DictionaryAtom();
            data.Set("IsGuildBank", loadGuildbank);

            DbClient.BeginTransaction();
            DbClient.AddCommand("live", "game_GetBank", args, OnBankLoaded, data);
        }
        private void OnBankLoaded(RealmEventArgs args)
        {

        }

        /* public Character(long id, IGameUser user)
                : base(null, id)
            {
                User = user;
                RecipeRepository = new RecipeRepository();
            }

            //public override void OnInit(DictionaryAtom definition)
            public override void OnInit()
            {
            //    base.OnInit();
                var flag = DataManager.GetFlag("Character");

                AbilityRepository = new AbilityRepository(Game, EntityManager);
                Channels = new ChannelHandler(User);
                Game.SetManagerReferences(Channels);

                Flags.SetFlag(flag.Abbrev);
                Position = Globals.Globals.PositionTypes.Standing;
                Location = EntityManager.LuaGetTemplate(Game.GetIntConstant("startSpace").GetValueOrDefault(1));

                EventManager.RegisterListener(this, Game, typeof(OnGameRound), Instance_OnGameTurn);
            }

            public RecipeRepository RecipeRepository { get; private set; }
            public AbilityRepository AbilityRepository { get; private set; }
            public IGameUser User { get; private set; }
            public IMobInstance GreetedShop { get; set; }
            public ChannelHandler Channels { get; private set; }

            void Instance_OnGameTurn(RealmEventArgs e)
            {
                if (IsDead) return;
                RegenHealth();
                RegenMana();
                RegenStamina();
                SendPrompt();
            }

            public string Note
            {
                get { return GetStringProperty("note"); }
                set { Properties.SetProperty("note", value); }
            }

            new public string Name
            {
                get { return GetStringProperty("name"); }
                set { Properties.SetProperty("name", value); }
            }

            public string FullName
            {
                get
                {
                    var str = GetStringProperty("title");
                    if (!string.IsNullOrEmpty(str))
                        str += " ";
                    str += Name;
                    return str;
                }
            }

            public int CurrentXp
            {
                get { return GetIntProperty("current_xp"); }
                set { Properties.SetProperty("current_xp", value); }
            }

            public Archetype CurrentArchetype
            {
                get { return (Archetype)DataManager.Get("Archetypes", GetStringProperty("archetype")); }
                set { Properties.SetProperty("archetype", value.IsNull() ? string.Empty : value.Name); }
            }

            public override AbilityTemplate AutoAttackAbility
            {
                get
                {
                    var abilityId = GetLongProperty("autoattack_ability");
                    if (abilityId == 0)
                        return EntityManager.LuaGetTemplate(CurrentArchetype.AutoAttackAbility) as AbilityTemplate;
                    var entity = EntityManager.LuaGetTemplate(abilityId);
                    if (entity.IsNull())
                        return EntityManager.LuaGetTemplate(CurrentArchetype.AutoAttackAbility) as AbilityTemplate;
                    return entity as AbilityTemplate;
                }
                set { Properties.SetProperty("autoattack_ability", value.IsNull() ? 0 : value.ID); }
            }

            public bool CanSeeExtendedDetails
            {
                get
                {
                    return Flags.HasFlag("Wizard") || Flags.HasFlag("Admin") || Flags.HasFlag("Builder");
                }
            }

            public override int CurrentHealth
            {
                get 
                {
                    return GetIntProperty("current_health"); 
                }
                set
                {
                    var setHealth = value;
                    if (setHealth < 0)
                        setHealth = 0;
                    var maxHealth = StatisticHandler.MaximumHealth;
                    if (setHealth > maxHealth)
                        setHealth = maxHealth;
                    Properties.SetProperty("current_health", setHealth);
                    // TODO: : If User is not loading, send prompt
                    if (!User.IsLoading)
                    {
                        SendPrompt();
                    }
               }
            }

            public override int CurrentMana
            {
                get
                {
                    return GetIntProperty("current_mana");
                }
                set
                {
                    var setMana = value;
                    if (setMana < 0)
                        setMana = 0;
                    var maxMana = StatisticHandler.MaximumMana;
                    if (setMana > maxMana)
                        setMana = maxMana;
                    Properties.SetProperty("current_mana", setMana);
                    // TODO: : If user is not loading, send prompt
                    if (!User.IsLoading)
                    {
                        SendPrompt();
                    }
           /    }
            }

            public override int CurrentStamina
            {
                get
                {
                    return GetIntProperty("current_stamina");
                }
                set
                {
                    var setStamina = value;
                    if (setStamina < 0)
                        setStamina = 0;
                    var maxStamina = StatisticHandler.MaximumStamina;
                    if (setStamina > maxStamina)
                        setStamina = maxStamina;
                    Properties.SetProperty("current_stamina", setStamina);
                    // TODO: : If user is not loading, send prompt
                    if (!User.IsLoading)
                    {
                        SendPrompt();
                    }
                }
            }

            // TODO: : Handle the Character entering the game
            /*public void OnUserEnterGame(MUDEventArgs aArgs)
            {
                if (CurrentHealth > CalculateMaxHealth())
                {
                    CurrentHealth = CalculateMaxHealth();
                }
                if (CurrentMana > CalculateMaxMana())
                {
                    CurrentMana = CalculateMaxMana();
                }
                if (CurrentStamina > CalculateMaxStamina())
                {
                    CurrentStamina = CalculateMaxStamina();
                }
                SendPrompt();
            }

            // TODO: : Handle the character being hit
            public void OnCombatHit(MUDEventArgs e)
            {
                if (IsDead)
                {
                    User.SendText("You're dead!");
                }
            }

            public void SendPrompt()
            {
                var sb = new StringBuilder();
                sb.AppendFormat("<Health: {0}/{1} | Mana: {2}/{3} | Stamina: {4}/{5}>", CurrentHealth,
                    StatisticHandler.MaximumHealth, CurrentMana, StatisticHandler.MaximumMana,
                    CurrentStamina, StatisticHandler.MaximumStamina);
                User.SendText(sb.ToString());
            }

            public override bool CanMove(string aDirection, bool isIgnoringCombat, bool aSendMessage)
            {
                if (isIgnoringCombat && IsFighting)
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_FIGHTING, this);
                    return false;
                }

                if (IsDead)
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_DEAD, this);
                    return false;
                }

                var currentSpace = Location as Space;
                if (currentSpace.IsNull())
                    return false;
                if (currentSpace.PortalCount() == 0)
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_NOEXITS, this);
                    return false;
                }

                if (Position == Globals.Globals.PositionTypes.Prone || Position == Globals.Globals.PositionTypes.Sitting)
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_POSITION, this);
                    return false;
                }

                var exit = currentSpace.GetPortal(aDirection);
                if (exit.IsNull())
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_NODIR, this);
                    return false;
                }

                var destinationSpace = exit.Destination;
                if (destinationSpace.IsNull())
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_DIR, this);
                    return false;
                }

                // check here for doors
                var value = ~(Access & destinationSpace.Access);
                if (value == 0)
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_NOTALLOW, this);
                    return false;
                }

                if (destinationSpace.Terrain.HasMovementMode(Movement))
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_TERRAIN, this);
                    return false;
                }

                // Check stamina
                var staminaCost = destinationSpace.CalculateStaminaCost(this as ICharacter);
                if (CurrentStamina < staminaCost)
                {
                    if (aSendMessage)
                        CommandManager.ReportToCharacter(MessageResources.MSG_CANNOT_MOVE_STAMINA, this);
                    return false;
                }

                return true;
            }
 
            public void GainXp(int value)
            {
                CurrentXp += value;
                if (NeededForNextLevel() > 0) return;
                Level++;

                var table = new EventTable {{"level", Level}};
                EventManager.ThrowEvent(this, new OnLevelGain("OnLevelGame"), table);
            }

            public int NeededForNextLevel()
            {
                var nextLevel = Level + 1;
                if (nextLevel > Game.Properties.GetProperty<int>("max_level"))
                    return -1;
            
                //// calculate next level requirement
                var needed = (nextLevel * Game.Properties.GetProperty<int>("base_xp")) +
                    ((nextLevel - 1) * Game.Properties.GetProperty<int>("xp_step"));
                return needed - CurrentXp;
            }

            public FormulaItemTemplate GetRecipeByProduct(string productName)
            {
                foreach (var recipeId in RecipeRepository.Keys)
                {
                    var formula = EntityManager.LuaGetTemplate(recipeId) as FormulaItemTemplate;
                    if (formula.IsNull()) continue;
                    var product = EntityManager.LuaGetTemplate(formula.Product) as ItemTemplate;
                    if (product.CompareName(productName)) return formula;
                }
                return null;
            }*/
    }
}
