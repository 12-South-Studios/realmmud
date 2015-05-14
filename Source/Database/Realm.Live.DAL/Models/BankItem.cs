using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("BankItems")]
    public class BankItem : Entity
    {
        public Instance Instance { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
