namespace WMS.Check
{
    partial class FrmCheckList
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
            this.tsmiAddCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDoneCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtCreater = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.cbbCheckStatus = new ChensControl.ChensComboBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.cbbCheckType = new ChensControl.ChensComboBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtCheckNo = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCheckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCheckStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrCheckStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tsmiAddCheck,
            this.tsmiDelCheck,
            this.tsmiDoneCheck,
            this.tsmiCancelCheck,
            this.tsmiAnalyse});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 3;
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
            // tsmiAddCheck
            // 
            this.tsmiAddCheck.Name = "tsmiAddCheck";
            this.tsmiAddCheck.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiAddCheck.Size = new System.Drawing.Size(68, 21);
            this.tsmiAddCheck.Text = "新增盘点";
            this.tsmiAddCheck.Click += new System.EventHandler(this.tsmiAddCheck_Click);
            // 
            // tsmiDelCheck
            // 
            this.tsmiDelCheck.Name = "tsmiDelCheck";
            this.tsmiDelCheck.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDelCheck.Size = new System.Drawing.Size(68, 21);
            this.tsmiDelCheck.Text = "删除盘点";
            this.tsmiDelCheck.Visible = false;
            this.tsmiDelCheck.Click += new System.EventHandler(this.tsmiDelCheck_Click);
            // 
            // tsmiDoneCheck
            // 
            this.tsmiDoneCheck.Name = "tsmiDoneCheck";
            this.tsmiDoneCheck.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiDoneCheck.Size = new System.Drawing.Size(68, 21);
            this.tsmiDoneCheck.Text = "完成盘点";
            this.tsmiDoneCheck.Click += new System.EventHandler(this.tsmiDoneCheck_Click);
            // 
            // tsmiCancelCheck
            // 
            this.tsmiCancelCheck.Name = "tsmiCancelCheck";
            this.tsmiCancelCheck.Size = new System.Drawing.Size(68, 21);
            this.tsmiCancelCheck.Text = "取消盘点";
            this.tsmiCancelCheck.Click += new System.EventHandler(this.tsmiCancelCheck_Click);
            // 
            // tsmiAnalyse
            // 
            this.tsmiAnalyse.Name = "tsmiAnalyse";
            this.tsmiAnalyse.Size = new System.Drawing.Size(68, 21);
            this.tsmiAnalyse.Text = "盈亏分析";
            this.tsmiAnalyse.Click += new System.EventHandler(this.tsmiAnalyse_Click);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtCreater);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.cbbCheckStatus);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.cbbCheckType);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtCheckNo);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 4;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
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
            this.txtCreater.TabIndex = 35;
            this.txtCreater.TextEnabled = false;
            this.txtCreater.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.CheckInfo);
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(44, 17);
            this.chensLabel4.TabIndex = 34;
            this.chensLabel4.Text = "创建人";
            // 
            // cbbCheckStatus
            // 
            this.cbbCheckStatus.BackColor = System.Drawing.Color.White;
            this.cbbCheckStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbCheckStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMain, "CheckStatus", true));
            this.cbbCheckStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbCheckStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbCheckStatus.FormattingEnabled = true;
            this.cbbCheckStatus.HotTrack = false;
            this.cbbCheckStatus.Location = new System.Drawing.Point(571, 22);
            this.cbbCheckStatus.Name = "cbbCheckStatus";
            this.cbbCheckStatus.Size = new System.Drawing.Size(150, 25);
            this.cbbCheckStatus.TabIndex = 33;
            this.cbbCheckStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 32;
            this.chensLabel3.Text = "盘点状态";
            // 
            // cbbCheckType
            // 
            this.cbbCheckType.BackColor = System.Drawing.Color.White;
            this.cbbCheckType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbCheckType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMain, "CheckType", true));
            this.cbbCheckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCheckType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbCheckType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbCheckType.FormattingEnabled = true;
            this.cbbCheckType.HotTrack = false;
            this.cbbCheckType.Location = new System.Drawing.Point(329, 22);
            this.cbbCheckType.Name = "cbbCheckType";
            this.cbbCheckType.Size = new System.Drawing.Size(150, 25);
            this.cbbCheckType.TabIndex = 31;
            this.cbbCheckType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 30;
            this.chensLabel2.Text = "盘点类型";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(571, 58);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 29;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 28;
            this.chensLabel5.Text = "——";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(267, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 27;
            this.chensLabel6.Text = "创建日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(329, 58);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 26;
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
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.BackColor = System.Drawing.Color.White;
            this.txtCheckNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "CheckNo", true));
            this.txtCheckNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCheckNo.HotTrack = false;
            this.txtCheckNo.Location = new System.Drawing.Point(87, 23);
            this.txtCheckNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(150, 23);
            this.txtCheckNo.TabIndex = 2;
            this.txtCheckNo.TextEnabled = false;
            this.txtCheckNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "盘点单号";
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
            this.gbBottom.TabIndex = 5;
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
            this.colEdit,
            this.colHID,
            this.colHCheckNo,
            this.colHCheckType,
            this.colHStrCheckType,
            this.colHCheckStatus,
            this.colHStrCheckStatus,
            this.colHDescription,
            this.colHRemarks,
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
            // colEdit
            // 
            this.colEdit.DataPropertyName = "EditText";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "查看明细";
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEdit.HeaderText = "编辑/查看";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.LinkColor = System.Drawing.Color.Blue;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "";
            this.colEdit.TrackVisitedState = false;
            this.colEdit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            // 
            // colHCheckNo
            // 
            this.colHCheckNo.DataPropertyName = "CheckNo";
            this.colHCheckNo.HeaderText = "盘点单号";
            this.colHCheckNo.Name = "colHCheckNo";
            this.colHCheckNo.ReadOnly = true;
            // 
            // colHCheckType
            // 
            this.colHCheckType.DataPropertyName = "CheckType";
            this.colHCheckType.HeaderText = "盘点类型";
            this.colHCheckType.Name = "colHCheckType";
            this.colHCheckType.ReadOnly = true;
            this.colHCheckType.Visible = false;
            // 
            // colHStrCheckType
            // 
            this.colHStrCheckType.DataPropertyName = "StrCheckType";
            this.colHStrCheckType.HeaderText = "盘点类型";
            this.colHStrCheckType.Name = "colHStrCheckType";
            this.colHStrCheckType.ReadOnly = true;
            // 
            // colHCheckStatus
            // 
            this.colHCheckStatus.DataPropertyName = "CheckStatus";
            this.colHCheckStatus.HeaderText = "盘点状态";
            this.colHCheckStatus.Name = "colHCheckStatus";
            this.colHCheckStatus.ReadOnly = true;
            this.colHCheckStatus.Visible = false;
            // 
            // colHStrCheckStatus
            // 
            this.colHStrCheckStatus.DataPropertyName = "StrCheckStatus";
            this.colHStrCheckStatus.HeaderText = "盘点状态";
            this.colHStrCheckStatus.Name = "colHStrCheckStatus";
            this.colHStrCheckStatus.ReadOnly = true;
            // 
            // colHDescription
            // 
            this.colHDescription.DataPropertyName = "Description";
            this.colHDescription.HeaderText = "盘点描述";
            this.colHDescription.Name = "colHDescription";
            this.colHDescription.ReadOnly = true;
            // 
            // colHRemarks
            // 
            this.colHRemarks.DataPropertyName = "Remarks";
            this.colHRemarks.HeaderText = "备注";
            this.colHRemarks.Name = "colHRemarks";
            this.colHRemarks.ReadOnly = true;
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
            // 
            // colHCreateTime
            // 
            this.colHCreateTime.DataPropertyName = "CreateTime";
            this.colHCreateTime.HeaderText = "创建时间";
            this.colHCreateTime.Name = "colHCreateTime";
            this.colHCreateTime.ReadOnly = true;
            this.colHCreateTime.Width = 130;
            // 
            // colHModifyer
            // 
            this.colHModifyer.DataPropertyName = "Modifyer";
            this.colHModifyer.HeaderText = "修改人";
            this.colHModifyer.Name = "colHModifyer";
            this.colHModifyer.ReadOnly = true;
            // 
            // colHModifyTime
            // 
            this.colHModifyTime.DataPropertyName = "ModifyTime";
            this.colHModifyTime.HeaderText = "修改时间";
            this.colHModifyTime.Name = "colHModifyTime";
            this.colHModifyTime.ReadOnly = true;
            this.colHModifyTime.Width = 130;
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
            this.pageList.Location = new System.Drawing.Point(3, 629);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // FrmCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmCheckList";
            this.Text = "FrmCheckList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCheckList_FormClosed);
            this.Load += new System.EventHandler(this.FrmCheckList_Load);
            this.Enter += new System.EventHandler(this.FrmCheckList_Enter);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiDoneCheck;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensTextBox txtCheckNo;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelCheck;
        private ChensControl.ChensComboBox cbbCheckStatus;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensComboBox cbbCheckType;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtCreater;
        private ChensControl.ChensLabel chensLabel4;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalyse;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCheckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCheckStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrCheckStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyTime;
    }
}