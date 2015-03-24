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
    // ChannelControl
    // **************************************************
    public partial class ChannelControl : BaseEditorControl
    {
        public ChannelControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public ChannelControl(int aClassId)
            : base(EditorSystemType.Channel, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "channel_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "channel_def", "display_name");
            ComboUtils.fillCombo(cboType, "ref_channel_type", "name", "ref_channel_type_id", 0);
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("channel_def", "channel_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Channel [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Channel [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Channel loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();

            int flags = Database.getNullableId(dataRow, "flags");
            chkReadOnly.Checked = ((flags & Globals.CHANNEL_FLAG_ReadOnly) != 0) ? true : false;
            chkAdmin.Checked = ((flags & Globals.CHANNEL_FLAG_Admin) != 0) ? true : false;

            ComboUtils.fillCombo(cboType, "ref_channel_type", "name", "ref_channel_type_id", (int)dataRow["ref_channel_type_id"]);

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("channel_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Channel Def");
                }
                else
                    Database.updateData("channel_def", "channel_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("channel_def", "channel_def_id", Id, "display_name", txtDisplayName.Text);

                int flags = 
                    (chkReadOnly.Checked ? Globals.CHANNEL_FLAG_ReadOnly : 0) |
                    (chkAdmin.Checked ? Globals.CHANNEL_FLAG_Admin : 0);
                Database.updateData("channel_def", "channel_def_id", Id, "flags", flags);
                Database.updateData("channel_def", "channel_def_id", Id, "ref_channel_type_id", (cboType.SelectedItem as TagInfo).Id);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving channel [" + ControlName + "]");
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

            return valid;
        }
    }


    // **************************************************
    // ChannelBuilder
    // **************************************************
    public class ChannelBuilder : EditorBuilder
    {
        public ChannelBuilder()
            : base(EditorSystemType.Channel, "Channel", "Channels")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new ChannelControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "channel_def", "system_name", "class_id = " + aClassId, "Channel_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("channel_def", "channel_def_id = " + aId);
            Database.deleteData("channel_def", "channel_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("channel_def", "channel_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("channel_def", aId, "system_name").ToString();
            return Database.getData("channel_def", "channel_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("channel_def", aId, "system_name", "channel_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("channel_def");
        }

    }
}
