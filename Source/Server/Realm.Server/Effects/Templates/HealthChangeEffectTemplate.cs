//// ----------------------------------------------------------------------
//// <copyright file="HealthChangeEffectTemplate.cs" company="12-South Studios">
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
//    public class HealthChangeEffectTemplate : EffectTemplate
//    {
//        public HealthChangeEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("HealthChange");
//        }

//        public Globals.Globals.HealthChangeTypes HealthChange
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.HealthChangeTypes>(Properties.GetProperty<string>("health_change_type")); }
//            set { Properties.SetProperty("health_change_type", value.GetName()); }
//        }

//        public int MinDamage
//        {
//            get { return Properties.GetProperty<int>("min_damage"); }
//            set { Properties.SetProperty("min_damage", value); }
//        }

//        public int MaxDamage
//        {
//            get { return Properties.GetProperty<int>("max_damage"); }
//            set { Properties.SetProperty("max_damage", value); }
//        }

//        public Globals.Globals.DamageTypes DamageType
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.DamageTypes>(Properties.GetProperty<string>("damage_type")); }
//            set { Properties.SetProperty("damage_type", value.GetName()); }
//        }
//    }
//}
