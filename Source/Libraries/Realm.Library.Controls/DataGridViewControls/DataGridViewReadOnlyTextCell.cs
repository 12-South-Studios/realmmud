using System.Windows.Forms;
using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Library.Controls
// ReSharper restore CheckNamespace
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

            if (txtEdit.IsNotNull())
                // ReSharper disable PossibleNullReferenceException
                txtEdit.Text = Value.IsNull() ? RowId.ToString() : Value.ToString();
            // ReSharper restore PossibleNullReferenceException
        }

        /// <summary>
        ///
        /// </summary>
        public int RowId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public override object DefaultNewRowValue { get { return -(RowId++); } }
    }
}