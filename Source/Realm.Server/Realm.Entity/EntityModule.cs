using Ninject;
using Realm.Entity.Entities;
using Realm.Library.Common;
using Realm.Library.Common.Collections;
using Realm.Library.Common.Data;

namespace Realm.Entity
{
    public class EntityModule : NinjectGameModule
    {
        public EntityModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<IEntityInitializer>().To<EntityInitializer>();
            Bind<IEntityRecycler>().To<EntityRecycler>().WithConstructorArgument("recycleFrequency", 0);
            Bind<IEntityLoader>().To<EntityLoader>();
            Bind<IEntityRepository>().To<EntityRepository>();
            Bind<IEntityFactory>().To<EntityFactory>();

            Bind<IEntityManager>().To<EntityManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("EntityManager");
                    x.OnInit(InitAtom, Kernel.Get<IEntityInitializer>());
                    InitAtom.Set("EntityManager", x);
                });
        }
    }
}
