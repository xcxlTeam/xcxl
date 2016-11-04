namespace WMS.Check
{
    partial class FrmReCheck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.bsCheck = new System.Windows.Forms.BindingSource(this.components);
            this.gbMiddle = new System.Windows.Forms.GroupBox();
            this.lblDifferenceQty = new ChensControl.ChensLabel();
            this.lblStrCheckType = new ChensControl.ChensLabel();
            this.lblCheckNo = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCheckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrProfitLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDifferenceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheck)).BeginInit();
            this.gbMiddle.SuspendLayout();
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
            this.tsmiReCheck,
            this.tsmiExport,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Size = new System.Drawing.Size(68, 21);
            this.tsmiSearch.Text = "刷新数据";
            this.tsmiSearch.Visible = false;
            this.tsmiSearch.Click += new System.EventHandler(this.tsmiSearch_Click);
            // 
            // tsmiReCheck
            // 
            this.tsmiReCheck.Name = "tsmiReCheck";
            this.tsmiReCheck.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiReCheck.Size = new System.Drawing.Size(80, 21);
            this.tsmiReCheck.Text = "保存并关闭";
            this.tsmiReCheck.Click += new System.EventHandler(this.tsmiReCheck_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(44, 21);
            this.tsmiExport.Text = "导出";
            this.tsmiExport.Visible = false;
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.CheckDetailsInfo);
            // 
            // bsCheck
            // 
            this.bsCheck.DataSource = typeof(WMS.WebService.CheckInfo);
            // 
            // gbMiddle
            // 
            this.gbMiddle.Controls.Add(this.lblDifferenceQty);
            this.gbMiddle.Controls.Add(this.lblStrCheckType);
            this.gbMiddle.Controls.Add(this.lblCheckNo);
            this.gbMiddle.Controls.Add(this.chensLabel3);
            this.gbMiddle.Controls.Add(this.chensLabel2);
            this.gbMiddle.Controls.Add(this.chensLabel1);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMiddle.Location = new System.Drawing.Point(0, 25);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 60);
            this.gbMiddle.TabIndex = 8;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "盘点信息";
            // 
            // lblDifferenceQty
            // 
            this.lblDifferenceQty.AutoSize = true;
            this.lblDifferenceQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCheck, "DifferenceQty", true));
            this.lblDifferenceQty.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDifferenceQty.ForeColor = System.Drawing.Color.Red;
            this.lblDifferenceQty.Location = new System.Drawing.Point(571, 18);
            this.lblDifferenceQty.Name = "lblDifferenceQty";
            this.lblDifferenceQty.Size = new System.Drawing.Size(80, 26);
            this.lblDifferenceQty.TabIndex = 6;
            this.lblDifferenceQty.Text = "-10000";
            this.lblDifferenceQty.TextChanged += new System.EventHandler(this.lblDifferenceQty_TextChanged);
            // 
            // lblStrCheckType
            // 
            this.lblStrCheckType.AutoSize = true;
            this.lblStrCheckType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCheck, "StrCheckType", true));
            this.lblStrCheckType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStrCheckType.Location = new System.Drawing.Point(329, 20);
            this.lblStrCheckType.Name = "lblStrCheckType";
            this.lblStrCheckType.Size = new System.Drawing.Size(74, 22);
            this.lblStrCheckType.TabIndex = 5;
            this.lblStrCheckType.Text = "按保管员";
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCheck, "CheckNo", true));
            this.lblCheckNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckNo.Location = new System.Drawing.Point(99, 21);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(136, 22);
            this.lblCheckNo.TabIndex = 4;
            this.lblCheckNo.Text = "P201501XXXXX";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 24);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 2;
            this.chensLabel3.Text = "盈亏数量";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "盘点类型";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(68, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "主盘点单号";
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.cbxSelectAll);
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Controls.Add(this.pageList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 85);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 652);
            this.gbBottom.TabIndex = 9;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "查询结果";
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.BackColor = System.Drawing.Color.Gainsboro;
            this.cbxSelectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.cbxSelectAll.Location = new System.Drawing.Point(6, 20);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(51, 21);
            this.cbxSelectAll.TabIndex = 6;
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
            this.colEdit,
            this.colCheckNo,
            this.colCheckType,
            this.colStrCheckType,
            this.colWarehouseNo,
            this.colWarehouseName,
            this.colHouseNo,
            this.colHouseName,
            this.colAreaNo,
            this.colAreaName,
            this.colScanWarehouseNo,
            this.colScanHouseNo,
            this.colScanAreaNo,
            this.colMaterialNo,
            this.colMaterialDesc,
            this.colAccountQty,
            this.colScanQty,
            this.colStrProfitLoss,
            this.colDifferenceQty});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
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
            this.dgvList.Size = new System.Drawing.Size(986, 608);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvList_Scroll);
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "选择";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect.Width = 60;
            // 
            // colEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "查看";
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEdit.HeaderText = "盘点明细";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "查看";
            this.colEdit.Visible = false;
            this.colEdit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // colCheckNo
            // 
            this.colCheckNo.DataPropertyName = "CheckNo";
            this.colCheckNo.HeaderText = "盘点单号";
            this.colCheckNo.Name = "colCheckNo";
            this.colCheckNo.Visible = false;
            // 
            // colCheckType
            // 
            this.colCheckType.DataPropertyName = "CheckType";
            this.colCheckType.HeaderText = "盘点类型";
            this.colCheckType.Name = "colCheckType";
            this.colCheckType.Visible = false;
            // 
            // colStrCheckType
            // 
            this.colStrCheckType.DataPropertyName = "StrCheckType";
            this.colStrCheckType.HeaderText = "盘点类型";
            this.colStrCheckType.Name = "colStrCheckType";
            this.colStrCheckType.Visible = false;
            // 
            // colWarehouseNo
            // 
            this.colWarehouseNo.DataPropertyName = "WarehouseNo";
            this.colWarehouseNo.HeaderText = "仓库编号";
            this.colWarehouseNo.Name = "colWarehouseNo";
            this.colWarehouseNo.Visible = false;
            // 
            // colWarehouseName
            // 
            this.colWarehouseName.DataPropertyName = "WarehouseName";
            this.colWarehouseName.HeaderText = "仓库名称";
            this.colWarehouseName.Name = "colWarehouseName";
            this.colWarehouseName.Visible = false;
            this.colWarehouseName.Width = 200;
            // 
            // colHouseNo
            // 
            this.colHouseNo.DataPropertyName = "HouseNo";
            this.colHouseNo.HeaderText = "库区编号";
            this.colHouseNo.Name = "colHouseNo";
            this.colHouseNo.Visible = false;
            // 
            // colHouseName
            // 
            this.colHouseName.DataPropertyName = "HouseName";
            this.colHouseName.HeaderText = "库区名称";
            this.colHouseName.Name = "colHouseName";
            this.colHouseName.Visible = false;
            // 
            // colAreaNo
            // 
            this.colAreaNo.DataPropertyName = "AreaNo";
            this.colAreaNo.HeaderText = "货位编号";
            this.colAreaNo.Name = "colAreaNo";
            this.colAreaNo.Visible = false;
            // 
            // colAreaName
            // 
            this.colAreaName.DataPropertyName = "AreaName";
            this.colAreaName.HeaderText = "货位名称";
            this.colAreaName.Name = "colAreaName";
            this.colAreaName.Visible = false;
            // 
            // colScanWarehouseNo
            // 
            this.colScanWarehouseNo.DataPropertyName = "ScanWarehouseNo";
            this.colScanWarehouseNo.HeaderText = "实盘仓库";
            this.colScanWarehouseNo.Name = "colScanWarehouseNo";
            this.colScanWarehouseNo.Visible = false;
            // 
            // colScanHouseNo
            // 
            this.colScanHouseNo.DataPropertyName = "ScanHouseNo";
            this.colScanHouseNo.HeaderText = "实盘库区";
            this.colScanHouseNo.Name = "colScanHouseNo";
            this.colScanHouseNo.Visible = false;
            // 
            // colScanAreaNo
            // 
            this.colScanAreaNo.DataPropertyName = "ScanAreaNo";
            this.colScanAreaNo.HeaderText = "实盘货位";
            this.colScanAreaNo.Name = "colScanAreaNo";
            this.colScanAreaNo.Visible = false;
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "MaterialNo";
            this.colMaterialNo.HeaderText = "物料编号";
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.Visible = false;
            this.colMaterialNo.Width = 150;
            // 
            // colMaterialDesc
            // 
            this.colMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colMaterialDesc.HeaderText = "物料描述";
            this.colMaterialDesc.Name = "colMaterialDesc";
            this.colMaterialDesc.Visible = false;
            this.colMaterialDesc.Width = 200;
            // 
            // colAccountQty
            // 
            this.colAccountQty.DataPropertyName = "AccountQty";
            this.colAccountQty.HeaderText = "账存数量";
            this.colAccountQty.Name = "colAccountQty";
            // 
            // colScanQty
            // 
            this.colScanQty.DataPropertyName = "ScanQty";
            this.colScanQty.HeaderText = "实盘数量";
            this.colScanQty.Name = "colScanQty";
            // 
            // colStrProfitLoss
            // 
            this.colStrProfitLoss.DataPropertyName = "StrProfitLoss";
            this.colStrProfitLoss.HeaderText = "盈亏状态";
            this.colStrProfitLoss.Name = "colStrProfitLoss";
            // 
            // colDifferenceQty
            // 
            this.colDifferenceQty.DataPropertyName = "DifferenceQty";
            this.colDifferenceQty.HeaderText = "盈亏数量";
            this.colDifferenceQty.Name = "colDifferenceQty";
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
            this.pageList.Location = new System.Drawing.Point(3, 628);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.Visible = false;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // FrmReCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 737);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.msMain);
            this.Name = "FrmReCheck";
            this.Text = "复盘确认";
            this.Load += new System.EventHandler(this.FrmReCheck_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheck)).EndInit();
            this.gbMiddle.ResumeLayout(false);
            this.gbMiddle.PerformLayout();
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiReCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.BindingSource bsCheck;
        private System.Windows.Forms.GroupBox gbMiddle;
        private ChensControl.ChensLabel lblDifferenceQty;
        private ChensControl.ChensLabel lblStrCheckType;
        private ChensControl.ChensLabel lblCheckNo;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrProfitLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDifferenceQty;
        private System.Windows.Forms.CheckBox cbxSelectAll;
    }
}