//using System;
//using System.Collections.Generic;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Abilities;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerKillCommand : GameCommand
//    {
//        private delegate void CombatResult(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility);

//        private readonly Dictionary<Globals.Globals.CombatHitResultTypes, CombatResult> CombatResultTable;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerKillCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerKillCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
//        {
//            CombatResultTable = new Dictionary<Globals.Globals.CombatHitResultTypes, CombatResult>
//                                    {
//                                        {Globals.Globals.CombatHitResultTypes.Niss, CombatResultMiss},
//                                        {Globals.Globals.CombatHitResultTypes.Dodge, CombatResultDodge},
//                                        {Globals.Globals.CombatHitResultTypes.Parry, CombatResultParry},
//                                        {Globals.Globals.CombatHitResultTypes.Block, CombatResultBlock},
//                                        {Globals.Globals.CombatHitResultTypes.Devastate, CombatResultDevastate},
//                                        {Globals.Globals.CombatHitResultTypes.Glance, CombatResultGlance},
//                                        {Globals.Globals.CombatHitResultTypes.Hit, CombatResultHit}
//                                    };
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var keyword = oUser.GetProperty<object>("last command string").ToString();
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            Execute(oUser.GetCurrentCharacter(), null, null, keyword, true);
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        /// <param name="oActor"><see cref="Biota"/> object doing the action</param>
//        /// <param name="obj1">first object being acted upon</param>
//        /// <param name="obj2">second object being acted upon</param>
//        /// <param name="aKeyword">Phrase or keyword string</param>
//        /// <param name="aMessage">Flag indicating whether or not to send the message to the client</param>
//        public void Execute(IBiota oActor, IGameEntity obj1, IGameEntity obj2, string aKeyword, bool aMessage = false)
//        {
//            var word1 = aKeyword.FirstWord();
//            if (string.IsNullOrEmpty(word1)) return;

//            var word2 = aKeyword.SecondWord();

//            //// determine who is being attacked
//            var target = oActor.Location.Contents.GetEntity(word1) as Biota;
//            if (target.IsNull())
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#nothing_here#", oActor);
//                return;
//            }

//            if (target == oActor)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#cannot_attack_self#", oActor);
//                return;
//            }

//            //// Safe Space, can't attack in here
//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            if (Space.Bits.HasBit(Globals.Globals.SpaceBits.IsSafe))
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#cannot_attack_safe#", oActor);
//                return;
//            }

//            //// Is there an auto-attack ability?
//            var ability = oActor.AutoAttackAbility;
//            if (null == ability)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_with_what#", oActor);
//                return;
//            }

//            //// Does the ability require a weapon?  And do you have one equipped?
//            if (ability.Bits.HasBit(Globals.Globals.AbilityBits.WeaponRequired))
//            {
//                var aWeapon = oActor.GetEquippedItem(Globals.Globals.WearLocations.wearhandright);
//                if (null == aWeapon)
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#no_weapon#", oActor);
//                    return;
//                }

//                if (!aWeapon.IsType("weapon"))
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#not_weapon#", oActor, null, aWeapon);
//                    return;
//                }
//            }

//            //// Post-Delay is still ticking for the auto-attack
//            if (!string.IsNullOrEmpty(oActor.LastAttack))
//            {
//                var span = DateTime.Now.Subtract(Convert.ToDateTime(oActor.LastAttack));
//                if (span.TotalMilliseconds < (ability.PostDelay * 1000))
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#cannot_attack_postdelay#", oActor);
//                    return;
//                }
//            }

//            if (oActor.Fighting == target)
//            {
//                // TODO: How to handle multiple attacks from an ability?
//                //for (int i = 0; i < ability.; i++)
//                Execute(oActor, target, ability);
//            }
//            else
//            {
//                if (!CombatManager.EngageCombatant(oActor, target))
//                    return;

//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_self#", oActor, target);
//                if (aMessage && target is Character)
//                    CommandManager.ReportToCharacter("#attack_target#", target, oActor);
//                CommandManager.ReportToSpaceLimited("#attack_other#", oActor, target);

//                // TODO: How to handle multiple attacks from an ability?
//                //for (int i = 0; i < ability.NumberAttacks; i++)
//                Execute(oActor, target, ability);
//            }
//        }

//        private void ThrowCombatResultEvents(IBiota oActor, IBiota oTarget,
//            Globals.Globals.CombatHitResultTypes result, Damage dmg = null)
//        {
//            var table = new EventTable
//                                    {
//                                        {"attacker", oActor},
//                                        {"defender", oTarget},
//                                        {"result", result}
//                                    };

//            if (dmg.IsNotNull())
//            {
//                table.Add("amount", dmg.DamageAmount);
//                table.Add("location", dmg.DamageLocation);
//                table.Add("type", dmg.DamageType);
//            }

//            EventManager.ThrowEvent<OnCombatResult>(oActor, table);
//            EventManager.ThrowEvent<OnCombatResult>(oTarget, table);
//        }

//        private void CombatResultMiss(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            if (oActor is Character)
//                CommandManager.ReportToCharacter("#attack_miss_self#", oActor, oTarget);
//            if (oTarget is Character)
//                CommandManager.ReportToCharacter("#attack_miss_target#", oTarget, oActor);
//            CommandManager.ReportToSpaceLimited("#attack_miss_other#", oActor, oTarget);

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Niss);
//        }
//        private void CombatResultDodge(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            if (oActor is Character)
//                CommandManager.ReportToCharacter("#attack_dodge_self#", oActor, oTarget);
//            if (oTarget is Character)
//                CommandManager.ReportToCharacter("#attack_dodge_target#", oTarget, oActor);
//            CommandManager.ReportToSpaceLimited("#attack_dodge_other#", oActor, oTarget);

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Dodge);
//        }
//        private void CombatResultParry(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            if (oActor is Character)
//                CommandManager.ReportToCharacter("#attack_parry_self#", oActor, oTarget);
//            if (oTarget is Character)
//                CommandManager.ReportToCharacter("#attack_parry_target#", oTarget, oActor);
//            CommandManager.ReportToSpaceLimited("#attack_parry_other#", oActor, oTarget);

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Parry);
//        }
//        private void CombatResultBlock(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            if (oActor is Character)
//                CommandManager.ReportToCharacter("#attack_block_self#", oActor, oTarget);
//            if (oTarget is Character)
//                CommandManager.ReportToCharacter("#attack_block_target#", oTarget, oActor);
//            CommandManager.ReportToSpaceLimited("#attack_block_other#", oActor, oTarget);

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Block);
//        }
//        private void CombatResultDevastate(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            var atk = new Attack(oActor, oTarget, Globals.Globals.WearLocations.none,
//                                 oActor.GetEquippedItem(Globals.Globals.WearLocations.wearhandright),
//                                 Globals.Globals.CombatHitResultTypes.Devastate);
//            var dmg = CombatManager.DamageCheck(atk);

//            if (dmg.DamageAmount > 0)
//            {
//                if (oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_devastate_self#", oActor,
//                                                     oTarget, dmg.DamageLocation.GetShortName(), dmg);
//                if (oTarget is Character)
//                    CommandManager.ReportToCharacter("#attack_devastate_target#", oTarget, oActor,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                CommandManager.ReportToSpaceLimited("#attack_devastate_other#", oActor, oTarget,
//                                                    dmg.DamageLocation.GetShortName(), dmg);
//            }
//            else
//            {
//                if (oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_devastate_resist_self#", oActor, oTarget,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                if (oTarget is Character)
//                    CommandManager.ReportToCharacter("#attack_devastate_resist_target#", oTarget, oActor,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                CommandManager.ReportToSpaceLimited("#attack_devastate_resist_other#", oActor, oTarget,
//                                                    dmg.DamageLocation.GetShortName(), dmg);

//                atk.Defender.CurrentHealth -= dmg.DamageAmount;
//            }

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Devastate, dmg);
//        }
//        private void CombatResultGlance(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            var atk = new Attack(oActor, oTarget, Globals.Globals.WearLocations.none,
//                                 oActor.GetEquippedItem(Globals.Globals.WearLocations.wearhandright),
//                                 Globals.Globals.CombatHitResultTypes.Glance);
//            var dmg = CombatManager.DamageCheck(atk);

//            if (dmg.DamageAmount > 0)
//            {
//                if (oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_glance_self#", oActor, oTarget,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                if (oTarget is Character)
//                    CommandManager.ReportToCharacter("#attack_glance_target#", oTarget, oActor,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                CommandManager.ReportToSpaceLimited("#attack_glance_other#", oActor, oTarget,
//                                                    dmg.DamageLocation.GetShortName(), dmg);

//                atk.Defender.CurrentHealth -= dmg.DamageAmount;
//            }
//            else
//            {
//                if (oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_glance_resist_self#", oActor, oTarget,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                if (oTarget is Character)
//                    CommandManager.ReportToCharacter("#attack_glance_resist_target#", oTarget, oActor,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                CommandManager.ReportToSpaceLimited("#attack_glance_resist_other#", oActor, oTarget,
//                                                    dmg.DamageLocation.GetShortName(), dmg);
//            }

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Hit, dmg);
//        }
//        private void CombatResultHit(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            var atk = new Attack(oActor, oTarget, Globals.Globals.WearLocations.none,
//                                 oActor.GetEquippedItem(Globals.Globals.WearLocations.wearhandright),
//                                 Globals.Globals.CombatHitResultTypes.Hit);
//            var dmg = CombatManager.DamageCheck(atk);

//            if (dmg.DamageAmount > 0)
//            {
//                if (oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_hit_self#", oActor, oTarget,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                if (oTarget is Character)
//                    CommandManager.ReportToCharacter("#attack_hit_target#", oTarget, oActor,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                CommandManager.ReportToSpaceLimited("#attack_hit_other#", oActor, oTarget,
//                                                    dmg.DamageLocation.GetShortName(), dmg);

//                atk.Defender.CurrentHealth -= dmg.DamageAmount;
//            }
//            else
//            {
//                if (oActor is Character)
//                    CommandManager.ReportToCharacter("#attack_hit_resist_self#", oActor, oTarget,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                if (oTarget is Character)
//                    CommandManager.ReportToCharacter("#attack_hit_resist_target#", oTarget, oActor,
//                                                     dmg.DamageLocation.GetShortName(), dmg);
//                CommandManager.ReportToSpaceLimited("#attack_hit_resist_other#", oActor, oTarget,
//                                                    dmg.DamageLocation.GetShortName(), dmg);
//            }

//            ThrowCombatResultEvents(oActor, oTarget, Globals.Globals.CombatHitResultTypes.Glance, dmg);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="oActor"></param>
//        /// <param name="oTarget"></param>
//        /// <param name="aAbility"></param>
//        public void Execute(IBiota oActor, IBiota oTarget, AbilityTemplate aAbility)
//        {
//            oActor.LastAttack = DateTime.Now.ToString();

//            var result = oActor.HitCheck(oTarget, aAbility);
//            if (CombatResultTable.ContainsKey(result))
//                CombatResultTable[result].DynamicInvoke(oActor, oTarget, aAbility);
//        }
//    }
//}
