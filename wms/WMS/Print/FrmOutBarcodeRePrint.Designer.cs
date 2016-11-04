namespace WMS.Print
{
    partial class FrmOutBarcodeRePrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtAndalaNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.lblaAndalaNo = new ChensControl.ChensLabel();
            this.txtSN = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensTextBox2 = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensTextBox1 = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.lblVoucherNo = new ChensControl.ChensLabel();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBARCODENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVOUCHERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colROWNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDELIVERYNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPRDVERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBATCHNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPackQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSUPCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSUPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReserveNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReserveRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAndalaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrintQty = new ChensControl.ChensDataGridViewNumericUpDownColumn();
            this.msMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiPrint,
            this.tsmiChangePrinter,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(992, 27);
            this.msMain.TabIndex = 4;
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
            this.tsmiPrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrint.Text = "箱号打印";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(80, 21);
            this.tsmiChangePrinter.Text = "设置打印机";
            this.tsmiChangePrinter.Click += new System.EventHandler(this.tsmiChangePrinter_Click);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtAndalaNo);
            this.gbHeader.Controls.Add(this.lblaAndalaNo);
            this.gbHeader.Controls.Add(this.txtSN);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.chensTextBox2);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensTextBox1);
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
            this.gbHeader.TabIndex = 5;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // txtAndalaNo
            // 
            this.txtAndalaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAndalaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAndalaNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "AndalaNo", true));
            this.txtAndalaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAndalaNo.HotTrack = false;
            this.txtAndalaNo.Location = new System.Drawing.Point(329, 58);
            this.txtAndalaNo.Name = "txtAndalaNo";
            this.txtAndalaNo.Size = new System.Drawing.Size(150, 23);
            this.txtAndalaNo.TabIndex = 12;
            this.txtAndalaNo.TextEnabled = false;
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // lblaAndalaNo
            // 
            this.lblaAndalaNo.AutoSize = true;
            this.lblaAndalaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblaAndalaNo.Location = new System.Drawing.Point(267, 60);
            this.lblaAndalaNo.Name = "lblaAndalaNo";
            this.lblaAndalaNo.Size = new System.Drawing.Size(56, 17);
            this.lblaAndalaNo.TabIndex = 11;
            this.lblaAndalaNo.Text = "进仓单号";
            // 
            // txtSN
            // 
            this.txtSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SN", true));
            this.txtSN.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSN.HotTrack = false;
            this.txtSN.Location = new System.Drawing.Point(87, 58);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(150, 23);
            this.txtSN.TabIndex = 10;
            this.txtSN.TextEnabled = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 60);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 9;
            this.chensLabel3.Text = "来料批次";
            // 
            // chensTextBox2
            // 
            this.chensTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SERIALNO", true));
            this.chensTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox2.HotTrack = false;
            this.chensTextBox2.Location = new System.Drawing.Point(559, 23);
            this.chensTextBox2.Name = "chensTextBox2";
            this.chensTextBox2.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox2.TabIndex = 8;
            this.chensTextBox2.TextEnabled = false;
            this.chensTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(509, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(44, 17);
            this.chensLabel2.TabIndex = 7;
            this.chensLabel2.Text = "流水号";
            // 
            // chensTextBox1
            // 
            this.chensTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MATERIALNO", true));
            this.chensTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox1.HotTrack = false;
            this.chensTextBox1.Location = new System.Drawing.Point(329, 23);
            this.chensTextBox1.Name = "chensTextBox1";
            this.chensTextBox1.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox1.TabIndex = 6;
            this.chensTextBox1.TextEnabled = false;
            this.chensTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(267, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 5;
            this.chensLabel1.Text = "物料编号";
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
            this.btnSearch.TabIndex = 4;
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
            this.txtVoucherNo.Location = new System.Drawing.Point(87, 23);
            this.txtVoucherNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 1;
            this.txtVoucherNo.TextEnabled = false;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblVoucherNo.Location = new System.Drawing.Point(25, 25);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(56, 17);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "送货单号";
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.cbxSelectAll);
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 122);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 447);
            this.gbMiddle.TabIndex = 8;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "条码明细";
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.BackColor = System.Drawing.Color.Gainsboro;
            this.cbxSelectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.cbxSelectAll.Location = new System.Drawing.Point(12, 19);
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
            this.colBARCODENO,
            this.colSERIALNO,
            this.colVOUCHERNO,
            this.colROWNO,
            this.colDELIVERYNO,
            this.colMATERIALNO,
            this.colMATERIALDESC,
            this.colPRDVERSION,
            this.colBSN,
            this.colBATCHNO,
            this.colPlated,
            this.colBatchQty,
            this.colOutPackQty,
            this.colQTY,
            this.colSUPCODE,
            this.colSUPNAME,
            this.colDepartment,
            this.colReason,
            this.colTrackNo,
            this.colReserveNumber,
            this.colReserveRowNo,
            this.colAndalaNo,
            this.colPrintQty});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 405);
            this.dgvList.TabIndex = 1;
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvList_Scroll);
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
            this.pageList.Location = new System.Drawing.Point(3, 424);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 0;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // colSelect
            // 
            this.colSelect.FalseValue = "False";
            this.colSelect.HeaderText = "选择";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect.TrueValue = "True";
            this.colSelect.Width = 60;
            // 
            // colBARCODENO
            // 
            this.colBARCODENO.DataPropertyName = "BARCODENO";
            this.colBARCODENO.HeaderText = "外箱序号";
            this.colBARCODENO.Name = "colBARCODENO";
            this.colBARCODENO.ReadOnly = true;
            // 
            // colSERIALNO
            // 
            this.colSERIALNO.DataPropertyName = "SERIALNO";
            this.colSERIALNO.HeaderText = "流水号";
            this.colSERIALNO.Name = "colSERIALNO";
            this.colSERIALNO.ReadOnly = true;
            // 
            // colVOUCHERNO
            // 
            this.colVOUCHERNO.DataPropertyName = "VOUCHERNO";
            this.colVOUCHERNO.HeaderText = "采购订单号";
            this.colVOUCHERNO.Name = "colVOUCHERNO";
            this.colVOUCHERNO.ReadOnly = true;
            // 
            // colROWNO
            // 
            this.colROWNO.DataPropertyName = "ROWNO";
            this.colROWNO.HeaderText = "行号";
            this.colROWNO.Name = "colROWNO";
            this.colROWNO.ReadOnly = true;
            // 
            // colDELIVERYNO
            // 
            this.colDELIVERYNO.DataPropertyName = "DELIVERYNO";
            this.colDELIVERYNO.HeaderText = "送货单号";
            this.colDELIVERYNO.Name = "colDELIVERYNO";
            this.colDELIVERYNO.ReadOnly = true;
            // 
            // colMATERIALNO
            // 
            this.colMATERIALNO.DataPropertyName = "MATERIALNO";
            this.colMATERIALNO.HeaderText = "物料编号";
            this.colMATERIALNO.Name = "colMATERIALNO";
            this.colMATERIALNO.ReadOnly = true;
            // 
            // colMATERIALDESC
            // 
            this.colMATERIALDESC.DataPropertyName = "MATERIALDESC";
            this.colMATERIALDESC.HeaderText = "物料描述";
            this.colMATERIALDESC.Name = "colMATERIALDESC";
            this.colMATERIALDESC.ReadOnly = true;
            this.colMATERIALDESC.Width = 200;
            // 
            // colPRDVERSION
            // 
            this.colPRDVERSION.DataPropertyName = "PRDVERSION";
            this.colPRDVERSION.HeaderText = "产品版本";
            this.colPRDVERSION.Name = "colPRDVERSION";
            this.colPRDVERSION.ReadOnly = true;
            // 
            // colBSN
            // 
            this.colBSN.DataPropertyName = "SN";
            this.colBSN.HeaderText = "来料批次";
            this.colBSN.Name = "colBSN";
            this.colBSN.ReadOnly = true;
            // 
            // colBATCHNO
            // 
            this.colBATCHNO.DataPropertyName = "BATCHNO";
            this.colBATCHNO.HeaderText = "生产批号";
            this.colBATCHNO.Name = "colBATCHNO";
            this.colBATCHNO.ReadOnly = true;
            // 
            // colPlated
            // 
            this.colPlated.DataPropertyName = "Plated";
            this.colPlated.HeaderText = "涂层物料";
            this.colPlated.Name = "colPlated";
            this.colPlated.ReadOnly = true;
            // 
            // colBatchQty
            // 
            this.colBatchQty.DataPropertyName = "BatchQty";
            this.colBatchQty.HeaderText = "批次数量";
            this.colBatchQty.Name = "colBatchQty";
            this.colBatchQty.ReadOnly = true;
            // 
            // colOutPackQty
            // 
            this.colOutPackQty.DataPropertyName = "OutPackQty";
            this.colOutPackQty.HeaderText = "包装数量";
            this.colOutPackQty.Name = "colOutPackQty";
            this.colOutPackQty.ReadOnly = true;
            // 
            // colQTY
            // 
            this.colQTY.DataPropertyName = "QTY";
            this.colQTY.HeaderText = "数量";
            this.colQTY.Name = "colQTY";
            this.colQTY.ReadOnly = true;
            // 
            // colSUPCODE
            // 
            this.colSUPCODE.DataPropertyName = "SUPCODE";
            this.colSUPCODE.HeaderText = "供应商代码";
            this.colSUPCODE.Name = "colSUPCODE";
            this.colSUPCODE.ReadOnly = true;
            // 
            // colSUPNAME
            // 
            this.colSUPNAME.DataPropertyName = "SUPNAME";
            this.colSUPNAME.HeaderText = "供应商名称";
            this.colSUPNAME.Name = "colSUPNAME";
            this.colSUPNAME.ReadOnly = true;
            this.colSUPNAME.Width = 200;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "Department";
            this.colDepartment.HeaderText = "退仓部门";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            // 
            // colReason
            // 
            this.colReason.DataPropertyName = "Reason";
            this.colReason.HeaderText = "退仓原因";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            // 
            // colTrackNo
            // 
            this.colTrackNo.DataPropertyName = "TrackNo";
            this.colTrackNo.HeaderText = "生产订单号";
            this.colTrackNo.Name = "colTrackNo";
            this.colTrackNo.ReadOnly = true;
            // 
            // colReserveNumber
            // 
            this.colReserveNumber.DataPropertyName = "ReserveNumber";
            this.colReserveNumber.HeaderText = "预留项目号";
            this.colReserveNumber.Name = "colReserveNumber";
            this.colReserveNumber.ReadOnly = true;
            // 
            // colReserveRowNo
            // 
            this.colReserveRowNo.DataPropertyName = "ReserveRowNo";
            this.colReserveRowNo.HeaderText = "预留行号";
            this.colReserveRowNo.Name = "colReserveRowNo";
            this.colReserveRowNo.ReadOnly = true;
            // 
            // colAndalaNo
            // 
            this.colAndalaNo.DataPropertyName = "AndalaNo";
            this.colAndalaNo.HeaderText = "进仓单号";
            this.colAndalaNo.Name = "colAndalaNo";
            this.colAndalaNo.ReadOnly = true;
            // 
            // colPrintQty
            // 
            this.colPrintQty.DecimalPlaces = 0;
            dataGridViewCellStyle3.NullValue = "1";
            this.colPrintQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrintQty.HeaderText = "打印份数";
            this.colPrintQty.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.colPrintQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colPrintQty.Name = "colPrintQty";
            this.colPrintQty.Width = 80;
            // 
            // FrmOutBarcodeRePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 569);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Name = "FrmOutBarcodeRePrint";
            this.Text = "外箱标签重打";
            this.Load += new System.EventHandler(this.FrmOutBarcodeRePrint_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.gbMiddle.ResumeLayout(false);
            this.gbMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel lblVoucherNo;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox chensTextBox2;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox chensTextBox1;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtSN;
        private ChensControl.ChensTextBox txtAndalaNo;
        private ChensControl.ChensLabel lblaAndalaNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBARCODENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVOUCHERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colROWNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDELIVERYNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPRDVERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBATCHNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPackQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSUPCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSUPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReserveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReserveRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAndalaNo;
        private ChensControl.ChensDataGridViewNumericUpDownColumn colPrintQty;
    }
}