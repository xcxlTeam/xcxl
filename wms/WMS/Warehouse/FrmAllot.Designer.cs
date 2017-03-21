﻿namespace WMS.Warehouse
{
    partial class FrmAllot
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
            this.tsmPickUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMustBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStopOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSceneMaterialReport = new System.Windows.Forms.ToolStripMenuItem();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.dgvData = new ChensControl.ChensDataGridView();
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
            this.chensButton2 = new ChensControl.ChensButton();
            this.chensMenuStrip1.SuspendLayout();
            this.chensGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.chensGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPickUp,
            this.tsmBackUp,
            this.tsmMustBack,
            this.tsmStopOrder,
            this.tsmSceneMaterialReport});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(992, 25);
            this.chensMenuStrip1.TabIndex = 0;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // tsmPickUp
            // 
            this.tsmPickUp.Name = "tsmPickUp";
            this.tsmPickUp.Size = new System.Drawing.Size(80, 21);
            this.tsmPickUp.Text = "拣货单生成";
            // 
            // tsmBackUp
            // 
            this.tsmBackUp.Name = "tsmBackUp";
            this.tsmBackUp.Size = new System.Drawing.Size(80, 21);
            this.tsmBackUp.Text = "返库单生成";
            // 
            // tsmMustBack
            // 
            this.tsmMustBack.Name = "tsmMustBack";
            this.tsmMustBack.Size = new System.Drawing.Size(92, 21);
            this.tsmMustBack.Text = "必返料单生成";
            // 
            // tsmStopOrder
            // 
            this.tsmStopOrder.Name = "tsmStopOrder";
            this.tsmStopOrder.Size = new System.Drawing.Size(80, 21);
            this.tsmStopOrder.Text = "停工单设置";
            // 
            // tsmSceneMaterialReport
            // 
            this.tsmSceneMaterialReport.Name = "tsmSceneMaterialReport";
            this.tsmSceneMaterialReport.Size = new System.Drawing.Size(164, 21);
            this.tsmSceneMaterialReport.Text = "当天使用现场物料清单打印";
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.Controls.Add(this.dgvData);
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 99);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(992, 365);
            this.chensGroupBox1.TabIndex = 1;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询结果";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column5,
            this.Column8,
            this.Column9,
            this.Column7,
            this.Column4,
            this.Column6});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvData.GridColor = System.Drawing.Color.LightGray;
            this.dgvData.HaveCopyMenu = true;
            this.dgvData.Location = new System.Drawing.Point(3, 19);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(986, 343);
            this.dgvData.TabIndex = 0;
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
            this.Column7.HeaderText = "建筑编号";
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
            this.chensGroupBox2.Controls.Add(this.chensButton2);
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(3, 33);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(986, 60);
            this.chensGroupBox2.TabIndex = 2;
            this.chensGroupBox2.TabStop = false;
            this.chensGroupBox2.Text = "查询条件";
            // 
            // chensButton2
            // 
            this.chensButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensButton2.ForeColor = System.Drawing.Color.White;
            this.chensButton2.Location = new System.Drawing.Point(405, 15);
            this.chensButton2.Name = "chensButton2";
            this.chensButton2.Size = new System.Drawing.Size(82, 32);
            this.chensButton2.TabIndex = 4;
            this.chensButton2.Text = "刷新";
            this.chensButton2.UseVisualStyleBackColor = false;
            this.chensButton2.Click += new System.EventHandler(this.chensButton2_Click);
            // 
            // FrmAllot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Name = "FrmAllot";
            this.Text = "Form1";
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.chensGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.chensGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmBackUp;
        private System.Windows.Forms.ToolStripMenuItem tsmMustBack;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensDataGridView dgvData;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensButton chensButton2;
        private System.Windows.Forms.ToolStripMenuItem tsmPickUp;
        private System.Windows.Forms.ToolStripMenuItem tsmSceneMaterialReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStopOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}