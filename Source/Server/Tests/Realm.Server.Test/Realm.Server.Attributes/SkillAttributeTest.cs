//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.Attributes;
//using Realm.Server.Contexts;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.Attributes
//{
//    [TestClass]
//    public class SkillAttributeTest
//    {
//        [Fact]
//        public void SkillAttribute_Constructor_Test()
//        {
//            var skill = new Skill(1, "test", new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 100, true, null);

//            var actual = new SkillAttribute(skill);

//            Assert.IsNotNull(actual);
//            Assert.AreEqual("test", actual.Name);
//        }

//        [Fact]
//        public void SkillAttribute_ConstructorOverload_Test()
//        {
//            var skill = new Skill(1, "test", new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude), 
//                Globals.Globals.Statistics.Fortitude, 100, true, null);

//            var attrib = new SkillAttribute(skill);

//            var actual = new SkillAttribute(attrib, 2, null);

//            Assert.IsNotNull(actual);
//            Assert.AreEqual(2, actual.ID);
//            Assert.AreEqual("test", actual.Name);
//            Assert.AreEqual(1, actual.Rating);
//        }

//        [Fact]
//        public void SkillAttribute_GrossRating_Test()
//        {
//            // TODO: Fix this
//            var fakeOwner = new FakeMobInstance();
//            fakeOwner.StatisticHandler = new StatisticHandler(fakeOwner);

//            var skill = new Skill(1, "test", new SkillCategory(1, "test", Globals.Globals.Statistics.Fortitude),
//                Globals.Globals.Statistics.Fortitude, 100, true, null);

//            var attrib = new SkillAttribute(skill);

//            var actual = new SkillAttribute(attrib, 2, null);


//        }
//    }
//}
