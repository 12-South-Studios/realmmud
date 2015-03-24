using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemPotionControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemPotionControl()
        {
            InitializeComponent();
            linkAbility.SystemType = EditorSystemType.Ability;
        }

        public override void initNewImpl()
        {
            
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_potion_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_potion_map_id"];

            numCharges.Value = (int)dataRow["charges"];
            EditorFactory.setupLink(linkAbility, EditorSystemType.Ability, Database.getNullableId(dataRow, "ability_def_id"));
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
            Database.deleteData("item_potion_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_potion_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_potion_map");

            Database.updateData("item_potion_map", "item_potion_map_id", mItemMapId, "charges", (int)numCharges.Value);
            Database.updateData("item_potion_map", "item_potion_map_id", mItemMapId, "ability_def_id", BaseEditorControl.getContentLinkId(linkAbility));
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_potion_map", "item_def_id", aDefId);
        }
    }
}