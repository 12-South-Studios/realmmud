//// ----------------------------------------------------------------------
//// <copyright file="WeaponItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class WeaponItemInstance : ItemInstance, IWeapon
//    {
//        public WeaponItemInstance(long id, WeaponItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "weapon");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public int Parry
//        {
//            get
//            {
//                var parent = Parent as WeaponItemTemplate;
//                return parent.IsNotNull() ? parent.Parry : 0;
//            }
//        }

//        public bool CanParry
//        {
//            get
//            {
//                var parent = Parent as WeaponItemTemplate;
//                return parent.IsNotNull() && parent.CanParry;
//            }
//        }

//        public long Skill
//        {
//            get
//            {
//                var parent = Parent as WeaponItemTemplate;
//                return parent.IsNotNull() ? parent.Skill : 0;
//            }
//        }

//        public Globals.Globals.DamageTypes DamageType
//        {
//            get
//            {
//                var parent = Parent as WeaponItemTemplate;
//                return parent.IsNotNull() ? parent.DamageType : Globals.Globals.DamageTypes.Crush;
//            }
//        }

//        public int MinDamage
//        {
//            get
//            {
//                var parent = Parent as WeaponItemTemplate;
//                return parent.IsNotNull() ? parent.MinDamage : 0;
//            }
//        }

//        public int MaxDamage
//        {
//            get
//            {
//                var parent = Parent as WeaponItemTemplate;
//                return parent.IsNotNull() ? parent.MaxDamage : 0;
//            }
//        }
//    }
//}
