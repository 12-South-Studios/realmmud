//// ----------------------------------------------------------------------
//// <copyright file="TeleportEffectTemplate.cs" company="12-South Studios">
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
//    public class TeleportEffectTemplate : EffectTemplate
//    {
//        public TeleportEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//       //     base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("Teleport");
//        }

//        public long SpaceId
//        {
//            get { return Properties.GetProperty<long>("Space_id"); }
//            set { Properties.SetProperty("Space_id", value); }
//        }

//        public bool UseBindPoint
//        {
//            get { return Properties.GetProperty<bool>("use_bind_point"); }
//            set { Properties.SetProperty("use_bind_point", value); }
//        }

//        public bool UseRandomSpace
//        {
//            get { return Properties.GetProperty<bool>("use_random_Space"); }
//            set { Properties.SetProperty("use_random_Space", value); }
//        }
//    }
//}
