//using Realm.Server.Attributes;

//namespace Realm.Server.Test.Realm.Server.Attributes
//{
//    [TestFixture]
//    public class AttributeUtilsTest
//    {
//        [Test]
//        public void AttributeUtils_CalculateBonus_Test()
//        {
//            const int rating = 100;
//            const int expected = 44;
//            var actual = AttributeUtils.CalculateBonus(rating);
//            Assert.AreEqual(expected, actual);
//        }

//        [TestCase(10, 1.0f)]
//        [TestCase(20, 0.9f)]
//        [TestCase(30, 0.8f)]
//        [TestCase(40, 0.7f)]
//        [TestCase(50, 0.6f)]
//        [TestCase(60, 0.5f)]
//        [TestCase(70, 0.4f)]
//        [TestCase(80, 0.3f)]
//        [TestCase(90, 0.2f)]
//        [TestCase(100, 0.1f)]
//        [TestCase(110, 0.01f)]
//        public void CalculateXpMultiplier_Test(int skillDifference, float multiplier)
//        {
//            Assert.AreEqual(multiplier, AttributeUtils.CalculateXpMultiplier(skillDifference));
//        }

//        [TestCase(1, 1, Globals.Globals.SkillTestResultTypes.Success, 100, 100)]
//        [TestCase(100, 1, Globals.Globals.SkillTestResultTypes.Success, 100, 10)]
//        [TestCase(1, 100, Globals.Globals.SkillTestResultTypes.Success, 100, 110)]
//        [TestCase(100, 1, Globals.Globals.SkillTestResultTypes.Success, -5, 1)]
//        public void UseSkill_Test(int originalRating, int objectSkillRating, Globals.Globals.SkillTestResultTypes result, int baseXp, int expectedXp)
//        {
//            Assert.AreEqual(expectedXp, AttributeUtils.UseSkill(originalRating, objectSkillRating, result, baseXp));
//        }

//        [TestCase(100, 1, 100, true, Globals.Globals.SkillTestResultTypes.Success, 10)]
//        [TestCase(1, 110, 100, false, Globals.Globals.SkillTestResultTypes.CriticalFailure, 50)]
//        [TestCase(50, 110, 100, false, Globals.Globals.SkillTestResultTypes.Failure, 150)]
//        [TestCase(110, 1, 100, false, Globals.Globals.SkillTestResultTypes.CriticalSuccess, 1)]
//        [TestCase(110, 50, 100, false, Globals.Globals.SkillTestResultTypes.Success, 50)]
//        public void SkillCheck_Test(int originalRating, int objectSkillRating, int xpValue, bool ignoreCheck, 
//            Globals.Globals.SkillTestResultTypes expectedResult, int expectedXp)
//        {
//            var actual = AttributeUtils.SkillCheck(originalRating, objectSkillRating, xpValue, ignoreCheck);
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(expectedResult, actual.Result);
//            Assert.AreEqual(expectedXp, actual.Xp); 
//        }
//    }
//}
