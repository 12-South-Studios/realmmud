using Realm.Library.Common.Events;

namespace Realm.Data.Loaders
{
    /// <summary>
    ///
    /// </summary>
    public interface ILoader
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="boolSet"></param>
        /// <returns></returns>
        bool Load(BooleanSet boolSet);

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        void OnLoadComplete(RealmEventArgs args);

        /// <summary>
        ///
        /// </summary>
        string IdColumn { get; }

        /// <summary>
        ///
        /// </summary>
        string NameColumn { get; }
    }
}