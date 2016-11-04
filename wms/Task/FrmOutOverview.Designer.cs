namespace JingXinWMS.Task
{
    partial class FrmOutOverview
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
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage2 = new ChensControl.DividPage();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.cbbWarehouse = new ChensControl.ChensComboBox();
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.txtMaterialDoc = new ChensControl.ChensTextBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.cbbPostStatus = new ChensControl.ChensComboBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.txtDeliveryNo = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.cbbIsQuality = new ChensControl.ChensComboBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.cbbVoucherType = new ChensControl.ChensComboBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.cbbTaskStatus = new ChensControl.ChensComboBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtReceiveUserNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtSupCusNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtTaskNo = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHVoucherNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSAPMaterialDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupCusNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSupCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrTaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrIsQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAuditUserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAuditUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAuditDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTaskIssued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReceiveUserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReceiveUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrPostStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsReceivePost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrIsReceivePpost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsShelvePost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrIsShelvePpost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateUserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPOSTSTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvDetail = new ChensControl.ChensDataGridView();
            this.colBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBTask_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBFromAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBToAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBTaskQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBQualityQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBRemainQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBShelveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStrStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBIsQualityComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStrIsQualityComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBKeeperUserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBKeeperUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBOperatorUserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBOperatorUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCompleteDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBTMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBTMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBReviewQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBPackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBShelvePackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBTrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBUnQualityQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBPostQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageDetail = new ChensControl.ChensPage();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.msMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiExportDetail});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.tsmiSearch.Size = new System.Drawing.Size(68, 21);
            this.tsmiSearch.Text = "查询数据";
            this.tsmiSearch.Visible = false;
            // 
            // tsmiExportDetail
            // 
            this.tsmiExportDetail.Name = "tsmiExportDetail";
            this.tsmiExportDetail.Size = new System.Drawing.Size(68, 21);
            this.tsmiExportDetail.Text = "导出明细";
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.cbbWarehouse);
            this.gbHeader.Controls.Add(this.chensLabel12);
            this.gbHeader.Controls.Add(this.txtMaterialDoc);
            this.gbHeader.Controls.Add(this.chensLabel10);
            this.gbHeader.Controls.Add(this.cbbPostStatus);
            this.gbHeader.Controls.Add(this.chensLabel11);
            this.gbHeader.Controls.Add(this.txtDeliveryNo);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.cbbIsQuality);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.cbbVoucherType);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.cbbTaskStatus);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.txtReceiveUserNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtSupCusNo);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtTaskNo);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 165);
            this.gbHeader.TabIndex = 12;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // cbbWarehouse
            // 
            this.cbbWarehouse.BackColor = System.Drawing.Color.White;
            this.cbbWarehouse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbWarehouse.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbWarehouse.FormattingEnabled = true;
            this.cbbWarehouse.HotTrack = false;
            this.cbbWarehouse.Location = new System.Drawing.Point(614, 127);
            this.cbbWarehouse.Name = "cbbWarehouse";
            this.cbbWarehouse.Size = new System.Drawing.Size(150, 25);
            this.cbbWarehouse.TabIndex = 30;
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(540, 130);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(56, 17);
            this.chensLabel12.TabIndex = 29;
            this.chensLabel12.Text = "所属仓库";
            // 
            // txtMaterialDoc
            // 
            this.txtMaterialDoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDoc.HotTrack = false;
            this.txtMaterialDoc.Location = new System.Drawing.Point(353, 128);
            this.txtMaterialDoc.Name = "txtMaterialDoc";
            this.txtMaterialDoc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDoc.TabIndex = 28;
            this.txtMaterialDoc.TextEnabled = false;
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(291, 130);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 27;
            this.chensLabel10.Text = "物料凭证";
            // 
            // cbbPostStatus
            // 
            this.cbbPostStatus.BackColor = System.Drawing.Color.White;
            this.cbbPostStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbPostStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPostStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbPostStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbPostStatus.FormattingEnabled = true;
            this.cbbPostStatus.HotTrack = false;
            this.cbbPostStatus.Location = new System.Drawing.Point(614, 92);
            this.cbbPostStatus.Name = "cbbPostStatus";
            this.cbbPostStatus.Size = new System.Drawing.Size(150, 25);
            this.cbbPostStatus.TabIndex = 26;
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(540, 95);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(56, 17);
            this.chensLabel11.TabIndex = 25;
            this.chensLabel11.Text = "过账状态";
            // 
            // txtDeliveryNo
            // 
            this.txtDeliveryNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDeliveryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDeliveryNo.HotTrack = false;
            this.txtDeliveryNo.Location = new System.Drawing.Point(353, 93);
            this.txtDeliveryNo.Name = "txtDeliveryNo";
            this.txtDeliveryNo.Size = new System.Drawing.Size(150, 23);
            this.txtDeliveryNo.TabIndex = 24;
            this.txtDeliveryNo.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(291, 95);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 23;
            this.chensLabel8.Text = "单据编号";
            // 
            // cbbIsQuality
            // 
            this.cbbIsQuality.BackColor = System.Drawing.Color.White;
            this.cbbIsQuality.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbIsQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIsQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbIsQuality.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbIsQuality.FormattingEnabled = true;
            this.cbbIsQuality.HotTrack = false;
            this.cbbIsQuality.Location = new System.Drawing.Point(111, 127);
            this.cbbIsQuality.Name = "cbbIsQuality";
            this.cbbIsQuality.Size = new System.Drawing.Size(150, 25);
            this.cbbIsQuality.TabIndex = 20;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(25, 130);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 19;
            this.chensLabel9.Text = "是否质检";
            // 
            // cbbVoucherType
            // 
            this.cbbVoucherType.BackColor = System.Drawing.Color.White;
            this.cbbVoucherType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVoucherType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbVoucherType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbVoucherType.FormattingEnabled = true;
            this.cbbVoucherType.HotTrack = false;
            this.cbbVoucherType.Location = new System.Drawing.Point(111, 92);
            this.cbbVoucherType.Name = "cbbVoucherType";
            this.cbbVoucherType.Size = new System.Drawing.Size(150, 25);
            this.cbbVoucherType.TabIndex = 16;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 95);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 15;
            this.chensLabel7.Text = "出库类型";
            // 
            // cbbTaskStatus
            // 
            this.cbbTaskStatus.BackColor = System.Drawing.Color.White;
            this.cbbTaskStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbTaskStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTaskStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbTaskStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbTaskStatus.FormattingEnabled = true;
            this.cbbTaskStatus.HotTrack = false;
            this.cbbTaskStatus.Location = new System.Drawing.Point(614, 56);
            this.cbbTaskStatus.Name = "cbbTaskStatus";
            this.cbbTaskStatus.Size = new System.Drawing.Size(150, 25);
            this.cbbTaskStatus.TabIndex = 14;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(540, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 13;
            this.chensLabel6.Text = "任务状态";
            // 
            // txtReceiveUserNo
            // 
            this.txtReceiveUserNo.BackColor = System.Drawing.Color.White;
            this.txtReceiveUserNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtReceiveUserNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiveUserNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtReceiveUserNo.HotTrack = false;
            this.txtReceiveUserNo.Location = new System.Drawing.Point(353, 58);
            this.txtReceiveUserNo.Name = "txtReceiveUserNo";
            this.txtReceiveUserNo.Size = new System.Drawing.Size(150, 23);
            this.txtReceiveUserNo.TabIndex = 12;
            this.txtReceiveUserNo.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(291, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(44, 17);
            this.chensLabel5.TabIndex = 11;
            this.chensLabel5.Text = "拣货人";
            // 
            // txtSupCusNo
            // 
            this.txtSupCusNo.BackColor = System.Drawing.Color.White;
            this.txtSupCusNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupCusNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCusNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupCusNo.HotTrack = false;
            this.txtSupCusNo.Location = new System.Drawing.Point(111, 58);
            this.txtSupCusNo.Name = "txtSupCusNo";
            this.txtSupCusNo.Size = new System.Drawing.Size(150, 23);
            this.txtSupCusNo.TabIndex = 10;
            this.txtSupCusNo.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(32, 17);
            this.chensLabel4.TabIndex = 9;
            this.chensLabel4.Text = "客户";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(614, 23);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 8;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(540, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(34, 17);
            this.chensLabel3.TabIndex = 7;
            this.chensLabel3.Text = "——";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(353, 21);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 6;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(291, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 5;
            this.chensLabel2.Text = "创建日期";
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
            // 
            // txtTaskNo
            // 
            this.txtTaskNo.BackColor = System.Drawing.Color.White;
            this.txtTaskNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTaskNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTaskNo.HotTrack = false;
            this.txtTaskNo.Location = new System.Drawing.Point(111, 23);
            this.txtTaskNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTaskNo.Name = "txtTaskNo";
            this.txtTaskNo.Size = new System.Drawing.Size(150, 23);
            this.txtTaskNo.TabIndex = 2;
            this.txtTaskNo.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(68, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "下架任务号";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 190);
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
            this.scMain.Size = new System.Drawing.Size(992, 583);
            this.scMain.SplitterDistance = 303;
            this.scMain.TabIndex = 14;
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 0);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 303);
            this.gbMiddle.TabIndex = 13;
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
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHID,
            this.colHVoucherType,
            this.colHStrVoucherType,
            this.colHVoucherNo,
            this.colHSAPMaterialDoc,
            this.colHTaskNo,
            this.colHTaskType,
            this.colHStrTaskType,
            this.colHCreateDateTime,
            this.colHSupCusNo,
            this.colHSupCusName,
            this.colHTaskStatus,
            this.colHStrTaskStatus,
            this.colHIsQuality,
            this.colHStrIsQuality,
            this.colHAuditUserNo,
            this.colHAuditUserName,
            this.colHAuditDateTime,
            this.colHTaskIssued,
            this.colHReceiveUserNo,
            this.colHReceiveUserName,
            this.colHRemark,
            this.colHReason,
            this.colHStrPostStatus,
            this.colHIsReceivePost,
            this.colHStrIsReceivePpost,
            this.colHIsShelvePost,
            this.colHStrIsShelvePpost,
            this.colHWarehouseCode,
            this.colHWarehouseName,
            this.colHCreateUserNo,
            this.colHPOSTSTATUS,
            this.colHPlant,
            this.colHPlantName});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 261);
            this.dgvList.TabIndex = 1;
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            // 
            // colHVoucherType
            // 
            this.colHVoucherType.DataPropertyName = "VoucherType";
            this.colHVoucherType.HeaderText = "出库类型";
            this.colHVoucherType.Name = "colHVoucherType";
            this.colHVoucherType.ReadOnly = true;
            this.colHVoucherType.Visible = false;
            // 
            // colHStrVoucherType
            // 
            this.colHStrVoucherType.DataPropertyName = "StrVoucherType";
            this.colHStrVoucherType.HeaderText = "出库类型";
            this.colHStrVoucherType.Name = "colHStrVoucherType";
            this.colHStrVoucherType.ReadOnly = true;
            // 
            // colHVoucherNo
            // 
            this.colHVoucherNo.DataPropertyName = "DeliveryNo";
            this.colHVoucherNo.HeaderText = "单据编号";
            this.colHVoucherNo.Name = "colHVoucherNo";
            this.colHVoucherNo.ReadOnly = true;
            // 
            // colHSAPMaterialDoc
            // 
            this.colHSAPMaterialDoc.DataPropertyName = "MaterialDoc";
            this.colHSAPMaterialDoc.HeaderText = "物料凭证";
            this.colHSAPMaterialDoc.Name = "colHSAPMaterialDoc";
            this.colHSAPMaterialDoc.ReadOnly = true;
            // 
            // colHTaskNo
            // 
            this.colHTaskNo.DataPropertyName = "TaskNo";
            this.colHTaskNo.HeaderText = "下架任务号";
            this.colHTaskNo.Name = "colHTaskNo";
            this.colHTaskNo.ReadOnly = true;
            this.colHTaskNo.Width = 130;
            // 
            // colHTaskType
            // 
            this.colHTaskType.DataPropertyName = "TaskType";
            this.colHTaskType.HeaderText = "任务类型";
            this.colHTaskType.Name = "colHTaskType";
            this.colHTaskType.ReadOnly = true;
            this.colHTaskType.Visible = false;
            // 
            // colHStrTaskType
            // 
            this.colHStrTaskType.DataPropertyName = "StrTaskType";
            this.colHStrTaskType.HeaderText = "任务类型";
            this.colHStrTaskType.Name = "colHStrTaskType";
            this.colHStrTaskType.ReadOnly = true;
            this.colHStrTaskType.Visible = false;
            // 
            // colHCreateDateTime
            // 
            this.colHCreateDateTime.DataPropertyName = "CreateDateTime";
            this.colHCreateDateTime.HeaderText = "创建日期";
            this.colHCreateDateTime.Name = "colHCreateDateTime";
            this.colHCreateDateTime.ReadOnly = true;
            this.colHCreateDateTime.Visible = false;
            // 
            // colHSupCusNo
            // 
            this.colHSupCusNo.DataPropertyName = "SupcusNo";
            this.colHSupCusNo.HeaderText = "供应商代码";
            this.colHSupCusNo.Name = "colHSupCusNo";
            this.colHSupCusNo.ReadOnly = true;
            // 
            // colHSupCusName
            // 
            this.colHSupCusName.DataPropertyName = "SupcusName";
            this.colHSupCusName.HeaderText = "供应商名称";
            this.colHSupCusName.Name = "colHSupCusName";
            this.colHSupCusName.ReadOnly = true;
            this.colHSupCusName.Width = 200;
            // 
            // colHTaskStatus
            // 
            this.colHTaskStatus.DataPropertyName = "TaskStatus";
            this.colHTaskStatus.HeaderText = "状态";
            this.colHTaskStatus.Name = "colHTaskStatus";
            this.colHTaskStatus.ReadOnly = true;
            this.colHTaskStatus.Visible = false;
            // 
            // colHStrTaskStatus
            // 
            this.colHStrTaskStatus.DataPropertyName = "StrTaskStatus";
            this.colHStrTaskStatus.HeaderText = "状态";
            this.colHStrTaskStatus.Name = "colHStrTaskStatus";
            this.colHStrTaskStatus.ReadOnly = true;
            // 
            // colHIsQuality
            // 
            this.colHIsQuality.DataPropertyName = "IsQuality";
            this.colHIsQuality.HeaderText = "是否质检";
            this.colHIsQuality.Name = "colHIsQuality";
            this.colHIsQuality.ReadOnly = true;
            this.colHIsQuality.Visible = false;
            // 
            // colHStrIsQuality
            // 
            this.colHStrIsQuality.DataPropertyName = "StrIsQuality";
            this.colHStrIsQuality.HeaderText = "是否质检";
            this.colHStrIsQuality.Name = "colHStrIsQuality";
            this.colHStrIsQuality.ReadOnly = true;
            // 
            // colHAuditUserNo
            // 
            this.colHAuditUserNo.DataPropertyName = "AuditUserNo";
            this.colHAuditUserNo.HeaderText = "审核人";
            this.colHAuditUserNo.Name = "colHAuditUserNo";
            this.colHAuditUserNo.ReadOnly = true;
            this.colHAuditUserNo.Visible = false;
            // 
            // colHAuditUserName
            // 
            this.colHAuditUserName.DataPropertyName = "AuditUserName";
            this.colHAuditUserName.HeaderText = "审核人";
            this.colHAuditUserName.Name = "colHAuditUserName";
            this.colHAuditUserName.ReadOnly = true;
            this.colHAuditUserName.Visible = false;
            // 
            // colHAuditDateTime
            // 
            this.colHAuditDateTime.DataPropertyName = "AuditDateTime";
            this.colHAuditDateTime.HeaderText = "审核时间";
            this.colHAuditDateTime.Name = "colHAuditDateTime";
            this.colHAuditDateTime.ReadOnly = true;
            this.colHAuditDateTime.Visible = false;
            // 
            // colHTaskIssued
            // 
            this.colHTaskIssued.DataPropertyName = "TaskIssued";
            this.colHTaskIssued.HeaderText = "任务下发时间";
            this.colHTaskIssued.Name = "colHTaskIssued";
            this.colHTaskIssued.ReadOnly = true;
            this.colHTaskIssued.Width = 130;
            // 
            // colHReceiveUserNo
            // 
            this.colHReceiveUserNo.DataPropertyName = "ReceiveUserNo";
            this.colHReceiveUserNo.HeaderText = "拣货人";
            this.colHReceiveUserNo.Name = "colHReceiveUserNo";
            this.colHReceiveUserNo.ReadOnly = true;
            this.colHReceiveUserNo.Visible = false;
            // 
            // colHReceiveUserName
            // 
            this.colHReceiveUserName.DataPropertyName = "ReceiveUserName";
            this.colHReceiveUserName.HeaderText = "拣货人";
            this.colHReceiveUserName.Name = "colHReceiveUserName";
            this.colHReceiveUserName.ReadOnly = true;
            // 
            // colHRemark
            // 
            this.colHRemark.DataPropertyName = "Remark";
            this.colHRemark.HeaderText = "备注";
            this.colHRemark.Name = "colHRemark";
            this.colHRemark.ReadOnly = true;
            this.colHRemark.Visible = false;
            // 
            // colHReason
            // 
            this.colHReason.DataPropertyName = "Reason ";
            this.colHReason.HeaderText = "入库原因";
            this.colHReason.Name = "colHReason";
            this.colHReason.ReadOnly = true;
            this.colHReason.Visible = false;
            // 
            // colHStrPostStatus
            // 
            this.colHStrPostStatus.DataPropertyName = "StrPostStatus";
            this.colHStrPostStatus.HeaderText = "过账状态";
            this.colHStrPostStatus.Name = "colHStrPostStatus";
            this.colHStrPostStatus.ReadOnly = true;
            // 
            // colHIsReceivePost
            // 
            this.colHIsReceivePost.DataPropertyName = "IsReceivePost";
            this.colHIsReceivePost.HeaderText = "是否拣货过账";
            this.colHIsReceivePost.Name = "colHIsReceivePost";
            this.colHIsReceivePost.ReadOnly = true;
            this.colHIsReceivePost.Visible = false;
            this.colHIsReceivePost.Width = 120;
            // 
            // colHStrIsReceivePpost
            // 
            this.colHStrIsReceivePpost.DataPropertyName = "StrIsReceivePost";
            this.colHStrIsReceivePpost.HeaderText = "是否拣货过账";
            this.colHStrIsReceivePpost.Name = "colHStrIsReceivePpost";
            this.colHStrIsReceivePpost.ReadOnly = true;
            this.colHStrIsReceivePpost.Width = 120;
            // 
            // colHIsShelvePost
            // 
            this.colHIsShelvePost.DataPropertyName = "IsShelvePost";
            this.colHIsShelvePost.HeaderText = "是否下架过账";
            this.colHIsShelvePost.Name = "colHIsShelvePost";
            this.colHIsShelvePost.ReadOnly = true;
            this.colHIsShelvePost.Visible = false;
            this.colHIsShelvePost.Width = 120;
            // 
            // colHStrIsShelvePpost
            // 
            this.colHStrIsShelvePpost.DataPropertyName = "StrIsShelvePost";
            this.colHStrIsShelvePpost.HeaderText = "是否下架过账";
            this.colHStrIsShelvePpost.Name = "colHStrIsShelvePpost";
            this.colHStrIsShelvePpost.ReadOnly = true;
            this.colHStrIsShelvePpost.Width = 120;
            // 
            // colHWarehouseCode
            // 
            this.colHWarehouseCode.DataPropertyName = "WarehouseCode";
            this.colHWarehouseCode.HeaderText = "仓库ID";
            this.colHWarehouseCode.Name = "colHWarehouseCode";
            this.colHWarehouseCode.ReadOnly = true;
            this.colHWarehouseCode.Visible = false;
            // 
            // colHWarehouseName
            // 
            this.colHWarehouseName.DataPropertyName = "WarehouseName";
            this.colHWarehouseName.HeaderText = "仓库名称";
            this.colHWarehouseName.Name = "colHWarehouseName";
            this.colHWarehouseName.ReadOnly = true;
            this.colHWarehouseName.Width = 200;
            // 
            // colHCreateUserNo
            // 
            this.colHCreateUserNo.DataPropertyName = "CreateUserNo";
            this.colHCreateUserNo.HeaderText = "创建人";
            this.colHCreateUserNo.Name = "colHCreateUserNo";
            this.colHCreateUserNo.ReadOnly = true;
            this.colHCreateUserNo.Visible = false;
            // 
            // colHPOSTSTATUS
            // 
            this.colHPOSTSTATUS.DataPropertyName = "POSTSTATUS";
            this.colHPOSTSTATUS.HeaderText = "过账状态";
            this.colHPOSTSTATUS.Name = "colHPOSTSTATUS";
            this.colHPOSTSTATUS.ReadOnly = true;
            this.colHPOSTSTATUS.Visible = false;
            // 
            // colHPlant
            // 
            this.colHPlant.DataPropertyName = "Plant";
            this.colHPlant.HeaderText = "工厂编号";
            this.colHPlant.Name = "colHPlant";
            this.colHPlant.ReadOnly = true;
            this.colHPlant.Visible = false;
            // 
            // colHPlantName
            // 
            this.colHPlantName.DataPropertyName = "PlantName";
            this.colHPlantName.HeaderText = "工厂名称";
            this.colHPlantName.Name = "colHPlantName";
            this.colHPlantName.ReadOnly = true;
            this.colHPlantName.Visible = false;
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
            this.pageList.Location = new System.Drawing.Point(3, 280);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 0;
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
            this.gbBottom.Size = new System.Drawing.Size(992, 276);
            this.gbBottom.TabIndex = 14;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "入库明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBID,
            this.colBTask_ID,
            this.colBFromAreaNo,
            this.colBToAreaNo,
            this.colBMaterialNo,
            this.colBMaterialDesc,
            this.colBTaskQty,
            this.colBQualityQty,
            this.colBRemainQty,
            this.colBShelveQty,
            this.colBStatus,
            this.colBStrStatus,
            this.colBIsQualityComp,
            this.colBStrIsQualityComp,
            this.colBKeeperUserNo,
            this.colBKeeperUserName,
            this.colBOperatorUserNo,
            this.colBOperatorUserName,
            this.colBCompleteDateTime,
            this.colBTMaterialNo,
            this.colBTMaterialDesc,
            this.colBReviewQty,
            this.colBPackCount,
            this.colBShelvePackCount,
            this.colBRowNo,
            this.colBTrackNo,
            this.colBUnit,
            this.colBUnQualityQty,
            this.colBPostQty});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetail.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvDetail.GridColor = System.Drawing.Color.LightGray;
            this.dgvDetail.HaveCopyMenu = true;
            this.dgvDetail.Location = new System.Drawing.Point(3, 19);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(986, 234);
            this.dgvDetail.TabIndex = 1;
            // 
            // colBID
            // 
            this.colBID.DataPropertyName = "ID";
            this.colBID.HeaderText = "ID";
            this.colBID.Name = "colBID";
            this.colBID.ReadOnly = true;
            this.colBID.Visible = false;
            // 
            // colBTask_ID
            // 
            this.colBTask_ID.DataPropertyName = "Task_ID";
            this.colBTask_ID.HeaderText = "主表ID";
            this.colBTask_ID.Name = "colBTask_ID";
            this.colBTask_ID.ReadOnly = true;
            this.colBTask_ID.Visible = false;
            // 
            // colBFromAreaNo
            // 
            this.colBFromAreaNo.DataPropertyName = "FromAreaNo";
            this.colBFromAreaNo.HeaderText = "清点货位";
            this.colBFromAreaNo.Name = "colBFromAreaNo";
            this.colBFromAreaNo.ReadOnly = true;
            // 
            // colBToAreaNo
            // 
            this.colBToAreaNo.DataPropertyName = "ToAreaNo";
            this.colBToAreaNo.HeaderText = "入库货位";
            this.colBToAreaNo.Name = "colBToAreaNo";
            this.colBToAreaNo.ReadOnly = true;
            this.colBToAreaNo.Visible = false;
            // 
            // colBMaterialNo
            // 
            this.colBMaterialNo.DataPropertyName = "MaterialNo";
            this.colBMaterialNo.HeaderText = "物料编号";
            this.colBMaterialNo.Name = "colBMaterialNo";
            this.colBMaterialNo.ReadOnly = true;
            this.colBMaterialNo.Width = 150;
            // 
            // colBMaterialDesc
            // 
            this.colBMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colBMaterialDesc.HeaderText = "物料描述";
            this.colBMaterialDesc.Name = "colBMaterialDesc";
            this.colBMaterialDesc.ReadOnly = true;
            this.colBMaterialDesc.Width = 200;
            // 
            // colBTaskQty
            // 
            this.colBTaskQty.DataPropertyName = "TaskQty";
            this.colBTaskQty.HeaderText = "任务数量";
            this.colBTaskQty.Name = "colBTaskQty";
            this.colBTaskQty.ReadOnly = true;
            // 
            // colBQualityQty
            // 
            this.colBQualityQty.DataPropertyName = "QualityQty";
            this.colBQualityQty.HeaderText = "合格数量";
            this.colBQualityQty.Name = "colBQualityQty";
            this.colBQualityQty.ReadOnly = true;
            this.colBQualityQty.Visible = false;
            // 
            // colBRemainQty
            // 
            this.colBRemainQty.DataPropertyName = "RemainQty";
            this.colBRemainQty.HeaderText = "剩余数量";
            this.colBRemainQty.Name = "colBRemainQty";
            this.colBRemainQty.ReadOnly = true;
            // 
            // colBShelveQty
            // 
            this.colBShelveQty.DataPropertyName = "ShelveQty";
            this.colBShelveQty.HeaderText = "已下架数量";
            this.colBShelveQty.Name = "colBShelveQty";
            this.colBShelveQty.ReadOnly = true;
            // 
            // colBStatus
            // 
            this.colBStatus.DataPropertyName = "Status";
            this.colBStatus.HeaderText = "状态";
            this.colBStatus.Name = "colBStatus";
            this.colBStatus.ReadOnly = true;
            this.colBStatus.Visible = false;
            // 
            // colBStrStatus
            // 
            this.colBStrStatus.DataPropertyName = "StrStatus";
            this.colBStrStatus.HeaderText = "状态";
            this.colBStrStatus.Name = "colBStrStatus";
            this.colBStrStatus.ReadOnly = true;
            // 
            // colBIsQualityComp
            // 
            this.colBIsQualityComp.DataPropertyName = "IsQualityComp";
            this.colBIsQualityComp.HeaderText = "是否质检完成";
            this.colBIsQualityComp.Name = "colBIsQualityComp";
            this.colBIsQualityComp.ReadOnly = true;
            this.colBIsQualityComp.Visible = false;
            // 
            // colBStrIsQualityComp
            // 
            this.colBStrIsQualityComp.DataPropertyName = "StrIsQualityComp";
            this.colBStrIsQualityComp.HeaderText = "是否质检完成";
            this.colBStrIsQualityComp.Name = "colBStrIsQualityComp";
            this.colBStrIsQualityComp.ReadOnly = true;
            this.colBStrIsQualityComp.Visible = false;
            this.colBStrIsQualityComp.Width = 120;
            // 
            // colBKeeperUserNo
            // 
            this.colBKeeperUserNo.DataPropertyName = "KeeperUserNo";
            this.colBKeeperUserNo.HeaderText = "拣货人";
            this.colBKeeperUserNo.Name = "colBKeeperUserNo";
            this.colBKeeperUserNo.ReadOnly = true;
            this.colBKeeperUserNo.Visible = false;
            // 
            // colBKeeperUserName
            // 
            this.colBKeeperUserName.DataPropertyName = "KeeperUserName";
            this.colBKeeperUserName.HeaderText = "拣货人";
            this.colBKeeperUserName.Name = "colBKeeperUserName";
            this.colBKeeperUserName.ReadOnly = true;
            this.colBKeeperUserName.Visible = false;
            // 
            // colBOperatorUserNo
            // 
            this.colBOperatorUserNo.DataPropertyName = "OperatorUserNo";
            this.colBOperatorUserNo.HeaderText = "操作人";
            this.colBOperatorUserNo.Name = "colBOperatorUserNo";
            this.colBOperatorUserNo.ReadOnly = true;
            this.colBOperatorUserNo.Visible = false;
            // 
            // colBOperatorUserName
            // 
            this.colBOperatorUserName.DataPropertyName = "OperatorUserName";
            this.colBOperatorUserName.HeaderText = "操作人";
            this.colBOperatorUserName.Name = "colBOperatorUserName";
            this.colBOperatorUserName.ReadOnly = true;
            // 
            // colBCompleteDateTime
            // 
            this.colBCompleteDateTime.DataPropertyName = "CompleteDateTime";
            this.colBCompleteDateTime.HeaderText = "完成时间";
            this.colBCompleteDateTime.Name = "colBCompleteDateTime";
            this.colBCompleteDateTime.ReadOnly = true;
            this.colBCompleteDateTime.Visible = false;
            // 
            // colBTMaterialNo
            // 
            this.colBTMaterialNo.DataPropertyName = "TMaterialNo";
            this.colBTMaterialNo.HeaderText = "临时物料编号";
            this.colBTMaterialNo.Name = "colBTMaterialNo";
            this.colBTMaterialNo.ReadOnly = true;
            this.colBTMaterialNo.Visible = false;
            // 
            // colBTMaterialDesc
            // 
            this.colBTMaterialDesc.DataPropertyName = "TMaterialDesc";
            this.colBTMaterialDesc.HeaderText = "临时物料描述";
            this.colBTMaterialDesc.Name = "colBTMaterialDesc";
            this.colBTMaterialDesc.ReadOnly = true;
            this.colBTMaterialDesc.Visible = false;
            // 
            // colBReviewQty
            // 
            this.colBReviewQty.DataPropertyName = "ReviewQty";
            this.colBReviewQty.HeaderText = "拣货数量";
            this.colBReviewQty.Name = "colBReviewQty";
            this.colBReviewQty.ReadOnly = true;
            this.colBReviewQty.Visible = false;
            // 
            // colBPackCount
            // 
            this.colBPackCount.DataPropertyName = "PackCount";
            this.colBPackCount.HeaderText = "PackCount";
            this.colBPackCount.Name = "colBPackCount";
            this.colBPackCount.ReadOnly = true;
            this.colBPackCount.Visible = false;
            // 
            // colBShelvePackCount
            // 
            this.colBShelvePackCount.DataPropertyName = "ShelvePackCount";
            this.colBShelvePackCount.HeaderText = "ShelvePackCount";
            this.colBShelvePackCount.Name = "colBShelvePackCount";
            this.colBShelvePackCount.ReadOnly = true;
            this.colBShelvePackCount.Visible = false;
            // 
            // colBRowNo
            // 
            this.colBRowNo.DataPropertyName = "行号";
            this.colBRowNo.HeaderText = "行号";
            this.colBRowNo.Name = "colBRowNo";
            this.colBRowNo.ReadOnly = true;
            this.colBRowNo.Visible = false;
            // 
            // colBTrackNo
            // 
            this.colBTrackNo.DataPropertyName = "TrackNo";
            this.colBTrackNo.HeaderText = "TrackNo";
            this.colBTrackNo.Name = "colBTrackNo";
            this.colBTrackNo.ReadOnly = true;
            this.colBTrackNo.Visible = false;
            // 
            // colBUnit
            // 
            this.colBUnit.DataPropertyName = "Unit";
            this.colBUnit.HeaderText = "计量单位";
            this.colBUnit.Name = "colBUnit";
            this.colBUnit.ReadOnly = true;
            this.colBUnit.Visible = false;
            // 
            // colBUnQualityQty
            // 
            this.colBUnQualityQty.DataPropertyName = "UnQualityQty";
            this.colBUnQualityQty.HeaderText = "不合格数量";
            this.colBUnQualityQty.Name = "colBUnQualityQty";
            this.colBUnQualityQty.ReadOnly = true;
            this.colBUnQualityQty.Visible = false;
            // 
            // colBPostQty
            // 
            this.colBPostQty.DataPropertyName = "PostQty";
            this.colBPostQty.HeaderText = "过账数量";
            this.colBPostQty.Name = "colBPostQty";
            this.colBPostQty.ReadOnly = true;
            this.colBPostQty.Visible = false;
            // 
            // pageDetail
            // 
            this.pageDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageDetail.CurrentPageNumber = 0;
            dividPage2.CurrentPageNumber = 0;
            dividPage2.CurrentPageRecordCounts = 0;
            dividPage2.CurrentPageShowCounts = 10;
            dividPage2.DefaultPageShowCounts = 10;
            dividPage2.PagesCount = 0;
            dividPage2.RecordCounts = 0;
            this.pageDetail.dDividPage = dividPage2;
            this.pageDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageDetail.Location = new System.Drawing.Point(3, 253);
            this.pageDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageDetail.Name = "pageDetail";
            this.pageDetail.Size = new System.Drawing.Size(986, 20);
            this.pageDetail.TabIndex = 0;
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(JingXinWMS.JXWebService.OverViewInfo);
            // 
            // FrmOutOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmOutOverview";
            this.Text = "出库任务总览";
            this.Load += new System.EventHandler(this.FrmOutOverview_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportDetail;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensComboBox cbbWarehouse;
        private ChensControl.ChensLabel chensLabel12;
        private ChensControl.ChensTextBox txtMaterialDoc;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensComboBox cbbPostStatus;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensTextBox txtDeliveryNo;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensComboBox cbbIsQuality;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensComboBox cbbVoucherType;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensComboBox cbbTaskStatus;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtReceiveUserNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtSupCusNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtTaskNo;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.SplitContainer scMain;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvDetail;
        private ChensControl.ChensPage pageDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHVoucherNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSAPMaterialDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupCusNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSupCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrTaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAuditUserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAuditUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAuditDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTaskIssued;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReceiveUserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReceiveUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrPostStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsReceivePost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsReceivePpost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsShelvePost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsShelvePpost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateUserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPOSTSTATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBTask_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBFromAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBToAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBTaskQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBQualityQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBRemainQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBShelveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStrStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBIsQualityComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStrIsQualityComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBKeeperUserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBKeeperUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBOperatorUserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBOperatorUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCompleteDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBTMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBTMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBReviewQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBPackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBShelvePackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBTrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBUnQualityQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBPostQty;
        private System.Windows.Forms.BindingSource bsMain;

    }
}