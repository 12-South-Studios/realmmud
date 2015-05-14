using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("Properties")]
    public class Property : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    
        [MaxLength(1024)]
        public string Description { get; set; }

        public bool IsPersistable { get; set; }

        public bool IsVisible { get; set; }

        public bool IsVolatile { get; set; }
    }
}
