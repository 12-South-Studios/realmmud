using Ninject;
using Realm.Admin.DAL.Interfaces;
using Realm.DAL.Interfaces;
using Realm.Edit.Builders;

namespace Realm.Edit.Editor
{
    public static class BuilderRegistrationModule
    {
        public static void RegisterBuilders()
        {
            var realmDbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var realmAdminContext = Program.NinjectKernel.Get<IRealmAdminDbContext>();

            // Keep this list alphabetized
            EditorFactory.RegisterEditor(new AbilityBuilder(realmDbContext, realmAdminContext));
            EditorFactory.RegisterEditor(new MonthBuilder(realmDbContext, realmAdminContext));
            EditorFactory.RegisterEditor(new RaceBuilder(realmDbContext, realmAdminContext));
            // Keep this list alphabetized
        }
    }
}
