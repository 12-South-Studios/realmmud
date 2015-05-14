//// ----------------------------------------------------------------------
//// <copyright file="GiveAbilityEffectTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;

//namespace Realm.Server.Effects.Templates
//{
//    public class GiveAbilityEffectTemplate : EffectTemplate
//    {
//        public GiveAbilityEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("GiveAbility");
//        }

//        public long AbilityId
//        {
//            get { return Properties.GetProperty<long>("give_ability_id"); }
//            set { Properties.SetProperty("give_ability_id", value); }
//        }
//    }
//}
