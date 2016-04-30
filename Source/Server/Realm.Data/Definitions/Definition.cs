using System;
using Ninject;
using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Objects;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Abstract class defining a definition object that holds static data
    /// </summary>
    public abstract class Definition : Cell, IEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Unique ID of the Definition</param>
        /// <param name="name">Name of the Definition</param>
        /// <param name="definition">Dictionary Atom containing definition data</param>
        protected Definition(long id, string name, DictionaryAtom definition)
        {
            Validation.Validate<ArgumentOutOfRangeException>(id > 0 && id < Int64.MaxValue);
            Validation.IsNotNullOrEmpty(name, "name");
            Validation.IsNotNull(definition, "definition");

            ID = id;
            Name = name;
            Def = definition;
        }

        /// <summary>
        /// Gets a reference to the definition data
        /// </summary>
        public DictionaryAtom Def { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected StaticDataManager StaticDataManager { get; private set; }

        [Inject]
        public void SetStaticDataManager(IStaticDataManager staticDataMgr)
        {
            StaticDataManager = (StaticDataManager)staticDataMgr;
        }
    }
}