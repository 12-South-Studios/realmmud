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
    // StatisticControl
    // **************************************************
    public partial class StatisticControl : BaseEditorControl
    {
        private int mStatTagSetId = 0;

        public StatisticControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public StatisticControl(int aClassId)
            : base(EditorSystemType.Statistic, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "statistic_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "statistic_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "statistic_def", "display_description");

            TagUtils.fillCheckedList(lstStatTags, "StatisticGroupTags");
            ComboUtils.fillCombo(cboStatType, "ref_stat_type", "name", "ref_stat_type_id", 0);

            lblAmalgam.Visible = false;
            gridAmalgamStats.Visible = false;

            initAmalgamStatGrid();
            initRequiredStatGrid();
        }

        private void initAmalgamStatGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Statistic;
                col.Name = "statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Amalgam Stat";
                col.CellTemplate = cell;
                gridAmalgamStats.Columns.Add(col);
            }
        }

        private void initRequiredStatGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Statistic;
                col.Name = "prerequisite_statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Required Stat";
                col.CellTemplate = cell;
                gridRequiredStats.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "prerequisite_statistic_value";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Min Value";
                col.CellTemplate = cell;
                col.Maximum = 100;
                col.Minimum = 1;
                gridRequiredStats.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
            TagUtils.fillCheckedList(lstStatTags, "StatisticGroupTags");
            ComboUtils.fillCombo(cboStatType, "ref_stat_type", "name", "ref_stat_type_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("statistic_def", "statistic_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Statistic [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Statistic [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Statistic loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            ComboUtils.fillCombo(cboStatType, "ref_stat_type", "name", "ref_stat_type_id", (int)dataRow["ref_stat_type_id"]);
            numMinLevel.Value = Database.getNullableId(dataRow, "prerequisite_level");
            if (dataRow["is_skill"] != DBNull.Value)
                chkIsSkill.Checked = (bool)dataRow["is_skill"];

            // Fill the Unit tags
            mStatTagSetId = Database.getNullableId(dataRow, "stat_tag_set_def_id");
            if (mStatTagSetId > 0)
                TagUtils.fillCheckedList(lstStatTags, "StatisticGroupTags", mStatTagSetId);
            else
                TagUtils.fillCheckedList(lstStatTags, "StatisticGroupTags");

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadAmalgamStatGrid(aId);
            loadRequiredStatGrid(aId);
        }

        private void loadAmalgamStatGrid(int aId)
        {
            gridAmalgamStats.Rows.Clear();

            DataTable dt = Database.getData("statistic_amalgam_map", "statistic_def_id", aId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0)
            {
                lblAmalgam.Visible = true;
                gridAmalgamStats.Visible = true;
            }
            else
            {
                foreach (DataRow rowView in dt.Rows)
                {
                    int gridIndex = gridAmalgamStats.Rows.Add();
                    DataGridViewRow gridRow = gridAmalgamStats.Rows[gridIndex];

                    DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                    cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "amalgam_statistic_def_id");

                    gridRow.Tag = (int)rowView["statistic_amalgam_map_id"];
                }
            }
            dt.Dispose();
        }

        private void loadRequiredStatGrid(int aId)
        {
            gridRequiredStats.Rows.Clear();

            DataTable dt = Database.getData("statistic_prerequisite_map", "statistic_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridRequiredStats.Rows.Add();
                DataGridViewRow gridRow = gridRequiredStats.Rows[gridIndex];

                DataGridViewLinkCell cellStat = gridRow.Cells["prerequisite_statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "prerequisite_statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellValue = gridRow.Cells["prerequisite_value"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellValue.Value = Database.getNullableId(rowView, "prerequisite_value");

                gridRow.Tag = (int)rowView["statistic_prerequisite_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridAmalgamStats.EndEdit();

            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("statistic_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Statistic Def");
                }
                else
                    Database.updateData("statistic_def", "statistic_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("statistic_def", "statistic_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("statistic_def", "statistic_def_id", Id, "display_description", txtDisplayDescription.Text);
                Database.updateData("statistic_def", "statistic_def_id", Id, "ref_stat_type_id", (cboStatType.SelectedItem as TagInfo).Id);
                Database.updateData("statistic_def", "statistic_def_id", Id, "prerequisite_level", (int)numMinLevel.Value);
                Database.updateData("statistic_def", "statistic_def_id", Id, "is_skill", (chkIsSkill.Checked == true) ? 1 : 0);

                int newStatTagSetId = TagUtils.saveTagSet(lstStatTags, "Stat" + Id);
                Database.updateData("statistic_def", "statistic_def_id", Id, "stat_tag_set_def_id", newStatTagSetId);

                saveAmalgamStatGrid(Id);
                saveRequiredStatGrid(Id);

                // Delete the old tag sets if they existed
                if (mStatTagSetId > 0)
                    TagUtils.deleteTagSet(mStatTagSetId);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving statistic [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveAmalgamStatGrid(int aDefId)
        {
            Database.deleteData("statistic_amalgam_map", "statistic_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAmalgamStats.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statisticDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statisticDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("statistic_amalgam_map", "statistic_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in statistic_amalgam_map");

                    Database.updateData("statistic_amalgam_map", "statistic_amalgam_map_id", rowId, "amalgam_statistic_def_id", statisticDefIdBrowseInfo.Id);
                }
            }
            gridAmalgamStats.flushDeletedRows();
        }

        private void saveRequiredStatGrid(int aDefId)
        {
            Database.deleteData("statistic_prerequisite_map", "statistic_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridRequiredStats.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statisticDefIdBrowseInfo = gridRow.Cells["prerequisite_statistic_def_id"].Value as EditorBrowseInfo;
                    if (statisticDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("statistic_prerequisite_map", "statistic_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in statistic_prerequisite_map");

                    Database.updateData("statistic_prerequisite_map", "statistic_prerequisite_map_id", rowId, "prerequisite_statistic_def_id", statisticDefIdBrowseInfo.Id);
                    Database.updateData("statistic_prerequisite_map", "statistic_prerequisite_map_id", rowId, "prerequisite_level", (int)gridRow.Cells["prerequisite_level"].Value);
                }
            }
            gridRequiredStats.flushDeletedRows();
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
                    Program.MainForm.setStatusMessage("Missing Statistic Name");
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
                    Program.MainForm.setStatusMessage("Missing Statistic Description");
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

        private void cboStatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatType.SelectedItem.ToString() == "Amalgam" || cboStatType.SelectedItem.ToString() == "AmalgamPool")
            {
                gridAmalgamStats.Visible = true;
                lblAmalgam.Visible = true;
            }
            else
            {
                gridAmalgamStats.Visible = false;
                lblAmalgam.Visible = false;
                gridAmalgamStats.Rows.Clear();
            }
        }
    }


    // **************************************************
    // StatisticBuilder
    // **************************************************
    public class StatisticBuilder : EditorBuilder
    {
        public StatisticBuilder()
            : base(EditorSystemType.Statistic, "Statistic", "Statistics")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new StatisticControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "statistic_def", "system_name", "class_id = " + aClassId, "statistic_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            int statTagSetId = 0;
            DataTable dt = Database.getData("statistic_def", "statistic_def_id", aId, "stat_tag_set_def_id");
            if (dt != null)
            {
                if (dt.Rows[0]["stat_tag_set_def_id"] != DBNull.Value)
                    statTagSetId = (int)dt.Rows[0]["stat_tag_set_def_id"];
            }

            Database.deleteData("statistic_amalgam_map", "statistic_def_id", aId);
            Database.deleteData("statistic_prerequisite_map", "statistic_def_id", aId);
            Database.deleteData("statistic_def", "statistic_def_id", aId);

            if (statTagSetId > 0)
            {
                Database.deleteData("tag_set_map", "tag_set_def_id", (int)statTagSetId);
                Database.deleteData("tag_set_def", "tag_set_def_id", (int)statTagSetId);
            }
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("statistic_def", "statistic_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("statistic_def", aId, "system_name").ToString();
            return Database.getData("statistic_def", "statistic_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("statistic_def", aId, "system_name", "statistic_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("statistic_def");
        }

    }
}