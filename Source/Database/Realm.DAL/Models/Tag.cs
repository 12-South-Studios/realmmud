using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("Tags")]
    public class Tag : Entity
    {
        public TagCategoryTypes TagCategory { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}