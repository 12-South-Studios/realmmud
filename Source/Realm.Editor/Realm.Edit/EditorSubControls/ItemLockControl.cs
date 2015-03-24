using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemLockControl  : ItemSubControl
    {
        private int mItemMapId;

        public ItemLockControl()
        {
            InitializeComponent();

            linkPickSkill.SystemType = EditorSystemType.Statistic;
            linkKey.SystemType = EditorSystemType.Item;
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", 0);
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_lock_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_lock_map_id"];

            EditorFactory.setupLink(linkPickSkill, EditorSystemType.Statistic, (int)dataRow["pick_statistic_def_id"]);
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", (int)dataRow["pick_difficulty_id"]);

            int flags = (int)dataRow["flags"];
            chkIsRelockable.Checked = ((flags & Globals.LOCK_FLAG_Relockable) != 0) ? true : false;

            EditorFactory.setupLink(linkKey, EditorSystemType.Item, Database.getNullableId(dataRow, "key_item_def_id"));
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboDifficulty.SelectedIndex == -1) return false;
            if (linkPickSkill.Text == "") return false;
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_lock_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_lock_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_lock_map");

            Database.updateData("item_lock_map", "item_lock_map_id", mItemMapId, "pick_statistic_def_id", BaseEditorControl.getContentLinkId(linkPickSkill));
            Database.updateData("item_lock_map", "item_lock_map_id", mItemMapId, "ref_difficulty_id", (cboDifficulty.SelectedItem as TagInfo).Id);

            int flags = 
                (chkIsRelockable.Checked ? Globals.LOCK_FLAG_Relockable : 0);
            Database.updateData("item_lock_map", "item_lock_map_id", mItemMapId, "flags", flags);
            Database.updateData("item_lock_map", "item_lock_map_id", mItemMapId, "key_item_def_id", BaseEditorControl.getContentLinkId(linkKey));
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_lock_map", "item_def_id", aDefId);
        }
    }
}

