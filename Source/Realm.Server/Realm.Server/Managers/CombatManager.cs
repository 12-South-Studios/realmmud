//// ----------------------------------------------------------------------
//// <copyright file="CombatManager.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Linq;
//using System.Collections;
//using System.Management.Instrumentation;
//using Realm.Command;
//using Realm.Command.Interfaces;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Singleton;
//using Realm.Server.Commands;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Properties;
//using log4net;

//namespace Realm.Server.Managers
//{
//    public sealed class CombatManager : Singleton, ICombatManager
//    {
//        static CombatManager _instance;
//        static readonly object Padlock = new object();

//        private readonly Hashtable _combats;

//        private IEventManager _eventManager;
//        private ILog _log;
//        private ILuaManager _luaManager;
//        private ICommandManager _commandManager;

//        private CombatManager()
//        {
//            _combats = new Hashtable();
//        }

//        public void OnInit(IEventManager eventManager, ILog log, ILuaManager luaManager, ICommandManager commandManager)
//        {
//            _eventManager = eventManager;
//            _log = log;
//            _luaManager = luaManager;
//            _commandManager = commandManager;
//            _eventManager.RegisterListener(this, Game.Instance, typeof(OnGameInitialize), Instance_OnGameInitialize);
//        }

//        void Instance_OnGameInitialize(RealmEventArgs args)
//        {
//            _eventManager.RegisterListener(this, Game.Instance, typeof(OnGameRound), Instance_OnGameRound);
//            _luaManager.RegisterLuaFunctions(this);

//            var booleanSet = args.GetValue("BooleanSet") as BooleanSet;
//            if (booleanSet.IsNull()) return;

//            _log.Info("CombatManager initialized.");
//            booleanSet.CompleteItem("CombatManager");
//        }

//        void Instance_OnGameRound(RealmEventArgs e)
//        {
//            if (_combats.Count == 0) return;

//            try
//            {
//                foreach(var map in _combats.Values.OfType<CombatMap>())
//                {
//                    // TODO: For now ignore mobs (focused on getting player auto-attack working)
//                    if (map.Attacker is MobInstance) continue;

//                    _log.InfoFormat("Auto-attack combat for IBiota[{0}]", map.Attacker.ID);

//                    var command = _commandManager.GetCommand<PlayerKillCommand>("kill");
//                    if (command.IsNull())
//                        throw new InstanceNotFoundException(string.Format(ErrorResources.ERR_COMMAND_NOT_FOUND, "kill"));

//                    command.Execute(map.Attacker, map.Defender, map.Attacker.AutoAttackAbility);
//                }
//            }
//            catch (Exception ex)
//            {
//                ex.Handle(ExceptionHandlingOptions.RecordOnly, _log);
//            }
//        }

//        public static CombatManager Instance
//        {
//            get
//            {
//                lock (Padlock)
//                {
//                    return _instance ?? (_instance = new CombatManager());
//                }
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="aAttacker"></param>
//        /// <param name="aDefender"></param>
//        /// <returns></returns>
//        public bool EngageCombatant(IBiota aAttacker, IBiota aDefender)
//        {
//            //// is either dead or is the attacker already engaged in combat?
//            if (aAttacker.IsDead || aDefender.IsDead || aAttacker.IsFighting) return false;

//            //// are they already engaged to one another?
//            if (null != aAttacker.Fighting && 
//                null != aDefender.Fighting && 
//                aAttacker.Fighting == aDefender.Fighting)
//                return false;

//            aAttacker.Fighting = aDefender;
//            aDefender.Fighting = aAttacker;

//            //// setup the combat map
//            if (!SetupCombatMap(aAttacker, aDefender))
//            {
//                _log.ErrorFormat("Failed to setup Combat Map for Attacker[{0}]=>Defender[{1}]", aAttacker.ID, aDefender.ID);
//                return false;
//            }

//            if (!SetupCombatMap(aDefender, aAttacker))
//            {
//                _log.ErrorFormat("Failed to setup Combat Map for Defender[{0}]=>Attacker[{1}]", aDefender.ID, aAttacker.ID);
//                return false;
//            }

//            _eventManager.ThrowEvent(aAttacker, new OnCombatEngage("OnCombatEngage"), 
//                new EventTable {{"attacker", aAttacker}, {"defender", aDefender}});
//            _log.InfoFormat("Attacker[{0}] engaged Defender[{1}]", aAttacker.ID, aDefender.ID);
//            return true;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="aAttacker"></param>
//        /// <param name="aDefender"></param>
//        /// <returns></returns>
//        public bool DisengageCombatant(IBiota aAttacker, IBiota aDefender)
//        {
//            if (_combats.Contains(aAttacker))
//                _combats.Remove(aAttacker);

//            _eventManager.ThrowEvent(aAttacker, new OnCombatDisengage("OnCombatDisengage"), 
//                new EventTable { { "attacker", aAttacker }, { "defender", aDefender } }); 
//            return true;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="aAttack"></param>
//        /// <returns></returns>
//        public Damage DamageCheck(Attack aAttack)
//        {
//            var dmg = new Damage();

//            //// determine the wear location to be hit
//            var hitLoc = aAttack.HitLocation == Globals.Globals.WearLocations.none
//                             ? aAttack.Defender.GetRandomWearLocation()
//                             : aAttack.HitLocation;

//            dmg.DamageLocation = hitLoc;
//            dmg.DamageType = aAttack.DamageType;

//            // TODO: Do armor damage (durability) check 

//            //// Gotta do at least 1 base damage
//            if (aAttack.DamageAmount <= 0)
//                aAttack.DamageAmount = 1;

//            //// Normal = No chance in damage
//            //// Devastate = Damage increased by 50%
//            //// Glance = Damage decreased by 50%
//            switch (aAttack.HitResult)
//            {
//                case Globals.Globals.CombatHitResultTypes.Glance:
//                    dmg.DamageAmount = (int)(Math.Round(aAttack.DamageAmount * 0.5f));
//                    break;
//                case Globals.Globals.CombatHitResultTypes.Devastate:
//                    dmg.DamageAmount = (int)(Math.Round(aAttack.DamageAmount * 1.5f));
//                    break;
//                default:
//                    dmg.DamageAmount = aAttack.DamageAmount;
//                    break;
//            }
//            return dmg;
//        }

//        private bool SetupCombatMap(IBiota aAttacker, IBiota aDefender)
//        {
//            var map = new CombatMap
//                          {
//                              Attacker = aAttacker,
//                              Defender = aDefender,
//                              LastAttack = DateTime.Now,
//                              NumberAttacksPerRound = 1
//                          };
//            _combats[aAttacker] = map;
//            return true;
//        }

//        internal class CombatMap
//        {
//            public IBiota Attacker;
//            public IBiota Defender;
//            public DateTime LastAttack;
//            public int NumberAttacksPerRound;
//        }
//    }
//}
