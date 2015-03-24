using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Library.Database.Framework
{
    /// <summary>
    ///
    /// </summary>
    public class PendingCommand
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        public PendingCommand(DatabaseClient owner)
        {
            Owner = owner;
        }

        /// <summary>
        ///
        /// </summary>
        public DatabaseClient Owner { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public EventCallback<RealmEventArgs> Callback { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DictionaryAtom Data { get; set; }
    }
}