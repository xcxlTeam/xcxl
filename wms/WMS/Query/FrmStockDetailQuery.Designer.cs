namespace WMS.Query
{
    partial class FrmStockDetailQuery
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
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.dtpBeginTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtAreaNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtHouseNo = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtBarcode = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtSN = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStockType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHstrStockType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.msMain.TabIndex = 4;
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
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.dtpBeginTime);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.txtAreaNo);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.txtHouseNo);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.txtWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.txtBarcode);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtSN);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 130);
            this.gbHeader.TabIndex = 5;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(329, 93);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 34;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(267, 98);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(34, 17);
            this.chensLabel7.TabIndex = 33;
            this.chensLabel7.Text = "——";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Checked = false;
            this.dtpBeginTime.Location = new System.Drawing.Point(87, 93);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.ShowCheckBox = true;
            this.dtpBeginTime.Size = new System.Drawing.Size(150, 23);
            this.dtpBeginTime.TabIndex = 32;
            this.dtpBeginTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(25, 95);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 31;
            this.chensLabel8.Text = "入库日期";
            // 
            // txtAreaNo
            // 
            this.txtAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "AreaNo", true));
            this.txtAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaNo.HotTrack = false;
            this.txtAreaNo.Location = new System.Drawing.Point(571, 23);
            this.txtAreaNo.Name = "txtAreaNo";
            this.txtAreaNo.Size = new System.Drawing.Size(150, 23);
            this.txtAreaNo.TabIndex = 30;
            this.txtAreaNo.TextEnabled = false;
            this.txtAreaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Stock_Model);
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(509, 25);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 29;
            this.chensLabel6.Text = "库存货位";
            // 
            // txtHouseNo
            // 
            this.txtHouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "HouseNo", true));
            this.txtHouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtHouseNo.HotTrack = false;
            this.txtHouseNo.Location = new System.Drawing.Point(329, 23);
            this.txtHouseNo.Name = "txtHouseNo";
            this.txtHouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtHouseNo.TabIndex = 28;
            this.txtHouseNo.TextEnabled = false;
            this.txtHouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(267, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 27;
            this.chensLabel1.Text = "库存库区";
            // 
            // txtWarehouseNo
            // 
            this.txtWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "WarehouseNo", true));
            this.txtWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseNo.HotTrack = false;
            this.txtWarehouseNo.Location = new System.Drawing.Point(87, 23);
            this.txtWarehouseNo.Name = "txtWarehouseNo";
            this.txtWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWarehouseNo.TabIndex = 26;
            this.txtWarehouseNo.TextEnabled = false;
            this.txtWarehouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 25;
            this.chensLabel2.Text = "库存仓库";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SerialNo", true));
            this.txtBarcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBarcode.HotTrack = false;
            this.txtBarcode.Location = new System.Drawing.Point(571, 58);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(150, 23);
            this.txtBarcode.TabIndex = 4;
            this.txtBarcode.TextEnabled = false;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(32, 17);
            this.chensLabel5.TabIndex = 9;
            this.chensLabel5.Text = "条码";
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
            this.txtSN.TabIndex = 8;
            this.txtSN.TextEnabled = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(267, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(32, 17);
            this.chensLabel4.TabIndex = 7;
            this.chensLabel4.Text = "批号";
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
            this.txtMaterialNo.TabIndex = 6;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 60);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 5;
            this.chensLabel3.Text = "库存物料";
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
            this.gbBottom.Location = new System.Drawing.Point(0, 155);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 618);
            this.gbBottom.TabIndex = 6;
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
            this.colHStockType,
            this.colHstrStockType,
            this.colHBatchNo,
            this.colHSN,
            this.colHMaterialNo,
            this.colHMaterialDesc,
            this.colHBarcode,
            this.colHWarehouseNo,
            this.colHWarehouseName,
            this.colHHouseNo,
            this.colHHouseName,
            this.colHAreaNo,
            this.colHAreaName,
            this.colHQty,
            this.colHCreater,
            this.colHCreateTime});
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
            this.dgvList.Size = new System.Drawing.Size(986, 574);
            this.dgvList.TabIndex = 2;
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
            this.pageList.Location = new System.Drawing.Point(3, 594);
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
            // colHStockType
            // 
            this.colHStockType.DataPropertyName = "StockType";
            this.colHStockType.HeaderText = "库存类型";
            this.colHStockType.Name = "colHStockType";
            this.colHStockType.ReadOnly = true;
            this.colHStockType.Visible = false;
            // 
            // colHstrStockType
            // 
            this.colHstrStockType.DataPropertyName = "strStockType";
            this.colHstrStockType.HeaderText = "库存类型";
            this.colHstrStockType.Name = "colHstrStockType";
            this.colHstrStockType.ReadOnly = true;
            this.colHstrStockType.Visible = false;
            // 
            // colHBatchNo
            // 
            this.colHBatchNo.DataPropertyName = "BatchNo";
            this.colHBatchNo.HeaderText = "批号";
            this.colHBatchNo.Name = "colHBatchNo";
            this.colHBatchNo.ReadOnly = true;
            // 
            // colHSN
            // 
            this.colHSN.DataPropertyName = "SN";
            this.colHSN.HeaderText = "原厂批次";
            this.colHSN.Name = "colHSN";
            this.colHSN.ReadOnly = true;
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
            // colHBarcode
            // 
            this.colHBarcode.DataPropertyName = "Barcode";
            this.colHBarcode.HeaderText = "条码";
            this.colHBarcode.Name = "colHBarcode";
            this.colHBarcode.ReadOnly = true;
            this.colHBarcode.Width = 250;
            // 
            // colHWarehouseNo
            // 
            this.colHWarehouseNo.DataPropertyName = "WarehouseNo";
            this.colHWarehouseNo.HeaderText = "仓库编号";
            this.colHWarehouseNo.Name = "colHWarehouseNo";
            this.colHWarehouseNo.ReadOnly = true;
            this.colHWarehouseNo.Visible = false;
            // 
            // colHWarehouseName
            // 
            this.colHWarehouseName.DataPropertyName = "WarehouseName";
            this.colHWarehouseName.HeaderText = "仓库名称";
            this.colHWarehouseName.Name = "colHWarehouseName";
            this.colHWarehouseName.ReadOnly = true;
            // 
            // colHHouseNo
            // 
            this.colHHouseNo.DataPropertyName = "HouseNo";
            this.colHHouseNo.HeaderText = "库区编号";
            this.colHHouseNo.Name = "colHHouseNo";
            this.colHHouseNo.ReadOnly = true;
            this.colHHouseNo.Visible = false;
            // 
            // colHHouseName
            // 
            this.colHHouseName.DataPropertyName = "HouseName";
            this.colHHouseName.HeaderText = "库区名称";
            this.colHHouseName.Name = "colHHouseName";
            this.colHHouseName.ReadOnly = true;
            // 
            // colHAreaNo
            // 
            this.colHAreaNo.DataPropertyName = "AreaNo";
            this.colHAreaNo.HeaderText = "货位编号";
            this.colHAreaNo.Name = "colHAreaNo";
            this.colHAreaNo.ReadOnly = true;
            this.colHAreaNo.Visible = false;
            // 
            // colHAreaName
            // 
            this.colHAreaName.DataPropertyName = "AreaName";
            this.colHAreaName.HeaderText = "货位名称";
            this.colHAreaName.Name = "colHAreaName";
            this.colHAreaName.ReadOnly = true;
            // 
            // colHQty
            // 
            this.colHQty.DataPropertyName = "Qty";
            this.colHQty.HeaderText = "库存数量";
            this.colHQty.Name = "colHQty";
            this.colHQty.ReadOnly = true;
            // 
            // colHCreater
            // 
            this.colHCreater.DataPropertyName = "Creater";
            this.colHCreater.HeaderText = "入库人";
            this.colHCreater.Name = "colHCreater";
            this.colHCreater.ReadOnly = true;
            this.colHCreater.Visible = false;
            // 
            // colHCreateTime
            // 
            this.colHCreateTime.DataPropertyName = "CreateTime";
            this.colHCreateTime.HeaderText = "入库时间";
            this.colHCreateTime.Name = "colHCreateTime";
            this.colHCreateTime.ReadOnly = true;
            // 
            // FrmStockDetailQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmStockDetailQuery";
            this.Text = "库存明细查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmStockDetailQuery_FormClosed);
            this.Load += new System.EventHandler(this.FrmStockDetailQuery_Load);
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
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtSN;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private ChensControl.ChensTextBox txtBarcode;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtAreaNo;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtHouseNo;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensDateTimePicker dtpBeginTime;
        private ChensControl.ChensLabel chensLabel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStockType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHstrStockType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
    }
}