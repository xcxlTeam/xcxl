namespace WMS.Query
{
    partial class FrmPrintRecordQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage3 = new ChensControl.DividPage();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.cbbVoucherType = new ChensControl.ChensComboBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtSUPCODE = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colHBARCODETYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrBarcodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coloHSUPCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSUPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVOUCHERTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPRINTQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.msMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiExport});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 7;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.tsmiSearch.Size = new System.Drawing.Size(68, 21);
            this.tsmiSearch.Text = "查询数据";
            this.tsmiSearch.Visible = false;
            this.tsmiSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(44, 21);
            this.tsmiExport.Text = "导出";
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.cbbVoucherType);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.txtSUPCODE);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 12;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // cbbVoucherType
            // 
            this.cbbVoucherType.BackColor = System.Drawing.Color.White;
            this.cbbVoucherType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbVoucherType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMain, "iVoucherType", true));
            this.cbbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVoucherType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbVoucherType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbVoucherType.FormattingEnabled = true;
            this.cbbVoucherType.HotTrack = false;
            this.cbbVoucherType.Location = new System.Drawing.Point(87, 58);
            this.cbbVoucherType.Name = "cbbVoucherType";
            this.cbbVoucherType.Size = new System.Drawing.Size(150, 25);
            this.cbbVoucherType.TabIndex = 16;
            this.cbbVoucherType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 60);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 15;
            this.chensLabel7.Text = "单据类型";
            // 
            // txtSUPCODE
            // 
            this.txtSUPCODE.BackColor = System.Drawing.Color.White;
            this.txtSUPCODE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSUPCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSUPCODE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SUPCODE", true));
            this.txtSUPCODE.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSUPCODE.HotTrack = false;
            this.txtSUPCODE.Location = new System.Drawing.Point(87, 23);
            this.txtSUPCODE.Name = "txtSUPCODE";
            this.txtSUPCODE.Size = new System.Drawing.Size(150, 23);
            this.txtSUPCODE.TabIndex = 10;
            this.txtSUPCODE.TextEnabled = false;
            this.txtSUPCODE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 25);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(44, 17);
            this.chensLabel4.TabIndex = 9;
            this.chensLabel4.Text = "供应商";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(549, 23);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 8;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(34, 17);
            this.chensLabel3.TabIndex = 7;
            this.chensLabel3.Text = "——";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(329, 23);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 6;
            this.dtpStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 5;
            this.chensLabel2.Text = "打印日期";
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
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Controls.Add(this.pageList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 120);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 653);
            this.gbBottom.TabIndex = 13;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "查询结果";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHBARCODETYPE,
            this.colHStrBarcodeType,
            this.coloHSUPCODE,
            this.colHSUPNAME,
            this.colHVOUCHERTYPE,
            this.colHStrVoucherType,
            this.colHPRINTQTY});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 609);
            this.dgvList.TabIndex = 2;
            // 
            // colHBARCODETYPE
            // 
            this.colHBARCODETYPE.DataPropertyName = "BARCODETYPE";
            this.colHBARCODETYPE.HeaderText = "条码类型";
            this.colHBARCODETYPE.Name = "colHBARCODETYPE";
            this.colHBARCODETYPE.ReadOnly = true;
            this.colHBARCODETYPE.Visible = false;
            // 
            // colHStrBarcodeType
            // 
            this.colHStrBarcodeType.DataPropertyName = "StrBarcodeType";
            this.colHStrBarcodeType.HeaderText = "标签类型";
            this.colHStrBarcodeType.Name = "colHStrBarcodeType";
            this.colHStrBarcodeType.ReadOnly = true;
            // 
            // coloHSUPCODE
            // 
            this.coloHSUPCODE.DataPropertyName = "SUPCODE";
            this.coloHSUPCODE.HeaderText = "供应商代码";
            this.coloHSUPCODE.Name = "coloHSUPCODE";
            this.coloHSUPCODE.ReadOnly = true;
            // 
            // colHSUPNAME
            // 
            this.colHSUPNAME.DataPropertyName = "SUPNAME";
            this.colHSUPNAME.HeaderText = "供应商名称";
            this.colHSUPNAME.Name = "colHSUPNAME";
            this.colHSUPNAME.ReadOnly = true;
            this.colHSUPNAME.Width = 200;
            // 
            // colHVOUCHERTYPE
            // 
            this.colHVOUCHERTYPE.DataPropertyName = "VOUCHERTYPE";
            this.colHVOUCHERTYPE.HeaderText = "单据类型";
            this.colHVOUCHERTYPE.Name = "colHVOUCHERTYPE";
            this.colHVOUCHERTYPE.ReadOnly = true;
            this.colHVOUCHERTYPE.Visible = false;
            // 
            // colHStrVoucherType
            // 
            this.colHStrVoucherType.DataPropertyName = "StrVoucherType";
            this.colHStrVoucherType.HeaderText = "单据类型";
            this.colHStrVoucherType.Name = "colHStrVoucherType";
            this.colHStrVoucherType.ReadOnly = true;
            // 
            // colHPRINTQTY
            // 
            this.colHPRINTQTY.DataPropertyName = "PRINTQTY";
            this.colHPRINTQTY.HeaderText = "打印数量";
            this.colHPRINTQTY.Name = "colHPRINTQTY";
            this.colHPRINTQTY.ReadOnly = true;
            // 
            // pageList
            // 
            this.pageList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageList.CurrentPageNumber = 0;
            dividPage3.CurrentPageNumber = 0;
            dividPage3.CurrentPageRecordCounts = 0;
            dividPage3.CurrentPageShowCounts = 10;
            dividPage3.DefaultPageShowCounts = 10;
            dividPage3.PagesCount = 0;
            dividPage3.RecordCounts = 0;
            this.pageList.dDividPage = dividPage3;
            this.pageList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageList.Location = new System.Drawing.Point(3, 629);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.Click += new System.EventHandler(this.pageList_ChensPageChange);
            // 
            // FrmPrintRecordQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmPrintRecordQuery";
            this.Text = "标签打印记录查新";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrintRecordQuery_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrintRecordQuery_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensComboBox cbbVoucherType;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtSUPCODE;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHBARCODETYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrBarcodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn coloHSUPCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSUPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVOUCHERTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPRINTQTY;
        private System.Windows.Forms.BindingSource bsMain;
    }
}