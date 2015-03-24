//// ----------------------------------------------------------------------
//// <copyright file="GiveSkillEffectTemplate.cs" company="12-South Studios">
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
//    public class GiveSkillEffectTemplate : EffectTemplate
//    {
//        public GiveSkillEffectTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("GiveSkill");
//        }

//        public string Skill
//        {
//            get { return Properties.GetProperty<string>("give_skill"); }
//            set { Properties.SetProperty("give_skill", value); }
//        }

//        public new int Value
//        {
//            get { return Properties.GetProperty<int>("skill_value"); }
//            set { Properties.SetProperty("skill_value", value); }
//        }
//    }
//}
