using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.Admin.DAL.Models
{
    [Table("Sessions")]
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime SessionDate { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<SessionValue> Values { get; set; }

        public virtual ICollection<SessionAction> Actions { get; set; } 
    }
}
