namespace WMS.Print
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chensMenuStrip1 = new ChensControl.ChensMenuStrip();
            this.生成下架任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印报废拣货单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置打印机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensDataGridView2 = new ChensControl.ChensDataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new ChensControl.ChensButton();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.chensDataGridView1 = new ChensControl.ChensDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensMenuStrip1.SuspendLayout();
            this.chensGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView2)).BeginInit();
            this.chensGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成下架任务ToolStripMenuItem,
            this.打印报废拣货单ToolStripMenuItem,
            this.设置打印机ToolStripMenuItem});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(992, 25);
            this.chensMenuStrip1.TabIndex = 0;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // 生成下架任务ToolStripMenuItem
            // 
            this.生成下架任务ToolStripMenuItem.Name = "生成下架任务ToolStripMenuItem";
            this.生成下架任务ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.生成下架任务ToolStripMenuItem.Text = "生成下架任务";
            // 
            // 打印报废拣货单ToolStripMenuItem
            // 
            this.打印报废拣货单ToolStripMenuItem.Name = "打印报废拣货单ToolStripMenuItem";
            this.打印报废拣货单ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.打印报废拣货单ToolStripMenuItem.Text = "打印报废拣货单";
            // 
            // 设置打印机ToolStripMenuItem
            // 
            this.设置打印机ToolStripMenuItem.Name = "设置打印机ToolStripMenuItem";
            this.设置打印机ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.设置打印机ToolStripMenuItem.Text = "设置打印机";
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.Controls.Add(this.chensLabel3);
            this.chensGroupBox1.Controls.Add(this.dtpEndTime);
            this.chensGroupBox1.Controls.Add(this.dtpStartTime);
            this.chensGroupBox1.Controls.Add(this.chensLabel2);
            this.chensGroupBox1.Controls.Add(this.chensDataGridView2);
            this.chensGroupBox1.Controls.Add(this.btnSearch);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 25);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(992, 112);
            this.chensGroupBox1.TabIndex = 1;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询条件";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(195, 28);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(20, 17);
            this.chensLabel3.TabIndex = 53;
            this.chensLabel3.Text = "至";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(221, 26);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 52;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(39, 26);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 51;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(4, 28);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(32, 17);
            this.chensLabel2.TabIndex = 50;
            this.chensLabel2.Text = "日期";
            // 
            // chensDataGridView2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.chensDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.chensDataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.chensDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chensDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chensDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chensDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.chensDataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chensDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.chensDataGridView2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensDataGridView2.GridColor = System.Drawing.Color.LightGray;
            this.chensDataGridView2.HaveCopyMenu = true;
            this.chensDataGridView2.Location = new System.Drawing.Point(3, 60);
            this.chensDataGridView2.Name = "chensDataGridView2";
            this.chensDataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.chensDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.chensDataGridView2.RowTemplate.Height = 23;
            this.chensDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chensDataGridView2.Size = new System.Drawing.Size(986, 49);
            this.chensDataGridView2.TabIndex = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "选择";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "转移单号";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "日期";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(392, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 28);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "刷新";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.Controls.Add(this.chensDataGridView1);
            this.chensGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(0, 137);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(992, 398);
            this.chensGroupBox2.TabIndex = 2;
            this.chensGroupBox2.TabStop = false;
            this.chensGroupBox2.Text = "查询结果";
            // 
            // chensDataGridView1
            // 
            this.chensDataGridView1.AllowUserToAddRows = false;
            this.chensDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.chensDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.chensDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.chensDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chensDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chensDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chensDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column8,
            this.Column7,
            this.Column10});
            this.chensDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.chensDataGridView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensDataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.chensDataGridView1.HaveCopyMenu = true;
            this.chensDataGridView1.Location = new System.Drawing.Point(3, 19);
            this.chensDataGridView1.Name = "chensDataGridView1";
            this.chensDataGridView1.ReadOnly = true;
            this.chensDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.chensDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.chensDataGridView1.RowTemplate.Height = 23;
            this.chensDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chensDataGridView1.Size = new System.Drawing.Size(986, 376);
            this.chensDataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "转移单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "物料编号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "批次";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "货位";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "物料数量";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "中文名称";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "英文名称";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Name = "Form4";
            this.Text = "Form4";
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView2)).EndInit();
            this.chensGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 生成下架任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印报废拣货单ToolStripMenuItem;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private System.Windows.Forms.ToolStripMenuItem 设置打印机ToolStripMenuItem;
        private ChensControl.ChensDataGridView chensDataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensDataGridView chensDataGridView1;
        private ChensControl.ChensLabel chensLabel3;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private ChensControl.ChensLabel chensLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}