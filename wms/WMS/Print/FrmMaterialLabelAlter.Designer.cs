namespace WMS.Print
{
    partial class FrmMaterialLabelAlter
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
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colBARCODENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBATCHNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPackQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSUPCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSUPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDELIVERYNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVOUCHERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colROWNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.txtNSN = new ChensControl.ChensTextBox();
            this.bsCreate = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtNPrintQty = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.cbxNOther = new ChensControl.ChensCheckBox();
            this.cbxNPlatedTin = new ChensControl.ChensCheckBox();
            this.cbxNPlatedSilver = new ChensControl.ChensCheckBox();
            this.txtNOutPackQty = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtNQty = new ChensControl.ChensTextBox();
            this.lblInnerPackQty = new ChensControl.ChensLabel();
            this.txtNBatchNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtNMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtNMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtSERIALNO = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtBATCHNO = new ChensControl.ChensTextBox();
            this.cbbVoucherType = new ChensControl.ChensComboBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.txtSN = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtMATERIALNO = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.lblVoucherNo = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreate)).BeginInit();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 122);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 451);
            this.gbMiddle.TabIndex = 9;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "条码明细";
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
            this.colBARCODENO,
            this.colSERIALNO,
            this.colMATERIALNO,
            this.colMATERIALDESC,
            this.colBSN,
            this.colBATCHNO,
            this.colPlated,
            this.colBatchQty,
            this.colOutPackQty,
            this.colQTY,
            this.colSUPCODE,
            this.colSUPNAME,
            this.colStrVoucherType,
            this.colDELIVERYNO,
            this.colVOUCHERNO,
            this.colROWNO});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 409);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // colBARCODENO
            // 
            this.colBARCODENO.DataPropertyName = "BARCODENO";
            this.colBARCODENO.HeaderText = "外箱序号";
            this.colBARCODENO.Name = "colBARCODENO";
            // 
            // colSERIALNO
            // 
            this.colSERIALNO.DataPropertyName = "SERIALNO";
            this.colSERIALNO.HeaderText = "流水号";
            this.colSERIALNO.Name = "colSERIALNO";
            // 
            // colMATERIALNO
            // 
            this.colMATERIALNO.DataPropertyName = "MATERIALNO";
            this.colMATERIALNO.HeaderText = "物料编号";
            this.colMATERIALNO.Name = "colMATERIALNO";
            // 
            // colMATERIALDESC
            // 
            this.colMATERIALDESC.DataPropertyName = "MATERIALDESC";
            this.colMATERIALDESC.HeaderText = "物料描述";
            this.colMATERIALDESC.Name = "colMATERIALDESC";
            // 
            // colBSN
            // 
            this.colBSN.DataPropertyName = "SN";
            this.colBSN.HeaderText = "来料批次";
            this.colBSN.Name = "colBSN";
            // 
            // colBATCHNO
            // 
            this.colBATCHNO.DataPropertyName = "BATCHNO";
            this.colBATCHNO.HeaderText = "生产批号";
            this.colBATCHNO.Name = "colBATCHNO";
            // 
            // colPlated
            // 
            this.colPlated.DataPropertyName = "Plated";
            this.colPlated.HeaderText = "涂层物料";
            this.colPlated.Name = "colPlated";
            // 
            // colBatchQty
            // 
            this.colBatchQty.DataPropertyName = "BatchQty";
            this.colBatchQty.HeaderText = "批次数量";
            this.colBatchQty.Name = "colBatchQty";
            // 
            // colOutPackQty
            // 
            this.colOutPackQty.DataPropertyName = "OutPackQty";
            this.colOutPackQty.HeaderText = "包装数量";
            this.colOutPackQty.Name = "colOutPackQty";
            // 
            // colQTY
            // 
            this.colQTY.DataPropertyName = "QTY";
            this.colQTY.HeaderText = "数量";
            this.colQTY.Name = "colQTY";
            // 
            // colSUPCODE
            // 
            this.colSUPCODE.DataPropertyName = "SUPCODE";
            this.colSUPCODE.HeaderText = "供应商代码";
            this.colSUPCODE.Name = "colSUPCODE";
            // 
            // colSUPNAME
            // 
            this.colSUPNAME.DataPropertyName = "SUPNAME";
            this.colSUPNAME.HeaderText = "供应商名称";
            this.colSUPNAME.Name = "colSUPNAME";
            // 
            // colStrVoucherType
            // 
            this.colStrVoucherType.DataPropertyName = "StrVoucherType";
            this.colStrVoucherType.HeaderText = "单据类型";
            this.colStrVoucherType.Name = "colStrVoucherType";
            // 
            // colDELIVERYNO
            // 
            this.colDELIVERYNO.DataPropertyName = "DELIVERYNO";
            this.colDELIVERYNO.HeaderText = "单据编号";
            this.colDELIVERYNO.Name = "colDELIVERYNO";
            // 
            // colVOUCHERNO
            // 
            this.colVOUCHERNO.DataPropertyName = "VOUCHERNO";
            this.colVOUCHERNO.HeaderText = "采购订单号";
            this.colVOUCHERNO.Name = "colVOUCHERNO";
            this.colVOUCHERNO.Visible = false;
            // 
            // colROWNO
            // 
            this.colROWNO.DataPropertyName = "ROWNO";
            this.colROWNO.HeaderText = "行号";
            this.colROWNO.Name = "colROWNO";
            // 
            // pageList
            // 
            this.pageList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageList.CurrentPageNumber = 0;
            dividPage1.CurrentPageNumber = 0;
            dividPage1.CurrentPageRecordCounts = 0;
            dividPage1.CurrentPageShowCounts = 10;
            dividPage1.DefaultPageShowCounts = 10;
            dividPage1.PagesCount = 0;
            dividPage1.RecordCounts = 0;
            this.pageList.dDividPage = dividPage1;
            this.pageList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageList.Location = new System.Drawing.Point(3, 428);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 0;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.txtNSN);
            this.gbBottom.Controls.Add(this.chensLabel4);
            this.gbBottom.Controls.Add(this.txtNPrintQty);
            this.gbBottom.Controls.Add(this.chensLabel7);
            this.gbBottom.Controls.Add(this.cbxNOther);
            this.gbBottom.Controls.Add(this.cbxNPlatedTin);
            this.gbBottom.Controls.Add(this.cbxNPlatedSilver);
            this.gbBottom.Controls.Add(this.txtNOutPackQty);
            this.gbBottom.Controls.Add(this.chensLabel6);
            this.gbBottom.Controls.Add(this.txtNQty);
            this.gbBottom.Controls.Add(this.lblInnerPackQty);
            this.gbBottom.Controls.Add(this.txtNBatchNo);
            this.gbBottom.Controls.Add(this.chensLabel5);
            this.gbBottom.Controls.Add(this.txtNMaterialDesc);
            this.gbBottom.Controls.Add(this.chensLabel8);
            this.gbBottom.Controls.Add(this.txtNMaterialNo);
            this.gbBottom.Controls.Add(this.chensLabel9);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 573);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(992, 200);
            this.gbBottom.TabIndex = 7;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "打印参数";
            // 
            // txtNSN
            // 
            this.txtNSN.BackColor = System.Drawing.Color.White;
            this.txtNSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNSN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "SN", true));
            this.txtNSN.Enabled = false;
            this.txtNSN.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNSN.HotTrack = false;
            this.txtNSN.Location = new System.Drawing.Point(353, 58);
            this.txtNSN.Name = "txtNSN";
            this.txtNSN.Size = new System.Drawing.Size(150, 23);
            this.txtNSN.TabIndex = 10;
            this.txtNSN.TextEnabled = false;
            // 
            // bsCreate
            // 
            this.bsCreate.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(279, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 17;
            this.chensLabel4.Text = "来料批次";
            // 
            // txtNPrintQty
            // 
            this.txtNPrintQty.BackColor = System.Drawing.Color.White;
            this.txtNPrintQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNPrintQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNPrintQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "PRINTQTY", true));
            this.txtNPrintQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNPrintQty.HotTrack = false;
            this.txtNPrintQty.Location = new System.Drawing.Point(99, 163);
            this.txtNPrintQty.Name = "txtNPrintQty";
            this.txtNPrintQty.Size = new System.Drawing.Size(150, 23);
            this.txtNPrintQty.TabIndex = 16;
            this.txtNPrintQty.TextEnabled = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 165);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 15;
            this.chensLabel7.Text = "打印份数";
            // 
            // cbxNOther
            // 
            this.cbxNOther.AutoSize = true;
            this.cbxNOther.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedOther", true));
            this.cbxNOther.Enabled = false;
            this.cbxNOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNOther.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxNOther.Location = new System.Drawing.Point(175, 131);
            this.cbxNOther.Name = "cbxNOther";
            this.cbxNOther.Size = new System.Drawing.Size(48, 21);
            this.cbxNOther.TabIndex = 15;
            this.cbxNOther.Text = "其他";
            this.cbxNOther.Textn = "其他";
            this.cbxNOther.UseVisualStyleBackColor = true;
            this.cbxNOther.CheckedChanged += new System.EventHandler(this.cbxNOther_CheckedChanged);
            // 
            // cbxNPlatedTin
            // 
            this.cbxNPlatedTin.AutoSize = true;
            this.cbxNPlatedTin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedTin", true));
            this.cbxNPlatedTin.Enabled = false;
            this.cbxNPlatedTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNPlatedTin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxNPlatedTin.Location = new System.Drawing.Point(100, 130);
            this.cbxNPlatedTin.Name = "cbxNPlatedTin";
            this.cbxNPlatedTin.Size = new System.Drawing.Size(48, 21);
            this.cbxNPlatedTin.TabIndex = 14;
            this.cbxNPlatedTin.Text = "镀锡";
            this.cbxNPlatedTin.Textn = "镀锡";
            this.cbxNPlatedTin.UseVisualStyleBackColor = true;
            this.cbxNPlatedTin.CheckedChanged += new System.EventHandler(this.cbxNPlatedTin_CheckedChanged);
            // 
            // cbxNPlatedSilver
            // 
            this.cbxNPlatedSilver.AutoSize = true;
            this.cbxNPlatedSilver.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedSilver", true));
            this.cbxNPlatedSilver.Enabled = false;
            this.cbxNPlatedSilver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNPlatedSilver.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxNPlatedSilver.Location = new System.Drawing.Point(25, 130);
            this.cbxNPlatedSilver.Name = "cbxNPlatedSilver";
            this.cbxNPlatedSilver.Size = new System.Drawing.Size(48, 21);
            this.cbxNPlatedSilver.TabIndex = 13;
            this.cbxNPlatedSilver.Text = "镀银";
            this.cbxNPlatedSilver.Textn = "镀银";
            this.cbxNPlatedSilver.UseVisualStyleBackColor = true;
            this.cbxNPlatedSilver.CheckedChanged += new System.EventHandler(this.cbxNPlatedSilver_CheckedChanged);
            // 
            // txtNOutPackQty
            // 
            this.txtNOutPackQty.BackColor = System.Drawing.Color.White;
            this.txtNOutPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNOutPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNOutPackQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "OUTPACKQTY", true));
            this.txtNOutPackQty.Enabled = false;
            this.txtNOutPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNOutPackQty.HotTrack = false;
            this.txtNOutPackQty.Location = new System.Drawing.Point(99, 93);
            this.txtNOutPackQty.Name = "txtNOutPackQty";
            this.txtNOutPackQty.Size = new System.Drawing.Size(150, 23);
            this.txtNOutPackQty.TabIndex = 11;
            this.txtNOutPackQty.TextEnabled = false;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(25, 95);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(68, 17);
            this.chensLabel6.TabIndex = 9;
            this.chensLabel6.Text = "外箱包装量";
            // 
            // txtNQty
            // 
            this.txtNQty.BackColor = System.Drawing.Color.White;
            this.txtNQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "QTY", true));
            this.txtNQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNQty.HotTrack = false;
            this.txtNQty.Location = new System.Drawing.Point(353, 93);
            this.txtNQty.Name = "txtNQty";
            this.txtNQty.Size = new System.Drawing.Size(150, 23);
            this.txtNQty.TabIndex = 12;
            this.txtNQty.TextEnabled = false;
            // 
            // lblInnerPackQty
            // 
            this.lblInnerPackQty.AutoSize = true;
            this.lblInnerPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblInnerPackQty.Location = new System.Drawing.Point(279, 95);
            this.lblInnerPackQty.Name = "lblInnerPackQty";
            this.lblInnerPackQty.Size = new System.Drawing.Size(56, 17);
            this.lblInnerPackQty.TabIndex = 7;
            this.lblInnerPackQty.Text = "实际数量";
            // 
            // txtNBatchNo
            // 
            this.txtNBatchNo.BackColor = System.Drawing.Color.White;
            this.txtNBatchNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNBatchNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "BATCHNO", true));
            this.txtNBatchNo.Enabled = false;
            this.txtNBatchNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNBatchNo.HotTrack = false;
            this.txtNBatchNo.Location = new System.Drawing.Point(99, 58);
            this.txtNBatchNo.Name = "txtNBatchNo";
            this.txtNBatchNo.Size = new System.Drawing.Size(150, 23);
            this.txtNBatchNo.TabIndex = 9;
            this.txtNBatchNo.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(25, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 5;
            this.chensLabel5.Text = "生产批号";
            // 
            // txtNMaterialDesc
            // 
            this.txtNMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtNMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNMaterialDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "MATERIALDESC", true));
            this.txtNMaterialDesc.Enabled = false;
            this.txtNMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNMaterialDesc.HotTrack = false;
            this.txtNMaterialDesc.Location = new System.Drawing.Point(353, 23);
            this.txtNMaterialDesc.Name = "txtNMaterialDesc";
            this.txtNMaterialDesc.Size = new System.Drawing.Size(150, 23);
            this.txtNMaterialDesc.TabIndex = 8;
            this.txtNMaterialDesc.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(279, 25);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 3;
            this.chensLabel8.Text = "物料描述";
            // 
            // txtNMaterialNo
            // 
            this.txtNMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtNMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "MATERIALNO", true));
            this.txtNMaterialNo.Enabled = false;
            this.txtNMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtNMaterialNo.HotTrack = false;
            this.txtNMaterialNo.Location = new System.Drawing.Point(99, 23);
            this.txtNMaterialNo.Name = "txtNMaterialNo";
            this.txtNMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtNMaterialNo.TabIndex = 7;
            this.txtNMaterialNo.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(25, 25);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 1;
            this.chensLabel9.Text = "物料编号";
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtSERIALNO);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.txtBATCHNO);
            this.gbHeader.Controls.Add(this.cbbVoucherType);
            this.gbHeader.Controls.Add(this.chensLabel11);
            this.gbHeader.Controls.Add(this.chensLabel10);
            this.gbHeader.Controls.Add(this.txtSN);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.txtMATERIALNO);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtVoucherNo);
            this.gbHeader.Controls.Add(this.lblVoucherNo);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 27);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 6;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // txtSERIALNO
            // 
            this.txtSERIALNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSERIALNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSERIALNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SERIALNO", true));
            this.txtSERIALNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSERIALNO.HotTrack = false;
            this.txtSERIALNO.Location = new System.Drawing.Point(87, 23);
            this.txtSERIALNO.Name = "txtSERIALNO";
            this.txtSERIALNO.Size = new System.Drawing.Size(150, 23);
            this.txtSERIALNO.TabIndex = 1;
            this.txtSERIALNO.TextEnabled = false;
            this.txtSERIALNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(44, 17);
            this.chensLabel2.TabIndex = 15;
            this.chensLabel2.Text = "流水号";
            // 
            // txtBATCHNO
            // 
            this.txtBATCHNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBATCHNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBATCHNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "BATCHNO", true));
            this.txtBATCHNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBATCHNO.HotTrack = false;
            this.txtBATCHNO.Location = new System.Drawing.Point(329, 58);
            this.txtBATCHNO.Name = "txtBATCHNO";
            this.txtBATCHNO.Size = new System.Drawing.Size(150, 23);
            this.txtBATCHNO.TabIndex = 5;
            this.txtBATCHNO.TextEnabled = false;
            this.txtBATCHNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.cbbVoucherType.Location = new System.Drawing.Point(329, 22);
            this.cbbVoucherType.Name = "cbbVoucherType";
            this.cbbVoucherType.Size = new System.Drawing.Size(150, 25);
            this.cbbVoucherType.TabIndex = 2;
            this.cbbVoucherType.SelectedIndexChanged += new System.EventHandler(this.cbbVOUCHERTYPE_SelectedIndexChanged);
            this.cbbVoucherType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(267, 25);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(56, 17);
            this.chensLabel11.TabIndex = 12;
            this.chensLabel11.Text = "单据类型";
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(267, 60);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 11;
            this.chensLabel10.Text = "生产批号";
            // 
            // txtSN
            // 
            this.txtSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SN", true));
            this.txtSN.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSN.HotTrack = false;
            this.txtSN.Location = new System.Drawing.Point(559, 58);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(150, 23);
            this.txtSN.TabIndex = 6;
            this.txtSN.TextEnabled = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(497, 60);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 9;
            this.chensLabel3.Text = "来料批次";
            // 
            // txtMATERIALNO
            // 
            this.txtMATERIALNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMATERIALNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMATERIALNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MATERIALNO", true));
            this.txtMATERIALNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMATERIALNO.HotTrack = false;
            this.txtMATERIALNO.Location = new System.Drawing.Point(87, 58);
            this.txtMATERIALNO.Name = "txtMATERIALNO";
            this.txtMATERIALNO.Size = new System.Drawing.Size(150, 23);
            this.txtMATERIALNO.TabIndex = 4;
            this.txtMATERIALNO.TextEnabled = false;
            this.txtMATERIALNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(32, 17);
            this.chensLabel1.TabIndex = 5;
            this.chensLabel1.Text = "物料";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(913, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 28);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.White;
            this.txtVoucherNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "DELIVERYNO", true));
            this.txtVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVoucherNo.HotTrack = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(559, 22);
            this.txtVoucherNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 3;
            this.txtVoucherNo.TextEnabled = false;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblVoucherNo.Location = new System.Drawing.Point(497, 25);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(56, 17);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "单据编号";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiPrint,
            this.tsmiChangePrinter});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(992, 27);
            this.msMain.TabIndex = 5;
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
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPrint.Size = new System.Drawing.Size(80, 21);
            this.tsmiPrint.Text = "替换并打印";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(80, 21);
            this.tsmiChangePrinter.Text = "设置打印机";
            this.tsmiChangePrinter.Click += new System.EventHandler(this.tsmiChangePrinter_Click);
            // 
            // FrmMaterialLabelAlter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmMaterialLabelAlter";
            this.Text = "物料标签替换";
            this.Load += new System.EventHandler(this.FrmMaterialLabelAlter_Load);
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreate)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtSN;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtMATERIALNO;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel lblVoucherNo;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensTextBox txtNSN;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtNPrintQty;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensCheckBox cbxNOther;
        private ChensControl.ChensCheckBox cbxNPlatedTin;
        private ChensControl.ChensCheckBox cbxNPlatedSilver;
        private ChensControl.ChensTextBox txtNOutPackQty;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtNQty;
        private ChensControl.ChensLabel lblInnerPackQty;
        private ChensControl.ChensTextBox txtNBatchNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtNMaterialDesc;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensTextBox txtNMaterialNo;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensTextBox txtBATCHNO;
        private ChensControl.ChensComboBox cbbVoucherType;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensLabel chensLabel10;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.BindingSource bsCreate;
        private ChensControl.ChensTextBox txtSERIALNO;
        private ChensControl.ChensLabel chensLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBARCODENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBATCHNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPackQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSUPCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSUPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDELIVERYNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVOUCHERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colROWNO;
    }
}