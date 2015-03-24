using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace RealmEdit
{
    // **************************************************
    // ShopControl
    // **************************************************
    public partial class ShopControl : BaseEditorControl
    {
        private int mItemTypeTagSetId = 0;

        public ShopControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public ShopControl(int aClassId)
            : base(EditorSystemType.Shop, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "shop_def", "system_name");

            initItemTypesGrid();
            initItemsGrid();
            initAbilitiesGrid();
        }

        private void initItemTypesGrid()
        {
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_item_type_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Item Type";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_item_type", "ref_item_type_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridItemTypes.Columns.Add(col);
            }
        }

        private void initItemsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Item;
                col.Name = "item_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Items";
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

        private void initAbilitiesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Ability;
                col.Name = "ability_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Abilities";
                col.CellTemplate = cell;
                gridAbilities.Columns.Add(col);
            }
        }

        public override void initTooltipsImpl()
        {
            setTooltip(numBuy, "The percentage to mark-DOWN the value of an item when buying it from a player.", true);
            setTooltip(numSell, "The percentage to mark-UP the value of an item when selling it to a player.", true);
        }

        public override void initNewImpl()
        {

        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("shop_def", "shop_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Shop [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Shop [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Shop loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            numBuy.Value = (int)dataRow["buy_markup"];
            numSell.Value = (int)dataRow["sell_markup"];

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadItemTypesGrid(aId);
            loadItemsGrid(aId);
            loadAbilitiesGrid(aId);
        }

        private void loadItemTypesGrid(int aId)
        {
            gridItemTypes.Rows.Clear();

            DataTable dt = Database.getData("shop_item_type_map", "shop_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItemTypes.Rows.Add();
                DataGridViewRow gridRow = gridItemTypes.Rows[gridIndex];

                DataGridViewComboBoxCell cellItemType = gridRow.Cells["ref_item_type_id"] as DataGridViewComboBoxCell;
                if (Database.getNullableId(rowView, "ref_item_type_id") == 0)
                    ComboUtils.fillComboCellWithRefTable(cellItemType, "ref_item_type", "ref_item_type_id", "name", 6);
                    //cellItemType.Value = 6;   // None
                else
                    ComboUtils.fillComboCellWithRefTable(cellItemType, "ref_item_type", "ref_item_type_id", "name", Database.getNullableId(rowView, "ref_item_type_id"));

                gridRow.Tag = (int)rowView["shop_item_type_map_id"];
            }
            dt.Dispose();
        }

        private void loadAbilitiesGrid(int aId)
        {
            gridAbilities.Rows.Clear();

            DataTable dt = Database.getData("shop_ability_map", "shop_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridAbilities.Rows.Add();
                DataGridViewRow gridRow = gridAbilities.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["ability_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Ability, rowView, "ability_def_id");

                gridRow.Tag = (int)rowView["shop_ability_map_id"];
            }
            dt.Dispose();
        }

        private void loadItemsGrid(int aId)
        {
            gridItems.Rows.Clear();

            DataTable dt = Database.getData("shop_item_map", "shop_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItems.Rows.Add();
                DataGridViewRow gridRow = gridItems.Rows[gridIndex];

                DataGridViewLinkCell cellItem = gridRow.Cells["item_def_id"] as DataGridViewLinkCell;
                cellItem.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "item_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridRow.Cells["quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellQty.Value = (int)rowView["quantity"];

                gridRow.Tag = (int)rowView["shop_item_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridItems.EndEdit();

            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("shop_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Shop Def");
                }
                else
                    Database.updateData("shop_def", "shop_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("shop_def", "shop_def_id", Id, "buy_markup", (int)numBuy.Value);
                Database.updateData("shop_def", "shop_def_id", Id, "sell_markup", (int)numSell.Value);

                saveItemTypesGrid(Id);
                saveItemsGrid(Id);
                saveAbilitiesGrid(Id);

                // Delete the old tag sets if they existed
                if (mItemTypeTagSetId > 0)
                    TagUtils.deleteTagSet(mItemTypeTagSetId);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving shop [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveItemTypesGrid(int aDefId)
        {
            Database.deleteData("shop_item_type_map", "shop_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridItemTypes.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    int rowId = Database.createData("shop_item_type_map", "shop_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in shop_item_type_map");

                    if (gridRow.Cells["ref_item_type_id"].Value != null)
                        Database.updateData("shop_item_type_map", "shop_item_type_map_id", rowId, "ref_item_type_id", (int)gridRow.Cells["ref_item_type_id"].Value);
                    else
                        Database.updateData("shop_item_type_map", "shop_item_type_map_id", rowId, "ref_item_type_id", 0);
                }
            }
            gridItemTypes.flushDeletedRows();
        }

        private void saveItemsGrid(int aDefId)
        {
            Database.deleteData("shop_item_map", "shop_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridItems.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo itemDefIdBrowseInfo = gridRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                    if (itemDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("shop_item_map", "shop_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in shop_item_map");

                    Database.updateData("shop_item_map", "shop_item_map_id", rowId, "item_deF_id", itemDefIdBrowseInfo.Id);
                    Database.updateData("shop_item_map", "shop_item_map_id", rowId, "quantity", (int)gridRow.Cells["quantity"].Value);
                }
            }
            gridItems.flushDeletedRows();
        }

        private void saveAbilitiesGrid(int aDefId)
        {
            Database.deleteData("shop_ability_map", "shop_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAbilities.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo abilityDefIdBrowseInfo = gridRow.Cells["ability_def_id"].Value as EditorBrowseInfo;
                    if (abilityDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("shop_ability_map", "shop_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in shop_ability_map");

                    Database.updateData("shop_ability_map", "shop_ability_map_id", rowId, "ability_def_id", abilityDefIdBrowseInfo.Id);
                }
            }
            gridAbilities.flushDeletedRows();
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            bool valid = true;
            Color errorColor = Color.DarkRed;

            // Validate system name
            if (txtSystemName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemName.BackColor = Color.Empty;
            }

            return valid;
        }
    }


    // **************************************************
    // ShopBuilder
    // **************************************************
    public class ShopBuilder : EditorBuilder
    {
        public ShopBuilder()
            : base(EditorSystemType.Shop, "Shop", "Shops")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new ShopControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "shop_def", "system_name", "class_id = " + aClassId, "shop_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("shop_ability_map", "shop_def_id = " + aId);
            Database.deleteData("shop_ability_map", "shop_def_id", aId);
            //Database.deleteData("shop_item_type_map", "shop_def_id = " + aId);
            Database.deleteData("shop_item_type_map", "shop_def_id", aId);
            //Database.deleteData("shop_item_map", "shop_def_id = " + aId);
            Database.deleteData("shop_item_map", "shop_def_id", aId);
            //Database.deleteData("shop_def", "shop_def_id = " + aId);
            Database.deleteData("shop_def", "shop_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("shop_def", "shop_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("shop_def", aId, "system_name").ToString();
            return Database.getData("shop_def", "shop_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("shop_def", aId, "system_name", "shop_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("shop_def");
        }

    }
}

