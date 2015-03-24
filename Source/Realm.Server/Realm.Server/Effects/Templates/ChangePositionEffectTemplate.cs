//// ----------------------------------------------------------------------
//// <copyright file="ChangePositionEffectTemplate.cs" company="12-South Studios">
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
//    public class ChangePositionEffectTemplate : EffectTemplate
//    {
//        public ChangePositionEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("ChangePosition");
//        }

//        public Globals.Globals.PositionTypes Position
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.PositionTypes>(Properties.GetProperty<string>("position")); }
//            set { Properties.SetProperty("position", value.GetName()); }
//        }
//    }
//}
