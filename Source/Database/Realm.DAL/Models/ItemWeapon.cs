using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemWeapons")]
    public class ItemWeapon : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public DamageTypes DamageType { get; set; }

        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public SpeedClassTypes SpeedClassType { get; set; }
    }
}