using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Resets")]
    public class Reset : Primitive
    {
        public ResetTypes ResetType { get; set; }

        public ResetLocationTypes ResetLocationType { get; set; }

        public virtual Space Space { get; set; }

        public int Limit { get; set; }

        public int Quantity { get; set; }

        public virtual Primitive Object { get; set; }
    }
}