﻿namespace WMS.FastTask
{
    partial class Form99
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
            this.components = new System.ComponentModel.Container();
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.chensPage1 = new ChensControl.ChensPage();
            this.dgv_show = new ChensControl.ChensDataGridView();
            this.tIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISPOST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voucherNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEUSERNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensComboBox1 = new ChensControl.ChensComboBox();
            this.cmb_state = new ChensControl.ChensComboBox();
            this.btn_select = new ChensControl.ChensButton();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.endtime = new ChensControl.ChensDateTimePicker();
            this.begintime = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txt_ontaskno = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txt_peo = new ChensControl.ChensTextBox();
            this.txt_djno = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.chensMenuStrip1 = new ChensControl.ChensMenuStrip();
            this.新建出库单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改出库单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除出库单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.新建报废出库单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chensGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.chensGroupBox1.SuspendLayout();
            this.chensMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox2.Controls.Add(this.chensPage1);
            this.chensGroupBox2.Controls.Add(this.dgv_show);
            this.chensGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(0, 143);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(1031, 331);
            this.chensGroupBox2.TabIndex = 5;
            this.chensGroupBox2.TabStop = false;
            this.chensGroupBox2.Text = "详细信息";
            // 
            // chensPage1
            // 
            this.chensPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensPage1.CurrentPageNumber = 0;
            dividPage1.CurrentPageNumber = 0;
            dividPage1.CurrentPageRecordCounts = 0;
            dividPage1.CurrentPageShowCounts = 10;
            dividPage1.DefaultPageShowCounts = 10;
            dividPage1.PagesCount = 0;
            dividPage1.RecordCounts = 0;
            this.chensPage1.dDividPage = dividPage1;
            this.chensPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chensPage1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chensPage1.Location = new System.Drawing.Point(3, 299);
            this.chensPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensPage1.Name = "chensPage1";
            this.chensPage1.Size = new System.Drawing.Size(1025, 29);
            this.chensPage1.TabIndex = 1;
            this.chensPage1.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.chensPage1_ChensPageChange);
            // 
            // dgv_show
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_show.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_show.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tIDDataGridViewTextBoxColumn,
            this.ISPOST,
            this.voucherNoDataGridViewTextBoxColumn,
            this.taskNoDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.cREATEUSERNODataGridViewTextBoxColumn,
            this.createDateTimeDataGridViewTextBoxColumn,
            this.reasonDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.dgv_show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgv_show.GridColor = System.Drawing.Color.LightGray;
            this.dgv_show.HaveCopyMenu = true;
            this.dgv_show.Location = new System.Drawing.Point(6, 22);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.ReadOnly = true;
            this.dgv_show.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgv_show.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_show.RowTemplate.Height = 23;
            this.dgv_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_show.Size = new System.Drawing.Size(1013, 270);
            this.dgv_show.TabIndex = 0;
            this.dgv_show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellContentClick);
            // 
            // tIDDataGridViewTextBoxColumn
            // 
            this.tIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.tIDDataGridViewTextBoxColumn.Name = "tIDDataGridViewTextBoxColumn";
            this.tIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // ISPOST
            // 
            this.ISPOST.DataPropertyName = "SHELVEPOST";
            this.ISPOST.HeaderText = "是否过账";
            this.ISPOST.Name = "ISPOST";
            this.ISPOST.ReadOnly = true;
            // 
            // voucherNoDataGridViewTextBoxColumn
            // 
            this.voucherNoDataGridViewTextBoxColumn.HeaderText = "单据号";
            this.voucherNoDataGridViewTextBoxColumn.Name = "voucherNoDataGridViewTextBoxColumn";
            this.voucherNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taskNoDataGridViewTextBoxColumn
            // 
            this.taskNoDataGridViewTextBoxColumn.HeaderText = "下架任务号";
            this.taskNoDataGridViewTextBoxColumn.Name = "taskNoDataGridViewTextBoxColumn";
            this.taskNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.HeaderText = "状态";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cREATEUSERNODataGridViewTextBoxColumn
            // 
            this.cREATEUSERNODataGridViewTextBoxColumn.HeaderText = "制单人";
            this.cREATEUSERNODataGridViewTextBoxColumn.Name = "cREATEUSERNODataGridViewTextBoxColumn";
            this.cREATEUSERNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createDateTimeDataGridViewTextBoxColumn
            // 
            this.createDateTimeDataGridViewTextBoxColumn.HeaderText = "制单日期";
            this.createDateTimeDataGridViewTextBoxColumn.Name = "createDateTimeDataGridViewTextBoxColumn";
            this.createDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.createDateTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // reasonDataGridViewTextBoxColumn
            // 
            this.reasonDataGridViewTextBoxColumn.HeaderText = "出库原因";
            this.reasonDataGridViewTextBoxColumn.Name = "reasonDataGridViewTextBoxColumn";
            this.reasonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox1.Controls.Add(this.chensComboBox1);
            this.chensGroupBox1.Controls.Add(this.cmb_state);
            this.chensGroupBox1.Controls.Add(this.btn_select);
            this.chensGroupBox1.Controls.Add(this.chensLabel7);
            this.chensGroupBox1.Controls.Add(this.chensLabel6);
            this.chensGroupBox1.Controls.Add(this.endtime);
            this.chensGroupBox1.Controls.Add(this.begintime);
            this.chensGroupBox1.Controls.Add(this.chensLabel5);
            this.chensGroupBox1.Controls.Add(this.txt_ontaskno);
            this.chensGroupBox1.Controls.Add(this.chensLabel4);
            this.chensGroupBox1.Controls.Add(this.chensLabel3);
            this.chensGroupBox1.Controls.Add(this.txt_peo);
            this.chensGroupBox1.Controls.Add(this.txt_djno);
            this.chensGroupBox1.Controls.Add(this.chensLabel2);
            this.chensGroupBox1.Controls.Add(this.chensLabel1);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 25);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(1031, 118);
            this.chensGroupBox1.TabIndex = 4;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "查询";
            // 
            // chensComboBox1
            // 
            this.chensComboBox1.BackColor = System.Drawing.Color.White;
            this.chensComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chensComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensComboBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensComboBox1.FormattingEnabled = true;
            this.chensComboBox1.HotTrack = false;
            this.chensComboBox1.Location = new System.Drawing.Point(318, 22);
            this.chensComboBox1.Name = "chensComboBox1";
            this.chensComboBox1.Size = new System.Drawing.Size(138, 25);
            this.chensComboBox1.TabIndex = 17;
            // 
            // cmb_state
            // 
            this.cmb_state.BackColor = System.Drawing.Color.White;
            this.cmb_state.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmb_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_state.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_state.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmb_state.FormattingEnabled = true;
            this.cmb_state.HotTrack = false;
            this.cmb_state.Location = new System.Drawing.Point(89, 82);
            this.cmb_state.Name = "cmb_state";
            this.cmb_state.Size = new System.Drawing.Size(138, 25);
            this.cmb_state.TabIndex = 13;
            // 
            // btn_select
            // 
            this.btn_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btn_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_select.ForeColor = System.Drawing.Color.White;
            this.btn_select.Location = new System.Drawing.Point(722, 22);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(104, 26);
            this.btn_select.TabIndex = 16;
            this.btn_select.Text = "查询";
            this.btn_select.UseVisualStyleBackColor = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(26, 86);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(44, 17);
            this.chensLabel7.TabIndex = 12;
            this.chensLabel7.Text = "状态：";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(475, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(68, 17);
            this.chensLabel6.TabIndex = 11;
            this.chensLabel6.Text = "结束日期：";
            // 
            // endtime
            // 
            this.endtime.Checked = false;
            this.endtime.Location = new System.Drawing.Point(549, 58);
            this.endtime.Name = "endtime";
            this.endtime.ShowCheckBox = true;
            this.endtime.Size = new System.Drawing.Size(148, 23);
            this.endtime.TabIndex = 10;
            // 
            // begintime
            // 
            this.begintime.Checked = false;
            this.begintime.Location = new System.Drawing.Point(549, 25);
            this.begintime.Name = "begintime";
            this.begintime.ShowCheckBox = true;
            this.begintime.Size = new System.Drawing.Size(148, 23);
            this.begintime.TabIndex = 9;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(475, 27);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(68, 17);
            this.chensLabel5.TabIndex = 8;
            this.chensLabel5.Text = "开始日期：";
            // 
            // txt_ontaskno
            // 
            this.txt_ontaskno.BackColor = System.Drawing.Color.White;
            this.txt_ontaskno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_ontaskno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ontaskno.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_ontaskno.HotTrack = false;
            this.txt_ontaskno.Location = new System.Drawing.Point(318, 54);
            this.txt_ontaskno.Name = "txt_ontaskno";
            this.txt_ontaskno.Size = new System.Drawing.Size(138, 23);
            this.txt_ontaskno.TabIndex = 7;
            this.txt_ontaskno.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(240, 56);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(80, 17);
            this.chensLabel4.TabIndex = 6;
            this.chensLabel4.Text = "下架任务号：";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(240, 27);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(68, 17);
            this.chensLabel3.TabIndex = 4;
            this.chensLabel3.Text = "出库类型：";
            // 
            // txt_peo
            // 
            this.txt_peo.BackColor = System.Drawing.Color.White;
            this.txt_peo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_peo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_peo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_peo.HotTrack = false;
            this.txt_peo.Location = new System.Drawing.Point(89, 54);
            this.txt_peo.Name = "txt_peo";
            this.txt_peo.Size = new System.Drawing.Size(138, 23);
            this.txt_peo.TabIndex = 3;
            this.txt_peo.TextEnabled = false;
            // 
            // txt_djno
            // 
            this.txt_djno.BackColor = System.Drawing.Color.White;
            this.txt_djno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_djno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_djno.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_djno.HotTrack = false;
            this.txt_djno.Location = new System.Drawing.Point(89, 25);
            this.txt_djno.Name = "txt_djno";
            this.txt_djno.Size = new System.Drawing.Size(138, 23);
            this.txt_djno.TabIndex = 2;
            this.txt_djno.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(27, 56);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "制单人：";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(27, 27);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "单据号：";
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建出库单ToolStripMenuItem,
            this.新建报废出库单ToolStripMenuItem,
            this.修改出库单ToolStripMenuItem,
            this.删除出库单ToolStripMenuItem});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(1031, 25);
            this.chensMenuStrip1.TabIndex = 3;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // 新建出库单ToolStripMenuItem
            // 
            this.新建出库单ToolStripMenuItem.Name = "新建出库单ToolStripMenuItem";
            this.新建出库单ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.新建出库单ToolStripMenuItem.Text = "新建出库单";
            this.新建出库单ToolStripMenuItem.Click += new System.EventHandler(this.新建出库单ToolStripMenuItem_Click);
            // 
            // 修改出库单ToolStripMenuItem
            // 
            this.修改出库单ToolStripMenuItem.Name = "修改出库单ToolStripMenuItem";
            this.修改出库单ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.修改出库单ToolStripMenuItem.Text = "修改出库单";
            this.修改出库单ToolStripMenuItem.Click += new System.EventHandler(this.修改出库单ToolStripMenuItem_Click);
            // 
            // 删除出库单ToolStripMenuItem
            // 
            this.删除出库单ToolStripMenuItem.Name = "删除出库单ToolStripMenuItem";
            this.删除出库单ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.删除出库单ToolStripMenuItem.Text = "删除出库单";
            this.删除出库单ToolStripMenuItem.Click += new System.EventHandler(this.删除出库单ToolStripMenuItem_Click);
            // 
            // 新建报废出库单ToolStripMenuItem
            // 
            this.新建报废出库单ToolStripMenuItem.Name = "新建报废出库单ToolStripMenuItem";
            this.新建报废出库单ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.新建报废出库单ToolStripMenuItem.Text = "新建报废出库单";
            // 
            // Form99
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 474);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.Name = "Form99";
            this.Text = "Frmmain_FastOut";
            this.chensGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensPage chensPage1;
        private ChensControl.ChensDataGridView dgv_show;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensComboBox cmb_state;
        private ChensControl.ChensButton btn_select;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker endtime;
        private ChensControl.ChensDateTimePicker begintime;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txt_ontaskno;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txt_peo;
        private ChensControl.ChensTextBox txt_djno;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建出库单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改出库单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除出库单ToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISPOST;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucherNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEUSERNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private ChensControl.ChensComboBox chensComboBox1;
        private System.Windows.Forms.ToolStripMenuItem 新建报废出库单ToolStripMenuItem;
    }
}