//using System.Collections.Generic;
//using Realm.Server.Attributes;
//using Realm.Server.Effects;
//using Realm.Server.NPC;

//namespace Realm.Server.Contexts
//{
//    public interface IStatisticHandler
//    {
//        StatRepository Stats { get; }
//        SkillRepository Skills { get; }

//        bool AddSkill(string name, int rating, int pointsSpent);
//        SkillAttribute GetSkill(string name);
//        bool AddStat(string name, int rating, int pointsSpent);
//        StatAttribute GetStat(Globals.Globals.Statistics type);
//        int CalculateCoreStat(Globals.Globals.Statistics type);
//        int CalculateSkill(string name);
//        int CalculateGrossSkill(string name);
//        int CalculateDefenseStat(Globals.Globals.Statistics type);
//        int CalculateResistanceStat(Globals.Globals.Statistics type);
//        int Armor { get; }
//        int MaximumHealth { get; }
//        int MaximumMana { get; }
//        int MaximumStamina { get; }
//        float Dodge { get; }
//        float Block { get; }
//        float Parry { get; }
//        int CalculateStat(Globals.Globals.Statistics type);
//        int CalculateStatMods(Globals.Globals.Statistics stat, string name = "");
//        int CalculateBonus(Globals.Globals.Statistics type);
//        float CalculateHealthRegen(bool inCombat = false);
//        float CalculateManaRegen(bool inCombat = false);
//        float CalculateStaminaRegen(bool inCombat = false);
//        float CalculateElementMod(IEnumerable<EffectInstance> effectList, string name);
//    }
//}
