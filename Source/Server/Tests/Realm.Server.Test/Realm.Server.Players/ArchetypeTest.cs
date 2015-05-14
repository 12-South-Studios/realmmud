//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Realm.Server.Attributes;
//using Realm.Server.Players;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Players
//{
//    [TestClass]
//    public class ArchetypeTest
//    {
//        private static Archetype GetArchetype()
//        {
//            return new Archetype(1, "test", null);
//        }

//        [TestMethod]
//        public void Archetype_AddAbility_NotPresent_Test()
//        {
//            var archetype = GetArchetype();

//            archetype.AddAbility(1);
//            var abilityList = archetype.Abilities as List<long>;
//            if (abilityList == null)
//                throw new Exception();

//            Assert.AreEqual(1, abilityList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddAbility_Present_Test()
//        {
//            var archetype = GetArchetype();

//            archetype.AddAbility(1);
//            archetype.AddAbility(1);
//            var abilityList = archetype.Abilities as List<long>;
//            if (abilityList == null)
//                throw new Exception();

//            Assert.AreEqual(1, abilityList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddSkill_NotPresent_Test()
//        {
//            var archetype = GetArchetype();

//            var skill = new Skill(1, "test", new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 50, true, null);

//            archetype.AddSkill(skill, 50);
//            var skillList = new List<Skill>(archetype.Skills);
//            if (skillList == null)
//                throw new Exception();

//            Assert.AreEqual(1, skillList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddSkill_Present_Test()
//        {
//            var archetype = GetArchetype();

//            var skill = new Skill(1, "test", new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 50, true, null);

//            archetype.AddSkill(skill, 50);
//            archetype.AddSkill(skill, 25);
//            var skillList = new List<Skill>(archetype.Skills);
//            if (skillList == null)
//                throw new Exception();

//            Assert.AreEqual(1, skillList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddPreferredSkillsCategory_NotPresent_Test()
//        {
//            var archetype = GetArchetype();

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>()))
//                .Returns(new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude));

//            archetype.AddPreferredSkillCategory(mockData.Object, "test");
//            var skillList = new List<SkillCategory>(archetype.PreferredSkills);
//            if (skillList == null)
//                throw new Exception();

//            Assert.AreEqual(1, skillList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddPreferredSkillsCategory_Present_Test()
//        {
//            var archetype = GetArchetype();

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>()))
//                .Returns(new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude));

//            archetype.AddPreferredSkillCategory(mockData.Object, "test");
//            archetype.AddPreferredSkillCategory(mockData.Object, "test");

//            var skillList = new List<SkillCategory>(archetype.PreferredSkills);
//            if (skillList == null)
//                throw new Exception();

//            Assert.AreEqual(1, skillList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddRestrictedSkillsCategory_NotPresent_Test()
//        {
//            var archetype = GetArchetype();

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>()))
//                .Returns(new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude));

//            archetype.AddRestrictedSkillCategory(mockData.Object, "test");
//            var skillList = new List<SkillCategory>(archetype.RestrictedSkills);
//            if (skillList == null)
//                throw new Exception();

//            Assert.AreEqual(1, skillList.Count);
//        }

//        [TestMethod]
//        public void Archetype_AddRestrictedSkillsCategory_Present_Test()
//        {
//            var archetype = GetArchetype();

//            var mockData = TestHelper.MockDataManager;
//            mockData.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>()))
//                .Returns(new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude));

//            archetype.AddRestrictedSkillCategory(mockData.Object, "test");
//            archetype.AddRestrictedSkillCategory(mockData.Object, "test");

//            var skillList = new List<SkillCategory>(archetype.RestrictedSkills);
//            if (skillList == null)
//                throw new Exception();

//            Assert.AreEqual(1, skillList.Count);
//        }
//    }
//}
