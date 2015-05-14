using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.DAL.Interfaces;
using Realm.DAL.Models;
using Realm.Edit.Extensions;
using Realm.Library.Common;
using Realm.Library.Controls;

namespace Realm.Edit.EditorControls
{
    public partial class AbilityControl : BaseEditorControl
    {
        private int _tagSetId;

        public AbilityControl()
        {
            InitializeComponent();
            InitControls();
            Id = 0;
            Initializing = false;
        }

        public AbilityControl(int aClassId)
            : base(SystemTypes.Ability, aClassId)
        {
            InitializeComponent();
            InitControls();
            Id = 0;
            Initializing = false;
        }

        public override void InitTooltipsImpl()
        {
            base.InitTooltipsImpl();

            txtSystemName.SetTooltip("SystemName field is the internal name for the object.", false);
            txtDisplayName.SetTooltip("DisplayName field is the public name of the object.", false);
            txtDisplayDescription.SetTooltip("Description field is the public description of the object.", false);
        }

        private void InitControls()
        {
            cboOffensiveStat.Fill<Statistic>();
            cboDefensiveStat.Fill<Statistic>();
            lstAbilityTags.Fill("AbilityTags");

            InitAbilityEffectsGrid();
            InitAbilityPrerequisitesGrid();
        }

        private void InitAbilityEffectsGrid()
        {
            DataGridViewColumn column;

            {
                column = gridEffects.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>("Effect",
                    "Effect", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell) column.CellTemplate).SystemType = (short)SystemTypes.Effect;
            }

            {
                column =
                    gridEffects.CreateDataGridControls<DataGridViewComboBoxColumn, DataGridViewComboBoxCell>(
                        "TargetClassType", "Target Class Type", 25);
                if (column.CellTemplate is DataGridViewComboBoxCell)
                    ((DataGridViewComboBoxCell) column.CellTemplate).Fill<TargetClassTypes>();

                DataGridViewComboBoxColumn comboColumn = (DataGridViewComboBoxColumn) column;
                comboColumn.ValueMember = "Value";
                comboColumn.DisplayMember = "Name";
            }
        }

        private void InitAbilityPrerequisitesGrid()
        {
            DataGridViewColumn column;

            gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewNumericTextCell>(
                "MinLevel", "Min Level", 50);

            {
                column = gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>(
                    "Race", "Race", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell)column.CellTemplate).SystemType = (short)SystemTypes.Race;
            }

            {
                column = gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>(
                    "Faction", "Faction", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell)column.CellTemplate).SystemType = (short)SystemTypes.Faction;
            }

            gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewNumericTextCell>(
                "FactionLevel", "Min Faction", 50);

            {
                column = gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewComboBoxCell>(
                    "Statistic", "Statistic", 100);
                if (column.CellTemplate is DataGridViewComboBoxCell)
                    ((DataGridViewComboBoxCell)column.CellTemplate).Fill<Statistic>();
            }

            gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewNumericTextCell>(
               "StatisticValue", "Min Statistic", 50);

            {
                column = gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>(
                    "Skill", "Skill", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell) column.CellTemplate).SystemType = (short) SystemTypes.Skill;
            }

            gridPrerequisites.CreateDataGridControls<DataGridViewColumn, DataGridViewNumericTextCell>(
               "SkillValue", "Min Skill", 50);
        }

        // TODO: AbilityReagantMap (Item)
        // TODO: AbilityGuildMap (Flags?)

        public override void InitNewImpl()
        {
            cboOffensiveStat.Fill<Statistic>();
            cboDefensiveStat.Fill<Statistic>();
        }

        public override void MakeCopyImpl()
        {
            txtSystemName.Text = ControlName;
            Id = 0;
        }

        public override void InitContentImpl(int aId)
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var obj = (Ability)dbContext.GetPrimitive(SystemTypes.Ability, aId);

            txtSystemName.Text = obj.SystemName;
            txtDisplayName.Text = obj.DisplayName.Value;
            txtDisplayDescription.Text = obj.DisplayDescription.Value;
            numRechargeRate.Value = (decimal) obj.RechargeRate;
            numericUpDownPreDelay.Value = (decimal) obj.PreDelay;
            numericUpDownPostDelay.Value = (decimal) obj.PostDelay;
            numStaminaCost.Value = obj.StaminaCost;
            numManaCost.Value = obj.ManaCost;

            cboOffensiveStat.Fill<Statistic>((int)obj.OffensiveStat);
            cboDefensiveStat.Fill<Statistic>((int)obj.DefensiveStat);

            if (obj.Terrain != null)
                linkTerrain.Setup(SystemTypes.Terrain, obj.Terrain.Id);
            if (obj.InterruptionResistSkill != null)
                linkInterruptResist.Setup(SystemTypes.Skill, obj.InterruptionResistSkill.Id);
            if (obj.InterruptionEffect != null)
                linkInterruptEffect.Setup(SystemTypes.Effect, obj.InterruptionEffect.Id);

            PopulateCheckboxes(dbContext, obj);

            _tagSetId = obj.TagSet == null ? 0 : obj.TagSet.Id;
            if (_tagSetId > 0)
                lstAbilityTags.Fill("AbilityTags", _tagSetId);
            else 
                lstAbilityTags.Fill("AbilityTags");

            // TODO: Populate AbilityEffects
            // TODO: Populate AbilityPrerequisites
            // TODO: Populate AbilityReagants
            // TODO: Populate AbilityGuild

            ControlName = txtSystemName.Text;
        }

        private void PopulateCheckboxes(IRealmDbContext dbContext, Ability obj)
        {
            chkNotInterruptible.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits,
                "NotInterruptible");
            chkAutoAttack.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits, "AutoAttack");
            chkWeaponRequired.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits,
                "WeaponRequired");
            chkImplementRequired.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits,
                "ImplementRequired");
            chkVerbalRequired.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits, "VerbalRequired");
            chkPassive.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits, "Passive");
            chkTerrainRequired.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits,
                "TerrainRequired");
            chkNoCombatUse.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits, "NoCombatUse");
            chkSightRequired.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.AbilityBits, obj.Bits, "SightRequired");
        }

        public override bool SaveImpl()
        {
            try
            {
                IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var ability = (Ability)(Id == 0 ? new Ability() : dbContext.GetPrimitive(SystemTypes.Ability, Id));

                if (Id == 0)
                {
                    ability.SystemClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == ClassId);
                    dbContext.Abilities.Add(ability);
                }

                ability.SystemName = txtSystemName.Text;
                ability.DisplayName = SaveSystemString(dbContext, ability.DisplayName, txtDisplayName.Text);
                ability.DisplayDescription = SaveSystemString(dbContext, ability.DisplayDescription,
                    txtDisplayDescription.Text);

                ability.RechargeRate = (float)numRechargeRate.Value;
                ability.StaminaCost = (int)numStaminaCost.Value;
                ability.ManaCost = (int) numManaCost.Value;
                ability.PreDelay = (float) numericUpDownPreDelay.Value;
                ability.PostDelay = (float) numericUpDownPostDelay.Value;
                ability.OffensiveStat = (Statistic)EnumerationFunctions.GetEnumByName<Statistic>(cboOffensiveStat.Text);
                ability.DefensiveStat = (Statistic) EnumerationFunctions.GetEnumByName<Statistic>(cboDefensiveStat.Text);

                ability.InterruptionEffect = linkInterruptEffect.GetContentId() == 0
                    ? null
                    : dbContext.Effects.FirstOrDefault(x => x.Id == linkInterruptEffect.GetContentId());

                ability.InterruptionResistSkill = linkInterruptResist.GetContentId() == 0
                    ? null
                    : dbContext.Skills.FirstOrDefault(x => x.Id == linkInterruptResist.GetContentId());

                ability.Terrain = linkTerrain.GetContentId() == 0
                    ? null
                    : dbContext.Terrains.FirstOrDefault(x => x.Id == linkTerrain.GetContentId());

                int bits = (chkNotInterruptible.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "NotInterruptible") : 0);
                bits += (chkAutoAttack.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "AutoAttack") : 0);
                bits += (chkWeaponRequired.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "WeaponRequired") : 0);
                bits += (chkImplementRequired.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "ImplementRequired") : 0);
                bits += (chkVerbalRequired.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "VerbalRequired") : 0);
                bits += (chkPassive.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "Passive") : 0);
                bits += (chkTerrainRequired.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "TerrainRequired") : 0);
                bits += (chkNoCombatUse.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "NoCombatUse") : 0);
                bits += (chkSightRequired.Checked ? dbContext.GetBitValue(BitTypes.AbilityBits, "SightRequired") : 0);
                ability.Bits = bits;

                // todo tag set

                // TODO: Save AbilityEffects
                // TODO: Save AbilityPrerequisites
                // TODO: Save AbilityReagants
                // TODO: Save AbilityGuild

                dbContext.SaveChanges();

                Id = ability.Id;
                InitContent(Id);

                return true;
            }
            catch (DataException ex)
            {
                Program.Log.Error(string.Format("Error saving {0}", ControlName), ex);
                return false;
            }
            catch (Exception ex)
            {
                Program.Log.Error(ex);
                throw;
            }
        }

        public override bool IsSaveValid(bool aGiveFeedback)
        {
            int errors = txtDisplayName.ValidateField(() => txtDisplayName.Text.Length == 0, "Missing Display Name") ? 1 : 0;
            errors += txtSystemName.ValidateField(() => txtSystemName.Text.Length == 0, "Missing System Name") ? 1 : 0;
            errors += txtDisplayDescription.ValidateField(() => txtDisplayDescription.Text.Length == 0,
                "Missing Display Description") ? 1 : 0;
            if (chkTerrainRequired.Checked)
                errors += linkTerrain.ValidateField(() => string.IsNullOrEmpty(linkTerrain.Text), "Missing Terrain") ? 1 : 0;
            errors += chkAutoAttack.ValidateField(() => chkAutoAttack.Checked && chkPassive.Checked,
                "Cannot be Auto-Attack and Passive") ? 1 : 0;
            errors += chkAutoAttack.ValidateField(() => chkAutoAttack.Checked && chkNoCombatUse.Checked,
                "Cannot be Auto-Attack and No-Combat-Use") ? 1 : 0;

            return errors == 0;
        }

        private void ChkNotInterruptibleCheckedChanged(object sender, EventArgs e)
        {
            linkInterruptEffect.Enabled = !chkNotInterruptible.Checked;
            linkInterruptResist.Enabled = !chkNotInterruptible.Checked;
        }

        private void ChkTerrainRequiredCheckedChanged(object sender, EventArgs e)
        {
            linkTerrain.Enabled = !chkTerrainRequired.Checked;
        }
    }
}
