//using System;
//using System.Collections.Generic;
//using Realm.Library.Ai;
//using Realm.Library.Common;
//using Realm.Server.Ai;
//using Realm.Server.Events;
//using Realm.Server.Players;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.NPC
//// ReSharper restore CheckNamespace
//{
//    public class RegularMobInstance : MobInstance, IRegularMob
//    {
//        private Dictionary<long, MemoryRecord> _memories;

//        public RegularMobInstance(long id, RegularMobTemplate parent)
//            : base(id, parent)
//        {

//        }

//        #region GameEntity
//        public override void OnInit()
//        {
//            AiBrain = new MobBrain(this, new MessageContext(), Parent.CastAs<MobTemplate>().Behavior, Log);
//            _memories = new Dictionary<long, MemoryRecord>();

//            if (!Bits.HasBit(Globals.Globals.MobileBits.NoAttack))
//            {
//                EventManager.RegisterListener(this, CombatManager, typeof(OnCombatEngage), MobInstance_OnCombatEngage);
//                EventManager.RegisterListener(this, CombatManager, typeof(OnCombatDisengage), MobInstance_OnCombatDisengage);
//                EventManager.RegisterListener(this, CombatManager, typeof(OnCombatResult), MobInstance_OnCombatResult);
//                EventManager.RegisterListener(this, Game, typeof(OnGameRound), Instance_OnGameRound);
//            }
//        }
//        #endregion

//        #region IRegularMob
//        public IAiAgent AiBrain { get; private set; }

//        public Globals.Globals.MonsterClassTypes MonsterClass
//        {
//            get
//            {
//                var parent = Parent.CastAs<MobTemplate>();
//                return parent.IsNull() ? Globals.Globals.MonsterClassTypes.Strong : parent.MonsterClass;
//            }
//        }

//        public Behavior Behavior
//        {
//            get
//            {
//                var parent = Parent.CastAs<MobTemplate>();
//                return parent.IsNull() ? null : parent.Behavior;
//            }
//        }
//        #endregion

//        #region IExperienced
//        /// <summary>
//        /// Calculates the amount of experience the monster is worth, taking factors such as 
//        /// the player's level, the monster class, and the level difference between the 
//        /// monster and player into account.
//        /// </summary>
//        public int CalculateXpAward(int playerLevel)
//        {
//            var baseXp = (playerLevel * Game.GetProperty<int>("monster_xp_base")) +
//                ((playerLevel - 1) * Game.GetProperty<int>("monster_xp_step"));
//            var multXp = 1;
//            if (MonsterClass != Globals.Globals.MonsterClassTypes.Strong)
//                multXp = Game.GetProperty<int>(MonsterClass.ToString());

//            var levelMult = 1;
//            if (playerLevel > Level)
//                levelMult = (playerLevel - Level) * Game.GetProperty<int>("player_level_higher_xp_mod");
//            else if (Level > playerLevel)
//                levelMult = (Level - playerLevel) * Game.GetProperty<int>("player_level_lower_xp_mod");

//            float calcXp = levelMult * (baseXp * (multXp / 100));
//            return Convert.ToInt32(Math.Round(calcXp));
//        }
//        #endregion

//        #region Events
//        void Instance_OnGameRound(RealmEventArgs e)
//        {
//            // Can't regen if dead or turned off (asleep)
//            if (IsDead || (AiBrain.IsNotNull() && AiBrain.IsAsleep)) return;

//            RegenHealth();
//            RegenMana();
//            RegenStamina();
//        }
//        void MobInstance_OnCombatEngage(RealmEventArgs e)
//        {
//            if (AiBrain.CurrentState.IsNull() || IsFighting) return;

//            var attacker = e.GetValue("attacker").CastAs<IBiota>();
//            var defender = e.GetValue("defender").CastAs<IBiota>();

//            if (attacker.Equals(this)) return;
//            if (!(attacker is ICharacter)) return;
//            if (!defender.Equals(this)) return;

//            MemoryRecord record;
//            if (_memories.ContainsKey(attacker.ID))
//            {
//                record = _memories[attacker.ID];
//                record.StartedCombat = DateTime.Now;
//                record.TimestampEnter = DateTime.Now;
//            }
//            else
//            {
//                record = new MemoryRecord
//                             {
//                                 CharacterID = attacker.ID,
//                                 TimestampEnter = DateTime.Now,
//                                 StartedCombat = DateTime.Now
//                             };

//                _memories.Add(attacker.ID, record);
//            }

//            Log.InfoFormat("Mob {0} => OnCombatEngage => MemoryRecord for Character {1}", ID, attacker.ID);
//        }
//        void MobInstance_OnCombatDisengage(RealmEventArgs e)
//        {
//            if (!IsFighting) return;

//            var attacker = e.GetValue("attacker").CastAs<IBiota>();
//            var defender = e.GetValue("defender").CastAs<IBiota>();

//            if (attacker.Equals(this)) return;
//            if (!(attacker is ICharacter)) return;
//            if (!defender.Equals(this)) return;

//            MemoryRecord record;
//            if (_memories.ContainsKey(attacker.ID))
//            {
//                record = _memories[attacker.ID];
//                record.TimestampLeave = DateTime.Now;
//                Log.InfoFormat("Mob {0} => OnCombatDisengage => MemoryRecord for Character {1}", ID, attacker.ID);
//            }
//            else
//            {
//                record = new MemoryRecord
//                             {
//                                 CharacterID = attacker.ID,
//                                 TimestampEnter = DateTime.Now,
//                                 StartedCombat = DateTime.Now
//                             };

//                _memories.Add(attacker.ID, record);

//                Log.ErrorFormat("Mob {0} => OnCombatDisengage => Had no MemoryRecord for Character {1}", ID, attacker.ID);
//            }
//        }
//        void MobInstance_OnCombatResult(RealmEventArgs e)
//        {
//            if (!IsFighting) return;

//            var attacker = e.GetValue("attacker").CastAs<IBiota>();
//            var defender = e.GetValue("defender").CastAs<IBiota>();
//            if (!(attacker is ICharacter) || !(defender is ICharacter)) return;

//            if (!e.HasValue("amount")) return;
//            var amount = (int)e.GetValue("amount");

//            MemoryRecord record;
//            // TODO: If I'm the attacker, increment the damage inflicted
//            // TODO: If I'm the defender, increment the damage taken

//        }
//        #endregion
//    }
//}
