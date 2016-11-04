namespace WMS.Print
{
    partial class FrmCensorshipPrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage4 = new ChensControl.DividPage();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtDeliveryNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.dtpEndDate = new ChensControl.ChensDateTimePicker();
            this.dtpStartDate = new ChensControl.ChensDateTimePicker();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialDoc = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPostDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVoucherNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDeliveryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupplierNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMoveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPrintTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvDetail = new ChensControl.ChensDataGridView();
            this.colBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBPrdVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageDetail = new ChensControl.ChensPage();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtDeliveryNo);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.dtpEndDate);
            this.gbHeader.Controls.Add(this.dtpStartDate);
            this.gbHeader.Controls.Add(this.txtVoucherNo);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.txtMaterialDoc);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
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
            // txtDeliveryNo
            // 
            this.txtDeliveryNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDeliveryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "DeliveryNo", true));
            this.txtDeliveryNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDeliveryNo.HotTrack = false;
            this.txtDeliveryNo.Location = new System.Drawing.Point(559, 58);
            this.txtDeliveryNo.Name = "txtDeliveryNo";
            this.txtDeliveryNo.Size = new System.Drawing.Size(150, 23);
            this.txtDeliveryNo.TabIndex = 24;
            this.txtDeliveryNo.TextEnabled = false;
            this.txtDeliveryNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.DeliveryReceive_Model);
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(497, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 25;
            this.chensLabel6.Text = "送货单号";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialNo", true));
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(329, 58);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 23;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(267, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 11;
            this.chensLabel5.Text = "物料编号";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Checked = false;
            this.dtpEndDate.Location = new System.Drawing.Point(329, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 10;
            this.dtpEndDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = false;
            this.dtpStartDate.Location = new System.Drawing.Point(87, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 9;
            this.dtpStartDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "VoucherNo", true));
            this.txtVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVoucherNo.HotTrack = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(559, 23);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 8;
            this.txtVoucherNo.TextEnabled = false;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(497, 25);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 7;
            this.chensLabel4.Text = "采购单号";
            // 
            // txtMaterialDoc
            // 
            this.txtMaterialDoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDoc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialDoc", true));
            this.txtMaterialDoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDoc.HotTrack = false;
            this.txtMaterialDoc.Location = new System.Drawing.Point(87, 58);
            this.txtMaterialDoc.Name = "txtMaterialDoc";
            this.txtMaterialDoc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDoc.TabIndex = 6;
            this.txtMaterialDoc.TextEnabled = false;
            this.txtMaterialDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 60);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 5;
            this.chensLabel3.Text = "物料凭证";
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
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(34, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "——";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "凭证日期";
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
            this.msMain.TabIndex = 3;
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
            this.tsmiPrint.Text = "打印送检单";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(80, 21);
            this.tsmiChangePrinter.Text = "设置打印机";
            this.tsmiChangePrinter.Click += new System.EventHandler(this.tsmiChangePrinter_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 122);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbMiddle);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbBottom);
            this.scMain.Size = new System.Drawing.Size(992, 651);
            this.scMain.SplitterDistance = 350;
            this.scMain.TabIndex = 8;
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 0);
            this.gbMiddle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbMiddle.Size = new System.Drawing.Size(992, 350);
            this.gbMiddle.TabIndex = 8;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "查询结果";
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
            this.colHID,
            this.colHCreateDate,
            this.colHDocDate,
            this.colHPostDate,
            this.colHVoucherNo,
            this.colHDeliveryNo,
            this.colHSupplierNo,
            this.colHSupplierName,
            this.colHPlant,
            this.colHMoveType,
            this.colHMaterialDoc,
            this.colHPrintTime});
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
            this.dgvList.Size = new System.Drawing.Size(986, 306);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvList_RowPostPaint);
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            // 
            // colHCreateDate
            // 
            this.colHCreateDate.DataPropertyName = "CreateDate";
            this.colHCreateDate.HeaderText = "CreateDate";
            this.colHCreateDate.Name = "colHCreateDate";
            this.colHCreateDate.ReadOnly = true;
            this.colHCreateDate.Visible = false;
            // 
            // colHDocDate
            // 
            this.colHDocDate.DataPropertyName = "DocDate";
            this.colHDocDate.HeaderText = "凭证日期";
            this.colHDocDate.Name = "colHDocDate";
            this.colHDocDate.ReadOnly = true;
            // 
            // colHPostDate
            // 
            this.colHPostDate.DataPropertyName = "PostDate";
            this.colHPostDate.HeaderText = "记账日期";
            this.colHPostDate.Name = "colHPostDate";
            this.colHPostDate.ReadOnly = true;
            // 
            // colHVoucherNo
            // 
            this.colHVoucherNo.DataPropertyName = "VoucherNo";
            this.colHVoucherNo.HeaderText = "采购订单";
            this.colHVoucherNo.Name = "colHVoucherNo";
            this.colHVoucherNo.ReadOnly = true;
            // 
            // colHDeliveryNo
            // 
            this.colHDeliveryNo.DataPropertyName = "DeliveryNo";
            this.colHDeliveryNo.HeaderText = "送货单号";
            this.colHDeliveryNo.Name = "colHDeliveryNo";
            this.colHDeliveryNo.ReadOnly = true;
            // 
            // colHSupplierNo
            // 
            this.colHSupplierNo.DataPropertyName = "SupCode";
            this.colHSupplierNo.HeaderText = "供应商代码";
            this.colHSupplierNo.Name = "colHSupplierNo";
            this.colHSupplierNo.ReadOnly = true;
            // 
            // colHSupplierName
            // 
            this.colHSupplierName.DataPropertyName = "SupName";
            this.colHSupplierName.HeaderText = "供应商名称";
            this.colHSupplierName.Name = "colHSupplierName";
            this.colHSupplierName.ReadOnly = true;
            this.colHSupplierName.Width = 200;
            // 
            // colHPlant
            // 
            this.colHPlant.DataPropertyName = "Plant";
            this.colHPlant.HeaderText = "工厂";
            this.colHPlant.Name = "colHPlant";
            this.colHPlant.ReadOnly = true;
            // 
            // colHMoveType
            // 
            this.colHMoveType.DataPropertyName = "MoveType";
            this.colHMoveType.HeaderText = "移动类型";
            this.colHMoveType.Name = "colHMoveType";
            this.colHMoveType.ReadOnly = true;
            this.colHMoveType.Visible = false;
            // 
            // colHMaterialDoc
            // 
            this.colHMaterialDoc.DataPropertyName = "MaterialDoc";
            this.colHMaterialDoc.HeaderText = "物料凭证";
            this.colHMaterialDoc.Name = "colHMaterialDoc";
            this.colHMaterialDoc.ReadOnly = true;
            // 
            // colHPrintTime
            // 
            this.colHPrintTime.DataPropertyName = "PrintTime";
            this.colHPrintTime.HeaderText = "最后打印事件";
            this.colHPrintTime.Name = "colHPrintTime";
            this.colHPrintTime.ReadOnly = true;
            this.colHPrintTime.Width = 130;
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
            this.pageList.Location = new System.Drawing.Point(3, 326);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dgvDetail);
            this.gbBottom.Controls.Add(this.pageDetail);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 0);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(992, 297);
            this.gbBottom.TabIndex = 9;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "送检明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBID,
            this.colBRowNo,
            this.colBMaterialNo,
            this.colBMaterialDesc,
            this.colBReceiveQty,
            this.colBUnit,
            this.colBPrdVersion});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetail.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvDetail.GridColor = System.Drawing.Color.LightGray;
            this.dgvDetail.HaveCopyMenu = true;
            this.dgvDetail.Location = new System.Drawing.Point(3, 19);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvDetail.RowHeadersVisible = false;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(986, 255);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // colBID
            // 
            this.colBID.DataPropertyName = "ID";
            this.colBID.HeaderText = "ID";
            this.colBID.Name = "colBID";
            this.colBID.ReadOnly = true;
            this.colBID.Visible = false;
            // 
            // colBRowNo
            // 
            this.colBRowNo.DataPropertyName = "RowNo";
            this.colBRowNo.HeaderText = "行号";
            this.colBRowNo.Name = "colBRowNo";
            this.colBRowNo.ReadOnly = true;
            // 
            // colBMaterialNo
            // 
            this.colBMaterialNo.DataPropertyName = "MaterialNo";
            this.colBMaterialNo.HeaderText = "物料编号";
            this.colBMaterialNo.Name = "colBMaterialNo";
            this.colBMaterialNo.ReadOnly = true;
            // 
            // colBMaterialDesc
            // 
            this.colBMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colBMaterialDesc.HeaderText = "物料描述";
            this.colBMaterialDesc.Name = "colBMaterialDesc";
            this.colBMaterialDesc.ReadOnly = true;
            this.colBMaterialDesc.Width = 200;
            // 
            // colBReceiveQty
            // 
            this.colBReceiveQty.DataPropertyName = "ReceiveQty";
            this.colBReceiveQty.HeaderText = "收货数量";
            this.colBReceiveQty.Name = "colBReceiveQty";
            this.colBReceiveQty.ReadOnly = true;
            // 
            // colBUnit
            // 
            this.colBUnit.DataPropertyName = "Unit";
            this.colBUnit.HeaderText = "计量单位";
            this.colBUnit.Name = "colBUnit";
            this.colBUnit.ReadOnly = true;
            // 
            // colBPrdVersion
            // 
            this.colBPrdVersion.DataPropertyName = "PrdVersion";
            this.colBPrdVersion.HeaderText = "产品版本";
            this.colBPrdVersion.Name = "colBPrdVersion";
            this.colBPrdVersion.ReadOnly = true;
            // 
            // pageDetail
            // 
            this.pageDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageDetail.CurrentPageNumber = 0;
            dividPage4.CurrentPageNumber = 0;
            dividPage4.CurrentPageRecordCounts = 0;
            dividPage4.CurrentPageShowCounts = 10;
            dividPage4.DefaultPageShowCounts = 10;
            dividPage4.PagesCount = 0;
            dividPage4.RecordCounts = 0;
            this.pageDetail.dDividPage = dividPage4;
            this.pageDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageDetail.Location = new System.Drawing.Point(3, 274);
            this.pageDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageDetail.Name = "pageDetail";
            this.pageDetail.Size = new System.Drawing.Size(986, 20);
            this.pageDetail.TabIndex = 0;
            this.pageDetail.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageDetail_ChensPageChange);
            // 
            // FrmCensorshipPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmCensorshipPrint";
            this.Text = "送检单打印";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCensorshipPrint_FormClosed);
            this.Load += new System.EventHandler(this.FrmCensorshipPrint_Load);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtMaterialDoc;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensDateTimePicker dtpEndDate;
        private ChensControl.ChensDateTimePicker dtpStartDate;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.SplitContainer scMain;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvDetail;
        private ChensControl.ChensPage pageDetail;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtDeliveryNo;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBPrdVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPostDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVoucherNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDeliveryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupplierNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMoveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPrintTime;
    }
}