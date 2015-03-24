using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("Strings")]
    public class SystemString : Entity
    {
        public StringTypes StringType { get; set; }

        public string Value { get; set; }
    }
}