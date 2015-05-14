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
    // TerrainControl
    // **************************************************
    public partial class TerrainControl : BaseEditorControl
    {
        public TerrainControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public TerrainControl(int aClassId)
            : base(EditorSystemType.Terrain, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "terrain_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "terrain_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "terrain_def", "display_description");
        }

        public override void initNewImpl()
        {
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("terrain_def", "terrain_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Terrain [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Terrain [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Terrain loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            int flags = (int)dataRow["flags"];
            chkUnderground.Checked = ((flags & Globals.TERRAIN_FLAG_Underground) != 0) ? true : false;

            dt.Dispose();
            ControlName = txtSystemName.Text;
        }

        public override bool saveImpl()
        {
            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("terrain_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Terrain Def");
                }
                else
                    Database.updateData("terrain_def", "terrain_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("terrain_def", "terrain_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("terrain_def", "terrain_def_id", Id, "display_description", txtDisplayDescription.Text);
                
                int flags = (chkUnderground.Checked ? Globals.TERRAIN_FLAG_Underground : 0);
                Database.updateData("terrain_def", "terrain_def_id", Id, "flags", flags);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving terrain [" + ControlName + "]");
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
                    Program.MainForm.setStatusMessage("Missing Terrain Name");
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
                    Program.MainForm.setStatusMessage("Missing Terrain Description");
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
    // TerrainBuilder
    // **************************************************
    public class TerrainBuilder : EditorBuilder
    {
        public TerrainBuilder()
            : base(EditorSystemType.Terrain, "Terrain", "Terrain Types")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new TerrainControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "terrain_def", "system_name", "class_id = " + aClassId, "Terrain_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("terrain_def", "terrain_def_id = " + aId);
            Database.deleteData("terrain_def", "terrain_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("terrain_def", "terrain_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("terrain_def", aId, "system_name").ToString();
            return Database.getData("terrain_def", "terrain_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("terrain_def", aId, "system_name", "terrain_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("terrain_def");
        }

    }
}