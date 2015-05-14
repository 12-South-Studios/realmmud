using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemWeapons")]
    public class ItemWeapon : Entity
    {
        public DamageTypes DamageType { get; set; }

        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }

        public Skill Skill { get; set; }

        public SpeedClassTypes SpeedClassType { get; set; }
    }
}