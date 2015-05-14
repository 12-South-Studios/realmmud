//// ----------------------------------------------------------------------
//// <copyright file="StatModEffectTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;
//using Realm.Server.Attributes;

//namespace Realm.Server.Effects.Templates
//{
//    public class StatModEffectTemplate : EffectTemplate
//    {
//        public StatModEffectTemplate(long id, string name)
//            : base(id, name) 
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("StatMod");
//        }

//        public Globals.Globals.Statistics Stat
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Properties.GetProperty<string>("statistic")); }
//            set { Properties.SetProperty("statistic", value.GetName()); }
//        }

//        public Skill Skill
//        {
//            get { return Stat != Globals.Globals.Statistics.Skill ? null : (Skill)DataManager.Get("Skills", Properties.GetProperty<string>("skill")); }
//            set { Properties.SetProperty("skill", value.ToString()); }
//        }

//        public Globals.Globals.ElementTypes Element
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.ElementTypes>(Properties.GetProperty<string>("element"));
//            }
//            set { Properties.SetProperty("element", value.ToString()); }
//        }

//        public int MinValue
//        {
//            get { return Properties.GetProperty<int>("min_value"); }
//            set { Properties.SetProperty("min_value", value); }
//        }

//        public int MaxValue
//        {
//            get { return Properties.GetProperty<int>("max_value"); }
//            set { Properties.SetProperty("max_value", value); }
//        } 
//    }
//}
