using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("QuestProgresses")]
    public class QuestProgress : Entity
    {
        public QuestProgressTypes QuestProgressType { get; set; }

        public int? PrimitiveId { get; set; }
        public virtual Primitive Primitive { get; set; }

        public int Quantity { get; set; }

        public string ProgressName { get; set; }

        [Required]
        public int QuestId { get; set; }
        public virtual Quest Quest { get; set; }
    }
}