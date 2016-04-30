//using System;
//using Realm.Library.Common;
//using Realm.Server.Item;
//using Realm.Server.Properties;

//
//namespace Realm.Server.NPC
//
//{
//    public class Attack
//    {
//        public Attack(IBiota attacker, IBiota defender, Globals.Globals.WearLocations hitLocation,
//            IItem attackObject, Globals.Globals.CombatHitResultTypes hitResult)
//        {
//            if (attacker.IsNull())
//                throw new ArgumentNullException("attacker", ErrorResources.ERR_NULL_PARAMETER);
//            if (defender.IsNull())
//                throw new ArgumentNullException("defender", ErrorResources.ERR_NULL_PARAMETER);
//            if (attackObject.IsNull())
//                throw new ArgumentNullException("attackObject", ErrorResources.ERR_NULL_PARAMETER);

//            Attacker = attacker;
//            Defender = defender;
//            HitLocation = hitLocation;
//            HitResult = hitResult;

//            if (attackObject is IWeapon)
//            {
//                var weapon = attackObject as IWeapon;
//                DamageType = weapon.DamageType;
//                DamageAmount = Library.Common.Random.Between(weapon.MinDamage, weapon.MaxDamage);
//            }
//            else
//            {
//                //// other types, such as spells or abilities
//                DamageAmount = 0;
//                DamageType = Globals.Globals.DamageTypes.Crush;
//            }
//        }

//        public IBiota Attacker { get; set; }
//        public IBiota Defender { get; set; }
//        public Globals.Globals.WearLocations HitLocation { get; set; }
//        public Globals.Globals.DamageTypes DamageType { get; set; }
//        public int DamageAmount { get; set; }
//        public Globals.Globals.CombatHitResultTypes HitResult { get; set; }
//    }
//}
