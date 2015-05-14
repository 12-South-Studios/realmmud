//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Realm.Server.NPC;
//using Realm.Server.Test.Helpers;

//namespace Realm.Server.Test.Realm.Server.NPC.Combat
//{
//    [TestClass]
//    public class AttackTest
//    {
//        [TestMethod]
//        public void Attack_Constructor_Weapon_Test()
//        {
//            const Globals.Globals.DamageTypes type = Globals.Globals.DamageTypes.Pierce;

//            var fakeAttacker = new FakeMobInstance {ID = 1, Name = "Attacker"};
//            var fakeDefender = new FakeMobInstance {ID = 2, Name = "Defender"};

//            const Globals.Globals.WearLocations loc = Globals.Globals.WearLocations.wearbody;

//            var fakeItem = new FakeWeaponInstance
//                               {
//                                   DamageType = Globals.Globals.DamageTypes.Pierce, 
//                                   MinDamage = 1, 
//                                   MaxDamage = 20
//                               };

//            const Globals.Globals.CombatHitResultTypes result = Globals.Globals.CombatHitResultTypes.Devastate;

//            var actual = new Attack(fakeAttacker, fakeDefender, loc, fakeItem, result);

//            Assert.AreEqual(fakeAttacker, actual.Attacker);
//            Assert.AreEqual(fakeDefender, actual.Defender);
//            Assert.AreEqual(loc, actual.HitLocation);
//            Assert.AreEqual(result, actual.HitResult);
//            Assert.IsTrue(actual.DamageAmount >= 1 && actual.DamageAmount <= 20);
//            Assert.AreEqual(type, actual.DamageType);
//        }

//        [TestMethod]
//        public void Attack_Constructor_NonWeapon_Test()
//        {
//            const Globals.Globals.DamageTypes type = Globals.Globals.DamageTypes.Crush;

//            var fakeAttacker = new FakeMobInstance { ID = 1, Name = "Attacker" };
//            var fakeDefender = new FakeMobInstance { ID = 2, Name = "Defender" };

//            const Globals.Globals.WearLocations loc = Globals.Globals.WearLocations.wearbody;

//            var fakeItem = new FakeItemInstance();

//            const Globals.Globals.CombatHitResultTypes result = Globals.Globals.CombatHitResultTypes.Devastate;

//            var actual = new Attack(fakeAttacker, fakeDefender, loc, fakeItem, result);

//            Assert.AreEqual(fakeAttacker, actual.Attacker);
//            Assert.AreEqual(fakeDefender, actual.Defender);
//            Assert.AreEqual(loc, actual.HitLocation);
//            Assert.AreEqual(result, actual.HitResult);
//            Assert.IsTrue(actual.DamageAmount == 0);
//            Assert.AreEqual(type, actual.DamageType);
//        }
//    }
//}
