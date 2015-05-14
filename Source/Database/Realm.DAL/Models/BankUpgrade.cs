using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("BankUpgrades", Schema = "ref")]
    public class BankUpgrade : Entity
    {
        public int BankLevel { get; set; }

        public int UpgradeCost { get; set; }

        public int StackLimit { get; set; }
    }
}