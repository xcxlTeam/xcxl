namespace WMS.Basic
{
    partial class FrmHouseFile
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
            this.tcFile = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.cbbHouseStatus = new ChensControl.ChensComboBox();
            this.bsHouse = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtDescription = new ChensControl.ChensTextBox();
            this.txtPhone = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtUsingQty = new ChensControl.ChensTextBox();
            this.txtQty = new ChensControl.ChensTextBox();
            this.txtHouseNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtPerson = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtHouseName = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.tcFile.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsHouse)).BeginInit();
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
            this.tpBasic.Controls.Add(this.cbbHouseStatus);
            this.tpBasic.Controls.Add(this.chensLabel8);
            this.tpBasic.Controls.Add(this.txtDescription);
            this.tpBasic.Controls.Add(this.txtPhone);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtUsingQty);
            this.tpBasic.Controls.Add(this.txtQty);
            this.tpBasic.Controls.Add(this.txtHouseNo);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.chensLabel7);
            this.tpBasic.Controls.Add(this.chensLabel6);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.txtPerson);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtHouseName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(984, 411);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "库区信息";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // cbbHouseStatus
            // 
            this.cbbHouseStatus.BackColor = System.Drawing.Color.White;
            this.cbbHouseStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbHouseStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHouse, "HouseStatus", true));
            this.cbbHouseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHouseStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbHouseStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbHouseStatus.FormattingEnabled = true;
            this.cbbHouseStatus.HotTrack = false;
            this.cbbHouseStatus.Location = new System.Drawing.Point(151, 227);
            this.cbbHouseStatus.Name = "cbbHouseStatus";
            this.cbbHouseStatus.Size = new System.Drawing.Size(300, 25);
            this.cbbHouseStatus.TabIndex = 8;
            // 
            // bsHouse
            // 
            this.bsHouse.DataSource = typeof(WMS.WebService.HouseInfo);
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(65, 230);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 151;
            this.chensLabel8.Text = "库区状态";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "LocationDesc", true));
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDescription.HotTrack = false;
            this.txtDescription.Location = new System.Drawing.Point(151, 163);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(755, 50);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.TextEnabled = false;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "ContactPhone", true));
            this.txtPhone.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPhone.HotTrack = false;
            this.txtPhone.Location = new System.Drawing.Point(606, 83);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 23);
            this.txtPhone.TabIndex = 4;
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
            this.chensLabel2.Text = "库区描述";
            // 
            // txtUsingQty
            // 
            this.txtUsingQty.BackColor = System.Drawing.Color.White;
            this.txtUsingQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUsingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsingQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "AreaUsingCount", true));
            this.txtUsingQty.Enabled = false;
            this.txtUsingQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUsingQty.HotTrack = false;
            this.txtUsingQty.Location = new System.Drawing.Point(606, 123);
            this.txtUsingQty.Name = "txtUsingQty";
            this.txtUsingQty.Size = new System.Drawing.Size(300, 23);
            this.txtUsingQty.TabIndex = 6;
            this.txtUsingQty.TextEnabled = false;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "AreaCount", true));
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtQty.HotTrack = false;
            this.txtQty.Location = new System.Drawing.Point(151, 123);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(300, 23);
            this.txtQty.TabIndex = 5;
            this.txtQty.TextEnabled = false;
            // 
            // txtHouseNo
            // 
            this.txtHouseNo.BackColor = System.Drawing.Color.White;
            this.txtHouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "HouseNo", true));
            this.txtHouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtHouseNo.HotTrack = false;
            this.txtHouseNo.Location = new System.Drawing.Point(151, 43);
            this.txtHouseNo.Name = "txtHouseNo";
            this.txtHouseNo.Size = new System.Drawing.Size(300, 23);
            this.txtHouseNo.TabIndex = 1;
            this.txtHouseNo.TextEnabled = true;
            this.txtHouseNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHouseNo_KeyUp);
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 136;
            this.chensLabel9.Text = "库区编号";
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
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(520, 125);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(68, 17);
            this.chensLabel6.TabIndex = 143;
            this.chensLabel6.Text = "货位使用数";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(65, 125);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 141;
            this.chensLabel5.Text = "货位总数";
            // 
            // txtPerson
            // 
            this.txtPerson.BackColor = System.Drawing.Color.White;
            this.txtPerson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "ContactUser", true));
            this.txtPerson.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPerson.HotTrack = false;
            this.txtPerson.Location = new System.Drawing.Point(151, 83);
            this.txtPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(300, 23);
            this.txtPerson.TabIndex = 3;
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
            // txtHouseName
            // 
            this.txtHouseName.BackColor = System.Drawing.Color.White;
            this.txtHouseName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtHouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHouseName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHouse, "HouseName", true));
            this.txtHouseName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtHouseName.HotTrack = false;
            this.txtHouseName.Location = new System.Drawing.Point(606, 43);
            this.txtHouseName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHouseName.Name = "txtHouseName";
            this.txtHouseName.Size = new System.Drawing.Size(300, 23);
            this.txtHouseName.TabIndex = 2;
            this.txtHouseName.TextEnabled = true;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(520, 45);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 137;
            this.chensLabel3.Text = "库区名称";
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
            // FrmHouseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Name = "FrmHouseFile";
            this.Text = "新增库区";
            this.Load += new System.EventHandler(this.FrmHouseFile_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tcFile.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsHouse)).EndInit();
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
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtUsingQty;
        private ChensControl.ChensTextBox txtQty;
        private ChensControl.ChensTextBox txtHouseNo;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtPerson;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtHouseName;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtPhone;
        private ChensControl.ChensTextBox txtDescription;
        private System.Windows.Forms.BindingSource bsHouse;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensComboBox cbbHouseStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
    }
}