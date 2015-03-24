using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Admin.DAL.Models
{
    [Table("RestrictedNames")]
    public class RestrictedName : Entity
    {
        [MaxLength(50)]
        public string Value { get; set; }

        public bool IsReserved { get; set; }

        public bool IsCopyright { get; set; }

        public bool IsProfanity { get; set; }

        public bool IsRegex { get; set; }
    }
}
