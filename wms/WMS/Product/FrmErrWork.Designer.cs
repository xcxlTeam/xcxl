namespace WMS.Product
{
    partial class FrmErrWork
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensButton3 = new ChensControl.ChensButton();
            this.chensButton2 = new ChensControl.ChensButton();
            this.chensTextBox1 = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.chensButton1 = new ChensControl.ChensButton();
            this.chensDataGridView5 = new ChensControl.ChensDataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensGroupBox7 = new ChensControl.ChensGroupBox();
            this.msMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.chensGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView5)).BeginInit();
            this.chensGroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClose});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 14;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiClose.Size = new System.Drawing.Size(44, 21);
            this.tsmiClose.Text = "关闭";
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 66);
            this.gbHeader.TabIndex = 21;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // txtWarehouseNo
            // 
            this.txtWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseNo.HotTrack = false;
            this.txtWarehouseNo.Location = new System.Drawing.Point(131, 23);
            this.txtWarehouseNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarehouseNo.Name = "txtWarehouseNo";
            this.txtWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWarehouseNo.TabIndex = 1;
            this.txtWarehouseNo.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(57, 25);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 9;
            this.chensLabel5.Text = "参数名称";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(913, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 29);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox1.Controls.Add(this.chensButton3);
            this.chensGroupBox1.Controls.Add(this.chensButton2);
            this.chensGroupBox1.Controls.Add(this.chensTextBox1);
            this.chensGroupBox1.Controls.Add(this.chensLabel1);
            this.chensGroupBox1.Controls.Add(this.chensButton1);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 91);
            this.chensGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensGroupBox1.Size = new System.Drawing.Size(992, 126);
            this.chensGroupBox1.TabIndex = 22;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询条件";
            // 
            // chensButton3
            // 
            this.chensButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chensButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton3.ForeColor = System.Drawing.Color.White;
            this.chensButton3.Location = new System.Drawing.Point(914, 47);
            this.chensButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensButton3.Name = "chensButton3";
            this.chensButton3.Size = new System.Drawing.Size(67, 29);
            this.chensButton3.TabIndex = 12;
            this.chensButton3.Text = "删除";
            this.chensButton3.UseVisualStyleBackColor = false;
            // 
            // chensButton2
            // 
            this.chensButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chensButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton2.ForeColor = System.Drawing.Color.White;
            this.chensButton2.Location = new System.Drawing.Point(716, 47);
            this.chensButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensButton2.Name = "chensButton2";
            this.chensButton2.Size = new System.Drawing.Size(67, 29);
            this.chensButton2.TabIndex = 11;
            this.chensButton2.Text = "添加";
            this.chensButton2.UseVisualStyleBackColor = false;
            // 
            // chensTextBox1
            // 
            this.chensTextBox1.BackColor = System.Drawing.Color.White;
            this.chensTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox1.HotTrack = false;
            this.chensTextBox1.Location = new System.Drawing.Point(131, 51);
            this.chensTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox1.Name = "chensTextBox1";
            this.chensTextBox1.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox1.TabIndex = 1;
            this.chensTextBox1.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(57, 53);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 9;
            this.chensLabel1.Text = "参数名称";
            // 
            // chensButton1
            // 
            this.chensButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chensButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton1.ForeColor = System.Drawing.Color.White;
            this.chensButton1.Location = new System.Drawing.Point(815, 47);
            this.chensButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensButton1.Name = "chensButton1";
            this.chensButton1.Size = new System.Drawing.Size(67, 29);
            this.chensButton1.TabIndex = 10;
            this.chensButton1.Text = "修改";
            this.chensButton1.UseVisualStyleBackColor = false;
            // 
            // chensDataGridView5
            // 
            this.chensDataGridView5.AllowUserToAddRows = false;
            this.chensDataGridView5.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.chensDataGridView5.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.chensDataGridView5.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.chensDataGridView5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chensDataGridView5.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chensDataGridView5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.chensDataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chensDataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.chensDataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensDataGridView5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.chensDataGridView5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensDataGridView5.GridColor = System.Drawing.Color.LightGray;
            this.chensDataGridView5.HaveCopyMenu = true;
            this.chensDataGridView5.Location = new System.Drawing.Point(3, 22);
            this.chensDataGridView5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensDataGridView5.Name = "chensDataGridView5";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chensDataGridView5.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.chensDataGridView5.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.chensDataGridView5.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.chensDataGridView5.RowTemplate.Height = 23;
            this.chensDataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chensDataGridView5.Size = new System.Drawing.Size(986, 528);
            this.chensDataGridView5.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "MaterialNo";
            this.dataGridViewTextBoxColumn15.HeaderText = "限值编号";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 150;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "参数名称";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 300;
            // 
            // chensGroupBox7
            // 
            this.chensGroupBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox7.Controls.Add(this.chensDataGridView5);
            this.chensGroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensGroupBox7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox7.Location = new System.Drawing.Point(0, 217);
            this.chensGroupBox7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.chensGroupBox7.Name = "chensGroupBox7";
            this.chensGroupBox7.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.chensGroupBox7.Size = new System.Drawing.Size(992, 556);
            this.chensGroupBox7.TabIndex = 23;
            this.chensGroupBox7.TabStop = false;
            this.chensGroupBox7.Text = "异常工艺操作列表";
            // 
            // FrmErrWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.chensGroupBox7);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Name = "FrmErrWork";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView5)).EndInit();
            this.chensGroupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensButton chensButton3;
        private ChensControl.ChensButton chensButton2;
        private ChensControl.ChensTextBox chensTextBox1;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensButton chensButton1;
        private ChensControl.ChensDataGridView chensDataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private ChensControl.ChensGroupBox chensGroupBox7;

    }
}
