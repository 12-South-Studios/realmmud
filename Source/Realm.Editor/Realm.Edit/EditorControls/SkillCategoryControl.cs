using System;
using System.Drawing;
using System.Windows.Forms;
using Realm.Edit.Data;

namespace Realm.Edit.EditorControls
{
    // **************************************************
    // SkillCategoryControl
    // **************************************************
    public partial class SkillCategoryControl : BaseEditorControl
    {
        public SkillCategoryControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public SkillCategoryControl(int aClassId)
            : base(DataSystemType.SkillCategory, aClassId)
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
            ComboUtils.FillCombo(cboStatistics, statList, 0);
        }

        public override void InitNewImpl()
        {
            var statList = Program.RealmDal.GetStatistics();
            ComboUtils.FillCombo(cboStatistics, statList, 0);
        }

        public override void MakeCopyImpl()
        {
            txtSystemName.Text = ControlName;
            Id = 0;
        }

        public override void InitContentImpl(int aId)
        {
            var obj = Program.RealmDal.GetSkillCategory(aId);

            txtSystemName.Text = obj.SystemName;
            txtDisplayName.Text = obj.DisplayName;

            var statList = Program.RealmDal.GetStatistics();
            ComboUtils.FillCombo(cboStatistics, statList, obj.StatisticID);

            ControlName = txtSystemName.Text;
        }

        public override bool SaveImpl()
        {
            try
            {
                var obj = new SkillCategory
                {
                    SystemName = txtSystemName.Text,
                    DisplayName = txtDisplayName.Text,
                    StatisticID = GetComboContentId(cboStatistics)
                };

                if (Id > 0)
                {
                    obj.SkillCategoryID = Id;
                    if (!Program.RealmDal.UpdateSkillCategory(obj))
                        throw new Exception("Update " + ControlName + " Failure");
                }
                else
                {
                    var newId = Program.RealmDal.AddSkillCategory(ClassId, obj);
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
    // SkillCategoryBuilder
    // **************************************************
    public class SkillCategoryBuilder : EditorBuilder
    {
        public SkillCategoryBuilder()
            : base(DataSystemType.SkillCategory, "Skill Category", "Skill Categories")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.icons_ability_16.GetHicon());
        }

        public override BaseEditorControl Create(int aClassId)
        {
            return new SkillCategoryControl(aClassId);
        }

        public override int PopulateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return PopulateBrowseNodeImpl(aParentNode, aClassId, aMenu, aFilter);
        }

        protected override void DeleteImpl(int aId)
        {
            if (!Program.RealmDal.DeletePrimitive(aId))
            {
                Program.Log.ErrorFormat("Failed to Delete Skill Category {0}", aId);
                return;
            }
        }

        public override void Move(int aId, int aNewClassId)
        {
            MoveToClass(aId, aNewClassId);
        }

        public override string IdToText(object aId)
        {
            var obj = Program.RealmDal.GetSkillCategory((int)aId);
            return obj != null ? obj.SystemName : string.Empty;
        }

        public override EditorBrowseInfo GetBrowseInfo(int aId)
        {
            return GetSimpleBrowseInfo(aId);
        }
    }
}
