using System.ComponentModel.DataAnnotations;
using Realm.DAL.Interfaces;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    public abstract class Primitive : Entity, IPrimitive
    {
        [Required]
        [MaxLength(255)]
        public string SystemName { get; set; }

        [Required]
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        public virtual SystemString DisplayName { get; set; }
    }
}
