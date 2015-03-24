using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemMachineControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemMachineControl()
        {
            InitializeComponent();
        }

        public override void initNewImpl()
        {
            //TagUtils.fillComboBox(cboMachineType, "MachineTypeTags", 0, String.Empty);
            ComboUtils.fillCombo(cboMachineType, "ref_machine_type", "name", "ref_machine_type_id", 0);
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_machine_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_machine_map_id"];

            //TagUtils.fillComboBox(cboMachineType, "MachineTypeTags", (int)dataRow["machine_tag_def_id"], string.Empty);
            ComboUtils.fillCombo(cboMachineType, "ref_machine_type", "name", "ref_machine_type_id", (int)dataRow["ref_machine_type_id"]);
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboMachineType.SelectedIndex == -1)
                return false;

            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_machine_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_machine_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_machine_map");

            Database.updateData("item_machine_map", "item_machine_map_id", mItemMapId, "ref_machine_type_id", (cboMachineType.SelectedItem as TagInfo).Id);
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_machine_map", "item_def_id", aDefId);
        }
    }
}
