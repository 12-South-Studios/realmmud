//// ----------------------------------------------------------------------
//// <copyright file="AblativeEffectTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Collections.Generic;
//using Realm.Library.Common;

//namespace Realm.Server.Effects.Templates
//{
//    public class AblativeEffectTemplate : EffectTemplate
//    {
//        private readonly IList<Globals.Globals.DamageTypes> _damageTypes;

//        public AblativeEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//            _damageTypes = new List<Globals.Globals.DamageTypes>();
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("Albative");
//        }

//        public int MaxValue
//        {
//            get { return Properties.GetProperty<int>("max_value"); }
//            set { Properties.SetProperty("max_value", value); }
//        }

//        public IList<Globals.Globals.DamageTypes> DamageTypes { get { return new List<Globals.Globals.DamageTypes>(_damageTypes); } }

//        public bool HasDamageType(Globals.Globals.DamageTypes type) { return _damageTypes.Contains(type); }

//        public void AddDamageType(Globals.Globals.DamageTypes type)
//        {
//            if (!HasDamageType(type))
//                _damageTypes.Add(type);
//        }

//        public void RemoveDamageType(Globals.Globals.DamageTypes type)
//        {
//            if (HasDamageType(type))
//                _damageTypes.Remove(type);
//        }
//    }
//}
