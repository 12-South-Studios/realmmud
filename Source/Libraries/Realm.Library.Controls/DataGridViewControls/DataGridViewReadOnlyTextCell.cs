using System.Windows.Forms;

namespace Realm.Library.Controls.DataGridViewControls
{
    /// <summary>
    ///
    /// </summary>
    public class DataGridViewReadOnlyTextCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// Set the value of the editing control to the current cell value.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="initialFormattedValue"></param>
        /// <param name="dataGridViewCellStyle"></param>
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            var txtEdit = DataGridView.EditingControl as DataGridViewTextBoxEditingControl;

            RowId = 1;

            if (txtEdit != null)
                txtEdit.Text = Value?.ToString() ?? RowId.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        public int RowId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public override object DefaultNewRowValue => -RowId++;
    }
}