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
    public partial class ZoneControl : BaseEditorControl
    {
        public ZoneControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public ZoneControl(int aClassId)
            : base(EditorSystemType.Zone, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "zone_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "zone_def", "display_name");
            TextBoxUtils.initTextBox(txtDescription, "zone_def", "display_description");
            TextBoxUtils.initTextBox(txtAuthor, "zone_def", "author");

            initSpacesGrid();
            initAccessLevelsGrid();
            initSpawnsGrid();
        }

        private void initSpacesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Space;
                col.Name = "space_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Space";
                col.CellTemplate = cell;
                gridSpaces.Columns.Add(col);
            }
        }

        private void initAccessLevelsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.AccessLevel;
                col.Name = "access_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Access Level";
                col.CellTemplate = cell;
                gridAccessLevels.Columns.Add(col);
            }
        }

        private void initSpawnsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Spawn;
                col.Name = "spawn_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Spawn";
                col.CellTemplate = cell;
                gridSpawns.Columns.Add(col);
            }
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("zone_def", "zone_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Zone [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Zone [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Zone loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDescription.Text = dataRow["display_description"].ToString();
            txtAuthor.Text = dataRow["author"].ToString();
            numReset.Value = (int)dataRow["reset_rate"];

            int flags = (int)dataRow["flags"];
            chkSystemZone.Checked = ((flags & Globals.ZONE_FLAG_System) != 0) ? true : false;

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadSpacesGrid(aId);
            loadAccessLevelsGrid(aId);
            loadSpawnsGrid(aId);
        }

        private void loadSpacesGrid(int aDefId)
        {
            gridSpaces.Rows.Clear();

            DataTable dt = Database.getData("zone_space_map", "zone_def_id", aDefId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridSpaces.Rows.Add();
                DataGridViewRow gridRow = gridSpaces.Rows[gridIndex];

                DataGridViewLinkCell cellSpace = gridRow.Cells["space_def_id"] as DataGridViewLinkCell;
                cellSpace.Value = EditorFactory.getBrowseInfo(EditorSystemType.Space, rowView, "space_def_id");

                gridRow.Tag = (int)rowView["zone_space_map_id"];
            }
            dt.Dispose();
        }

        private void loadAccessLevelsGrid(int aDefId)
        {
            gridAccessLevels.Rows.Clear();

            DataTable dt = Database.getData("zone_access_map", "zone_def_id", aDefId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridAccessLevels.Rows.Add();
                DataGridViewRow gridRow = gridAccessLevels.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["access_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.AccessLevel, rowView, "access_def_id");

                gridRow.Tag = (int)rowView["zone_access_map_id"];
            }
            dt.Dispose();
        }

        private void loadSpawnsGrid(int aDefId)
        {
            gridSpawns.Rows.Clear();

            DataTable dt = Database.getData("zone_spawn_map", "zone_def_id", aDefId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridSpawns.Rows.Add();
                DataGridViewRow gridRow = gridSpawns.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["spawn_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Spawn, rowView, "spawn_def_id");

                gridRow.Tag = (int)rowView["zone_spawn_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridSpaces.EndEdit();
            gridAccessLevels.EndEdit();

            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("zone_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Zone Def");
                }
                else
                    Database.updateData("zone_def", "zone_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("zone_def", "zone_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("zone_def", "zone_def_id", Id, "display_description", txtDescription.Text);
                Database.updateData("zone_def", "zone_def_id", Id, "author", txtAuthor.Text);
                Database.updateData("zone_def", "zone_def_id", Id, "reset_rate", (int)numReset.Value);

                int flags =
                    (chkSystemZone.Checked ? Globals.ZONE_FLAG_System : 0);
                Database.updateData("zone_def", "zone_def_id", Id, "flags", flags);

                saveSpacesGrid(Id);
                saveAccessLevelsGrid(Id);
                saveSpawnsGrid(Id);

                Database.commitTransaction();

                initContent(Id);

                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving zone [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveSpacesGrid(int aDefId)
        {
            Database.deleteData("zone_space_map", "zone_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridSpaces.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo spaceDefIdBrowseInfo = gridRow.Cells["space_def_id"].Value as EditorBrowseInfo;
                    if (spaceDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("zone_space_map", "zone_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in zone_space_map");

                    Database.updateData("zone_space_map", "zone_space_map_id", rowId, "space_def_id", spaceDefIdBrowseInfo.Id);
                }
            }
            gridSpaces.flushDeletedRows();
        }

        private void saveAccessLevelsGrid(int aDefId)
        {
            Database.deleteData("zone_access_map", "zone_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAccessLevels.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo accessDefIdBrowseInfo = gridRow.Cells["access_def_id"].Value as EditorBrowseInfo;
                    if (accessDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("zone_access_map", "zone_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in zone_access_map");

                    Database.updateData("zone_access_map", "zone_access_map_id", rowId, "access_def_id", accessDefIdBrowseInfo.Id);
                }
            }

            gridAccessLevels.flushDeletedRows();
        }

        private void saveSpawnsGrid(int aDefId)
        {
            Database.deleteData("zone_spawn_map", "zone_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridSpawns.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo spawnDefIdBrowseInfo = gridRow.Cells["spawn_def_id"].Value as EditorBrowseInfo;
                    if (spawnDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("zone_spawn_map", "zone_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in zone_spawn_map");

                    Database.updateData("zone_spawn_map", "zone_spawn_map_id", rowId, "spawn_def_id", spawnDefIdBrowseInfo.Id);
                }
            }
            gridSpawns.flushDeletedRows();
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

            if (txtAuthor.Text.Length <= 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Author");
                    txtAuthor.BackColor = errorColor;
                }
                return false;
            }
            else
                txtAuthor.BackColor = Color.Empty;

            return true;
        }
    }


    // **************************************************
    // ZoneBuilder
    // **************************************************
    public class ZoneBuilder : EditorBuilder
    {
        public ZoneBuilder()
            : base(EditorSystemType.Zone, "Zone", "Zones")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }
        public override BaseEditorControl create(int aClassId)
        {
            return new ZoneControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "zone_def", "system_name", "class_id = " + aClassId, "zone_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("zone_spawn_map", "zone_def_id = " + aId);
            Database.deleteData("zone_spawn_map", "zone_def_id", aId);
            //Database.deleteData("zone_access_map", "zone_def_id = " + aId);
            Database.deleteData("zone_access_map", "zone_def_id", aId);
            //Database.deleteData("zone_space_map", "zone_def_id = " + aId);
            Database.deleteData("zone_space_map", "zone_def_id", aId);
            //Database.deleteData("zone_def", "zone_def_id = " + aId);
            Database.deleteData("zone_def", "zone_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("zone_def", "zone_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("zone_def", aId, "system_name").ToString();
            return Database.getData("zone_def", "zone_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("zone_def", aId, "system_name", "zone_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("zone_def");
        }

    }
}
