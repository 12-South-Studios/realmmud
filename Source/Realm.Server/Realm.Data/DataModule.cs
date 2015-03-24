using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Database.Framework;

namespace Realm.Data
{
    public class DataModule : NinjectGameModule
    {
        public DataModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<ILoaderRepository>().To<LoaderRepository>();
            Bind<IEntity, IStaticDataLoader>().To<StaticDataLoader>().InSingletonScope().Named("StaticDataLoader");
            Bind<IStaticDataRepository>().To<StaticDataRepository>();

            Bind<IDatabaseLoadBalancer, IDatabaseManager>().To<DatabaseManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("DatabaseManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("DatabaseManager", x);
                });
            Bind<IStaticDataManager>().To<StaticDataManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("StaticDataManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("StaticDataManager", x);
                });
        }
    }
}
