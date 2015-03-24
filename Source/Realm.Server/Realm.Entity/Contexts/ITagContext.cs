using System.Collections.Generic;
using Realm.Library.Common;

namespace Realm.Entity.Contexts
{
    /// <summary>
    /// Declares the contract for an object that can handle string tags
    /// </summary>
    public interface ITagContext : IContext
    {
        /// <summary>
        /// Gets whether or not the object has the given tag
        /// </summary>
        /// <param name="name">Name of the tag</param>
        /// <returns>Returns a value indicating the object has or hasn't got the tag</returns>
        bool HasTag(string name);

        /// <summary>
        /// Adds the given tag name to the object
        /// </summary>
        /// <param name="tag"></param>>
        void AddTag(Tag tag);

        /// <summary>
        /// Removes the given tag name from the object
        /// </summary>
        /// <param name="name">Tag name</param>
        void RemoveTag(string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        void RemoveTag(int id);

        /// <summary>
        /// Gets a list of tags on the object
        /// </summary>
        /// <returns>Returns a list of tag objects</returns>
        IList<object> Tags { get; }
    }
}