using System;
using System.Collections.Generic;
using System.Globalization;
using Ninject;
using Realm.Command;
using Realm.Command.Interfaces;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity.Entities.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;
using Realm.Server.NPC.Combat;
using Realm.Server.Properties;
using Realm.Time.Interfaces;

namespace Realm.Server.Commands
{
    public class VariableHelper : IVariableHelper
    {
        private readonly Dictionary<string, Delegate> _variableTable = new Dictionary<string, Delegate>();

        [Inject]
        public ITimeManager TimeManager { get; set; }

        /// <summary>
        /// Registers all of the in-game string variables and their associated functions
        /// </summary>
        public void RegisterVariables()
        {
            _variableTable.Add("$n", new Func<ReportData, string>(ParseActorName));
            _variableTable.Add("$N", new Func<ReportData, string>(ParseVictimName));
            _variableTable.Add("$o", new Func<ReportData, string>(ParseDirectObjectName));
            _variableTable.Add("$O", new Func<ReportData, string>(ParseIndirectObjectName));
            _variableTable.Add("$q", new Func<ReportData, string>(ParseDirectObjectPluralName));
            _variableTable.Add("$Q", new Func<ReportData, string>(ParseIndirectObjectPluralName));
            _variableTable.Add("$i", new Func<ReportData, string>(ParseDirectObjectId));
            _variableTable.Add("$I", new Func<ReportData, string>(ParseIndirectObjectId));
            _variableTable.Add("$a", new Func<ReportData, string>(AddArticleToActorName));
            _variableTable.Add("$A", new Func<ReportData, string>(AddArticleToVictimName));
            _variableTable.Add("$t", new Func<ReportData, string>(AddTheToActorName));
            _variableTable.Add("$T", new Func<ReportData, string>(AddTheToVictimName));
            _variableTable.Add("$e", new Func<ReportData, string>(ParseActorSubjectPronoun));
            _variableTable.Add("$E", new Func<ReportData, string>(ParseVictimSubjectPronoun));
            _variableTable.Add("$m", new Func<ReportData, string>(ParseActorObjectPronoun));
            _variableTable.Add("$M", new Func<ReportData, string>(ParseVictimObjectPronoun));
            _variableTable.Add("$s", new Func<ReportData, string>(ParseActorPossessivePronoun));
            _variableTable.Add("$S", new Func<ReportData, string>(ParseVictimPossessivePronoun));
            _variableTable.Add("$r", new Func<ReportData, string>(ParseActorReflexivePronoun));
            _variableTable.Add("$R", new Func<ReportData, string>(ParseVictimReflexivePronoun));
            _variableTable.Add("$d", new Func<ReportData, string>(ParseDirectionOfMovement));
            _variableTable.Add("$D", new Func<ReportData, string>(ParseReverseDirectionOfMovement));
            _variableTable.Add("$p", new Func<ReportData, string>(ParseActorPosition));
            _variableTable.Add("$P", new Func<ReportData, string>(ParseVictimPosition));
            _variableTable.Add("$y", new Func<ReportData, string>(ParseActorMovementMode));
            _variableTable.Add("$Y", new Func<ReportData, string>(ParseVictimMovementMode));
            _variableTable.Add("$w", new Func<ReportData, string>(WearLocationShortName));
            _variableTable.Add("$W", new Func<ReportData, string>(WearLocationLongName));
            _variableTable.Add("$G", new Func<ReportData, string>(ParseDamageDetails));

            _variableTable.Add("%i", new Func<ReportData, string>(ParseDirectObjectValue<int>));
            _variableTable.Add("%I", new Func<ReportData, string>(ParseIndirectObjectValue<int>));
            _variableTable.Add("%f", new Func<ReportData, string>(ParseDirectObjectValue<float>));
            _variableTable.Add("%F", new Func<ReportData, string>(ParseIndirectObjectValue<float>));
            _variableTable.Add("%l", new Func<ReportData, string>(ParseDirectObjectValue<long>));
            _variableTable.Add("%L", new Func<ReportData, string>(ParseIndirectObjectValue<long>));
            _variableTable.Add("%s", new Func<ReportData, string>(ParseDirectObjectValue<string>));
            _variableTable.Add("%S", new Func<ReportData, string>(ParseIndirectObjectValue<string>));
            _variableTable.Add("%t", new Func<ReportData, string>(ParseExtraObjectValue<int>));
            _variableTable.Add("%T", new Func<ReportData, string>(ParseExtraObjectValue<string>));
            _variableTable.Add("%q", new Func<ReportData, string>(ParseNumberToWords));
            _variableTable.Add("%c", new Func<ReportData, string>(ParseQuantityToCurrency));
            _variableTable.Add("%h", new Func<ReportData, string>(ParseGameHourOfDay));
            _variableTable.Add("%H", new Func<ReportData, string>(ParseGameTimeOfDay));
            _variableTable.Add("%m", new Func<ReportData, string>(ParseGameDayOfMonth));
            _variableTable.Add("%M", new Func<ReportData, string>(ParseGameNameOfMonth));
            _variableTable.Add("%Y", new Func<ReportData, string>(ParseGameYear));
        }

        /// <summary>
        /// Retrieve the delegate from the Variable table
        /// </summary>
        public Delegate GetDelegate(string var)
        {
            return _variableTable.ContainsKey(var) ? _variableTable[var] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count => _variableTable.Count;

        /// <summary>
        /// Variable is $n, name of the object doing the acting
        /// </summary>
        public string ParseActorName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var cell = data.Actor as ICell;
            return cell.IsNull() ? string.Empty : cell.Name;
        }

        /// <summary>
        /// Variable $N, name of the object being acted upon
        /// </summary>
        public string ParseVictimName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var cell = data.Victim as ICell;
            return cell.IsNull() ? string.Empty : cell.Name;
        }

        /// <summary>
        /// Variable $o, name of the object being used in the act by $n
        /// </summary>
        public string ParseDirectObjectName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var obj = data.DirectObject as IEntity;
            return obj.IsNull() ? string.Empty : obj.Name;
        }

        /// <summary>
        /// Variable $O, name of the object being used in the act by $N
        /// </summary>
        public string ParseIndirectObjectName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var obj = data.IndirectObject as IEntity;
            return obj.IsNull() ? string.Empty : obj.Name;
        }

        /// <summary>
        /// Variable $q, plural name of the object used by $n
        /// </summary>
        public string ParseDirectObjectPluralName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var _object = data.DirectObject as IEntity;
            if (_object.IsNull()) return string.Empty;
            if (_object is IGameEntity)
            {
                var go = _object as IGameEntity;
                if (string.IsNullOrEmpty(go.PluralName))
                    return _object.Name + "s";
                return go.PluralName;
            }
            return _object.Name;
        }

        /// <summary>
        /// Variable $Q, plural name of the object used by $N
        /// </summary>
        public static string ParseIndirectObjectPluralName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var _object = data.IndirectObject as IEntity;
            if (_object.IsNull()) return string.Empty;
            if (_object is IGameEntity)
            {
                var go = _object as IGameEntity;
                if (string.IsNullOrEmpty(go.PluralName))
                    return _object.Name + "s";
                return go.PluralName;
            }
            return _object.Name;
        }

        /// <summary>
        /// Variable $i, ID of the object used by $n
        /// </summary>
        public static string ParseDirectObjectId(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var _object = data.DirectObject as IEntity;
            return _object.IsNotNull() ? _object.ID.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        /// <summary>
        /// Variable $I, ID of the object used by $N
        /// </summary>
        public static string ParseIndirectObjectId(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var _object = data.IndirectObject as IEntity;
            return _object.IsNotNull() ? _object.ID.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        /// <summary>
        /// Variable $a, append article (a or an) to name of $n
        /// </summary>
        public static string AddArticleToActorName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var cell = data.Actor as ICell;
            return cell.IsNull() ? string.Empty : cell.Name.AddArticle();
        }

        /// <summary>
        /// Variable $A, append article (a or an) to name of $N
        /// </summary>
        public static string AddArticleToVictimName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var cell = data.Victim as ICell;
            return cell.IsNull() ? string.Empty : cell.Name.AddArticle();
        }

        /// <summary>
        /// Variable $t, append article (the) to name of $N
        /// </summary>
        public static string AddTheToActorName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var cell = data.Actor as ICell;
            return cell.IsNull() ? string.Empty : cell.Name.AddArticle(ArticleAppendOptions.TheToFront);
        }

        /// <summary>
        /// Variable $T, append article (the) to name of $N
        /// </summary>
        public static string AddTheToVictimName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var cell = data.Victim as ICell;
            return cell.IsNull() ? string.Empty : cell.Name.AddArticle(ArticleAppendOptions.TheToFront);
        }

        /// <summary>
        /// Variable $e, subject pronoun based on gender of $n
        /// </summary>
        public static string ParseActorSubjectPronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Actor is IBiota)
            {
                var biote = data.Actor as IBiota;
                return biote.Gender.SubjectPronoun();
            }
            return "it";
        }

        /// <summary>
        /// Variable $E, subject pronoun based on gender of $N
        /// </summary>
        public static string ParseVictimSubjectPronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Victim is IBiota)
            {
                var biote = data.Victim as IBiota;
                return biote.Gender.SubjectPronoun();
            }
            return "it";
        }

        /// <summary>
        /// Variable $m, object pronoun based on gender of $n
        /// </summary>
        private string ParseActorObjectPronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Actor is IBiota)
            {
                var biote = data.Actor as IBiota;
                return biote.Gender.ObjectPronoun();
            }
            return "it";
        }

        /// <summary>
        /// Variable $M, object pronoun based on gender of $N
        /// </summary>
        private string ParseVictimObjectPronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Victim is IBiota)
            {
                var biote = data.Victim as IBiota;
                return biote.Gender.ObjectPronoun();
            }
            return "it";
        }

        /// <summary>
        /// Variable $s, possessive pronoun based on gender of $n
        /// </summary>
        private string ParseActorPossessivePronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Actor is IBiota)
            {
                var biote = data.Actor as IBiota;
                return biote.Gender.PossessivePronoun();
            }
            return "its";
        }

        /// <summary>
        /// Variable $S, possessive pronoun based on gender of $N
        /// </summary>
        private string ParseVictimPossessivePronoun(ReportData data)
        {
            if (data.Victim is IBiota)
            {
                var biote = data.Victim as IBiota;
                return biote.Gender.PossessivePronoun();
            }
            return "its";
        }

        /// <summary>
        /// Variable $r, reflexive pronoun based on gender of $n
        /// </summary>
        private string ParseActorReflexivePronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Actor is IBiota)
            {
                var biote = data.Actor as IBiota;
                return biote.Gender.ReflexivePronoun();
            }
            return "itself";
        }

        /// <summary>
        /// Variable $R, reflexive pronoun based on gender of $N
        /// </summary>
        private string ParseVictimReflexivePronoun(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Victim is IBiota)
            {
                var biote = data.Victim as IBiota;
                return biote.Gender.ReflexivePronoun();
            }
            return "itself";
        }

        /// <summary>
        /// Variable $d, direction of movement of object
        /// </summary>
        private string ParseDirectionOfMovement(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var oExit = data.DirectObject as PortalDef;
            return oExit.IsNull() ? string.Empty : oExit.Direction.GetName();
        }

        /// <summary>
        /// Variable $D, reverse direction of movement of object
        /// </summary>
        private string ParseReverseDirectionOfMovement(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var oExit = data.DirectObject as PortalDef;
            return oExit.IsNull() ? string.Empty : oExit.Direction.GetOpposite();
        }

        /// <summary>
        /// Variable $p, position of the actor
        /// </summary>
        private string ParseActorPosition(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Actor is IBiota)
            {
                var biote = data.Actor as IBiota;
                return biote.Position.GetName();
            }
            return string.Empty;
        }

        /// <summary>
        /// Variable $P, position of the victim
        /// </summary>
        private string ParseVictimPosition(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Victim is IBiota)
            {
                var biote = data.Victim as IBiota;
                return biote.Position.GetName();
            }
            return string.Empty;
        }

        /// <summary>
        /// Variable $y, movement mode of the actor
        /// </summary>
        private string ParseActorMovementMode(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Actor is IBiota)
            {
                var biote = data.Actor as IBiota;
                return biote.Movement.GetShortName();
            }
            return string.Empty;
        }

        /// <summary>
        /// Variable $Y, movement mode of the victim
        /// </summary>
        private string ParseVictimMovementMode(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            if (data.Victim is IBiota)
            {
                var biote = data.Victim as IBiota;
                return biote.Movement.GetShortName();
            }
            return string.Empty;
        }

        /// <summary>
        /// Variable $w, short name of the wear location
        /// </summary>
        private string WearLocationShortName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var loc = data.IndirectObject as string;
            return EnumerationExtensions.GetEnum<Globals.WearLocations>(loc).GetShortName();
        }

        /// <summary>
        /// Variable $W, long name of the wear location
        /// </summary>
        private string WearLocationLongName(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var loc = data.IndirectObject as string;
            return EnumerationExtensions.GetEnum<Globals.WearLocations>(loc).GetExtraData();
        }

        /// <summary>
        /// Variable $G, damage details
        /// </summary>
        private string ParseDamageDetails(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            var dmg = data.IndirectObject as Damage;
            return dmg.IsNull() ? string.Empty : dmg.DamageAmount + " " + dmg.DamageType.ToString().ToLower();
        }

        /// <summary>
        /// Variable (%i, %f, %l, %s), value from direct object
        /// </summary>
        private string ParseDirectObjectValue<T>(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            try
            {
                return ((T)data.DirectObject).ToString();
            }
            catch (InvalidCastException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Variable (%I, %F, %L, %S), value from indirect object
        /// </summary>
        private string ParseIndirectObjectValue<T>(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            try
            {
                return ((T)data.DirectObject).ToString();
            }
            catch (InvalidCastException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Variable (%t, %T), value from extra object
        /// </summary>
        private string ParseExtraObjectValue<T>(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            try
            {
                return ((T)data.Extra).ToString();
            }
            catch (InvalidCastException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Variable %q, convert numerical value to string name
        /// </summary>
        private string ParseNumberToWords(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            try
            {
                return ((int)data.Extra).ToWords();
            }
            catch (InvalidCastException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///  Variable %c, convert numerical value to currency
        /// </summary>
        private string ParseQuantityToCurrency(ReportData data)
        {
            if (data.IsNull())
                throw new ArgumentNullException(nameof(data), ErrorResources.ERR_NULL_PARAMETER);

            try
            {
                var value = (int)data.Extra;
                return Currency.ConvertCurrency(value, false);
            }
            catch (InvalidCastException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Variable %h, Hour of the game day
        /// </summary>
        private string ParseGameHourOfDay(ReportData data)
        {
            return TimeManager.CurrentGameState.DateTime.Hour.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Variable %H, Full time of the game day
        /// </summary>
        private string ParseGameTimeOfDay(ReportData data)
        {
            return TimeManager.CurrentGameState.DateTime.ToString();
        }

        /// <summary>
        /// Variable %m, day of game month
        /// </summary>
        private string ParseGameDayOfMonth(ReportData data)
        {
            return TimeManager.CurrentGameState.DateTime.Day.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Variable %M, Name of game month
        /// </summary>
        private string ParseGameNameOfMonth(ReportData data)
        {
            return TimeManager.CurrentGameState.Month.DisplayName;
        }

        /// <summary>
        /// Variable %Y, year of game
        /// </summary>
        private string ParseGameYear(ReportData data)
        {
            return TimeManager.CurrentGameState.DateTime.Year.ToString(CultureInfo.InvariantCulture);
        }
    }
}
