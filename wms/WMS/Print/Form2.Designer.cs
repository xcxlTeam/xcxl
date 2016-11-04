namespace WMS.Print
{
    partial class Form2
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
            this.chensMenuStrip1 = new ChensControl.ChensMenuStrip();
            this.库存状态变更单打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置打印机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensButton1 = new ChensControl.ChensButton();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtBATCHNO = new ChensControl.ChensTextBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.txtMATERIALNO = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.chensDataGridView1 = new ChensControl.ChensDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensMenuStrip1.SuspendLayout();
            this.chensGroupBox1.SuspendLayout();
            this.chensGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.库存状态变更单打印ToolStripMenuItem,
            this.设置打印机ToolStripMenuItem});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(992, 25);
            this.chensMenuStrip1.TabIndex = 0;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // 库存状态变更单打印ToolStripMenuItem
            // 
            this.库存状态变更单打印ToolStripMenuItem.Name = "库存状态变更单打印ToolStripMenuItem";
            this.库存状态变更单打印ToolStripMenuItem.Size = new System.Drawing.Size(152, 21);
            this.库存状态变更单打印ToolStripMenuItem.Text = "库存检验状态变更单打印";
            // 
            // 设置打印机ToolStripMenuItem
            // 
            this.设置打印机ToolStripMenuItem.Name = "设置打印机ToolStripMenuItem";
            this.设置打印机ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.设置打印机ToolStripMenuItem.Text = "设置打印机";
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.Controls.Add(this.chensButton1);
            this.chensGroupBox1.Controls.Add(this.btnSearch);
            this.chensGroupBox1.Controls.Add(this.txtBATCHNO);
            this.chensGroupBox1.Controls.Add(this.chensLabel10);
            this.chensGroupBox1.Controls.Add(this.txtMATERIALNO);
            this.chensGroupBox1.Controls.Add(this.chensLabel3);
            this.chensGroupBox1.Controls.Add(this.chensLabel1);
            this.chensGroupBox1.Controls.Add(this.dtpEndTime);
            this.chensGroupBox1.Controls.Add(this.dtpStartTime);
            this.chensGroupBox1.Controls.Add(this.chensLabel2);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 25);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(992, 100);
            this.chensGroupBox1.TabIndex = 1;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询条件";
            // 
            // chensButton1
            // 
            this.chensButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chensButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton1.ForeColor = System.Drawing.Color.White;
            this.chensButton1.Location = new System.Drawing.Point(819, 21);
            this.chensButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensButton1.Name = "chensButton1";
            this.chensButton1.Size = new System.Drawing.Size(66, 28);
            this.chensButton1.TabIndex = 33;
            this.chensButton1.Text = "过账";
            this.chensButton1.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(723, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 28);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtBATCHNO
            // 
            this.txtBATCHNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBATCHNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBATCHNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBATCHNO.HotTrack = false;
            this.txtBATCHNO.Location = new System.Drawing.Point(312, 51);
            this.txtBATCHNO.Name = "txtBATCHNO";
            this.txtBATCHNO.Size = new System.Drawing.Size(150, 23);
            this.txtBATCHNO.TabIndex = 29;
            this.txtBATCHNO.TextEnabled = false;
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(250, 53);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(32, 17);
            this.chensLabel10.TabIndex = 31;
            this.chensLabel10.Text = "批次";
            // 
            // txtMATERIALNO
            // 
            this.txtMATERIALNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMATERIALNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMATERIALNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMATERIALNO.HotTrack = false;
            this.txtMATERIALNO.Location = new System.Drawing.Point(70, 51);
            this.txtMATERIALNO.Name = "txtMATERIALNO";
            this.txtMATERIALNO.Size = new System.Drawing.Size(150, 23);
            this.txtMATERIALNO.TabIndex = 28;
            this.txtMATERIALNO.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(8, 53);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(32, 17);
            this.chensLabel3.TabIndex = 30;
            this.chensLabel3.Text = "物料";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(255, 24);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(20, 17);
            this.chensLabel1.TabIndex = 27;
            this.chensLabel1.Text = "至";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(312, 22);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 26;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(70, 22);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 25;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(8, 24);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 23;
            this.chensLabel2.Text = "检验日期";
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.Controls.Add(this.chensDataGridView1);
            this.chensGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(0, 125);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(992, 363);
            this.chensGroupBox2.TabIndex = 2;
            this.chensGroupBox2.TabStop = false;
            this.chensGroupBox2.Text = "查询结果";
            // 
            // chensDataGridView1
            // 
            this.chensDataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.chensDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.chensDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.chensDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chensDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chensDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chensDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column9,
            this.Column6,
            this.Column8});
            this.chensDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.chensDataGridView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensDataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.chensDataGridView1.HaveCopyMenu = true;
            this.chensDataGridView1.Location = new System.Drawing.Point(3, 19);
            this.chensDataGridView1.Name = "chensDataGridView1";
            this.chensDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.chensDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.chensDataGridView1.RowTemplate.Height = 23;
            this.chensDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chensDataGridView1.Size = new System.Drawing.Size(986, 341);
            this.chensDataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "货位编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "库区编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "仓库编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "物料编号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "批次";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "数量";
            this.Column7.Name = "Column7";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "件数";
            this.Column9.Name = "Column9";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "中文名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "英文名称";
            this.Column8.Name = "Column8";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            this.chensGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 库存状态变更单打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置打印机ToolStripMenuItem;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtBATCHNO;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensTextBox txtMATERIALNO;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensButton chensButton1;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensDataGridView chensDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}