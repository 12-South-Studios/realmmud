using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemSetBonuses")]
    public class ItemSetBonus : Entity
    {
        public int ItemSetId { get; set; }
        public virtual ItemSet ItemSet { get; set; }

        public Statistic Statistic { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int ValueMod { get; set; }
    }
}