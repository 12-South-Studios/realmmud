using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("BankLogs")]
    public class BankLog : Entity
    {
        public DateTime ModifiedOn { get; set; }

        [MaxLength(50)]
        public string CharacterName { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }

        public bool Withdrew { get; set; }
    }
}
