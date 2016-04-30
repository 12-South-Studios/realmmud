using System;
using System.Windows.Forms;
using Realm.Library.Common.Objects;

namespace Realm.Library.Controls.Calendar

{
    /// <summary>
    ///
    /// </summary>
    public class CalendarCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CalendarCell()
        {
            Style.Format = "d";
        }

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

            var ctl = DataGridView.EditingControl as CalendarEditingControl;
            if (ctl.IsNotNull())
                // ReSharper disable PossibleNullReferenceException
                ctl.Value = (DateTime)Value;
            // ReSharper restore PossibleNullReferenceException
        }

        /// <summary>
        /// Gets type of the editing control that CalendarCell uses.
        /// </summary>
        public override Type EditType => typeof(CalendarEditingControl);

        /// <summary>
        /// Gets the type of the value that CalendarCell contains.
        /// </summary>
        public override Type ValueType => typeof(DateTime);

        /// <summary>
        /// Use the current date and time as the default value.
        /// </summary>
        public override object DefaultNewRowValue => DateTime.Now;
    }
}