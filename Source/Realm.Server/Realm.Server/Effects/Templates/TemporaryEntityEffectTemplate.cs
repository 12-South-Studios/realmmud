//// ----------------------------------------------------------------------
//// <copyright file="TemporaryEntityEffectTemplate.cs" company="12-South Studios">
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
//    public class TemporaryEntityEffectTemplate : EffectTemplate
//    {
//        public TemporaryEntityEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("TemporaryEntity");
//        }

//        public long EntityId
//        {
//            get { return Properties.GetProperty<long>("entity_id"); }
//            set { Properties.SetProperty("entity_id", value); }
//        }

//        public bool PlaceInInventory
//        {
//            get { return Properties.GetProperty<bool>("place_in_inventory"); }
//            set { Properties.SetProperty("place_in_inventory", value); }
//        }
//    }
//}
