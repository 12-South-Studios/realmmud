using System.Collections.Generic;
using Realm.Library.Common;

namespace Realm.Entity.Contexts
{
    /// <summary>
    /// Declares the contract for an object that can handle string flags
    /// </summary>
    public interface IFlagContext : IContext
    {
        /// <summary>
        /// Gets whether or not the object has the given flag
        /// </summary>
        /// <param name="value">Flag value</param>
        /// <returns>Returns whether or not the object has the flag</returns>
        bool HasFlag(string value);

        /// <summary>
        /// Sets the given flag onto the object
        /// </summary>
        /// <param name="value">Flag value</param>
        /// <returns>Returns whether or not the flag was set</returns>
        bool SetFlag(string value);

        /// <summary>
        /// Removes the given flag from the object
        /// </summary>
        /// <param name="value">Flag value</param>
        /// <returns>Returns whether or not the flag was unset</returns>
        bool UnsetFlag(string value);

        /// <summary>
        /// Gets a string compilation of all flag abbreviations on the object
        /// </summary>
        /// <returns>Returns a string value</returns>
        string Flags { get; }

        /// <summary>
        /// Gets or Sets an enumerable list of strings on the object
        /// </summary>
        /// <returns>Returns an IEnumerable list of strings</returns>
        IEnumerable<string> FlagList { get; set; }
    }
}