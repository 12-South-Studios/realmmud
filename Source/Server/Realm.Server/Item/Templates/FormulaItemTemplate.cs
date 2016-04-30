//// ----------------------------------------------------------------------
//// <copyright file="FormulaItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Collections.Generic;
//using Realm.Library.Common;
//using Realm.Server.Attributes;

//
//namespace Realm.Server.Item
//
//{
//    public class FormulaItemTemplate : ItemTemplate
//    {
//        private readonly Dictionary<long, int> _resources = new Dictionary<long, int>();

//        public FormulaItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "formula");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("formula");

//        }

//        public override void Clone(IGameEntity source)
//        {
//            base.Clone(source);
//            var formula = source as FormulaItemTemplate;
//            if (formula.IsNull()) return;
//            foreach (long key in formula.ResourceKeys)
//                _resources[key] = formula.GetResource(key);
//        }

//        public long Machine 
//        {
//            get { return Properties.GetProperty<long>("machine_id"); }
//            set { Properties.SetProperty("machine_id", value); }
//        }

//        public long Tool
//        {
//            get { return Properties.GetProperty<long>("tool_id"); }
//            set { Properties.SetProperty("tool_id", value); }
//        }

//        public Skill Skill
//        {
//            get { return (Skill)DataManager.Get("Skills", Properties.GetProperty<string>("skill")); }
//            set { Properties.SetProperty("skill", value.ToString()); }
//        }

//        public int SkillValue
//        {
//            get { return Properties.GetProperty<int>("skill_value"); }
//            set { Properties.SetProperty("skill_value", value); }
//        }

//        public long Product
//        {
//            get { return Properties.GetProperty<long>("product_id"); }
//            set { Properties.SetProperty("product_id", value); }
//        }

//        public int ProductQuantity
//        {
//            get { return Properties.GetProperty<int>("product_quantity"); }
//            set { Properties.SetProperty("product_quantity", value); }
//        }

//        public int XpValue
//        {
//            get { return Properties.GetProperty<int>("xp_value"); }
//            set { Properties.SetProperty("xp_value", value); }
//        }

//        public IEnumerable<long> ResourceKeys
//        {
//            get { return _resources.Keys; }
//        }

//        public new void AddResource(long id, int qty)
//        {
//            if (!_resources.ContainsKey(id))
//                _resources[id] = qty;
//        }

//        public int GetResource(long id)
//        {
//            return _resources.ContainsKey(id) ? _resources[id] : 0;
//        }

//        public void SetSkill(string name)
//        {
//            var attr = (Skill)DataManager.Get("Skills", name);
//            if (null != attr)
//                Skill = attr;
//        }
//    }
//}
