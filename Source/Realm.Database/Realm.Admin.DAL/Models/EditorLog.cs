using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.Admin.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.Admin.DAL.Models
{
    [Table("EditorLogs")]
    public class EditorLog : Entity
    {
        public DateTime? LoggedOn { get; set; }

        public ActionTypes ActionType { get; set; }

        public string Text { get; set; }
    }
}
