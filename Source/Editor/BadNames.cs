using System;
using System.Linq;
using System.Windows.Forms;
using Realm.Admin.DAL;
using Realm.Admin.DAL.Models;
using Realm.Edit.Extensions;
using Realm.Edit.Properties;

namespace Realm.Edit
{
    public partial class BadNames : BaseEditorForm
    {
        private readonly IRealmAdminDbContext _realmDbContext;

        public BadNames(IRealmAdminDbContext dbContext)
        {
            _realmDbContext = dbContext;
            InitializeComponent();
            Init();
            FillDataGrid();
        }

        private void Init()
        {
            gridBadNames.CreateDataGridControls<DataGridViewColumn, DataGridViewTextBoxCell>("value",
                Resources.BADNAME_COL_INVALIDNAME, 75);
            gridBadNames.CreateDataGridControls<DataGridViewCheckBoxColumn, DataGridViewCheckBoxCell>("is_profanity", Resources.BADNAME_COL_PROFANITY);
            gridBadNames.CreateDataGridControls<DataGridViewCheckBoxColumn, DataGridViewCheckBoxCell>("is_reserved", Resources.BADNAME_COL_RESERVED);
            gridBadNames.CreateDataGridControls<DataGridViewCheckBoxColumn, DataGridViewCheckBoxCell>("is_copyright", Resources.BADNAME_COL_COPYRIGHT);
            gridBadNames.CreateDataGridControls<DataGridViewCheckBoxColumn, DataGridViewCheckBoxCell>("is_regex", Resources.BADNAME_COL_REGEX);
        }

        private void FillDataGrid()
        {
            gridBadNames.Rows.Clear();

            var nameList = _realmDbContext.RestrictedNames.ToList();
            foreach (var name in nameList)
            {
                var gridIndex = gridBadNames.Rows.Add();
                var gridRow = gridBadNames.Rows[gridIndex];

                var cellName = gridRow.Cells["value"] as DataGridViewTextBoxCell;
                if (cellName == null) continue;
                cellName.Value = name.Value;

                var cellIsReserved = gridRow.Cells["is_reserved"] as DataGridViewCheckBoxCell;
                if (cellIsReserved == null) continue;
                cellIsReserved.Value = name.IsReserved;

                var cellIsCopyright = gridRow.Cells["is_copyright"] as DataGridViewCheckBoxCell;
                if (cellIsCopyright == null) continue;
                cellIsCopyright.Value = name.IsCopyright;

                var cellIsProfanity = gridRow.Cells["is_profanity"] as DataGridViewCheckBoxCell;
                if (cellIsProfanity == null) continue;
                cellIsProfanity.Value = name.IsProfanity;

                var cellIsRegex = gridRow.Cells["is_regex"] as DataGridViewCheckBoxCell;
                if (cellIsRegex == null) continue;
                cellIsRegex.Value = name.IsRegex;

                gridRow.Tag = name.Id;
            }
        }

        private void RemoveDeletedRows()
        {
            var deletedRows = gridBadNames.DeletedRows;
            if (!deletedRows.Any()) return;
            
            pbStatus.Maximum = deletedRows.Count < 2 ? 1 : deletedRows.Count - 1;
            pbStatus.Minimum = 1;
            int count = 1;

            foreach (var id in deletedRows.Select(row => row.Tag != null
                                                                ? (int)row.Tag
                                                                : 0).Where(id => id != 0))
            {
                var name = _realmDbContext.RestrictedNames.FirstOrDefault(x => x.Id == id);
                if (name == null) continue;
                
                _realmDbContext.RestrictedNames.Remove(name);
                pbStatus.Value = count;
                count++;
            }

            _realmDbContext.SaveChanges();
            gridBadNames.FlushDeletedRows();   
        }

        private void AddOrUpdateNewRows()
        {
            pbStatus.Maximum = gridBadNames.Rows.Count - 1;
            pbStatus.Minimum = 1;
            int count = 1;

            foreach (DataGridViewRow gridRow in gridBadNames.Rows)
            {
                if (gridRow.IsNewRow) continue;

                var id = gridRow.Tag != null ? (int)gridRow.Tag : 0;

                var cellName = gridRow.Cells["value"] as DataGridViewTextBoxCell;
                if (cellName == null || cellName.Value == null) continue;

                var cellIsReserved = gridRow.Cells["is_reserved"] as DataGridViewCheckBoxCell;
                if (cellIsReserved == null) continue;
                var isReserved = cellIsReserved.Value != null && (bool)cellIsReserved.Value;

                var cellIsCopyright = gridRow.Cells["is_copyright"] as DataGridViewCheckBoxCell;
                if (cellIsCopyright == null) continue;
                var isCopyright = cellIsCopyright.Value != null && (bool)cellIsCopyright.Value;

                var cellIsProfanity = gridRow.Cells["is_profanity"] as DataGridViewCheckBoxCell;
                if (cellIsProfanity == null) continue;
                var isProfanity = cellIsProfanity.Value != null && (bool)cellIsProfanity.Value;

                var cellIsRegex = gridRow.Cells["is_regex"] as DataGridViewCheckBoxCell;
                if (cellIsRegex == null) continue;
                var isRegex = cellIsRegex.Value != null && (bool)cellIsRegex.Value;

                var name = id == 0
                    ? new RestrictedName()
                    : _realmDbContext.RestrictedNames.FirstOrDefault(x => x.Id == id);

                if (id == 0)
                    _realmDbContext.RestrictedNames.Add(name);

                name.Value = cellName.Value.ToString();
                name.IsReserved = isReserved;
                name.IsCopyright = isCopyright;
                name.IsProfanity = isProfanity;
                name.IsRegex = isRegex;

                _realmDbContext.SaveChanges();

                gridRow.Tag = name.Id;

                pbStatus.Value = count;
                count++;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            RemoveDeletedRows();
            AddOrUpdateNewRows();

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
