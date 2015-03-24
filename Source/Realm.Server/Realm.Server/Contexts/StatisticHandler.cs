//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Realm.Command;
//using Realm.Command.Interfaces;
//using Realm.Data;
//using log4net;
//using Realm.Library.Common;
//using Realm.Server.Attributes;
//using Realm.Server.Channels;
//using Realm.Server.Commands;
//using Realm.Server.Effects;
//using Realm.Server.Effects.Instances;
//using Realm.Server.Events;
//using Realm.Server.Interfaces;
//using Realm.Server.Managers;
//using Realm.Server.NPC;
//using Realm.Server.Pathfinding;
//using Realm.Server.Players;
//using Realm.Server.Time;

//namespace Realm.Server.Contexts
//{
//    public class StatisticHandler : BaseContext<IGameEntity>,
//        IStatisticHandler, IManagerReference, ILogging
//    {
//        public StatisticHandler(IGameEntity parent)
//            : base(parent)
//        {
//            Stats = new StatRepository();
//            Skills = new SkillRepository();
//        }

//        public StatRepository Stats { get; private set; }

//        public SkillRepository Skills { get; private set; }

//        /// <summary>
//        /// Adds a skill with the given rating and spent-points
//        /// </summary>
//        public bool AddSkill(string name, int rating, int pointsSpent)
//        {
//            if (Skills.Contains(name)) return false;

//            var foundSkill = (Skill)DataManager.Get("Skills", name);
//            if (foundSkill.IsNull()) return false;

//            var skill = new SkillAttribute(foundSkill)
//                            {
//                                Owner = Owner as IBiota,
//                                Rating = rating,
//                                TrainingPoints = pointsSpent
//                            };
//            Skills.Add(name, skill);
//            Log.InfoFormat("Added SkillAttribute[{0}, {1}]", name, rating);
//            return true;
//        }

//        public SkillAttribute GetSkill(string name)
//        {
//            return Skills.Contains(name) ? Skills.Get(name) : null;
//        }

//        /// <summary>
//        /// Adds a stat with the given rating and spent-points
//        /// </summary>
//        public bool AddStat(string name, int rating, int pointsSpent)
//        {
//            Globals.Globals.Statistics type;
//            try
//            {
//                type = EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(name);
//            }
//            catch (ArgumentException)
//            {
//                return false;
//            }
//            if (Stats.Contains(type)) return false;

//            var stat = new StatAttribute(type.GetValue(), type.ToString(), type)
//                           {
//                               Owner = Owner as IBiota,
//                               Rating = rating,
//                               TrainingPoints = pointsSpent
//                           };
//            Stats.Add(type, stat);
//            Log.InfoFormat("Added Stat[{0}, {1}]", type, rating);
//            return true;
//        }

//        public StatAttribute GetStat(Globals.Globals.Statistics type)
//        {
//            return Stats.Contains(type) ? Stats.Get(type) : null;
//        }

//        public int CalculateCoreStat(Globals.Globals.Statistics type)
//        {
//            //// Can Be trained
//            //// Can Be modified
//            //// Bonus based upon rating
//            //// Rating + StatMods + (Times Trained x stat_tp_ratio)
//            var stat = GetStat(type);
//            var statRating = (stat.IsNotNull()) ? stat.Rating : 0;
//            var statTp = (stat.IsNotNull()) ? stat.TrainingPoints : 0;

//            return statRating + CalculateStatMods(type)
//                + (statTp * Game.Properties.GetProperty<int>("stat_tp_ratio"));
//        }

//        /// <summary>
//        /// Calculates the value of this skill.  Does not include the values of the 
//        /// parent skills.
//        /// </summary>
//        public int CalculateSkill(string name)
//        {
//            //// Can be trained
//            //// Can be modified
//            //// Bonus based upon stat rating
//            //// Rating + StatMods + (Times Trained x skill_tp_ratio) + StatBonus
//            var skill = GetSkill(name);
//            var skillRating = (skill.IsNotNull()) ? skill.Rating : 0;
//            var skillTp = (skill.IsNotNull()) ? skill.TrainingPoints : 0;

//            var statRating = 0;
//            if (skill.IsNotNull())
//            {
//                var stat = GetStat(skill.Skill.Stat);
//                statRating = (stat.IsNotNull()) ? stat.Rating : 0;
//            }

//            return skillRating + CalculateStatMods(Globals.Globals.Statistics.Skill, name)
//                + (skillTp * Game.Properties.GetProperty<int>("skill_tp_ratio"))
//                + AttributeUtils.CalculateBonus(statRating);
//        }

//        /// <summary>
//        /// Calculates the value of this skill and adds it to the values of the 
//        /// parent skills.
//        /// </summary>
//        public int CalculateGrossSkill(string name)
//        {
//            var totalSkill = CalculateSkill(name);
//            var attrib = GetSkill(name);
//            if (attrib.Skill.Parent.IsNull()) return totalSkill;

//            var foundSkill = GetSkill(attrib.Skill.Parent.Name);
//            while (attrib.Skill.Parent.IsNotNull())
//            {
//                totalSkill = CalculateSkill(foundSkill.Name);
//                foundSkill = GetSkill(foundSkill.Skill.Parent.Name);
//            }
//            return totalSkill;
//        }

//        public int CalculateDefenseStat(Globals.Globals.Statistics type)
//        {
//            //// Cannot be trained
//            //// Can be modified
//            //// Bonus based upon primary stat
//            //// 10 + (1/2 Level) + StatMods
//            var parent = Owner as Biota;
//            if (parent.IsNull()) return 0;
//            return type == Globals.Globals.Statistics.Defense
//                ? 10 + (parent.Level / 2) + Armor + CalculateStatMods(type)
//                : 10 + (parent.Level / 2) + CalculateStatMods(type);
//        }

//        public int CalculateResistanceStat(Globals.Globals.Statistics type)
//        {
//            //// Cannot be trained
//            //// Can be modified
//            //// No bonus
//            var stat = GetStat(type);
//            return (stat.IsNotNull() ? stat.Rating : 0) + CalculateStatMods(type);
//        }

//        public int Armor
//        {
//            get
//            {
//                var parent = Owner as Biota;
//                return parent.IsNull()
//                           ? 0
//                           : parent.Inventory.Equipment.Values.Sum(item => item.Properties.GetProperty<int>("armor"));
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the Health statistic, taking bonuses, stat mods, 
//        /// and also training into account.
//        /// </summary>
//        public int MaximumHealth
//        {
//            get
//            {
//                //// Can be trained
//                //// Can be modified
//                //// Bonus based upon primary stats
//                //// Maximum Health = Base Health (by Race) + Endurance Modifier + Willpower Modifier + (Times Trained x Health Gain)
//                var parent = Owner as IBiota;
//                if (parent.IsNull()) return 0;
//                var stat = GetStat(Globals.Globals.Statistics.Health);
//                var statTp = (stat.IsNotNull()) ? stat.TrainingPoints : 0;
//                int baseHealth = parent.Race.IsNotNull()
//                                     ? parent.Race.Properties.GetProperty<int>("base_health")
//                                     : Game.GetIntConstant("defaultHealth").GetValueOrDefault(0);
//                if (baseHealth <= 0)
//                    baseHealth = Game.GetIntConstant("defaultHealth").GetValueOrDefault(0);

//                return baseHealth + CalculateStatMods(Globals.Globals.Statistics.Health)
//                       + CalculateBonus(Globals.Globals.Statistics.Endurance)
//                       + CalculateBonus(Globals.Globals.Statistics.Willpower)
//                       + (statTp * Game.Properties.GetProperty<int>("health_tp_ratio"));
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the Mana statistic, taking bonuses, stat mods, 
//        /// and also training into account.
//        /// </summary>
//        public int MaximumMana
//        {
//            get
//            {
//                //// Can be trained
//                //// Can be modified
//                //// Bonus based upon primary stats
//                //// Maximum Mana = Base Mana (by School) + Vitality Modifier + Willpower Modifier + (Mana Gain / Level x Level)
//                var parent = Owner as IBiota;
//                if (parent.IsNull()) return 0;
//                var stat = GetStat(Globals.Globals.Statistics.Mana);
//                var statTp = (stat.IsNotNull()) ? stat.TrainingPoints : 0;
//                int baseMana = parent.Race.IsNotNull()
//                                   ? parent.Race.Properties.GetProperty<int>("base_mana")
//                                   : Game.GetIntConstant("defaultMana").GetValueOrDefault(0);
//                if (baseMana <= 0)
//                    baseMana = Game.GetIntConstant("defaultMana").GetValueOrDefault(0);

//                return baseMana + CalculateStatMods(Globals.Globals.Statistics.Mana)
//                       + CalculateBonus(Globals.Globals.Statistics.Vitality)
//                       + CalculateBonus(Globals.Globals.Statistics.Willpower)
//                       + (statTp * Game.Properties.GetProperty<int>("mana_tp_ratio"));
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the Stamina statistic, taking bonuses, stat mods, 
//        /// and also training into account.
//        /// </summary>
//        public int MaximumStamina
//        {
//            get
//            {
//                //// Can be trained
//                //// Can be modified
//                //// Bonus based upon primary stats
//                //// Maximum Stamina = Base Stamina (by School) + Endurance Modifier + Strength Modifier + (Stamina Gain / Level x Level)
//                var parent = Owner as IBiota;
//                if (parent.IsNull()) return 0;
//                var stat = GetStat(Globals.Globals.Statistics.Stamina);
//                var statTp = (stat.IsNotNull()) ? stat.TrainingPoints : 0;
//                int baseStamina = parent.Race.IsNotNull()
//                                      ? parent.Race.Properties.GetProperty<int>("base_stamina")
//                                      : Game.GetIntConstant("defaultStamina").GetValueOrDefault(0);
//                if (baseStamina <= 0)
//                    baseStamina = Game.GetIntConstant("defaultStamina").GetValueOrDefault(0);

//                return baseStamina + CalculateStatMods(Globals.Globals.Statistics.Stamina)
//                       + CalculateBonus(Globals.Globals.Statistics.Endurance)
//                       + CalculateBonus(Globals.Globals.Statistics.Strength)
//                       + (statTp * Game.Properties.GetProperty<int>("stamina_tp_ratio"));
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the Dodge statistic, taking bonuses and stat mods
//        /// into account.
//        /// </summary>
//        public float Dodge
//        {
//            get
//            {
//                //// Can be trained
//                //// Can be modified
//                //// Bonus based upon primary stats
//                //// -- Dodge = (1/2 Level) + Agility Modifier + Dexterity Modifier + Other Modifiers
//                var parent = Owner as Biota;
//                if (parent.IsNull()) return 0;
//                var stat = GetStat(Globals.Globals.Statistics.Dodge);
//                var statRating = (stat.IsNotNull()) ? stat.Rating : 0;
//                var rating = statRating + CalculateBonus(Globals.Globals.Statistics.Agility)
//                             + CalculateBonus(Globals.Globals.Statistics.Dexterity) +
//                             CalculateStatMods(Globals.Globals.Statistics.Dodge);
//                var chance = (rating / (((1190 / 3) * parent.Level) + rating)) * 100;

//                return chance > Game.Properties.GetProperty<int>("max_avoidance")
//                           ? Game.Properties.GetProperty<int>("max_avoidance")
//                           : chance;
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the Block statistic, taking bonuses and stat mods
//        /// into account.
//        /// </summary>
//        public float Block
//        {
//            get
//            {
//                //// Can be trained
//                //// Can be modified
//                //// Bonus based upon primary stats
//                //// -- Block = (1/2 Level) + Strength Modifier + Endurance Modifier + Armor Modifiers + Other Modifiers
//                //// AvoidRating / ((1190/3) * CharacterLevel + AvoidRating)
//                var parent = Owner as Biota;
//                if (parent.IsNull()) return 0;
//                var stat = GetStat(Globals.Globals.Statistics.Block);
//                var statRating = (stat.IsNotNull()) ? stat.Rating : 0;
//                var rating = statRating + CalculateBonus(Globals.Globals.Statistics.Strength)
//                             + CalculateBonus(Globals.Globals.Statistics.Endurance) +
//                             CalculateStatMods(Globals.Globals.Statistics.Block);
//                var chance = (rating / (((1190 / 3) * parent.Level) + rating)) * 100;

//                return chance > Game.Properties.GetProperty<int>("max_avoidance")
//                           ? Game.Properties.GetProperty<int>("max_avoidance")
//                           : chance;
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the Parry statistic, taking bonuses and stat mods
//        /// into account.
//        /// </summary>
//        public float Parry
//        {
//            get
//            {
//                //// Can be trained
//                //// Can be modified
//                //// Bonus based upon primary stats
//                //// -- Parry = (1/2 Level) + Agility Modifier + Strength Modifier + Other Modifiers
//                var parent = Owner as Biota;
//                if (parent.IsNull()) return 0;
//                var stat = GetStat(Globals.Globals.Statistics.Parry);
//                var statRating = (stat.IsNotNull()) ? stat.Rating : 0;
//                var rating = statRating + CalculateBonus(Globals.Globals.Statistics.Agility)
//                             + CalculateBonus(Globals.Globals.Statistics.Strength) +
//                             CalculateStatMods(Globals.Globals.Statistics.Parry);
//                var chance = (rating / (((1190 / 3) * parent.Level) + rating)) * 100;

//                return chance > Game.Properties.GetProperty<int>("max_avoidance")
//                           ? Game.Properties.GetProperty<int>("max_avoidance")
//                           : chance;
//            }
//        }

//        /// <summary>
//        /// Calculates the value of the passed parameter statistic including 
//        /// bonuses and stat mods.
//        /// </summary>
//        public int CalculateStat(Globals.Globals.Statistics type)
//        {
//            switch (type)
//            {
//                case Globals.Globals.Statistics.Dexterity:
//                case Globals.Globals.Statistics.Vitality:
//                case Globals.Globals.Statistics.Willpower:
//                case Globals.Globals.Statistics.Agility:
//                case Globals.Globals.Statistics.Endurance:
//                case Globals.Globals.Statistics.Strength:
//                case Globals.Globals.Statistics.Luck:
//                case Globals.Globals.Statistics.Spirit:
//                    return CalculateCoreStat(type);

//                case Globals.Globals.Statistics.Defense:
//                case Globals.Globals.Statistics.Faith:
//                case Globals.Globals.Statistics.Fortitude:
//                case Globals.Globals.Statistics.Warding:
//                    return CalculateDefenseStat(type);

//                case Globals.Globals.Statistics.Health:
//                    return MaximumHealth;
//                case Globals.Globals.Statistics.Mana:
//                    return MaximumMana;
//                case Globals.Globals.Statistics.Stamina:
//                    return MaximumStamina;

//                default:
//                    return 0;
//            }
//        }

//        /// <summary>
//        /// Calculates the total value of the given modifiers based upon the passed
//        /// parameter statistic and an optional name (which can be either a skill name or 
//        /// an element name).  Takes both effects and worn equipment into account.
//        /// </summary>
//        public int CalculateStatMods(Globals.Globals.Statistics stat, string name = "")
//        {
//            if (Owner.IsNull() || !(Owner is IBiota)) return 0;
//            var parent = Owner as IBiota;

//            var totalMod = 0;
//            var effectList = parent.EffectsHandler.GetEffects("statmod");
//            foreach (var instance in effectList)
//            {
//                var statMod = instance as StatModEffectInstance;
//                if (statMod.IsNull()) continue;
//                switch (statMod.Stat)
//                {
//                    case Globals.Globals.Statistics.Skill:
//                        if (statMod.Skill.IsNull())
//                            break;
//                        if (statMod.Skill.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
//                            totalMod += instance.Value;
//                        break;
//                    case Globals.Globals.Statistics.Element:
//                        break;
//                    default:
//                        if (statMod.Stat == stat)
//                            totalMod += instance.Value;
//                        break;
//                }
//            }
//            foreach (var item in parent.Inventory.Equipment.Values)
//            {
//                foreach (var itemStat in item.StatMods)
//                {
//                    if (itemStat == Globals.Globals.Statistics.Skill || itemStat == Globals.Globals.Statistics.Element) continue;
//                    if (itemStat == stat)
//                        totalMod += item.GetStatMod(itemStat);
//                }
//                totalMod += 0;
//            }

//            totalMod += parent.Race.IsNotNull() ? parent.Race.GetStatMod(stat) : 0;
//            var calcMod = CalculateElementMod(effectList, name);
//            calcMod += CalculateElementMod(Game.Effects.GetEffects("statmod"), name);
//            return Convert.ToInt32(Math.Round(calcMod));
//        }

//        /// <summary>
//        /// Calculates the bonus for the given statistic.  Takes stat mods into account.
//        /// </summary>
//        public int CalculateBonus(Globals.Globals.Statistics type)
//        {
//            var stat = GetStat(type);
//            var rating = (stat.IsNotNull() ? stat.Rating : 0) + CalculateStatMods(type);
//            return AttributeUtils.CalculateBonus(rating);
//        }

//        /// <summary>
//        /// Calculates the rate of regeneration for the Health statistic
//        /// </summary>
//        public float CalculateHealthRegen(bool inCombat = false)
//        {
//            if (inCombat)
//            {
//                return Game.Properties.GetProperty<int>("base_combat_health_regen_rate") +
//                    ((CalculateBonus(Globals.Globals.Statistics.Vitality) + CalculateBonus(Globals.Globals.Statistics.Endurance)) / 5);
//            }
//            return Game.Properties.GetProperty<int>("base_noncombat_health_regen_rate") +
//                ((CalculateBonus(Globals.Globals.Statistics.Vitality) + CalculateBonus(Globals.Globals.Statistics.Endurance)) / 2);
//        }

//        /// <summary>
//        /// Calculates the rate of regeneration for the Mana statistic
//        /// </summary>
//        public float CalculateManaRegen(bool inCombat = false)
//        {
//            if (inCombat)
//            {
//                return Game.Properties.GetProperty<int>("base_combat_mana_regen_rate") +
//                    (CalculateBonus(Globals.Globals.Statistics.Vitality) / 5);
//            }
//            return Game.Properties.GetProperty<int>("base_noncombat_mana_regen_rate") +
//                (CalculateBonus(Globals.Globals.Statistics.Vitality) / 2);
//        }


//        /// <summary>
//        /// Calculates the rate of regeneration for the Stamina statistic
//        /// </summary>
//        public float CalculateStaminaRegen(bool inCombat = false)
//        {
//            if (inCombat)
//            {
//                return Game.Properties.GetProperty<int>("base_combat_stamina_regen_rate") +
//                    (CalculateBonus(Globals.Globals.Statistics.Endurance) / 5);
//            }
//            return Game.Properties.GetProperty<int>("base_noncombat_stamina_regen_rate") +
//                (CalculateBonus(Globals.Globals.Statistics.Endurance) / 2);
//        }

//        /// <summary>
//        /// Takes a list of effects and compares their primary, opposite and complementary
//        /// element names to the passed name parameter.  Returns a value between 0.0 and 1.0
//        /// indicating the multiplier (1.0 for primary, 0.0 for opposite, and 0.5 for complementary).
//        /// </summary>
//        public float CalculateElementMod(IEnumerable<EffectInstance> effectList, string name)
//        {
//            var totalMod = 1.0f;
//            foreach (var statMod in effectList.OfType<StatModEffectInstance>()
//                .Where(statMod => statMod.Stat == Globals.Globals.Statistics.Element))
//            {
//                //// If the name matches, return the value
//                if (statMod.Element.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
//                    totalMod = 1.0f;

//                // if the name matches an opposite element, return 0
//                if (statMod.Element.GetOpposite().GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
//                {
//                    totalMod = 0.0f;
//                    continue;
//                }

//                // if the name matches a complementary element, return half the value
//                if (statMod.Element.GetLeft().GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
//                {
//                    totalMod = 0.5f;
//                    continue;
//                }
//                if (statMod.Element.GetRight().GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
//                {
//                    totalMod = 0.5f;
//                    continue;
//                }

//                totalMod = 1.0f;
//            }
//            return totalMod;
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
