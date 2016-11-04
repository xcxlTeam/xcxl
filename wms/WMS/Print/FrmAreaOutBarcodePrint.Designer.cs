namespace WMS.Print
{
    partial class FrmAreaOutBarcodePrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage2 = new ChensControl.DividPage();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.txtAreaNo = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvMain = new ChensControl.ChensDataGridView();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrAreaType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHContactUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHContactPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHLocationDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrAreaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageMain = new ChensControl.ChensPage();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvDetail = new ChensControl.ChensDataGridView();
            this.pageDetail = new ChensControl.ChensPage();
            this.msMain.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiImport,
            this.tsmiPrint,
            this.tsmiChangePrinter});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(992, 29);
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
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(68, 21);
            this.tsmiImport.Text = "导入库存";
            this.tsmiImport.Visible = false;
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrint.Text = "箱号打印";
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(80, 21);
            this.tsmiChangePrinter.Text = "设置打印机";
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.txtAreaNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 29);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gbHeader.Size = new System.Drawing.Size(992, 60);
            this.gbHeader.TabIndex = 5;
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
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 29);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(329, 23);
            this.txtMaterialNo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 3;
            this.txtMaterialNo.TextEnabled = false;
            // 
            // txtAreaNo
            // 
            this.txtAreaNo.BackColor = System.Drawing.Color.White;
            this.txtAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "AreaNo", true));
            this.txtAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaNo.HotTrack = false;
            this.txtAreaNo.Location = new System.Drawing.Point(87, 23);
            this.txtAreaNo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtAreaNo.Name = "txtAreaNo";
            this.txtAreaNo.Size = new System.Drawing.Size(150, 23);
            this.txtAreaNo.TabIndex = 2;
            this.txtAreaNo.TextEnabled = false;
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.AreaInfo);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "物料编号";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "货位编号";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 89);
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
            this.scMain.Size = new System.Drawing.Size(992, 684);
            this.scMain.SplitterDistance = 350;
            this.scMain.TabIndex = 6;
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dgvMain);
            this.gbMiddle.Controls.Add(this.pageMain);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 0);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 350);
            this.gbMiddle.TabIndex = 7;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "查询结果";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHID,
            this.colHWarehouseNo,
            this.colHWarehouseName,
            this.colHHouseNo,
            this.colBHouseName,
            this.colHAreaNo,
            this.colHAreaName,
            this.colHAreaType,
            this.colHStrAreaType,
            this.colHContactUser,
            this.colHContactPhone,
            this.colHLocationDesc,
            this.colHAreaStatus,
            this.colHStrAreaStatus,
            this.colHAddress,
            this.colHHouseID,
            this.colHIsDel,
            this.colHCreater,
            this.colHCreateTime,
            this.colHModifyer,
            this.colHModifyTime});
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvMain.GridColor = System.Drawing.Color.LightGray;
            this.dgvMain.HaveCopyMenu = true;
            this.dgvMain.Location = new System.Drawing.Point(3, 19);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(986, 308);
            this.dgvMain.TabIndex = 1;
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            // 
            // colHWarehouseNo
            // 
            this.colHWarehouseNo.DataPropertyName = "WarehouseNo";
            this.colHWarehouseNo.HeaderText = "仓库编号";
            this.colHWarehouseNo.Name = "colHWarehouseNo";
            this.colHWarehouseNo.ReadOnly = true;
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
            // 
            // colBHouseName
            // 
            this.colBHouseName.DataPropertyName = "HouseName";
            this.colBHouseName.HeaderText = "库区名称";
            this.colBHouseName.Name = "colBHouseName";
            this.colBHouseName.ReadOnly = true;
            // 
            // colHAreaNo
            // 
            this.colHAreaNo.DataPropertyName = "AreaNo";
            this.colHAreaNo.HeaderText = "货位编号";
            this.colHAreaNo.Name = "colHAreaNo";
            this.colHAreaNo.ReadOnly = true;
            // 
            // colHAreaName
            // 
            this.colHAreaName.DataPropertyName = "AreaName";
            this.colHAreaName.HeaderText = "货位名称";
            this.colHAreaName.Name = "colHAreaName";
            this.colHAreaName.ReadOnly = true;
            // 
            // colHAreaType
            // 
            this.colHAreaType.DataPropertyName = "AreaType";
            this.colHAreaType.HeaderText = "货位类型";
            this.colHAreaType.Name = "colHAreaType";
            this.colHAreaType.ReadOnly = true;
            this.colHAreaType.Visible = false;
            // 
            // colHStrAreaType
            // 
            this.colHStrAreaType.DataPropertyName = "StrAreaType";
            this.colHStrAreaType.HeaderText = "货位类型";
            this.colHStrAreaType.Name = "colHStrAreaType";
            this.colHStrAreaType.ReadOnly = true;
            // 
            // colHContactUser
            // 
            this.colHContactUser.DataPropertyName = "ContactUser";
            this.colHContactUser.HeaderText = "联系人";
            this.colHContactUser.Name = "colHContactUser";
            this.colHContactUser.ReadOnly = true;
            // 
            // colHContactPhone
            // 
            this.colHContactPhone.DataPropertyName = "ContactPhone";
            this.colHContactPhone.HeaderText = "联系电话";
            this.colHContactPhone.Name = "colHContactPhone";
            this.colHContactPhone.ReadOnly = true;
            // 
            // colHLocationDesc
            // 
            this.colHLocationDesc.DataPropertyName = "LocationDesc";
            this.colHLocationDesc.HeaderText = "货位描述";
            this.colHLocationDesc.Name = "colHLocationDesc";
            this.colHLocationDesc.ReadOnly = true;
            // 
            // colHAreaStatus
            // 
            this.colHAreaStatus.DataPropertyName = "AreaStatus";
            this.colHAreaStatus.HeaderText = "货位状态";
            this.colHAreaStatus.Name = "colHAreaStatus";
            this.colHAreaStatus.ReadOnly = true;
            this.colHAreaStatus.Visible = false;
            // 
            // colHStrAreaStatus
            // 
            this.colHStrAreaStatus.DataPropertyName = "StrAreaStatus";
            this.colHStrAreaStatus.HeaderText = "货位状态";
            this.colHStrAreaStatus.Name = "colHStrAreaStatus";
            this.colHStrAreaStatus.ReadOnly = true;
            // 
            // colHAddress
            // 
            this.colHAddress.DataPropertyName = "Address";
            this.colHAddress.HeaderText = "地址";
            this.colHAddress.Name = "colHAddress";
            this.colHAddress.ReadOnly = true;
            this.colHAddress.Visible = false;
            // 
            // colHHouseID
            // 
            this.colHHouseID.DataPropertyName = "HouseID";
            this.colHHouseID.HeaderText = "库区ID";
            this.colHHouseID.Name = "colHHouseID";
            this.colHHouseID.ReadOnly = true;
            this.colHHouseID.Visible = false;
            // 
            // colHIsDel
            // 
            this.colHIsDel.DataPropertyName = "IsDel";
            this.colHIsDel.HeaderText = "删除标识";
            this.colHIsDel.Name = "colHIsDel";
            this.colHIsDel.ReadOnly = true;
            this.colHIsDel.Visible = false;
            // 
            // colHCreater
            // 
            this.colHCreater.DataPropertyName = "Creater";
            this.colHCreater.HeaderText = "创建人";
            this.colHCreater.Name = "colHCreater";
            this.colHCreater.ReadOnly = true;
            this.colHCreater.Visible = false;
            // 
            // colHCreateTime
            // 
            this.colHCreateTime.DataPropertyName = "CreateTime";
            this.colHCreateTime.HeaderText = "创建时间";
            this.colHCreateTime.Name = "colHCreateTime";
            this.colHCreateTime.ReadOnly = true;
            this.colHCreateTime.Visible = false;
            // 
            // colHModifyer
            // 
            this.colHModifyer.DataPropertyName = "Modifyer";
            this.colHModifyer.HeaderText = "修改人";
            this.colHModifyer.Name = "colHModifyer";
            this.colHModifyer.ReadOnly = true;
            this.colHModifyer.Visible = false;
            // 
            // colHModifyTime
            // 
            this.colHModifyTime.DataPropertyName = "ModifyTime";
            this.colHModifyTime.HeaderText = "修改时间";
            this.colHModifyTime.Name = "colHModifyTime";
            this.colHModifyTime.ReadOnly = true;
            this.colHModifyTime.Visible = false;
            // 
            // pageMain
            // 
            this.pageMain.CurrentPageNumber = 0;
            dividPage1.CurrentPageNumber = 0;
            dividPage1.CurrentPageRecordCounts = 0;
            dividPage1.CurrentPageShowCounts = 10;
            dividPage1.DefaultPageShowCounts = 10;
            dividPage1.PagesCount = 0;
            dividPage1.RecordCounts = 0;
            this.pageMain.dDividPage = dividPage1;
            this.pageMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageMain.Location = new System.Drawing.Point(3, 327);
            this.pageMain.Name = "pageMain";
            this.pageMain.Size = new System.Drawing.Size(986, 20);
            this.pageMain.TabIndex = 0;
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
            this.gbBottom.Size = new System.Drawing.Size(992, 330);
            this.gbBottom.TabIndex = 7;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "外箱明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetail.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvDetail.GridColor = System.Drawing.Color.LightGray;
            this.dgvDetail.HaveCopyMenu = true;
            this.dgvDetail.Location = new System.Drawing.Point(3, 19);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetail.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(986, 288);
            this.dgvDetail.TabIndex = 1;
            // 
            // pageDetail
            // 
            this.pageDetail.CurrentPageNumber = 0;
            dividPage2.CurrentPageNumber = 0;
            dividPage2.CurrentPageRecordCounts = 0;
            dividPage2.CurrentPageShowCounts = 10;
            dividPage2.DefaultPageShowCounts = 10;
            dividPage2.PagesCount = 0;
            dividPage2.RecordCounts = 0;
            this.pageDetail.dDividPage = dividPage2;
            this.pageDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDetail.Location = new System.Drawing.Point(3, 307);
            this.pageDetail.Name = "pageDetail";
            this.pageDetail.Size = new System.Drawing.Size(986, 20);
            this.pageDetail.TabIndex = 0;
            // 
            // FrmAreaOutBarcodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmAreaOutBarcodePrint";
            this.Text = "货位外箱标签打印";
            this.Load += new System.EventHandler(this.FrmAreaOutBarcodePrint_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensTextBox txtAreaNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.SplitContainer scMain;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvMain;
        private ChensControl.ChensPage pageMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrAreaType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHContactUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHContactPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHLocationDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrAreaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyTime;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvDetail;
        private ChensControl.ChensPage pageDetail;
        private System.Windows.Forms.BindingSource bsMain;
    }
}