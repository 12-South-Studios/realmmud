//// ----------------------------------------------------------------------
//// <copyright file="StatusEffectEffectTemplate.cs" company="12-South Studios">
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
//    public class StatusEffectEffectTemplate : EffectTemplate
//    {
//        public StatusEffectEffectTemplate(long id, string name)
//            : base(id, name) 
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("StatusEffect");
//        }

//        public Globals.Globals.StatusEffectTypes StatusEffect 
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.StatusEffectTypes>(Properties.GetProperty<string>("status_effect")); }
//            set { Properties.SetProperty("status_effect", value.GetName()); }
//        }
//    }
//}
