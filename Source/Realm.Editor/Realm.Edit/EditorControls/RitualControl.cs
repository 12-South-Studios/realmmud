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
    // RitualControl
    // **************************************************
    public partial class RitualControl : BaseEditorControl
    {
        public RitualControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public RitualControl(int aClassId)
            : base(EditorSystemType.Ritual, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "ritual_def", "system_name");
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("ritual_def", "ritual_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Ritual [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Ritual [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Ritual loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("ritual_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Ritual Def");
                }
                else
                    Database.updateData("ritual_def", "ritual_def_id", Id, "system_name", txtSystemName.Text); 
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving ritual [" + ControlName + "]");
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
                    Program.MainForm.setStatusMessage("Missing Ritual System Name");
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
    // RitualBuilder
    // **************************************************
    public class RitualBuilder : EditorBuilder
    {
        public RitualBuilder()
            : base(EditorSystemType.Ritual, "Ritual", "Rituals")
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
            return populateBrowseNodeImpl(aParentNode, aClassId, "ritual_def", "system_name", "class_id = " + aClassId, "ritual_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("ritual_def", "ritual_def_id = " + aId);
            Database.deleteData("ritual_def", "ritual_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("ritual_def", "ritual_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("ritual_def", aId, "system_name").ToString();
            return Database.getData("ritual_def", "ritual_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("ritual_def", aId, "system_name", "ritual_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("ritual_def");
        }

    }
}
