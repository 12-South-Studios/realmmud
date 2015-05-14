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
    // TreasureTableControl
    // **************************************************
    public partial class TreasureTableControl : BaseEditorControl
    {
        public TreasureTableControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public TreasureTableControl(int aClassId)
            : base(EditorSystemType.TreasureTable, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "treasure_table_def", "system_name");
            TextBoxUtils.initTextBox(txtSystemDescription, "treasure_table_def", "system_description");

            initItemsGrid();
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
                col.HeaderText = "Treasure Item";
                col.CellTemplate = cell;
                gridItems.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("treasure_table_def", "treasure_table_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Treasure Table [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Treasure Table [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Treasure Table loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtSystemDescription.Text = dataRow["system_description"].ToString();

            ControlName = txtSystemName.Text;

            loadItemsGrid(aId);
        }

        private void loadItemsGrid(int aId)
        {
            gridItems.Rows.Clear();

            DataTable dt = Database.getData("treasure_table_item_map", "treasure_table_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItems.Rows.Add();
                DataGridViewRow gridRow = gridItems.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["item_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "item_def_id");

                gridRow.Tag = (int)rowView["treasure_table_item_map_id"];
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
                    Id = Database.createData("treasure_table_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Treasure Table Def");
                }
                else
                    Database.updateData("treasure_table_def", "treasure_table_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("treasure_table_def", "treasure_table_def_id", Id, "system_description", txtSystemDescription.Text);

                saveItemsGrid(Id);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving treasure table [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveItemsGrid(int aDefId)
        {
            Database.deleteData("treasure_table_item_map", "treasure_table_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridItems.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo itemDefIdBrowseInfo = gridRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                    if (itemDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("treasure_table_item_map", "treasure_table_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in treasure_table_item_map");

                    Database.updateData("treasure_table_item_map", "treasure_table_item_map_id", rowId, "item_def_id", itemDefIdBrowseInfo.Id);
                }
            }
            gridItems.flushDeletedRows();
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
    // TreasureTableBuilder
    // **************************************************
    public class TreasureTableBuilder : EditorBuilder
    {
        public TreasureTableBuilder()
            : base(EditorSystemType.TreasureTable, "Treasure Table", "Treasure Tables")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new TreasureTableControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "treasure_table_def", "system_name", "class_id = " + aClassId, "treasure_table_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("treasure_table_item_map", "treasure_table_def_id = " + aId);
            Database.deleteData("treasure_table_item_map", "treasure_table_def_id", aId);
            //Database.deleteData("treasure_table_def", "treasure_table_def_id = " + aId);
            Database.deleteData("treasure_table_def", "treasure_table_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("treasure_table_def", "treasure_table_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("treasure_table_def", aId, "system_name").ToString();
            return Database.getData("treasure_table_def", "treasure_table_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("treasure_table_def", aId, "system_name", "treasure_table_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("treasure_table_def");
        }

    }
}