using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemRuneControl : ItemSubControl
    {
        public ItemRuneControl()
        {
            InitializeComponent();

            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Slot;
                col.Name = "slot_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Slot";
                col.CellTemplate = cell;
                gridSockets.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
        }

        public override void loadItemData(int aDefId)
        {
            gridSockets.Rows.Clear();

            int flags = 0;

            DataTable dt = Database.getData("item_rune_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            foreach (DataRowView rowView in dt.Rows)
            {
                int gridIndex = gridSockets.Rows.Add();
                DataGridViewRow gridRow = gridSockets.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["slot_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Slot, rowView, "slot_def_id");

                flags = (int)rowView["flags"];

                gridRow.Tag = (int)rowView["item_rune_map_id"];
            }
            dt.Dispose();

            chkIsRemovable.Checked = ((flags & Globals.RUNE_FLAG_Removable) != 0) ? true : false;
        }

        private void loadSocketGrid(int aId)
        {

        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_rune_map", "item_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridSockets.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo slotDefIdBrowseInfo = gridRow.Cells["slot_def_id"].Value as EditorBrowseInfo;
                    if (slotDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_rune_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_rune_map");

                    Database.updateData("item_rune_map", "item_rune_map_id", rowId, "slot_def_id", slotDefIdBrowseInfo.Id);
                    
                    int flags =
                        (chkIsRemovable.Checked ? Globals.RUNE_FLAG_Removable : 0);
                    Database.updateData("item_rune_map", "item_rune_map_id", rowId, "flags", flags);
                }
            }
            gridSockets.flushDeletedRows();
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_rune_map", "item_def_id", aDefId);
        }
    }
}

