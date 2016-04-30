using Realm.Library.Common.Data;

namespace Realm.Data.Definitions.Common

{
    /// <summary>
    ///
    /// </summary>
    public abstract class SubDefinition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="definition"></param>
        protected SubDefinition(long id, DictionaryAtom definition)
        {
            ID = id;
            Def = definition;
        }

        /// <summary>
        ///
        /// </summary>
        public long ID { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public DictionaryAtom Def { get; private set; }
    }
}