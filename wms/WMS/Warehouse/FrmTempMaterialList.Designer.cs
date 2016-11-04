namespace WMS.Warehouse
{
    partial class FrmTempMaterialList
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
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlter = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.txtCreater = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.txtTempMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colHEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSapMaterialDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplaceUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplaceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempMaterialStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
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
            this.tsmiAdd,
            this.tsmiDel,
            this.tsmiAlter});
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
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiAdd.Size = new System.Drawing.Size(68, 21);
            this.tsmiAdd.Text = "新增物料";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDel.Size = new System.Drawing.Size(68, 21);
            this.tsmiDel.Text = "删除物料";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // tsmiAlter
            // 
            this.tsmiAlter.Name = "tsmiAlter";
            this.tsmiAlter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiAlter.Size = new System.Drawing.Size(68, 21);
            this.tsmiAlter.Text = "替换物料";
            this.tsmiAlter.Click += new System.EventHandler(this.tsmiAlter_Click);
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
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.txtTempMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 6;
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
            this.dtpEndTime.TabIndex = 31;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 30;
            this.chensLabel5.Text = "——";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(267, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 29;
            this.chensLabel6.Text = "创建日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(329, 58);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 28;
            this.dtpStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtCreater
            // 
            this.txtCreater.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCreater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreater.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Creater", true));
            this.txtCreater.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCreater.HotTrack = false;
            this.txtCreater.Location = new System.Drawing.Point(87, 58);
            this.txtCreater.Name = "txtCreater";
            this.txtCreater.Size = new System.Drawing.Size(150, 23);
            this.txtCreater.TabIndex = 27;
            this.txtCreater.TextEnabled = false;
            this.txtCreater.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.TempMaterialInfo);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(44, 17);
            this.chensLabel4.TabIndex = 26;
            this.chensLabel4.Text = "创建人";
            // 
            // btnSearch
            // 
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
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialNo", true));
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(327, 23);
            this.txtMaterialNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 3;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtTempMaterialNo
            // 
            this.txtTempMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtTempMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTempMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "TempMaterialNo", true));
            this.txtTempMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTempMaterialNo.HotTrack = false;
            this.txtTempMaterialNo.Location = new System.Drawing.Point(87, 23);
            this.txtTempMaterialNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTempMaterialNo.Name = "txtTempMaterialNo";
            this.txtTempMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtTempMaterialNo.TabIndex = 2;
            this.txtTempMaterialNo.TextEnabled = false;
            this.txtTempMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(54, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "SAP物料";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "临时物料";
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Controls.Add(this.pageList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 120);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 653);
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
            this.colHEdit,
            this.colID,
            this.colTempMaterialNo,
            this.colTempMaterialName,
            this.colMaterialNo,
            this.colMaterialDesc,
            this.colSapMaterialDoc,
            this.colReplaceUser,
            this.colReplaceTime,
            this.colTempMaterialStatus,
            this.colIsDel,
            this.colCreater,
            this.colCreateTime,
            this.colModifyer,
            this.colModifyTime});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.dgvList.Size = new System.Drawing.Size(986, 609);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // colHEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "编辑";
            this.colHEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHEdit.HeaderText = "编辑";
            this.colHEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colHEdit.Name = "colHEdit";
            this.colHEdit.ReadOnly = true;
            this.colHEdit.Text = "编辑";
            this.colHEdit.TrackVisitedState = false;
            this.colHEdit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colTempMaterialNo
            // 
            this.colTempMaterialNo.DataPropertyName = "TempMaterialNo";
            this.colTempMaterialNo.HeaderText = "临时物料编号";
            this.colTempMaterialNo.Name = "colTempMaterialNo";
            this.colTempMaterialNo.ReadOnly = true;
            this.colTempMaterialNo.Width = 150;
            // 
            // colTempMaterialName
            // 
            this.colTempMaterialName.DataPropertyName = "TempMaterialDesc";
            this.colTempMaterialName.HeaderText = "临时物料描述";
            this.colTempMaterialName.Name = "colTempMaterialName";
            this.colTempMaterialName.ReadOnly = true;
            this.colTempMaterialName.Width = 200;
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "MaterialNo";
            this.colMaterialNo.HeaderText = "SAP物料编号";
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.ReadOnly = true;
            this.colMaterialNo.Width = 150;
            // 
            // colMaterialDesc
            // 
            this.colMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colMaterialDesc.HeaderText = "SAP物料描述";
            this.colMaterialDesc.Name = "colMaterialDesc";
            this.colMaterialDesc.ReadOnly = true;
            this.colMaterialDesc.Width = 200;
            // 
            // colSapMaterialDoc
            // 
            this.colSapMaterialDoc.DataPropertyName = "SapMaterialDoc";
            this.colSapMaterialDoc.HeaderText = "SAP物料凭证";
            this.colSapMaterialDoc.Name = "colSapMaterialDoc";
            this.colSapMaterialDoc.ReadOnly = true;
            this.colSapMaterialDoc.Visible = false;
            // 
            // colReplaceUser
            // 
            this.colReplaceUser.DataPropertyName = "ReplaceUser";
            this.colReplaceUser.HeaderText = "替换人";
            this.colReplaceUser.Name = "colReplaceUser";
            this.colReplaceUser.ReadOnly = true;
            // 
            // colReplaceTime
            // 
            this.colReplaceTime.DataPropertyName = "ReplaceTime";
            this.colReplaceTime.HeaderText = "替换时间";
            this.colReplaceTime.Name = "colReplaceTime";
            this.colReplaceTime.ReadOnly = true;
            // 
            // colTempMaterialStatus
            // 
            this.colTempMaterialStatus.DataPropertyName = "TempMaterialStatus";
            this.colTempMaterialStatus.HeaderText = "临时物料状态";
            this.colTempMaterialStatus.Name = "colTempMaterialStatus";
            this.colTempMaterialStatus.ReadOnly = true;
            this.colTempMaterialStatus.Visible = false;
            // 
            // colIsDel
            // 
            this.colIsDel.DataPropertyName = "IsDel";
            this.colIsDel.HeaderText = "删除标识";
            this.colIsDel.Name = "colIsDel";
            this.colIsDel.ReadOnly = true;
            this.colIsDel.Visible = false;
            // 
            // colCreater
            // 
            this.colCreater.DataPropertyName = "Creater";
            this.colCreater.HeaderText = "创建人";
            this.colCreater.Name = "colCreater";
            this.colCreater.ReadOnly = true;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "CreateTime";
            this.colCreateTime.HeaderText = "创建时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            // 
            // colModifyer
            // 
            this.colModifyer.DataPropertyName = "Modifyer";
            this.colModifyer.HeaderText = "修改人";
            this.colModifyer.Name = "colModifyer";
            this.colModifyer.ReadOnly = true;
            this.colModifyer.Visible = false;
            // 
            // colModifyTime
            // 
            this.colModifyTime.DataPropertyName = "ModifyTime";
            this.colModifyTime.HeaderText = "修改时间";
            this.colModifyTime.Name = "colModifyTime";
            this.colModifyTime.ReadOnly = true;
            this.colModifyTime.Visible = false;
            // 
            // pageList
            // 
            this.pageList.CurrentPageNumber = 0;
            dividPage1.CurrentPageNumber = 0;
            dividPage1.CurrentPageRecordCounts = 0;
            dividPage1.CurrentPageShowCounts = 10;
            dividPage1.DefaultPageShowCounts = 10;
            dividPage1.PagesCount = 0;
            dividPage1.RecordCounts = 0;
            this.pageList.dDividPage = dividPage1;
            this.pageList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageList.Location = new System.Drawing.Point(3, 629);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // FrmTempMaterialList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmTempMaterialList";
            this.Text = "临时物料";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTempMaterialList_FormClosed);
            this.Load += new System.EventHandler(this.FrmTempInventoryList_Load);
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
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensTextBox txtTempMaterialNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlter;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensTextBox txtCreater;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensDataGridView dgvList;
        private System.Windows.Forms.DataGridViewLinkColumn colHEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapMaterialDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplaceUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplaceTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempMaterialStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyTime;
    }
}