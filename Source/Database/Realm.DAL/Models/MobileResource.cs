using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileResources")]
    public class MobileResource : Entity
    {
        public int? NodeItemId { get; set; }
        public virtual Item NodeItem { get; set; }

        public MobileNodeTypes NodeType { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}