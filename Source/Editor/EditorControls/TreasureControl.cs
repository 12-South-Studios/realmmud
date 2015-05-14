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
    // TreasureControl
    // **************************************************
    public partial class TreasureControl : BaseEditorControl
    {
        public TreasureControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public TreasureControl(int aClassId)
            : base(EditorSystemType.Treasure, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "treasure_def", "system_name");
            TextBoxUtils.initTextBox(txtSystemDescription, "treasure_def", "system_description");

            initTablesGrid();
        }

        private void initTablesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.TreasureTable;
                col.Name = "treasure_table_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Treasure Table";
                col.CellTemplate = cell;
                gridTables.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "item_quantity";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Quantity";
                col.CellTemplate = cell;
                col.Maximum = 99;
                col.Minimum = 1;
                cell.Value = 1;
                gridTables.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "min_coin";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Min Coin";
                col.CellTemplate = cell;
                col.Maximum = 9999999;
                col.Minimum = 0;
                cell.Value = 0;
                gridTables.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "max_coin";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Max Coin";
                col.CellTemplate = cell;
                col.Maximum = 9999999;
                col.Minimum = 0;
                cell.Value = 0;
                gridTables.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("treasure_def", "treasure_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Treasure [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Treasure [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Treasure loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtSystemDescription.Text = dataRow["system_description"].ToString();

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadTablesGrid(aId);
        }

        private void loadTablesGrid(int aId)
        {
            gridTables.Rows.Clear();

            DataTable dt = Database.getData("treasure_table_map", "treasure_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridTables.Rows.Add();
                DataGridViewRow gridRow = gridTables.Rows[gridIndex];

                DataGridViewLinkCell cellTable = gridRow.Cells["treasure_table_def_id"] as DataGridViewLinkCell;
                cellTable.Value = EditorFactory.getBrowseInfo(EditorSystemType.TreasureTable, rowView, "treasure_table_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridRow.Cells["item_quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                if (rowView["item_quantity"] != System.DBNull.Value)
                    cellQty.Value = (int)rowView["item_quantity"];

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellMin = gridRow.Cells["min_coin"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                if (rowView["min_coin"] != System.DBNull.Value) 
                    cellMin.Value = (int)rowView["min_coin"];

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellMax = gridRow.Cells["max_coin"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                if (rowView["max_coin"] != System.DBNull.Value) 
                    cellMax.Value = (int)rowView["max_coin"];

                gridRow.Tag = (int)rowView["treasure_table_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridTables.EndEdit();

            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("treasure_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Treasure Def");
                }
                else
                    Database.updateData("treasure_def", "treasure_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("treasure_def", "treasure_def_id", Id, "system_description", txtSystemDescription.Text);

                saveTablesGrid(Id);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving treasure [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveTablesGrid(int aDefId)
        {
            Database.deleteData("treasure_table_map", "treasure_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridTables.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    int rowId = Database.createData("treasure_table_map", "treasure_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in treasure_table_map");

                    EditorBrowseInfo tableDefIdBrowseInfo = gridRow.Cells["treasure_table_def_id"].Value as EditorBrowseInfo;
                    if (tableDefIdBrowseInfo != null)
                        Database.updateData("treasure_table_map", "treasure_table_map_id", rowId, "treasure_table_def_id", tableDefIdBrowseInfo.Id);

                    if (gridRow.Cells["item_quantity"].Value != null)
                        Database.updateData("treasure_table_map", "treasure_table_map_id", rowId, "item_quantity", (int)gridRow.Cells["item_quantity"].Value);
                    if (gridRow.Cells["min_coin"].Value != null) 
                        Database.updateData("treasure_table_map", "treasure_table_map_id", rowId, "min_coin", (int)gridRow.Cells["min_coin"].Value);
                    if (gridRow.Cells["max_coin"].Value != null) 
                        Database.updateData("treasure_table_map", "treasure_table_map_id", rowId, "max_coin", (int)gridRow.Cells["max_coin"].Value);
                }
            }
            gridTables.flushDeletedRows();
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


            // Validate Description
            if (txtSystemDescription.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Description");
                    txtSystemDescription.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemDescription.BackColor = Color.Empty;
            }
            return valid;
        }
    }


    // **************************************************
    // TreasureBuilder
    // **************************************************
    public class TreasureBuilder : EditorBuilder
    {
        public TreasureBuilder()
            : base(EditorSystemType.Treasure, "Treasure", "Treasures")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new TreasureControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "treasure_def", "system_name", "class_id = " + aClassId, "treasure_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("treasure_table_map", "treasure_def_id = " + aId);
            Database.deleteData("treasure_table_map", "treasure_def_id", aId);
            //Database.deleteData("treasure_def", "treasure_def_id = " + aId);
            Database.deleteData("treasure_def", "treasure_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("treasure_def", "treasure_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("treasure_def", aId, "system_name").ToString();
            return Database.getData("treasure_def", "treasure_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("treasure_def", aId, "system_name", "treasure_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("treasure_def");
        }

    }
}