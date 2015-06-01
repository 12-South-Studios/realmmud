using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Quests")]
    public class Quest : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int Bits { get; set; }

        public int Timer { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<QuestAction> Actions { get; set; }

        public virtual ICollection<QuestProgress> ProgressSteps { get; set; }

        public virtual ICollection<QuestRequirement> Requirements { get; set; }
    }
}