namespace WMS
{
    partial class FrmMainTab
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainTab));
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.lblVersion = new ChensControl.ChensLinkLabel();
            this.navMenu = new ChensControl.ChensNavigator();
            this.tabForms = new ChensControl.ChensTabControl();
            this.plTop = new System.Windows.Forms.Panel();
            this.lblApplicationName = new ChensControl.ChensLabel();
            this.cmsTabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCloseThis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseRight = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.plUser = new System.Windows.Forms.Panel();
            this.btnChangePwd = new ChensControl.ChensLinkLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.cmsTabPage.SuspendLayout();
            this.plUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // spMain
            // 
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spMain.Location = new System.Drawing.Point(0, 90);
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.lblVersion);
            this.spMain.Panel1.Controls.Add(this.navMenu);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.picBackground);
            this.spMain.Panel2.Controls.Add(this.tabForms);
            this.spMain.Size = new System.Drawing.Size(1292, 642);
            this.spMain.SplitterDistance = 250;
            this.spMain.TabIndex = 1;
            this.spMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spMain_SplitterMoved);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(140)))), ((int)(((byte)(190)))));
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblVersion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.lblVersion.Location = new System.Drawing.Point(170, 623);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 17);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.TabStop = true;
            this.lblVersion.Text = "1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVersion_LinkClicked);
            // 
            // navMenu
            // 
            this.navMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navMenu.Location = new System.Drawing.Point(0, 0);
            this.navMenu.Name = "navMenu";
            this.navMenu.Size = new System.Drawing.Size(250, 642);
            this.navMenu.TabIndex = 0;
            this.navMenu.MenuButton2Click += new ChensControl.ChensNavigator.MenuButton2ClickHandle(this.navMenu_MenuButton2Click);
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForms.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabForms.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tabForms.HaveClose = true;
            this.tabForms.Location = new System.Drawing.Point(0, 0);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(1038, 642);
            this.tabForms.TabIndex = 0;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            this.tabForms.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabForms_ControlRemoved);
            this.tabForms.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDoubleClick);
            this.tabForms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDown);
            this.tabForms.MouseLeave += new System.EventHandler(this.tabForms_MouseLeave);
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(162)))), ((int)(((byte)(129)))));
            this.plTop.Controls.Add(this.picIcon);
            this.plTop.Controls.Add(this.picMin);
            this.plTop.Controls.Add(this.picClose);
            this.plTop.Controls.Add(this.lblApplicationName);
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1358, 25);
            this.plTop.TabIndex = 2;
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblApplicationName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblApplicationName.Location = new System.Drawing.Point(632, 4);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(103, 17);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "WMS系统 主界面";
            // 
            // cmsTabPage
            // 
            this.cmsTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmsTabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh,
            this.toolStripSeparator1,
            this.tsmiCloseThis,
            this.tsmiCloseOther,
            this.tsmiCloseLeft,
            this.tsmiCloseRight,
            this.tsmiCloseAll});
            this.cmsTabPage.Name = "cmsTabPage";
            this.cmsTabPage.Size = new System.Drawing.Size(137, 142);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(136, 22);
            this.tsmiRefresh.Text = "刷新当前页";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // tsmiCloseThis
            // 
            this.tsmiCloseThis.Name = "tsmiCloseThis";
            this.tsmiCloseThis.Size = new System.Drawing.Size(136, 22);
            this.tsmiCloseThis.Text = "关闭当前项";
            this.tsmiCloseThis.Click += new System.EventHandler(this.tsmiCloseThis_Click);
            // 
            // tsmiCloseOther
            // 
            this.tsmiCloseOther.Name = "tsmiCloseOther";
            this.tsmiCloseOther.Size = new System.Drawing.Size(136, 22);
            this.tsmiCloseOther.Text = "关闭其他项";
            this.tsmiCloseOther.Click += new System.EventHandler(this.tsmiCloseOther_Click);
            // 
            // tsmiCloseLeft
            // 
            this.tsmiCloseLeft.Name = "tsmiCloseLeft";
            this.tsmiCloseLeft.Size = new System.Drawing.Size(136, 22);
            this.tsmiCloseLeft.Text = "关闭左侧项";
            this.tsmiCloseLeft.Click += new System.EventHandler(this.tsmiCloseLeft_Click);
            // 
            // tsmiCloseRight
            // 
            this.tsmiCloseRight.Name = "tsmiCloseRight";
            this.tsmiCloseRight.Size = new System.Drawing.Size(136, 22);
            this.tsmiCloseRight.Text = "关闭右侧项";
            this.tsmiCloseRight.Click += new System.EventHandler(this.tsmiCloseRight_Click);
            // 
            // tsmiCloseAll
            // 
            this.tsmiCloseAll.Name = "tsmiCloseAll";
            this.tsmiCloseAll.Size = new System.Drawing.Size(136, 22);
            this.tsmiCloseAll.Text = "关闭所有项";
            this.tsmiCloseAll.Click += new System.EventHandler(this.tsmiCloseAll_Click);
            // 
            // plUser
            // 
            this.plUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plUser.Controls.Add(this.btnChangePwd);
            this.plUser.Controls.Add(this.chensLabel2);
            this.plUser.Controls.Add(this.chensLabel1);
            this.plUser.Controls.Add(this.pictureBox1);
            this.plUser.Location = new System.Drawing.Point(1080, 70);
            this.plUser.Name = "plUser";
            this.plUser.Size = new System.Drawing.Size(135, 90);
            this.plUser.TabIndex = 5;
            this.plUser.Visible = false;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.AutoSize = true;
            this.btnChangePwd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnChangePwd.Location = new System.Drawing.Point(39, 67);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(56, 17);
            this.btnChangePwd.TabIndex = 3;
            this.btnChangePwd.TabStop = true;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnChangePwd_LinkClicked);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 40);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(51, 20);
            this.chensLabel2.TabIndex = 2;
            this.chensLabel2.Text = "管理员";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chensLabel1.Location = new System.Drawing.Point(65, 15);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(52, 20);
            this.chensLabel1.TabIndex = 1;
            this.chensLabel1.Text = "admin";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WMS.Properties.Resources.MainTop;
            this.pictureBox2.Image = global::WMS.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(46, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(169, 53);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMS.Properties.Resources.head;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.BackgroundImage = global::WMS.Properties.Resources.admin;
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picUser.Location = new System.Drawing.Point(1189, 40);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(25, 25);
            this.picUser.TabIndex = 4;
            this.picUser.TabStop = false;
            this.picUser.Visible = false;
            this.picUser.Click += new System.EventHandler(this.picUser_Click);
            // 
            // picExit
            // 
            this.picExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImage = global::WMS.Properties.Resources.exit;
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picExit.Location = new System.Drawing.Point(1239, 40);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(25, 25);
            this.picExit.TabIndex = 3;
            this.picExit.TabStop = false;
            this.picExit.Visible = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picIcon.Location = new System.Drawing.Point(0, 0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(25, 25);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 3;
            this.picIcon.TabStop = false;
            // 
            // picMin
            // 
            this.picMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMin.Image = global::WMS.Properties.Resources.min;
            this.picMin.Location = new System.Drawing.Point(1307, 1);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(24, 24);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMin.TabIndex = 2;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            this.picMin.MouseEnter += new System.EventHandler(this.picMin_MouseEnter);
            this.picMin.MouseLeave += new System.EventHandler(this.picMin_MouseLeave);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picClose.Image = global::WMS.Properties.Resources.close;
            this.picClose.Location = new System.Drawing.Point(1331, 1);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(24, 24);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // picBackground
            // 
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.ErrorImage = null;
            this.picBackground.Image = global::WMS.Properties.Resources.MainBackground;
            this.picBackground.InitialImage = null;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(1038, 642);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 1;
            this.picBackground.TabStop = false;
            // 
            // picHeader
            // 
            this.picHeader.BackgroundImage = global::WMS.Properties.Resources.MainTop;
            this.picHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(1292, 90);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 0;
            this.picHeader.TabStop = false;
            this.picHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseMove);
            // 
            // FrmMainTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1292, 732);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.plUser);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.plTop);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.picHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMainTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOMS系统 主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMainTab_FormClosed);
            this.Load += new System.EventHandler(this.FrmMainTab_Load);
            this.Shown += new System.EventHandler(this.FrmMainTab_Shown);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel1.PerformLayout();
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.cmsTabPage.ResumeLayout(false);
            this.plUser.ResumeLayout(false);
            this.plUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.SplitContainer spMain;
        private ChensControl.ChensNavigator navMenu;
        private ChensControl.ChensTabControl tabForms;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.PictureBox picClose;
        private ChensControl.ChensLabel lblApplicationName;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.ContextMenuStrip cmsTabPage;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseThis;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseOther;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseLeft;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseRight;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseAll;
        private System.Windows.Forms.Panel plUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ChensControl.ChensLinkLabel btnChangePwd;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLinkLabel lblVersion;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

