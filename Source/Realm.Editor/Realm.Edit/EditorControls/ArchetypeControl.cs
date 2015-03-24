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
    // ArchetypeControl
    // **************************************************
    public partial class ArchetypeControl : BaseEditorControl
    {
        public ArchetypeControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public ArchetypeControl(int aClassId)
            : base(EditorSystemType.Archetype, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "archetype_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "archetype_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "archetype_def", "display_description");

            initAbilitiesGrid();
            initStatsGrid();
        }

        private void initAbilitiesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Ability;
                col.Name = "ability_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 150;
                col.HeaderText = "Ability";
                col.CellTemplate = cell;
                gridAbilities.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_exempt";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.HeaderText = "Is Exempt";
                col.CellTemplate = cell;
                gridAbilities.Columns.Add(col);
            }
        }

        private void initStatsGrid()
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
                gridStatistics.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "value";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.Width = 50;
                col.HeaderText = "Starting Value";
                col.CellTemplate = cell;
                col.Maximum = 99999;
                col.Minimum = -99999;
                gridStatistics.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_exempt";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.HeaderText = "Is Exempt";
                col.CellTemplate = cell;
                gridStatistics.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("archetype_def", "archetype_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Archetype [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Archetype [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Archetype loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadAbilitiesGrid(aId);
            loadStatsGrid(aId);
        }

        private void loadAbilitiesGrid(int aDefId)
        {
            gridAbilities.Rows.Clear();

            DataTable dt = Database.getData("archetype_ability_map", "archetype_def_id", aDefId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridAbilities.Rows.Add();
                DataGridViewRow gridRow = gridAbilities.Rows[gridIndex];

                DataGridViewLinkCell cellAbility = gridRow.Cells["ability_def_id"] as DataGridViewLinkCell;
                cellAbility.Value = EditorFactory.getBrowseInfo(EditorSystemType.Ability, rowView, "ability_def_id");

                DataGridViewCheckBoxCell cellDefault = gridRow.Cells["is_exempt"] as DataGridViewCheckBoxCell;
                cellDefault.Value = (bool)rowView["is_exempt"];

                gridRow.Tag = (int)rowView["archetype_ability_map_id"];
            }
            dt.Dispose();
        }

        private void loadStatsGrid(int aDefId)
        {
            gridStatistics.Rows.Clear();

            DataTable dt = Database.getData("archetype_statistic_map", "archetype_def_id", aDefId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridStatistics.Rows.Add();
                DataGridViewRow gridRow = gridStatistics.Rows[gridIndex];

                DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellValue = gridRow.Cells["value"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellValue.Value = (int)rowView["value"];

                DataGridViewCheckBoxCell cellDefault = gridRow.Cells["is_exempt"] as DataGridViewCheckBoxCell;
                cellDefault.Value = (bool)rowView["is_exempt"];

                gridRow.Tag = (int)rowView["archetype_statistic_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridAbilities.EndEdit();
            gridStatistics.EndEdit();

            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("archetype_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Archetype Def");
                }
                else
                    Database.updateData("archetype_def", "archetype_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("archetype_def", "archetype_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("archetype_def", "archetype_def_id", Id, "display_description", txtDisplayDescription.Text);

                saveAbilitiesGrid(Id);
                saveStatsGrid(Id);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving archetype [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveAbilitiesGrid(int aDefId)
        {
            Database.deleteData("archetype_ability_map", "archetype_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAbilities.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo abilityDefIdBrowseInfo = gridRow.Cells["ability_def_id"].Value as EditorBrowseInfo;
                    if (abilityDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("archetype_ability_map", "archetype_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in archetype_ability_map");

                    Database.updateData("archetype_ability_map", "archetype_ability_map_id", rowId, "ability_def_id", abilityDefIdBrowseInfo.Id);
                    if (gridRow.Cells["is_exempt"].Value != null)
                        Database.updateData("archetype_ability_map", "archetype_ability_map_id", rowId, "is_exempt", (int)gridRow.Cells["is_exempt"].Value);
                }
            }
            gridAbilities.flushDeletedRows();
        }

        private void saveStatsGrid(int aDefId)
        {
            Database.deleteData("archetype_statistic_map", "archetype_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridStatistics.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("archetype_statistic_map", "archetype_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in archetype_statistic_map");

                    Database.updateData("archetype_statistic_map", "archetype_statistic_map_id", rowId, "statistic_Def_id", statDefIdBrowseInfo.Id);
                    Database.updateData("archetype_statistic_map", "archetype_statistic_map_id", rowId, "value", (int)gridRow.Cells["value"].Value);
                    if (gridRow.Cells["is_exempt"].Value != null)
                        Database.updateData("archetype_statistic_map", "archetype_statistic_map_id", rowId, "is_exempt", (int)gridRow.Cells["is_exempt"].Value);
                }
            }
            gridStatistics.flushDeletedRows();
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

            // Validate Description
            if (txtDisplayDescription.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Description");
                    txtDisplayDescription.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtDisplayDescription.BackColor = Color.Empty;
            }
            return valid;
        }
    }


    // **************************************************
    // ArchetypeBuilder
    // **************************************************
    public class ArchetypeBuilder : EditorBuilder
    {
        public ArchetypeBuilder()
            : base(EditorSystemType.Archetype, "Archetype", "Archetypes")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new ArchetypeControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "archetype_def", "system_name", "class_id = " + aClassId, "archetype_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("archetype_statistic_map", "archetype_def_id = " + aId);
            Database.deleteData("archetype_statistic_map", "archetype_def_id", aId);
            //Database.deleteData("archetype_ability_map", "archetype_def_id = " + aId);
            Database.deleteData("archetype_ability_map", "archetype_def_id", aId);
            //Database.deleteData("archetype_def", "archetype_def_id = " + aId);
            Database.deleteData("archetype_def", "archetype_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("archetype_def", "archetype_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("archetype_def", aId, "system_name").ToString();
            return Database.getData("archetype_def", "archetype_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("archetype_def", aId, "system_name", "archetype_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("archetype_def");
        }

    }
}