namespace WMS.Print
{
    partial class Form10
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
            this.btnSearch = new ChensControl.ChensButton();
            this.txtMATERIALNO = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.chensDataGridView1 = new ChensControl.ChensDataGridView();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensCheckBox1 = new ChensControl.ChensCheckBox();
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
            this.库存状态变更单打印ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.库存状态变更单打印ToolStripMenuItem.Text = "原材料入库单打印";
            // 
            // 设置打印机ToolStripMenuItem
            // 
            this.设置打印机ToolStripMenuItem.Name = "设置打印机ToolStripMenuItem";
            this.设置打印机ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.设置打印机ToolStripMenuItem.Text = "设置打印机";
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.Controls.Add(this.chensCheckBox1);
            this.chensGroupBox1.Controls.Add(this.chensLabel5);
            this.chensGroupBox1.Controls.Add(this.dtpEndTime);
            this.chensGroupBox1.Controls.Add(this.dtpStartTime);
            this.chensGroupBox1.Controls.Add(this.chensLabel8);
            this.chensGroupBox1.Controls.Add(this.btnSearch);
            this.chensGroupBox1.Controls.Add(this.txtMATERIALNO);
            this.chensGroupBox1.Controls.Add(this.chensLabel3);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 25);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(992, 71);
            this.chensGroupBox1.TabIndex = 1;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询条件";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(837, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 28);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtMATERIALNO
            // 
            this.txtMATERIALNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMATERIALNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMATERIALNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMATERIALNO.HotTrack = false;
            this.txtMATERIALNO.Location = new System.Drawing.Point(73, 26);
            this.txtMATERIALNO.Name = "txtMATERIALNO";
            this.txtMATERIALNO.Size = new System.Drawing.Size(150, 23);
            this.txtMATERIALNO.TabIndex = 28;
            this.txtMATERIALNO.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(11, 28);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(49, 17);
            this.chensLabel3.TabIndex = 30;
            this.chensLabel3.Text = "PO单号";
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.Controls.Add(this.chensDataGridView1);
            this.chensGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(0, 96);
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
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column1});
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
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(477, 28);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 36;
            this.chensLabel5.Text = "——";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(517, 26);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 35;
            this.dtpEndTime.Visible = false;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(321, 26);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 34;
            this.dtpStartTime.Visible = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(283, 28);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(32, 17);
            this.chensLabel8.TabIndex = 33;
            this.chensLabel8.Text = "日期";
            this.chensLabel8.Visible = false;
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
            this.Column7.HeaderText = "打印张数";
            this.Column7.Name = "Column7";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "中文名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "英文名称";
            this.Column1.Name = "Column1";
            // 
            // chensCheckBox1
            // 
            this.chensCheckBox1.AutoSize = true;
            this.chensCheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensCheckBox1.Location = new System.Drawing.Point(722, 26);
            this.chensCheckBox1.Name = "chensCheckBox1";
            this.chensCheckBox1.Size = new System.Drawing.Size(60, 21);
            this.chensCheckBox1.TabIndex = 37;
            this.chensCheckBox1.Text = "已打印";
            this.chensCheckBox1.Textn = "已打印";
            this.chensCheckBox1.UseVisualStyleBackColor = true;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Name = "Form10";
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
        private ChensControl.ChensTextBox txtMATERIALNO;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensDataGridView chensDataGridView1;
        private ChensControl.ChensCheckBox chensCheckBox1;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensLabel chensLabel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}