using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemTreasureControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemTreasureControl()
        {
            InitializeComponent();
            linkTreasure.SystemType = EditorSystemType.Treasure;
        }

        public override void initNewImpl()
        {
            
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_treasure_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];
            mItemMapId = (int)dataRow["item_treasure_map_id"];

            numQuantity.Value = (int)dataRow["quantity"];
            EditorFactory.setupLink(linkTreasure, EditorSystemType.Treasure, Database.getNullableId(dataRow, "treasure_def_id"));
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (linkTreasure.Text == "")
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Treasure Definition.");
                    linkTreasure.BackColor = aErrorColor;
                }
                return false;
            }

            linkTreasure.BackColor = Color.Empty;
            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_treasure_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_treasure_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_treasure_map");

            Database.updateData("item_treasure_map", "item_treasure_map_id", mItemMapId, "quantity", (int)numQuantity.Value);
            Database.updateData("item_treasure_map", "item_treasure_map_id", mItemMapId, "treasure_def_id", BaseEditorControl.getContentLinkId(linkTreasure));
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_treasure_map", "item_def_id", aDefId);
        }
    }
}