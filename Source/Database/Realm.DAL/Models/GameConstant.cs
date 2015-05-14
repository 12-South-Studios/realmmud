using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("GameConstants", Schema = "ref")]
    public class GameConstant : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        public GameConstantCategory GameConstantCategory { get; set; }
    }
}