using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemArmorControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemArmorControl()
        {
            InitializeComponent();
            initDefensiveStatGrid();
        }

        public override void initNewImpl()
        {
            //TagUtils.fillComboBox(cboArmorType, "ArmorTypeTags", 0, String.Empty);  
            ComboUtils.fillCombo(cboArmorType, "ref_armor_type", "name", "ref_armor_type_id", 0);
            ComboUtils.fillCombo(cboArmorClass, "ref_armor_class", "name", "ref_armor_class_id", 0);
        }

        private void initDefensiveStatGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Statistic;
                col.Name = "statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Statistic";
                col.CellTemplate = cell;
                gridDefensiveStats.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "value";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Stat Modifier";
                col.CellTemplate = cell;
                col.Maximum = 100;
                col.Minimum = -100;
                gridDefensiveStats.Columns.Add(col);
            }
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_armor_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_armor_map_id"];
            ComboUtils.fillCombo(cboArmorType, "ref_armor_type", "name", "ref_armor_type_id", (int)dataRow["ref_armor_type_id"]);
            ComboUtils.fillCombo(cboArmorClass, "ref_armor_class", "name", "ref_armor_class_id", (int)dataRow["ref_armor_class_id"]);

            loadDefensiveStatGrid(aDefId);
        }

        private void loadDefensiveStatGrid(int aId)
        {
            gridDefensiveStats.Rows.Clear();

            DataTable dt = Database.getData("item_armor_stat_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridDefensiveStats.Rows.Add();
                DataGridViewRow gridRow = gridDefensiveStats.Rows[gridIndex];

                DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellMod = gridRow.Cells["value"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellMod.Value = (int)rowView["value"];

                gridRow.Tag = (int)rowView["item_armor_stat_map_id"];
            }
            dt.Dispose();
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
            Database.deleteData("item_armor_stat_map", "item_def_id", aDefId);
            Database.deleteData("item_armor_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_armor_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_armor_map");

            Database.updateData("item_armor_map", "item_armor_map_id", mItemMapId, "ref_armor_type_id", (cboArmorType.SelectedItem as TagInfo).Id);
            Database.updateData("item_armor_map", "item_armor_map_id", mItemMapId, "ref_armor_class_id", (cboArmorClass.SelectedItem as TagInfo).Id);

            saveDefensiveStatsGrid(aDefId);
        }

        private void saveDefensiveStatsGrid(int aDefId)
        {
            foreach (DataGridViewRow gridRow in gridDefensiveStats.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_armor_stat_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_armor_stat_map");

                    Database.updateData("item_armor_stat_map", "item_armor_stat_map_id", rowId, "statistic_def_id", statDefIdBrowseInfo.Id);
                    if (gridRow.Cells["value"].Value != null)
                        Database.updateData("item_armor_stat_map", "item_armor_stat_map_id", rowId, "value", (int)gridRow.Cells["value"].Value);
                }
            }
            gridDefensiveStats.flushDeletedRows();
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_armor_stat_map", "item_def_id", aDefId);
            Database.deleteData("item_armor_map", "item_def_id", aDefId);
        }
    }
}
