﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;
using Realm.DAL.Models;
using Realm.Edit.Editor;
using Realm.Edit.Extensions;
using Realm.Library.Controls.DataGridViewControls;

namespace Realm.Edit.EditorControls
{
    public partial class MonthControl : BaseEditorControl
    {
        public MonthControl()
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public MonthControl(int classId)
            : base(SystemTypes.Month, classId)
        {
            InitializeComponent();
            InitControls();
            Id = 0;
        }

        public override void InitTooltipsImpl()
        {
            base.InitTooltipsImpl();

            txtSystemName.SetTooltip("SystemName field is the internal name for the object.", false);
            txtDisplayName.SetTooltip("DisplayName field is the public name of the object.", false);
        }

        private void InitControls()
        {
            cboSeasonTypes.Fill<SeasonTypes>();

            InitMonthEffectsGrid();
        }

        private void InitMonthEffectsGrid()
        {
            {
                var column = gridEffects.CreateDataGridControls<DataGridViewColumn, DataGridViewTypedLinkCell>(
                    "Effect", "Effect", 100);
                if (column.CellTemplate is DataGridViewTypedLinkCell)
                    ((DataGridViewTypedLinkCell)column.CellTemplate).SystemType = SystemTypes.Effect;
            }
        }

        public override void InitNewImpl()
        {
            cboSeasonTypes.Fill<SeasonTypes>();
        }

        public override void MakeCopyImpl()
        {
            txtSystemName.Text = ControlName;
            Id = 0;
        }

        public override void InitContentImpl(int id)
        {
            var dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var obj = (Month)dbContext.GetPrimitive(SystemTypes.Month, id);

            txtSystemName.Text = obj.SystemName;
            txtDisplayName.Text = obj.DisplayName;
            numNumberDays.Value = obj.NumberDays;
            chkIsShrouding.Checked = obj.IsShrouding;
            cboSeasonTypes.Fill<SeasonTypes>(obj.SeasonType);
            PopulateEffectsGrid(obj);;

            ControlName = txtSystemName.Text;
        }

        private void PopulateEffectsGrid(Month month)
        {
            foreach (var effect in month.Effects)
            {
                var row = new DataGridViewRow {Tag = effect};

                var cellEffect = row.Cells["Effect"] as DataGridViewLinkCell;
                cellEffect.Value = EditorFactory.GetBrowseInfo(SystemTypes.Effect, effect.Effect.Id);

                gridEffects.Rows.Add(row);
            }
        }

        public override bool SaveImpl()
        {
            try
            {
                var dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var month = (Month)(Id == 0 ? new Month() : dbContext.GetPrimitive(SystemTypes.Month, Id));

                if (Id == 0)
                {
                    month.SystemClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == ClassId);
                    dbContext.Months.Add(month);
                }

                month.SystemName = txtSystemName.Text;
                month.DisplayName = txtDisplayName.Text;
                month.NumberDays = Convert.ToInt32(numNumberDays.Value);
                month.IsShrouding = chkIsShrouding.Checked;

                // todo save effect grid

                dbContext.SaveChanges();

                Id = month.Id;
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

        public override bool IsSaveValid(bool giveFeedback)
        {
            int errors = txtDisplayName.ValidateField(() => txtDisplayName.Text.Length == 0, "Missing Display Name") ? 1 : 0;
            errors += txtSystemName.ValidateField(() => txtSystemName.Text.Length == 0, "Missing System Name") ? 1 : 0;

            return errors == 0;
        }
    }
}
