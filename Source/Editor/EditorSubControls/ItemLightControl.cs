using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class ItemLightControl : ItemSubControl
    {
        private int mItemMapId;

        public enum FuelType { Solid, Liquid };

        public ItemLightControl()
        {
            InitializeComponent();
            linkLiquidFuel.SystemType = EditorSystemType.Liquid;
        }

        public override void initNewImpl()
        {
            //TagUtils.fillComboBox(cboFuelType, "FuelTypeTags", 0, String.Empty);
            ComboUtils.fillCombo(cboFuelType, "ref_fuel_type", "name", "ref_fuel_type_id", 0);
            
        }

        public override void loadItemData(int aDefId)
        {
            DataTable dt = Database.getData("item_light_map", "item_def_id", aDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mItemMapId = (int)dataRow["item_light_map_id"];

            //TagUtils.fillComboBox(cboFuelType, "FuelTypeTags", (int)dataRow["fuel_type_tag_def_id"], string.Empty);
            ComboUtils.fillCombo(cboFuelType, "ref_fuel_type", "name", "ref_fuel_type_id", (int)dataRow["ref_fuel_type_id"]);

            numBurnTime.Value = Database.getNullableId(dataRow, "solid_fuel_burn_time");
            EditorFactory.setupLink(linkLiquidFuel, EditorSystemType.Liquid, Database.getNullableId(dataRow, "liquid_fuel_def_id"));
            numMaxCharges.Value = Database.getNullableId(dataRow, "liquid_fuel_max_charges");
            numBurnRate.Value = Database.getNullableId(dataRow, "liquid_fuel_burn_rate");
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (cboFuelType.SelectedIndex == -1)
                return false;

            return true;
        }

        public override void preSaveItemData(int aItemDefId)
        {
        }

        public override void saveItemData(int aDefId)
        {
            Database.deleteData("item_light_map", "item_def_id", aDefId);

            mItemMapId = Database.createData("item_light_map", "item_def_id", aDefId, null, null);
            if (mItemMapId == 0) throw new Exception("Failed to create new row in item_light_map");

            int fuelTypeId = (cboFuelType.SelectedItem as TagInfo).Id;
            Database.updateData("item_light_map", "item_light_map_id", mItemMapId, "ref_fuel_type_id", fuelTypeId);
            if (fuelTypeId == Globals.FUEL_TYPE_Solid)
            {
                Database.updateData("item_light_map", "item_light_map_id", mItemMapId, "solid_fuel_burn_time", (int)numBurnTime.Value);
            }
            else if (fuelTypeId == Globals.FUEL_TYPE_Liquid)
            {
                Database.updateData("item_light_map", "item_light_map_id", mItemMapId, "liquid_fuel_def_id", BaseEditorControl.getContentLinkId(linkLiquidFuel));
                Database.updateData("item_light_map", "item_light_map_id", mItemMapId, "liquid_fuel_burn_rate", (int)numBurnRate.Value);
                Database.updateData("item_light_map", "item_light_map_id", mItemMapId, "liquid_fuel_max_charges", (int)numMaxCharges.Value);
            }
        }

        public override void preClearItemData(int aDefId)
        {
            Database.deleteData("item_light_map", "item_def_id", aDefId);
        }

        private void cboFuelType_Changed(object sender, EventArgs e)
        {
            if (cboFuelType.SelectedItem.ToString() == FuelType.Solid.ToString())
            {
                linkLiquidFuel.Visible = false;
                lblLiquidFuel.Visible = false;
                numMaxCharges.Visible = false;
                lblMaxCharges.Visible = false;
                numBurnRate.Visible = false;
                lblBurnRate.Visible = false;
                numBurnTime.Visible = true;
                lblBurnTime.Visible = true;

                linkLiquidFuel.clear();
                numBurnRate.Value = 0;
                numMaxCharges.Value = 0;
            }
            else if (cboFuelType.SelectedItem.ToString() == FuelType.Liquid.ToString())
            {
                linkLiquidFuel.Visible = true;
                lblLiquidFuel.Visible = true;
                numMaxCharges.Visible = true;
                lblMaxCharges.Visible = true;
                numBurnRate.Visible = true;
                lblBurnRate.Visible = true;
                numBurnTime.Visible = false;
                lblBurnTime.Visible = false;

                numBurnTime.Value = 0;
            }
        }
    }
}
