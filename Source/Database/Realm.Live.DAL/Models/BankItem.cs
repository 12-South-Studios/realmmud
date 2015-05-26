using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("BankItems")]
    public class BankItem : Entity
    {
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public Int64? InstanceId { get; set; }
        public virtual Instance Instance { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
