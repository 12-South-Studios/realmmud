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
    // StaticStringControl
    // **************************************************
    public partial class StaticStringControl : BaseEditorControl
    {
        public StaticStringControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public StaticStringControl(int aClassId)
            : base(EditorSystemType.String, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "static_string_def", "system_name");
            TextBoxUtils.initTextBox(txtStringText, "static_string_def", "text");
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("static_string_def", "static_string_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Static String [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Static String [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Static String loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtStringText.Text = dataRow["text"].ToString();
            numCodeValue.Value = Database.getNullableId(dataRow, "code");

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("static_string_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Static String Def");
                }
                else
                    Database.updateData("static_string_def", "static_string_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("static_string_def", "static_string_def_id", Id, "text", txtStringText.Text);
                Database.updateData("static_string_def", "static_string_def_id", Id, "code", (int)numCodeValue.Value);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving static string [" + ControlName + "]");
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
                    Program.MainForm.setStatusMessage("Missing String Name");
                    txtSystemName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemName.BackColor = Color.Empty;
            }

            // Validate display name
            if (txtStringText.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing String Text");
                    txtStringText.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtStringText.BackColor = Color.Empty;
            }

            return valid;
        }
    }


    // **************************************************
    // StaticStringBuilder
    // **************************************************
    public class StaticStringBuilder : EditorBuilder
    {
        public StaticStringBuilder()
            : base(EditorSystemType.String, "Static String", "Static Strings")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new StaticStringControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "static_string_def", "system_name", "class_id = " + aClassId, "static_string_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("static_string_def", "static_string_def_id = " + aId);
            Database.deleteData("static_string_def", "static_string_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("static_string_def", "static_string_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("static_string_def", aId, "system_name").ToString();
            return Database.getData("static_string_def", "static_string_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("static_string_def", aId, "system_name", "static_string_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("static_string_def");
        }

    }
}
