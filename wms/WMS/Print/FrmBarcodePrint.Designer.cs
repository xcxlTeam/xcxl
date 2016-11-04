namespace WMS.Print
{
    partial class FrmBarcodePrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBARCODENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDELIVERYNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVOUCHERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colROWNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colPrintQty = new ChensControl.ChensDataGridViewNumericUpDownColumn();
            this.pageList = new ChensControl.ChensPage();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtSerialNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.txtAreaNo = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtHouseNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtSN = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtBatchNo = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.btnSearch = new ChensControl.ChensButton();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.cbxSelectAll);
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 155);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 618);
            this.gbMiddle.TabIndex = 9;
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
            this.colAreaNo,
            this.colHouseNo,
            this.colWarehouseNo,
            this.colAreaName,
            this.colHouseName,
            this.colWarehouseName,
            this.colCreateTime,
            this.colBARCODENO,
            this.colSERIALNO,
            this.colStrVoucherType,
            this.colDELIVERYNO,
            this.colVOUCHERNO,
            this.colROWNO,
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
            this.dgvList.Size = new System.Drawing.Size(986, 576);
            this.dgvList.TabIndex = 1;
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvList_Scroll);
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
            // colAreaNo
            // 
            this.colAreaNo.DataPropertyName = "AreaNo";
            this.colAreaNo.HeaderText = "货位编号";
            this.colAreaNo.Name = "colAreaNo";
            this.colAreaNo.ReadOnly = true;
            // 
            // colHouseNo
            // 
            this.colHouseNo.DataPropertyName = "HouseNo";
            this.colHouseNo.HeaderText = "库区编号";
            this.colHouseNo.Name = "colHouseNo";
            this.colHouseNo.ReadOnly = true;
            // 
            // colWarehouseNo
            // 
            this.colWarehouseNo.DataPropertyName = "WarehouseNo";
            this.colWarehouseNo.HeaderText = "仓库编号";
            this.colWarehouseNo.Name = "colWarehouseNo";
            this.colWarehouseNo.ReadOnly = true;
            // 
            // colAreaName
            // 
            this.colAreaName.DataPropertyName = "AreaName";
            this.colAreaName.HeaderText = "货位名称";
            this.colAreaName.Name = "colAreaName";
            this.colAreaName.ReadOnly = true;
            this.colAreaName.Visible = false;
            // 
            // colHouseName
            // 
            this.colHouseName.DataPropertyName = "HouseName";
            this.colHouseName.HeaderText = "库区名称";
            this.colHouseName.Name = "colHouseName";
            this.colHouseName.ReadOnly = true;
            this.colHouseName.Visible = false;
            // 
            // colWarehouseName
            // 
            this.colWarehouseName.DataPropertyName = "WarehouseName";
            this.colWarehouseName.HeaderText = "仓库名称";
            this.colWarehouseName.Name = "colWarehouseName";
            this.colWarehouseName.ReadOnly = true;
            this.colWarehouseName.Visible = false;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "CreateTime";
            this.colCreateTime.HeaderText = "库存时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
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
            // colStrVoucherType
            // 
            this.colStrVoucherType.DataPropertyName = "StrVoucherType";
            this.colStrVoucherType.HeaderText = "入库类型";
            this.colStrVoucherType.Name = "colStrVoucherType";
            this.colStrVoucherType.ReadOnly = true;
            // 
            // colDELIVERYNO
            // 
            this.colDELIVERYNO.DataPropertyName = "DELIVERYNO";
            this.colDELIVERYNO.HeaderText = "单据编号";
            this.colDELIVERYNO.Name = "colDELIVERYNO";
            this.colDELIVERYNO.ReadOnly = true;
            // 
            // colVOUCHERNO
            // 
            this.colVOUCHERNO.DataPropertyName = "VOUCHERNO";
            this.colVOUCHERNO.HeaderText = "单据编号";
            this.colVOUCHERNO.Name = "colVOUCHERNO";
            this.colVOUCHERNO.ReadOnly = true;
            this.colVOUCHERNO.Visible = false;
            // 
            // colROWNO
            // 
            this.colROWNO.DataPropertyName = "ROWNO";
            this.colROWNO.HeaderText = "行号";
            this.colROWNO.Name = "colROWNO";
            this.colROWNO.ReadOnly = true;
            this.colROWNO.Visible = false;
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
            this.colDepartment.Visible = false;
            // 
            // colReason
            // 
            this.colReason.DataPropertyName = "Reason";
            this.colReason.HeaderText = "退仓原因";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            this.colReason.Visible = false;
            // 
            // colTrackNo
            // 
            this.colTrackNo.DataPropertyName = "TrackNo";
            this.colTrackNo.HeaderText = "生产订单号";
            this.colTrackNo.Name = "colTrackNo";
            this.colTrackNo.ReadOnly = true;
            this.colTrackNo.Visible = false;
            // 
            // colReserveNumber
            // 
            this.colReserveNumber.DataPropertyName = "ReserveNumber";
            this.colReserveNumber.HeaderText = "预留项目号";
            this.colReserveNumber.Name = "colReserveNumber";
            this.colReserveNumber.ReadOnly = true;
            this.colReserveNumber.Visible = false;
            // 
            // colReserveRowNo
            // 
            this.colReserveRowNo.DataPropertyName = "ReserveRowNo";
            this.colReserveRowNo.HeaderText = "预留行号";
            this.colReserveRowNo.Name = "colReserveRowNo";
            this.colReserveRowNo.ReadOnly = true;
            this.colReserveRowNo.Visible = false;
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
            this.pageList.Location = new System.Drawing.Point(3, 595);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 0;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtSerialNo);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.txtAreaNo);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.txtHouseNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.txtWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtSN);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.txtBatchNo);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.dtpStartTime);
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
            // txtSerialNo
            // 
            this.txtSerialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SERIALNO", true));
            this.txtSerialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSerialNo.HotTrack = false;
            this.txtSerialNo.Location = new System.Drawing.Point(87, 93);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(150, 23);
            this.txtSerialNo.TabIndex = 7;
            this.txtSerialNo.TextEnabled = false;
            this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(25, 95);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(44, 17);
            this.chensLabel9.TabIndex = 34;
            this.chensLabel9.Text = "流水号";
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
            this.txtAreaNo.TabIndex = 3;
            this.txtAreaNo.TextEnabled = false;
            this.txtAreaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(509, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 33;
            this.chensLabel1.Text = "库存货位";
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
            this.txtHouseNo.TabIndex = 2;
            this.txtHouseNo.TextEnabled = false;
            this.txtHouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 31;
            this.chensLabel2.Text = "库存库区";
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
            this.txtWarehouseNo.TabIndex = 1;
            this.txtWarehouseNo.TextEnabled = false;
            this.txtWarehouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(25, 25);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 29;
            this.chensLabel5.Text = "库存仓库";
            // 
            // txtSN
            // 
            this.txtSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SN", true));
            this.txtSN.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSN.HotTrack = false;
            this.txtSN.Location = new System.Drawing.Point(329, 93);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(150, 23);
            this.txtSN.TabIndex = 8;
            this.txtSN.TextEnabled = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(267, 95);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 27;
            this.chensLabel7.Text = "来料批次";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MATERIALNO", true));
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(87, 58);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 4;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(25, 60);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 25;
            this.chensLabel8.Text = "库存物料";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "BATCHNO", true));
            this.txtBatchNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBatchNo.HotTrack = false;
            this.txtBatchNo.Location = new System.Drawing.Point(571, 90);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(150, 23);
            this.txtBatchNo.TabIndex = 9;
            this.txtBatchNo.TextEnabled = false;
            this.txtBatchNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(509, 95);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 11;
            this.chensLabel6.Text = "生产批次";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(571, 58);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 6;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(509, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(34, 17);
            this.chensLabel4.TabIndex = 7;
            this.chensLabel4.Text = "——";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(267, 60);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 6;
            this.chensLabel3.Text = "库存日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(329, 58);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 5;
            this.dtpStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
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
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiPrint,
            this.tsmiImport,
            this.tsmiDeal,
            this.tsmiChangePrinter});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
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
            this.tsmiPrint.Text = "标签打印";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiImport.Size = new System.Drawing.Size(68, 21);
            this.tsmiImport.Text = "导入库存";
            this.tsmiImport.Visible = false;
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiDeal
            // 
            this.tsmiDeal.AutoToolTip = true;
            this.tsmiDeal.Name = "tsmiDeal";
            this.tsmiDeal.Size = new System.Drawing.Size(68, 21);
            this.tsmiDeal.Text = "处理库存";
            this.tsmiDeal.ToolTipText = "手工导入库存数据后使用";
            this.tsmiDeal.Visible = false;
            this.tsmiDeal.Click += new System.EventHandler(this.tsmiDeal_Click);
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(80, 21);
            this.tsmiChangePrinter.Text = "设置打印机";
            this.tsmiChangePrinter.Click += new System.EventHandler(this.tsmiChangePrinter_Click);
            // 
            // FrmBarcodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmBarcodePrint";
            this.Text = "库存标签打印";
            this.Load += new System.EventHandler(this.FrmBarcodePrint_Load);
            this.gbMiddle.ResumeLayout(false);
            this.gbMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeal;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtBatchNo;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbMiddle;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensTextBox txtAreaNo;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtHouseNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtSN;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensTextBox txtSerialNo;
        private System.Windows.Forms.BindingSource bsMain;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBARCODENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDELIVERYNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVOUCHERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colROWNO;
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
        private ChensControl.ChensDataGridViewNumericUpDownColumn colPrintQty;
    }
}