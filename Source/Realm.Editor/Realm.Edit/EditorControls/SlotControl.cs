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
    // SlotControl
    // **************************************************
    public partial class SlotControl : BaseEditorControl
    {
        public SlotControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public SlotControl(int aClassId)
            : base(EditorSystemType.Slot, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "slot_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "slot_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "slot_def", "display_description");
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboSlotType, "ref_slot_type", "name", "ref_slot_type_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("slot_def", "slot_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Slot [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Slot [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Slot loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();
            numValue.Value = (int)dataRow["slot_value"];
            ComboUtils.fillCombo(cboSlotType, "ref_slot_type", "name", "ref_slot_type_id", (int)dataRow["ref_slot_type_id"]);

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("slot_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Slot Def");
                }
                else
                    Database.updateData("slot_def", "slot_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("slot_def", "slot_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("slot_def", "slot_def_id", Id, "display_description", txtDisplayDescription.Text);
                Database.updateData("slot_def", "slot_def_id", Id, "slot_value", (int)numValue.Value);
                Database.updateData("slot_def", "slot_def_id", Id, "ref_slot_type_id", (cboSlotType.SelectedItem as TagInfo).Id);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving slot [" + ControlName + "]");
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
                    Program.MainForm.setStatusMessage("Missing Display Description");
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
    // SlotBuilder
    // **************************************************
    public class SlotBuilder : EditorBuilder
    {
        public SlotBuilder()
            : base(EditorSystemType.Slot, "Slot", "Slots")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new SlotControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "slot_def", "system_name", "class_id = " + aClassId, "slot_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("slot_def", "slot_def_id = " + aId);
            Database.deleteData("slot_def", "slot_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("slot_def", "slot_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("slot_def", aId, "system_name").ToString();
            return Database.getData("slot_def", "slot_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("slot_def", aId, "system_name", "slot_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("slot_def");
        }

    }
}