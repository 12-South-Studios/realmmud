using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("Users")]
    public class User : Entity
    {
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        public string Salt { get; set; }

        public string PasswordChangeToken { get; set; }

        public DateTime? PasswordTokenGeneratedAt { get; set; }

        public DateTime? PasswordTokenExpiresAt { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Bank Bank { get; set; }

        public virtual ICollection<UserAction> ActionHistory { get; set; }
    }
}
