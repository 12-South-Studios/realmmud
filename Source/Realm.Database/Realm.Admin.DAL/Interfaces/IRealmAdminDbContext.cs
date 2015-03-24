using System;
using System.Data.Entity;
using Realm.Admin.DAL.Models;
using Realm.DAL.Common;

namespace Realm.Admin.DAL.Interfaces
{
    public interface IRealmAdminDbContext : IDisposable, IRealmContext
    {
        IDbSet<EditorLog> EditorLogs { get; set; }
        IDbSet<Log> Logs { get; set; }
        IDbSet<Login> LoginHistory { get; set; }
        IDbSet<RestrictedName> RestrictedNames { get; set; }
        IDbSet<Session> Sessions { get; set; } 
    }
}
