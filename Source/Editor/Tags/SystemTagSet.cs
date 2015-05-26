using System.Collections.Generic;
using System.Linq;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.Library.Common;

namespace Realm.Edit.Tags
{
    public class SystemTagSet
    {
        public string Name { get; private set; }
        public TagCategoryTypes Category { get; private set; }

        public Dictionary<string, SystemTag> Tags { get; private set; }
        private Dictionary<int, SystemTag> TagsById { get; set; }

        public SystemTagSet(string name, TagCategoryTypes category)
        {
            Name = name;
            Category = category;
            Tags = new Dictionary<string, SystemTag>();
            TagsById = new Dictionary<int, SystemTag>();
        }

        public SystemTagSet(SystemTagSet copy) : this(copy.Name, copy.Category)
        {
            foreach (var tag in copy.Tags.Values)
            {
                AddTag(tag.Id, tag.Name);
            }
        }

        public void AddTags(TagCategoryTypes category)
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var tagList = dbContext.Tags.Where(x => x.TagCategory == category).ToList();
            if (tagList.IsNull()) return;

            tagList.ForEach(x => AddTag(x.Id, x.Name));
        }

        public bool HasTag(int tagId)
        {
            return TagsById.ContainsKey(tagId);
        }

        public void AddTag(int tagId, string name)
        {
            Validation.IsNotNullOrEmpty(name, "name");

            var tag = new SystemTag(tagId, name);
            Tags.Add(name, tag);
            if (tagId > 0)
                TagsById.Add(tagId, tag);
        }

        public void RemoveTag(string name)
        {
            Validation.IsNotNullOrEmpty(name, "name");

            if (!Tags.ContainsKey(name)) return;

            var tag = GetTag(name);
            Tags.Remove(tag.Name);
            TagsById.Remove(tag.Id);
        }

        public SystemTag GetTag(string name)
        {
            Validation.IsNotNullOrEmpty(name, "name");

            SystemTag value;
            return Tags.TryGetValue(name, out value) ? value : null;
        }

        public SystemTag GetTag(int value)
        {
            SystemTag value1;
            return TagsById.TryGetValue(value, out value1) ? value1 : null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
