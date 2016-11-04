namespace WMS.Basic
{
    partial class FrmMenuFile
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
            this.tcFile = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.txtParameter = new ChensControl.ChensTextBox();
            this.chensLabel13 = new ChensControl.ChensLabel();
            this.cbbMenuStatus = new ChensControl.ChensComboBox();
            this.bsMenu = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxControls = new ChensControl.ChensComboBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.cbxForms = new ChensControl.ChensComboBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.cbxNamespace = new ChensControl.ChensComboBox();
            this.cbbMenuType = new ChensControl.ChensComboBox();
            this.cbxBIsDefault = new ChensControl.ChensCheckBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtDescription = new ChensControl.ChensTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbParentMenu = new ChensControl.ChensComboBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtSolution = new ChensControl.ChensTextBox();
            this.txtMenuNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMenuName = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tcFile.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMenu)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcFile
            // 
            this.tcFile.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcFile.Controls.Add(this.tpBasic);
            this.tcFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFile.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tcFile.Location = new System.Drawing.Point(0, 25);
            this.tcFile.Name = "tcFile";
            this.tcFile.SelectedIndex = 0;
            this.tcFile.Size = new System.Drawing.Size(992, 444);
            this.tcFile.TabIndex = 3;
            this.tcFile.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.txtParameter);
            this.tpBasic.Controls.Add(this.chensLabel13);
            this.tpBasic.Controls.Add(this.cbbMenuStatus);
            this.tpBasic.Controls.Add(this.chensLabel12);
            this.tpBasic.Controls.Add(this.label5);
            this.tpBasic.Controls.Add(this.label3);
            this.tpBasic.Controls.Add(this.cbxControls);
            this.tpBasic.Controls.Add(this.chensLabel11);
            this.tpBasic.Controls.Add(this.cbxForms);
            this.tpBasic.Controls.Add(this.chensLabel10);
            this.tpBasic.Controls.Add(this.chensLabel8);
            this.tpBasic.Controls.Add(this.cbxNamespace);
            this.tpBasic.Controls.Add(this.cbbMenuType);
            this.tpBasic.Controls.Add(this.cbxBIsDefault);
            this.tpBasic.Controls.Add(this.chensLabel6);
            this.tpBasic.Controls.Add(this.txtDescription);
            this.tpBasic.Controls.Add(this.label2);
            this.tpBasic.Controls.Add(this.label1);
            this.tpBasic.Controls.Add(this.cbbParentMenu);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtSolution);
            this.tpBasic.Controls.Add(this.txtMenuNo);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.chensLabel7);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtMenuName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasic.Size = new System.Drawing.Size(984, 411);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "菜单信息";
            // 
            // txtParameter
            // 
            this.txtParameter.BackColor = System.Drawing.Color.White;
            this.txtParameter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParameter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtParameter.HotTrack = false;
            this.txtParameter.Location = new System.Drawing.Point(605, 123);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(135, 23);
            this.txtParameter.TabIndex = 8;
            this.txtParameter.TextEnabled = false;
            // 
            // chensLabel13
            // 
            this.chensLabel13.AutoSize = true;
            this.chensLabel13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel13.Location = new System.Drawing.Point(588, 125);
            this.chensLabel13.Name = "chensLabel13";
            this.chensLabel13.Size = new System.Drawing.Size(11, 17);
            this.chensLabel13.TabIndex = 169;
            this.chensLabel13.Text = ":";
            // 
            // cbbMenuStatus
            // 
            this.cbbMenuStatus.BackColor = System.Drawing.Color.White;
            this.cbbMenuStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbMenuStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMenu, "MenuStatus", true));
            this.cbbMenuStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMenuStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbMenuStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbMenuStatus.FormattingEnabled = true;
            this.cbbMenuStatus.HotTrack = false;
            this.cbbMenuStatus.Location = new System.Drawing.Point(151, 227);
            this.cbbMenuStatus.Name = "cbbMenuStatus";
            this.cbbMenuStatus.Size = new System.Drawing.Size(300, 25);
            this.cbbMenuStatus.TabIndex = 11;
            // 
            // bsMenu
            // 
            this.bsMenu.DataSource = typeof(WMS.WebService.MenuInfo);
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(65, 230);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(56, 17);
            this.chensLabel12.TabIndex = 167;
            this.chensLabel12.Text = "菜单状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(912, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 166;
            this.label5.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(912, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 17);
            this.label3.TabIndex = 165;
            this.label3.Text = "*";
            // 
            // cbxControls
            // 
            this.cbxControls.BackColor = System.Drawing.Color.White;
            this.cbxControls.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxControls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxControls.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxControls.FormattingEnabled = true;
            this.cbxControls.HotTrack = false;
            this.cbxControls.Location = new System.Drawing.Point(756, 122);
            this.cbxControls.Name = "cbxControls";
            this.cbxControls.Size = new System.Drawing.Size(150, 25);
            this.cbxControls.TabIndex = 9;
            this.cbxControls.SelectedIndexChanged += new System.EventHandler(this.cbxControls_SelectedIndexChanged);
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(742, 125);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(11, 17);
            this.chensLabel11.TabIndex = 163;
            this.chensLabel11.Text = ".";
            // 
            // cbxForms
            // 
            this.cbxForms.BackColor = System.Drawing.Color.White;
            this.cbxForms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxForms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxForms.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxForms.FormattingEnabled = true;
            this.cbxForms.HotTrack = false;
            this.cbxForms.Location = new System.Drawing.Point(435, 122);
            this.cbxForms.Name = "cbxForms";
            this.cbxForms.Size = new System.Drawing.Size(150, 25);
            this.cbxForms.TabIndex = 7;
            this.cbxForms.SelectedIndexChanged += new System.EventHandler(this.cbxForms_SelectedIndexChanged);
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(421, 125);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(11, 17);
            this.chensLabel10.TabIndex = 161;
            this.chensLabel10.Text = ".";
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(254, 125);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(11, 17);
            this.chensLabel8.TabIndex = 160;
            this.chensLabel8.Text = ".";
            // 
            // cbxNamespace
            // 
            this.cbxNamespace.BackColor = System.Drawing.Color.White;
            this.cbxNamespace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxNamespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNamespace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNamespace.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxNamespace.FormattingEnabled = true;
            this.cbxNamespace.HotTrack = false;
            this.cbxNamespace.Location = new System.Drawing.Point(268, 122);
            this.cbxNamespace.Name = "cbxNamespace";
            this.cbxNamespace.Size = new System.Drawing.Size(150, 25);
            this.cbxNamespace.TabIndex = 6;
            this.cbxNamespace.SelectedIndexChanged += new System.EventHandler(this.cbxNamespace_SelectedIndexChanged);
            // 
            // cbbMenuType
            // 
            this.cbbMenuType.BackColor = System.Drawing.Color.White;
            this.cbbMenuType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbMenuType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMenu, "MenuType", true));
            this.cbbMenuType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMenuType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbMenuType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbMenuType.FormattingEnabled = true;
            this.cbbMenuType.HotTrack = false;
            this.cbbMenuType.Location = new System.Drawing.Point(606, 83);
            this.cbbMenuType.Name = "cbbMenuType";
            this.cbbMenuType.Size = new System.Drawing.Size(300, 25);
            this.cbbMenuType.TabIndex = 4;
            this.cbbMenuType.SelectedIndexChanged += new System.EventHandler(this.cbbMenuType_SelectedIndexChanged);
            // 
            // cbxBIsDefault
            // 
            this.cbxBIsDefault.AutoSize = true;
            this.cbxBIsDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsMenu, "BIsDefault", true));
            this.cbxBIsDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBIsDefault.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxBIsDefault.Location = new System.Drawing.Point(95, 325);
            this.cbxBIsDefault.Name = "cbxBIsDefault";
            this.cbxBIsDefault.Size = new System.Drawing.Size(72, 21);
            this.cbxBIsDefault.TabIndex = 12;
            this.cbxBIsDefault.Text = "是否默认";
            this.cbxBIsDefault.Textn = "是否默认";
            this.cbxBIsDefault.UseVisualStyleBackColor = true;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(25, 295);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 155;
            this.chensLabel6.Text = "属性设置";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMenu, "Description", true));
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDescription.HotTrack = false;
            this.txtDescription.Location = new System.Drawing.Point(151, 163);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(755, 50);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.TextEnabled = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(457, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 154;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(912, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 153;
            this.label1.Text = "*";
            // 
            // cbbParentMenu
            // 
            this.cbbParentMenu.BackColor = System.Drawing.Color.White;
            this.cbbParentMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbParentMenu.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMenu, "ParentID", true));
            this.cbbParentMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbParentMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbParentMenu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbParentMenu.FormattingEnabled = true;
            this.cbbParentMenu.HotTrack = false;
            this.cbbParentMenu.Location = new System.Drawing.Point(151, 82);
            this.cbbParentMenu.Name = "cbbParentMenu";
            this.cbbParentMenu.Size = new System.Drawing.Size(300, 25);
            this.cbbParentMenu.TabIndex = 3;
            this.cbbParentMenu.SelectedIndexChanged += new System.EventHandler(this.cbbParentMenu_SelectedIndexChanged);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 165);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 150;
            this.chensLabel2.Text = "菜单描述";
            // 
            // txtSolution
            // 
            this.txtSolution.BackColor = System.Drawing.Color.White;
            this.txtSolution.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSolution.Enabled = false;
            this.txtSolution.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSolution.HotTrack = false;
            this.txtSolution.Location = new System.Drawing.Point(151, 123);
            this.txtSolution.Name = "txtSolution";
            this.txtSolution.Size = new System.Drawing.Size(100, 23);
            this.txtSolution.TabIndex = 5;
            this.txtSolution.Text = "JingXinWMS";
            this.txtSolution.TextEnabled = false;
            // 
            // txtMenuNo
            // 
            this.txtMenuNo.BackColor = System.Drawing.Color.White;
            this.txtMenuNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMenuNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMenuNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMenu, "MenuNo", true));
            this.txtMenuNo.Enabled = false;
            this.txtMenuNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMenuNo.HotTrack = false;
            this.txtMenuNo.Location = new System.Drawing.Point(151, 43);
            this.txtMenuNo.Name = "txtMenuNo";
            this.txtMenuNo.Size = new System.Drawing.Size(300, 23);
            this.txtMenuNo.TabIndex = 1;
            this.txtMenuNo.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 137;
            this.chensLabel9.Text = "菜单编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(457, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 146;
            this.label4.Text = "*";
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(520, 85);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 145;
            this.chensLabel7.Text = "菜单类型";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(65, 125);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 142;
            this.chensLabel5.Text = "菜单路径";
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(65, 85);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 140;
            this.chensLabel4.Text = "上级菜单";
            // 
            // txtMenuName
            // 
            this.txtMenuName.BackColor = System.Drawing.Color.White;
            this.txtMenuName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMenuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMenuName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMenu, "MenuName", true));
            this.txtMenuName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMenuName.HotTrack = false;
            this.txtMenuName.Location = new System.Drawing.Point(606, 43);
            this.txtMenuName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(300, 23);
            this.txtMenuName.TabIndex = 2;
            this.txtMenuName.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(520, 45);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 138;
            this.chensLabel3.Text = "菜单名称";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 15);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 136;
            this.chensLabel1.Text = "基本信息";
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
            this.msMain.TabIndex = 2;
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
            // FrmMenuFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Name = "FrmMenuFile";
            this.Text = "新增菜单";
            this.Load += new System.EventHandler(this.FrmMenuFile_Load);
            this.tcFile.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMenu)).EndInit();
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
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtSolution;
        private ChensControl.ChensTextBox txtMenuNo;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.Label label4;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtMenuName;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.Label label1;
        private ChensControl.ChensComboBox cbbParentMenu;
        private System.Windows.Forms.Label label2;
        private ChensControl.ChensTextBox txtDescription;
        private System.Windows.Forms.BindingSource bsMenu;
        private ChensControl.ChensCheckBox cbxBIsDefault;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensComboBox cbbMenuType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private ChensControl.ChensComboBox cbxControls;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensComboBox cbxForms;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensComboBox cbxNamespace;
        private ChensControl.ChensComboBox cbbMenuStatus;
        private ChensControl.ChensLabel chensLabel12;
        private ChensControl.ChensTextBox txtParameter;
        private ChensControl.ChensLabel chensLabel13;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
    }
}