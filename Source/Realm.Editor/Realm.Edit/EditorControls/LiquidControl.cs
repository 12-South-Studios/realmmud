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
    // LiquidControl
    // **************************************************
    public partial class LiquidControl : BaseEditorControl
    {
        public LiquidControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public LiquidControl(int aClassId)
            : base(EditorSystemType.Liquid, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "liquid_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "liquid_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "liquid_def", "display_description");
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboColor, "ref_color", "name", "ref_color_id", 0);
            ComboUtils.fillCombo(cboFlammability, "ref_flammability", "name", "ref_flammability_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("liquid_def", "liquid_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Liquid [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Liquid [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Liquid loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();
            numThirstPoints.Value = (int)dataRow["thirst_points"];
            numDrunkPoints.Value = (int)dataRow["drunk_points"];
            numCostPerCharge.Value = Convert.ToDecimal(dataRow["cost_per_charge"]);

            ComboUtils.fillCombo(cboFlammability, "ref_flammability", "name", "ref_flammability_id", (int)dataRow["ref_flammability_id"]);
            ComboUtils.fillCombo(cboColor, "ref_color", "name", "ref_color_id", (int)dataRow["ref_color_id"]);

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("liquid_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Liquid Def");
                }
                else
                    Database.updateData("liquid_def", "liquid_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("liquid_def", "liquid_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("liquid_def", "liquid_def_id", Id, "display_description", txtDisplayDescription.Text);
                Database.updateData("liquid_def", "liquid_def_id", Id, "thirst_points", (int)numThirstPoints.Value);
                Database.updateData("liquid_def", "liquid_def_id", Id, "drunk_points", (int)numDrunkPoints.Value);
                Database.updateData("liquid_def", "liquid_def_id", Id, "cost_per_charge", Convert.ToSingle(numCostPerCharge.Value));
                Database.updateData("liquid_def", "liquid_def_id", Id, "ref_flammability_id", (cboFlammability.SelectedItem as TagInfo).Id);
                Database.updateData("liquid_def", "liquid_def_id", Id, "ref_color_id", (cboColor.SelectedItem as TagInfo).Id);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving liquid [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
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
                    Program.MainForm.setStatusMessage("Missing Liquid Name");
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
                    Program.MainForm.setStatusMessage("Missing Liquid Description");
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
    // LiquidBuilder
    // **************************************************
    public class LiquidBuilder : EditorBuilder
    {
        public LiquidBuilder()
            : base(EditorSystemType.Liquid, "Liquid", "Liquids")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new LiquidControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "liquid_def", "system_name", "class_id = " + aClassId, "liquid_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("liquid_def", "liquid_def_id = " + aId);
            Database.deleteData("liquid_def", "liquid_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("liquid_def", "liquid_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("liquid_def", aId, "system_name").ToString();
            return Database.getData("liquid_def", "liquid_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("liquid_def", aId, "system_name", "liquid_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("liquid_def");
        }

    }
}

