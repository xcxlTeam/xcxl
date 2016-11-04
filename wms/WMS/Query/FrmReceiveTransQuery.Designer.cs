namespace WMS.Query
{
    partial class FrmReceiveTransQuery
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
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.chensTextBox1 = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtTaskNo = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtSerialNo = new ChensControl.ChensTextBox();
            this.txtSN = new ChensControl.ChensTextBox();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtSupplierNo = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtDeliveryNo = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDeliveryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVoucherNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDeliveryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReceiveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupplierNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.msMain.TabIndex = 6;
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
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.chensLabel10);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.chensTextBox1);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.txtTaskNo);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.txtSerialNo);
            this.gbHeader.Controls.Add(this.txtSN);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.txtSupplierNo);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.txtVoucherNo);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.txtDeliveryNo);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 165);
            this.gbHeader.TabIndex = 7;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(329, 128);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 36;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(267, 130);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(34, 17);
            this.chensLabel9.TabIndex = 38;
            this.chensLabel9.Text = "——";
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(25, 130);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 37;
            this.chensLabel10.Text = "收货日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(87, 128);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 35;
            this.dtpStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensTextBox1
            // 
            this.chensTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Creater", true));
            this.chensTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox1.HotTrack = false;
            this.chensTextBox1.Location = new System.Drawing.Point(329, 93);
            this.chensTextBox1.Name = "chensTextBox1";
            this.chensTextBox1.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox1.TabIndex = 34;
            this.chensTextBox1.TextEnabled = false;
            this.chensTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.ReceiveTransInfo);
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(267, 95);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(44, 17);
            this.chensLabel8.TabIndex = 33;
            this.chensLabel8.Text = "收货人";
            // 
            // txtTaskNo
            // 
            this.txtTaskNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTaskNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "TaskNo", true));
            this.txtTaskNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTaskNo.HotTrack = false;
            this.txtTaskNo.Location = new System.Drawing.Point(87, 93);
            this.txtTaskNo.Name = "txtTaskNo";
            this.txtTaskNo.Size = new System.Drawing.Size(150, 23);
            this.txtTaskNo.TabIndex = 32;
            this.txtTaskNo.TextEnabled = false;
            this.txtTaskNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 95);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 31;
            this.chensLabel7.Text = "任务编号";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SerialNo", true));
            this.txtSerialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSerialNo.HotTrack = false;
            this.txtSerialNo.Location = new System.Drawing.Point(559, 58);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(150, 23);
            this.txtSerialNo.TabIndex = 30;
            this.txtSerialNo.TextEnabled = false;
            this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtSN
            // 
            this.txtSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SN", true));
            this.txtSN.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSN.HotTrack = false;
            this.txtSN.Location = new System.Drawing.Point(329, 58);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(150, 23);
            this.txtSN.TabIndex = 29;
            this.txtSN.TextEnabled = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialNo", true));
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(87, 58);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 28;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(44, 17);
            this.chensLabel5.TabIndex = 27;
            this.chensLabel5.Text = "流水号";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 60);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 26;
            this.chensLabel2.Text = "来料批次";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 25;
            this.chensLabel1.Text = "收货物料";
            // 
            // txtSupplierNo
            // 
            this.txtSupplierNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupplierNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SupplierNo", true));
            this.txtSupplierNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupplierNo.HotTrack = false;
            this.txtSupplierNo.Location = new System.Drawing.Point(559, 23);
            this.txtSupplierNo.Name = "txtSupplierNo";
            this.txtSupplierNo.Size = new System.Drawing.Size(150, 23);
            this.txtSupplierNo.TabIndex = 24;
            this.txtSupplierNo.TextEnabled = false;
            this.txtSupplierNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(509, 25);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(44, 17);
            this.chensLabel6.TabIndex = 23;
            this.chensLabel6.Text = "供应商";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "VoucherNo", true));
            this.txtVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVoucherNo.HotTrack = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(329, 23);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 22;
            this.txtVoucherNo.TextEnabled = false;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(267, 25);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 21;
            this.chensLabel4.Text = "采购单号";
            // 
            // txtDeliveryNo
            // 
            this.txtDeliveryNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDeliveryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "DeliveryNo", true));
            this.txtDeliveryNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDeliveryNo.HotTrack = false;
            this.txtDeliveryNo.Location = new System.Drawing.Point(87, 23);
            this.txtDeliveryNo.Name = "txtDeliveryNo";
            this.txtDeliveryNo.Size = new System.Drawing.Size(150, 23);
            this.txtDeliveryNo.TabIndex = 20;
            this.txtDeliveryNo.TextEnabled = false;
            this.txtDeliveryNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 19;
            this.chensLabel3.Text = "送货单号";
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
            this.gbBottom.Location = new System.Drawing.Point(0, 190);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 582);
            this.gbBottom.TabIndex = 8;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "查询结果";
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
            this.colHID,
            this.colHTaskNo,
            this.colHDeliveryNo,
            this.colHVoucherNo,
            this.colHRowNo,
            this.colHDeliveryQty,
            this.colHMaterialNo,
            this.colHMaterialDesc,
            this.colHReceiveType,
            this.colHSupplierNo,
            this.colHSupplierName,
            this.colHMaterialDoc,
            this.colHMaterialDocDate,
            this.colHReceiveQty,
            this.colHPackCount,
            this.colHBarcode,
            this.colHSN,
            this.colHSerialNo,
            this.colHCreater,
            this.colHCreateDate});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
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
            this.dgvList.Size = new System.Drawing.Size(986, 538);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
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
            this.pageList.Location = new System.Drawing.Point(3, 558);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            // 
            // colHTaskNo
            // 
            this.colHTaskNo.DataPropertyName = "TaskNo";
            this.colHTaskNo.HeaderText = "任务编号";
            this.colHTaskNo.Name = "colHTaskNo";
            this.colHTaskNo.ReadOnly = true;
            // 
            // colHDeliveryNo
            // 
            this.colHDeliveryNo.DataPropertyName = "DeliveryNo";
            this.colHDeliveryNo.HeaderText = "收货单号";
            this.colHDeliveryNo.Name = "colHDeliveryNo";
            this.colHDeliveryNo.ReadOnly = true;
            // 
            // colHVoucherNo
            // 
            this.colHVoucherNo.DataPropertyName = "VoucherNo";
            this.colHVoucherNo.HeaderText = "采购订单号";
            this.colHVoucherNo.Name = "colHVoucherNo";
            this.colHVoucherNo.ReadOnly = true;
            // 
            // colHRowNo
            // 
            this.colHRowNo.DataPropertyName = "RowNo";
            this.colHRowNo.HeaderText = "订单行号";
            this.colHRowNo.Name = "colHRowNo";
            this.colHRowNo.ReadOnly = true;
            // 
            // colHDeliveryQty
            // 
            this.colHDeliveryQty.DataPropertyName = "DeliveryQty";
            this.colHDeliveryQty.HeaderText = "发货单数量";
            this.colHDeliveryQty.Name = "colHDeliveryQty";
            this.colHDeliveryQty.ReadOnly = true;
            this.colHDeliveryQty.Visible = false;
            // 
            // colHMaterialNo
            // 
            this.colHMaterialNo.DataPropertyName = "MaterialNo";
            this.colHMaterialNo.HeaderText = "物料编号";
            this.colHMaterialNo.Name = "colHMaterialNo";
            this.colHMaterialNo.ReadOnly = true;
            this.colHMaterialNo.Width = 150;
            // 
            // colHMaterialDesc
            // 
            this.colHMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colHMaterialDesc.HeaderText = "物料描述";
            this.colHMaterialDesc.Name = "colHMaterialDesc";
            this.colHMaterialDesc.ReadOnly = true;
            this.colHMaterialDesc.Width = 200;
            // 
            // colHReceiveType
            // 
            this.colHReceiveType.DataPropertyName = "ReceiveType";
            this.colHReceiveType.HeaderText = "收货类型";
            this.colHReceiveType.Name = "colHReceiveType";
            this.colHReceiveType.ReadOnly = true;
            // 
            // colHSupplierNo
            // 
            this.colHSupplierNo.DataPropertyName = "SupplierNo";
            this.colHSupplierNo.HeaderText = "供应商代码";
            this.colHSupplierNo.Name = "colHSupplierNo";
            this.colHSupplierNo.ReadOnly = true;
            // 
            // colHSupplierName
            // 
            this.colHSupplierName.DataPropertyName = "SupplierName";
            this.colHSupplierName.HeaderText = "供应商名称";
            this.colHSupplierName.Name = "colHSupplierName";
            this.colHSupplierName.ReadOnly = true;
            this.colHSupplierName.Width = 200;
            // 
            // colHMaterialDoc
            // 
            this.colHMaterialDoc.DataPropertyName = "MaterialDoc";
            this.colHMaterialDoc.HeaderText = "物料凭证";
            this.colHMaterialDoc.Name = "colHMaterialDoc";
            this.colHMaterialDoc.ReadOnly = true;
            // 
            // colHMaterialDocDate
            // 
            this.colHMaterialDocDate.DataPropertyName = "MaterialDocDate";
            this.colHMaterialDocDate.HeaderText = "凭证日期";
            this.colHMaterialDocDate.Name = "colHMaterialDocDate";
            this.colHMaterialDocDate.ReadOnly = true;
            // 
            // colHReceiveQty
            // 
            this.colHReceiveQty.DataPropertyName = "ReceiveQty";
            this.colHReceiveQty.HeaderText = "收货数量";
            this.colHReceiveQty.Name = "colHReceiveQty";
            this.colHReceiveQty.ReadOnly = true;
            // 
            // colHPackCount
            // 
            this.colHPackCount.DataPropertyName = "PackCount";
            this.colHPackCount.HeaderText = "收货箱数";
            this.colHPackCount.Name = "colHPackCount";
            this.colHPackCount.ReadOnly = true;
            this.colHPackCount.Visible = false;
            // 
            // colHBarcode
            // 
            this.colHBarcode.DataPropertyName = "Barcode";
            this.colHBarcode.HeaderText = "外箱条码";
            this.colHBarcode.Name = "colHBarcode";
            this.colHBarcode.ReadOnly = true;
            this.colHBarcode.Width = 250;
            // 
            // colHSN
            // 
            this.colHSN.DataPropertyName = "SN";
            this.colHSN.HeaderText = "来料批次";
            this.colHSN.Name = "colHSN";
            this.colHSN.ReadOnly = true;
            // 
            // colHSerialNo
            // 
            this.colHSerialNo.DataPropertyName = "SerialNo";
            this.colHSerialNo.HeaderText = "流水号";
            this.colHSerialNo.Name = "colHSerialNo";
            this.colHSerialNo.ReadOnly = true;
            // 
            // colHCreater
            // 
            this.colHCreater.DataPropertyName = "Creater";
            this.colHCreater.HeaderText = "收货人";
            this.colHCreater.Name = "colHCreater";
            this.colHCreater.ReadOnly = true;
            // 
            // colHCreateDate
            // 
            this.colHCreateDate.DataPropertyName = "CreateDate";
            this.colHCreateDate.HeaderText = "收货时间";
            this.colHCreateDate.Name = "colHCreateDate";
            this.colHCreateDate.ReadOnly = true;
            // 
            // FrmReceiveTransQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmReceiveTransQuery";
            this.Text = "历史收货记录查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReceiveTransQuery_FormClosed);
            this.Load += new System.EventHandler(this.FrmReceiveTransQuery_Load);
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
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.BindingSource bsMain;
        private ChensControl.ChensTextBox txtSupplierNo;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtDeliveryNo;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtSerialNo;
        private ChensControl.ChensTextBox txtSN;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensTextBox txtTaskNo;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox chensTextBox1;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDeliveryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVoucherNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDeliveryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReceiveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupplierNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateDate;
    }
}