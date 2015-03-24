using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemFormulaControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemFormulaControl()
        {
            InitializeComponent();
            initResourcesGrid();

            linkSkill.SystemType = EditorSystemType.Statistic;
            linkProduct.SystemType = EditorSystemType.Item;
            linkMachine.SystemType = EditorSystemType.Item;
            linkTool.SystemType = EditorSystemType.Item;
        }

        public override void initNewImpl()
        {
        }

        private void initResourcesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Item;
                col.Name = "resource_item_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Resource";
                col.CellTemplate = cell;
                gridResources.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "resource_quantity";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Quantity";
                col.CellTemplate = cell;
                col.Maximum = 9999;
                col.Minimum = 1;
                gridResources.Columns.Add(col);
            }
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_formula_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_formula_map_id"];

            EditorFactory.setupLink(linkSkill, EditorSystemType.Statistic, Database.getNullableId(dataRow, "statistic_def_id"));
            numMinSkill.Value = (int)dataRow["min_skill"];
            EditorFactory.setupLink(linkProduct, EditorSystemType.Item, Database.getNullableId(dataRow, "product_item_def_id"));
            numProductQty.Value = (int)dataRow["product_quantity"];
            EditorFactory.setupLink(linkMachine, EditorSystemType.Item, Database.getNullableId(dataRow, "machine_item_def_id"));
            EditorFactory.setupLink(linkTool, EditorSystemType.Item, Database.getNullableId(dataRow, "tool_item_def_id"));
            numXpValue.Value = (int)dataRow["xp_value"];
            dt.Dispose();

            loadResourcesGrid(aDefId);
        }

        private void loadResourcesGrid(int aId)
        {
            gridResources.Rows.Clear();

            DataTable dt = Database.getData("item_formula_resource_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridResources.Rows.Add();
                DataGridViewRow gridRow = gridResources.Rows[gridIndex];

                DataGridViewLinkCell cellResource = gridRow.Cells["resource_item_def_id"] as DataGridViewLinkCell;
                cellResource.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "resource_item_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridRow.Cells["resource_quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellQty.Value = (int)rowView["resource_quantity"];

                gridRow.Tag = (int)rowView["item_formula_resource_map_id"];
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
            Database.deleteData("item_formula_resource_map", "item_def_id", aDefId);
            Database.deleteData("item_formula_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_formula_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_formula_map");

            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "statistic_def_id", BaseEditorControl.getContentLinkId(linkSkill));
            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "min_skill", (int)numMinSkill.Value);
            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "product_item_def_id", BaseEditorControl.getContentLinkId(linkProduct));
            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "product_quantity", (int)numProductQty.Value);
            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "machine_item_def_id", BaseEditorControl.getContentLinkId(linkMachine));
            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "tool_item_def_id", BaseEditorControl.getContentLinkId(linkTool));
            Database.updateData("item_formula_map", "item_formula_map_id", mItemMapId, "xp_value", (int)numXpValue.Value);

            saveResourcesGrid(aDefId);
        }

        private void saveResourcesGrid(int aDefId)
        {
            foreach (DataGridViewRow gridRow in gridResources.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo resourceDefIdBrowseInfo = gridRow.Cells["resource_item_def_id"].Value as EditorBrowseInfo;
                    if (resourceDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_formula_resource_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_formula_resource_map");

                    Database.updateData("item_formula_resource_map", "item_formula_resource_map_id", rowId, "resource_item_def_id", resourceDefIdBrowseInfo.Id);
                    Database.updateData("item_formula_resource_map", "item_formula_resource_map_id", rowId, "resource_quantity", (int)gridRow.Cells["resource_quantity"].Value);
                }
            }
            gridResources.flushDeletedRows();
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_formula_resource_map", "item_def_id", aDefId);
            Database.deleteData("item_formula_map", "item_def_id", aDefId);
        }

        private void gridResources_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["quantity"].Value = 1;
        }
    }
}
