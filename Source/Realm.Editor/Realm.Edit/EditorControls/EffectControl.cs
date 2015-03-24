using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace RealmEdit
{
    // **************************************************
    // EffectControl
    // **************************************************
    public partial class EffectControl : BaseEditorControl
    {
        private EffectHealthChangeControl mHealthChangeControl = new EffectHealthChangeControl();
        private EffectStatModControl mStatModControl = new EffectStatModControl();
        private EffectGiveObjectControl mGiveObjectControl = new EffectGiveObjectControl();
        private EffectSpaceEffectControl mSpaceEffectControl = new EffectSpaceEffectControl();
        private EffectChangePositionControl mChangePositionControl = new EffectChangePositionControl();

        private EffectSubControl mCurrentControl;

        // Matches static.ref_effect_type
        public enum EffectTypes
        {
            GiveObject      = 1,
            HealthChange    = 2,
            ChangePosition  = 3,
            SpaceEffect     = 4,
            StatMod         = 5
        }
        private EffectTypes mEffectType = EffectTypes.HealthChange;

        public EffectControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public EffectControl(int aClassId)
            : base(EditorSystemType.Effect, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "effect_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "effect_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "effect_def", "display_description");
            radInstant.Checked = true;

            ComboUtils.fillCombo(cboEffectType, "ref_effect_type", "name", "ref_effect_type_id", 0);
            cboEffectType.SelectedText = "Health Change";
        }


        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboEffectType, "ref_effect_type", "name", "ref_effect_type_id", 0);
            {
                mHealthChangeControl.initNewImpl();
                mStatModControl.initNewImpl();
                mGiveObjectControl.initNewImpl();
                mSpaceEffectControl.initNewImpl();
                mChangePositionControl.initNewImpl();
            }
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("effect_def", "effect_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Effect [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Effect [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Effect loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            int flags = (int)dataRow["flags"];
            chkIsFriendly.Checked = ((flags & Globals.EFFECT_FLAG_Friendly) != 0) ? true : false;
            ComboUtils.fillCombo(cboEffectType, "ref_effect_type", "name", "ref_effect_type_id", Database.getNullableId(dataRow, "ref_effect_type_id"));

            int duration = (int)dataRow["duration"];
            if (duration <= 0)
            {
                radInstant.Checked = true;
                numDuration.Enabled = false;
            }
            else
            {
                radDuration.Checked = true;
                numDuration.Enabled = true;
                numDuration.Value = duration;
            }

            dt.Dispose();
            ControlName = txtSystemName.Text;

            // Choose the proper sub-item type, load the data into all controls
            EffectTypes effectType = (EffectTypes)Database.getNullableId(dataRow, "ref_effect_type_id");
            switchEffectType(EffectTypes.HealthChange);
            switchEffectType(effectType);

            {
                mHealthChangeControl.loadEffectData(Id);
                mStatModControl.loadEffectData(Id);
                mGiveObjectControl.loadEffectData(Id);
                mSpaceEffectControl.loadEffectData(Id);
                mChangePositionControl.loadEffectData(Id);
            }
        }

        public override bool saveImpl()
        {
            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("effect_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Effect Def");
                }
                else
                    Database.updateData("effect_def", "effect_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("effect_def", "effect_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("effect_def", "effect_def_id", Id, "display_description", txtDisplayDescription.Text);

                mCurrentControl.preSaveEffectData(Id);

                int flags = (chkIsFriendly.Checked ? Globals.EFFECT_FLAG_Friendly : 0);
                Database.updateData("effect_def", "effect_def_id", Id, "flags", flags);

                // Save the duration
                if (radDuration.Checked)
                    Database.updateData("effect_def", "effect_def_id", Id, "duration", (int)numDuration.Value);
                else
                    Database.updateData("effect_def", "effect_def_id", Id, "duration", 0);
                Database.updateData("effect_def", "effect_def_id", Id, "ref_effect_type_id", (cboEffectType.SelectedItem as TagInfo).Id);

                // Invoke all the pre-clears, and then the save
                {
                    if (mHealthChangeControl != mCurrentControl) mHealthChangeControl.preClearEffectData(Id);
                    if (mStatModControl != mCurrentControl) mStatModControl.preClearEffectData(Id);
                    if (mGiveObjectControl != mCurrentControl) mGiveObjectControl.preClearEffectData(Id);
                    if (mSpaceEffectControl != mCurrentControl) mSpaceEffectControl.preClearEffectData(Id);
                    if (mChangePositionControl != mCurrentControl) mChangePositionControl.preClearEffectData(Id);
                    mCurrentControl.saveEffectData(Id);
                }

                // Invoke all the post saves
                {
                    mHealthChangeControl.postSaveEffectData(Id, mHealthChangeControl == mCurrentControl);
                    mStatModControl.postSaveEffectData(Id, mStatModControl == mCurrentControl);
                    mGiveObjectControl.postSaveEffectData(Id, mGiveObjectControl == mCurrentControl);
                    mSpaceEffectControl.postSaveEffectData(Id, mSpaceEffectControl == mCurrentControl);
                    mChangePositionControl.postSaveEffectData(Id, mChangePositionControl == mCurrentControl);
                }

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving effect [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            bool valid = true;
            Color errorColor = Color.DarkRed;

            // You cannot save an effect without choosing a type
            if (null == mCurrentControl)
            {
                valid = false;
                Program.MainForm.setStatusMessage("An effect type must be chosen");
                cboEffectType.BackColor = errorColor;
            }
            else
            {
                cboEffectType.BackColor = Color.Empty;
                valid &= mCurrentControl.isSaveValid(aGiveFeedback, errorColor);
            }

            // Validate system name
            if (txtSystemName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemName.BackColor = Color.Empty;
            }

            // Validate display name
            if (txtDisplayName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Display Name");
                    txtDisplayName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtDisplayName.BackColor = Color.Empty;
            }

            return valid;
        }

        private void switchEffectType(EffectTypes aNewType)
        {
            if (mCurrentControl != null)
            {
                mCurrentControl.Hide();
                panelEffectType.Controls.Remove(mCurrentControl);
            }

            mEffectType = aNewType;
            switch (aNewType)
            {
                case EffectTypes.HealthChange:
                    mHealthChangeControl.initNewImpl();
                    mCurrentControl = mHealthChangeControl; 
                    cboEffectType.SelectedText = "Health Change";
                    break;

                case EffectTypes.StatMod:
                    mStatModControl.initNewImpl();
                    mCurrentControl = mStatModControl; 
                    cboEffectType.SelectedText = "Statistic Mod";
                    break;
                case EffectTypes.GiveObject:
                    mGiveObjectControl.initNewImpl();
                    mCurrentControl = mGiveObjectControl; 
                    cboEffectType.SelectedText = "Give Object"; 
                    break;
                case EffectTypes.SpaceEffect:
                    mSpaceEffectControl.initNewImpl();
                    mCurrentControl = mSpaceEffectControl;
                    cboEffectType.SelectedText = "Space Effect";
                    break;
                case EffectTypes.ChangePosition:
                    mChangePositionControl.initNewImpl();
                    mCurrentControl = mChangePositionControl;
                    cboEffectType.SelectedText = "Change Position";
                    break;
                default:
                    mCurrentControl = null;
                    cboEffectType.SelectedText = "Health Change";
                    break;
            }

            if (mCurrentControl != null)
            {
                mCurrentControl.Dock = DockStyle.Fill;
                panelEffectType.Controls.Add(mCurrentControl);
                mCurrentControl.Show();
            }
        }

        private void onEffectTypeChanged(object sender, EventArgs e)
        {
            if (cboEffectType.SelectedItem == null)
                return;

            string selectedItem = cboEffectType.SelectedItem.ToString().Replace(" ", "");
            switchEffectType((EffectTypes)Enum.Parse(typeof(EffectTypes), selectedItem, true));
        }

        private void radDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (radDuration.Checked)
            {
                numDuration.Enabled = true;
            }
            else
            {
                numDuration.Enabled = false;
            }
        }
    }


    // **************************************************
    // EffectBuilder
    // **************************************************
    public class EffectBuilder : EditorBuilder
    {
        public EffectBuilder()
            : base(EditorSystemType.Effect, "Effect", "Effects")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new EffectControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "effect_def", "system_name", "class_id = " + aClassId, "effect_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            // Delete any residual rows in sub-item map tables
            {
                //Database.deleteData("effect_position_map", "effect_def_id = " + aId);
                Database.deleteData("effect_position_map", "effect_def_id", aId);
                //Database.deleteData("effect_healthchange_map", "effect_def_id = " + aId);
                Database.deleteData("effect_healthchange_map", "effect_def_id", aId);
                //Database.deleteData("effect_statmod_map", "effect_def_id = " + aId);
                Database.deleteData("effect_statmod_map", "effect_def_id", aId);
                //Database.deleteData("effect_giveobject_map", "effect_def_id = " + aId);
                Database.deleteData("effect_giveobject_map", "effect_def_id", aId);
                //Database.deleteData("effect_spaceeffect_map", "effect_def_id = " + aId);
                Database.deleteData("effect_spaceeffect_map", "effect_def_id", aId);
            }

            //Database.deleteData("effect_def", "effect_def_id = " + aId);
            Database.deleteData("effect_def", "effect_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("effect_def", "effect_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            //return Database.getData("effect_def", aId, "system_name").ToString();
            return Database.getData("effect_def", "effect_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("effect_def", aId, "system_name", "effect_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("effect_def");
        }

    }
}

