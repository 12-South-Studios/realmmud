using System;
using System.Data.Entity;
using System.Linq;
using Ninject;
using Realm.DAL;
using Realm.DAL.Models;

namespace Realm.Edit.Tags
{
    public static class TagSetUtils
    {
        public static int CreateTagSet()
        {
            try
            {
                var dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var newTagSet = new TagSet();
                dbContext.TagSets.Add(newTagSet);
                dbContext.SaveChanges();

                return newTagSet.Id;
            }
            catch (Exception ex)
            {
                
            }

            return 0;
        }

        public static void ClearTagSetMap(int tagSetId)
        {
            try
            {
                var dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var tagSet = dbContext.TagSets.Include(x => x.Tags).FirstOrDefault(x => x.Id == tagSetId);
                if (tagSet == null) return;

                tagSet.Tags.Clear();
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void DeleteTagSet(int tagSetId)
        {
            try
            {
                var dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var tagSet = new TagSet();
                dbContext.TagSets.Remove(tagSet);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }

        /*public static void loadTagSet(DataGridViewCheckComboBoxCell cell, DataRowView dbRow, String columnName)
        {
            DataView viewTagSetMap = Database.createView("tag_set_map");
            viewTagSetMap.RowFilter = "tag_set_def_id = " + dbRow[columnName];
            foreach (DataGridViewCheckComboBoxControl.CheckComboBoxItem checkBoxItem in cell.Items)
            {
                bool foundMatchingTag = false;
                foreach (DataRowView rowView in viewTagSetMap)
                {
                    int tagDefId = (int)rowView["tag_def_id"];
                    if (tagDefId == checkBoxItem.ID)
                    {
                        foundMatchingTag = true;
                    }
                }
                if (foundMatchingTag)
                {
                    checkBoxItem.CheckState = true;
                }
                else
                {
                    checkBoxItem.CheckState = false;
                }
            }
            viewTagSetMap.Dispose();
        }*/

        /*public static void saveTagSet(DataGridViewCheckComboBoxCell cell, DataRowView dbRow, String columnName)
        {
            DataView viewTagSetDef = Database.createView("tag_set_def");
            DataView viewTagSetMap = Database.createView("tag_set_map");

            int tagSetDefId = 0;
            if (dbRow[columnName] == DBNull.Value)
            {
                DataRowView rowTagSetDef = Database.getOrCreateRow(viewTagSetDef, 0);
                rowTagSetDef.BeginEdit();
                rowTagSetDef.EndEdit();
                Database.updateRow(rowTagSetDef.Row);
                tagSetDefId = (int)rowTagSetDef["tag_set_def_id"];
                dbRow[columnName] = tagSetDefId;
            }
            else
            {
                tagSetDefId = (int)dbRow[columnName];
            }

            Database.deleteRows("tag_set_map", "tag_set_def_id = " + tagSetDefId);
            foreach (DataGridViewCheckComboBoxControl.CheckComboBoxItem checkBoxItem in cell.Items)
            {
                if (checkBoxItem.CheckState == true)
                {
                    DataRowView rowTagSetMap = Database.getOrCreateRow(viewTagSetMap, 0);
                    rowTagSetMap.BeginEdit();
                    rowTagSetMap["tag_set_def_id"] = tagSetDefId;
                    rowTagSetMap["tag_def_id"] = checkBoxItem.ID;
                    rowTagSetMap.EndEdit();
                    Database.updateRow(rowTagSetMap.Row);
                }
            }

            viewTagSetDef.Dispose();
            viewTagSetMap.Dispose();
        }*/
    }
}
