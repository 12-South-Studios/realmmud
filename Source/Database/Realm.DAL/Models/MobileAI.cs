using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileAIs")]
    public class MobileAI : Entity
    {
        public MonsterClassTypes MonsterClass { get; set; }

        public int? BehaviorId { get; set; }
        public virtual Behavior Behavior { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}