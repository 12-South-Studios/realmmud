using Realm.Data.Interfaces;

namespace Realm.Help
{
    public interface IHelpLoader
    {
        void Load(IStaticDataManager staticDataManager, IHelpRepository helpRepository);
    }
}
