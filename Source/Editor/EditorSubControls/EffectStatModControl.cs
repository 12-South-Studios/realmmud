using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class EffectStatModControl : EffectSubControl
    {
        private int mEffectMapId;

        public EffectStatModControl()
        {
            InitializeComponent();
            linkStatAffected.SystemType = EditorSystemType.Statistic;
        }

        public override void initNewImpl()
        {            
        }

        public override void loadEffectData(int aEffectDefId)
        {
            DataTable dt = Database.getData("effect_statmod_map", "effect_def_id", aEffectDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mEffectMapId = (int)dataRow["effect_statmod_map_id"];
            EditorFactory.setupLink(linkStatAffected, EditorSystemType.Statistic, Database.getNullableId(dataRow, "stat_affected_def_id"));
            numStatMin.Value = Database.getNullableId(dataRow, "stat_change_min");
            numStatMax.Value = Database.getNullableId(dataRow, "stat_change_max");
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (numStatMin.Value > numStatMax.Value)
            {
                Program.MainForm.setStatusMessage("Min Stat Value must be <= Max Stat value");
                numStatMax.BackColor = Color.DarkRed;
                return false;
            }
            else
                numStatMax.BackColor = Color.Empty;

            return true;
        }

        public override void preSaveEffectData(int aEffectDefId)
        {
        }

        public override void saveEffectData(int aDefId)
        {
            Database.deleteData("effect_statmod_map", "effect_def_id", aDefId);

            mEffectMapId = Database.createData("effect_statmod_map", "effect_def_id", aDefId, null, null);
            if (mEffectMapId == 0) throw new Exception("Failed to create new row in effect_statmod_map");

            Database.updateData("effect_statmod_map", "effect_statmod_map_id", mEffectMapId, "stat_affected_def_id", BaseEditorControl.getContentLinkId(linkStatAffected));
            if (linkStatAffected.Text != "")
            {
                Database.updateData("effect_statmod_map", "effect_statmod_map_id", mEffectMapId, "stat_change_min", (int)numStatMin.Value);
                Database.updateData("effect_statmod_map", "effect_statmod_map_id", mEffectMapId, "stat_change_max", (int)numStatMax.Value);
            }
        }

        public override void preClearEffectData(int aDefId)
        {
            //Database.deleteData("effect_statmod_map", "effect_def_id = " + aDefId);
            Database.deleteData("effect_statmod_map", "effect_def_id", aDefId);
        }
    }
}
