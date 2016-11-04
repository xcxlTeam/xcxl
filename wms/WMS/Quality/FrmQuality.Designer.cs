namespace WMS.Quality
{
    partial class FrmQuality
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQualityType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.chensTextBox3 = new ChensControl.ChensTextBox();
            this.bsDelivery = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensTextBox2 = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensTextBox1 = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtWarehouseName = new ChensControl.ChensTextBox();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDelivery)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.cbxSelectAll);
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 121);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(1014, 200);
            this.gbBottom.TabIndex = 10;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "质检明细";
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.BackColor = System.Drawing.Color.Gainsboro;
            this.cbxSelectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.cbxSelectAll.Location = new System.Drawing.Point(6, 20);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(51, 21);
            this.cbxSelectAll.TabIndex = 4;
            this.cbxSelectAll.Text = "选择";
            this.cbxSelectAll.UseVisualStyleBackColor = false;
            this.cbxSelectAll.CheckedChanged += new System.EventHandler(this.cbxSelectAll_CheckedChanged);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.ID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column8,
            this.Column4,
            this.Column9,
            this.Column5,
            this.colQualityType});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1008, 176);
            this.dgvList.TabIndex = 0;
            this.dgvList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvList_CurrentCellDirtyStateChanged);
            this.dgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvList_DataError);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvList_Scroll);
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "OKSelect";
            this.colSelect.HeaderText = "选择";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 56;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "RowNo";
            this.Column1.HeaderText = "行号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 56;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "MaterialNo";
            this.Column2.HeaderText = "物料号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "MaterialDesc";
            this.Column3.HeaderText = "物料描述";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.DataPropertyName = "ReceiveQty";
            this.Column6.HeaderText = "送检数量";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "QualityQty";
            this.Column8.HeaderText = "合格数量";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "CurrentQualityQty";
            this.Column4.HeaderText = "本次合格数量";
            this.Column4.Name = "Column4";
            this.Column4.Width = 104;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "UnQualityQty";
            this.Column9.HeaderText = "不合格数量";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "CurrentUnQualityQty";
            this.Column5.HeaderText = "本次不合格数量";
            this.Column5.Name = "Column5";
            this.Column5.Width = 116;
            // 
            // colQualityType
            // 
            this.colQualityType.HeaderText = "缺陷等级";
            this.colQualityType.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3"});
            this.colQualityType.Name = "colQualityType";
            this.colQualityType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colQualityType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colQualityType.ToolTipText = "本次不合格数量的缺陷等级";
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.chensTextBox3);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.chensTextBox2);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.chensTextBox1);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.txtWarehouseName);
            this.gbHeader.Controls.Add(this.txtWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(1014, 96);
            this.gbHeader.TabIndex = 9;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "质检信息";
            // 
            // chensTextBox3
            // 
            this.chensTextBox3.BackColor = System.Drawing.Color.White;
            this.chensTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDelivery, "Plant", true));
            this.chensTextBox3.Enabled = false;
            this.chensTextBox3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox3.HotTrack = false;
            this.chensTextBox3.Location = new System.Drawing.Point(724, 21);
            this.chensTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox3.Name = "chensTextBox3";
            this.chensTextBox3.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox3.TabIndex = 9;
            this.chensTextBox3.TextEnabled = false;
            // 
            // bsDelivery
            // 
            this.bsDelivery.DataSource = typeof(WMS.WebService.DeliveryReceive_Model);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(674, 23);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(44, 17);
            this.chensLabel5.TabIndex = 8;
            this.chensLabel5.Text = "工厂：";
            // 
            // chensTextBox2
            // 
            this.chensTextBox2.BackColor = System.Drawing.Color.White;
            this.chensTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDelivery, "SupName", true));
            this.chensTextBox2.Enabled = false;
            this.chensTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox2.HotTrack = false;
            this.chensTextBox2.Location = new System.Drawing.Point(86, 21);
            this.chensTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox2.Name = "chensTextBox2";
            this.chensTextBox2.Size = new System.Drawing.Size(569, 23);
            this.chensTextBox2.TabIndex = 7;
            this.chensTextBox2.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(12, 23);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 6;
            this.chensLabel4.Text = "供应商：";
            // 
            // chensTextBox1
            // 
            this.chensTextBox1.BackColor = System.Drawing.Color.White;
            this.chensTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDelivery, "DeliveryNo", true));
            this.chensTextBox1.Enabled = false;
            this.chensTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox1.HotTrack = false;
            this.chensTextBox1.Location = new System.Drawing.Point(86, 53);
            this.chensTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox1.Name = "chensTextBox1";
            this.chensTextBox1.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox1.TabIndex = 5;
            this.chensTextBox1.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(12, 55);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(68, 17);
            this.chensLabel3.TabIndex = 4;
            this.chensLabel3.Text = "送货单号：";
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.White;
            this.txtWarehouseName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDelivery, "MaterialDoc", true));
            this.txtWarehouseName.Enabled = false;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseName.HotTrack = false;
            this.txtWarehouseName.Location = new System.Drawing.Point(560, 53);
            this.txtWarehouseName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(150, 23);
            this.txtWarehouseName.TabIndex = 3;
            this.txtWarehouseName.TextEnabled = false;
            // 
            // txtWarehouseNo
            // 
            this.txtWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDelivery, "VoucherNo", true));
            this.txtWarehouseNo.Enabled = false;
            this.txtWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseNo.HotTrack = false;
            this.txtWarehouseNo.Location = new System.Drawing.Point(312, 53);
            this.txtWarehouseNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarehouseNo.Name = "txtWarehouseNo";
            this.txtWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWarehouseNo.TabIndex = 2;
            this.txtWarehouseNo.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(498, 55);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(68, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "物料凭证：";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(243, 55);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(37, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "PO：";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiClose});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1014, 25);
            this.msMain.TabIndex = 11;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(44, 21);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiClose.Size = new System.Drawing.Size(44, 21);
            this.tsmiClose.Text = "关闭";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // FrmQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 321);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Name = "FrmQuality";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物料质检";
            this.Load += new System.EventHandler(this.FrmQuality_Load);
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDelivery)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtWarehouseName;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox chensTextBox1;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox chensTextBox2;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox chensTextBox3;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensGroupBox gbBottom;
        private System.Windows.Forms.BindingSource bsDelivery;
        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private ChensControl.ChensDataGridView dgvList;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn colQualityType;
    }
}