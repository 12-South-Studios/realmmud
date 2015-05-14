using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemContainerControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemContainerControl()
        {
            InitializeComponent();
            initItemsGrid();

            chkIsLocked.Visible = false;
            linkLock.Visible = false;
            linkLock.SystemType = EditorSystemType.Item;
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboSize, "ref_size", "name", "ref_size_id", 0);
        }

        private void initItemsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Item;
                col.Name = "contained_item_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Item";
                col.CellTemplate = cell;
                gridItems.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "quantity";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Quantity";
                col.CellTemplate = cell;
                col.Maximum = 9999;
                col.Minimum = 1;
                gridItems.Columns.Add(col);
            }
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_container_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_container_map_id"];

            numVolume.Value = (int)dataRow["volume_allowance"];
            numWeight.Value = (int)dataRow["weight_allowance"];
           
            ComboUtils.fillCombo(cboSize, "ref_size", "name", "ref_size_id", (int)dataRow["ref_size_id"]);

            int flags = (int)dataRow["flags"];
            chkIsCloseable.Checked = ((flags & Globals.CONTAINER_FLAG_Closeable) != 0) ? true : false;
            chkIsLockable.Checked = ((flags & Globals.CONTAINER_FLAG_Lockable) != 0) ? true : false;
            chkIsLocked.Checked = ((flags & Globals.CONTAINER_FLAG_Locked) != 0) ? true : false;

            if (chkIsLockable.Checked)
            {
                EditorFactory.setupLink(linkLock, EditorSystemType.Item, Database.getNullableId(dataRow, "lock_item_def_id"));
            }
            dt.Dispose();

            loadItemsGrid(aDefId);
        }

        private void loadItemsGrid(int aId)
        {
            gridItems.Rows.Clear();

            DataTable dt = Database.getData("item_container_map_item_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItems.Rows.Add();
                DataGridViewRow gridRow = gridItems.Rows[gridIndex];

                DataGridViewLinkCell cellItem = gridRow.Cells["contained_item_def_id"] as DataGridViewLinkCell;
                cellItem.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "contained_item_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridRow.Cells["quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellQty.Value = (int)rowView["quantity"];

                gridRow.Tag = (int)rowView["item_container_map_item_map_id"];
            }
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboSize.SelectedIndex == -1)
                return false;

            if (chkIsLockable.Checked)
            {
                if (linkLock.Text == "")
                {
                    return false;
                }
            }

            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_container_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_container_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_container_map");

            Database.updateData("item_container_map", "item_container_map_id", mItemMapId, "volume_allowance", (int)numVolume.Value);
            Database.updateData("item_container_map", "item_container_map_id", mItemMapId, "weight_allowance", (int)numWeight.Value);
            Database.updateData("item_container_map", "item_container_map_id", mItemMapId, "ref_size_id", (cboSize.SelectedItem as TagInfo).Id);

            int flags = 
                    (chkIsCloseable.Checked ? Globals.CONTAINER_FLAG_Closeable : 0) |
                    (chkIsLockable.Checked ? Globals.CONTAINER_FLAG_Lockable : 0) |
                    (chkIsLocked.Checked ? Globals.CONTAINER_FLAG_Locked : 0);
            Database.updateData("item_container_map", "item_container_map_id", mItemMapId, "flags", flags);
            Database.updateData("item_container_map", "item_container_map_id", mItemMapId, "lock_item_def_id", BaseEditorControl.getContentLinkId(linkLock));

            saveItemsGrid(aDefId);
        }

        private void saveItemsGrid(int aDefId)
        {
            foreach (DataGridViewRow gridRow in gridItems.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo itemDefIdBrowseInfo = gridRow.Cells["contained_item_def_id"].Value as EditorBrowseInfo;
                    if (itemDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_container_map_item_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_container_map_item_map");

                    Database.updateData("item_container_map_item_map", "item_container_map_item_map_id", rowId, "contained_item_def_id", itemDefIdBrowseInfo.Id);
                    Database.updateData("item_container_map_item_map", "item_container_map_item_map_id", rowId, "quantity", (int)gridRow.Cells["quantity"].Value);
                }
            }
            gridItems.flushDeletedRows();
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_container_map_item_map", "item_def_id", aDefId);
            Database.deleteData("item_container_map", "item_def_id", aDefId);
        }

        private void chkIsLockable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsLockable.Checked)
            {
                chkIsLocked.Visible = true;
                linkLock.Visible = true;
            }
            else
            {
                chkIsLocked.Visible = false;
                linkLock.Visible = false;
            }
        }

        private void gridItems_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["quantity"].Value = 1;
        }
    }
}

