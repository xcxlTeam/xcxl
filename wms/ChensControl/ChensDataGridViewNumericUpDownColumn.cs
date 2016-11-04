﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ChensControl
{
    public class ChensDataGridViewNumericUpDownColumn: DataGridViewColumn
    {
        /// <summary>
        /// Constructor for the ChensDataGridViewNumericUpDownColumn class.
        /// </summary>
        public ChensDataGridViewNumericUpDownColumn() : base(new ChensDataGridViewNumericUpDownCell())
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
                ChensDataGridViewNumericUpDownCell dataGridViewNumericUpDownCell = value as ChensDataGridViewNumericUpDownCell;
                if (value != null && dataGridViewNumericUpDownCell == null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type DataGridViewNumericUpDownElements.ChensDataGridViewNumericUpDownCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Replicates the DecimalPlaces property of the ChensDataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Appearance"),
            DefaultValue(ChensDataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultDecimalPlaces),
            Description("Indicates the number of decimal places to display.")
        ]
        public int DecimalPlaces
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.DecimalPlaces;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                // Update the template cell so that subsequent cloned cells use the new value.
                this.NumericUpDownCellTemplate.DecimalPlaces = value;
                if (this.DataGridView != null)
                {
                    // Update all the existing ChensDataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        ChensDataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as ChensDataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetDecimalPlaces(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Replicates the Increment property of the ChensDataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the amount to increment or decrement on each button click.")
        ]
        public Decimal Increment
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.Increment;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.Increment = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        ChensDataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as ChensDataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetIncrement(rowIndex, value);
                        }
                    }
                }
            }
        }

        /// Indicates whether the Increment property should be persisted.
        private bool ShouldSerializeIncrement()
        {
            return !this.Increment.Equals(ChensDataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultIncrement);
        }

        /// <summary>
        /// Replicates the Maximum property of the ChensDataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the maximum value for the numeric up-down cells."),
            RefreshProperties(RefreshProperties.All)
        ]
        public Decimal Maximum
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.Maximum;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.Maximum = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        ChensDataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as ChensDataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetMaximum(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows, 
                    //       column headers / row headers as needed.
                }
            }
        }

        /// Indicates whether the Maximum property should be persisted.
        private bool ShouldSerializeMaximum()
        {
            return !this.Maximum.Equals(ChensDataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultMaximum);
        }

        /// <summary>
        /// Replicates the Minimum property of the ChensDataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the minimum value for the numeric up-down cells."),
            RefreshProperties(RefreshProperties.All)
        ]
        public Decimal Minimum
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.Minimum;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.Minimum = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        ChensDataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as ChensDataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetMinimum(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows, 
                    //       column headers / row headers as needed.
                }
            }
        }

        /// Indicates whether the Maximum property should be persisted.
        private bool ShouldSerializeMinimum()
        {
            return !this.Minimum.Equals(ChensDataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultMinimum);
        }

        /// <summary>
        /// Replicates the ThousandsSeparator property of the ChensDataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            DefaultValue(ChensDataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultThousandsSeparator),
            Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")
        ]
        public bool ThousandsSeparator
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.ThousandsSeparator;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.ThousandsSeparator = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        ChensDataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as ChensDataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetThousandsSeparator(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows, 
                    //       column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Small utility function that returns the template cell as a ChensDataGridViewNumericUpDownCell
        /// </summary>
        private ChensDataGridViewNumericUpDownCell NumericUpDownCellTemplate
        {
            get
            {
                return (ChensDataGridViewNumericUpDownCell)this.CellTemplate;
            }
        }

        /// <summary>
        /// Returns a standard compact string representation of the column.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append("ChensDataGridViewNumericUpDownColumn { Name=");
            sb.Append(this.Name);
            sb.Append(", Index=");
            sb.Append(this.Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
    }
}