using System;
using Realm.Data;

namespace Realm.Server.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public static class AttributeUtils
    {
        /// <summary>
        /// Executes a skill check using the given ratings and returns a populated
        /// skill result (with test result and final xp).
        /// </summary>
        /// <param name="sourceRating">Rating of the Source</param>
        /// <param name="targetRating">Rating of the Target</param>
        /// <param name="xpValue">XP Gain for the Action</param>
        /// <param name="ignoreSkillCheck">(Optional) Skips the actual skill check and just does the XP calculations</param>
        /// <returns>Enumeration Skill Result</returns>
        public static SkillResult Check(int sourceRating, int targetRating,
            int xpValue, bool ignoreSkillCheck = false)
        {
            var result = new SkillResult();

            if (ignoreSkillCheck)
            {
                result.Xp = CalculateXp(sourceRating, targetRating,
                    Globals.SkillTestResultTypes.Success, xpValue);
                result.Result = Globals.SkillTestResultTypes.Success;
            }
            else
            {
                var skillCheck = sourceRating + Library.Common.Random.D100(1) - targetRating;
                if (skillCheck <= -100)
                {
                    result.Xp = CalculateXp(sourceRating, targetRating,
                        Globals.SkillTestResultTypes.CriticalFailure, xpValue);
                    result.Result = Globals.SkillTestResultTypes.CriticalFailure;
                }
                else if (skillCheck <= 0)
                {
                    result.Xp = CalculateXp(sourceRating, targetRating,
                        Globals.SkillTestResultTypes.Failure, xpValue);
                    result.Result = Globals.SkillTestResultTypes.Failure;
                }
                else if (skillCheck >= 100)
                {
                    result.Xp = CalculateXp(sourceRating, targetRating,
                        Globals.SkillTestResultTypes.CriticalSuccess, xpValue);
                    result.Result = Globals.SkillTestResultTypes.CriticalSuccess;
                }
                else
                {
                    result.Xp = CalculateXp(sourceRating, targetRating,
                        Globals.SkillTestResultTypes.Success, xpValue);
                    result.Result = Globals.SkillTestResultTypes.Success;
                } 
            }

            return result;
        }

        /// <summary>
        /// Calculates the final (modified) Xp result for the skill use.
        /// </summary>
        /// <param name="sourceRating"></param>
        /// <param name="targetRating"></param>
        /// <param name="testResult">Skill result</param>
        /// <param name="baseXpValue">Base Xp gain for the calculations</param>
        /// <returns>Integer value representing the final (modified) Xp gain</returns>
        /// <remarks>
        /// Skills grow through use and this is calculated by awarding "Skill XP" using 
        /// the difference between the absolute value of the source and target ratings 
        /// where a higher source rating results in lower % of XP applied and a higher 
        /// target rating results in a higher % of XP applied.  In addition, the test
        /// result type also impacts the final XP value with CriticalSuccess results
        /// increasing the final result by 150% and CriticalFailures lowering that same 
        /// result by 50%.
        ///</remarks>
        public static int CalculateXp(int sourceRating, int targetRating,
            Globals.SkillTestResultTypes testResult, int baseXpValue)
        {
            float modifiedXp;
            var skillDiff = Math.Abs(sourceRating - targetRating);
            if (skillDiff == 0)
            {
                // no difference, so XP value is given straight up
                modifiedXp = testResult.CalculateXpResult(baseXpValue);
            }
            else
            {
                if (sourceRating >= targetRating)
                {
                    modifiedXp = baseXpValue * CalculateXpMultiplier(skillDiff);
                    if (modifiedXp <= 0)
                        modifiedXp = 1;
                    modifiedXp = testResult.CalculateXpResult(modifiedXp);
                }
                else
                {
                    modifiedXp = baseXpValue + baseXpValue * CalculateXpMultiplier(skillDiff);
                    modifiedXp = testResult.CalculateXpResult(modifiedXp);
                }
            }
            return (int)modifiedXp;
        }

        /// <summary>
        /// Calculates the XP multiplier, which takes the absolute value of the skill 
        /// difference into account.
        /// </summary>
        /// <param name="skillDiff"></param>
        /// <returns></returns>
        public static Single CalculateXpMultiplier(int skillDiff)
        {
            if (skillDiff <= 10) return 1.0f;
            if (skillDiff <= 20) return 0.9f;
            if (skillDiff <= 30) return 0.8f;
            if (skillDiff <= 40) return 0.7f;
            if (skillDiff <= 50) return 0.6f;
            if (skillDiff <= 60) return 0.5f;
            if (skillDiff <= 70) return 0.4f;
            if (skillDiff <= 80) return 0.3f;
            if (skillDiff <= 90) return 0.2f;
            return skillDiff <= 100 ? 0.1f : 0.01f;
        }

        /// <summary>
        /// Calculates the bonus value of an attribute based upon the passed rating.
        /// This may not be applicable in all cases.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public static int CalculateBonus(int rating)
        {
            return (int)Math.Round((double)(-6 + rating / 2));
        }
    }
}
