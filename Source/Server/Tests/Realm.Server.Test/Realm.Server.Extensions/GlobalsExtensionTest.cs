//using Realm.Library.Common;

//namespace Realm.Server.Test.Realm.Server.Extensions
//{
//    [TestFixture]
//    public class DirectionTypeExtensionTest
//    {
//        [TestCase(Globals.Globals.Directions.North, "south")]
//        [TestCase(Globals.Globals.Directions.South, "north")]
//        [TestCase(Globals.Globals.Directions.East, "west")]
//        [TestCase(Globals.Globals.Directions.West, "east")]
//        [TestCase(Globals.Globals.Directions.Northeast, "southwest")]
//        [TestCase(Globals.Globals.Directions.Northwest, "southeast")]
//        [TestCase(Globals.Globals.Directions.Southeast, "northwest")]
//        [TestCase(Globals.Globals.Directions.Southwest, "northeast")]
//        [TestCase(Globals.Globals.Directions.Up, "down")]
//        [TestCase(Globals.Globals.Directions.Down, "up")]
//        public void GetOpposite_Test(Globals.Globals.Directions direction, string expected)
//        {
//            Assert.AreEqual(expected, direction.GetOpposite());
//        }

//        public enum PronounType
//        {
//            Object,
//            Possessive,
//            Reflexive,
//            Subject
//        };

//        [TestCase(Globals.Globals.GenderTypes.Female, PronounType.Object, "her")]
//        [TestCase(Globals.Globals.GenderTypes.Male, PronounType.Object, "him")]
//        [TestCase(Globals.Globals.GenderTypes.Neuter, PronounType.Object, "it")]
//        [TestCase(Globals.Globals.GenderTypes.Male, PronounType.Possessive, "his")]
//        [TestCase(Globals.Globals.GenderTypes.Female, PronounType.Possessive, "hers")]
//        [TestCase(Globals.Globals.GenderTypes.Neuter, PronounType.Possessive, "its")]
//        [TestCase(Globals.Globals.GenderTypes.Male, PronounType.Reflexive, "himself")]
//        [TestCase(Globals.Globals.GenderTypes.Female, PronounType.Reflexive, "herself")]
//        [TestCase(Globals.Globals.GenderTypes.Neuter, PronounType.Reflexive, "itself")]
//        [TestCase(Globals.Globals.GenderTypes.Male, PronounType.Subject, "he")]
//        [TestCase(Globals.Globals.GenderTypes.Female, PronounType.Subject, "she")]
//        [TestCase(Globals.Globals.GenderTypes.Neuter, PronounType.Subject, "it")]
//        public void Pronoun_Test(Globals.Globals.GenderTypes gender, PronounType type, string expected)
//        {
//            switch (type)
//            {
//                case PronounType.Object:
//                    Assert.AreEqual(expected, gender.ObjectPronoun());
//                    break;
//                case PronounType.Possessive:
//                    Assert.AreEqual(expected, gender.PossessivePronoun());
//                    break;
//                case PronounType.Reflexive:
//                    Assert.AreEqual(expected, gender.ReflexivePronoun());
//                    break;
//                case PronounType.Subject:
//                    Assert.AreEqual(expected, gender.SubjectPronoun());
//                    break;
//            }
//        }

//        [TestCase(100.0f, Globals.Globals.SkillTestResultTypes.CriticalFailure, 50.0f)]
//        [TestCase(100.0f, Globals.Globals.SkillTestResultTypes.CriticalSuccess, 150.0f)]
//        [TestCase(100.0f, Globals.Globals.SkillTestResultTypes.Success, 100.0f)]
//        [TestCase(100.0f, Globals.Globals.SkillTestResultTypes.Failure, 100.0f)]
//        public void CalculateXpResult_Test(float xpValue, Globals.Globals.SkillTestResultTypes testResult, float expected)
//        {
//            Assert.AreEqual(expected, testResult.CalculateXpResult(xpValue));
//        }

//        [TestCase(Globals.Globals.ElementTypes.Light, Globals.Globals.ElementTypes.Shadow, Globals.Globals.ElementTypes.Fire, Globals.Globals.ElementTypes.Air)]
//        [TestCase(Globals.Globals.ElementTypes.Shadow, Globals.Globals.ElementTypes.Light, Globals.Globals.ElementTypes.Earth, Globals.Globals.ElementTypes.Water)]
//        [TestCase(Globals.Globals.ElementTypes.Fire, Globals.Globals.ElementTypes.Water, Globals.Globals.ElementTypes.Earth, Globals.Globals.ElementTypes.Light)]
//        [TestCase(Globals.Globals.ElementTypes.Earth, Globals.Globals.ElementTypes.Air, Globals.Globals.ElementTypes.Fire, Globals.Globals.ElementTypes.Shadow)]
//        [TestCase(Globals.Globals.ElementTypes.Air, Globals.Globals.ElementTypes.Earth, Globals.Globals.ElementTypes.Light, Globals.Globals.ElementTypes.Water)]
//        [TestCase(Globals.Globals.ElementTypes.Water, Globals.Globals.ElementTypes.Fire, Globals.Globals.ElementTypes.Air, Globals.Globals.ElementTypes.Shadow)]
//        public void GetElement_Test(Globals.Globals.ElementTypes element, Globals.Globals.ElementTypes opposite, 
//            Globals.Globals.ElementTypes left, Globals.Globals.ElementTypes right)
//        {
//            var elem = element.GetOpposite();
//            Assert.AreEqual(elem, opposite);

//            elem = element.GetLeft();
//            Assert.AreEqual(elem, left);

//            elem = element.GetRight();
//            Assert.AreEqual(elem, right);
//        }
//    }
//}
