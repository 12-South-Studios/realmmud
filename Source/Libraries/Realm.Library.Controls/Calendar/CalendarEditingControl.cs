using System;
using System.Windows.Forms;
using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Library.Controls
// ReSharper restore CheckNamespace
{
    /// <summary>
    ///
    /// </summary>
    internal class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        /// <summary>
        ///
        /// </summary>
        public CalendarEditingControl()
        {
            Format = DateTimePickerFormat.Short;
        }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
        /// </summary>
        public object EditingControlFormattedValue
        {
            get { return Value.ToShortDateString(); }
            set
            {
                var s = value as string;
                if (s.IsNotNull())
                    Value = DateTime.Parse(s);
            }
        }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        /// </summary>
        /// <param name="dataGridViewCellStyle"></param>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
        /// </summary>
        public int EditingControlRowIndex { get; set; }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.EditingControlWantsInputKey
        /// method. Let the DateTimePicker handle the keys listed.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataGridViewWantsInputKey"></param>
        /// <returns></returns>
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            bool returnVal = false;

            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    returnVal = true; break;
            }

            return returnVal;
        }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method
        /// </summary>
        /// <param name="selectAll"></param>
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
        /// </summary>
        public bool RepositionEditingControlOnValueChange { get { return false; } }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
        /// </summary>
        public DataGridView EditingControlDataGridView { get; set; }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
        /// </summary>
        public bool EditingControlValueChanged { get; set; }

        /// <summary>
        /// Implements the IDataGridViewEditingControl.EditingPanelCursor property.
        /// </summary>
        public Cursor EditingPanelCursor { get { return base.Cursor; } }

        /// <summary>
        /// Notify the DataGridView that the contents of the cell have changed.
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnValueChanged(EventArgs eventargs)
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}