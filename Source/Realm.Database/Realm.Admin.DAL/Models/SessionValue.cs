using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.Admin.DAL.Enumerations;

namespace Realm.Admin.DAL.Models
{
    [Table("SessionValues")]
    public class SessionValue 
    {
        [Key]
        public int Id { get; set; }

        public SessionRecordTypes RecordType { get; set; }

        public int Value { get; set; }
    }
}
