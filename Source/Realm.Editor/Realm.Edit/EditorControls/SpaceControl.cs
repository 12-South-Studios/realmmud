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
    public partial class SpaceControl : BaseEditorControl
    {
        public SpaceControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public SpaceControl(int aClassId)
            : base(EditorSystemType.Space, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "space_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "space_def", "display_name");
            TextBoxUtils.initTextBox(txtDescription, "space_def", "display_description");

            linkAccessLevel.SystemType = EditorSystemType.AccessLevel;

            initExitGrid();
            initNpcGrid();
            initItemGrid();
            initEffectsGrid();
        }

        private void initExitGrid()
        {
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_direction_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Direction";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_direction", "ref_direction_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridExits.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Space;
                col.Name = "destination_space_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Space";
                col.CellTemplate = cell;
                gridExits.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_hidden";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 50;
                col.HeaderText = "Is Secret";
                col.CellTemplate = cell;
                gridExits.CurrentCellDirtyStateChanged += new EventHandler(gridExits_CurrentCellDirtyStateChanged);
                gridExits.Columns.Add(col);
            }
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_difficulty_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 60;
                col.HeaderText = "Difficulty";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_difficulty", "ref_difficulty_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridExits.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_oneway";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 50;
                col.HeaderText = "Is One-Way";
                col.CellTemplate = cell;
                gridExits.CurrentCellDirtyStateChanged += new EventHandler(gridExits_CurrentCellDirtyStateChanged);
                gridExits.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_transparent";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 50;
                col.HeaderText = "Is Transparent";
                col.CellTemplate = cell;
                gridExits.CurrentCellDirtyStateChanged += new EventHandler(gridExits_CurrentCellDirtyStateChanged);
                gridExits.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Barrier;
                col.Name = "barrier_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Barrier";
                col.CellTemplate = cell;
                gridExits.Columns.Add(col);
            }
        }

        void gridExits_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridExits.CurrentCell == null)
                return;

            if (gridExits.CurrentCell is DataGridViewCheckBoxCell)
            {
                // Is it checked true?
                bool isChecked = (bool)gridExits.CurrentCell.Value;
                if (isChecked)
                {
                    // If so, enable the difficulty cell
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)gridExits["ref_difficulty_id", gridExits.CurrentRow.Index];
                    cell.ReadOnly = false;
                }
                else
                {
                    // If not, disable the difficulty cell
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)gridExits["ref_difficulty_id", gridExits.CurrentRow.Index];
                    cell.Value = 6; // None
                    cell.ReadOnly = true;
                }
            }
        }

        private void initNpcGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Npc;
                col.Name = "npc_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Npcs";
                col.CellTemplate = cell;
                gridNpcs.Columns.Add(col);
            }
        }

        private void initEffectsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.SpaceEffect;
                col.Name = "space_effect_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Space Effects";
                col.CellTemplate = cell;
                gridEffects.Columns.Add(col);
            }
        }

        private void initItemGrid()
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

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboTerrain, "terrain_def", "system_name", "terrain_def_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("space_def", "space_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Space [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Space [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Space loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDescription.Text = dataRow["display_description"].ToString();

            ComboUtils.fillCombo(cboTerrain, "terrain_def", "system_name", "terrain_def_id", (int)dataRow["terrain_def_id"]);
            EditorFactory.setupLink(linkAccessLevel, EditorSystemType.AccessLevel, Database.getNullableId(dataRow, "access_def_id"));

            int flags = (int)dataRow["flags"];
            chkNoMob.Checked = ((flags & Globals.SPACE_FLAG_NoMob) != 0) ? true : false;
            chkNoRecall.Checked = ((flags & Globals.SPACE_FLAG_NoRecall) != 0) ? true : false;
            chkNoSummon.Checked = ((flags & Globals.SPACE_FLAG_NoSummon) != 0) ? true : false;
            chkNoCombat.Checked = ((flags & Globals.SPACE_FLAG_Safe) != 0) ? true : false;
            chkNoMagic.Checked = ((flags & Globals.SPACE_FLAG_NoMagic) != 0) ? true : false;
            chkIsShrine.Checked = ((flags & Globals.SPACE_FLAG_Shrine) != 0) ? true : false;

            dt.Dispose();
            ControlName = txtSystemName.Text;
            loadExitGrid(aId);
            loadNpcGrid(aId);
            loadItemGrid(aId);
            loadEffectsGrid(aId);
        }

        private void loadExitGrid(int aId)
        {
            gridExits.Rows.Clear();

            DataTable dt = Database.getData("space_exit_map", "space_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridExits.Rows.Add();
                DataGridViewRow gridRow = gridExits.Rows[gridIndex];

                DataGridViewComboBoxCell cellDirection = gridRow.Cells["ref_direction_id"] as DataGridViewComboBoxCell;
                ComboUtils.fillComboCellWithRefTable(cellDirection, "ref_direction", "ref_direction_id", "name", (int)rowView["ref_direction_id"]);

                DataGridViewLinkCell cellSpace = gridRow.Cells["destination_space_def_id"] as DataGridViewLinkCell;
                cellSpace.Value = EditorFactory.getBrowseInfo(EditorSystemType.Space, rowView, "destination_space_def_id");

                int flags = (int)rowView["flags"];

                DataGridViewCheckBoxCell cellHidden = gridRow.Cells["is_hidden"] as DataGridViewCheckBoxCell;
                cellHidden.Value = ((flags & Globals.EXIT_FLAG_Hidden) != 0) ? true : false;

                DataGridViewCheckBoxCell cellOneWay = gridRow.Cells["is_oneway"] as DataGridViewCheckBoxCell;
                cellOneWay.Value = ((flags & Globals.EXIT_FLAG_OneWay) != 0) ? true : false;

                DataGridViewCheckBoxCell cellTransparent = gridRow.Cells["is_transparent"] as DataGridViewCheckBoxCell;
                cellTransparent.Value = ((flags & Globals.EXIT_FLAG_Transparent) != 0) ? true : false;

                DataGridViewComboBoxCell cellDifficulty = gridRow.Cells["ref_difficulty_id"] as DataGridViewComboBoxCell;
                if (Database.getNullableId(rowView, "ref_difficulty_id") == 0)
                    ComboUtils.fillComboCellWithRefTable(cellDifficulty, "ref_difficulty", "ref_difficulty_id", "name", 6);
                //cellDifficulty.Value = 6;   // None
                else
                    ComboUtils.fillComboCellWithRefTable(cellDifficulty, "ref_difficulty", "ref_difficulty_id", "name", Database.getNullableId(rowView, "ref_difficulty_id"));

                DataGridViewLinkCell cellBarrier = gridRow.Cells["barrier_def_id"] as DataGridViewLinkCell;
                cellBarrier.Value = EditorFactory.getBrowseInfo(EditorSystemType.Barrier, rowView, "barrier_def_id");

                gridRow.Tag = (int)rowView["space_exit_map_id"];
            }
            dt.Dispose();
        }

        private void loadNpcGrid(int aId)
        {
            gridNpcs.Rows.Clear();

            DataTable dt = Database.getData("space_npc_map", "space_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridNpcs.Rows.Add();
                DataGridViewRow gridRow = gridNpcs.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["npc_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Npc, rowView, "npc_def_id");

                gridRow.Tag = (int)rowView["space_npc_map_id"];
            }
            dt.Dispose();
        }

        private void loadEffectsGrid(int aId)
        {
            gridEffects.Rows.Clear();

            DataTable dt = Database.getData("space_effect_map", "space_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridEffects.Rows.Add();
                DataGridViewRow gridRow = gridEffects.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["space_effect_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.SpaceEffect, rowView, "space_effect_def_id");

                gridRow.Tag = (int)rowView["space_effect_map_id"];
            }
            dt.Dispose();
        }

        private void loadItemGrid(int aId)
        {
            gridItems.Rows.Clear();

            DataTable dt = Database.getData("space_item_map", "space_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItems.Rows.Add();
                DataGridViewRow gridRow = gridItems.Rows[gridIndex];

                DataGridViewLinkCell cellItem = gridRow.Cells["item_def_id"] as DataGridViewLinkCell;
                cellItem.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "item_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridRow.Cells["quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellQty.Value = (int)rowView["quantity"];

                gridRow.Tag = (int)rowView["space_item_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridExits.EndEdit();
            gridNpcs.EndEdit();
            gridItems.EndEdit();
            gridEffects.EndEdit();

            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("space_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Space Def");
                }
                else
                    Database.updateData("space_def", "space_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("space_def", "space_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("space_def", "space_def_id", Id, "display_description", txtDescription.Text);
                Database.updateData("space_def", "space_def_id", Id, "terrain_def_id", (cboTerrain.SelectedItem as TagInfo).Id);
                Database.updateData("space_def", "space_def_id", Id, "access_def_id", getContentLinkId(linkAccessLevel));
                
                int flags =
                        (chkNoMob.Checked ? Globals.SPACE_FLAG_NoMob : 0) |
                        (chkNoRecall.Checked ? Globals.SPACE_FLAG_NoRecall : 0) |
                        (chkNoSummon.Checked ? Globals.SPACE_FLAG_NoSummon : 0) |
                        (chkNoCombat.Checked ? Globals.SPACE_FLAG_Safe : 0) |
                        (chkNoMagic.Checked ? Globals.SPACE_FLAG_NoMagic : 0) |
                        (chkIsShrine.Checked ? Globals.SPACE_FLAG_Shrine : 0);
                Database.updateData("space_def", "space_def_id", Id, "flags", flags);

                saveExitGrid(Id);
                saveNpcGrid(Id);
                saveItemGrid(Id);
                saveEffectsGrid(Id);

                Database.commitTransaction();

                initContent(Id);

                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving space [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveExitGrid(int aDefId)
        {
            Database.deleteData("space_exit_map", "space_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridExits.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo spaceDefIdBrowseInfo = gridRow.Cells["destination_space_def_id"].Value as EditorBrowseInfo;
                    if (spaceDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("space_exit_map", "space_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in space_exit_map");

                    Database.updateData("space_exit_map", "space_exit_map_id", rowId, "ref_direction_id", (gridRow.Cells["ref_direction_id"].Value as TagInfo).Id);
                    Database.updateData("space_exit_map", "space_exit_map_id", rowId, "destination_space_def_id", spaceDefIdBrowseInfo.Id);
                    
                    int flags =
                        (Convert.ToBoolean(gridRow.Cells["is_hidden"].Value) ? Globals.EXIT_FLAG_Hidden : 0) |
                        (Convert.ToBoolean(gridRow.Cells["is_oneway"].Value) ? Globals.EXIT_FLAG_OneWay : 0) |
                        (Convert.ToBoolean(gridRow.Cells["is_transparent"].Value) ? Globals.EXIT_FLAG_Transparent : 0);
                    Database.updateData("space_exit_map", "space_exit_map_id", rowId, "flags", flags);

                    if (gridRow.Cells["ref_difficulty_id"].Value != null)
                        Database.updateData("space_exit_map", "space_exit_map_id", rowId, "ref_difficulty_id", (gridRow.Cells["ref_difficulty_id"].Value as TagInfo).Id);

                    EditorBrowseInfo barrierDefIdBrowseInfo = gridRow.Cells["barrier_def_id"].Value as EditorBrowseInfo;
                    if (barrierDefIdBrowseInfo != null)
                        Database.updateData("space_exit_map", "space_exit_map_id", rowId, "barrier_def_id", barrierDefIdBrowseInfo.Id);
                }
            }
            gridExits.flushDeletedRows();
        }

        private void saveNpcGrid(int aDefId)
        {
            Database.deleteData("space_npc_map", "space_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridNpcs.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo npcDefIdBrowseInfo = gridRow.Cells["npc_def_id"].Value as EditorBrowseInfo;
                    if (npcDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("space_npc_map", "space_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in space_npc_map");

                    Database.updateData("space_npc_map", "space_npc_map_id", rowId, "npc_def_id", npcDefIdBrowseInfo.Id);
                }
            }
            gridNpcs.flushDeletedRows();
        }

        private void saveEffectsGrid(int aDefId)
        {
            Database.deleteData("space_effect_map", "space_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridEffects.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo effectDefIdBrowseInfo = gridRow.Cells["space_effect_def_id"].Value as EditorBrowseInfo;
                    if (effectDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("space_effect_map", "space_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in space_effect_map");

                    Database.updateData("space_effect_map", "space_effect_map_id", rowId, "space_effect_def_id", effectDefIdBrowseInfo.Id);
                }
            }
            gridEffects.flushDeletedRows();
        }

        private void saveItemGrid(int aDefId)
        {
            Database.deleteData("space_item_map", "space_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridItems.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo itemDefIdBrowseInfo = gridRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                    if (itemDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("space_item_map", "space_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in space_item_map");

                    Database.updateData("space_item_map", "space_item_map_id", rowId, "item_def_id", itemDefIdBrowseInfo.Id);
                    if (gridRow.Cells["quantity"].Value == null)
                        Database.updateData("space_item_map", "space_item_map_id", rowId, "quantity", 1);
                    else
                        Database.updateData("space_item_map", "space_item_map_id", rowId, "quantity", (int)gridRow.Cells["quantity"].Value);
                }
            }
            gridItems.flushDeletedRows();
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

            if (txtDisplayName.Text.Length <= 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Display Name");
                    txtDisplayName.BackColor = errorColor;
                }
                return false;
            }
            else
                txtDisplayName.BackColor = Color.Empty;

            return true;
        }

        private void gridItems_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["quantity"].Value = 1;
        }
    }


    // **************************************************
    // SpaceBuilder
    // **************************************************
    public class SpaceBuilder : EditorBuilder
    {
        public SpaceBuilder()
            : base(EditorSystemType.Space, "Space", "Spaces")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }
        public override BaseEditorControl create(int aClassId)
        {
            return new SpaceControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "space_def", "system_name", "class_id = " + aClassId, "space_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("space_npc_map", "space_def_id = " + aId);
            Database.deleteData("space_npc_map", "space_def_id", aId);
            //Database.deleteData("space_exit_map", "space_def_id = " + aId);
            Database.deleteData("space_exit_map", "space_def_id", aId);
            //Database.deleteData("space_item_map", "space_def_id = " + aId);
            Database.deleteData("space_item_map", "space_def_id", aId);
            //Database.deleteData("space_effect_map", "space_def_id = " + aId);
            Database.deleteData("space_effect_map", "space_def_id", aId);
            //Database.deleteData("space_def", "space_def_id = " + aId);
            Database.deleteData("space_def", "space_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("space_def", "space_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("space_def", aId, "system_name").ToString();
            return Database.getData("space_def", "space_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("space_def", aId, "system_name", "space_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("space_def");
        }

    }
}
