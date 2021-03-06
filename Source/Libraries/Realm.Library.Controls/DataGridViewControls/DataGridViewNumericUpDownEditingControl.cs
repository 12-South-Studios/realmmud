using System;
using System.Drawing;
using System.Windows.Forms;

namespace Realm.Library.Controls.DataGridViewControls
{
    /// <summary>
    /// Defines the editing control for the DataGridViewNumericUpDownCell custom cell type.
    /// </summary>
    internal class DataGridViewNumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        // Needed to forward keyboard messages to the child TextBox control.
        [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        // The grid that owns this editing control
        private DataGridView _dataGridView;

        // Stores whether the editing control's value has changed or not
        private bool _valueChanged;

        // Stores the row index in which the editing control resides

        /// <summary>
        /// Constructor of the editing control class
        /// </summary>
        public DataGridViewNumericUpDownEditingControl()
        {
            // The editing control must not be part of the tabbing loop
            TabStop = false;
        }

        // Beginning of the IDataGridViewEditingControl interface implementation

        /// <summary>
        /// Property which caches the grid that uses this editing control
        /// </summary>
        public virtual DataGridView EditingControlDataGridView
        {
            get { return _dataGridView; }
            set { _dataGridView = value; }
        }

        /// <summary>
        /// Property which represents the current formatted value of the editing control
        /// </summary>
        public virtual object EditingControlFormattedValue
        {
            get { return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting); }
            set { Text = (string) value; }
        }

        /// <summary>
        /// Property which represents the row in which the editing control resides
        /// </summary>
        public virtual int EditingControlRowIndex { get; set; }

        /// <summary>
        /// Property which indicates whether the value of the editing control has changed or not
        /// </summary>
        public virtual bool EditingControlValueChanged
        {
            get { return _valueChanged; }
            set { _valueChanged = value; }
        }

        /// <summary>
        /// Property which determines which cursor must be used for the editing panel,
        /// i.e. the parent of the editing control.
        /// </summary>
        public virtual Cursor EditingPanelCursor => Cursors.Default;

        /// <summary>
        /// Property which indicates whether the editing control needs to be repositioned
        /// when its value changes.
        /// </summary>
        public virtual bool RepositionEditingControlOnValueChange => false;

        /// <summary>
        /// Method called by the grid before the editing control is shown so it can adapt to the
        /// provided cell style.
        /// </summary>
        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            if (dataGridViewCellStyle.BackColor.A < 255)
            {
                // The NumericUpDown control does not support transparent back colors
                var opaqueBackColor = Color.FromArgb(255, dataGridViewCellStyle.BackColor);
                BackColor = opaqueBackColor;
                _dataGridView.EditingPanel.BackColor = opaqueBackColor;
            }
            else
            {
                BackColor = dataGridViewCellStyle.BackColor;
            }
            ForeColor = dataGridViewCellStyle.ForeColor;
            TextAlign = DataGridViewNumericUpDownCell.TranslateAlignment(dataGridViewCellStyle.Alignment);
        }

        private bool CheckTextBoxSelection(TextBox textBox, RightToLeft rightToLeft, int length, int start)
        {
            return RightToLeft == rightToLeft && !(textBox.SelectionLength == length && textBox.SelectionStart == start);
        }

        private bool HandleRightKey(TextBox textBox)
        {
            return textBox != null &&
                   (CheckTextBoxSelection(textBox, RightToLeft.No, 0, textBox.Text.Length)
                    || CheckTextBoxSelection(textBox, RightToLeft.Yes, 0, 0));
        }

        private bool HandleLeftKey(TextBox textBox)
        {
            return textBox != null &&
                   (CheckTextBoxSelection(textBox, RightToLeft.No, 0, 0)
                    || CheckTextBoxSelection(textBox, RightToLeft.Yes, 0, textBox.Text.Length));
        }

        /// <summary>
        /// Method called by the grid on keystrokes to determine if the editing control is
        /// interested in the key or not.
        /// </summary>
        public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            TextBox textBox;
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                    // If the end of the selection is at the end of the string, let the DataGridView treat the key message
                    textBox = Controls[1] as TextBox;
                    if (HandleRightKey(textBox))
                        return true;
                    break;

                case Keys.Left:
                    // If the end of the selection is at the beginning of the string or if the entire text is selected
                    // and we did not start editing, send this character to the dataGridView, else process the key message
                    textBox = Controls[1] as TextBox;
                    if (HandleLeftKey(textBox))
                        return true;
                    break;

                case Keys.Down:
                    // If the current value hasn't reached its minimum yet, handle the key. Otherwise let
                    // the grid handle it.
                    if (Value > Minimum)
                        return true;
                    break;

                case Keys.Up:
                    // If the current value hasn't reached its maximum yet, handle the key. Otherwise let
                    // the grid handle it.
                    if (Value < Maximum)
                        return true;
                    break;

                case Keys.Home:
                case Keys.End:
                    // Let the grid handle the key if the entire text is selected.
                    textBox = Controls[1] as TextBox;
                    if (textBox != null && textBox.SelectionLength != textBox.Text.Length)
                        return true;
                    break;

                case Keys.Delete:
                    // Let the grid handle the key we're at the end of the text.
                    textBox = Controls[1] as TextBox;
                    if (textBox != null && (textBox.SelectionLength > 0 ||
                                            textBox.SelectionStart < textBox.Text.Length))
                        return true;
                    break;
            }
            return !dataGridViewWantsInputKey;
        }

        /// <summary>
        /// Returns the current value of the editing control.
        /// </summary>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            var userEdit = UserEdit;
            try
            {
                // Prevent the Value from being set to Maximum or Minimum when the cell is being painted.
                UserEdit = (context & DataGridViewDataErrorContexts.Display) == 0;
                return Value.ToString((ThousandsSeparator ? "N" : "F") + DecimalPlaces);
            }
            finally
            {
                UserEdit = userEdit;
            }
        }

        /// <summary>
        /// Called by the grid to give the editing control a chance to prepare itself for
        /// the editing session.
        /// </summary>
        public virtual void PrepareEditingControlForEdit(bool selectAll)
        {
            var textBox = Controls[1] as TextBox;
            if (textBox == null) return;
            if (selectAll)
            {
                textBox.SelectAll();
            }
            else
            {
                // Do not select all the text, but
                // position the caret at the end of the text
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        // End of the IDataGridViewEditingControl interface implementation

        /// <summary>
        /// Small utility function that updates the local dirty state and
        /// notifies the grid of the value change.
        /// </summary>
        private void NotifyDataGridViewOfValueChange()
        {
            if (_valueChanged) return;
            _valueChanged = true;
            _dataGridView.NotifyCurrentCellDirty(true);
        }

        /// <summary>
        /// Listen to the KeyPress notification to know when the value changed, and
        /// notify the grid of the change.
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            // The value changes when a digit, the decimal separator, the group separator or
            // the negative sign is pressed.
            var notifyValueChange = false;
            if (char.IsDigit(e.KeyChar))
            {
                notifyValueChange = true;
            }
            else
            {
                var numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                var decimalSeparatorStr = numberFormatInfo.NumberDecimalSeparator;
                var groupSeparatorStr = numberFormatInfo.NumberGroupSeparator;
                var negativeSignStr = numberFormatInfo.NegativeSign;
                if (!string.IsNullOrEmpty(decimalSeparatorStr) && decimalSeparatorStr.Length == 1)
                {
                    notifyValueChange = decimalSeparatorStr[0] == e.KeyChar;
                }
                if (!notifyValueChange && !string.IsNullOrEmpty(groupSeparatorStr) && groupSeparatorStr.Length == 1)
                {
                    notifyValueChange = groupSeparatorStr[0] == e.KeyChar;
                }
                if (!notifyValueChange && !string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
                {
                    notifyValueChange = negativeSignStr[0] == e.KeyChar;
                }
            }

            if (notifyValueChange)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }

        /// <summary>
        /// Listen to the ValueChanged notification to forward the change to the grid.
        /// </summary>
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            if (Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }

        /// <summary>
        /// A few keyboard messages need to be forwarded to the inner textbox of the
        /// NumericUpDown control so that the first character pressed appears in it.
        /// </summary>
        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            var textBox = Controls[1] as TextBox;
            if (textBox == null) return base.ProcessKeyEventArgs(ref m);
            SendMessage(textBox.Handle, m.Msg, m.WParam, m.LParam);
            return true;
        }
    }
}