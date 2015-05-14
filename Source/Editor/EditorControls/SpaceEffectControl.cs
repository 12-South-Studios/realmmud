using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RealmEdit
{
    public partial class SpaceEffectControl : BaseEditorControl
    {
        public SpaceEffectControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public SpaceEffectControl(int aClassId)
            : base(EditorSystemType.SpaceEffect, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
            rdoDuration.Checked = true;
        }

        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "space_effect_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "space_effect_def", "display_name");

            linkSummoningNpc.SystemType = EditorSystemType.Npc;
            linkEffect.SystemType = EditorSystemType.Effect;
        }

        public override void initNewImpl()
        {
            ListUtils.fillCheckedFlags(lstMovementTypes, "MovementFlags", 0, null);    // Default to all selected
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("space_effect_def", "space_effect_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Space Effect [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Space Effect [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Space Effect loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            //TextBoxUtils.populateTextBox(txtDisplayName, dataRow, "display_name");
            txtDisplayName.Text = dataRow["display_name"].ToString();
            ListUtils.fillCheckedFlags(lstMovementTypes, "MovementFlags", (int)dataRow["movement_flags"], null);

            EditorFactory.setupLink(linkEffect, EditorSystemType.Effect, Database.getNullableId(dataRow, "effect_def_id"));

            int flags = (int)dataRow["flags"];
            chkOnEnter.Checked = (flags & Globals.SPACE_EFFECT_FLAG_OnEnter) != 0 ? true : false;
            chkOnTurn.Checked = (flags & Globals.SPACE_EFFECT_FLAG_OnTurn) != 0 ? true : false;

            int duration = (int)dataRow["duration"];
            if (duration <= 0)
                rdoDurationInstant.Checked = true;
            else
            {
                rdoDuration.Checked = true;
                numDuration.Value = duration;
            }

            // Populate the Remove/Cleanse effects

            // Summoning Details
            EditorFactory.setupLink(linkSummoningNpc, EditorSystemType.Npc, Database.getNullableId(dataRow, "summon_npc_def_id"));
            int summonQty = Database.getNullableId(dataRow, "summon_npc_quantity");
            if (summonQty < numSummoningQty.Minimum)
                numSummoningQty.Value = numSummoningQty.Minimum;
            else if (summonQty > numSummoningQty.Maximum)
                numSummoningQty.Value = numSummoningQty.Maximum;
            else
                numSummoningQty.Value = summonQty;

            dt.Dispose();
            ControlName = txtSystemName.Text;

        }

        public override bool saveImpl()
        {
            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("space_effect_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Space Effect Def");
                }
                else
                    Database.updateData("space_effect_def", "space_effect_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "duration", (int)numDuration.Value);
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "effect_def_id", getContentLinkId(linkEffect));
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "movement_flags", ListUtils.getCheckedFlags(lstMovementTypes));
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "summon_npc_def_id", getContentLinkId(linkSummoningNpc));
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "summon_npc_quantity", (int)numSummoningQty.Value);

                int flags =
                    (chkOnEnter.Checked ? Globals.SPACE_EFFECT_FLAG_OnEnter : 0) |
                    (chkOnTurn.Checked ? Globals.SPACE_EFFECT_FLAG_OnTurn : 0);
                Database.updateData("space_effect_def", "space_effect_def_id", Id, "flags", flags);
                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving space effect [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            bool valid = true; 
            Color errorColor = Color.DarkRed;

            if (txtSystemName.Text.Length <= 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                return false;
            }
            else
                txtSystemName.BackColor = Color.Empty;

            if (txtDisplayName.Text.Length <= 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Display Name");
                    txtDisplayName.BackColor = errorColor;
                }
                return false;
            }
            else
                txtDisplayName.BackColor = Color.Empty;

            if (ListUtils.getCheckedFlags(lstMovementTypes) == 0)
            {
                Program.MainForm.setStatusMessage("At least one movement type must be selected");
                lstMovementTypes.BackColor = errorColor;
            }
            else
                lstMovementTypes.BackColor = Color.Empty;

            return valid;
        }

        private void rdoDuration_CheckedChanged(object sender, EventArgs e)
        {
            numDuration.Enabled = rdoDuration.Checked;
        }

        private void chkOnEnter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnEnter.Checked && chkOnTurn.Checked)
                chkOnTurn.Checked = false;
        }

        private void chkOnTurn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnEnter.Checked && chkOnTurn.Checked)
                chkOnEnter.Checked = false;
        }
    }


    // **************************************************
    // SpaceEffectBuilder
    // **************************************************
    public class SpaceEffectBuilder : EditorBuilder
    {
        public SpaceEffectBuilder()
            : base(EditorSystemType.SpaceEffect, "Space Effect", "Space Effects")
        {
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new SpaceEffectControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "space_effect_def", "system_name", "class_id = " + aClassId, "space_effect_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            //Database.deleteData("space_effect_def", "space_effect_def_id = " + aId);
            Database.deleteData("space_effect_def", "space_effect_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("space_effect_def", "space_effect_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("space_effect_def", aId, "system_name").ToString();
            return Database.getData("space_effect_def", "space_effect_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("space_effect_def", aId, "system_name", "space_effect_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("space_effect_def");
        }

    }
}
