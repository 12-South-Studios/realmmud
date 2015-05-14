using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemPortalControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemPortalControl()
        {
            InitializeComponent();
            linkDestination.SystemType = EditorSystemType.Space;
        }

        public override void initNewImpl()
        {
            
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_portal_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_portal_map_id"];

            EditorFactory.setupLink(linkDestination, EditorSystemType.Space, Database.getNullableId(dataRow, "destination_space_def_id"));

            int flags = (int)dataRow["flags"];
            chkOnUse.Checked = ((flags & Globals.PORTAL_FLAG_OnUse) != 0) ? true : false;
            chkOnEnter.Checked = ((flags & Globals.PORTAL_FLAG_OnEnter) != 0) ? true : false;
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_portal_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_portal_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_portal_map");

            Database.updateData("item_portal_map", "item_portal_map_id", mItemMapId, "destination_space_def_id", BaseEditorControl.getContentLinkId(linkDestination));

            int flags =
                (chkOnUse.Checked ? Globals.PORTAL_FLAG_OnUse : 0) |
                (chkOnEnter.Checked ? Globals.PORTAL_FLAG_OnEnter : 0);
            Database.updateData("item_portal_map", "item_portal_map_id", mItemMapId, "flags", flags);
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_portal_map", "item_def_id", aDefId);
        }

        private void chkOnUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnUse.Checked)
            {
                chkOnEnter.Checked = false;
            }
        }

        private void chkOnEnter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnEnter.Checked)
            {
                chkOnUse.Checked = false;
            }
        }
    }
}