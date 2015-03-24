using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class EffectHealthChangeControl : EffectSubControl
    {
        private int mEffectMapId;

        public EffectHealthChangeControl()
        {
            InitializeComponent();
            linkResistStat.SystemType = EditorSystemType.Statistic;
            linkOnFail.SystemType = EditorSystemType.Effect;
            linkOnResist.SystemType = EditorSystemType.Effect;
            ComboUtils.fillCombo(cboDamage, "ref_damage_type", "name", "ref_damage_type_id", 0);
        }

        public override void initNewImpl()
        {            
        }

        public override void loadEffectData(int aEffectDefId)
        {
            DataTable dt = Database.getData("effect_healthchange_map", "effect_def_id", aEffectDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mEffectMapId = (int)dataRow["effect_healthchange_map_id"];

            int healthChangeType = (int)dataRow["health_change_type_id"];
            if (healthChangeType == Globals.HEALTH_CHANGE_TYPE_Damage)
                rdoDamage.Checked = true;
            else if (healthChangeType == Globals.HEALTH_CHANGE_TYPE_Heal)
                rdoHeal.Checked = true;
            else if (healthChangeType == Globals.HEALTH_CHANGE_TYPE_Steal)
                rdoSteal.Checked = true;
            else
                rdoResurrect.Checked = true;

            numHealthMin.Value = Database.getNullableId(dataRow, "health_change_min");
            numHealthMax.Value = Database.getNullableId(dataRow, "health_change_max");
            numHealthBonus.Value = Database.getNullableId(dataRow, "health_change_bonus");

            EditorFactory.setupLink(linkResistStat, EditorSystemType.Statistic, Database.getNullableId(dataRow, "resist_statistic_def_id"));
            EditorFactory.setupLink(linkOnFail, EditorSystemType.Effect, Database.getNullableId(dataRow, "onfail_effect_def_id"));
            EditorFactory.setupLink(linkOnResist, EditorSystemType.Effect, Database.getNullableId(dataRow, "onresist_effect_def_id"));
            
            ComboUtils.fillCombo(cboDamage, "ref_damage_type", "name", "ref_damage_type_id", Database.getNullableId(dataRow, "ref_damage_type_id"));
            dt.Dispose();
        }

        public override bool isSaveValid(bool aGiveFeedback, Color aErrorColor)
        {
            if (numHealthMax.Value < numHealthMin.Value)
            {
                Program.MainForm.setStatusMessage("Max Health Change must be >= Min Health Change");
                numHealthMax.BackColor = Color.DarkRed;
                numHealthMin.BackColor = Color.DarkRed;
                return false;
            }
            else
            {
                numHealthMax.BackColor = Color.Empty;
                numHealthMin.BackColor = Color.Empty;
                numHealthBonus.BackColor = Color.Empty;
            }

            return true;
        }

        public override void preSaveEffectData(int aEffectDefId)
        {
        }

        public override void saveEffectData(int aDefId)
        {
            Database.deleteData("effect_healthchange_map", "effect_def_id", aDefId);

            mEffectMapId = Database.createData("effect_healthchange_map", "effect_def_id", aDefId, null, null);
            if (mEffectMapId == 0) throw new Exception("Failed to create new row in effect_healthchange_map");

            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "resist_statistic_def_id", BaseEditorControl.getContentLinkId(linkResistStat));
            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_min", (int)numHealthMin.Value);
            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_max", (int)numHealthMax.Value);
            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_bonus", (int)numHealthBonus.Value);

            if (rdoDamage.Checked)
                Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_type_id", Globals.HEALTH_CHANGE_TYPE_Damage);
            else if (rdoHeal.Checked)
                Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_type_id", Globals.HEALTH_CHANGE_TYPE_Heal);
            else if (rdoSteal.Checked)
                Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_type_id", Globals.HEALTH_CHANGE_TYPE_Steal);
            else
                Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "health_change_type_id", Globals.HEALTH_CHANGE_TYPE_Resurrect);

            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "onfail_effect_def_id", BaseEditorControl.getContentLinkId(linkOnFail));
            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "onresist_effect_def_id", BaseEditorControl.getContentLinkId(linkOnResist));
            Database.updateData("effect_healthchange_map", "effect_healthchange_map_id", mEffectMapId, "ref_damage_type_id", (cboDamage.SelectedItem as TagInfo).Id);
        }

        public override void preClearEffectData(int aDefId)
        {
            //Database.deleteData("effect_healthchange_map", "effect_def_id = " + aDefId);
            Database.deleteData("effect_healtchange_map", "effect_def_id", aDefId);
        }

        private void rdoDamage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDamage.Checked)
            {
                cboDamage.Enabled = true;
            }
            else
            {
                cboDamage.SelectedItem = null;
                cboDamage.Enabled = false;
            }
        }
    }
}
