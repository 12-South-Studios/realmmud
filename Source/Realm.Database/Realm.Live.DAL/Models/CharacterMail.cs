using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterMailbox")]
    public class CharacterMail : Entity
    {
        [MaxLength(50)]
        public string FromCharacterName { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }

        public string Text { get; set; }

        public DateTime SentOn { get; set; }

        public bool IsNew { get; set; }

        public int Coin { get; set; }

        public virtual ICollection<CharacterMailItem> Items { get; set; }
    }
}
