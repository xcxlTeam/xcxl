namespace WMS.Print
{
    partial class Form1
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
            this.拣货单生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mRP计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.必返料单生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停工单设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当天使用现场物料清单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensDataGridView1 = new ChensControl.ChensDataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.chensDateTimePicker2 = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensButton2 = new ChensControl.ChensButton();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensDateTimePicker1 = new ChensControl.ChensDateTimePicker();
            this.chensMenuStrip1.SuspendLayout();
            this.chensGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).BeginInit();
            this.chensGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拣货单生成ToolStripMenuItem,
            this.mRP计算ToolStripMenuItem,
            this.必返料单生成ToolStripMenuItem,
            this.停工单设置ToolStripMenuItem,
            this.当天使用现场物料清单ToolStripMenuItem});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(992, 25);
            this.chensMenuStrip1.TabIndex = 0;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // 拣货单生成ToolStripMenuItem
            // 
            this.拣货单生成ToolStripMenuItem.Name = "拣货单生成ToolStripMenuItem";
            this.拣货单生成ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.拣货单生成ToolStripMenuItem.Text = "拣货单生成";
            // 
            // mRP计算ToolStripMenuItem
            // 
            this.mRP计算ToolStripMenuItem.Name = "mRP计算ToolStripMenuItem";
            this.mRP计算ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.mRP计算ToolStripMenuItem.Text = "返库单生成";
            // 
            // 必返料单生成ToolStripMenuItem
            // 
            this.必返料单生成ToolStripMenuItem.Name = "必返料单生成ToolStripMenuItem";
            this.必返料单生成ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.必返料单生成ToolStripMenuItem.Text = "必返料单生成";
            // 
            // 停工单设置ToolStripMenuItem
            // 
            this.停工单设置ToolStripMenuItem.Name = "停工单设置ToolStripMenuItem";
            this.停工单设置ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.停工单设置ToolStripMenuItem.Text = "停工单设置";
            // 
            // 当天使用现场物料清单ToolStripMenuItem
            // 
            this.当天使用现场物料清单ToolStripMenuItem.Name = "当天使用现场物料清单ToolStripMenuItem";
            this.当天使用现场物料清单ToolStripMenuItem.Size = new System.Drawing.Size(164, 21);
            this.当天使用现场物料清单ToolStripMenuItem.Text = "当天使用现场物料清单打印";
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.Controls.Add(this.chensDataGridView1);
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 99);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(992, 365);
            this.chensGroupBox1.TabIndex = 1;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询结果";
            // 
            // chensDataGridView1
            // 
            this.chensDataGridView1.AllowUserToAddRows = false;
            this.chensDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.chensDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.chensDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.chensDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chensDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chensDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chensDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column5,
            this.Column8,
            this.Column9,
            this.Column7,
            this.Column4,
            this.Column6});
            this.chensDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.chensDataGridView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensDataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.chensDataGridView1.HaveCopyMenu = true;
            this.chensDataGridView1.Location = new System.Drawing.Point(3, 19);
            this.chensDataGridView1.Name = "chensDataGridView1";
            this.chensDataGridView1.ReadOnly = true;
            this.chensDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.chensDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.chensDataGridView1.RowTemplate.Height = 23;
            this.chensDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chensDataGridView1.Size = new System.Drawing.Size(986, 343);
            this.chensDataGridView1.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "物料编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "中文名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "英文名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "需求数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "线边库存";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "差异数量";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "制法";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "物料类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "操作类型";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.Controls.Add(this.chensDateTimePicker2);
            this.chensGroupBox2.Controls.Add(this.chensLabel5);
            this.chensGroupBox2.Controls.Add(this.chensButton2);
            this.chensGroupBox2.Controls.Add(this.chensLabel2);
            this.chensGroupBox2.Controls.Add(this.chensDateTimePicker1);
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(3, 33);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(986, 60);
            this.chensGroupBox2.TabIndex = 2;
            this.chensGroupBox2.TabStop = false;
            this.chensGroupBox2.Text = "查询条件";
            // 
            // chensDateTimePicker2
            // 
            this.chensDateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensDateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensDateTimePicker2.Location = new System.Drawing.Point(345, 22);
            this.chensDateTimePicker2.Name = "chensDateTimePicker2";
            this.chensDateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.chensDateTimePicker2.TabIndex = 14;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(305, 27);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 13;
            this.chensLabel5.Text = "——";
            // 
            // chensButton2
            // 
            this.chensButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensButton2.ForeColor = System.Drawing.Color.White;
            this.chensButton2.Location = new System.Drawing.Point(627, 19);
            this.chensButton2.Name = "chensButton2";
            this.chensButton2.Size = new System.Drawing.Size(82, 32);
            this.chensButton2.TabIndex = 4;
            this.chensButton2.Text = "刷新";
            this.chensButton2.UseVisualStyleBackColor = false;
            this.chensButton2.Click += new System.EventHandler(this.chensButton2_Click);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(37, 27);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 3;
            this.chensLabel2.Text = "制造日期";
            // 
            // chensDateTimePicker1
            // 
            this.chensDateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensDateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensDateTimePicker1.Location = new System.Drawing.Point(99, 22);
            this.chensDateTimePicker1.Name = "chensDateTimePicker1";
            this.chensDateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.chensDateTimePicker1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.chensGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).EndInit();
            this.chensGroupBox2.ResumeLayout(false);
            this.chensGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mRP计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 必返料单生成ToolStripMenuItem;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensDataGridView chensDataGridView1;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensDateTimePicker chensDateTimePicker1;
        private ChensControl.ChensButton chensButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ToolStripMenuItem 拣货单生成ToolStripMenuItem;
        private ChensControl.ChensDateTimePicker chensDateTimePicker2;
        private ChensControl.ChensLabel chensLabel5;
        private System.Windows.Forms.ToolStripMenuItem 当天使用现场物料清单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停工单设置ToolStripMenuItem;
    }
}