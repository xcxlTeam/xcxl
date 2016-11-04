namespace WMS.Basic
{
    partial class FrmUserFile
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("管理员");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("游客");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("A1");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("B1");
            this.bsUser = new System.Windows.Forms.BindingSource(this.components);
            this.tcFile = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.cbxBIsPick = new ChensControl.ChensCheckBox();
            this.cbbSex = new ChensControl.ChensComboBox();
            this.cbxBIsQuanlity = new ChensControl.ChensCheckBox();
            this.txtDecription = new ChensControl.ChensTextBox();
            this.chensLabel13 = new ChensControl.ChensLabel();
            this.txtUserNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxBIsReceive = new ChensControl.ChensCheckBox();
            this.txtRePassword = new ChensControl.ChensTextBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.txtPassword = new ChensControl.ChensTextBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtMobile = new ChensControl.ChensTextBox();
            this.cbbUserStatus = new ChensControl.ChensComboBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtUserName = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.tpGroup = new System.Windows.Forms.TabPage();
            this.cbxSelectAllGroup = new ChensControl.ChensCheckBox();
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.tpWarehouse = new System.Windows.Forms.TabPage();
            this.cbxSelectAllWarehouse = new ChensControl.ChensCheckBox();
            this.lvWarehouse = new System.Windows.Forms.ListView();
            this.chensLabel14 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bsUser)).BeginInit();
            this.tcFile.SuspendLayout();
            this.tpBasic.SuspendLayout();
            this.tpGroup.SuspendLayout();
            this.tpWarehouse.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsUser
            // 
            this.bsUser.DataSource = typeof(WMS.WebService.UserInfo);
            // 
            // tcFile
            // 
            this.tcFile.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcFile.Controls.Add(this.tpBasic);
            this.tcFile.Controls.Add(this.tpGroup);
            this.tcFile.Controls.Add(this.tpWarehouse);
            this.tcFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFile.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tcFile.Location = new System.Drawing.Point(0, 25);
            this.tcFile.Name = "tcFile";
            this.tcFile.SelectedIndex = 0;
            this.tcFile.Size = new System.Drawing.Size(992, 444);
            this.tcFile.TabIndex = 2;
            this.tcFile.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.cbxBIsPick);
            this.tpBasic.Controls.Add(this.cbbSex);
            this.tpBasic.Controls.Add(this.cbxBIsQuanlity);
            this.tpBasic.Controls.Add(this.txtDecription);
            this.tpBasic.Controls.Add(this.chensLabel13);
            this.tpBasic.Controls.Add(this.txtUserNo);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.label3);
            this.tpBasic.Controls.Add(this.label2);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.cbxBIsReceive);
            this.tpBasic.Controls.Add(this.txtRePassword);
            this.tpBasic.Controls.Add(this.chensLabel11);
            this.tpBasic.Controls.Add(this.txtPassword);
            this.tpBasic.Controls.Add(this.chensLabel10);
            this.tpBasic.Controls.Add(this.chensLabel8);
            this.tpBasic.Controls.Add(this.txtMobile);
            this.tpBasic.Controls.Add(this.cbbUserStatus);
            this.tpBasic.Controls.Add(this.chensLabel7);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtUserName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(984, 411);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "用户信息";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // cbxBIsPick
            // 
            this.cbxBIsPick.AutoSize = true;
            this.cbxBIsPick.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsUser, "BIsPick", true));
            this.cbxBIsPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBIsPick.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxBIsPick.Location = new System.Drawing.Point(205, 350);
            this.cbxBIsPick.Name = "cbxBIsPick";
            this.cbxBIsPick.Size = new System.Drawing.Size(72, 21);
            this.cbxBIsPick.TabIndex = 12;
            this.cbxBIsPick.Text = "是否拣货";
            this.cbxBIsPick.Textn = "是否拣货";
            this.cbxBIsPick.UseVisualStyleBackColor = true;
            this.cbxBIsPick.CheckedChanged += new System.EventHandler(this.cbxBIsPick_CheckedChanged);
            // 
            // cbbSex
            // 
            this.cbbSex.BackColor = System.Drawing.Color.White;
            this.cbbSex.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbSex.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsUser, "Sex", true));
            this.cbbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbSex.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbSex.FormattingEnabled = true;
            this.cbbSex.HotTrack = false;
            this.cbbSex.Location = new System.Drawing.Point(151, 82);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(300, 25);
            this.cbbSex.TabIndex = 3;
            // 
            // cbxBIsQuanlity
            // 
            this.cbxBIsQuanlity.AutoSize = true;
            this.cbxBIsQuanlity.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsUser, "BIsQuality", true));
            this.cbxBIsQuanlity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBIsQuanlity.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxBIsQuanlity.Location = new System.Drawing.Point(315, 350);
            this.cbxBIsQuanlity.Name = "cbxBIsQuanlity";
            this.cbxBIsQuanlity.Size = new System.Drawing.Size(72, 21);
            this.cbxBIsQuanlity.TabIndex = 11;
            this.cbxBIsQuanlity.Text = "质检提示";
            this.cbxBIsQuanlity.Textn = "质检提示";
            this.cbxBIsQuanlity.UseVisualStyleBackColor = true;
            this.cbxBIsQuanlity.Visible = false;
            // 
            // txtDecription
            // 
            this.txtDecription.BackColor = System.Drawing.Color.White;
            this.txtDecription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDecription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDecription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUser, "Description", true));
            this.txtDecription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDecription.HotTrack = false;
            this.txtDecription.Location = new System.Drawing.Point(151, 123);
            this.txtDecription.Multiline = true;
            this.txtDecription.Name = "txtDecription";
            this.txtDecription.Size = new System.Drawing.Size(755, 50);
            this.txtDecription.TabIndex = 5;
            this.txtDecription.TextEnabled = false;
            // 
            // chensLabel13
            // 
            this.chensLabel13.AutoSize = true;
            this.chensLabel13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel13.Location = new System.Drawing.Point(65, 125);
            this.chensLabel13.Name = "chensLabel13";
            this.chensLabel13.Size = new System.Drawing.Size(56, 17);
            this.chensLabel13.TabIndex = 136;
            this.chensLabel13.Text = "用户描述";
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUser, "UserNo", true));
            this.txtUserNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUserNo.HotTrack = false;
            this.txtUserNo.Location = new System.Drawing.Point(151, 43);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(300, 23);
            this.txtUserNo.TabIndex = 1;
            this.txtUserNo.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 2;
            this.chensLabel9.Text = "用户编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(457, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 130;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(912, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 17);
            this.label3.TabIndex = 130;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(457, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 130;
            this.label2.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(912, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 17);
            this.label13.TabIndex = 129;
            this.label13.Text = "*";
            // 
            // cbxBIsReceive
            // 
            this.cbxBIsReceive.AutoSize = true;
            this.cbxBIsReceive.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsUser, "BIsReceive", true));
            this.cbxBIsReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBIsReceive.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxBIsReceive.Location = new System.Drawing.Point(95, 350);
            this.cbxBIsReceive.Name = "cbxBIsReceive";
            this.cbxBIsReceive.Size = new System.Drawing.Size(72, 21);
            this.cbxBIsReceive.TabIndex = 10;
            this.cbxBIsReceive.Text = "是否收货";
            this.cbxBIsReceive.Textn = "是否收货";
            this.cbxBIsReceive.UseVisualStyleBackColor = true;
            this.cbxBIsReceive.CheckedChanged += new System.EventHandler(this.cbxBIsReceive_CheckedChanged);
            // 
            // txtRePassword
            // 
            this.txtRePassword.BackColor = System.Drawing.Color.White;
            this.txtRePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtRePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUser, "RePassword", true));
            this.txtRePassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtRePassword.HotTrack = false;
            this.txtRePassword.Location = new System.Drawing.Point(606, 258);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.Size = new System.Drawing.Size(300, 23);
            this.txtRePassword.TabIndex = 9;
            this.txtRePassword.TextEnabled = false;
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(520, 260);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(56, 17);
            this.chensLabel11.TabIndex = 17;
            this.chensLabel11.Text = "确认密码";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUser, "Password", true));
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPassword.HotTrack = false;
            this.txtPassword.Location = new System.Drawing.Point(151, 258);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(300, 23);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.TextEnabled = false;
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(65, 260);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 15;
            this.chensLabel10.Text = "用户密码";
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(25, 320);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 12;
            this.chensLabel8.Text = "属性设置";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.White;
            this.txtMobile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUser, "Mobile", true));
            this.txtMobile.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMobile.HotTrack = false;
            this.txtMobile.Location = new System.Drawing.Point(606, 82);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(300, 23);
            this.txtMobile.TabIndex = 4;
            this.txtMobile.TextEnabled = false;
            // 
            // cbbUserStatus
            // 
            this.cbbUserStatus.BackColor = System.Drawing.Color.White;
            this.cbbUserStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbUserStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsUser, "UserStatus", true));
            this.cbbUserStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUserStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbUserStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbUserStatus.FormattingEnabled = true;
            this.cbbUserStatus.HotTrack = false;
            this.cbbUserStatus.Location = new System.Drawing.Point(151, 190);
            this.cbbUserStatus.Name = "cbbUserStatus";
            this.cbbUserStatus.Size = new System.Drawing.Size(300, 25);
            this.cbbUserStatus.TabIndex = 6;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(65, 190);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 10;
            this.chensLabel7.Text = "用户状态";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(520, 85);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 6;
            this.chensLabel5.Text = "联系电话";
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(65, 85);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 4;
            this.chensLabel4.Text = "用户性别";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUser, "UserName", true));
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUserName.HotTrack = false;
            this.txtUserName.Location = new System.Drawing.Point(606, 43);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(300, 23);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(520, 45);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 2;
            this.chensLabel3.Text = "用户名称";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 230);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "密码设置";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 15);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "基本信息";
            // 
            // tpGroup
            // 
            this.tpGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpGroup.Controls.Add(this.cbxSelectAllGroup);
            this.tpGroup.Controls.Add(this.chensLabel12);
            this.tpGroup.Controls.Add(this.lvGroup);
            this.tpGroup.Location = new System.Drawing.Point(4, 29);
            this.tpGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpGroup.Name = "tpGroup";
            this.tpGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpGroup.Size = new System.Drawing.Size(984, 411);
            this.tpGroup.TabIndex = 1;
            this.tpGroup.Text = "用户组";
            // 
            // cbxSelectAllGroup
            // 
            this.cbxSelectAllGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectAllGroup.AutoSize = true;
            this.cbxSelectAllGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSelectAllGroup.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.cbxSelectAllGroup.Location = new System.Drawing.Point(62, 65);
            this.cbxSelectAllGroup.Name = "cbxSelectAllGroup";
            this.cbxSelectAllGroup.Size = new System.Drawing.Size(53, 23);
            this.cbxSelectAllGroup.TabIndex = 3;
            this.cbxSelectAllGroup.Text = "全选";
            this.cbxSelectAllGroup.Textn = "全选";
            this.cbxSelectAllGroup.UseVisualStyleBackColor = true;
            this.cbxSelectAllGroup.CheckedChanged += new System.EventHandler(this.cbxSelectAllGroup_CheckedChanged);
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(25, 15);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(56, 17);
            this.chensLabel12.TabIndex = 2;
            this.chensLabel12.Text = "所属分组";
            // 
            // lvGroup
            // 
            this.lvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvGroup.CheckBoxes = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.lvGroup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvGroup.Location = new System.Drawing.Point(65, 95);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(915, 314);
            this.lvGroup.TabIndex = 1;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.List;
            // 
            // tpWarehouse
            // 
            this.tpWarehouse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpWarehouse.Controls.Add(this.cbxSelectAllWarehouse);
            this.tpWarehouse.Controls.Add(this.lvWarehouse);
            this.tpWarehouse.Controls.Add(this.chensLabel14);
            this.tpWarehouse.Location = new System.Drawing.Point(4, 29);
            this.tpWarehouse.Name = "tpWarehouse";
            this.tpWarehouse.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpWarehouse.Size = new System.Drawing.Size(984, 411);
            this.tpWarehouse.TabIndex = 2;
            this.tpWarehouse.Text = "仓库";
            // 
            // cbxSelectAllWarehouse
            // 
            this.cbxSelectAllWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectAllWarehouse.AutoSize = true;
            this.cbxSelectAllWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSelectAllWarehouse.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.cbxSelectAllWarehouse.Location = new System.Drawing.Point(62, 65);
            this.cbxSelectAllWarehouse.Name = "cbxSelectAllWarehouse";
            this.cbxSelectAllWarehouse.Size = new System.Drawing.Size(53, 23);
            this.cbxSelectAllWarehouse.TabIndex = 5;
            this.cbxSelectAllWarehouse.Text = "全选";
            this.cbxSelectAllWarehouse.Textn = "全选";
            this.cbxSelectAllWarehouse.UseVisualStyleBackColor = true;
            this.cbxSelectAllWarehouse.CheckedChanged += new System.EventHandler(this.cbxSelectAllWarehouse_CheckedChanged);
            // 
            // lvWarehouse
            // 
            this.lvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWarehouse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvWarehouse.CheckBoxes = true;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.lvWarehouse.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.lvWarehouse.Location = new System.Drawing.Point(65, 95);
            this.lvWarehouse.Name = "lvWarehouse";
            this.lvWarehouse.Size = new System.Drawing.Size(915, 314);
            this.lvWarehouse.TabIndex = 4;
            this.lvWarehouse.UseCompatibleStateImageBehavior = false;
            this.lvWarehouse.View = System.Windows.Forms.View.List;
            // 
            // chensLabel14
            // 
            this.chensLabel14.AutoSize = true;
            this.chensLabel14.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel14.Location = new System.Drawing.Point(25, 15);
            this.chensLabel14.Name = "chensLabel14";
            this.chensLabel14.Size = new System.Drawing.Size(56, 17);
            this.chensLabel14.TabIndex = 3;
            this.chensLabel14.Text = "负责仓库";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiSave,
            this.tsmiSaveAdd,
            this.tsmiSaveClose,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(44, 21);
            this.tsmiAdd.Text = "新增";
            this.tsmiAdd.Visible = false;
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(80, 21);
            this.tsmiSave.Text = "保存并查看";
            this.tsmiSave.Visible = false;
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAdd
            // 
            this.tsmiSaveAdd.Name = "tsmiSaveAdd";
            this.tsmiSaveAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiSaveAdd.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveAdd.Text = "保存并新增";
            this.tsmiSaveAdd.Click += new System.EventHandler(this.tsmiSaveAdd_Click);
            // 
            // tsmiSaveClose
            // 
            this.tsmiSaveClose.Name = "tsmiSaveClose";
            this.tsmiSaveClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveClose.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveClose.Text = "保存并关闭";
            this.tsmiSaveClose.Click += new System.EventHandler(this.tsmiSaveClose_Click);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // FrmUserFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FrmUserFile";
            this.Text = "新增用户";
            this.Load += new System.EventHandler(this.FrmUserFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsUser)).EndInit();
            this.tcFile.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            this.tpGroup.ResumeLayout(false);
            this.tpGroup.PerformLayout();
            this.tpWarehouse.ResumeLayout(false);
            this.tpWarehouse.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensTabControl tcFile;
        private System.Windows.Forms.TabPage tpBasic;
        private ChensControl.ChensCheckBox cbxBIsPick;
        private ChensControl.ChensComboBox cbbSex;
        private ChensControl.ChensCheckBox cbxBIsQuanlity;
        private ChensControl.ChensTextBox txtDecription;
        private ChensControl.ChensLabel chensLabel13;
        private ChensControl.ChensTextBox txtUserNo;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensCheckBox cbxBIsReceive;
        private ChensControl.ChensTextBox txtRePassword;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensTextBox txtPassword;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensTextBox txtMobile;
        private ChensControl.ChensComboBox cbbUserStatus;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtUserName;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.TabPage tpGroup;
        private ChensControl.ChensLabel chensLabel12;
        private System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.TabPage tpWarehouse;
        private System.Windows.Forms.ListView lvWarehouse;
        private ChensControl.ChensLabel chensLabel14;
        private System.Windows.Forms.BindingSource bsUser;
        private ChensControl.ChensCheckBox cbxSelectAllGroup;
        private ChensControl.ChensCheckBox cbxSelectAllWarehouse;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
    }
}