using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.Live.DAL.Enumerations;

namespace Realm.Live.DAL.Models
{
    [Table("UserActions")]
    public class UserAction : Entity
    {
        public DateTime ActionOccurredAt { get; set; }

        [MaxLength(50)]
        public string OriginatedFromIpAddress { get; set; }

        public UserActionTypes ActionType { get; set; }
    }
}
