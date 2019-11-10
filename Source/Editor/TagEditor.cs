using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.DAL.Models;
using Realm.Edit.Tags;

namespace Realm.Edit
{
    public partial class TagEditorForm : Form
    {
        private Dictionary<string, List<int>> DeletedTags { get; }

        public TagEditorForm()
        {
            InitializeComponent();
            DeletedTags = new Dictionary<string, List<int>>();
            InitializeData();
            ActiveControl = cboCategory;
        }

        private void InitializeData()
        {
            listTags.Items.Clear();

            cboCategory.BeginUpdate();
            cboCategory.Items.Clear();

            DeletedTags.Clear();
            foreach (var tagSet in SystemTags.TagSetValues)
            {
                var copyTagSet = new SystemTagSet(tagSet);
                cboCategory.Items.Add(copyTagSet);
                DeletedTags.Add(tagSet.Name, new List<int>());
            }

            if (cboCategory.Items.OfType<object>().Any())
                cboCategory.SelectedIndex = 0;

            cboCategory.EndUpdate();
        }

        private void SaveTags()
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();

            foreach (SystemTagSet set in cboCategory.Items)
            {
                var tagSet = set;

                foreach (var id in DeletedTags[tagSet.Name])
                {
                    var tag = dbContext.Tags.FirstOrDefault(x => x.Id == id);
                    dbContext.Tags.Remove(tag);
                }

                foreach (var tag in tagSet.Tags.Values)
                {
                    var foundTag = dbContext.Tags.FirstOrDefault(x => x.Name == tag.Name
                                                                      && x.TagCategory == set.Category);
                    if (foundTag == null)
                    {
                        foundTag = new Tag();
                        dbContext.Tags.Add(foundTag);
                    }

                    foundTag.Name = tag.Name;
                    foundTag.TagCategory = set.Category;
                }

                dbContext.SaveChanges();
            }

            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            SaveTags();
        }

        private void CboCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem == null) return;
            listTags.BeginUpdate();
            listTags.Items.Clear();

            var tagSet = cboCategory.SelectedItem as SystemTagSet;
            if (tagSet == null) return;

            foreach (var tag in tagSet.Tags.Values)
            {
                listTags.Items.Add(new TagInfo(tag.Name, tag.Id, 0));
            }

            txtTag.Text = string.Empty;
            if (listTags.Items.OfType<object>().Any())
                listTags.SelectedIndex = 0;

            listTags.EndUpdate();
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            if (txtTag.TextLength <= 0 || cboCategory.SelectedItem == null) return;

            var tagSet = cboCategory.SelectedItem as SystemTagSet;
            if (tagSet == null || tagSet.Tags.ContainsKey(txtTag.Text)) return;

            tagSet.AddTag(0, txtTag.Text);
            listTags.SelectedIndex = listTags.Items.Add(new TagInfo(txtTag.Text, 0, 0));
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem == null || listTags.SelectedItem == null) return;

            var tagSet = cboCategory.SelectedItem as SystemTagSet;
            if (tagSet == null) return;

            var tagInfo = listTags.SelectedItem as TagInfo;
            if (tagInfo == null) return;

            if (tagSet.Tags.ContainsKey(tagInfo.Name))
            {
                tagSet.RemoveTag(tagInfo.Name);
                if ( tagInfo.Id > 0 )
                    DeletedTags[tagSet.Name].Add(tagInfo.Id);
            }

            var saveIndex = listTags.SelectedIndex;
            listTags.Items.RemoveAt(listTags.SelectedIndex);
            listTags.SelectedIndex = saveIndex < listTags.Items.Count ? saveIndex : listTags.Items.Count - 1;
        }

        private void BtnUpdateClick(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem == null || listTags.SelectedItem == null) return;

            var tagInfo = listTags.SelectedItem as TagInfo;
            if (tagInfo == null) return;

            var tagSet = cboCategory.SelectedItem as SystemTagSet;
            if (tagSet == null) return;

            if (tagSet.Tags.ContainsKey(tagInfo.Name) && !tagSet.Tags.ContainsKey(txtTag.Text))
            {
                var tag = tagSet.GetTag(tagInfo.Name);
                tagSet.RemoveTag(tag.Name);
                tag.Name = txtTag.Text;
                tagSet.AddTag(tag.Id, tag.Name);
                tagInfo.Name = txtTag.Text;
            }
                
            // Update the list.  Probably a better way to do this
            var listIndex = listTags.SelectedIndex;
            var cboIndex = cboCategory.SelectedIndex;
            cboCategory.SelectedIndex = -1;
            cboCategory.SelectedIndex = cboIndex;
            listTags.SelectedIndex = listIndex;
        }

        private void TagEditorFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SystemTags.Init();
        }

        private void ListTagsSelectedIndexChanged(object sender, EventArgs e)
        {
            var enabled = listTags.SelectedIndex >= 0;
            btnRemove.Enabled = enabled;
            txtTag.Text = enabled ? listTags.SelectedItem.ToString() : string.Empty;
        }

        private void TxtTagTextChanged(object sender, EventArgs e)
        {
            var enabled = false;
            if (cboCategory.SelectedItem != null && listTags.SelectedItem != null)
            {
                var tagSet = cboCategory.SelectedItem as SystemTagSet;
                if (tagSet == null) return;

                var tagInfo = listTags.SelectedItem as TagInfo;
                if (tagInfo == null) return;

                if (!tagSet.Tags.ContainsKey(txtTag.Text))
                {
                    if (tagInfo.Name != txtTag.Text)
                        enabled = true;
                }
            }

            btnUpdate.Enabled = enabled;
        }
    }
}