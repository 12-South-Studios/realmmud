using System.Collections.Generic;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;

namespace Realm.Help
{
    public class HelpLoader : IHelpLoader
    {
        public void Load(IStaticDataManager staticDataManager, IHelpRepository helpRepository)
        {
            Dictionary<string, Definition> helps =
                staticDataManager.GetStaticData(Globals.SystemTypes.HelpLookup);
            
            // TODO Do something here
        }
    }
}
