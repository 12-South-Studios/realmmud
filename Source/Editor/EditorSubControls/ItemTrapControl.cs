using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemTrapControl  : ItemSubControl
    {
        private int mItemMapId;

        public ItemTrapControl()
        {
            InitializeComponent();

            linkSpaceEffect.SystemType = EditorSystemType.SpaceEffect;
            linkEffect.SystemType = EditorSystemType.Effect;
            linkDisarmSkill.SystemType = EditorSystemType.Statistic;
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboTargetClass, "ref_target_clas", "name", "ref_target_class_id", 0);
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", 0);
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_trap_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_trap_map_id"];

            EditorFactory.setupLink(linkDisarmSkill, EditorSystemType.Statistic, (int)dataRow["disarm_statistic_def_id"]);
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", (int)dataRow["ref_difficulty_id"]);
            ComboUtils.fillCombo(cboTargetClass, "ref_target_class", "name", "ref_target_class_id", (int)dataRow["ref_target_class_id"]);

            int flags = (int)dataRow["flags"];
            chkIsDestroyedOnUse.Checked = ((flags & Globals.TRAP_FLAG_DestroyedOnUse) != 0) ? true : false;
            chkIsAreaNotifier.Checked = ((flags & Globals.TRAP_FLAG_AreaNotifier) != 0) ? true : false;

            if (dataRow["notify_radius"] != DBNull.Value)
                numNotifyRadius.Value = (int)dataRow["notify_radius"];

            EditorFactory.setupLink(linkSpaceEffect, EditorSystemType.SpaceEffect, Database.getNullableId(dataRow, "space_effect_def_id"));
            EditorFactory.setupLink(linkEffect, EditorSystemType.Effect, Database.getNullableId(dataRow, "effect_def_id"));
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboDifficulty.SelectedIndex == -1) return false;
            if (linkDisarmSkill.Text == "") return false;
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_trap_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_trap_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_trap_map");

            Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "disarm_statistic_def_id", BaseEditorControl.getContentLinkId(linkDisarmSkill));
            Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "ref_difficulty_id", (cboDifficulty.SelectedItem as TagInfo).Id);
            Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "ref_target_class_id", (cboTargetClass.SelectedItem as TagInfo).Id);

            int flags =
                (chkIsDestroyedOnUse.Checked ? Globals.TRAP_FLAG_DestroyedOnUse : 0) |
                (chkIsAreaNotifier.Checked ? Globals.TRAP_FLAG_AreaNotifier : 0);
            Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "flags", flags);

            if (chkIsAreaNotifier.Checked)
                Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "notify_radius", (int)numNotifyRadius.Value);
            Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "space_effect_def_id", BaseEditorControl.getContentLinkId(linkSpaceEffect));
            Database.updateData("item_trap_map", "item_trap_map_id", mItemMapId, "effect_def_id", BaseEditorControl.getContentLinkId(linkEffect));
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_trap_map", "item_def_id", aDefId);
        }
    }
}

