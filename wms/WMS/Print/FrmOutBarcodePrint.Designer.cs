namespace WMS.Print
{
    partial class FrmOutBarcodePrint
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
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTest = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.lblVoucherNo = new ChensControl.ChensLabel();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.cbxShowSup = new ChensControl.ChensCheckBox();
            this.bsCreate = new System.Windows.Forms.BindingSource(this.components);
            this.txtReserveUser = new ChensControl.ChensTextBox();
            this.lblReserveUser = new ChensControl.ChensLabel();
            this.txtSupName = new ChensControl.ChensTextBox();
            this.lblSupName = new ChensControl.ChensLabel();
            this.txtSupCode = new ChensControl.ChensTextBox();
            this.lblSupCode = new ChensControl.ChensLabel();
            this.txtBatchQty = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtPrintQty = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.cbxOther = new ChensControl.ChensCheckBox();
            this.cbxPlatedTin = new ChensControl.ChensCheckBox();
            this.cbxPlatedSilver = new ChensControl.ChensCheckBox();
            this.txtOutPackQty = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtInnerPackQty = new ChensControl.ChensTextBox();
            this.lblInnerPackQty = new ChensControl.ChensLabel();
            this.txtBatchNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.colHReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReserveRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReserveNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCurrentlyDeliveryNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWaitDeliveryNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDeliveryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVoucherNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreate)).BeginInit();
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
            this.tsmiRePrint,
            this.tsmiChangePrinter,
            this.tsmiTest});
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
            this.tsmiSearch.Text = "查询订单";
            this.tsmiSearch.Visible = false;
            this.tsmiSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrint.Text = "外箱打印";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiRePrint
            // 
            this.tsmiRePrint.Name = "tsmiRePrint";
            this.tsmiRePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiRePrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiRePrint.Text = "标签重打";
            this.tsmiRePrint.Click += new System.EventHandler(this.tsmiRePrint_Click);
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(80, 21);
            this.tsmiChangePrinter.Text = "设置打印机";
            this.tsmiChangePrinter.Click += new System.EventHandler(this.tsmiChangePrinter_Click);
            // 
            // tsmiTest
            // 
            this.tsmiTest.Name = "tsmiTest";
            this.tsmiTest.Size = new System.Drawing.Size(68, 21);
            this.tsmiTest.Text = "打印测试";
            this.tsmiTest.Visible = false;
            this.tsmiTest.Click += new System.EventHandler(this.tsmiTest_Click);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtVoucherNo);
            this.gbHeader.Controls.Add(this.lblVoucherNo);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 27);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 60);
            this.gbHeader.TabIndex = 4;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
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
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.White;
            this.txtVoucherNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "VOUCHERNO", true));
            this.txtVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVoucherNo.HotTrack = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(87, 23);
            this.txtVoucherNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 1;
            this.txtVoucherNo.TextEnabled = false;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucherNo_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Barcode_Model);
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
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.cbxShowSup);
            this.gbBottom.Controls.Add(this.txtReserveUser);
            this.gbBottom.Controls.Add(this.lblReserveUser);
            this.gbBottom.Controls.Add(this.txtSupName);
            this.gbBottom.Controls.Add(this.lblSupName);
            this.gbBottom.Controls.Add(this.txtSupCode);
            this.gbBottom.Controls.Add(this.lblSupCode);
            this.gbBottom.Controls.Add(this.txtBatchQty);
            this.gbBottom.Controls.Add(this.chensLabel1);
            this.gbBottom.Controls.Add(this.txtPrintQty);
            this.gbBottom.Controls.Add(this.chensLabel7);
            this.gbBottom.Controls.Add(this.cbxOther);
            this.gbBottom.Controls.Add(this.cbxPlatedTin);
            this.gbBottom.Controls.Add(this.cbxPlatedSilver);
            this.gbBottom.Controls.Add(this.txtOutPackQty);
            this.gbBottom.Controls.Add(this.chensLabel6);
            this.gbBottom.Controls.Add(this.txtInnerPackQty);
            this.gbBottom.Controls.Add(this.lblInnerPackQty);
            this.gbBottom.Controls.Add(this.txtBatchNo);
            this.gbBottom.Controls.Add(this.chensLabel4);
            this.gbBottom.Controls.Add(this.txtMaterialDesc);
            this.gbBottom.Controls.Add(this.chensLabel3);
            this.gbBottom.Controls.Add(this.txtMaterialNo);
            this.gbBottom.Controls.Add(this.chensLabel2);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 572);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(992, 200);
            this.gbBottom.TabIndex = 6;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "打印参数";
            // 
            // cbxShowSup
            // 
            this.cbxShowSup.AutoSize = true;
            this.cbxShowSup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BSHOWSUP", true));
            this.cbxShowSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxShowSup.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxShowSup.Location = new System.Drawing.Point(535, 23);
            this.cbxShowSup.Name = "cbxShowSup";
            this.cbxShowSup.Size = new System.Drawing.Size(84, 21);
            this.cbxShowSup.TabIndex = 23;
            this.cbxShowSup.Text = "显示供应商";
            this.cbxShowSup.Textn = "显示供应商";
            this.cbxShowSup.UseVisualStyleBackColor = true;
            // 
            // bsCreate
            // 
            this.bsCreate.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // txtReserveUser
            // 
            this.txtReserveUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtReserveUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReserveUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "ReserveUser", true));
            this.txtReserveUser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtReserveUser.HotTrack = false;
            this.txtReserveUser.Location = new System.Drawing.Point(353, 163);
            this.txtReserveUser.Name = "txtReserveUser";
            this.txtReserveUser.Size = new System.Drawing.Size(150, 23);
            this.txtReserveUser.TabIndex = 22;
            this.txtReserveUser.TextEnabled = false;
            // 
            // lblReserveUser
            // 
            this.lblReserveUser.AutoSize = true;
            this.lblReserveUser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblReserveUser.Location = new System.Drawing.Point(279, 165);
            this.lblReserveUser.Name = "lblReserveUser";
            this.lblReserveUser.Size = new System.Drawing.Size(44, 17);
            this.lblReserveUser.TabIndex = 21;
            this.lblReserveUser.Text = "退仓人";
            // 
            // txtSupName
            // 
            this.txtSupName.BackColor = System.Drawing.Color.White;
            this.txtSupName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "SUPNAME", true));
            this.txtSupName.Enabled = false;
            this.txtSupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupName.HotTrack = false;
            this.txtSupName.Location = new System.Drawing.Point(353, 128);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(150, 23);
            this.txtSupName.TabIndex = 12;
            this.txtSupName.TextEnabled = false;
            this.txtSupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSupName_KeyPress);
            // 
            // lblSupName
            // 
            this.lblSupName.AutoSize = true;
            this.lblSupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSupName.Location = new System.Drawing.Point(279, 130);
            this.lblSupName.Name = "lblSupName";
            this.lblSupName.Size = new System.Drawing.Size(68, 17);
            this.lblSupName.TabIndex = 20;
            this.lblSupName.Text = "供应商名称";
            // 
            // txtSupCode
            // 
            this.txtSupCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "SUPCODE", true));
            this.txtSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupCode.HotTrack = false;
            this.txtSupCode.Location = new System.Drawing.Point(99, 128);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(150, 23);
            this.txtSupCode.TabIndex = 11;
            this.txtSupCode.TextEnabled = false;
            this.txtSupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSupCode_KeyPress);
            // 
            // lblSupCode
            // 
            this.lblSupCode.AutoSize = true;
            this.lblSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSupCode.Location = new System.Drawing.Point(25, 130);
            this.lblSupCode.Name = "lblSupCode";
            this.lblSupCode.Size = new System.Drawing.Size(68, 17);
            this.lblSupCode.TabIndex = 18;
            this.lblSupCode.Text = "供应商代码";
            // 
            // txtBatchQty
            // 
            this.txtBatchQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBatchQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "BATCHQTY", true));
            this.txtBatchQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBatchQty.HotTrack = false;
            this.txtBatchQty.Location = new System.Drawing.Point(353, 58);
            this.txtBatchQty.Name = "txtBatchQty";
            this.txtBatchQty.Size = new System.Drawing.Size(150, 23);
            this.txtBatchQty.TabIndex = 4;
            this.txtBatchQty.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(279, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(68, 17);
            this.chensLabel1.TabIndex = 17;
            this.chensLabel1.Text = "本批次数量";
            // 
            // txtPrintQty
            // 
            this.txtPrintQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPrintQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrintQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "PRINTQTY", true));
            this.txtPrintQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPrintQty.HotTrack = false;
            this.txtPrintQty.Location = new System.Drawing.Point(99, 163);
            this.txtPrintQty.Name = "txtPrintQty";
            this.txtPrintQty.Size = new System.Drawing.Size(150, 23);
            this.txtPrintQty.TabIndex = 15;
            this.txtPrintQty.TextEnabled = false;
            this.txtPrintQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrintQty_KeyPress);
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
            // cbxOther
            // 
            this.cbxOther.AutoSize = true;
            this.cbxOther.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedOther", true));
            this.cbxOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxOther.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxOther.Location = new System.Drawing.Point(175, 131);
            this.cbxOther.Name = "cbxOther";
            this.cbxOther.Size = new System.Drawing.Size(48, 21);
            this.cbxOther.TabIndex = 9;
            this.cbxOther.Text = "其他";
            this.cbxOther.Textn = "其他";
            this.cbxOther.UseVisualStyleBackColor = true;
            this.cbxOther.CheckedChanged += new System.EventHandler(this.cbxOther_CheckedChanged);
            // 
            // cbxPlatedTin
            // 
            this.cbxPlatedTin.AutoSize = true;
            this.cbxPlatedTin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedTin", true));
            this.cbxPlatedTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlatedTin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxPlatedTin.Location = new System.Drawing.Point(100, 130);
            this.cbxPlatedTin.Name = "cbxPlatedTin";
            this.cbxPlatedTin.Size = new System.Drawing.Size(48, 21);
            this.cbxPlatedTin.TabIndex = 8;
            this.cbxPlatedTin.Text = "镀锡";
            this.cbxPlatedTin.Textn = "镀锡";
            this.cbxPlatedTin.UseVisualStyleBackColor = true;
            this.cbxPlatedTin.CheckedChanged += new System.EventHandler(this.cbxPlatedTin_CheckedChanged);
            // 
            // cbxPlatedSilver
            // 
            this.cbxPlatedSilver.AutoSize = true;
            this.cbxPlatedSilver.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedSilver", true));
            this.cbxPlatedSilver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlatedSilver.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxPlatedSilver.Location = new System.Drawing.Point(25, 130);
            this.cbxPlatedSilver.Name = "cbxPlatedSilver";
            this.cbxPlatedSilver.Size = new System.Drawing.Size(48, 21);
            this.cbxPlatedSilver.TabIndex = 7;
            this.cbxPlatedSilver.Text = "镀银";
            this.cbxPlatedSilver.Textn = "镀银";
            this.cbxPlatedSilver.UseVisualStyleBackColor = true;
            this.cbxPlatedSilver.CheckedChanged += new System.EventHandler(this.cbxPlatedSilver_CheckedChanged);
            // 
            // txtOutPackQty
            // 
            this.txtOutPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOutPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutPackQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "OUTPACKQTY", true));
            this.txtOutPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOutPackQty.HotTrack = false;
            this.txtOutPackQty.Location = new System.Drawing.Point(99, 93);
            this.txtOutPackQty.Name = "txtOutPackQty";
            this.txtOutPackQty.Size = new System.Drawing.Size(150, 23);
            this.txtOutPackQty.TabIndex = 5;
            this.txtOutPackQty.TextEnabled = false;
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
            // txtInnerPackQty
            // 
            this.txtInnerPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtInnerPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInnerPackQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "INNERPACKQTY", true));
            this.txtInnerPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtInnerPackQty.HotTrack = false;
            this.txtInnerPackQty.Location = new System.Drawing.Point(353, 93);
            this.txtInnerPackQty.Name = "txtInnerPackQty";
            this.txtInnerPackQty.Size = new System.Drawing.Size(150, 23);
            this.txtInnerPackQty.TabIndex = 6;
            this.txtInnerPackQty.TextEnabled = false;
            // 
            // lblInnerPackQty
            // 
            this.lblInnerPackQty.AutoSize = true;
            this.lblInnerPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblInnerPackQty.Location = new System.Drawing.Point(279, 95);
            this.lblInnerPackQty.Name = "lblInnerPackQty";
            this.lblInnerPackQty.Size = new System.Drawing.Size(68, 17);
            this.lblInnerPackQty.TabIndex = 7;
            this.lblInnerPackQty.Text = "内盒包装量";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "BATCHNO", true));
            this.txtBatchNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBatchNo.HotTrack = false;
            this.txtBatchNo.Location = new System.Drawing.Point(99, 58);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(150, 23);
            this.txtBatchNo.TabIndex = 3;
            this.txtBatchNo.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 5;
            this.chensLabel4.Text = "生产批号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "MATERIALDESC", true));
            this.txtMaterialDesc.Enabled = false;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(353, 23);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDesc.TabIndex = 2;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(279, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 3;
            this.chensLabel3.Text = "物料描述";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "MATERIALNO", true));
            this.txtMaterialNo.Enabled = false;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(99, 23);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 1;
            this.txtMaterialNo.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "物料编号";
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 87);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 485);
            this.gbMiddle.TabIndex = 7;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "查询结果";
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
            this.colHMaterialNo,
            this.colHMaterialDesc,
            this.colHSupCode,
            this.colHSupName,
            this.colHVoucherNo,
            this.colHRowNo,
            this.colHDeliveryNo,
            this.colHWaitDeliveryNum,
            this.colHCurrentlyDeliveryNum,
            this.colHPlant,
            this.colHTrackNo,
            this.colHReserveNumber,
            this.colHReserveRowNo,
            this.colHDepartment,
            this.colHReason});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 443);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvList_RowPostPaint);
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
            this.pageList.Location = new System.Drawing.Point(3, 462);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 0;
            this.pageList.Visible = false;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // colHReason
            // 
            this.colHReason.DataPropertyName = "Reason";
            this.colHReason.HeaderText = "退仓原因";
            this.colHReason.Name = "colHReason";
            this.colHReason.ReadOnly = true;
            this.colHReason.Visible = false;
            // 
            // colHDepartment
            // 
            this.colHDepartment.DataPropertyName = "Department";
            this.colHDepartment.HeaderText = "退仓部门";
            this.colHDepartment.Name = "colHDepartment";
            this.colHDepartment.ReadOnly = true;
            this.colHDepartment.Visible = false;
            // 
            // colHReserveRowNo
            // 
            this.colHReserveRowNo.DataPropertyName = "ReserveRowNo";
            this.colHReserveRowNo.HeaderText = "预留行号";
            this.colHReserveRowNo.Name = "colHReserveRowNo";
            this.colHReserveRowNo.ReadOnly = true;
            this.colHReserveRowNo.Visible = false;
            // 
            // colHReserveNumber
            // 
            this.colHReserveNumber.DataPropertyName = "ReserveNumber";
            this.colHReserveNumber.HeaderText = "预留单号";
            this.colHReserveNumber.Name = "colHReserveNumber";
            this.colHReserveNumber.ReadOnly = true;
            this.colHReserveNumber.Visible = false;
            // 
            // colHTrackNo
            // 
            this.colHTrackNo.DataPropertyName = "TrackNo";
            this.colHTrackNo.HeaderText = "生产订单号";
            this.colHTrackNo.Name = "colHTrackNo";
            this.colHTrackNo.ReadOnly = true;
            this.colHTrackNo.Visible = false;
            // 
            // colHPlant
            // 
            this.colHPlant.DataPropertyName = "Plant";
            this.colHPlant.HeaderText = "工厂编号";
            this.colHPlant.Name = "colHPlant";
            this.colHPlant.ReadOnly = true;
            this.colHPlant.Visible = false;
            // 
            // colHCurrentlyDeliveryNum
            // 
            this.colHCurrentlyDeliveryNum.DataPropertyName = "CurrentlyDeliveryNum";
            this.colHCurrentlyDeliveryNum.HeaderText = "送货数量";
            this.colHCurrentlyDeliveryNum.Name = "colHCurrentlyDeliveryNum";
            this.colHCurrentlyDeliveryNum.ReadOnly = true;
            // 
            // colHWaitDeliveryNum
            // 
            this.colHWaitDeliveryNum.DataPropertyName = "WaitDeliveryNum";
            this.colHWaitDeliveryNum.HeaderText = "订单数量";
            this.colHWaitDeliveryNum.Name = "colHWaitDeliveryNum";
            this.colHWaitDeliveryNum.ReadOnly = true;
            this.colHWaitDeliveryNum.Visible = false;
            // 
            // colHDeliveryNo
            // 
            this.colHDeliveryNo.DataPropertyName = "DeliveryNo";
            this.colHDeliveryNo.HeaderText = "送货单号";
            this.colHDeliveryNo.Name = "colHDeliveryNo";
            this.colHDeliveryNo.ReadOnly = true;
            // 
            // colHRowNo
            // 
            this.colHRowNo.DataPropertyName = "RowNo";
            this.colHRowNo.HeaderText = "订单行号";
            this.colHRowNo.Name = "colHRowNo";
            this.colHRowNo.ReadOnly = true;
            this.colHRowNo.Visible = false;
            // 
            // colHVoucherNo
            // 
            this.colHVoucherNo.DataPropertyName = "VoucherNo";
            this.colHVoucherNo.HeaderText = "采购订单号";
            this.colHVoucherNo.Name = "colHVoucherNo";
            this.colHVoucherNo.ReadOnly = true;
            // 
            // colHSupName
            // 
            this.colHSupName.DataPropertyName = "SupName";
            this.colHSupName.HeaderText = "供应商名称";
            this.colHSupName.Name = "colHSupName";
            this.colHSupName.ReadOnly = true;
            // 
            // colHSupCode
            // 
            this.colHSupCode.DataPropertyName = "SupCode";
            this.colHSupCode.HeaderText = "供应商代码";
            this.colHSupCode.Name = "colHSupCode";
            this.colHSupCode.ReadOnly = true;
            // 
            // colHMaterialDesc
            // 
            this.colHMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colHMaterialDesc.HeaderText = "物料描述";
            this.colHMaterialDesc.Name = "colHMaterialDesc";
            this.colHMaterialDesc.ReadOnly = true;
            this.colHMaterialDesc.Width = 300;
            // 
            // colHMaterialNo
            // 
            this.colHMaterialNo.DataPropertyName = "MaterialNo";
            this.colHMaterialNo.HeaderText = "物料编号";
            this.colHMaterialNo.Name = "colHMaterialNo";
            this.colHMaterialNo.ReadOnly = true;
            this.colHMaterialNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHMaterialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHMaterialNo.Width = 150;
            // 
            // FrmOutBarcodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmOutBarcodePrint";
            this.Text = "外箱标签打印";
            this.Load += new System.EventHandler(this.FrmOutBarcodePrint_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreate)).EndInit();
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private System.Windows.Forms.ToolStripMenuItem tsmiRePrint;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel lblVoucherNo;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtInnerPackQty;
        private ChensControl.ChensLabel lblInnerPackQty;
        private ChensControl.ChensTextBox txtBatchNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtOutPackQty;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtPrintQty;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensCheckBox cbxOther;
        private ChensControl.ChensCheckBox cbxPlatedTin;
        private ChensControl.ChensCheckBox cbxPlatedSilver;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.BindingSource bsCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiTest;
        private ChensControl.ChensTextBox txtBatchQty;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtSupName;
        private ChensControl.ChensLabel lblSupName;
        private ChensControl.ChensTextBox txtSupCode;
        private ChensControl.ChensLabel lblSupCode;
        private ChensControl.ChensTextBox txtReserveUser;
        private ChensControl.ChensLabel lblReserveUser;
        private ChensControl.ChensCheckBox cbxShowSup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVoucherNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDeliveryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWaitDeliveryNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCurrentlyDeliveryNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReserveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReserveRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReason;
    }
}