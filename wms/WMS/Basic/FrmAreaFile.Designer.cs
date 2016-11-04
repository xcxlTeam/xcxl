namespace WMS.Basic
{
    partial class FrmAreaFile
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
            this.txtAreaNoRight = new ChensControl.ChensTextBox();
            this.txtAreaNoLeft = new ChensControl.ChensTextBox();
            this.cbbAreaType = new ChensControl.ChensComboBox();
            this.bsArea = new System.Windows.Forms.BindingSource(this.components);
            this.cbbAreaStatus = new ChensControl.ChensComboBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtDescription = new ChensControl.ChensTextBox();
            this.txtPhone = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtAreaNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtPerson = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtAreaName = new ChensControl.ChensTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsArea)).BeginInit();
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
            this.tcFile.TabIndex = 4;
            this.tcFile.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.txtAreaNoRight);
            this.tpBasic.Controls.Add(this.txtAreaNoLeft);
            this.tpBasic.Controls.Add(this.cbbAreaType);
            this.tpBasic.Controls.Add(this.cbbAreaStatus);
            this.tpBasic.Controls.Add(this.chensLabel6);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.txtDescription);
            this.tpBasic.Controls.Add(this.txtPhone);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtAreaNo);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.chensLabel7);
            this.tpBasic.Controls.Add(this.txtPerson);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtAreaName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(984, 411);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "货位信息";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // txtAreaNoRight
            // 
            this.txtAreaNoRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaNoRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaNoRight.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaNoRight.HotTrack = false;
            this.txtAreaNoRight.Location = new System.Drawing.Point(251, 43);
            this.txtAreaNoRight.Name = "txtAreaNoRight";
            this.txtAreaNoRight.Size = new System.Drawing.Size(200, 23);
            this.txtAreaNoRight.TabIndex = 3;
            this.txtAreaNoRight.TextEnabled = false;
            this.txtAreaNoRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAreaNoRight_KeyUp);
            // 
            // txtAreaNoLeft
            // 
            this.txtAreaNoLeft.BackColor = System.Drawing.Color.White;
            this.txtAreaNoLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaNoLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaNoLeft.Enabled = false;
            this.txtAreaNoLeft.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaNoLeft.HotTrack = false;
            this.txtAreaNoLeft.Location = new System.Drawing.Point(151, 43);
            this.txtAreaNoLeft.Name = "txtAreaNoLeft";
            this.txtAreaNoLeft.Size = new System.Drawing.Size(100, 23);
            this.txtAreaNoLeft.TabIndex = 2;
            this.txtAreaNoLeft.TextEnabled = false;
            // 
            // cbbAreaType
            // 
            this.cbbAreaType.BackColor = System.Drawing.Color.White;
            this.cbbAreaType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbAreaType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsArea, "AreaType", true));
            this.cbbAreaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAreaType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbAreaType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbAreaType.FormattingEnabled = true;
            this.cbbAreaType.HotTrack = false;
            this.cbbAreaType.Location = new System.Drawing.Point(151, 122);
            this.cbbAreaType.Name = "cbbAreaType";
            this.cbbAreaType.Size = new System.Drawing.Size(300, 25);
            this.cbbAreaType.TabIndex = 7;
            // 
            // bsArea
            // 
            this.bsArea.DataSource = typeof(WMS.WebService.AreaInfo);
            // 
            // cbbAreaStatus
            // 
            this.cbbAreaStatus.BackColor = System.Drawing.Color.White;
            this.cbbAreaStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbAreaStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsArea, "AreaStatus", true));
            this.cbbAreaStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAreaStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbAreaStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbAreaStatus.FormattingEnabled = true;
            this.cbbAreaStatus.HotTrack = false;
            this.cbbAreaStatus.Location = new System.Drawing.Point(151, 227);
            this.cbbAreaStatus.Name = "cbbAreaStatus";
            this.cbbAreaStatus.Size = new System.Drawing.Size(300, 25);
            this.cbbAreaStatus.TabIndex = 9;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(65, 230);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 154;
            this.chensLabel6.Text = "货位状态";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(65, 125);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 153;
            this.chensLabel5.Text = "货位类型";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsArea, "LocationDesc", true));
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDescription.HotTrack = false;
            this.txtDescription.Location = new System.Drawing.Point(151, 163);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(755, 50);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.TextEnabled = false;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsArea, "ContactPhone", true));
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPhone.HotTrack = false;
            this.txtPhone.Location = new System.Drawing.Point(606, 83);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 23);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 165);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 150;
            this.chensLabel2.Text = "货位描述";
            // 
            // txtAreaNo
            // 
            this.txtAreaNo.BackColor = System.Drawing.Color.White;
            this.txtAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsArea, "AreaNo", true));
            this.txtAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaNo.HotTrack = false;
            this.txtAreaNo.Location = new System.Drawing.Point(151, 43);
            this.txtAreaNo.Name = "txtAreaNo";
            this.txtAreaNo.Size = new System.Drawing.Size(300, 23);
            this.txtAreaNo.TabIndex = 1;
            this.txtAreaNo.TextEnabled = false;
            this.txtAreaNo.Visible = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 136;
            this.chensLabel9.Text = "货位编号";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(912, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 17);
            this.label13.TabIndex = 145;
            this.label13.Text = "*";
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(520, 85);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 144;
            this.chensLabel7.Text = "联系电话";
            // 
            // txtPerson
            // 
            this.txtPerson.BackColor = System.Drawing.Color.White;
            this.txtPerson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsArea, "ContactUser", true));
            this.txtPerson.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPerson.HotTrack = false;
            this.txtPerson.Location = new System.Drawing.Point(151, 83);
            this.txtPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(300, 23);
            this.txtPerson.TabIndex = 5;
            this.txtPerson.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(65, 85);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(44, 17);
            this.chensLabel4.TabIndex = 139;
            this.chensLabel4.Text = "联系人";
            // 
            // txtAreaName
            // 
            this.txtAreaName.BackColor = System.Drawing.Color.White;
            this.txtAreaName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsArea, "AreaName", true));
            this.txtAreaName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaName.HotTrack = false;
            this.txtAreaName.Location = new System.Drawing.Point(606, 43);
            this.txtAreaName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(300, 23);
            this.txtAreaName.TabIndex = 4;
            this.txtAreaName.TextEnabled = false;
            this.txtAreaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAreaName_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(520, 45);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 137;
            this.chensLabel3.Text = "货位名称";
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
            // FrmAreaFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Name = "FrmAreaFile";
            this.Text = "新增货位";
            this.Load += new System.EventHandler(this.FrmAreaFile_Load);
            this.tcFile.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsArea)).EndInit();
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
        private ChensControl.ChensTextBox txtAreaNo;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtPerson;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtAreaName;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtPhone;
        private ChensControl.ChensTextBox txtDescription;
        private System.Windows.Forms.BindingSource bsArea;
        private ChensControl.ChensComboBox cbbAreaType;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensComboBox cbbAreaStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
        private ChensControl.ChensTextBox txtAreaNoRight;
        private ChensControl.ChensTextBox txtAreaNoLeft;
    }
}