//// ----------------------------------------------------------------------
//// <copyright file="SpaceEffectEffectTemplate.cs" company="12-South Studios">
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
//    public class SpaceEffectEffectTemplate : EffectTemplate
//    {
//        public SpaceEffectEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("SpaceEffect");
//        }

//        public long EffectId
//        {
//            get { return Properties.GetProperty<long>("effect_id"); }
//            set { Properties.SetProperty("effect_id", value); }
//        }

//        public int MovementBits
//        {
//            get { return Properties.GetProperty<int>("movement_bits"); }
//            set { Properties.SetProperty("movement_bits", value); }
//        }

//        public int EffectBits
//        {
//            get { return Properties.GetProperty<int>("effect_bits"); }
//            set { Properties.SetProperty("effect_bits", value); }
//        }

//        public new string LongName
//        {
//            get { return Properties.GetProperty<string>("long_name"); }
//            set { Properties.SetProperty("long_name", value); }
//        }
//    }
//}
