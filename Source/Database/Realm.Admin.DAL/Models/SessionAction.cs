using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.Admin.DAL.Enumerations;

namespace Realm.Admin.DAL.Models
{
    [Table("SessionActions")]
    public class SessionAction 
    {
        [Key]
        public int Id { get; set; }

        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }

        public ActionTypes ActionType { get; set; }

        public string ObjectId { get; set; }

        public string ObjectName { get; set; }
    }
}
