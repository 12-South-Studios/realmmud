using Realm.Standard.Patterns.Repository;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    /// Class that is a repository for database procedures
    /// </summary>
    public class ProcedureRepository : Repository<ProcedureKey, IProcedure>, IProcedureRepository
    {
    }
}