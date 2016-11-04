namespace WMS.Basic
{
    partial class FrmHouseList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage2 = new ChensControl.DividPage();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.txtCreater = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtHouseNo = new ChensControl.ChensTextBox();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddHouse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelHouse = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colBHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStrHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBContactUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBContactPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAreaCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAreaUsingCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBLocationDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHouseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBStrHouseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageDetail = new ChensControl.ChensPage();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrWarehouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHContactUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHContactPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseUsingCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHHouseRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHLocationDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrWarehouseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.gbHeader.SuspendLayout();
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
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.WarehouseInfo);
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
            this.dtpEndTime.TabIndex = 11;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 18;
            this.chensLabel5.Text = "——";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(267, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 17;
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
            this.chensLabel4.TabIndex = 14;
            this.chensLabel4.Text = "创建人";
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
            this.tsmiAddHouse,
            this.tsmiDelHouse});
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
            // tsmiAddHouse
            // 
            this.tsmiAddHouse.Name = "tsmiAddHouse";
            this.tsmiAddHouse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiAddHouse.Size = new System.Drawing.Size(68, 21);
            this.tsmiAddHouse.Text = "新增库区";
            this.tsmiAddHouse.Click += new System.EventHandler(this.tsmiAddHouse_Click);
            // 
            // tsmiDelHouse
            // 
            this.tsmiDelHouse.Name = "tsmiDelHouse";
            this.tsmiDelHouse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDelHouse.Size = new System.Drawing.Size(68, 21);
            this.tsmiDelHouse.Text = "删除库区";
            this.tsmiDelHouse.Click += new System.EventHandler(this.tsmiDelHouse_Click);
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
            this.scMain.TabIndex = 7;
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
            this.colHID,
            this.colHWarehouseNo,
            this.colHWarehouseName,
            this.colHWarehouseType,
            this.colHStrWarehouseType,
            this.colHContactUser,
            this.colHContactPhone,
            this.colHHouseCount,
            this.colHHouseUsingCount,
            this.colHHouseRate,
            this.colHLocationDesc,
            this.colHWarehouseStatus,
            this.colHStrWarehouseStatus,
            this.colHAddress,
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 201);
            this.dgvList.TabIndex = 3;
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
            this.gbBottom.TabIndex = 8;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "库区明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBEdit,
            this.colBID,
            this.colBWarehouseNo,
            this.colBWarehouseName,
            this.colBHouseNo,
            this.colBHouseName,
            this.colBHouseType,
            this.colBStrHouseType,
            this.colBContactUser,
            this.colBContactPhone,
            this.colBAreaCount,
            this.colBAreaUsingCount,
            this.colBLocationDesc,
            this.colBHouseStatus,
            this.colBStrHouseStatus,
            this.colBAddress,
            this.colBWarehouseID,
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetail.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(986, 350);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // colBEdit
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "编辑";
            this.colBEdit.DefaultCellStyle = dataGridViewCellStyle8;
            this.colBEdit.HeaderText = "编辑";
            this.colBEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colBEdit.LinkColor = System.Drawing.Color.Blue;
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
            // 
            // colBHouseName
            // 
            this.colBHouseName.DataPropertyName = "HouseName";
            this.colBHouseName.HeaderText = "库区名称";
            this.colBHouseName.Name = "colBHouseName";
            this.colBHouseName.ReadOnly = true;
            this.colBHouseName.Width = 200;
            // 
            // colBHouseType
            // 
            this.colBHouseType.DataPropertyName = "HouseType";
            this.colBHouseType.HeaderText = "库区类型";
            this.colBHouseType.Name = "colBHouseType";
            this.colBHouseType.ReadOnly = true;
            this.colBHouseType.Visible = false;
            // 
            // colBStrHouseType
            // 
            this.colBStrHouseType.DataPropertyName = "StrHouseType";
            this.colBStrHouseType.HeaderText = "库区类型";
            this.colBStrHouseType.Name = "colBStrHouseType";
            this.colBStrHouseType.ReadOnly = true;
            this.colBStrHouseType.Visible = false;
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
            // colBAreaCount
            // 
            this.colBAreaCount.DataPropertyName = "AreaCount";
            this.colBAreaCount.HeaderText = "货位总数";
            this.colBAreaCount.Name = "colBAreaCount";
            this.colBAreaCount.ReadOnly = true;
            this.colBAreaCount.Visible = false;
            // 
            // colBAreaUsingCount
            // 
            this.colBAreaUsingCount.DataPropertyName = "AreaUsingCount";
            this.colBAreaUsingCount.HeaderText = "货位使用数";
            this.colBAreaUsingCount.Name = "colBAreaUsingCount";
            this.colBAreaUsingCount.ReadOnly = true;
            this.colBAreaUsingCount.Visible = false;
            // 
            // colBLocationDesc
            // 
            this.colBLocationDesc.DataPropertyName = "LocationDesc";
            this.colBLocationDesc.HeaderText = "库区描述";
            this.colBLocationDesc.Name = "colBLocationDesc";
            this.colBLocationDesc.ReadOnly = true;
            // 
            // colBHouseStatus
            // 
            this.colBHouseStatus.DataPropertyName = "HouseStatus";
            this.colBHouseStatus.HeaderText = "库区状态";
            this.colBHouseStatus.Name = "colBHouseStatus";
            this.colBHouseStatus.ReadOnly = true;
            this.colBHouseStatus.Visible = false;
            // 
            // colBStrHouseStatus
            // 
            this.colBStrHouseStatus.DataPropertyName = "StrHouseStatus";
            this.colBStrHouseStatus.HeaderText = "库区状态";
            this.colBStrHouseStatus.Name = "colBStrHouseStatus";
            this.colBStrHouseStatus.ReadOnly = true;
            // 
            // colBAddress
            // 
            this.colBAddress.DataPropertyName = "Address";
            this.colBAddress.HeaderText = "地址";
            this.colBAddress.Name = "colBAddress";
            this.colBAddress.ReadOnly = true;
            this.colBAddress.Visible = false;
            // 
            // colBWarehouseID
            // 
            this.colBWarehouseID.DataPropertyName = "WarehouseID";
            this.colBWarehouseID.HeaderText = "仓库ID";
            this.colBWarehouseID.Name = "colBWarehouseID";
            this.colBWarehouseID.ReadOnly = true;
            this.colBWarehouseID.Visible = false;
            // 
            // colBIsDel
            // 
            this.colBIsDel.DataPropertyName = "IsDel";
            this.colBIsDel.HeaderText = "删除标记";
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
            // colHWarehouseType
            // 
            this.colHWarehouseType.DataPropertyName = "WarehouseType";
            this.colHWarehouseType.HeaderText = "仓库类型";
            this.colHWarehouseType.Name = "colHWarehouseType";
            this.colHWarehouseType.ReadOnly = true;
            this.colHWarehouseType.Visible = false;
            // 
            // colHStrWarehouseType
            // 
            this.colHStrWarehouseType.DataPropertyName = "StrWarehouseType";
            this.colHStrWarehouseType.HeaderText = "仓库类型";
            this.colHStrWarehouseType.Name = "colHStrWarehouseType";
            this.colHStrWarehouseType.ReadOnly = true;
            this.colHStrWarehouseType.Visible = false;
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
            // colHHouseCount
            // 
            this.colHHouseCount.DataPropertyName = "HouseCount";
            this.colHHouseCount.HeaderText = "库区总数";
            this.colHHouseCount.Name = "colHHouseCount";
            this.colHHouseCount.ReadOnly = true;
            // 
            // colHHouseUsingCount
            // 
            this.colHHouseUsingCount.DataPropertyName = "HouseUsingCount";
            this.colHHouseUsingCount.HeaderText = "库区使用数";
            this.colHHouseUsingCount.Name = "colHHouseUsingCount";
            this.colHHouseUsingCount.ReadOnly = true;
            // 
            // colHHouseRate
            // 
            this.colHHouseRate.DataPropertyName = "HouseRate";
            dataGridViewCellStyle3.Format = "P";
            this.colHHouseRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHHouseRate.HeaderText = "库区使用率";
            this.colHHouseRate.Name = "colHHouseRate";
            this.colHHouseRate.ReadOnly = true;
            // 
            // colHLocationDesc
            // 
            this.colHLocationDesc.DataPropertyName = "LocationDesc";
            this.colHLocationDesc.HeaderText = "仓库描述";
            this.colHLocationDesc.Name = "colHLocationDesc";
            this.colHLocationDesc.ReadOnly = true;
            // 
            // colHWarehouseStatus
            // 
            this.colHWarehouseStatus.DataPropertyName = "WarehouseStatus";
            this.colHWarehouseStatus.HeaderText = "仓库状态";
            this.colHWarehouseStatus.Name = "colHWarehouseStatus";
            this.colHWarehouseStatus.ReadOnly = true;
            this.colHWarehouseStatus.Visible = false;
            // 
            // colHStrWarehouseStatus
            // 
            this.colHStrWarehouseStatus.DataPropertyName = "StrWarehouseStatus";
            this.colHStrWarehouseStatus.HeaderText = "仓库状态";
            this.colHStrWarehouseStatus.Name = "colHStrWarehouseStatus";
            this.colHStrWarehouseStatus.ReadOnly = true;
            // 
            // colHAddress
            // 
            this.colHAddress.DataPropertyName = "Address";
            this.colHAddress.HeaderText = "仓库地址";
            this.colHAddress.Name = "colHAddress";
            this.colHAddress.ReadOnly = true;
            // 
            // colHIsDel
            // 
            this.colHIsDel.DataPropertyName = "IsDel";
            this.colHIsDel.HeaderText = "删除标记";
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
            // FrmHouseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmHouseList";
            this.Text = "库区设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHouseList_FormClosed);
            this.Load += new System.EventHandler(this.FrmHouseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
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
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtHouseNo;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddHouse;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelHouse;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.SplitContainer scMain;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvDetail;
        private ChensControl.ChensPage pageDetail;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensTextBox txtCreater;
        private ChensControl.ChensLabel chensLabel4;
        private System.Windows.Forms.DataGridViewLinkColumn colBEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStrHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBContactUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBContactPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAreaCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAreaUsingCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBLocationDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHouseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBStrHouseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBWarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBModifyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrWarehouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHContactUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHContactPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseUsingCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHouseRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHLocationDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrWarehouseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyTime;
    }
}