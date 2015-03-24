using System.Collections.Generic;
using Realm.Library.Common;

namespace Realm.Server.Managers
{
    public interface IDataManager
    {
        object GetFactory(string name);
        bool Add(string aList, ICell aObject);
        bool Remove(string aList, ICell aObject);
        bool Has(string aList, ICell aObject);
        IList<ICell> GetList(string aList);
        ICell Get(string aList, int aId);
        ICell Get(string aList, long aId);
        ICell Get(string aList, string aName);
        int GetListCount(string aList);

        IEnumerable<string> TableKeys { get; }
    }
}
