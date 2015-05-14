using System;
using Realm.Library.Common;

namespace Realm.Data
{
    // ReSharper disable CSharpWarnings::CS1591
    public static class GlobalsExtensions
    // ReSharper restore CSharpWarnings::CS1591
    {
        #region Wear Locations

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CompareName(this Globals.Globals.WearLocations value, string str)
        {
            Validation.IsNotNullOrEmpty(str, "str");

            return value.GetName().Equals(str) || value.GetShortName().Equals(str);
        }

        #endregion Wear Locations

        #region Element Types

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Globals.Globals.ElementTypes GetOpposite(this Globals.Globals.ElementTypes value)
        {
            var vals = value.GetExtraData().Split(new[] { ':', ';' });

            //Validation.Validate<InvalidDataException>(vals.All(x => !string.IsNullOrWhiteSpace(x)), ErrorResources.ERR_NULL_EXTRA_DATA, value.GetName());
            //Validation.Validate<InvalidDataException>(vals.Length >= 1, ErrorResources.ERR_NULL_EXTRA_DATA,
            //                                          value.GetName());

            return EnumerationExtensions.GetEnum<Globals.Globals.ElementTypes>(Convert.ToInt32(vals[0]) - 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Globals.Globals.ElementTypes GetLeft(this Globals.Globals.ElementTypes value)
        {
            var vals = value.GetExtraData().Split(new[] { ';', ':' });

            //Validation.Validate<InvalidDataException>(vals.All(x => !string.IsNullOrWhiteSpace(x)), ErrorResources.ERR_NULL_EXTRA_DATA, value.GetName());
            //Validation.Validate<InvalidDataException>(vals.Length >= 1, ErrorResources.ERR_NULL_EXTRA_DATA,
            //                                          value.GetName());

            return EnumerationExtensions.GetEnum<Globals.Globals.ElementTypes>(Convert.ToInt32(vals[1]) - 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Globals.Globals.ElementTypes GetRight(this Globals.Globals.ElementTypes value)
        {
            var vals = value.GetExtraData().Split(new[] { ':', ';' });

            //Validation.Validate<InvalidDataException>(vals.All(x => !string.IsNullOrWhiteSpace(x)), ErrorResources.ERR_NULL_EXTRA_DATA, value.GetName());
            //Validation.Validate<InvalidDataException>(vals.Length >= 1, ErrorResources.ERR_NULL_EXTRA_DATA,
            //                                          value.GetName());

            return EnumerationExtensions.GetEnum<Globals.Globals.ElementTypes>(Convert.ToInt32(vals[2]) - 1);
        }

        #endregion Element Types

        #region Skill Test Result Types

        /// <summary>
        /// Calculates the XP result given the outcome of the skill use and the base XP
        /// </summary>
        /// <param name="result"></param>
        /// <param name="xp"></param>
        /// <returns></returns>
        public static float CalculateXpResult(this Globals.Globals.SkillTestResultTypes result, Single xp)
        {
            Validation.Validate<ArgumentOutOfRangeException>(xp >= 1 && xp <= Single.MaxValue);

            switch (result)
            {
                case Globals.Globals.SkillTestResultTypes.CriticalFailure:
                    return xp * 0.5f;
                case Globals.Globals.SkillTestResultTypes.CriticalSuccess:
                    return xp * 1.5f;
                default:
                    return xp;
            }
        }

        #endregion Skill Test Result Types

        #region Directions

        /// <summary>
        /// Gets the opposite direction than the direction enum
        /// </summary>
        /// <param name="value">Enumeration reference</param>
        /// <returns>Returns a string name of the reverse direction</returns>
        public static string GetOpposite(this Globals.Globals.Directions value)
        {
            switch (value)
            {
                case Globals.Globals.Directions.Down:
                    return "up";
                case Globals.Globals.Directions.Up:
                    return "down";
                case Globals.Globals.Directions.West:
                    return "east";
                case Globals.Globals.Directions.East:
                    return "west";
                case Globals.Globals.Directions.North:
                    return "south";
                case Globals.Globals.Directions.South:
                    return "north";
                case Globals.Globals.Directions.Northeast:
                    return "southwest";
                case Globals.Globals.Directions.Southwest:
                    return "northeast";
                case Globals.Globals.Directions.Northwest:
                    return "southeast";
                case Globals.Globals.Directions.Southeast:
                    return "northwest";
                default:
                    return "none";
            }
        }

        #endregion Directions

        #region Gender Types

        /// <summary>
        /// Converts the given Gender to a Subject Pronoun string
        /// </summary>
        /// <param name="type">The type of Gender</param>
        /// <returns>Returns a string representing the subject pronoun</returns>
        public static string SubjectPronoun(this Globals.Globals.GenderTypes type)
        {
            switch (type)
            {
                case Globals.Globals.GenderTypes.Male:
                    return "he";
                case Globals.Globals.GenderTypes.Female:
                    return "she";
                default:
                    return "it";
            }
        }

        /// <summary>
        /// Converts the given Gender to a Object Pronoun string
        /// </summary>
        /// <param name="type">The type of Gender</param>
        /// <returns>Returns a string representing the object pronoun</returns>
        public static string ObjectPronoun(this Globals.Globals.GenderTypes type)
        {
            switch (type)
            {
                case Globals.Globals.GenderTypes.Male:
                    return "him";
                case Globals.Globals.GenderTypes.Female:
                    return "her";
                default:
                    return "it";
            }
        }

        /// <summary>
        /// Converts the given Gender to a Possessive Pronoun string
        /// </summary>
        /// <param name="type">The type of Gender</param>
        /// <returns>Returns a string representing the possessive pronoun</returns>
        public static string PossessivePronoun(this Globals.Globals.GenderTypes type)
        {
            switch (type)
            {
                case Globals.Globals.GenderTypes.Male:
                    return "his";
                case Globals.Globals.GenderTypes.Female:
                    return "hers";
                default:
                    return "its";
            }
        }

        /// <summary>
        /// Converts the given Gender to a Reflexive Pronoun string
        /// </summary>
        /// <param name="type">The type of Gender</param>
        /// <returns>Returns a string representing the reflexive pronoun</returns>
        public static string ReflexivePronoun(this Globals.Globals.GenderTypes type)
        {
            switch (type)
            {
                case Globals.Globals.GenderTypes.Male:
                    return "himself";
                case Globals.Globals.GenderTypes.Female:
                    return "herself";
                default:
                    return "itself";
            }
        }

        #endregion Gender Types
    }
}