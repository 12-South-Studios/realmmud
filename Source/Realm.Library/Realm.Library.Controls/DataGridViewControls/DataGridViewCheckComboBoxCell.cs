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
    public class DataGridViewCheckComboBoxCell : DataGridViewComboBoxCell
    {
        /// <summary>
        ///
        /// </summary>
        public override Type EditType { get { return typeof(DataGridViewCheckComboBoxControl); } }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var cloned = base.Clone() as DataGridViewCheckComboBoxCell;
            if (cloned.IsNotNull())
            {
                // ReSharper disable PossibleNullReferenceException
                cloned.Items.Clear();
                // ReSharper restore PossibleNullReferenceException
                foreach (DataGridViewCheckComboBoxControl.CheckComboBoxItem item in Items)
                {
                    var copyItem = new DataGridViewCheckComboBoxControl.CheckComboBoxItem(item.Text, item.ID, item.CheckState);
                    cloned.Items.Add(copyItem);
                }
            }
            // ReSharper disable AssignNullToNotNullAttribute
            return cloned;
            // ReSharper restore AssignNullToNotNullAttribute
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