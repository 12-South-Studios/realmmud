using System;
using System.Windows.Forms;
using Realm.Library.Controls.DataGridViewControls;

namespace Realm.Edit
{
    public partial class StringTable : Form
    {
        public static bool IsLoading;
        private StringValueTable _valueTable;

        public StringTable()
        {
            IsLoading = true;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewNumericTextCell cell = new DataGridViewNumericTextCell();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.Name = "string_id";
                col.HeaderText = "ID";
                col.CellTemplate = cell;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
                col.ReadOnly = true;
                stringValueGridView.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.Name = "string_name";
                col.HeaderText = "NAME";
                col.CellTemplate = cell;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
                col.ReadOnly = true;
                stringValueGridView.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                col.Name = "string";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 75;
                col.HeaderText = "Value";
                col.CellTemplate = cell;
                col.ReadOnly = false;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
                stringValueGridView.CurrentCellDirtyStateChanged += StringValueGridCurrentCellDirtyStateChanged;
                stringValueGridView.Columns.Add(col);
            }
        }

        protected void FillDataGrid()
        {
            stringValueGridView.Rows.Clear();
            stringValueGridView.SuspendLayout();
            _valueTable = new StringValueTable();
            Application.DoEvents();

            /*var constantList = _gameConstantDal.GetGameConstants().Where(x => x.ConstantId == 8);

            pbStatus.Minimum = 0;
            pbStatus.Value = 0;
            pbStatus.Maximum = constantList.Count();

            foreach (var constant in constantList)
            {
                var constantValue = _gameConstantDal.GetGameConstant(constant.ConstantId);
                string value = "Unlocalized";
                if (constantValue != null && !string.IsNullOrEmpty(constantValue.StringValue))
                    value = constantValue.StringValue;

                _valueTable.AddString(constant.ConstantId, value);
                Application.DoEvents();

                var gridIndex = stringValueGridView.Rows.Add();
                var gridRow = stringValueGridView.Rows[gridIndex];

                DataGridViewNumericTextCell cellId = gridRow.Cells["string_id"] as DataGridViewNumericTextCell;
                if (cellId != null)
                    cellId.Value = constant.ConstantId;

                DataGridViewTextBoxCell cellStat = gridRow.Cells["string_name"] as DataGridViewTextBoxCell;
                if (cellStat != null)
                    cellStat.Value = constant.;

                DataGridViewTextBoxCell cellVal = gridRow.Cells["string"] as DataGridViewTextBoxCell;
                if (cellVal != null)
                    cellVal.Value = value;

                {
                    if (cellStat != null)
                        cellStat.ToolTipText = constant.Description;
                    if (cellVal != null)
                        cellVal.ToolTipText = constant.Description;
                }

                gridRow.Tag = constant.RefGameConstantID;
                Application.DoEvents();
                pbStatus.Value++;
            }*/

            stringValueGridView.ResumeLayout();
        }

        protected void StringValueGridCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                stringValueGridView.CurrentCell.Tag = "Dirty";
            }
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            try
            {
                /*var constantRepo = (GameConstantRepository)Program.StaticContext.GetRepository("GAMECONSTANT");

                Application.DoEvents();
                pbStatus.Maximum = stringValueGridView.Rows.Count - 1;
                pbStatus.Minimum = 1;
                int count = 1;

                foreach (DataGridViewRow gridRow in stringValueGridView.Rows)
                {
                    Application.DoEvents();
                    if (gridRow == null || gridRow.Tag == null || gridRow.IsNewRow) continue;

                    var id = (int)gridRow.Tag;
                    if (stringValueGridView.IsDeleted(gridRow))
                    {
                        constantRepo.DeleteGameConstant(id);
                        continue;
                    }

                    var val = "None";
                    if (gridRow.Cells["string"].Value != null)
                        val = gridRow.Cells["string"].Value.ToString();

                    if (!constantRepo.UpdateGameConstant(id, null, null, val, null))
                    {
                        Program.Log.ErrorFormat("Failed to update Constant {0} with value {1}", id, val);
                        continue;
                    }

                    pbStatus.Value = count;
                    count++;
                }
                Program.StaticContext.Save();*/
            }
            catch (Exception ex)
            {
                Program.Log.Error(ex);
            }
            finally
            {
                Close();
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonReloadClick(object sender, EventArgs e)
        {
            stringValueGridView.Hide();
            FillDataGrid();
            stringValueGridView.Show();
        }

        private void StringTableShown(object sender, EventArgs e)
        {
            FillDataGrid();
            IsLoading = false;
        }
    }
}
