namespace WMS.Basic
{
    partial class FrmGroupMenu
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("查询管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("仓库管理", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("盘点管理", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点14");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("任务看板", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点16");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("标签打印", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点18");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("基础设置", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenuUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenuDown = new System.Windows.Forms.ToolStripMenuItem();
            this.tclBasic = new ChensControl.ChensTestControl1();
            this.scBasic = new System.Windows.Forms.SplitContainer();
            this.imgListMenu = new System.Windows.Forms.ImageList(this.components);
            this.scGroup = new System.Windows.Forms.SplitContainer();
            this.tclLeft = new ChensControl.ChensTestControl1();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserGroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUserGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHIsDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHUserGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageList = new ChensControl.ChensPage();
            this.lblGroup = new ChensControl.ChensLabel();
            this.scMenu = new System.Windows.Forms.SplitContainer();
            this.tclRight = new ChensControl.ChensTestControl1();
            this.tvMenu = new ChensControl.ChensTreeView();
            this.lblMenu = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.tclBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBasic)).BeginInit();
            this.scBasic.Panel1.SuspendLayout();
            this.scBasic.Panel2.SuspendLayout();
            this.scBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGroup)).BeginInit();
            this.scGroup.Panel1.SuspendLayout();
            this.scGroup.Panel2.SuspendLayout();
            this.scGroup.SuspendLayout();
            this.tclLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMenu)).BeginInit();
            this.scMenu.Panel1.SuspendLayout();
            this.scMenu.Panel2.SuspendLayout();
            this.scMenu.SuspendLayout();
            this.tclRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddGroup,
            this.tsmiDelGroup,
            this.tsmiAddMenu,
            this.tsmiDelMenu,
            this.tsmiMenuUp,
            this.tsmiMenuDown});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiAddGroup
            // 
            this.tsmiAddGroup.Name = "tsmiAddGroup";
            this.tsmiAddGroup.Size = new System.Drawing.Size(80, 21);
            this.tsmiAddGroup.Text = "新增用户组";
            this.tsmiAddGroup.Click += new System.EventHandler(this.tsmiAddGroup_Click);
            // 
            // tsmiDelGroup
            // 
            this.tsmiDelGroup.Name = "tsmiDelGroup";
            this.tsmiDelGroup.Size = new System.Drawing.Size(80, 21);
            this.tsmiDelGroup.Text = "删除用户组";
            this.tsmiDelGroup.Click += new System.EventHandler(this.tsmiDelGroup_Click);
            // 
            // tsmiAddMenu
            // 
            this.tsmiAddMenu.Name = "tsmiAddMenu";
            this.tsmiAddMenu.Size = new System.Drawing.Size(68, 21);
            this.tsmiAddMenu.Text = "新增菜单";
            this.tsmiAddMenu.Click += new System.EventHandler(this.tsmiAddMenu_Click);
            // 
            // tsmiDelMenu
            // 
            this.tsmiDelMenu.Name = "tsmiDelMenu";
            this.tsmiDelMenu.Size = new System.Drawing.Size(68, 21);
            this.tsmiDelMenu.Text = "删除菜单";
            this.tsmiDelMenu.Click += new System.EventHandler(this.tsmiDelMenu_Click);
            // 
            // tsmiMenuUp
            // 
            this.tsmiMenuUp.Name = "tsmiMenuUp";
            this.tsmiMenuUp.Size = new System.Drawing.Size(68, 21);
            this.tsmiMenuUp.Text = "上移菜单";
            this.tsmiMenuUp.Visible = false;
            // 
            // tsmiMenuDown
            // 
            this.tsmiMenuDown.Name = "tsmiMenuDown";
            this.tsmiMenuDown.Size = new System.Drawing.Size(68, 21);
            this.tsmiMenuDown.Text = "下移菜单";
            this.tsmiMenuDown.Visible = false;
            // 
            // tclBasic
            // 
            this.tclBasic.Controls.Add(this.scBasic);
            this.tclBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclBasic.Location = new System.Drawing.Point(0, 25);
            this.tclBasic.Name = "tclBasic";
            this.tclBasic.Size = new System.Drawing.Size(992, 728);
            this.tclBasic.TabIndex = 2;
            // 
            // scBasic
            // 
            this.scBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBasic.Location = new System.Drawing.Point(0, 0);
            this.scBasic.Name = "scBasic";
            // 
            // scBasic.Panel1
            // 
            this.scBasic.Panel1.Controls.Add(this.scGroup);
            // 
            // scBasic.Panel2
            // 
            this.scBasic.Panel2.Controls.Add(this.scMenu);
            this.scBasic.Size = new System.Drawing.Size(992, 728);
            this.scBasic.SplitterDistance = 330;
            this.scBasic.TabIndex = 2;
            this.scBasic.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scBasic_SplitterMoved);
            // 
            // imgListMenu
            // 
            this.imgListMenu.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListMenu.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListMenu.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // scGroup
            // 
            this.scGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGroup.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scGroup.IsSplitterFixed = true;
            this.scGroup.Location = new System.Drawing.Point(0, 0);
            this.scGroup.Name = "scGroup";
            this.scGroup.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scGroup.Panel1
            // 
            this.scGroup.Panel1.Controls.Add(this.lblGroup);
            // 
            // scGroup.Panel2
            // 
            this.scGroup.Panel2.Controls.Add(this.tclLeft);
            this.scGroup.Size = new System.Drawing.Size(330, 728);
            this.scGroup.SplitterDistance = 25;
            this.scGroup.TabIndex = 0;
            this.scGroup.TabStop = false;
            // 
            // tclLeft
            // 
            this.tclLeft.Controls.Add(this.dgvList);
            this.tclLeft.Controls.Add(this.pageList);
            this.tclLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclLeft.Location = new System.Drawing.Point(0, 0);
            this.tclLeft.Name = "tclLeft";
            this.tclLeft.Size = new System.Drawing.Size(330, 699);
            this.tclLeft.TabIndex = 2;
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
            this.colUserGroupNo,
            this.colHUserGroupName,
            this.colHCreater,
            this.colHCreateTime,
            this.colHIsDel,
            this.colHUserGroupType,
            this.colHDESCRIPTION});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
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
            this.dgvList.Size = new System.Drawing.Size(330, 672);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellClick);
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellContentClick);
            // 
            // colEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "编辑";
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEdit.HeaderText = "编辑";
            this.colEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.Width = 80;
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "ID";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.Visible = false;
            // 
            // colUserGroupNo
            // 
            this.colUserGroupNo.DataPropertyName = "UserGroupNo";
            this.colUserGroupNo.HeaderText = "用户组编号";
            this.colUserGroupNo.Name = "colUserGroupNo";
            this.colUserGroupNo.Visible = false;
            // 
            // colHUserGroupName
            // 
            this.colHUserGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHUserGroupName.DataPropertyName = "UserGroupName";
            this.colHUserGroupName.HeaderText = "用户组名称";
            this.colHUserGroupName.Name = "colHUserGroupName";
            // 
            // colHCreater
            // 
            this.colHCreater.DataPropertyName = "Creater";
            this.colHCreater.HeaderText = "创建人";
            this.colHCreater.Name = "colHCreater";
            this.colHCreater.Visible = false;
            // 
            // colHCreateTime
            // 
            this.colHCreateTime.DataPropertyName = "CreateTime";
            this.colHCreateTime.HeaderText = "创建时间";
            this.colHCreateTime.Name = "colHCreateTime";
            this.colHCreateTime.Visible = false;
            // 
            // colHIsDel
            // 
            this.colHIsDel.DataPropertyName = "IsDel";
            this.colHIsDel.HeaderText = "删除标识";
            this.colHIsDel.Name = "colHIsDel";
            this.colHIsDel.Visible = false;
            // 
            // colHUserGroupType
            // 
            this.colHUserGroupType.DataPropertyName = "UserGroupType";
            this.colHUserGroupType.HeaderText = "分组类别";
            this.colHUserGroupType.Name = "colHUserGroupType";
            this.colHUserGroupType.Visible = false;
            // 
            // colHDESCRIPTION
            // 
            this.colHDESCRIPTION.DataPropertyName = "DESCRIPTION";
            this.colHDESCRIPTION.HeaderText = "分组说明";
            this.colHDESCRIPTION.Name = "colHDESCRIPTION";
            this.colHDESCRIPTION.Visible = false;
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
            this.pageList.Location = new System.Drawing.Point(0, 672);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(330, 27);
            this.pageList.TabIndex = 0;
            this.pageList.Visible = false;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageGroup_ChensPageChange);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.DarkOrange;
            this.lblGroup.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblGroup.Location = new System.Drawing.Point(12, 4);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(44, 17);
            this.lblGroup.TabIndex = 1;
            this.lblGroup.Text = "用户组";
            // 
            // scMenu
            // 
            this.scMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMenu.IsSplitterFixed = true;
            this.scMenu.Location = new System.Drawing.Point(0, 0);
            this.scMenu.Name = "scMenu";
            this.scMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMenu.Panel1
            // 
            this.scMenu.Panel1.Controls.Add(this.lblMenu);
            // 
            // scMenu.Panel2
            // 
            this.scMenu.Panel2.Controls.Add(this.tclRight);
            this.scMenu.Size = new System.Drawing.Size(658, 728);
            this.scMenu.SplitterDistance = 25;
            this.scMenu.TabIndex = 0;
            this.scMenu.TabStop = false;
            // 
            // tclRight
            // 
            this.tclRight.Controls.Add(this.tvMenu);
            this.tclRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclRight.Location = new System.Drawing.Point(0, 0);
            this.tclRight.Name = "tclRight";
            this.tclRight.Size = new System.Drawing.Size(658, 699);
            this.tclRight.TabIndex = 3;
            // 
            // tvMenu
            // 
            this.tvMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvMenu.CheckBoxes = true;
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Name = "tvMenu";
            treeNode1.Name = "节点6";
            treeNode1.Text = "节点6";
            treeNode2.Name = "节点7";
            treeNode2.Text = "节点7";
            treeNode3.Name = "节点8";
            treeNode3.Text = "节点8";
            treeNode4.Name = "节点0";
            treeNode4.Text = "查询管理";
            treeNode5.Name = "节点9";
            treeNode5.Text = "节点9";
            treeNode6.Name = "节点10";
            treeNode6.Text = "节点10";
            treeNode7.Name = "节点1";
            treeNode7.Text = "仓库管理";
            treeNode8.Name = "节点11";
            treeNode8.Text = "节点11";
            treeNode9.Name = "节点12";
            treeNode9.Text = "节点12";
            treeNode10.Name = "节点2";
            treeNode10.Text = "盘点管理";
            treeNode11.Name = "节点13";
            treeNode11.Text = "节点13";
            treeNode12.Name = "节点14";
            treeNode12.Text = "节点14";
            treeNode13.Name = "节点3";
            treeNode13.Text = "任务看板";
            treeNode14.Name = "节点15";
            treeNode14.Text = "节点15";
            treeNode15.Name = "节点16";
            treeNode15.Text = "节点16";
            treeNode16.Name = "节点4";
            treeNode16.Text = "标签打印";
            treeNode17.Name = "节点17";
            treeNode17.Text = "节点17";
            treeNode18.Name = "节点18";
            treeNode18.Text = "节点18";
            treeNode19.Name = "节点5";
            treeNode19.Text = "基础设置";
            this.tvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode10,
            treeNode13,
            treeNode16,
            treeNode19});
            this.tvMenu.Size = new System.Drawing.Size(658, 699);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterCheck);
            this.tvMenu.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterCollapse);
            this.tvMenu.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterExpand);
            this.tvMenu.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeSelect);
            this.tvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMenu_NodeMouseDoubleClick);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.DarkOrange;
            this.lblMenu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblMenu.Location = new System.Drawing.Point(12, 4);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(56, 17);
            this.lblMenu.TabIndex = 2;
            this.lblMenu.Text = "菜单权限";
            // 
            // FrmGroupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 753);
            this.Controls.Add(this.tclBasic);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "FrmGroupMenu";
            this.Text = "菜单权限设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGroupMenu_FormClosed);
            this.Load += new System.EventHandler(this.FrmGroupMenu_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tclBasic.ResumeLayout(false);
            this.scBasic.Panel1.ResumeLayout(false);
            this.scBasic.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBasic)).EndInit();
            this.scBasic.ResumeLayout(false);
            this.scGroup.Panel1.ResumeLayout(false);
            this.scGroup.Panel1.PerformLayout();
            this.scGroup.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scGroup)).EndInit();
            this.scGroup.ResumeLayout(false);
            this.tclLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.scMenu.Panel1.ResumeLayout(false);
            this.scMenu.Panel1.PerformLayout();
            this.scMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMenu)).EndInit();
            this.scMenu.ResumeLayout(false);
            this.tclRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelMenu;
        private ChensControl.ChensTestControl1 tclBasic;
        private System.Windows.Forms.ImageList imgListMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuUp;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuDown;
        private System.Windows.Forms.SplitContainer scBasic;
        private System.Windows.Forms.SplitContainer scGroup;
        private System.Windows.Forms.SplitContainer scMenu;
        private ChensControl.ChensLabel lblMenu;
        private ChensControl.ChensTestControl1 tclRight;
        private ChensControl.ChensTreeView tvMenu;
        private ChensControl.ChensLabel lblGroup;
        private ChensControl.ChensTestControl1 tclLeft;
        private ChensControl.ChensDataGridView dgvList;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserGroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUserGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHIsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHUserGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHDESCRIPTION;
        private ChensControl.ChensPage pageList;
    }
}