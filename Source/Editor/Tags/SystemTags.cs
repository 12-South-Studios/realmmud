using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Realm.DAL.Enumerations;
using Realm.Library.Common;

namespace Realm.Edit.Tags
{
    public static class SystemTags
    {
        private static Dictionary<string, SystemTagSet> TagSets { get; }

        static SystemTags()
        {
            TagSets = new Dictionary<string, SystemTagSet>();
        }

        public static void Init()
        {
            TagSets.Clear();

            if (Program.MainForm != null)
            {
                Program.MainForm.ProgressStatus.Minimum = 0;
                Program.MainForm.ProgressStatus.Maximum = Enum.GetValues(typeof (TagCategoryTypes)).Length;
                Program.MainForm.ProgressStatus.Value = 0;
            }

            foreach (var category in EnumerationFunctions.GetAllEnumValues<TagCategoryTypes>())
            {
                var tagSet = new SystemTagSet(category.ToString(), category);
                tagSet.AddTags(category);
                TagSets.Add(category.ToString(), tagSet);

                Application.DoEvents();
                if (Program.MainForm == null) continue;

                Program.MainForm.ProgressStatus.Value++;
                Program.MainForm.SetStatusMessage($"Loading Tag Category [{category}]");
            }

            Program.Log.InfoFormat($"{Enum.GetValues(typeof(TagCategoryTypes)).Length} tag categories loaded.");
        }

        public static SystemTagSet GetTagSet(string setName)
        {
            SystemTagSet value;
            return TagSets.TryGetValue(setName, out value) ? value : null;
        }

        public static SystemTag GetTag(string setName, string tagName)
        {
            var tagSet = GetTagSet(setName);
            return tagSet?.GetTag(tagName);
        }

        public static SystemTag GetTag(string setName, int tagId)
        {
            var tagSet = GetTagSet(setName);
            return tagSet?.GetTag(tagId);
        }

        public static IEnumerable<SystemTagSet> TagSetValues => TagSets.Values;
    }
}
