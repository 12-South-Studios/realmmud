using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RealmEdit
{
    public partial class EffectGiveObjectControl : EffectSubControl
    {
        private int mEffectMapId;

        public EffectGiveObjectControl()
        {
            InitializeComponent();
            linkGive.SystemType = EditorSystemType.Ability;
        }

        public override void initNewImpl()
        {            
        }

        public override void loadEffectData(int aEffectDefId)
        {
            DataTable dt = Database.getData("effect_giveobject_map", "effect_def_id", aEffectDefId, null);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            DataRow dataRow = dt.Rows[0];

            mEffectMapId = (int)dataRow["effect_giveobject_map_id"];

            if (dataRow["give_ability_def_id"] != DBNull.Value)
            {
                radGiveAbility.Checked = true;
                lblGive.Text = "Ability";
                linkGive.SystemType = EditorSystemType.Ability;
                EditorFactory.setupLink(linkGive, EditorSystemType.Ability, Database.getNullableId(dataRow, "give_ability_def_id"));
            }
            else if (dataRow["give_statistic_def_id"] != DBNull.Value)
            {
                radGiveStat.Checked = true;
                lblGive.Text = "Skill";
                linkGive.SystemType = EditorSystemType.Statistic;
                EditorFactory.setupLink(linkGive, EditorSystemType.Statistic, Database.getNullableId(dataRow, "give_statistic_def_id"));
            }
            else if (dataRow["give_item_def_id"] != DBNull.Value)
            {
                radGiveItem.Checked = true;
                lblGive.Text = "Item";
                linkGive.SystemType = EditorSystemType.Item;
                EditorFactory.setupLink(linkGive, EditorSystemType.Item, Database.getNullableId(dataRow, "give_item_def_id"));
            }
            else if (dataRow["give_quest_def_id"] != DBNull.Value)
            {
                radGiveQuest.Checked = true;
                lblGive.Text = "Quest";
                linkGive.SystemType = EditorSystemType.Quest;
                EditorFactory.setupLink(linkGive, EditorSystemType.Quest, Database.getNullableId(dataRow, "give_quest_def_id"));
            }
            else if (dataRow["give_ritual_def_id"] != DBNull.Value)
            {
                radGiveRitual.Checked = true;
                lblGive.Text = "Ritual";
                linkGive.SystemType = EditorSystemType.Ritual;
                EditorFactory.setupLink(linkGive, EditorSystemType.Ritual, Database.getNullableId(dataRow, "give_ritual_def_id"));
            }
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
            Database.deleteData("effect_giveobject_map", "effect_def_id", aDefId);

            mEffectMapId = Database.createData("effect_giveobject_map", "effect_def_id", aDefId, null, null);
            if (mEffectMapId == 0) throw new Exception("Failed to create new row in effect_giveobject_map");

            if (radGiveAbility.Checked)
                Database.updateData("effect_giveobject_map", "effect_giveobject_map_id", mEffectMapId, "give_ability_def_id", BaseEditorControl.getContentLinkId(linkGive));
            else if (radGiveStat.Checked)
                Database.updateData("effect_giveobject_map", "effect_giveobject_map_id", mEffectMapId, "give_statistic_def_id", BaseEditorControl.getContentLinkId(linkGive));
            else if (radGiveItem.Checked)
                Database.updateData("effect_giveobject_map", "effect_giveobject_map_id", mEffectMapId, "give_item_def_id", BaseEditorControl.getContentLinkId(linkGive));
            else if (radGiveQuest.Checked)
                Database.updateData("effect_giveobject_map", "effect_giveobject_map_id", mEffectMapId, "give_quest_def_id", BaseEditorControl.getContentLinkId(linkGive));
            else if (radGiveRitual.Checked)
                Database.updateData("effect_giveobject_map", "effect_giveobject_map_id", mEffectMapId, "give_ritual_def_id", BaseEditorControl.getContentLinkId(linkGive));
        }

        public override void preClearEffectData(int aDefId)
        {
            //Database.deleteData("effect_giveobject_map", "effect_def_id = " + aDefId);
            Database.deleteData("effect_giveobject_map", "effect_def_id", aDefId);
        }

        private void radAbility_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiveAbility.Checked)
            {
                lblGive.Text = "Ability";
                linkGive.SystemType = EditorSystemType.Ability;
                linkGive.clear();
            }
            else if (radGiveStat.Checked)
            {
                lblGive.Text = "Skill";
                linkGive.SystemType = EditorSystemType.Statistic;
                linkGive.clear();
            }
            else if (radGiveItem.Checked)
            {
                lblGive.Text = "Item";
                linkGive.SystemType = EditorSystemType.Item;
                linkGive.clear();
            }
            else if (radGiveQuest.Checked)
            {
                lblGive.Text = "Quest";
                linkGive.SystemType = EditorSystemType.Quest;
                linkGive.clear();
            }
            else if (radGiveRitual.Checked)
            {
                lblGive.Text = "Ritual";
                linkGive.SystemType = EditorSystemType.Ritual;
                linkGive.clear();
            }
        }
    }
}
