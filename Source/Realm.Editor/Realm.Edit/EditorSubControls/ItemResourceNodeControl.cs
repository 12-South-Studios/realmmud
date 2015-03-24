using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemResourceNodeControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemResourceNodeControl()
        {
            InitializeComponent();
            initResourcesGrid();
        }

        public override void initNewImpl()
        {
        }

        private void initResourcesGrid()
        {
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_tool_type_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Tool Type";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_tool_type", "ref_tool_type_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridResources.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Statistic;
                col.Name = "statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Statistic";
                col.CellTemplate = cell;
                gridResources.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "min_skill";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Min Skill";
                col.CellTemplate = cell;
                col.Maximum = 9999;
                col.Minimum = 1;
                gridResources.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "gather_amount";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Gather Amount";
                col.CellTemplate = cell;
                col.Maximum = 9999;
                col.Minimum = 1;
                gridResources.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Item;
                col.Name = "resource_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Resource";
                col.CellTemplate = cell;
                gridResources.Columns.Add(col);
            }
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_resource_node_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_resource_node_map_id"];
            dt.Dispose();

            loadResourcesGrid(aDefId);
        }

        private void loadResourcesGrid(int aDefId)
        {
            gridResources.Rows.Clear();

            DataTable dt = Database.getData("item_resource_node_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridResources.Rows.Add();
                DataGridViewRow gridRow = gridResources.Rows[gridIndex];

                DataGridViewComboBoxCell cellType = gridRow.Cells["ref_tool_type_id"] as DataGridViewComboBoxCell;
                ComboUtils.fillComboCellWithRefTable(cellType, "ref_tool_type", "ref_tool_type_id", "name", Database.getNullableId(rowView, "ref_tool_type_id"));

                DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellSkill = gridRow.Cells["min_skill"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellSkill.Value = (int)rowView["min_skill"];

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellGather = gridRow.Cells["gather_amount"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellGather.Value = (int)rowView["gather_amount"];

                DataGridViewLinkCell cellResource = gridRow.Cells["resource_def_id"] as DataGridViewLinkCell;
                cellResource.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "resource_def_id");

                gridRow.Tag = (int)rowView["item_resource_node_map_id"];
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
            Database.deleteData("item_resource_node_map", "item_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridResources.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statDefIdBrowseInfo == null) continue;

                    EditorBrowseInfo resourceDefIdBrowseInfo = gridRow.Cells["resource_def_id"].Value as EditorBrowseInfo;

                    int rowId = Database.createData("item_resource_node_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_resource_node_map");

                    Database.updateData("item_resource_node_map", "item_resource_node_map_id", rowId, "ref_tool_type_id", (int)gridRow.Cells["ref_tool_type_id"].Value);
                    Database.updateData("item_resource_node_map", "item_resource_node_map_id", rowId, "statistic_def_id", statDefIdBrowseInfo.Id);
                    Database.updateData("item_resource_node_map", "item_resource_node_map_id", rowId, "min_skill", (int)gridRow.Cells["min_skill"].Value);
                    Database.updateData("item_resource_node_map", "item_resource_node_map_id", rowId, "gather_amount", (int)gridRow.Cells["gather_amount"].Value);
                    Database.updateData("item_resource_node_map", "item_resource_node_map_id", rowId, "resource_def_id", resourceDefIdBrowseInfo.Id);
                }
            }
            gridResources.flushDeletedRows();
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_resource_node_map", "item_def_id", aDefId);
        }
    }
}
