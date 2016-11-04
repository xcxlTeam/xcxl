namespace WMS.Basic
{
    partial class FrmWarehouseFile
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
            this.txtAddress = new ChensControl.ChensTextBox();
            this.bsWarehouse = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.cbbWarehouseStatus = new ChensControl.ChensComboBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtDescription = new ChensControl.ChensTextBox();
            this.txtPhone = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtUsingQty = new ChensControl.ChensTextBox();
            this.txtQty = new ChensControl.ChensTextBox();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtPerson = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtWarehouseName = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.tcFile.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsWarehouse)).BeginInit();
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
            this.tpBasic.Controls.Add(this.txtAddress);
            this.tpBasic.Controls.Add(this.chensLabel10);
            this.tpBasic.Controls.Add(this.cbbWarehouseStatus);
            this.tpBasic.Controls.Add(this.chensLabel8);
            this.tpBasic.Controls.Add(this.txtDescription);
            this.tpBasic.Controls.Add(this.txtPhone);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtUsingQty);
            this.tpBasic.Controls.Add(this.txtQty);
            this.tpBasic.Controls.Add(this.txtWarehouseNo);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.chensLabel7);
            this.tpBasic.Controls.Add(this.chensLabel6);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.txtPerson);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtWarehouseName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(984, 411);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "仓库信息";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "Address", true));
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAddress.HotTrack = false;
            this.txtAddress.Location = new System.Drawing.Point(151, 163);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(755, 23);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.TextEnabled = false;
            // 
            // bsWarehouse
            // 
            this.bsWarehouse.DataSource = typeof(WMS.WebService.WarehouseInfo);
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(65, 165);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 136;
            this.chensLabel10.Text = "仓库地址";
            // 
            // cbbWarehouseStatus
            // 
            this.cbbWarehouseStatus.BackColor = System.Drawing.Color.White;
            this.cbbWarehouseStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbWarehouseStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsWarehouse, "WarehouseStatus", true));
            this.cbbWarehouseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWarehouseStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbWarehouseStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbWarehouseStatus.FormattingEnabled = true;
            this.cbbWarehouseStatus.HotTrack = false;
            this.cbbWarehouseStatus.Location = new System.Drawing.Point(151, 267);
            this.cbbWarehouseStatus.Name = "cbbWarehouseStatus";
            this.cbbWarehouseStatus.Size = new System.Drawing.Size(300, 25);
            this.cbbWarehouseStatus.TabIndex = 9;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(65, 270);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 135;
            this.chensLabel8.Text = "仓库状态";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "LocationDesc", true));
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDescription.HotTrack = false;
            this.txtDescription.Location = new System.Drawing.Point(151, 203);
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
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "ContactPhone", true));
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
            this.chensLabel2.Location = new System.Drawing.Point(65, 205);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 134;
            this.chensLabel2.Text = "仓库描述";
            // 
            // txtUsingQty
            // 
            this.txtUsingQty.BackColor = System.Drawing.Color.White;
            this.txtUsingQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUsingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsingQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "HouseUsingCount", true));
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
            this.txtQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "HouseCount", true));
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtQty.HotTrack = false;
            this.txtQty.Location = new System.Drawing.Point(151, 123);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(300, 23);
            this.txtQty.TabIndex = 5;
            this.txtQty.TextEnabled = false;
            // 
            // txtWarehouseNo
            // 
            this.txtWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "WarehouseNo", true));
            this.txtWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseNo.HotTrack = false;
            this.txtWarehouseNo.Location = new System.Drawing.Point(151, 43);
            this.txtWarehouseNo.Name = "txtWarehouseNo";
            this.txtWarehouseNo.Size = new System.Drawing.Size(300, 23);
            this.txtWarehouseNo.TabIndex = 1;
            this.txtWarehouseNo.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 2;
            this.chensLabel9.Text = "仓库编号";
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
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(520, 85);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 10;
            this.chensLabel7.Text = "联系电话";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(520, 125);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(68, 17);
            this.chensLabel6.TabIndex = 8;
            this.chensLabel6.Text = "库区使用数";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(65, 125);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 6;
            this.chensLabel5.Text = "库区总数";
            // 
            // txtPerson
            // 
            this.txtPerson.BackColor = System.Drawing.Color.White;
            this.txtPerson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "ContactUser", true));
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
            this.chensLabel4.TabIndex = 4;
            this.chensLabel4.Text = "联系人";
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.White;
            this.txtWarehouseName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWarehouse, "WarehouseName", true));
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseName.HotTrack = false;
            this.txtWarehouseName.Location = new System.Drawing.Point(606, 43);
            this.txtWarehouseName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(300, 23);
            this.txtWarehouseName.TabIndex = 2;
            this.txtWarehouseName.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(520, 45);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 2;
            this.chensLabel3.Text = "仓库名称";
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
            // FrmWarehouseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Name = "FrmWarehouseFile";
            this.Text = "新增仓库";
            this.Load += new System.EventHandler(this.FrmWarehouseFile_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tcFile.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsWarehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private ChensControl.ChensTabControl tcFile;
        private System.Windows.Forms.TabPage tpBasic;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtPerson;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtWarehouseName;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensTextBox txtUsingQty;
        private ChensControl.ChensTextBox txtQty;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtPhone;
        private System.Windows.Forms.BindingSource bsWarehouse;
        private ChensControl.ChensTextBox txtDescription;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensComboBox cbbWarehouseStatus;
        private ChensControl.ChensTextBox txtAddress;
        private ChensControl.ChensLabel chensLabel10;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
    }
}