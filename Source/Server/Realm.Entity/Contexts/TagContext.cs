using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;

namespace Realm.Entity.Contexts
{
    /// <summary>
    ///
    /// </summary>
    public class TagContext : BaseContext<IEntity>, ITagContext
    {
        private readonly IList<Tag> _tags = new List<Tag>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        public TagContext(IEntity owner)
            : base(owner)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasTag(string name)
        {
            Validation.IsNotNullOrEmpty(name, "name");

            return _tags.Any(tag => tag.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                || tag.ID.ToString().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tag"></param>
        public void AddTag(Tag tag)
        {
            Validation.IsNotNull(tag, "tag");

            if (!_tags.Contains(tag))
                _tags.Add(tag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        public void RemoveTag(string name)
        {
            Validation.IsNotNullOrEmpty(name, "name");

            foreach (var tag in _tags.Where(tag => tag.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                _tags.Remove(tag);
                break;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void RemoveTag(int id)
        {
            Validation.Validate<ArgumentOutOfRangeException>(id > 0 && id <= Int32.MaxValue);

            foreach (var tag in _tags.Where(tag => tag.ID == id))
            {
                _tags.Remove(tag);
                break;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public IList<object> Tags { get { return new List<object>(_tags); } }
    }
}