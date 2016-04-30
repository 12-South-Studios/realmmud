//// ----------------------------------------------------------------------
//// <copyright file="FormulaItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Text;
//using Realm.Library.Common;
//using Realm.Server.Attributes;

//
//namespace Realm.Server.Item
//
//{
//    public class FormulaItemInstance : ItemInstance
//    {
//        public FormulaItemInstance(long id, FormulaItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "formula");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public long Machine
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.Machine : 0;
//            }
//        }

//        public long Tool
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.Tool : 0;
//            }
//        }

//        public Skill Skill
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.Skill : null;
//            }
//        }

//        public int SkillValue
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.SkillValue : 0;
//            }
//        }

//        public long Product
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.Product : 0;
//            }
//        }

//        public int ProductQuantity
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.ProductQuantity : 0;
//            }
//        }

//        public int XpValue
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.XpValue : 0;
//            }
//        }

//        public IEnumerable<long> ResourceKeys
//        {
//            get
//            {
//                var parent = Parent as FormulaItemTemplate;
//                return parent.IsNotNull() ? parent.ResourceKeys : new List<long>();
//            }
//        }

//        public int GetResource(long id)
//        {
//            var parent = Parent as FormulaItemTemplate;
//            return parent.IsNotNull() ? parent.GetResource(id) : 0;
//        }

//        public override string Explore(IGameEntity entity)
//        {
//            var formula = Parent as FormulaItemTemplate;
//            if (formula.IsNull()) return string.Empty;

//            var sb = new StringBuilder();
//            sb.AppendFormat("Formula Details:{0}", Environment.NewLine);
//            sb.AppendFormat("  Product:  {0}{1}", EntityManager.LuaGetTemplate(formula.Product).Name, Environment.NewLine);
//            sb.AppendFormat("  Skill:    {0} ({1}){2}", formula.Skill, formula.SkillValue, Environment.NewLine);
//            sb.AppendFormat("  Machine:  {0}{1}", EntityManager.LuaGetTemplate(formula.Machine).Name, Environment.NewLine);
//            sb.AppendFormat("  Tool:     {0}{1}", EntityManager.LuaGetTemplate(formula.Tool).Name, Environment.NewLine);

//            foreach (var resourceId in ResourceKeys)
//            {
//                var resource = EntityManager.LuaGetTemplate(resourceId) as ResourceItemTemplate;
//                if (resource.IsNull()) continue;
//                sb.AppendFormat("  Resource: {0} (x{1}){2}", resource.Name, GetResource(resourceId), Environment.NewLine);
//            }

//            return sb.ToString();
//        }
//    }
//}
