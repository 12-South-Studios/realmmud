using System.Drawing;
using System.Data.SqlClient;
using Realm.DAL.Enumerations;
using Realm.Edit.Extensions;

namespace Realm.Edit.EditorControls
{
    public partial class RaceControl : BaseEditorControl
    {
        public RaceControl()
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public RaceControl(int aClassId)
            : base(SystemTypes.Race, aClassId)
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        private void InitControls()
        {
            //TextBoxUtils.initTextBox(txtSystemName, "race_def", "system_name");
            //TextBoxUtils.initTextBox(txtDisplayName, "race_def", "display_name");
            //TextBoxUtils.initTextBox(txtDisplayDescription, "race_def", "display_description");
            //TextBoxUtils.initTextBox(txtAbbreviation, "race_def", "abbreviation");

            //InitStatModsGrid();
            //InitAbilitiesGrid();
        }

        /*private void InitStatModsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = DataSystemType.Skill;
                col.Name = "statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Statistic";
                col.CellTemplate = cell;
                gridStatMods.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "value_change";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Stat Modifier";
                col.CellTemplate = cell;
                col.Maximum = 100;
                col.Minimum = -100;
                gridStatMods.Columns.Add(col);
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
                col.HeaderText = "Ability";
                col.CellTemplate = cell;
                gridAbilities.Columns.Add(col);
            }
        }*/

        public override void InitNewImpl()
        {
            cboSize.Fill("ref_size", "ref_size_id", 0);
        }

        public override void MakeCopyImpl()
        {
            txtSystemName.Text = ControlName;
            Id = 0;
        }

        public override void InitContentImpl(int aId)
        {
            /*DataTable dt = Database.getData("race_def", "race_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Race [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Race [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Race loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            //TextBoxUtils.populateTextBox(txtAbbreviation, dataRow, "abbreviation");
            txtAbbreviation.Text = dataRow["abbreviation"].ToString();
            
            ComboUtils.fillCombo(cboSize, "ref_size", "name", "ref_size_id", (int)dataRow["ref_size_id"]);
            
            int flags = (int)dataRow["flags"];
            chkPlayerRace.Checked = ((flags & Globals.RACE_FLAG_Player) != 0) ? true : false;

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadStatModGrid(aId);
            loadAbilityGrid(aId);*/
        }

        /*private void loadStatModGrid(int aId)
        {
            gridStatMods.Rows.Clear();

            DataTable dt = Database.getData("race_statistic_map", "race_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridStatMods.Rows.Add();
                DataGridViewRow gridRow = gridStatMods.Rows[gridIndex];

                DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");
                
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellMod = gridRow.Cells["value_change"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellMod.Value = (int)rowView["value_change"];

                gridRow.Tag = (int)rowView["race_statistic_map_id"];
            }
            dt.Dispose();
        }

        private void loadAbilityGrid(int aId)
        {
            gridAbilities.Rows.Clear();

            DataTable dt = Database.getData("race_ability_map", "race_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridAbilities.Rows.Add();
                DataGridViewRow gridRow = gridAbilities.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["ability_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Ability, rowView, "ability_def_id");

                gridRow.Tag = (int)rowView["race_ability_map_id"];
            }
            dt.Dispose();
        }*/

        public override bool SaveImpl()
        {
            gridStatMods.EndEdit();
            gridAbilities.EndEdit();

            try {
                /*Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("race_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Race Def");
                }
                else
                    Database.updateData("race_def", "race_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("race_def", "race_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("race_def", "race_def_id", Id, "display_description", txtDisplayDescription.Text);
                Database.updateData("race_def", "race_def_id", Id, "abbreviation", txtAbbreviation.Text);

                int flags = (chkPlayerRace.Checked ? Globals.RACE_FLAG_Player : 0);
                Database.updateData("race_def", "race_def_id", Id, "flags", flags);
                Database.updateData("race_def", "race_def_id", Id, "ref_size_id", (cboSize.SelectedItem as TagInfo).Id);

                saveStatModsGrid(Id);
                saveAbilityGrid(Id);;

                Database.commitTransaction();*/

                InitContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                //Database.handleException(ex, "Error saving race [" + ControlName + "]");
                //Database.rollbackTransaction();
                return false;
            }
        }

        /*private void saveStatModsGrid(int aDefId)
        {
            Database.deleteData("race_statistic_map", "race_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridStatMods.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("race_statistic_map", "race_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in race_statistic_map");

                    Database.updateData("race_statistic_map", "race_statistic_map_id", rowId, "statistic_def_id", statDefIdBrowseInfo.Id);
                    Database.updateData("race_statistic_map", "race_statistic_map_id", rowId, "value_change", (int)gridRow.Cells["value_change"].Value);
                }
            }
            gridStatMods.flushDeletedRows();
        }

        private void saveAbilityGrid(int aDefId)
        {
            Database.deleteData("race_ability_map", "race_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAbilities.Rows)
            {
                if (!gridRow.IsNewRow)
                {
                    EditorBrowseInfo abDefIdBrowseInfo = gridRow.Cells["ability_def_id"].Value as EditorBrowseInfo;
                    if (abDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("race_ability_map", "race_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in race_ability_map");

                    Database.updateData("race_ability_map", "race_ability_map_id", rowId, "ability_def_id", abDefIdBrowseInfo.Id);
                }
            }
            gridAbilities.flushDeletedRows();
        }*/

        public override bool IsSaveValid(bool aGiveFeedback)
        {
            bool valid = true;
            Color errorColor = Color.DarkRed;

            // Validate system name
            if (txtSystemName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.SetWarningMessage("Missing Race Name");
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
                    Program.MainForm.SetWarningMessage("Missing Display Name");
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
                    Program.MainForm.SetWarningMessage("Missing Race Description");
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
}
