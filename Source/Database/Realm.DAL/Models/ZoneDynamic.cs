using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ZoneDynamics")]
    public class ZoneDynamic : Entity
    {
        public int MaxNumberOfSpaces { get; set; }

        public int MinNumberOfSpaces { get; set; }

        public int DecayTimeInSeconds { get; set; }

        public virtual Ability Ability { get; set; }

        public virtual Mobile Mobile { get; set; }

        [Required]
        public int ZoneId { get; set; }

        [ForeignKey("ZoneId")]
        public Zone Zone { get; set; }
    }
}