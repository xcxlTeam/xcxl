namespace WMS.Basic
{
    partial class FrmUserList
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
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPinYin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDuty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsPick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrIsPick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrIsReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrIsQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUserStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStrUserStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHLoginIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHLoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHLoginDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBIsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colHStrIsAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.cbbIsOnline = new ChensControl.ChensComboBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.dtpEndTime = new ChensControl.ChensDateTimePicker();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.dtpStartTime = new ChensControl.ChensDateTimePicker();
            this.txtCreater = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.txtUSERNAME = new ChensControl.ChensTextBox();
            this.txtUSERNO = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbHeader.SuspendLayout();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Controls.Add(this.pageList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 122);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 631);
            this.gbBottom.TabIndex = 2;
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
            this.colID,
            this.colHUserNo,
            this.colHUserName,
            this.colHPassword,
            this.colHUserType,
            this.colHStrUserType,
            this.colHPinYin,
            this.colHDuty,
            this.colHTel,
            this.colHMobile,
            this.colHEmail,
            this.colHSex,
            this.colHStrSex,
            this.colHIsPick,
            this.colHStrIsPick,
            this.colHIsReceive,
            this.colHStrIsReceive,
            this.colHIsQuality,
            this.colHStrIsQuality,
            this.colHUserStatus,
            this.colHStrUserStatus,
            this.colHAddress,
            this.colHGroupCode,
            this.colHWarehouseCode,
            this.colHDescription,
            this.colHLoginIP,
            this.colHLoginTime,
            this.colHLoginDevice,
            this.colHBIsAdmin,
            this.colHStrIsAdmin,
            this.colHGroupName,
            this.colHWarehouseName,
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
            this.dgvList.Size = new System.Drawing.Size(986, 587);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // colEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "编辑";
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEdit.HeaderText = "编辑";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.LinkColor = System.Drawing.Color.Blue;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "编辑";
            this.colEdit.TrackVisitedState = false;
            this.colEdit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colHUserNo
            // 
            this.colHUserNo.DataPropertyName = "UserNo";
            this.colHUserNo.HeaderText = "用户编号";
            this.colHUserNo.Name = "colHUserNo";
            this.colHUserNo.ReadOnly = true;
            // 
            // colHUserName
            // 
            this.colHUserName.DataPropertyName = "UserName";
            this.colHUserName.HeaderText = "用户名称";
            this.colHUserName.Name = "colHUserName";
            this.colHUserName.ReadOnly = true;
            // 
            // colHPassword
            // 
            this.colHPassword.DataPropertyName = "Password";
            this.colHPassword.HeaderText = "登录密码";
            this.colHPassword.Name = "colHPassword";
            this.colHPassword.ReadOnly = true;
            this.colHPassword.Visible = false;
            // 
            // colHUserType
            // 
            this.colHUserType.DataPropertyName = "UserType";
            this.colHUserType.HeaderText = "用户类型";
            this.colHUserType.Name = "colHUserType";
            this.colHUserType.ReadOnly = true;
            this.colHUserType.Visible = false;
            // 
            // colHStrUserType
            // 
            this.colHStrUserType.DataPropertyName = "StrUserType";
            this.colHStrUserType.HeaderText = "用户类型";
            this.colHStrUserType.Name = "colHStrUserType";
            this.colHStrUserType.ReadOnly = true;
            this.colHStrUserType.Visible = false;
            // 
            // colHPinYin
            // 
            this.colHPinYin.DataPropertyName = "PinYin";
            this.colHPinYin.HeaderText = "拼音码";
            this.colHPinYin.Name = "colHPinYin";
            this.colHPinYin.ReadOnly = true;
            this.colHPinYin.Visible = false;
            // 
            // colHDuty
            // 
            this.colHDuty.DataPropertyName = "Duty";
            this.colHDuty.HeaderText = "职务";
            this.colHDuty.Name = "colHDuty";
            this.colHDuty.ReadOnly = true;
            this.colHDuty.Visible = false;
            // 
            // colHTel
            // 
            this.colHTel.DataPropertyName = "Tel";
            this.colHTel.HeaderText = "联系电话";
            this.colHTel.Name = "colHTel";
            this.colHTel.ReadOnly = true;
            this.colHTel.Visible = false;
            // 
            // colHMobile
            // 
            this.colHMobile.DataPropertyName = "Mobile";
            this.colHMobile.HeaderText = "联系电话";
            this.colHMobile.Name = "colHMobile";
            this.colHMobile.ReadOnly = true;
            // 
            // colHEmail
            // 
            this.colHEmail.DataPropertyName = "Email";
            this.colHEmail.HeaderText = "电子邮件";
            this.colHEmail.Name = "colHEmail";
            this.colHEmail.ReadOnly = true;
            this.colHEmail.Visible = false;
            // 
            // colHSex
            // 
            this.colHSex.DataPropertyName = "Sex";
            this.colHSex.HeaderText = "性别";
            this.colHSex.Name = "colHSex";
            this.colHSex.ReadOnly = true;
            this.colHSex.Visible = false;
            // 
            // colHStrSex
            // 
            this.colHStrSex.DataPropertyName = "StrSex";
            this.colHStrSex.HeaderText = "性别";
            this.colHStrSex.Name = "colHStrSex";
            this.colHStrSex.ReadOnly = true;
            this.colHStrSex.Width = 60;
            // 
            // colHIsPick
            // 
            this.colHIsPick.DataPropertyName = "IsPick";
            this.colHIsPick.HeaderText = "是否拣货";
            this.colHIsPick.Name = "colHIsPick";
            this.colHIsPick.ReadOnly = true;
            this.colHIsPick.Visible = false;
            this.colHIsPick.Width = 80;
            // 
            // colHStrIsPick
            // 
            this.colHStrIsPick.DataPropertyName = "StrIsPick";
            this.colHStrIsPick.HeaderText = "是否拣货";
            this.colHStrIsPick.Name = "colHStrIsPick";
            this.colHStrIsPick.ReadOnly = true;
            this.colHStrIsPick.Width = 80;
            // 
            // colHIsReceive
            // 
            this.colHIsReceive.DataPropertyName = "IsReceive";
            this.colHIsReceive.HeaderText = "是否收货";
            this.colHIsReceive.Name = "colHIsReceive";
            this.colHIsReceive.ReadOnly = true;
            this.colHIsReceive.Visible = false;
            this.colHIsReceive.Width = 80;
            // 
            // colHStrIsReceive
            // 
            this.colHStrIsReceive.DataPropertyName = "StrIsReceive";
            this.colHStrIsReceive.HeaderText = "是否收货";
            this.colHStrIsReceive.Name = "colHStrIsReceive";
            this.colHStrIsReceive.ReadOnly = true;
            this.colHStrIsReceive.Visible = false;
            this.colHStrIsReceive.Width = 80;
            // 
            // colHIsQuality
            // 
            this.colHIsQuality.DataPropertyName = "IsQuality";
            this.colHIsQuality.HeaderText = "质检提示";
            this.colHIsQuality.Name = "colHIsQuality";
            this.colHIsQuality.ReadOnly = true;
            this.colHIsQuality.Visible = false;
            this.colHIsQuality.Width = 80;
            // 
            // colHStrIsQuality
            // 
            this.colHStrIsQuality.DataPropertyName = "StrIsQuality";
            this.colHStrIsQuality.HeaderText = "质检提示";
            this.colHStrIsQuality.Name = "colHStrIsQuality";
            this.colHStrIsQuality.ReadOnly = true;
            this.colHStrIsQuality.Visible = false;
            this.colHStrIsQuality.Width = 80;
            // 
            // colHUserStatus
            // 
            this.colHUserStatus.DataPropertyName = "UserStatus";
            this.colHUserStatus.HeaderText = "用户状态";
            this.colHUserStatus.Name = "colHUserStatus";
            this.colHUserStatus.ReadOnly = true;
            this.colHUserStatus.Visible = false;
            this.colHUserStatus.Width = 80;
            // 
            // colHStrUserStatus
            // 
            this.colHStrUserStatus.DataPropertyName = "StrUserStatus";
            this.colHStrUserStatus.HeaderText = "用户状态";
            this.colHStrUserStatus.Name = "colHStrUserStatus";
            this.colHStrUserStatus.ReadOnly = true;
            this.colHStrUserStatus.Width = 80;
            // 
            // colHAddress
            // 
            this.colHAddress.DataPropertyName = "Address";
            this.colHAddress.HeaderText = "地址";
            this.colHAddress.Name = "colHAddress";
            this.colHAddress.ReadOnly = true;
            this.colHAddress.Visible = false;
            // 
            // colHGroupCode
            // 
            this.colHGroupCode.DataPropertyName = "GroupCode";
            this.colHGroupCode.HeaderText = "用户组ID";
            this.colHGroupCode.Name = "colHGroupCode";
            this.colHGroupCode.ReadOnly = true;
            this.colHGroupCode.Visible = false;
            // 
            // colHWarehouseCode
            // 
            this.colHWarehouseCode.DataPropertyName = "WarehouseCode";
            this.colHWarehouseCode.HeaderText = "仓库ID";
            this.colHWarehouseCode.Name = "colHWarehouseCode";
            this.colHWarehouseCode.ReadOnly = true;
            this.colHWarehouseCode.Visible = false;
            // 
            // colHDescription
            // 
            this.colHDescription.DataPropertyName = "Description";
            this.colHDescription.HeaderText = "用户描述";
            this.colHDescription.Name = "colHDescription";
            this.colHDescription.ReadOnly = true;
            // 
            // colHLoginIP
            // 
            this.colHLoginIP.DataPropertyName = "LoginIP";
            this.colHLoginIP.HeaderText = "登录地址";
            this.colHLoginIP.Name = "colHLoginIP";
            this.colHLoginIP.ReadOnly = true;
            this.colHLoginIP.Width = 130;
            // 
            // colHLoginTime
            // 
            this.colHLoginTime.DataPropertyName = "LoginTime";
            this.colHLoginTime.HeaderText = "登录时间";
            this.colHLoginTime.Name = "colHLoginTime";
            this.colHLoginTime.ReadOnly = true;
            this.colHLoginTime.Width = 150;
            // 
            // colHLoginDevice
            // 
            this.colHLoginDevice.DataPropertyName = "LoginDevice";
            this.colHLoginDevice.HeaderText = "登录设备";
            this.colHLoginDevice.Name = "colHLoginDevice";
            this.colHLoginDevice.ReadOnly = true;
            this.colHLoginDevice.Width = 200;
            // 
            // colHBIsAdmin
            // 
            this.colHBIsAdmin.DataPropertyName = "BIsAdmin";
            this.colHBIsAdmin.FalseValue = "false";
            this.colHBIsAdmin.HeaderText = "是否管理员";
            this.colHBIsAdmin.Name = "colHBIsAdmin";
            this.colHBIsAdmin.ReadOnly = true;
            this.colHBIsAdmin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHBIsAdmin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colHBIsAdmin.TrueValue = "true";
            this.colHBIsAdmin.Visible = false;
            // 
            // colHStrIsAdmin
            // 
            this.colHStrIsAdmin.DataPropertyName = "StrIsAdmin";
            this.colHStrIsAdmin.HeaderText = "是否管理员";
            this.colHStrIsAdmin.Name = "colHStrIsAdmin";
            this.colHStrIsAdmin.ReadOnly = true;
            // 
            // colHGroupName
            // 
            this.colHGroupName.DataPropertyName = "GroupName";
            this.colHGroupName.HeaderText = "所属用户组";
            this.colHGroupName.Name = "colHGroupName";
            this.colHGroupName.ReadOnly = true;
            // 
            // colHWarehouseName
            // 
            this.colHWarehouseName.DataPropertyName = "WarehouseName";
            this.colHWarehouseName.HeaderText = "负责仓库";
            this.colHWarehouseName.Name = "colHWarehouseName";
            this.colHWarehouseName.ReadOnly = true;
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
            this.pageList.Location = new System.Drawing.Point(3, 607);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.cbbIsOnline);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.txtCreater);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.txtUSERNAME);
            this.gbHeader.Controls.Add(this.txtUSERNO);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 27);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 1;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // cbbIsOnline
            // 
            this.cbbIsOnline.BackColor = System.Drawing.Color.White;
            this.cbbIsOnline.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbIsOnline.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMain, "IsOnline", true));
            this.cbbIsOnline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIsOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbIsOnline.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbIsOnline.FormattingEnabled = true;
            this.cbbIsOnline.HotTrack = false;
            this.cbbIsOnline.Location = new System.Drawing.Point(571, 22);
            this.cbbIsOnline.Name = "cbbIsOnline";
            this.cbbIsOnline.Size = new System.Drawing.Size(150, 25);
            this.cbbIsOnline.TabIndex = 4;
            this.cbbIsOnline.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 26;
            this.chensLabel3.Text = "是否在线";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Checked = false;
            this.dtpEndTime.Location = new System.Drawing.Point(571, 58);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 25;
            this.dtpEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 60);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(34, 17);
            this.chensLabel5.TabIndex = 24;
            this.chensLabel5.Text = "——";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(267, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 23;
            this.chensLabel6.Text = "创建日期";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Checked = false;
            this.dtpStartTime.Location = new System.Drawing.Point(329, 58);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 22;
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
            this.txtCreater.TabIndex = 21;
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
            this.chensLabel4.TabIndex = 20;
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
            // txtUSERNAME
            // 
            this.txtUSERNAME.BackColor = System.Drawing.Color.White;
            this.txtUSERNAME.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUSERNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUSERNAME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "UserName", true));
            this.txtUSERNAME.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUSERNAME.HotTrack = false;
            this.txtUSERNAME.Location = new System.Drawing.Point(329, 23);
            this.txtUSERNAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUSERNAME.Name = "txtUSERNAME";
            this.txtUSERNAME.Size = new System.Drawing.Size(150, 23);
            this.txtUSERNAME.TabIndex = 3;
            this.txtUSERNAME.TextEnabled = false;
            this.txtUSERNAME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtUSERNO
            // 
            this.txtUSERNO.BackColor = System.Drawing.Color.White;
            this.txtUSERNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUSERNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUSERNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "UserNo", true));
            this.txtUSERNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUSERNO.HotTrack = false;
            this.txtUSERNO.Location = new System.Drawing.Point(87, 23);
            this.txtUSERNO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUSERNO.Name = "txtUSERNO";
            this.txtUSERNO.Size = new System.Drawing.Size(150, 23);
            this.txtUSERNO.TabIndex = 2;
            this.txtUSERNO.TextEnabled = false;
            this.txtUSERNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "用户名称";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "用户编号";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiAddUser,
            this.tsmiDelUser,
            this.tsmiResetPwd,
            this.tsmiOutput,
            this.tsmiClear});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(992, 27);
            this.msMain.TabIndex = 0;
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
            // tsmiAddUser
            // 
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiAddUser.Size = new System.Drawing.Size(68, 21);
            this.tsmiAddUser.Text = "新增用户";
            this.tsmiAddUser.Click += new System.EventHandler(this.tsmiAddUser_Click);
            // 
            // tsmiDelUser
            // 
            this.tsmiDelUser.Name = "tsmiDelUser";
            this.tsmiDelUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDelUser.Size = new System.Drawing.Size(68, 21);
            this.tsmiDelUser.Text = "删除用户";
            this.tsmiDelUser.Click += new System.EventHandler(this.tsmiDelUser_Click);
            // 
            // tsmiResetPwd
            // 
            this.tsmiResetPwd.Name = "tsmiResetPwd";
            this.tsmiResetPwd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiResetPwd.Size = new System.Drawing.Size(68, 21);
            this.tsmiResetPwd.Text = "重置密码";
            this.tsmiResetPwd.Click += new System.EventHandler(this.tsmiResetPwd_Click);
            // 
            // tsmiOutput
            // 
            this.tsmiOutput.Name = "tsmiOutput";
            this.tsmiOutput.Size = new System.Drawing.Size(68, 21);
            this.tsmiOutput.Text = "导出数据";
            this.tsmiOutput.Visible = false;
            this.tsmiOutput.Click += new System.EventHandler(this.tsmiOutput_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(68, 21);
            this.tsmiClear.Text = "清除登录";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.UserInfo);
            // 
            // FrmUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 753);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmUserList";
            this.Text = "用户设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserList_FormClosed);
            this.Load += new System.EventHandler(this.FrmUserList_Load);
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtUSERNAME;
        private ChensControl.ChensTextBox txtUSERNO;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetPwd;
        private ChensControl.ChensButton btnSearch;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiOutput;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensDateTimePicker dtpEndTime;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensDateTimePicker dtpStartTime;
        private ChensControl.ChensTextBox txtCreater;
        private ChensControl.ChensLabel chensLabel4;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private ChensControl.ChensComboBox cbbIsOnline;
        private ChensControl.ChensLabel chensLabel3;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPinYin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDuty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUserStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrUserStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHGroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHLoginIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHLoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHLoginDevice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHBIsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStrIsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHModifyTime;



    }
}