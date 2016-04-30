using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity.Contexts;
using Realm.Entity.Entities.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Objects;
using Realm.Library.Database.Framework;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public abstract class Biota : GameEntity, IBiota
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        protected Biota(long id, string name, Definition definition)
            : base(id, name, definition) { }

        /// <summary>
        ///
        /// </summary>
        protected DatabaseClient DbClient { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        public override void OnInit(DictionaryAtom initAtom)
        {
            base.OnInit(initAtom);

            Contexts.Add(new ContentsContext(this));

            DbClient = new DatabaseClient(this, initAtom.GetObject("DatabaseManager").CastAs<IDatabaseLoadBalancer>());
            Validation.IsNotNull(DbClient, "DbClient");

            /*Position = Globals.Globals.PositionTypes.Standing;
            Movement = Globals.Globals.MovementModeTypes.Walking;

            PerceptionHandler = new PerceptionHandler(this, 1);
            Inventory = new Inventory(this);
            EffectsHandler = new EffectsHandler(Game, EntityManager, Log, this);

            StatisticHandler = new StatisticHandler(this);
            Game.SetManagerReferences(StatisticHandler);*/
        }

        public abstract Globals.PositionTypes Position { get; set; }

        public abstract Globals.GenderTypes Gender { get; }

        public abstract RaceDef Race { get; }

        public abstract Globals.MovementModeTypes Movement { get; set; }
        public string LastAttack { get; set; }
        public IBiota Fighting { get; set; }
        public bool IsFighting => Fighting.IsNull();
        public bool IsDead { get; private set; }

        /*public Inventory Inventory { get; private set; }
        public PerceptionHandler PerceptionHandler { get; private set; }
        public IStatisticHandler StatisticHandler { get; private set; }
        public EffectsHandler EffectsHandler { get; private set; }

        public virtual int Level
        {
            get
            {
                return GetIntProperty("level");
            }
            set
            {
                var newLevel = value;
                if (newLevel < Level) return;
                if (newLevel < 0) newLevel = 1;
                if (newLevel > Game.Properties.GetProperty<int>("max_level"))
                    newLevel = Game.Properties.GetProperty<int>("max_level");
                Properties.SetProperty("level", newLevel);
            }
        }

        public virtual int CurrentHealth
        {
            get
            {
                return GetIntProperty("current_health");
            }
            set
            {
                var setHealth = value;
                if (setHealth < 0) setHealth = 0;
                var maxHealth = StatisticHandler.MaximumHealth;
                if (setHealth > maxHealth) setHealth = maxHealth;
                Properties.SetProperty("current_health", setHealth);
            }
        }

        public virtual int CurrentMana
        {
            get
            {
                return GetIntProperty("current_mana");
            }
            set
            {
                if (value < 0)
                {
                    Properties.SetProperty("current_mana", 0);
                    return;
                }

                var maxMana = StatisticHandler.MaximumMana;
                if (value > maxMana)
                {
                    Properties.SetProperty("current_mana", maxMana);
                    return;
                }

                Properties.SetProperty("current_mana", value);
            }
        }

        public virtual int CurrentStamina
        {
            get
            {
                return GetIntProperty("current_stamina");
            }
            set
            {
                if (value < 0)
                {
                    Properties.SetProperty("current_stamina", 0);
                    return;
                }

                var maxStamina = StatisticHandler.MaximumStamina;
                if (value > maxStamina)
                {
                    Properties.SetProperty("current_stamina", maxStamina);
                    return;
                }

                Properties.SetProperty("current_stamina", value);
            }
        }

        public virtual Globals.Globals.PositionTypes Position
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.PositionTypes>(GetStringProperty("position")); }
            set { Properties.SetProperty("position", value.GetName()); }
        }

        public virtual Globals.Globals.MovementModeTypes Movement
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.MovementModeTypes>(GetStringProperty("movement")); }
            set { Properties.SetProperty("movement", value.GetName()); }
        }

        public virtual Globals.Globals.GenderTypes Gender
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.GenderTypes>(GetStringProperty("gender")); }
            set { Properties.SetProperty("gender", value.GetName()); }
        }

        public virtual Race Race
        {
            get { return (Race)DataManager.Get("Races", GetStringProperty("race")); }
            set { Properties.SetProperty("race", value.IsNull() ? "none" : value.Name); }
        }

        public IBiota Fighting { get; set; }

        public bool IsFighting { get { return Fighting.IsNotNull(); } }

        public bool IsDead { get { return (CurrentHealth <= 0); } }

        public virtual AbilityTemplate AutoAttackAbility
        {
            get
            {
                var entity = EntityManager.LuaGetTemplate(GetLongProperty("autoattack_ability"));
                return entity.IsNotNull() ? entity as AbilityTemplate : null;
            }
            set { Properties.SetProperty("autoattack_ability", value.IsNull() ? 0 : value.ID); }
        }

        public virtual string LastAttack
        {
            get { return GetStringProperty("last_attack"); }
            set { Properties.SetProperty("last_attack", value); }
        }

        public virtual bool CanMove(string aDirection, bool isIgnoringCombat, bool aSendMessage)
        {
            var charMsg = string.Empty;
            var aiMsg = string.Empty;
            var failure = false;

            if (isIgnoringCombat && IsFighting)
            {
                charMsg = MessageResources.MSG_CANNOT_MOVE_FIGHTING;
                aiMsg = "Can't move because I'm engaged in combat!";
                failure = true;
            }
            else if (IsDead)
            {
                charMsg = MessageResources.MSG_CANNOT_MOVE_DEAD;
                aiMsg = "Can't move because I'm dead!";
                failure = true;
            }
            // can't move if your position isn't Standing/Crouching
            else if (Position != Globals.Globals.PositionTypes.Standing &&
                Position != Globals.Globals.PositionTypes.Crouching)
            {
                charMsg = MessageResources.MSG_CANNOT_MOVE_POSITION;
                aiMsg = "Can't move because I'm in no position to move!";
                failure = true;
            }
            else
            {
                var currentSpace = Location as Space;
                if (currentSpace.IsNull())
                {
                    charMsg = MessageResources.MSG_ERR;
                    aiMsg = "Can't move because there is no space in that direction!";
                    failure = true;
                }
                else if (currentSpace.PortalCount() == 0)
                {
                    charMsg = MessageResources.MSG_CANNOT_MOVE_NOEXITS;
                    aiMsg = "Can't move because there are no exits in the Space!";
                    failure = true;
                }
                else
                {
                    var exit = currentSpace.GetPortal(aDirection);
                    if (exit.IsNull())
                    {
                        charMsg = MessageResources.MSG_CANNOT_MOVE_NODIR;
                        aiMsg = string.Format("Can't move because {0} isn't a valid direction!", aDirection);
                        failure = true;
                    }
                    else if (exit.Destination.IsNull())
                    {
                        charMsg = MessageResources.MSG_CANNOT_MOVE_DIR;
                        aiMsg = string.Format("Can't move because {0} leads to an invalid Space!", aDirection);
                        failure = true;
                    }

                    // TODO: Handle Doors here

                    else if (~(Access & exit.Destination.Access) == 0)
                    {
                        charMsg = MessageResources.MSG_CANNOT_MOVE_NOTALLOW;
                        aiMsg = "Can't move because I'm not allowed to enter there!";
                        failure = true;
                    }
                    else if (exit.Destination.Terrain.HasMovementMode(Movement))
                    {
                        charMsg = MessageResources.MSG_CANNOT_MOVE_TERRAIN;
                        aiMsg = "Terrain in the destination does not allow me to move that direction.";
                        failure = true;
                    }
                }
            }

            if (failure)
            {
                if (aSendMessage && this is Players.ICharacter)
                    CommandManager.ReportToCharacter(charMsg, this);
                if (aSendMessage && this is IMobInstance)
                {
                    var mob = this as IRegularMob;
                    if (mob.IsNotNull())
                        mob.AiBrain.Messages.Add(aiMsg);
                }
            }

            return !failure;
        }

        /// <summary>
        /// Checks if the Biota can see in the current Space.  This checks for the presence of light
        /// or alternatively if the biota has the Admin/Wizard flags.
        /// </summary>
        public bool CanSee(GameEntityTemplate entity)
        {
            if (Flags.HasFlag("Wizard") || Flags.HasFlag("Admin")) return true;
            var Space = Location as Space;
            return Space.IsNotNull() && Space.HasLight;
        }

        /// <summary>
        /// Regenerates the biote's health, takes combat into account as well
        /// as stat bonuses.
        /// </summary>
        public void RegenHealth()
        {
            if (CurrentHealth >= StatisticHandler.MaximumHealth) return;
            var rate = StatisticHandler.CalculateHealthRegen(IsFighting);
            var Space = Location as Space;
            rate = Space.IsNotNull() && Space.Bits.HasBit(Globals.Globals.SpaceBits.IsTavern)
                ? (int)Math.Round(rate * 2)
                : (int)Math.Round(rate);
            CurrentHealth += (int)rate;

            EventManager.ThrowEvent<OnHealthRegen>(this, new EventTable
                                                             {
                                                                 { "health", CurrentHealth },
                                                                 { "amount", rate }
                                                             });
        }

        /// <summary>
        /// Regenerates the biote's mana, takes combat into account as well
        /// as stat bonuses.
        /// </summary>
        public void RegenMana()
        {
            if (CurrentMana >= StatisticHandler.MaximumMana) return;
            var rate = StatisticHandler.CalculateManaRegen(IsFighting);
            var Space = Location as Space;
            rate = Space.IsNotNull() && Space.Bits.HasBit(Globals.Globals.SpaceBits.IsTavern)
                ? (int)Math.Round(rate * 2)
                : (int)Math.Round(rate);
            CurrentMana += (int) rate;

            EventManager.ThrowEvent<OnManaRegen>(this, new EventTable
                                                           {
                                                               { "mana", CurrentMana },
                                                               { "amount", rate }
                                                           });
        }

        /// <summary>
        /// Regenerates the biote's stamina, takes combat into account as well
        /// as stat bonuses.
        /// </summary>
        public void RegenStamina()
        {
            if (CurrentStamina >= StatisticHandler.MaximumStamina) return;
            var rate = StatisticHandler.CalculateStaminaRegen(IsFighting);
            var Space = Location as Space;
            rate = Space.IsNotNull() && Space.Bits.HasBit(Globals.Globals.SpaceBits.IsTavern)
                ? (int) Math.Round(rate*2)
                : (int) Math.Round(rate);
            CurrentStamina += (int)rate;

            EventManager.ThrowEvent<OnStaminaRegen>(this, new EventTable
                                                              {
                                                                  {"stamina", CurrentStamina},
                                                                  {"amount", rate}
                                                              });
        }*/
    }
}