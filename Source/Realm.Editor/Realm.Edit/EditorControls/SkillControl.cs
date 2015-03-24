using System;
using System.Drawing;
using System.Windows.Forms;
using Realm.Edit.Data;
using Realm.Edit.Editor;

namespace Realm.Edit.EditorControls
{
    // **************************************************
    // SkillControl
    // **************************************************
    public partial class SkillControl : BaseEditorControl
    {
        public SkillControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public SkillControl(int aClassId)
            : base(DataSystemType.Skill, aClassId)
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public override void InitTooltipsImpl()
        {
            base.InitTooltipsImpl();

            SetTooltip(txtSystemName, "SystemName field is the internal name for the object.", false);
            SetTooltip(txtDisplayName, "DisplayName field is the public name of the object.", false);
        }

        private void InitControls()
        {
            var statList = Program.RealmDal.GetStatistics();
            ComboUtils.FillCombo(cboStatistic, statList, 0);
        }

        public override void InitNewImpl()
        {
            var statList = Program.RealmDal.GetStatistics();
            ComboUtils.FillCombo(cboStatistic, statList, 0);
        }

        public override void MakeCopyImpl()
        {
            txtSystemName.Text = ControlName;
            Id = 0;
        }

        public override void InitContentImpl(int aId)
        {
            var obj = Program.RealmDal.GetSkill(aId);

            txtSystemName.Text = obj.SystemName;
            txtDisplayName.Text = obj.DisplayName;
            txtDescription.Text = obj.DisplayDescription;

            numMaxValue.Value = obj.MaxValue;
            chkIsMasterable.Checked = obj.IsMasterable;

            var statList = Program.RealmDal.GetStatistics();
            ComboUtils.FillCombo(cboStatistic, statList, obj.StatisticID);

            EditorFactory.SetupLink(linkSkillCategory, DataSystemType.SkillCategory, obj.SkillCategoryID);
            EditorFactory.SetupLink(linkParentSkill, DataSystemType.Skill, obj.ParentSkillID.GetValueOrDefault(0));

            ControlName = txtSystemName.Text;
        }

        public override bool SaveImpl()
        {
            try
            {
                var obj = new Skill
                {
                    SystemName = txtSystemName.Text,
                    DisplayName = txtDisplayName.Text,
                    DisplayDescription = txtDescription.Text,
                    MaxValue = (int)numMaxValue.Value,
                    IsMasterable = chkIsMasterable.Checked,
                    StatisticID = GetComboContentId(cboStatistic),
                    SkillCategoryID = GetContentLinkId(linkSkillCategory),
                    ParentSkillID = GetContentLinkId(linkParentSkill)
                };

                if (Id > 0)
                {
                    obj.SkillID = Id;
                    if (!Program.RealmDal.UpdateSkill(obj))
                        throw new Exception("Update " + ControlName + " Failure");
                }
                else
                {
                    var newId = Program.RealmDal.AddSkill(ClassId, obj);
                    if (newId == 0)
                        throw new Exception("Add " + ControlName + " Failure");
                }

                InitContent(Id);
                return true;
            }
            catch (Exception ex)
            {
                Program.Log.ErrorFormat("Error saving {0}", ControlName);
                Program.Log.Error(ex);
                return false;
            }
        }

        public override bool IsSaveValid(bool aGiveFeedback)
        {
            var valid = true; // isDirty;
            var errorColor = Color.DarkRed;

            // Validate display name
            if (txtDisplayName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.SetWarningMessage("Missing Display Name");
                    txtDisplayName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtDisplayName.BackColor = Color.Empty;
            }

            // Validate system name
            if (txtSystemName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.SetWarningMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemName.BackColor = Color.Empty;
            }

            return valid;
        }
    }

    // **************************************************
    // SkillBuilder
    // **************************************************
    public class SkillBuilder : EditorBuilder
    {
        public SkillBuilder()
            : base(DataSystemType.Skill, "Skill", "Skills")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.icons_ability_16.GetHicon());
        }

        public override BaseEditorControl Create(int aClassId)
        {
            return new SkillControl(aClassId);
        }

        public override int PopulateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return PopulateBrowseNodeImpl(aParentNode, aClassId, aMenu, aFilter);
        }

        protected override void DeleteImpl(int aId)
        {
            if (!Program.RealmDal.DeletePrimitive(aId))
            {
                Program.Log.ErrorFormat("Failed to Delete Skill {0}", aId);
                return;
            }
        }

        public override void Move(int aId, int aNewClassId)
        {
            MoveToClass(aId, aNewClassId);
        }

        public override string IdToText(object aId)
        {
            var obj = Program.RealmDal.GetSkill((int)aId);
            return obj != null ? obj.SystemName : string.Empty;
        }

        public override EditorBrowseInfo GetBrowseInfo(int aId)
        {
            return GetSimpleBrowseInfo(aId);
        }
    }
}
