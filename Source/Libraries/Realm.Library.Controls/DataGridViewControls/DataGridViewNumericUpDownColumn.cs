using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Realm.Library.Controls.DataGridViewControls
{
    /// <summary>
    /// Custom column type dedicated to the DataGridViewNumericUpDownCell cell type.
    /// </summary>
    public class DataGridViewNumericUpDownColumn : DataGridViewColumn
    {
        /// <summary>
        /// Constructor for the DataGridViewNumericUpDownColumn class.
        /// </summary>
        public DataGridViewNumericUpDownColumn()
            : base(new DataGridViewNumericUpDownCell())
        {
        }

        /// <summary>
        /// Represents the implicit cell that gets cloned when adding rows to the grid.
        /// </summary>
        [
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                var dataGridViewNumericUpDownCell = value as DataGridViewNumericUpDownCell;
                if (value != null && dataGridViewNumericUpDownCell == null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Replicates the DecimalPlaces property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Appearance"),
            DefaultValue(DataGridViewNumericUpDownCell.DatagridviewnumericupdowncellDefaultDecimalPlaces),
            Description("Indicates the number of decimal places to display.")
        ]
        public int DecimalPlaces
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                return NumericUpDownCellTemplate.DecimalPlaces;
            }
            set
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");

                // Update the template cell so that subsequent cloned cells use the new value.
                NumericUpDownCellTemplate.DecimalPlaces = value;
                if (DataGridView == null) return;

                // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    // Be careful not to unshare rows unnecessarily.
                    // This could have severe performance repercussions.
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DataGridViewNumericUpDownCell;

                    // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation
                    // of each cell. The whole column is invalidated later in a single operation for better performance.
                    dataGridViewCell?.SetDecimalPlaces(rowIndex, value);
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
            }
        }

        /// <summary>
        /// Replicates the Increment property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the amount to increment or decrement on each button click.")
        ]
        public decimal Increment
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                return NumericUpDownCellTemplate.Increment;
            }
            set
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                NumericUpDownCellTemplate.Increment = value;
                if (DataGridView == null) return;

                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DataGridViewNumericUpDownCell;
                    dataGridViewCell?.SetIncrement(rowIndex, value);
                }
            }
        }

        /// Indicates whether the Increment property should be persisted.
        private bool ShouldSerializeIncrement()
        {
            return !Increment.Equals(DataGridViewNumericUpDownCell.DatagridviewnumericupdowncellDefaultIncrement);
        }

        /// <summary>
        /// Replicates the Maximum property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the maximum value for the numeric up-down cells."),
            RefreshProperties(RefreshProperties.All)
        ]
        public decimal Maximum
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                return NumericUpDownCellTemplate.Maximum;
            }
            set
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                NumericUpDownCellTemplate.Maximum = value;
                if (DataGridView == null) return;
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DataGridViewNumericUpDownCell;
                    dataGridViewCell?.SetMaximum(rowIndex, value);
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: This column and/or grid rows may need to be autosized depending on their
                //       autosize settings. Call the autosizing methods to autosize the column, rows,
                //       column headers / row headers as needed.
            }
        }

        /// Indicates whether the Maximum property should be persisted.
        private bool ShouldSerializeMaximum()
        {
            return !Maximum.Equals(DataGridViewNumericUpDownCell.DatagridviewnumericupdowncellDefaultMaximum);
        }

        /// <summary>
        /// Replicates the Minimum property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the minimum value for the numeric up-down cells."),
            RefreshProperties(RefreshProperties.All)
        ]
        public decimal Minimum
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                return NumericUpDownCellTemplate.Minimum;
            }
            set
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                NumericUpDownCellTemplate.Minimum = value;
                if (DataGridView == null) return;
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DataGridViewNumericUpDownCell;
                    dataGridViewCell?.SetMinimum(rowIndex, value);
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: This column and/or grid rows may need to be autosized depending on their
                //       autosize settings. Call the autosizing methods to autosize the column, rows,
                //       column headers / row headers as needed.
            }
        }

        /// Indicates whether the Maximum property should be persisted.
        private bool ShouldSerializeMinimum()
        {
            return !Minimum.Equals(DataGridViewNumericUpDownCell.DatagridviewnumericupdowncellDefaultMinimum);
        }

        /// <summary>
        /// Replicates the ThousandsSeparator property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            DefaultValue(DataGridViewNumericUpDownCell.DatagridviewnumericupdowncellDefaultThousandsSeparator),
            Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")
        ]
        public bool ThousandsSeparator
        {
            get
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                return NumericUpDownCellTemplate.ThousandsSeparator;
            }
            set
            {
                if (NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                NumericUpDownCellTemplate.ThousandsSeparator = value;
                if (DataGridView == null) return;
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DataGridViewNumericUpDownCell;
                    dataGridViewCell?.SetThousandsSeparator(rowIndex, value);
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: This column and/or grid rows may need to be autosized depending on their
                //       autosize settings. Call the autosizing methods to autosize the column, rows,
                //       column headers / row headers as needed.
            }
        }

        /// <summary>
        /// Small utility function that returns the template cell as a DataGridViewNumericUpDownCell
        /// </summary>
        private DataGridViewNumericUpDownCell NumericUpDownCellTemplate => (DataGridViewNumericUpDownCell)CellTemplate;

        /// <summary>
        /// Returns a standard compact string representation of the column.
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder(100);
            sb.Append("DataGridViewNumericUpDownColumn { Name=");
            sb.Append(Name);
            sb.Append(", Index=");
            sb.Append(Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
    }
}