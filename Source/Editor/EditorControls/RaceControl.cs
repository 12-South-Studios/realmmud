using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.DAL.Models;
using Realm.Edit.Extensions;
using Realm.Library.Common;
using Realm.Library.Controls.DataGridViewControls;

namespace Realm.Edit.EditorControls
{
    public partial class RaceControl : BaseEditorControl
    {
        public RaceControl()
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public RaceControl(int aClassId)
            : base(SystemTypes.Race, aClassId)
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        private void InitControls()
        {
            InitStatModsGrid();
            InitAbilitiesGrid();
            InitHitLocationsGrid();
        }

        private void InitStatModsGrid()
        {
            {
                DataGridViewColumn column = gridStatMods.CreateDataGridControls<DataGridViewComboBoxColumn, DataGridViewComboBoxCell>(
                    "Statistic", "Statistic", 50);
                if (column.CellTemplate is DataGridViewComboBoxCell)
                    ((DataGridViewComboBoxCell)column.CellTemplate).Fill<Statistic>();

                DataGridViewComboBoxColumn comboColumn = (DataGridViewComboBoxColumn)column;
                comboColumn.ValueMember = "Value";
                comboColumn.DisplayMember = "Name";
            }

            gridStatMods.CreateDataGridControls<DataGridViewColumn, DataGridViewNumericTextCell>(
                "StatMod", "Value Change", 50);
        }

        private void InitAbilitiesGrid()
        {
            {
                DataGridViewColumn column = gridAbilities.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>(
                    "Ability", "Ability", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell)column.CellTemplate).SystemType = (short)SystemTypes.Ability;
            }
        }

        private void InitHitLocationsGrid()
        {
            {
                DataGridViewColumn column = gridHitLocations.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>(
                    "HitLocation", "Hit Location", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell)column.CellTemplate).SystemType = (short)SystemTypes.WearLocation;
            }
        }

        public override void InitNewImpl()
        {
            cboSize.Fill<SizeTypes>();
        }

        public override void MakeCopyImpl()
        {
            txtSystemName.Text = ControlName;
            Id = 0;
        }

        public override void InitContentImpl(int aId)
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var obj = (Race)dbContext.GetPrimitive(SystemTypes.Race, aId);

            txtSystemName.Text = obj.SystemName;
            txtDisplayName.Text = obj.DisplayName;
            txtDisplayDescription.Text = obj.DisplayDescription;
            txtAbbreviation.Text = obj.Abbreviation;
            cboSize.Fill<SizeTypes>((int)obj.SizeType);
            chkPlayerRace.Checked = dbContext.DoesPrimitiveHaveBit(BitTypes.RaceBits, obj.Bits,
                "PlayerRace");

            // todo stat mod grid
            // todo ability grid
            // todo hit location grid

            ControlName = txtSystemName.Text;
        }

        public override bool SaveImpl()
        {
            try
            {
                IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var race = (Race) (Id == 0 ? new Race() : dbContext.GetPrimitive(SystemTypes.Race, Id));

                if (Id == 0)
                {
                    race.SystemClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == ClassId);
                    dbContext.Races.Add(race);
                }

                race.SystemName = txtSystemName.Text;
                race.DisplayName = txtDisplayName.Text;
                race.DisplayDescription = txtDisplayDescription.Text;
                race.Abbreviation = txtAbbreviation.Text;
                race.SizeType = (SizeTypes)EnumerationFunctions.GetEnumByName<SizeTypes>(cboSize.Text);
                
                int bits = chkPlayerRace.Checked ? dbContext.GetBitValue(BitTypes.RaceBits, "PlayerRace") : 0;
                race.Bits = bits;

                // todo stat mod grid
                // todo ability grid
                // todo hit location grid

                dbContext.SaveChanges();

                Id = race.Id;
                InitContent(Id);

                return true;
            }
            catch (DataException ex)
            {
                Program.Log.Error($"Error saving {ControlName}", ex);
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
            return errors == 0;
        }
    }
}
