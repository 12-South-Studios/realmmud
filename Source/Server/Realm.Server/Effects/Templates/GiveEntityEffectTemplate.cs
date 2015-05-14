//// ----------------------------------------------------------------------
//// <copyright file="GiveEntityEffectTemplate.cs" company="12-South Studios">
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
//    public class GiveEntityEffectTemplate : EffectTemplate
//    {
//        public GiveEntityEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("GiveEntity");
//        }

//        public long EffectId
//        {
//            get { return Properties.GetProperty<long>("give_effect_id"); }
//            set { Properties.SetProperty("give_effect_id", value); }
//        }
//    }
//}
