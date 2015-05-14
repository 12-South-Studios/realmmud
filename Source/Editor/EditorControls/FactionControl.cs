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
    // FactionControl
    // **************************************************
    public partial class FactionControl : BaseEditorControl
    {
        public FactionControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public FactionControl(int aClassId)
            : base(EditorSystemType.Faction, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "faction_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "faction_def", "display_name");
            initOppositionGrid();
        }

        private void initOppositionGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Faction;
                col.Name = "target_faction_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Faction";
                col.CellTemplate = cell;
                gridOpposition.Columns.Add(col);
            }
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_faction_relationship_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Relationship";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_faction_relationship", "ref_faction_relationship_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridOpposition.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("faction_def", "faction_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Faction [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Faction [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Faction loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadOppositionGrid(aId);
        }

        private void loadOppositionGrid(int aId)
        {
            gridOpposition.Rows.Clear();

            DataTable dt = Database.getData("faction_opposition_map", "faction_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridOpposition.Rows.Add();
                DataGridViewRow gridRow = gridOpposition.Rows[gridIndex];

                DataGridViewLinkCell cellFaction = gridRow.Cells["target_faction_def_id"] as DataGridViewLinkCell;
                cellFaction.Value = EditorFactory.getBrowseInfo(EditorSystemType.Faction, rowView, "target_faction_def_id");

                DataGridViewComboBoxCell cellType = gridRow.Cells["ref_faction_relationship_id"] as DataGridViewComboBoxCell;
                ComboUtils.fillComboCellWithRefTable(cellType, "ref_faction_relationship", "ref_faction_relationship_id", "name", Database.getNullableId(rowView, "ref_faction_relationship_id"));

                gridRow.Tag = (int)rowView["faction_opposition_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("faction_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Faction Def");
                }
                else
                    Database.updateData("faction_def", "faction_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("faction_def", "faction_def_id", Id, "display_name", txtDisplayName.Text);

                saveOppositionGrid(Id);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving faction [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveOppositionGrid(int aDefId)
        {
            Database.deleteData("faction_opposition_map", "faction_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridOpposition.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo factionDefIdBrowseInfo = gridRow.Cells["target_faction_def_id"].Value as EditorBrowseInfo;
                    if (factionDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("faction_opposition_map", "faction_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in faction_opposition_map");

                    Database.updateData("faction_opposition_map", "faction_opposition_map_id", rowId, "target_faction_def_id", factionDefIdBrowseInfo.Id);
                    
                    if (gridRow.Cells["ref_faction_relationship_id"].Value == DBNull.Value)
                        Database.updateData("faction_opposition_map", "faction_opposition_map_id", rowId, "ref_faction_relationship_id", Globals.FACTION_RELATIONSHIP_Neutral);
                    else
                        Database.updateData("faction_opposition_map", "faction_opposition_map_id", rowId, "ref_faction_relationship_id", (int)gridRow.Cells["ref_faction_relationship_id"].Value);
                }
            }
            gridOpposition.flushDeletedRows();
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

            // Validate display name
            if (txtDisplayName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Display Name");
                    txtDisplayName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtDisplayName.BackColor = Color.Empty;
            }

            return valid;
        }
    }


    // **************************************************
    // FactionBuilder
    // **************************************************
    public class FactionBuilder : EditorBuilder
    {
        public FactionBuilder()
            : base(EditorSystemType.Faction, "Faction", "Factions")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new FactionControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "faction_def", "system_name", "class_id = " + aClassId, "faction_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("faction_opposition_map", "faction_def_id = " + aId);
            Database.deleteData("faction_opposition_map", "faction_def_id", aId);
            //Database.deleteData("faction_def", "faction_def_id = " + aId);
            Database.deleteData("faction_def", "faction_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("faction_def", "faction_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("faction_def", aId, "system_name").ToString();
            return Database.getData("faction_def", "faction_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("faction_def", aId, "system_name", "faction_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("faction_def");
        }

    }
}
