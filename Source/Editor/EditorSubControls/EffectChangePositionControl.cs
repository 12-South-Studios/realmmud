using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class EffectChangePositionControl : EffectSubControl
    {
        private int mEffectMapId;

        public EffectChangePositionControl()
        {
            InitializeComponent();

        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboPosition, "ref_position", "name", "ref_position_id", 0);
        }

        public override void loadEffectData(int aEffectDefId)
        {
            DataTable dt = Database.getData("effect_position_map", "effect_def_id", aEffectDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mEffectMapId = (int)dataRow["effect_position_map_id"];
            ComboUtils.fillCombo(cboPosition, "ref_position", "name", "ref_position_id", (int)dataRow["ref_position_id"]);
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            return true;
        }

        public override void preSaveEffectData(int aEffectDefId)
        {
        }

        public override void saveEffectData(int aDefId)
        {
            //Database.deleteData("effect_position_map", "effect_def_id = " + aDefId);
            Database.deleteData("effect_position_map", "effect_def_id", aDefId);

            mEffectMapId = Database.createData("effect_position_map", "effect_def_id", aDefId, null, null);
            if (mEffectMapId == 0) throw new Exception("Failed to create new row in effect_position_map");

            Database.updateData("effect_position_map", "effect_position_map_id", mEffectMapId, "ref_position_id", (cboPosition.SelectedItem as TagInfo).Id);
        }

        public override void preClearEffectData(int aDefId)
        {
            //Database.deleteData("effect_position_map", "effect_def_id = " + aDefId);
            Database.deleteData("effect_position_map", "effect_def_id", aDefId);
        }
    }
}

