namespace WMS.Query
{
    partial class FrmStockInQuery
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
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.txtAndalaNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.lblaAndalaNo = new ChensControl.ChensLabel();
            this.txtDeliveryNo = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.cbbVoucherType = new ChensControl.ChensComboBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtSerialNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtSN = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtToAreaNo = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtToHouseNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtToWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHstrTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFromWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFromWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHToWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHToWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFromHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFromHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHToHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHToHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFromAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFromAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHToAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHToAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHstrVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDeliveryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coloHTaskDetail_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
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
            this.gbBottom.TabIndex = 7;
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
            this.colHTaskType,
            this.colHstrTaskType,
            this.colHTaskNo,
            this.colHFromWarehouseNo,
            this.colHFromWarehouseName,
            this.colHToWarehouseNo,
            this.colHToWarehouseName,
            this.colHFromHouseNo,
            this.colHFromHouseName,
            this.colHToHouseNo,
            this.colHToHouseName,
            this.colHFromAreaNo,
            this.colHFromAreaName,
            this.colHToAreaNo,
            this.colHToAreaName,
            this.colHBarcode,
            this.colHVoucherType,
            this.colHstrVoucherType,
            this.colHDeliveryNo,
            this.colHMaterialNo,
            this.colHMaterialDesc,
            this.colHQty,
            this.colHSN,
            this.colHCreateTime,
            this.coloHTaskDetail_ID});
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
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.chensLabel10);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.txtAndalaNo);
            this.gbHeader.Controls.Add(this.lblaAndalaNo);
            this.gbHeader.Controls.Add(this.txtDeliveryNo);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.cbbVoucherType);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtSerialNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.txtSN);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.txtToAreaNo);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.txtToHouseNo);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.txtToWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 165);
            this.gbHeader.TabIndex = 6;
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
            this.dtpEndTime.TabIndex = 32;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(267, 130);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(34, 17);
            this.chensLabel9.TabIndex = 34;
            this.chensLabel9.Text = "——";
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(25, 130);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 33;
            this.chensLabel10.Text = "入库日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(87, 128);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 31;
            this.dtpStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtAndalaNo
            // 
            this.txtAndalaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAndalaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAndalaNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "AndalaNo", true));
            this.txtAndalaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAndalaNo.HotTrack = false;
            this.txtAndalaNo.Location = new System.Drawing.Point(571, 93);
            this.txtAndalaNo.Name = "txtAndalaNo";
            this.txtAndalaNo.Size = new System.Drawing.Size(150, 23);
            this.txtAndalaNo.TabIndex = 30;
            this.txtAndalaNo.TextEnabled = false;
            this.txtAndalaNo.Visible = false;
            this.txtAndalaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.TaskTransInfo);
            // 
            // lblaAndalaNo
            // 
            this.lblaAndalaNo.AutoSize = true;
            this.lblaAndalaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblaAndalaNo.Location = new System.Drawing.Point(509, 95);
            this.lblaAndalaNo.Name = "lblaAndalaNo";
            this.lblaAndalaNo.Size = new System.Drawing.Size(56, 17);
            this.lblaAndalaNo.TabIndex = 29;
            this.lblaAndalaNo.Text = "任务单号";
            this.lblaAndalaNo.Visible = false;
            // 
            // txtDeliveryNo
            // 
            this.txtDeliveryNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDeliveryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "DeliveryNo", true));
            this.txtDeliveryNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDeliveryNo.HotTrack = false;
            this.txtDeliveryNo.Location = new System.Drawing.Point(329, 93);
            this.txtDeliveryNo.Name = "txtDeliveryNo";
            this.txtDeliveryNo.Size = new System.Drawing.Size(150, 23);
            this.txtDeliveryNo.TabIndex = 28;
            this.txtDeliveryNo.TextEnabled = false;
            this.txtDeliveryNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(267, 95);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 27;
            this.chensLabel8.Text = "内部批号";
            // 
            // cbbVoucherType
            // 
            this.cbbVoucherType.BackColor = System.Drawing.Color.White;
            this.cbbVoucherType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbVoucherType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMain, "VoucherType", true));
            this.cbbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVoucherType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbVoucherType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbVoucherType.FormattingEnabled = true;
            this.cbbVoucherType.HotTrack = false;
            this.cbbVoucherType.Location = new System.Drawing.Point(87, 92);
            this.cbbVoucherType.Name = "cbbVoucherType";
            this.cbbVoucherType.Size = new System.Drawing.Size(150, 25);
            this.cbbVoucherType.TabIndex = 26;
            this.cbbVoucherType.Visible = false;
            this.cbbVoucherType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 95);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 25;
            this.chensLabel7.Text = "入库类型";
            this.chensLabel7.Visible = false;
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialNo", true));
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(571, 58);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 24;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(32, 17);
            this.chensLabel5.TabIndex = 23;
            this.chensLabel5.Text = "物料";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SerialNo", true));
            this.txtSerialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSerialNo.HotTrack = false;
            this.txtSerialNo.Location = new System.Drawing.Point(87, 58);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(150, 23);
            this.txtSerialNo.TabIndex = 22;
            this.txtSerialNo.TextEnabled = false;
            this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 60);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 21;
            this.chensLabel2.Text = "原厂批次";
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
            this.txtSN.TabIndex = 20;
            this.txtSN.TextEnabled = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(32, 17);
            this.chensLabel1.TabIndex = 19;
            this.chensLabel1.Text = "条码";
            // 
            // txtToAreaNo
            // 
            this.txtToAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtToAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToAreaNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "ToAreaNo", true));
            this.txtToAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtToAreaNo.HotTrack = false;
            this.txtToAreaNo.Location = new System.Drawing.Point(571, 23);
            this.txtToAreaNo.Name = "txtToAreaNo";
            this.txtToAreaNo.Size = new System.Drawing.Size(150, 23);
            this.txtToAreaNo.TabIndex = 18;
            this.txtToAreaNo.TextEnabled = false;
            this.txtToAreaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(509, 25);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(32, 17);
            this.chensLabel6.TabIndex = 17;
            this.chensLabel6.Text = "货位";
            // 
            // txtToHouseNo
            // 
            this.txtToHouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtToHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToHouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "ToHouseNo", true));
            this.txtToHouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtToHouseNo.HotTrack = false;
            this.txtToHouseNo.Location = new System.Drawing.Point(329, 23);
            this.txtToHouseNo.Name = "txtToHouseNo";
            this.txtToHouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtToHouseNo.TabIndex = 16;
            this.txtToHouseNo.TextEnabled = false;
            this.txtToHouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(267, 25);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(32, 17);
            this.chensLabel4.TabIndex = 15;
            this.chensLabel4.Text = "库区";
            // 
            // txtToWarehouseNo
            // 
            this.txtToWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtToWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToWarehouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "ToWarehouseNo", true));
            this.txtToWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtToWarehouseNo.HotTrack = false;
            this.txtToWarehouseNo.Location = new System.Drawing.Point(87, 23);
            this.txtToWarehouseNo.Name = "txtToWarehouseNo";
            this.txtToWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtToWarehouseNo.TabIndex = 14;
            this.txtToWarehouseNo.TextEnabled = false;
            this.txtToWarehouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(32, 17);
            this.chensLabel3.TabIndex = 13;
            this.chensLabel3.Text = "仓库";
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
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(44, 21);
            this.tsmiExport.Text = "导出";
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            // 
            // colHTaskType
            // 
            this.colHTaskType.DataPropertyName = "TaskType";
            this.colHTaskType.HeaderText = "任务类型";
            this.colHTaskType.Name = "colHTaskType";
            this.colHTaskType.ReadOnly = true;
            this.colHTaskType.Visible = false;
            // 
            // colHstrTaskType
            // 
            this.colHstrTaskType.DataPropertyName = "strTaskType";
            this.colHstrTaskType.HeaderText = "任务类型";
            this.colHstrTaskType.Name = "colHstrTaskType";
            this.colHstrTaskType.ReadOnly = true;
            this.colHstrTaskType.Visible = false;
            // 
            // colHTaskNo
            // 
            this.colHTaskNo.DataPropertyName = "TaskNo";
            this.colHTaskNo.HeaderText = "任务编号";
            this.colHTaskNo.Name = "colHTaskNo";
            this.colHTaskNo.ReadOnly = true;
            // 
            // colHFromWarehouseNo
            // 
            this.colHFromWarehouseNo.DataPropertyName = "FromWarehouseNo";
            this.colHFromWarehouseNo.HeaderText = "移出仓库";
            this.colHFromWarehouseNo.Name = "colHFromWarehouseNo";
            this.colHFromWarehouseNo.ReadOnly = true;
            this.colHFromWarehouseNo.Visible = false;
            // 
            // colHFromWarehouseName
            // 
            this.colHFromWarehouseName.DataPropertyName = "FromWarehouseName";
            this.colHFromWarehouseName.HeaderText = "移出仓库";
            this.colHFromWarehouseName.Name = "colHFromWarehouseName";
            this.colHFromWarehouseName.ReadOnly = true;
            this.colHFromWarehouseName.Visible = false;
            // 
            // colHToWarehouseNo
            // 
            this.colHToWarehouseNo.DataPropertyName = "ToWarehouseNo";
            this.colHToWarehouseNo.HeaderText = "移入仓库";
            this.colHToWarehouseNo.Name = "colHToWarehouseNo";
            this.colHToWarehouseNo.ReadOnly = true;
            this.colHToWarehouseNo.Visible = false;
            // 
            // colHToWarehouseName
            // 
            this.colHToWarehouseName.DataPropertyName = "ToWarehouseName";
            this.colHToWarehouseName.HeaderText = "移入仓库";
            this.colHToWarehouseName.Name = "colHToWarehouseName";
            this.colHToWarehouseName.ReadOnly = true;
            // 
            // colHFromHouseNo
            // 
            this.colHFromHouseNo.DataPropertyName = "FromHouseNo";
            this.colHFromHouseNo.HeaderText = "移出库区";
            this.colHFromHouseNo.Name = "colHFromHouseNo";
            this.colHFromHouseNo.ReadOnly = true;
            this.colHFromHouseNo.Visible = false;
            // 
            // colHFromHouseName
            // 
            this.colHFromHouseName.DataPropertyName = "FromHouseName";
            this.colHFromHouseName.HeaderText = "移出库区";
            this.colHFromHouseName.Name = "colHFromHouseName";
            this.colHFromHouseName.ReadOnly = true;
            this.colHFromHouseName.Visible = false;
            // 
            // colHToHouseNo
            // 
            this.colHToHouseNo.DataPropertyName = "ToHouseNo";
            this.colHToHouseNo.HeaderText = "移入库区";
            this.colHToHouseNo.Name = "colHToHouseNo";
            this.colHToHouseNo.ReadOnly = true;
            this.colHToHouseNo.Visible = false;
            // 
            // colHToHouseName
            // 
            this.colHToHouseName.DataPropertyName = "ToHouseName";
            this.colHToHouseName.HeaderText = "移入库区";
            this.colHToHouseName.Name = "colHToHouseName";
            this.colHToHouseName.ReadOnly = true;
            // 
            // colHFromAreaNo
            // 
            this.colHFromAreaNo.DataPropertyName = "FromAreaNo";
            this.colHFromAreaNo.HeaderText = "移出货位";
            this.colHFromAreaNo.Name = "colHFromAreaNo";
            this.colHFromAreaNo.ReadOnly = true;
            this.colHFromAreaNo.Visible = false;
            // 
            // colHFromAreaName
            // 
            this.colHFromAreaName.DataPropertyName = "FromAreaName";
            this.colHFromAreaName.HeaderText = "移出货位";
            this.colHFromAreaName.Name = "colHFromAreaName";
            this.colHFromAreaName.ReadOnly = true;
            this.colHFromAreaName.Visible = false;
            // 
            // colHToAreaNo
            // 
            this.colHToAreaNo.DataPropertyName = "ToAreaNo";
            this.colHToAreaNo.HeaderText = "移入货位";
            this.colHToAreaNo.Name = "colHToAreaNo";
            this.colHToAreaNo.ReadOnly = true;
            this.colHToAreaNo.Visible = false;
            // 
            // colHToAreaName
            // 
            this.colHToAreaName.DataPropertyName = "ToAreaName";
            this.colHToAreaName.HeaderText = "移入货位";
            this.colHToAreaName.Name = "colHToAreaName";
            this.colHToAreaName.ReadOnly = true;
            // 
            // colHBarcode
            // 
            this.colHBarcode.DataPropertyName = "Barcode";
            this.colHBarcode.HeaderText = "条码";
            this.colHBarcode.Name = "colHBarcode";
            this.colHBarcode.ReadOnly = true;
            this.colHBarcode.Width = 250;
            // 
            // colHVoucherType
            // 
            this.colHVoucherType.DataPropertyName = "VoucherType";
            this.colHVoucherType.HeaderText = "单据类型";
            this.colHVoucherType.Name = "colHVoucherType";
            this.colHVoucherType.ReadOnly = true;
            this.colHVoucherType.Visible = false;
            // 
            // colHstrVoucherType
            // 
            this.colHstrVoucherType.DataPropertyName = "strVoucherType";
            this.colHstrVoucherType.HeaderText = "单据类型";
            this.colHstrVoucherType.Name = "colHstrVoucherType";
            this.colHstrVoucherType.ReadOnly = true;
            // 
            // colHDeliveryNo
            // 
            this.colHDeliveryNo.DataPropertyName = "DeliveryNo";
            this.colHDeliveryNo.HeaderText = "单据编号";
            this.colHDeliveryNo.Name = "colHDeliveryNo";
            this.colHDeliveryNo.ReadOnly = true;
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
            // colHQty
            // 
            this.colHQty.DataPropertyName = "Qty";
            this.colHQty.HeaderText = "入库数量";
            this.colHQty.Name = "colHQty";
            this.colHQty.ReadOnly = true;
            // 
            // colHSN
            // 
            this.colHSN.DataPropertyName = "SN";
            this.colHSN.HeaderText = "来料批次";
            this.colHSN.Name = "colHSN";
            this.colHSN.ReadOnly = true;
            // 
            // colHCreateTime
            // 
            this.colHCreateTime.DataPropertyName = "CreateTime";
            this.colHCreateTime.HeaderText = "入库时间";
            this.colHCreateTime.Name = "colHCreateTime";
            this.colHCreateTime.ReadOnly = true;
            // 
            // coloHTaskDetail_ID
            // 
            this.coloHTaskDetail_ID.DataPropertyName = "TaskDetail_ID";
            this.coloHTaskDetail_ID.HeaderText = "TaskDetail_ID";
            this.coloHTaskDetail_ID.Name = "coloHTaskDetail_ID";
            this.coloHTaskDetail_ID.ReadOnly = true;
            this.coloHTaskDetail_ID.Visible = false;
            // 
            // FrmStockInQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmStockInQuery";
            this.Text = "历史入库记录查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmStockInQuery_FormClosed);
            this.Load += new System.EventHandler(this.FrmStockInQuery_Load);
            this.gbBottom.ResumeLayout(false);
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
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private ChensControl.ChensTextBox txtToAreaNo;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtToHouseNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtToWarehouseNo;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensTextBox txtSN;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtSerialNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtDeliveryNo;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensComboBox cbbVoucherType;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtAndalaNo;
        private ChensControl.ChensLabel lblaAndalaNo;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHstrTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFromWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFromWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHToWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHToWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFromHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFromHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHToHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHToHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFromAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFromAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHToAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHToAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHstrVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDeliveryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn coloHTaskDetail_ID;
    }
}