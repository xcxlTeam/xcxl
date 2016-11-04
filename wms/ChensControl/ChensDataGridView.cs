using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChensControl
{
    public class ChensDataGridView : System.Windows.Forms.DataGridView
    {
        private ContextMenuStrip cmsCopy;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tsmiCopyCell;
        private ToolStripMenuItem tsmiCopyRow;
        private ToolStripMenuItem tsmiCopyColumn;

        private DataGridViewCell copyCell;

        public ChensDataGridView()
        {
            this.Font = ControlCommon.GetDefaultFont();
            this.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridColor = System.Drawing.Color.LightGray;
            this.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersVisible = false;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AutoGenerateColumns = false;


            //this.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_CellMouseDown);

            InitializeComponent();
        }

        private bool mHaveCopyMenu = true;

        [System.ComponentModel.Description("是否带有复制快捷菜单")]
        public bool HaveCopyMenu
        {
            get { return mHaveCopyMenu; }
            set { mHaveCopyMenu = value; }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.components = new System.ComponentModel.Container();
            this.cmsCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsCopy
            // 
            this.cmsCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyCell,
            this.tsmiCopyRow,
            this.tsmiCopyColumn});
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.Size = new System.Drawing.Size(131, 70);
            // 
            // tsmiCopyCell
            // 
            this.tsmiCopyCell.Name = "tsmiCopyCell";
            this.tsmiCopyCell.Size = new System.Drawing.Size(130, 22);
            this.tsmiCopyCell.Text = "复制单元格";
            this.tsmiCopyCell.Click += new System.EventHandler(this.tsmiCopyCell_Click);
            // 
            // tsmiCopyRow
            // 
            this.tsmiCopyRow.Name = "tsmiCopyRow";
            this.tsmiCopyRow.Size = new System.Drawing.Size(130, 22);
            this.tsmiCopyRow.Text = "复制行";
            this.tsmiCopyRow.Click += new System.EventHandler(this.tsmiCopyRow_Click);
            // 
            // tsmiCopyColumn
            // 
            this.tsmiCopyColumn.Name = "tsmiCopyColumn";
            this.tsmiCopyColumn.Size = new System.Drawing.Size(130, 22);
            this.tsmiCopyColumn.Text = "复制列";
            this.tsmiCopyColumn.Click += new System.EventHandler(this.tsmiCopyColumn_Click);
            // 
            // ChensDataGridView
            // 
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.RowTemplate.Height = 23;
            this.cmsCopy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }


        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击复制
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell cell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell == null || cell.Value == null) return;
            string strText = cell.Value.ToString().Trim();
            if (string.IsNullOrEmpty(strText)) return;
            Clipboard.Clear();
            Clipboard.SetDataObject(strText, false, 3, 100);
        }
        private void dgv_CellMouseDown(object sender, MouseEventArgs e)
        {
            //右键复制
            if (e.Button == MouseButtons.Right)
            {
                if (!mHaveCopyMenu) return;
                if (this.DataSource == null) return;
                if (this.Rows == null || this.Rows.Count <= 0 || this.RowCount <= 0) return;
                if (this.Columns == null || this.Columns.Count <= 0 || this.ColumnCount <= 0) return;
                DataGridView.HitTestInfo info = this.HitTest(e.X, e.Y);
                if (info.RowIndex < 0 || info.ColumnIndex < 0) return;

                copyCell = this.CurrentCell = this[info.ColumnIndex, info.RowIndex];
                copyCell.ContextMenuStrip = cmsCopy;
            }
        }

        private void tsmiCopyCell_Click(object sender, EventArgs e)
        {
            //复制单元格
            if (copyCell == null) return;
            string strContext = copyCell.Value == null ? this.Columns[copyCell.ColumnIndex].DefaultCellStyle.NullValue.ToString() : copyCell.Value.ToString();
            if (string.IsNullOrEmpty(strContext)) return;

            Clipboard.Clear();
            Clipboard.SetDataObject(strContext, false, 3, 100);
        }

        private void tsmiCopyRow_Click(object sender, EventArgs e)
        {
            //复制行
            if (copyCell == null) return;

            StringBuilder sbContext = new StringBuilder();
            foreach (DataGridViewColumn col in this.Columns)
            {
                if (!col.Visible) continue;
                sbContext.AppendFormat("{0}\t", this[col.Index, copyCell.RowIndex].Value == null ? col.DefaultCellStyle.NullValue : this[col.Index, copyCell.RowIndex].Value);
            }
            string strContext = sbContext.ToString();
            if (string.IsNullOrEmpty(strContext)) return;

            Clipboard.Clear();
            Clipboard.SetDataObject(strContext, false, 3, 100);
        }

        private void tsmiCopyColumn_Click(object sender, EventArgs e)
        {
            //复制列
            if (copyCell == null) return;

            StringBuilder sbContext = new StringBuilder();
            sbContext.AppendFormat("{0}{1}", this.Columns[copyCell.ColumnIndex].HeaderText, Environment.NewLine);
            foreach (DataGridViewRow row in this.Rows)
            {
                sbContext.AppendFormat("{0}{1}", this[copyCell.ColumnIndex, row.Index].Value, Environment.NewLine);
            }
            string strContext = sbContext.ToString();
            if (string.IsNullOrEmpty(strContext)) return;

            Clipboard.Clear();
            Clipboard.SetDataObject(strContext, false, 3, 100);
        }
    }
}
