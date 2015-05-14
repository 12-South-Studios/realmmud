using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemFoodControl : ItemSubControl
    {
        private int mItemMapId;

        public ItemFoodControl()
        {
            InitializeComponent();
        }

        public override void initNewImpl()
        {
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_food_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_food_map_id"];

            numHungerPoints.Value = (int)dataRow["hunger_points"];
            numCharges.Value = (int)dataRow["charges"];
            numGoodTime.Value = (int)dataRow["good_time"];
            numDecayTime.Value = Database.getNullableId(dataRow, "decay_time");
            if (dataRow["decay_description"] != DBNull.Value)
                txtDecayDescription.Text = dataRow["decay_description"].ToString();
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
            Database.deleteData("item_food_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_food_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_food_map");

            Database.updateData("item_food_map", "item_food_map_id", mItemMapId, "hunger_points", (int)numHungerPoints.Value);
            Database.updateData("item_food_map", "item_food_map_id", mItemMapId, "charges", (int)numCharges.Value);
            Database.updateData("item_food_map", "item_food_map_id", mItemMapId, "good_time", (int)numGoodTime.Value);
            Database.updateData("item_food_map", "item_food_map_id", mItemMapId, "decay_time", (int)numDecayTime.Value);
            Database.updateData("item_food_map", "item_food_map_id", mItemMapId, "decay_description", txtDecayDescription.Text);
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_food_map", "item_def_id", aDefId);
        }
    }
}

