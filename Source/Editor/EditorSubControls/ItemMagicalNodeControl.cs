using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemMagicalNodeControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemMagicalNodeControl()
        {
            InitializeComponent();
            linkAuraEffect.SystemType = EditorSystemType.Effect;
        }

        public override void initNewImpl()
        {
            ComboUtils.fillComboBox(cboElementType, "ElementTypeTags", 0, String.Empty);
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_magicalnode_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_magicalnode_map_id"];
            ComboUtils.fillComboBox(cboElementType, "ElementTypeTags", (int)dataRow["tag_def_id"], string.Empty);

            if (dataRow["effect_time"] != DBNull.Value)
                numAuraTime.Value = (int)dataRow["effect_time"];
            if (dataRow["effect_def_id"] != DBNull.Value)
                EditorFactory.setupLink(linkAuraEffect, EditorSystemType.Effect, Database.getNullableId(dataRow, "effect_def_id"));
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboElementType.SelectedIndex == -1)
                return false;

            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_magicalnode_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_magicalnode_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_magicalnode_map");

            Database.updateData("item_magicalnode_map", "item_magicalnode_map_id", mItemMapId, "tag_def_id", (cboElementType.SelectedItem as SystemTag).Value);
            Database.updateData("item_magicalnode_map", "item_magicalnode_map_id", mItemMapId, "effect_time", (int)numAuraTime.Value);
            Database.updateData("item_magicalnode_map", "item_magicalnode_map_id", mItemMapId, "effect_def_id", BaseEditorControl.getContentLinkId(linkAuraEffect));
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_magicalnode_map", "item_def_id", aDefId);
        }
    }
}
