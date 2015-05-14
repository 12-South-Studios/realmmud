using System.Collections.Generic;
using Realm.Entity.Entities;
using Realm.Library.Common.Data;

namespace Realm.Network.User
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICharacterContext
    {
        /// <summary>
        /// 
        /// </summary>
        ICharacter Character { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<DictionaryAtom> Characters { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool LoadCharacters();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool SelectCharacter(string name);
    }
}