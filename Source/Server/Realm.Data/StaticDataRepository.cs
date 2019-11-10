using System.Collections.Generic;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Standard.Patterns.Repository;

namespace Realm.Data
{
    /// <summary>
    /// Stores data from the database.
    /// Key = short value from Globals.Globals.SystemTypes
    /// Value = Dictionary
    ///     Key = ID
    ///     Value = Definition object
    /// </summary>
    public class StaticDataRepository : Repository<int, Dictionary<string, Definition>>, IStaticDataRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <param name="id"></param>
        /// <param name="def"></param>
        public void AddSubtype(int category, string id, Definition def)
        {
            Dictionary<string, Definition> categoryData;
            if (!Contains(category))
            {
                categoryData = new Dictionary<string, Definition> { { id, def } };
                Add(category, categoryData);
            }
            else
            {
                categoryData = Get(category);
                if (!categoryData.ContainsKey(id))
                    categoryData.Add(id, def);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Definition GetSubtype(int category, string id)
        {
            if (!Contains(category)) return null;
            var categoryData = Get(category);
            return categoryData.ContainsKey(id) ? categoryData[id] : null;
        }
    }
}