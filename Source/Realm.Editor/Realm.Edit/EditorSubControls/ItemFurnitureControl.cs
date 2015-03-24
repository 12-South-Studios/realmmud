using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemFurnitureControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemFurnitureControl()
        {
            InitializeComponent();
        }

        public override void initNewImpl()
        {
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_furniture_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_furniture_map_id"];
            numSeats.Value = (int)dataRow["max_number"];
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
            Database.deleteData("item_furniture_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_furniture_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_furniture_map");

            Database.updateData("item_furniture_map", "item_furniture_map_id", mItemMapId, "max_number", (int)numSeats.Value);
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_furniture_map", "item_def_id", aDefId);
        }
    }
}
