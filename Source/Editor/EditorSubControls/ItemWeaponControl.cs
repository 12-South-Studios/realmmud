using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemWeaponControl  : ItemSubControl
    {
        private int mItemMapId;

        public ItemWeaponControl()
        {
            InitializeComponent();

            linkEffect.SystemType = EditorSystemType.Effect;
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboWeaponType, "ref_weapon_type", "name", "ref_weapon_type_id", 0);
            ComboUtils.fillCombo(cboWeaponSpeed, "ref_speed_class", "name", "ref_speed_class_id", 0);
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_weapon_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_weapon_map_id"];

            EditorFactory.setupLink(linkEffect, EditorSystemType.Effect, Database.getNullableId(dataRow, "effect_def_id"));
            ComboUtils.fillCombo(cboWeaponType, "ref_weapon_type", "name", "ref_weapon_type_id", Database.getNullableId(dataRow, "ref_weapon_type_id"));
            ComboUtils.fillCombo(cboWeaponSpeed, "ref_speed_class", "name", "ref_speed_class_id", Database.getNullableId(dataRow, "ref_speed_class_id"));

            int flags = (int)dataRow["flags"];
            chkIsThrowable.Checked = ((flags & Globals.WEAPON_FLAG_Throwable) != 0) ? true : false;
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboWeaponSpeed.SelectedIndex == -1) return false;
            if (cboWeaponType.SelectedIndex == -1) return false;
            if (linkEffect.Text == "") return false;
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_weapon_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_weapon_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_weapon_map");

            Database.updateData("item_weapon_map", "item_weapon_map_id", mItemMapId, "effect_def_id", BaseEditorControl.getContentLinkId(linkEffect));
            Database.updateData("item_weapon_map", "item_weapon_map_id", mItemMapId, "ref_weapon_type_id", (cboWeaponType.SelectedItem as TagInfo).Id);
            Database.updateData("item_weapon_map", "item_weapon_map_id", mItemMapId, "ref_speed_class_id", (cboWeaponSpeed.SelectedItem as TagInfo).Id);

            int flags =
                (chkIsThrowable.Checked ? Globals.WEAPON_FLAG_Throwable : 0);
            Database.updateData("item_weapon_map", "item_weapon_map_id", mItemMapId, "flags", flags);
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_weapon_map", "item_def_id", aDefId);
        }
    }
}

