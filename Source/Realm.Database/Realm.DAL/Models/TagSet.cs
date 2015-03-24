using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("TagSets")]
    public class TagSet : Entity
    {
        public virtual ICollection<Tag> Tags { get; set; }
    }
}