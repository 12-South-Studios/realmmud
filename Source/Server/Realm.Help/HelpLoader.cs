using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;

namespace Realm.Help
{
    public class HelpLoader : IHelpLoader
    {
        public void Load(IStaticDataManager staticDataManager, IHelpRepository helpRepository)
        {
            Dictionary<string, Definition> helps =
                staticDataManager.GetStaticData(Globals.Globals.SystemTypes.HelpLookup);
            
            // TODO Do something here
        }
    }
}
