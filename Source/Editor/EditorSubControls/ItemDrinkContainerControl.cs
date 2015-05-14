using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemDrinkContainerControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemDrinkContainerControl()
        {
            InitializeComponent();
            linkLiquid.SystemType = EditorSystemType.Liquid;
        }

        public override void initNewImpl()
        {
            
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_drinkcontainer_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_drinkcontainer_map_id"];

            numCharges.Value = (int)dataRow["max_charges"];

            int flags = (int)dataRow["flags"];
            chkIsCloseable.Checked = ((flags & Globals.CONTAINER_FLAG_Closeable) != 0) ? true : false;

            EditorFactory.setupLink(linkLiquid, EditorSystemType.Liquid, Database.getNullableId(dataRow, "liquid_def_id"));
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
            Database.deleteData("item_drinkcontainer_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_drinkcontainer_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_drinkcontainer_map");

            Database.updateData("item_drinkcontainer_map", "item_drinkcontainer_map_id", mItemMapId, "max_charges", (int)numCharges.Value);
            int flags = 
                    (chkIsCloseable.Checked ? Globals.CONTAINER_FLAG_Closeable : 0);
            Database.updateData("item_drinkcontainer_map", "item_drinkcontainer_map_id", mItemMapId, "flags", flags);
            Database.updateData("item_drinkcontainer_map", "item_drinkcontainer_map_id", mItemMapId, "liquid_def_id", BaseEditorControl.getContentLinkId(linkLiquid));
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_drinkcontainer_map", "item_def_id", aDefId);
        }
    }
}

