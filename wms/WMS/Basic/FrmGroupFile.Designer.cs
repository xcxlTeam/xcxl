namespace WMS.Basic
{
    partial class FrmGroupFile
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
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.chensTabControl1 = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.cbbUserGroupStatus = new ChensControl.ChensComboBox();
            this.bsGroup = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.cbbUserGroupType = new ChensControl.ChensComboBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtDescription = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGroupName = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtGroupNo = new ChensControl.ChensTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.chensTabControl1.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsGroup)).BeginInit();
            this.SuspendLayout();
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
            this.msMain.Size = new System.Drawing.Size(492, 25);
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
            // chensTabControl1
            // 
            this.chensTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.chensTabControl1.Controls.Add(this.tpBasic);
            this.chensTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.chensTabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.chensTabControl1.Location = new System.Drawing.Point(0, 25);
            this.chensTabControl1.Name = "chensTabControl1";
            this.chensTabControl1.SelectedIndex = 0;
            this.chensTabControl1.Size = new System.Drawing.Size(492, 325);
            this.chensTabControl1.TabIndex = 3;
            this.chensTabControl1.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.cbbUserGroupStatus);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.cbbUserGroupType);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtDescription);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.txtGroupName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.txtGroupNo);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasic.Size = new System.Drawing.Size(484, 292);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "组信息";
            // 
            // cbbUserGroupStatus
            // 
            this.cbbUserGroupStatus.BackColor = System.Drawing.Color.White;
            this.cbbUserGroupStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbUserGroupStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsGroup, "UserGroupStatus", true));
            this.cbbUserGroupStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUserGroupStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbUserGroupStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbUserGroupStatus.FormattingEnabled = true;
            this.cbbUserGroupStatus.HotTrack = false;
            this.cbbUserGroupStatus.Location = new System.Drawing.Point(127, 227);
            this.cbbUserGroupStatus.Name = "cbbUserGroupStatus";
            this.cbbUserGroupStatus.Size = new System.Drawing.Size(300, 25);
            this.cbbUserGroupStatus.TabIndex = 5;
            // 
            // bsGroup
            // 
            this.bsGroup.DataSource = typeof(WMS.WebService.UserGroupInfo);
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(65, 230);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 139;
            this.chensLabel5.Text = "分组状态";
            // 
            // cbbUserGroupType
            // 
            this.cbbUserGroupType.BackColor = System.Drawing.Color.White;
            this.cbbUserGroupType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbUserGroupType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsGroup, "UserGroupType", true));
            this.cbbUserGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUserGroupType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbUserGroupType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbUserGroupType.FormattingEnabled = true;
            this.cbbUserGroupType.HotTrack = false;
            this.cbbUserGroupType.Location = new System.Drawing.Point(127, 122);
            this.cbbUserGroupType.Name = "cbbUserGroupType";
            this.cbbUserGroupType.Size = new System.Drawing.Size(300, 25);
            this.cbbUserGroupType.TabIndex = 3;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(65, 125);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 138;
            this.chensLabel4.Text = "分组类型";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGroup, "Description", true));
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDescription.HotTrack = false;
            this.txtDescription.Location = new System.Drawing.Point(127, 163);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 50);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 165);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 136;
            this.chensLabel2.Text = "分组描述";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(433, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 17);
            this.label13.TabIndex = 135;
            this.label13.Text = "*";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.White;
            this.txtGroupName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGroup, "UserGroupName", true));
            this.txtGroupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtGroupName.HotTrack = false;
            this.txtGroupName.Location = new System.Drawing.Point(127, 83);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(300, 23);
            this.txtGroupName.TabIndex = 2;
            this.txtGroupName.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(65, 85);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 133;
            this.chensLabel3.Text = "分组名称";
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.BackColor = System.Drawing.Color.White;
            this.txtGroupNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtGroupNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGroup, "UserGroupNo", true));
            this.txtGroupNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtGroupNo.HotTrack = false;
            this.txtGroupNo.Location = new System.Drawing.Point(127, 43);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(300, 23);
            this.txtGroupNo.TabIndex = 1;
            this.txtGroupNo.TextEnabled = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(433, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 132;
            this.label4.Text = "*";
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 3;
            this.chensLabel9.Text = "分组编号";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 15);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 1;
            this.chensLabel1.Text = "基本信息";
            // 
            // FrmGroupFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 350);
            this.Controls.Add(this.chensTabControl1);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmGroupFile";
            this.Text = "新增用户组";
            this.Load += new System.EventHandler(this.FrmGroupFile_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.chensTabControl1.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private ChensControl.ChensTabControl chensTabControl1;
        private System.Windows.Forms.TabPage tpBasic;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensTextBox txtGroupNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensTextBox txtGroupName;
        private ChensControl.ChensLabel chensLabel3;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.BindingSource bsGroup;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtDescription;
        private ChensControl.ChensComboBox cbbUserGroupType;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensComboBox cbbUserGroupStatus;
        private ChensControl.ChensLabel chensLabel5;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
    }
}