using System;
using System.Windows.Forms;

namespace Realm.Library.Controls.DataGridViewControls
{
    /// <summary>
    ///
    /// </summary>
    public class DataGridViewCheckComboBoxCell : DataGridViewComboBoxCell
    {
        /// <summary>
        ///
        /// </summary>
        public override Type EditType => typeof(DataGridViewCheckComboBoxControl);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var cloned = base.Clone() as DataGridViewCheckComboBoxCell;
            if (cloned == null) return cloned;

            cloned.Items.Clear();
            foreach (DataGridViewCheckComboBoxControl.CheckComboBoxItem item in Items)
            {
                var copyItem = new DataGridViewCheckComboBoxControl.CheckComboBoxItem(item.Text, item.ID, item.CheckState);
                cloned.Items.Add(copyItem);
            }
            return cloned;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellStyle"></param>
        /// <param name="valueTypeConverter"></param>
        /// <param name="formattedValueTypeConverter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override object GetFormattedValue(object value, int rowIndex,
            ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter,
            System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return "Select Tags";
        }
    }
}