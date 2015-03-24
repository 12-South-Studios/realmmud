//// ----------------------------------------------------------------------
//// <copyright file="WeaponItemTemplate.cs" company="12-South Studios">
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
//    public class WeaponItemTemplate : ItemTemplate, IWeapon
//    {
//        public WeaponItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "weapon");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("weapon");
//        }

//        public int Parry 
//        {
//            get { return Properties.GetProperty<int>("parry"); }
//            set { Properties.SetProperty("parry", value); }
//        }

//        public bool CanParry
//        {
//            get { return Parry > 0; }
//        }

//        public long Skill
//        {
//            get { return Properties.GetProperty<long>("skill_id"); }
//            set { Properties.SetProperty("skill_id", value); }
//        }

//        public Globals.Globals.DamageTypes DamageType
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.DamageTypes>(Properties.GetProperty<string>("damage_type")); }
//            set { Properties.SetProperty("damage_type", value.GetName()); }
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
//    }
//}
