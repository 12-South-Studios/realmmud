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
    // AccessControl
    // **************************************************
    public partial class AccessControl : BaseEditorControl
    {
        public AccessControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public AccessControl(int aClassId)
            : base(EditorSystemType.AccessLevel, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "access_def", "system_name");
            TextBoxUtils.initTextBox(txtSystemDescription, "access_def", "system_description");
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("access_def", "access_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Access [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Access [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Access loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            if (dataRow["system_description"] != DBNull.Value)
                txtSystemDescription.Text = dataRow["system_description"].ToString();
            if (dataRow["access_value"] != DBNull.Value)
                numValue.Value = (int)dataRow["access_value"];

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("access_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Access Def");
                }
                else
                    Database.updateData("access_def", "access_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("access_def", "access_def_id", Id, "access_value", (int)numValue.Value);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving access level [" + ControlName + "]");
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
                    Program.MainForm.setStatusMessage("Missing Access Level Name");
                    txtSystemName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemName.BackColor = Color.Empty;
            }

            return valid;
        }
    }


    // **************************************************
    // AccessBuilder
    // **************************************************
    public class AccessBuilder : EditorBuilder
    {
        public AccessBuilder()
            : base(EditorSystemType.AccessLevel, "Access Level", "Access Levels")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new AccessControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "access_def", "system_name", "class_id = " + aClassId, "access_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("access_def", "access_def_id = " + aId);
            Database.deleteData("access_def", "access_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("access_def", "access_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("access_def", aId, "system_name").ToString();
            return Database.getData("access_def", "access_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("access_def", aId, "system_name", "access_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("access_def");
        }

    }
}
