using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealmEdit
{
    public partial class SpawnControl : BaseEditorControl
    {
        public SpawnControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public SpawnControl(int aClassId)
            : base(EditorSystemType.Spawn, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "spawn_def", "system_name");
            ComboUtils.fillCombo(cboSpawnType, "ref_spawn_type", "name", "ref_spawn_type_id", 0);

            initNpcsGrid();
            initItemsGrid();
            initSpacesGrid();
            initAccessGrid();
        }

        private void initNpcsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                col.Name = "npc_def_id";
                cell.SystemType = EditorSystemType.Npc;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 75;
                col.HeaderText = "Npcs";
                col.CellTemplate = cell;
                gridNpcs.Columns.Add(col);
            }
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_behavior_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.HeaderText = "Behavior";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_behavior", "ref_behavior_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridNpcs.Columns.Add(col);
            }
        }

        private void initItemsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                col.Name = "item_def_id";
                cell.SystemType = EditorSystemType.Item;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Items";
                col.CellTemplate = cell;
                gridItems.Columns.Add(col);
            }
        }

        private void initAccessGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                col.Name = "access_def_id";
                cell.SystemType = EditorSystemType.AccessLevel;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Access Levels";
                col.CellTemplate = cell;
                gridAccess.Columns.Add(col);
            }
        }

        private void initSpacesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                col.Name = "space_def_id";
                cell.SystemType = EditorSystemType.Space;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Spaces";
                col.CellTemplate = cell;
                gridSpaces.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboSpawnType, "ref_spawn_type", "name", "ref_spawn_type_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("spawn_def", "spawn_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Spawn [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Spawn [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Spawn loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            numMinQty.Value = (int)dataRow["min_quantity"];
            numMaxQty.Value = (int)dataRow["max_quantity"];
            numPctChance.Value = (int)dataRow["chance"];
            numRespawnPeriod.Value = (int)dataRow["respawn_period"];
            
            ComboUtils.fillCombo(cboSpawnType, "ref_spawn_type", "name", "ref_spawn_type_id", (int)dataRow["ref_spawn_type_id"]);

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadNpcGrid(aId);
            loadItemGrid(aId);
            loadSpaceGrid(aId);
            loadAccessGrid(aId);
        }

        private void loadNpcGrid(int aId)
        {
            gridNpcs.Rows.Clear();

            DataTable dt = Database.getData("spawn_npc_map", "spawn_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridNpcs.Rows.Add();
                DataGridViewRow gridRow = gridNpcs.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["npc_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Npc, rowView, "npc_def_id");

                DataGridViewComboBoxCell cellBehavior = gridRow.Cells["ref_behavior_id"] as DataGridViewComboBoxCell;
                if (Database.getNullableId(rowView, "ref_behavior_id") == 0)
                    ComboUtils.fillComboCellWithRefTable(cellBehavior, "ref_behavior", "ref_behavior_id", "name", 1);
                //cellBehavior.Value = 1;   // Aggressive
                else
                    ComboUtils.fillComboCellWithRefTable(cellBehavior, "ref_behavior", "ref_behavior_id", "name", Database.getNullableId(rowView, "ref_behavior_id"));

                gridRow.Tag = (int)rowView["spawn_npc_map_id"];
            }
            dt.Dispose();
        }

        private void loadItemGrid(int aId)
        {
            gridItems.Rows.Clear();

            DataTable dt = Database.getData("spawn_item_map", "spawn_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItems.Rows.Add();
                DataGridViewRow gridRow = gridItems.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["item_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "item_def_id");

                gridRow.Tag = (int)rowView["spawn_item_map_id"];
            }
            dt.Dispose();
        }

        private void loadSpaceGrid(int aId)
        {
            gridSpaces.Rows.Clear();

            DataTable dt = Database.getData("spawn_space_map", "spawn_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridSpaces.Rows.Add();
                DataGridViewRow gridRow = gridSpaces.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["space_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Space, rowView, "space_def_id");

                gridRow.Tag = (int)rowView["spawn_space_map_id"];
            }
            dt.Dispose();
        }

        private void loadAccessGrid(int aId)
        {
            gridAccess.Rows.Clear();

            DataTable dt = Database.getData("spawn_access_map", "spawn_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridAccess.Rows.Add();
                DataGridViewRow gridRow = gridAccess.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["access_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.AccessLevel, rowView, "access_def_id");

                gridRow.Tag = (int)rowView["spawn_access_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridNpcs.EndEdit();
            gridItems.EndEdit();
            gridSpaces.EndEdit();
            gridAccess.EndEdit();

            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("spawn_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Spawn Def");
                }
                else
                    Database.updateData("spawn_def", "spawn_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("spawn_def", "spawn_def_id", Id, "min_quantity", (int)numMinQty.Value);
                Database.updateData("spawn_def", "spawn_def_id", Id, "max_quantity", (int)numMaxQty.Value);
                Database.updateData("spawn_def", "spawn_def_id", Id, "chance", (int)numPctChance.Value);
                Database.updateData("spawn_def", "spawn_def_id", Id, "respawn_period", (int)numRespawnPeriod.Value);
                Database.updateData("spawn_def", "spawn_def_id", Id, "ref_spawn_type_id", (cboSpawnType.SelectedItem as TagInfo).Id);

                saveNpcGrid(Id);
                saveItemGrid(Id);
                saveSpaceGrid(Id);
                saveAccessGrid(Id);

                Database.commitTransaction();

                initContent(Id);

                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving Spawn [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveNpcGrid(int aDefId)
        {
            Database.deleteData("spawn_npc_map", "spawn_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridNpcs.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo defIdBrowseInfo = gridRow.Cells["npc_def_id"].Value as EditorBrowseInfo;
                    if (defIdBrowseInfo == null) continue;

                    int rowId = Database.createData("spawn_npc_map", "spawn_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in spawn_npc_map");

                    Database.updateData("spawn_npc_map", "spawn_npc_map_id", rowId, "npc_def_id", defIdBrowseInfo.Id);
                    if (gridRow.Cells["ref_behavior_id"].Value != null)
                        Database.updateData("spawn_npc_map", "spawn_npc_map_id", rowId, "ref_behavior_id", (int)gridRow.Cells["ref_behavior_id"].Value);
                }
            }
            gridNpcs.flushDeletedRows();
        }

        private void saveItemGrid(int aDefId)
        {
            Database.deleteData("spawn_item_map", "spawn_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridItems.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo defIdBrowseInfo = gridRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                    if (defIdBrowseInfo == null) continue;

                    int rowId = Database.createData("spawn_item_map", "spawn_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in spawn_item_map");

                    Database.updateData("spawn_item_map", "spawn_item_map_id", rowId, "item_def_id", defIdBrowseInfo.Id);
                }
            }
            gridItems.flushDeletedRows();
        }

        private void saveSpaceGrid(int aDefId)
        {
            Database.deleteData("spawn_space_map", "spawn_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridSpaces.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo defIdBrowseInfo = gridRow.Cells["space_def_id"].Value as EditorBrowseInfo;
                    if (defIdBrowseInfo == null) continue;

                    int rowId = Database.createData("spawn_space_map", "spawn_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in spawn_space_map");

                    Database.updateData("spawn_space_map", "spawn_space_map_id", rowId, "space_def_id", defIdBrowseInfo.Id);
                }
            }
            gridSpaces.flushDeletedRows();
        }

        private void saveAccessGrid(int aDefId)
        {
            Database.deleteData("spawn_access_map", "spawn_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAccess.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo defIdBrowseInfo = gridRow.Cells["access_def_id"].Value as EditorBrowseInfo;
                    if (defIdBrowseInfo == null) continue;

                    int rowId = Database.createData("spawn_access_map", "spawn_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in spawn_access_map");

                    Database.updateData("spawn_access_map", "spawn_access_map_id", rowId, "access_def_id", defIdBrowseInfo.Id);
                }
            }
            gridAccess.flushDeletedRows();
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            Color errorColor = Color.DarkRed;

            if (txtSystemName.Text.Length <= 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                return false;
            }
            else
                txtSystemName.BackColor = Color.Empty;

            return true;
        }

        private void cboSpawnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int spawnTypeId = (cboSpawnType.SelectedItem as TagInfo).Id;

            if (spawnTypeId == Globals.SPAWN_TYPE_Space)
            {
                gridSpaces.Visible = true;
                gridAccess.Visible = false;
            }
            else if (spawnTypeId == Globals.SPAWN_TYPE_Access)
            {
                gridAccess.Visible = true;
                gridSpaces.Visible = false;
            }
        }
    }


    // **************************************************
    // SpawnBuilder
    // **************************************************
    public class SpawnBuilder : EditorBuilder
    {
        public SpawnBuilder()
            : base(EditorSystemType.Spawn, "Spawn", "Spawns")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }
        public override BaseEditorControl create(int aClassId)
        {
            return new SpawnControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "spawn_def", "system_name", "class_id = " + aClassId, "spawn_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("spawn_npc_map", "spawn_def_id = " + aId);
            Database.deleteData("spawn_npc_map", "spawn_def_id", aId);
            //Database.deleteData("spawn_item_map", "spawn_def_id = " + aId);
            Database.deleteData("spawn_item_map", "spawn_def_id", aId);
            //Database.deleteData("spawn_space_map", "spawn_def_id = " + aId);
            Database.deleteData("spawn_space_map", "spawn_def_id", aId);
            //Database.deleteData("spawn_access_map", "spawn_def_id = " + aId);
            Database.deleteData("spawn_access_map", "spawn_def_id", aId);
            //Database.deleteData("spawn_def", "spawn_def_id = " + aId);
            Database.deleteData("spawn_def", "spawn_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("spawn_def", "spawn_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("spawn_def", aId, "system_name").ToString();
            return Database.getData("spawn_def", "spawn_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("spawn_def", aId, "system_name", "spawn_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("spawn_def");
        }

    }
}
