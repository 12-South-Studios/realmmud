using Realm.Library.Patterns.Repository;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Declares a contract for a procedure repository
    /// </summary>
    public interface IProcedureRepository : IRepository<ProcedureKey, IProcedure>
    {
    }
}