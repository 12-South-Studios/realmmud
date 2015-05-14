using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Admin.DAL.Models
{
    [Table("Logs")]
    public class Log : Entity
    {
        public DateTime? LoggedOn { get; set; }

        [MaxLength(10)]
        public string LogLevel { get; set; }

        [MaxLength(255)]
        public string SourceName { get; set; }

        [MaxLength(255)]
        public string MachineName { get; set; }

        public string Text { get; set; }

        public string Exception { get; set; }
    }
}
