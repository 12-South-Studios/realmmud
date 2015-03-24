using System.Collections.Generic;
using Realm.Data.Definitions;

namespace Realm.Data.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IStaticDataManager
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Dictionary<string, Definition> GetStaticData(Globals.Globals.SystemTypes category);

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Dictionary<string, Definition> GetStaticData(int category);

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <param name="dataId"></param>
        /// <returns></returns>
        Definition GetStaticData(Globals.Globals.SystemTypes category, string dataId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <param name="dataId"></param>
        /// <returns></returns>
        Definition GetStaticData(int category, string dataId);
    }
}