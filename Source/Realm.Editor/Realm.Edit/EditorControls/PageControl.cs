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
    // PageControl
    // **************************************************
    public partial class PageControl : BaseEditorControl
    {
        public PageControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public PageControl(int aClassId)
            : base(EditorSystemType.Page, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "page_def", "system_name");
            TextBoxUtils.initTextBox(txtPageText, "page_def", "page_text");
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("page_def", "page_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Page [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Page [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Page loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            //TextBoxUtils.populateTextBox(txtPageText, stringRow, "page_text");
            txtPageText.Text = dataRow["page_text"].ToString();

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("page_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Page Def");
                }
                else
                    Database.updateData("page_def", "page_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("page_def", "page_def_id", Id, "page_text", txtPageText.Text);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving page [" + ControlName + "]");
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
            if (txtPageText.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Page Text");
                    txtPageText.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtPageText.BackColor = Color.Empty;
            }

            return valid;
        }
    }


    // **************************************************
    // PageBuilder
    // **************************************************
    public class PageBuilder : EditorBuilder
    {
        public PageBuilder()
            : base(EditorSystemType.Page, "Page", "Pages")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new PageControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "page_def", "system_name", "class_id = " + aClassId, "page_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("page_def", "page_def_id = " + aId);
            Database.deleteData("page_def", "page_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("page_def", "page_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("page_def", aId, "system_name").ToString();
            return Database.getData("page_def", "page_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("page_def", aId, "system_name", "page_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("page_def");
        }

    }
}
