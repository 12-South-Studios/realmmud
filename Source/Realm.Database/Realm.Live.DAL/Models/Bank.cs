using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.Live.DAL.Enumerations;

namespace Realm.Live.DAL.Models
{
    [Table("Banks")]
    public class Bank : Entity
    {
        public int Coin { get; set; }

        public int Level { get; set; }

        public DateTime? LastAccessed { get; set; }

        public BankTypes BankType { get; set; }

        public ICollection<BankItem> Items { get; set; }

        public ICollection<BankLog> Logs { get; set; }
 
        public Bank()
        {
            Level = 1;
        }
    }
}
