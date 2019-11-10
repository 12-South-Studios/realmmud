using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.Edit.Tags;
using Realm.Library.Common;

namespace Realm.Edit.Extensions
{
    public static class CheckedListBoxExtensions
    {
        public static void Fill(this CheckedListBox value, string categoryName)
        {
            Validation.IsNotNull(value, "value");
            Validation.IsNotNullOrEmpty(categoryName, "categoryName");

            value.Fill(categoryName, false);
        }

        public static void Fill(this CheckedListBox value, string categoryName, bool defaultCheckState)
        {
            Validation.IsNotNull(value, "value");
            Validation.IsNotNullOrEmpty(categoryName, "categoryName");

            value.BeginUpdate();
            value.Items.Clear();
            value.CheckOnClick = true;

            var tagSet = SystemTags.GetTagSet(categoryName);

            foreach (var tag in tagSet.Tags.Values)
                value.Items.Add(tag, defaultCheckState);

            value.EndUpdate();
        }

        /// <summary>
        /// Fill a checked list box with all the tags from a category, and set their check state
        /// A tag will be checked if there is a row in aVew whose aTagColumnName column has the tag value
        /// \note Its expected that aView has already been filtered for a specific item
        /// </summary>
        /*public static void FillCheckedList(CheckedListBox aCheckedList, string aCategoryName,
                                           DataView aView, string aTagColumnName)
        {
            aCheckedList.BeginUpdate();
            aCheckedList.Items.Clear();
            aCheckedList.CheckOnClick = true;

            var tagSet = SystemTags.GetTagSet(aCategoryName);
            foreach (var tag in tagSet.Tags.Values)
            {
                int index = aCheckedList.Items.Add(tag, false);
                foreach (DataRowView dbRow in aView)
                {
                    if ((int)dbRow[aTagColumnName] == tag.Value)
                    {
                        aCheckedList.SetItemChecked(index, true);
                        break;
                    }
                }
            }

            aCheckedList.EndUpdate();
        }*/

        public static void Fill(this CheckedListBox value, string categoryName, int tagSetId )
        {
            Validation.IsNotNull(value, "value");
            Validation.IsNotNullOrEmpty(categoryName, "categoryName");

            value.BeginUpdate();
            value.Items.Clear();
            value.CheckOnClick = true;

            var dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var checkedTagSetList = dbContext.TagSets.Include(x => x.Tags).Where(x => x.Id == tagSetId);
            if (!checkedTagSetList.Any() || checkedTagSetList.Count() > 1)
            {
                value.EndUpdate();
                return;
            }
            var tagList = checkedTagSetList.First().Tags.ToList();

            var tagSet = SystemTags.GetTagSet(categoryName);
            foreach (var tag in tagSet.Tags.Values.Where(tag => tagList.Exists(x => x.Id == tag.Id)))
            {
                value.SetItemChecked(value.Items.Add(tag, false), true);
                break;
            }

            value.EndUpdate();
        }

        /// <summary>
        /// Write a tag from a combobox to a row
        /// </summary>
        /*public static void saveComboBox(DataRowView aRow, string aColumn, ComboBox aBox)
        {
            SystemTag selectedTag = aBox.SelectedItem as SystemTag;
            if (selectedTag == null || selectedTag.Value == 0)
                aRow[aColumn] = DBNull.Value;
            else
                aRow[aColumn] = (aBox.SelectedItem as SystemTag).Value;
        }*/

        /*public static void saveCheckedList(CheckedListBox aListBox, string aTableName, string aKeyCol, string aTagCol, int aKey)
        {
            // Delete all of the rows which were there.
            // We will be inserting new rows for them.
            Database.deleteRows(aTableName, aKeyCol + " = " + aKey);

            // Insert new rows for the item/tag map.
            DataView viewTags = Database.createView(aTableName);
            foreach (SystemTag tagInfo in aListBox.CheckedItems)
            {
                DataRowView row = viewTags.AddNew();
                row.BeginEdit();

                row[aKeyCol] = aKey;
                row[aTagCol] = tagInfo.Value;
                row.EndEdit();
                Database.updateRow(row.Row);
            }
            viewTags.Dispose();
        }*/

        public static int GetTagCount(this CheckedListBox value)
        {
            Validation.IsNotNull(value, "value");

            return value.CheckedItems.Count;
        }

        public static int SaveTagSet(this CheckedListBox value)
        {
            Validation.IsNotNull(value, "value");

            var key = 0;
            if (value.CheckedItems.Count <= 0) return key;
            key = TagSetUtils.CreateTagSet();
            value.Save(key);
            return key;
        }

        private static void Save(this CheckedListBox value, int tagSetId)
        {
            Validation.IsNotNull(value, "value");

            /*using (var scope = new TransactionScope())
            {
                TagSetUtils.ClearTagSetMap(tagSetId);
                var dal = Program.NinjectKernel.Get<ITagDal>();
 
                foreach (SystemTag tagInfo in value.CheckedItems)
                {
                    dal.AddTagToTagSet(tagSetId, (short)tagInfo.Value);
                }

                scope.Complete();
            }*/
        }
    }
}
