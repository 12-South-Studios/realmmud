using System.Windows.Forms;
using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Library.Controls
// ReSharper restore CheckNamespace
{
    /// <summary>
    ///
    /// </summary>
    public class DataGridViewNumericTextCell : DataGridViewTextBoxCell
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="initialFormattedValue"></param>
        /// <param name="dataGridViewCellStyle"></param>
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            if (rowIndex == -1) return;

            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            var txtEdit = DataGridView.EditingControl as DataGridViewTextBoxEditingControl;
            if (txtEdit.IsNull()) return;

            // ReSharper disable PossibleNullReferenceException
            txtEdit.KeyPress += TxtEditKeyPress;
            // ReSharper restore PossibleNullReferenceException
            txtEdit.Text = Value.IsNull() ? string.Empty : Value.ToString();
        }

        /// <summary>
        /// Only allow numbers to be entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TxtEditKeyPress(object sender, KeyPressEventArgs e)
        {
            if ("-0123456789\b".IndexOf(e.KeyChar) == -1)
                e.Handled = true;
        }

        /// <summary>
        ///
        /// </summary>
        public override object DefaultNewRowValue { get { return 0; } }
    }
}