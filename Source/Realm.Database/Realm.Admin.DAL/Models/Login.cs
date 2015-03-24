using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Admin.DAL.Models
{
    [Table("Logins")]
    public class Login : Entity
    {
        public int UserId { get; set; }

        public DateTime LoggedIn { get; set; }

        [MaxLength(50)]
        public string IpAddress { get; set; }
    }
}
