//// ----------------------------------------------------------------------
//// <copyright file="DrainStatEffectTemplate.cs" company="12-South Studios">
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
//    public class DrainStatEffectTemplate : EffectTemplate
//    {
//        public DrainStatEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("DrainStat");
//        }

//        public long StatId
//        {
//            get { return Properties.GetProperty<long>("drain_stat"); }
//            set { Properties.SetProperty("drain_stat", value); }
//        }

//        public int Minimum
//        {
//            get { return Properties.GetProperty<int>("drain_min"); }
//            set { Properties.SetProperty("drain_min", value); }
//        }

//        public int Maximum
//        {
//            get { return Properties.GetProperty<int>("drain_max"); }
//            set { Properties.SetProperty("drain_max", value); }
//        }
//    }
//}
