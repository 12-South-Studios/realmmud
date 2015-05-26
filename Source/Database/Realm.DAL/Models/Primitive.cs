using System.ComponentModel.DataAnnotations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    public abstract class Primitive : Entity, IPrimitive
    {
        [Required]
        [MaxLength(255)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        public string DisplayName { get; set; }
    }
}
