namespace WMS.Basic
{
    partial class FrmAreaList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage2 = new ChensControl.DividPage();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvDetail = new ChensControl.ChensDataGridView();
            this.colBEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAreaType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStrAreaType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBContactUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBContactPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBLocationDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAreaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStrAreaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageDetail = new ChensControl.ChensPage();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.txtCreater = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtAreaNo = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtHouseNo = new ChensControl.ChensTextBox();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintArea = new System.Windows.Forms.ToolStripMenuItem();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHContactUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHContactPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaUsingCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAreaRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHLocationDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrHouseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.gbHeader.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.HouseInfo);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 120);
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
            this.scMain.Size = new System.Drawing.Size(992, 653);
            this.scMain.SplitterDistance = 250;
            this.scMain.TabIndex = 5;
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
            this.gbMiddle.Size = new System.Drawing.Size(992, 250);
            this.gbMiddle.TabIndex = 5;
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
            this.colHID,
            this.colHWarehouseNo,
            this.colHWarehouseName,
            this.colHHouseNo,
            this.colHHouseName,
            this.colHHouseType,
            this.colHStrHouseType,
            this.colHContactUser,
            this.colHContactPhone,
            this.colHAreaCount,
            this.colHAreaUsingCount,
            this.colHAreaRate,
            this.colHLocationDesc,
            this.colHHouseStatus,
            this.colHStrHouseStatus,
            this.colHAddress,
            this.colHWarehouseID,
            this.colHIsDel,
            this.colHCreater,
            this.colHCreateTime,
            this.colHModifyer,
            this.colHModifyTime});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 201);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
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
            this.pageList.Location = new System.Drawing.Point(3, 220);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 27);
            this.pageList.TabIndex = 0;
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
            this.gbBottom.Size = new System.Drawing.Size(992, 399);
            this.gbBottom.TabIndex = 6;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "货位明细";
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
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBEdit,
            this.colBID,
            this.colBWarehouseNo,
            this.colBWarehouseName,
            this.colBHouseNo,
            this.colBHouseName,
            this.colBAreaNo,
            this.colBAreaName,
            this.colBAreaType,
            this.colBStrAreaType,
            this.colBContactUser,
            this.colBContactPhone,
            this.colBLocationDesc,
            this.colBAreaStatus,
            this.colBStrAreaStatus,
            this.colBAddress,
            this.colBHouseID,
            this.colBIsDel,
            this.colBCreater,
            this.colBCreateTime,
            this.colBModifyer,
            this.colBModifyTime});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetail.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvDetail.GridColor = System.Drawing.Color.LightGray;
            this.dgvDetail.HaveCopyMenu = true;
            this.dgvDetail.Location = new System.Drawing.Point(3, 19);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetail.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(986, 350);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // colBEdit
            // 
            dataGridViewCellStyle7.NullValue = "编辑";
            this.colBEdit.DefaultCellStyle = dataGridViewCellStyle7;
            this.colBEdit.HeaderText = "编辑";
            this.colBEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colBEdit.Name = "colBEdit";
            this.colBEdit.ReadOnly = true;
            this.colBEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBEdit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // colBID
            // 
            this.colBID.DataPropertyName = "ID";
            this.colBID.HeaderText = "ID";
            this.colBID.Name = "colBID";
            this.colBID.ReadOnly = true;
            this.colBID.Visible = false;
            // 
            // colBWarehouseNo
            // 
            this.colBWarehouseNo.DataPropertyName = "WarehouseNo";
            this.colBWarehouseNo.HeaderText = "仓库编号";
            this.colBWarehouseNo.Name = "colBWarehouseNo";
            this.colBWarehouseNo.ReadOnly = true;
            this.colBWarehouseNo.Visible = false;
            // 
            // colBWarehouseName
            // 
            this.colBWarehouseName.DataPropertyName = "WarehouseName";
            this.colBWarehouseName.HeaderText = "仓库名称";
            this.colBWarehouseName.Name = "colBWarehouseName";
            this.colBWarehouseName.ReadOnly = true;
            this.colBWarehouseName.Visible = false;
            this.colBWarehouseName.Width = 200;
            // 
            // colBHouseNo
            // 
            this.colBHouseNo.DataPropertyName = "HouseNo";
            this.colBHouseNo.HeaderText = "库区编号";
            this.colBHouseNo.Name = "colBHouseNo";
            this.colBHouseNo.ReadOnly = true;
            this.colBHouseNo.Visible = false;
            // 
            // colBHouseName
            // 
            this.colBHouseName.DataPropertyName = "HouseName";
            this.colBHouseName.HeaderText = "库区名称";
            this.colBHouseName.Name = "colBHouseName";
            this.colBHouseName.ReadOnly = true;
            this.colBHouseName.Visible = false;
            this.colBHouseName.Width = 200;
            // 
            // colBAreaNo
            // 
            this.colBAreaNo.DataPropertyName = "AreaNo";
            this.colBAreaNo.HeaderText = "货位编号";
            this.colBAreaNo.Name = "colBAreaNo";
            this.colBAreaNo.ReadOnly = true;
            // 
            // colBAreaName
            // 
            this.colBAreaName.DataPropertyName = "AreaName";
            this.colBAreaName.HeaderText = "货位名称";
            this.colBAreaName.Name = "colBAreaName";
            this.colBAreaName.ReadOnly = true;
            this.colBAreaName.Width = 200;
            // 
            // colBAreaType
            // 
            this.colBAreaType.DataPropertyName = "AreaType";
            this.colBAreaType.HeaderText = "货位类型";
            this.colBAreaType.Name = "colBAreaType";
            this.colBAreaType.ReadOnly = true;
            this.colBAreaType.Visible = false;
            // 
            // colBStrAreaType
            // 
            this.colBStrAreaType.DataPropertyName = "StrAreaType";
            this.colBStrAreaType.HeaderText = "货位类型";
            this.colBStrAreaType.Name = "colBStrAreaType";
            this.colBStrAreaType.ReadOnly = true;
            // 
            // colBContactUser
            // 
            this.colBContactUser.DataPropertyName = "ContactUser";
            this.colBContactUser.HeaderText = "联系人";
            this.colBContactUser.Name = "colBContactUser";
            this.colBContactUser.ReadOnly = true;
            // 
            // colBContactPhone
            // 
            this.colBContactPhone.DataPropertyName = "ContactPhone";
            this.colBContactPhone.HeaderText = "联系电话";
            this.colBContactPhone.Name = "colBContactPhone";
            this.colBContactPhone.ReadOnly = true;
            // 
            // colBLocationDesc
            // 
            this.colBLocationDesc.DataPropertyName = "LocationDesc";
            this.colBLocationDesc.HeaderText = "货位描述";
            this.colBLocationDesc.Name = "colBLocationDesc";
            this.colBLocationDesc.ReadOnly = true;
            // 
            // colBAreaStatus
            // 
            this.colBAreaStatus.DataPropertyName = "AreaStatus";
            this.colBAreaStatus.HeaderText = "货位状态";
            this.colBAreaStatus.Name = "colBAreaStatus";
            this.colBAreaStatus.ReadOnly = true;
            this.colBAreaStatus.Visible = false;
            // 
            // colBStrAreaStatus
            // 
            this.colBStrAreaStatus.DataPropertyName = "StrAreaStatus";
            this.colBStrAreaStatus.HeaderText = "货位状态";
            this.colBStrAreaStatus.Name = "colBStrAreaStatus";
            this.colBStrAreaStatus.ReadOnly = true;
            // 
            // colBAddress
            // 
            this.colBAddress.DataPropertyName = "Address";
            this.colBAddress.HeaderText = "地址";
            this.colBAddress.Name = "colBAddress";
            this.colBAddress.ReadOnly = true;
            this.colBAddress.Visible = false;
            // 
            // colBHouseID
            // 
            this.colBHouseID.DataPropertyName = "HouseID";
            this.colBHouseID.HeaderText = "库区ID";
            this.colBHouseID.Name = "colBHouseID";
            this.colBHouseID.ReadOnly = true;
            this.colBHouseID.Visible = false;
            // 
            // colBIsDel
            // 
            this.colBIsDel.DataPropertyName = "IsDel";
            this.colBIsDel.HeaderText = "删除标识";
            this.colBIsDel.Name = "colBIsDel";
            this.colBIsDel.ReadOnly = true;
            this.colBIsDel.Visible = false;
            // 
            // colBCreater
            // 
            this.colBCreater.DataPropertyName = "Creater";
            this.colBCreater.HeaderText = "创建人";
            this.colBCreater.Name = "colBCreater";
            this.colBCreater.ReadOnly = true;
            // 
            // colBCreateTime
            // 
            this.colBCreateTime.DataPropertyName = "CreateTime";
            this.colBCreateTime.HeaderText = "创建时间";
            this.colBCreateTime.Name = "colBCreateTime";
            this.colBCreateTime.ReadOnly = true;
            // 
            // colBModifyer
            // 
            this.colBModifyer.DataPropertyName = "Modifyer";
            this.colBModifyer.HeaderText = "修改人";
            this.colBModifyer.Name = "colBModifyer";
            this.colBModifyer.ReadOnly = true;
            // 
            // colBModifyTime
            // 
            this.colBModifyTime.DataPropertyName = "ModifyTime";
            this.colBModifyTime.HeaderText = "修改时间";
            this.colBModifyTime.Name = "colBModifyTime";
            this.colBModifyTime.ReadOnly = true;
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
            this.pageDetail.Location = new System.Drawing.Point(3, 369);
            this.pageDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageDetail.Name = "pageDetail";
            this.pageDetail.Size = new System.Drawing.Size(986, 27);
            this.pageDetail.TabIndex = 0;
            this.pageDetail.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageDetail_ChensPageChange);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.txtCreater);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.txtAreaNo);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtHouseNo);
            this.gbHeader.Controls.Add(this.txtWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 3;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(571, 58);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 13;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 12;
            this.chensLabel5.Text = "——";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(267, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 11;
            this.chensLabel6.Text = "创建日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(329, 58);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 10;
            this.dtpStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCreater
            // 
            this.txtCreater.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCreater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreater.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCreater.HotTrack = false;
            this.txtCreater.Location = new System.Drawing.Point(87, 58);
            this.txtCreater.Name = "txtCreater";
            this.txtCreater.Size = new System.Drawing.Size(150, 23);
            this.txtCreater.TabIndex = 9;
            this.txtCreater.TextEnabled = false;
            this.txtCreater.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(44, 17);
            this.chensLabel4.TabIndex = 8;
            this.chensLabel4.Text = "创建人";
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
            this.txtAreaNo.TabIndex = 7;
            this.txtAreaNo.TextEnabled = false;
            this.txtAreaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(32, 17);
            this.chensLabel3.TabIndex = 5;
            this.chensLabel3.Text = "货位";
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
            // txtHouseNo
            // 
            this.txtHouseNo.BackColor = System.Drawing.Color.White;
            this.txtHouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "HouseNo", true));
            this.txtHouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtHouseNo.HotTrack = false;
            this.txtHouseNo.Location = new System.Drawing.Point(329, 23);
            this.txtHouseNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHouseNo.Name = "txtHouseNo";
            this.txtHouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtHouseNo.TabIndex = 3;
            this.txtHouseNo.TextEnabled = false;
            this.txtHouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtWarehouseNo
            // 
            this.txtWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "WarehouseNo", true));
            this.txtWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseNo.HotTrack = false;
            this.txtWarehouseNo.Location = new System.Drawing.Point(87, 23);
            this.txtWarehouseNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarehouseNo.Name = "txtWarehouseNo";
            this.txtWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWarehouseNo.TabIndex = 2;
            this.txtWarehouseNo.TextEnabled = false;
            this.txtWarehouseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(32, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "库区";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(32, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "仓库";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiAdd,
            this.tsmiDownload,
            this.tsmiImport,
            this.tsmiDel,
            this.tsmiPrintArea});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 2;
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
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiAdd.Size = new System.Drawing.Size(68, 21);
            this.tsmiAdd.Text = "新增货位";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDownload
            // 
            this.tsmiDownload.Name = "tsmiDownload";
            this.tsmiDownload.Size = new System.Drawing.Size(68, 21);
            this.tsmiDownload.Text = "下载模板";
            this.tsmiDownload.Click += new System.EventHandler(this.tsmiDownload_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiImport.Size = new System.Drawing.Size(68, 21);
            this.tsmiImport.Text = "导入货位";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDel.Size = new System.Drawing.Size(68, 21);
            this.tsmiDel.Text = "删除货位";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // tsmiPrintArea
            // 
            this.tsmiPrintArea.Name = "tsmiPrintArea";
            this.tsmiPrintArea.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrintArea.Text = "打印货位";
            this.tsmiPrintArea.Click += new System.EventHandler(this.tsmiPrintArea_Click);
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
            this.colHWarehouseName.Width = 200;
            // 
            // colHHouseNo
            // 
            this.colHHouseNo.DataPropertyName = "HouseNo";
            this.colHHouseNo.HeaderText = "库区编号";
            this.colHHouseNo.Name = "colHHouseNo";
            this.colHHouseNo.ReadOnly = true;
            // 
            // colHHouseName
            // 
            this.colHHouseName.DataPropertyName = "HouseName";
            this.colHHouseName.HeaderText = "库区名称";
            this.colHHouseName.Name = "colHHouseName";
            this.colHHouseName.ReadOnly = true;
            this.colHHouseName.Width = 200;
            // 
            // colHHouseType
            // 
            this.colHHouseType.DataPropertyName = "HouseType";
            this.colHHouseType.HeaderText = "库区类型";
            this.colHHouseType.Name = "colHHouseType";
            this.colHHouseType.ReadOnly = true;
            this.colHHouseType.Visible = false;
            // 
            // colHStrHouseType
            // 
            this.colHStrHouseType.DataPropertyName = "StrHouseType";
            this.colHStrHouseType.HeaderText = "库区类型";
            this.colHStrHouseType.Name = "colHStrHouseType";
            this.colHStrHouseType.ReadOnly = true;
            this.colHStrHouseType.Visible = false;
            // 
            // colHContactUser
            // 
            this.colHContactUser.DataPropertyName = "ContactUser";
            this.colHContactUser.HeaderText = "联系人";
            this.colHContactUser.Name = "colHContactUser";
            this.colHContactUser.ReadOnly = true;
            this.colHContactUser.Visible = false;
            // 
            // colHContactPhone
            // 
            this.colHContactPhone.DataPropertyName = "ContactPhone";
            this.colHContactPhone.HeaderText = "联系电话";
            this.colHContactPhone.Name = "colHContactPhone";
            this.colHContactPhone.ReadOnly = true;
            this.colHContactPhone.Visible = false;
            // 
            // colHAreaCount
            // 
            this.colHAreaCount.DataPropertyName = "AreaCount";
            this.colHAreaCount.HeaderText = "货位总数";
            this.colHAreaCount.Name = "colHAreaCount";
            this.colHAreaCount.ReadOnly = true;
            // 
            // colHAreaUsingCount
            // 
            this.colHAreaUsingCount.DataPropertyName = "AreaUsingCount";
            this.colHAreaUsingCount.HeaderText = "货位使用数";
            this.colHAreaUsingCount.Name = "colHAreaUsingCount";
            this.colHAreaUsingCount.ReadOnly = true;
            // 
            // colHAreaRate
            // 
            this.colHAreaRate.DataPropertyName = "AreaRate";
            dataGridViewCellStyle3.Format = "P";
            this.colHAreaRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHAreaRate.HeaderText = "货位使用率";
            this.colHAreaRate.Name = "colHAreaRate";
            this.colHAreaRate.ReadOnly = true;
            // 
            // colHLocationDesc
            // 
            this.colHLocationDesc.DataPropertyName = "LocationDesc";
            this.colHLocationDesc.HeaderText = "库区描述";
            this.colHLocationDesc.Name = "colHLocationDesc";
            this.colHLocationDesc.ReadOnly = true;
            // 
            // colHHouseStatus
            // 
            this.colHHouseStatus.DataPropertyName = "HouseStatus";
            this.colHHouseStatus.HeaderText = "库区状态";
            this.colHHouseStatus.Name = "colHHouseStatus";
            this.colHHouseStatus.ReadOnly = true;
            this.colHHouseStatus.Visible = false;
            // 
            // colHStrHouseStatus
            // 
            this.colHStrHouseStatus.DataPropertyName = "StrHouseStatus";
            this.colHStrHouseStatus.HeaderText = "库区状态";
            this.colHStrHouseStatus.Name = "colHStrHouseStatus";
            this.colHStrHouseStatus.ReadOnly = true;
            // 
            // colHAddress
            // 
            this.colHAddress.DataPropertyName = "Address";
            this.colHAddress.HeaderText = "地址";
            this.colHAddress.Name = "colHAddress";
            this.colHAddress.ReadOnly = true;
            this.colHAddress.Visible = false;
            // 
            // colHWarehouseID
            // 
            this.colHWarehouseID.DataPropertyName = "WarehouseID";
            this.colHWarehouseID.HeaderText = "仓库ID";
            this.colHWarehouseID.Name = "colHWarehouseID";
            this.colHWarehouseID.ReadOnly = true;
            this.colHWarehouseID.Visible = false;
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
            // FrmAreaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmAreaList";
            this.Text = "货位设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAreaList_FormClosed);
            this.Load += new System.EventHandler(this.FrmAreaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtHouseNo;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private ChensControl.ChensTextBox txtAreaNo;
        private ChensControl.ChensLabel chensLabel3;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintArea;
        private System.Windows.Forms.SplitContainer scMain;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvDetail;
        private ChensControl.ChensPage pageDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownload;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtCreater;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private System.Windows.Forms.DataGridViewLinkColumn colBEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAreaType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStrAreaType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBContactUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBContactPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBLocationDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAreaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStrAreaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBModifyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHContactUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHContactPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaUsingCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAreaRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHLocationDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrHouseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyTime;
    }
}