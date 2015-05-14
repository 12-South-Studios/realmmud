using System;

namespace Realm.DAL.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime? CreateDateUtc { get; set; }
    }
}
