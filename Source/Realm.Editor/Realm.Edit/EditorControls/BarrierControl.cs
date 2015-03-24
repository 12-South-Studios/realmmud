using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealmEdit
{
    public partial class BarrierControl : BaseEditorControl
    {
        public BarrierControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public BarrierControl(int aClassId)
            : base(EditorSystemType.Barrier, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "barrier_def", "system_name");

            linkLock.SystemType = EditorSystemType.Item;
            linkTrap.SystemType = EditorSystemType.Item;
            linkKey.SystemType = EditorSystemType.Item;
        }

        public override void initNewImpl()
        {
            ComboUtils.fillComboBox(cboMaterialTypes, "MaterialTypeTags", 0, String.Empty);
            ComboUtils.fillCombo(cboCondition, "ref_condition", "name", "ref_condition_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("barrier_def", "barrier_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Barrier [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Barrier [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Barrier loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            ComboUtils.fillCombo(cboMaterialTypes, "ref_material", "name", "ref_material_id", (int)dataRow["ref_material_id"]);
            EditorFactory.setupLink(linkLock, EditorSystemType.Item, Database.getNullableId(dataRow, "lock_item_def_id"));
            EditorFactory.setupLink(linkTrap, EditorSystemType.Item, Database.getNullableId(dataRow, "trap_item_def_id"));
            ComboUtils.fillCombo(cboCondition, "ref_condition", "name", "ref_condition_id", (int)dataRow["ref_condition_id"]);
            EditorFactory.setupLink(linkKey, EditorSystemType.Item, Database.getNullableId(dataRow, "key_item_def_id"));

            int flags = (int)dataRow["flags"];
            chkCloseable.Checked = ((flags & Globals.BARRIER_FLAG_Closeable) != 0) ? true : false;
            chkClosed.Checked = ((flags & Globals.BARRIER_FLAG_Closed) != 0) ? true : false;
            chkOneWay.Checked = ((flags & Globals.BARRIER_FLAG_OneWay) != 0) ? true : false;
            chkTransparent.Checked = ((flags & Globals.BARRIER_FLAG_Transparent) != 0) ? true : false;
            chkDestroyable.Checked = ((flags & Globals.BARRIER_FLAG_Destroyable) != 0) ? true : false;
            chkDestroyed.Checked = ((flags & Globals.BARRIER_FLAG_Destroyed) != 0) ? true : false;
            chkDispellable.Checked = ((flags & Globals.BARRIER_FLAG_Dispellable) != 0) ? true : false;
            chkLockable.Checked = ((flags & Globals.BARRIER_FLAG_Lockable) != 0) ? true : false;
            chkTrapable.Checked = ((flags & Globals.BARRIER_FLAG_Trapable) != 0) ? true : false;
            chkJumpable.Checked = ((flags & Globals.BARRIER_FLAG_Jumpable) != 0) ? true : false;
            chkClimbable.Checked = ((flags & Globals.BARRIER_FLAG_Climbable) != 0) ? true : false;
            chkSwimable.Checked = ((flags & Globals.BARRIER_FLAG_Swimmable) != 0) ? true : false;

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
                    Id = Database.createData("barrier_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Barrier Def");
                }
                else
                    Database.updateData("barrier_def", "barrier_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("barrier_def", "barrier_def_id", Id, "ref_material_id", (cboMaterialTypes.SelectedItem as TagInfo).Id);
                Database.updateData("barrier_def", "barrier_def_id", Id, "lock_item_def_id", getContentLinkId(linkLock));
                Database.updateData("barrier_def", "barrier_def_id", Id, "trap_item_def_id", getContentLinkId(linkTrap));
                Database.updateData("barrier_def", "barrier_def_id", Id, "ref_condition_id", (cboCondition.SelectedItem as TagInfo).Id);
                Database.updateData("barrier_def", "barrier_def_id", Id, "key_item_def_id", getContentLinkId(linkKey));

                int flags = 
                        (chkCloseable.Checked ? Globals.BARRIER_FLAG_Closeable : 0) |
                        (chkClosed.Checked ? Globals.BARRIER_FLAG_Closed : 0) |
                        (chkOneWay.Checked ? Globals.BARRIER_FLAG_OneWay : 0) |
                        (chkTransparent.Checked ? Globals.BARRIER_FLAG_Transparent : 0) |
                        (chkDispellable.Checked ? Globals.BARRIER_FLAG_Dispellable : 0) |
                        (chkDestroyable.Checked ? Globals.BARRIER_FLAG_Destroyable : 0) |
                        (chkDestroyed.Checked ? Globals.BARRIER_FLAG_Destroyed : 0) |
                        (chkLockable.Checked ? Globals.BARRIER_FLAG_Lockable : 0) |
                        (chkTrapable.Checked ? Globals.BARRIER_FLAG_Trapable : 0) |
                        (chkJumpable.Checked ? Globals.BARRIER_FLAG_Jumpable : 0) |
                        (chkClimbable.Checked ? Globals.BARRIER_FLAG_Climbable : 0) |
                        (chkSwimable.Checked ? Globals.BARRIER_FLAG_Swimmable : 0);
                Database.updateData("barrier_def", "barrier_def_id", Id, "flags", flags);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving barrier [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            Color errorColor = Color.DarkRed;

            if (txtSystemName.Text.Length <= 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                return false;
            }
            else
                txtSystemName.BackColor = Color.Empty;

            return true;
        }

        private void chkCloseable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCloseable.Checked)
            {
                chkClosed.Visible = true;
                chkClosed.Enabled = true;
            }
            else
            {
                chkClosed.Visible = false;
                chkClosed.Enabled = false;
            }
        }

        private void chkLockable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLockable.Checked)
            {
                linkLock.Visible = true;
                linkLock.Enabled = true;
                linkKey.Visible = true;
                linkKey.Enabled = true;
            }
            else
            {
                linkLock.Visible = false;
                linkLock.Enabled = false;
                linkKey.Visible = false;
                linkKey.Enabled = false;
            }
        }

        private void chkTrapable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrapable.Checked)
            {
                linkTrap.Visible = true;
                linkTrap.Enabled = true;
            }
            else
            {
                linkTrap.Visible = false;
                linkTrap.Enabled = false;
            }
        }

        private void chkDestroyable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDestroyable.Checked)
            {
                chkDestroyed.Visible = true;
                chkDestroyed.Enabled = true;
            }
            else
            {
                chkDestroyed.Visible = false;
                chkDestroyed.Enabled = false;
            }
        }
    }


    // **************************************************
    // BarrierBuilder
    // **************************************************
    public class BarrierBuilder : EditorBuilder
    {
        public BarrierBuilder()
            : base(EditorSystemType.Barrier, "Barrier", "Barriers")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }
        public override BaseEditorControl create(int aClassId)
        {
            return new BarrierControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "barrier_def", "system_name", "class_id = " + aClassId, "barrier_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("barrier_def", "barrier_def_id = " + aId);
            Database.deleteData("barrier_def", "barrier_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("barrier_def", "barrier_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("barrier_def", aId, "system_name").ToString();
            return Database.getData("barrier_def", "barrier_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("barrier_def", aId, "system_name", "barrier_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("barrier_def");
        }

    }
}
