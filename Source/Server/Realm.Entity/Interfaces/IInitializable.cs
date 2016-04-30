using Realm.Library.Common.Data;

namespace Realm.Entity.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IInitializable
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        void OnInit(DictionaryAtom initAtom);
    }
}