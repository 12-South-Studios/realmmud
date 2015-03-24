//// ----------------------------------------------------------------------
//// <copyright file="StatModOverTimeEffectTemplate.cs" company="12-South Studios">
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
//    public class StatModChangeOverTimeEffectTemplate : EffectTemplate
//    {
//        public StatModChangeOverTimeEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("StatModChangeOverTime");
//        }

//        public int NumberTicks
//        {
//            get { return Properties.GetProperty<int>("number_ticks"); }
//            set { Properties.SetProperty("number_ticks", value); }
//        }

//        public long EffectId
//        {
//            get { return Properties.GetProperty<long>("effect_id"); }
//            set { Properties.SetProperty("effect_id", value); }
//        }
//    }
//}
