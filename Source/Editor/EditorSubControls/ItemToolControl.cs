using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemToolControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemToolControl()
        {
            InitializeComponent();  
        }

        public override void initNewImpl()
        {
            //TagUtils.fillComboBox(cboToolType, "ToolTypeTags", 0, String.Empty);
            ComboUtils.fillCombo(cboToolType, "ref_tool_type", "name", "ref_tool_type_id", 0);
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_tool_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_tool_map_id"];

            ComboUtils.fillCombo(cboToolType, "ref_tool_type", "name", "ref_tool_type_id", (int)dataRow["ref_tool_type_id"]);
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboToolType.SelectedIndex == -1)
                return false;

            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_tool_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_tool_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_tool_map");

            Database.updateData("item_tool_map", "item_tool_map_id", mItemMapId, "ref_tool_type_id", (cboToolType.SelectedItem as TagInfo).Id);
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_tool_map", "item_def_id", aDefId);
        }
    }
}
