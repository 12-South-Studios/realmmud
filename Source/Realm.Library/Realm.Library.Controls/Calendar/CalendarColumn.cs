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
    public class CalendarColumn : DataGridViewColumn
    {
        /// <summary>
        ///
        /// </summary>
        public CalendarColumn()
            : base(new CalendarCell())
        {
        }

        /// <summary>
        /// Ensure that the cell used for the template is a CalendarCell.
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value.IsNotNull() && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                    throw new InvalidCastException("Must be a CalendarCell");

                base.CellTemplate = value;
            }
        }
    }
}