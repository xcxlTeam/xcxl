namespace WMS.Print
{
    partial class FrmInitMaterialPrint
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtWhereAreaNo = new ChensControl.ChensTextBox();
            this.txtWhereHouseNo = new ChensControl.ChensTextBox();
            this.txtWhereWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtWhereMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.txtBatchQty = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtPrintQty = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtOutPackQty = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtcinvstd = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.原料标签打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.colAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrintQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcvencode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcvenname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.chensGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.splitContainer1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.chensGroupBox1);
            this.scMain.Size = new System.Drawing.Size(976, 733);
            this.scMain.SplitterDistance = 470;
            this.scMain.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbBottom);
            this.splitContainer1.Size = new System.Drawing.Size(976, 470);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 8;
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtWhereAreaNo);
            this.gbHeader.Controls.Add(this.txtWhereHouseNo);
            this.gbHeader.Controls.Add(this.txtWhereWarehouseNo);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.chensLabel12);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtWhereMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(976, 175);
            this.gbHeader.TabIndex = 7;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // txtWhereAreaNo
            // 
            this.txtWhereAreaNo.BackColor = System.Drawing.Color.White;
            this.txtWhereAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereAreaNo.HotTrack = false;
            this.txtWhereAreaNo.Location = new System.Drawing.Point(406, 69);
            this.txtWhereAreaNo.Name = "txtWhereAreaNo";
            this.txtWhereAreaNo.Size = new System.Drawing.Size(150, 23);
            this.txtWhereAreaNo.TabIndex = 42;
            this.txtWhereAreaNo.TextEnabled = false;
            // 
            // txtWhereHouseNo
            // 
            this.txtWhereHouseNo.BackColor = System.Drawing.Color.White;
            this.txtWhereHouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereHouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereHouseNo.HotTrack = false;
            this.txtWhereHouseNo.Location = new System.Drawing.Point(123, 69);
            this.txtWhereHouseNo.Name = "txtWhereHouseNo";
            this.txtWhereHouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWhereHouseNo.TabIndex = 41;
            this.txtWhereHouseNo.TextEnabled = false;
            // 
            // txtWhereWarehouseNo
            // 
            this.txtWhereWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWhereWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereWarehouseNo.HotTrack = false;
            this.txtWhereWarehouseNo.Location = new System.Drawing.Point(406, 29);
            this.txtWhereWarehouseNo.Name = "txtWhereWarehouseNo";
            this.txtWhereWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWhereWarehouseNo.TabIndex = 40;
            this.txtWhereWarehouseNo.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(307, 72);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 39;
            this.chensLabel8.Text = "库存货位";
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(25, 71);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 38;
            this.chensLabel9.Text = "库存库区";
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(307, 31);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(56, 17);
            this.chensLabel12.TabIndex = 37;
            this.chensLabel12.Text = "库存仓库";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(645, 42);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 29);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtWhereMaterialNo
            // 
            this.txtWhereMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtWhereMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereMaterialNo.HotTrack = false;
            this.txtWhereMaterialNo.Location = new System.Drawing.Point(123, 29);
            this.txtWhereMaterialNo.Name = "txtWhereMaterialNo";
            this.txtWhereMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtWhereMaterialNo.TabIndex = 2;
            this.txtWhereMaterialNo.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(25, 31);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 3;
            this.chensLabel5.Text = "物料编号";
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Controls.Add(this.pageList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 0);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(976, 291);
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
            this.colAreaNo,
            this.colHouseNo,
            this.colWarehouseNo,
            this.colMATERIALNO,
            this.colImportQty,
            this.colPrintQty,
            this.colcvencode,
            this.colcvenname});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(970, 247);
            this.dgvList.TabIndex = 3;
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
            this.pageList.Location = new System.Drawing.Point(3, 267);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(970, 20);
            this.pageList.TabIndex = 2;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox1.Controls.Add(this.txtBatchQty);
            this.chensGroupBox1.Controls.Add(this.chensLabel3);
            this.chensGroupBox1.Controls.Add(this.txtPrintQty);
            this.chensGroupBox1.Controls.Add(this.chensLabel7);
            this.chensGroupBox1.Controls.Add(this.txtOutPackQty);
            this.chensGroupBox1.Controls.Add(this.chensLabel6);
            this.chensGroupBox1.Controls.Add(this.txtcinvstd);
            this.chensGroupBox1.Controls.Add(this.chensLabel4);
            this.chensGroupBox1.Controls.Add(this.txtMaterialDesc);
            this.chensGroupBox1.Controls.Add(this.chensLabel10);
            this.chensGroupBox1.Controls.Add(this.txtMaterialNo);
            this.chensGroupBox1.Controls.Add(this.chensLabel11);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(976, 259);
            this.chensGroupBox1.TabIndex = 8;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "打印参数";
            // 
            // txtBatchQty
            // 
            this.txtBatchQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBatchQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBatchQty.HotTrack = false;
            this.txtBatchQty.Location = new System.Drawing.Point(123, 129);
            this.txtBatchQty.Name = "txtBatchQty";
            this.txtBatchQty.Size = new System.Drawing.Size(150, 23);
            this.txtBatchQty.TabIndex = 4;
            this.txtBatchQty.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 131);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 17;
            this.chensLabel3.Text = "打印数量";
            // 
            // txtPrintQty
            // 
            this.txtPrintQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPrintQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrintQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPrintQty.HotTrack = false;
            this.txtPrintQty.Location = new System.Drawing.Point(123, 163);
            this.txtPrintQty.Name = "txtPrintQty";
            this.txtPrintQty.Size = new System.Drawing.Size(150, 23);
            this.txtPrintQty.TabIndex = 15;
            this.txtPrintQty.TextEnabled = false;
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
            // txtOutPackQty
            // 
            this.txtOutPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOutPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOutPackQty.HotTrack = false;
            this.txtOutPackQty.Location = new System.Drawing.Point(123, 93);
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
            // txtcinvstd
            // 
            this.txtcinvstd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtcinvstd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcinvstd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtcinvstd.HotTrack = false;
            this.txtcinvstd.Location = new System.Drawing.Point(123, 58);
            this.txtcinvstd.Name = "txtcinvstd";
            this.txtcinvstd.Size = new System.Drawing.Size(150, 23);
            this.txtcinvstd.TabIndex = 3;
            this.txtcinvstd.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 5;
            this.chensLabel4.Text = "规格型号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(353, 23);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.ReadOnly = true;
            this.txtMaterialDesc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDesc.TabIndex = 2;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(279, 25);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 3;
            this.chensLabel10.Text = "物料描述";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(123, 23);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.ReadOnly = true;
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 1;
            this.txtMaterialNo.TextEnabled = false;
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(25, 25);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(56, 17);
            this.chensLabel11.TabIndex = 1;
            this.chensLabel11.Text = "物料编号";
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.Stock_Model);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrint,
            this.tsmiImport});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(976, 27);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.原料标签打印ToolStripMenuItem});
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrint.Text = "标签打印";
            // 
            // 原料标签打印ToolStripMenuItem
            // 
            this.原料标签打印ToolStripMenuItem.Name = "原料标签打印ToolStripMenuItem";
            this.原料标签打印ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.原料标签打印ToolStripMenuItem.Text = "7*7原料标签打印";
            this.原料标签打印ToolStripMenuItem.Click += new System.EventHandler(this.原料标签打印ToolStripMenuItem_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiImport.ShowShortcutKeys = false;
            this.tsmiImport.Size = new System.Drawing.Size(68, 21);
            this.tsmiImport.Text = "导入库存";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
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
            // colMATERIALNO
            // 
            this.colMATERIALNO.DataPropertyName = "MATERIALNO";
            this.colMATERIALNO.HeaderText = "物料编号";
            this.colMATERIALNO.Name = "colMATERIALNO";
            this.colMATERIALNO.ReadOnly = true;
            // 
            // colImportQty
            // 
            this.colImportQty.DataPropertyName = "ImportQty";
            this.colImportQty.HeaderText = "导入数量";
            this.colImportQty.Name = "colImportQty";
            this.colImportQty.ReadOnly = true;
            // 
            // colPrintQty
            // 
            this.colPrintQty.DataPropertyName = "PrintQty";
            this.colPrintQty.HeaderText = "已打数量";
            this.colPrintQty.Name = "colPrintQty";
            this.colPrintQty.ReadOnly = true;
            // 
            // colcvencode
            // 
            this.colcvencode.DataPropertyName = "cvencode";
            this.colcvencode.HeaderText = "供应商代码";
            this.colcvencode.Name = "colcvencode";
            this.colcvencode.ReadOnly = true;
            // 
            // colcvenname
            // 
            this.colcvenname.DataPropertyName = "cvenname";
            this.colcvenname.HeaderText = "供应商名称";
            this.colcvenname.Name = "colcvenname";
            this.colcvenname.ReadOnly = true;
            // 
            // FrmInitMaterialPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 733);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.scMain);
            this.Name = "FrmInitMaterialPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "原料标签期初打印";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtWhereAreaNo;
        private ChensControl.ChensTextBox txtWhereHouseNo;
        private ChensControl.ChensTextBox txtWhereWarehouseNo;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel12;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtWhereMaterialNo;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtBatchQty;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtPrintQty;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtOutPackQty;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtcinvstd;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem 原料标签打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensPage pageList;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensGroupBox gbBottom;
        private System.Windows.Forms.SplitContainer scMain;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensLabel chensLabel11;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrintQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcvencode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcvenname;



    }
}