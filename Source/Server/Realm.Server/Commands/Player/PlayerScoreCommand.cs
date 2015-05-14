//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Effects;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Score command
//    /// </summary>
//    public class PlayerScoreCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerScoreCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerScoreCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();

//            var showAttributes = false;
//            var showSkills = false;
//            var showEffects = false;
//            var showDefenses = false;

//            var phrase = oUser.GetLastCommand();
//            if (!string.IsNullOrEmpty(phrase))
//            {
//                var words = phrase.Split(' ');
//                foreach (var word in words)
//                {
//                    if (word.Equals("-a"))
//                        showAttributes = true;
//                    if (word.Equals("-s"))
//                        showSkills = true;
//                    if (word.Equals("-e"))
//                        showEffects = true;
//                    if (word.Equals("-d"))
//                        showDefenses = true;
//                }
//            }

//            var character = oUser.GetCurrentCharacter();

//            var sb = new StringBuilder();
//            sb.Append(Environment.NewLine);
//            sb.Append("*==========================================================*");

//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("|  {0} (Level {1} {2})", character.FullName, character.Level, character.CurrentArchetype.Name.CapitalizeFirst());
//            sb.Append(Environment.NewLine);
//            sb.Append("------------------------------------------------------------");
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| XP Earned:     {0} (for next level: {1})", character.CurrentXp, character.NeededForNextLevel());
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Health:        {0} / {1}", character.CurrentHealth, character.StatisticHandler.MaximumHealth);
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Mana:          {0} / {1}", character.CurrentMana, character.StatisticHandler.MaximumMana);
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Stamina:       {0} / {1}", character.CurrentStamina, character.StatisticHandler.MaximumStamina);
//            sb.Append(Environment.NewLine);
//            sb.Append("------------------------------------------------------------");
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Health Regen:  {0}/s, {1}/s", character.StatisticHandler.CalculateHealthRegen(), character.StatisticHandler.CalculateHealthRegen(true));
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Mana Regen:    {0}/s, {1}/s", character.StatisticHandler.CalculateManaRegen(), character.StatisticHandler.CalculateManaRegen(true));
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Stamina Regen: {0}/s, {1}/s", character.StatisticHandler.CalculateStaminaRegen(), character.StatisticHandler.CalculateStaminaRegen(true));
//            sb.Append(Environment.NewLine);
//            sb.Append("------------------------------------------------------------");
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Coins:         {0}", Currency.ConvertCurrency(character.Value, true));
//            sb.Append(Environment.NewLine);
//            sb.AppendFormat("| Training Pts:  {0} / {1}", character.GetIntProperty("training_points_unspent"), character.GetIntProperty("training_points_spent"));
//            sb.Append(Environment.NewLine);

//            var ability = character.AutoAttackAbility;
//            sb.AppendFormat("| Auto-Attack:   {0}", ability.Name.CapitalizeFirst());
//            sb.Append(Environment.NewLine);

//            var boundSpace = character.GetIntProperty("bind_location");
//            if (boundSpace > 0)
//            {
//                var Space = EntityManager.LuaGetConcrete(boundSpace) as Space;
//                if (Space.IsNotNull())
//                    sb.AppendFormat("| Bound To:      {0} ({1})", Space.Name, Space.MyZone.Name);
//            }
//            else
//            {
//                var Space = EntityManager.LuaGetConcrete(Game.GetProperty<int>("startSpaceId")) as Space;
//                if (Space.IsNotNull())
//                    sb.AppendFormat("| Bound To:      {0} ({1})", Space.Name, Space.MyZone.Name);
//            }

//            if (!showAttributes && !showSkills && !showEffects && !showDefenses)
//            {
//                sb.Append(Environment.NewLine);
//                sb.Append("*==========================================================*");
//            }
//            else
//            {
//                if (showAttributes)
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append("------------------------------------------------------------");
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Attributes (Mental):");
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Dexterity:  {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Dexterity), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Dexterity));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Vitality:   {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Vitality), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Vitality));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Willpower:  {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Willpower), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Willpower));
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Attributes (Physical):");                    
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Agility:    {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Agility), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Agility));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Endurance:  {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Endurance), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Endurance));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Strength:   {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Strength), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Strength));
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Attributes (Other):");
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Luck:       {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Luck), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Luck));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Spirit:     {0} ({1})", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Spirit), character.StatisticHandler.CalculateBonus(Globals.Globals.Statistics.Spirit));
//                }

//                if (showDefenses)
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append("------------------------------------------------------------");
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("| Armor Rating:   {0}", character.StatisticHandler.Armor);
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Avoidance:");
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Block:      {0}%", character.StatisticHandler.Block);
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Parry:      {0}%", character.StatisticHandler.Parry);
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Dodge:      {0}%", character.StatisticHandler.Dodge);
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Defenses:");
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Defense:    {0}", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Defense));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Faith:      {0}", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Faith));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Fortitude:  {0}", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Fortitude));
//                    sb.Append(Environment.NewLine);
//                    sb.AppendFormat("|     Warding:    {0}", character.StatisticHandler.CalculateStat(Globals.Globals.Statistics.Warding));
//                }

//                if (showEffects)
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append("------------------------------------------------------------");
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Buffs / Debuffs:");

//                    foreach (var entity in character.EffectsHandler.Entities)
//                    {
//                        var effect = entity as EffectInstance;
//                        if (effect.IsNull()) continue;
//                        sb.Append(Environment.NewLine);
//                        sb.AppendFormat("|  {0}, expires in {1} ticks.", effect.Name.CapitalizeFirst(), effect.TimeLeft);
//                    }
//                }

//                if (showSkills)
//                {
//                    sb.Append(Environment.NewLine);
//                    sb.Append("------------------------------------------------------------");
//                    sb.Append(Environment.NewLine);
//                    sb.Append("| Skills:");

//                    foreach (var skillName in character.StatisticHandler.Skills.Keys)
//                    {
//                        sb.Append(Environment.NewLine);
//                        sb.AppendFormat("|  {0} (Rank {1})", skillName.CapitalizeFirst(), character.StatisticHandler.CalculateSkill(skillName));
//                    }
//                }

//                sb.Append(Environment.NewLine);
//                sb.Append("*==========================================================*");
//            }

//            CommandManager.ReportToCharacter(sb.ToString(), oUser);
//        }
//    }
//}
