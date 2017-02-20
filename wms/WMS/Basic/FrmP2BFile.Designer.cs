namespace WMS.Basic
{
    partial class FrmP2BFile
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
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tcFile = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.txtDescription = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWarehouseName = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.cbbWarehouseStatus = new ChensControl.ChensComboBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.tcFile.SuspendLayout();
            this.tpBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiSaveAdd,
            this.tsmiSaveClose,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(810, 25);
            this.msMain.TabIndex = 3;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(44, 21);
            this.tsmiAdd.Text = "新增";
            this.tsmiAdd.Visible = false;
            // 
            // tsmiSaveAdd
            // 
            this.tsmiSaveAdd.Name = "tsmiSaveAdd";
            this.tsmiSaveAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiSaveAdd.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveAdd.Text = "保存并新增";
            // 
            // tsmiSaveClose
            // 
            this.tsmiSaveClose.Name = "tsmiSaveClose";
            this.tsmiSaveClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveClose.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveClose.Text = "保存并关闭";
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
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
            this.tcFile.Size = new System.Drawing.Size(810, 228);
            this.tcFile.TabIndex = 4;
            this.tcFile.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.cbbWarehouseStatus);
            this.tpBasic.Controls.Add(this.chensLabel8);
            this.tpBasic.Controls.Add(this.txtDescription);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtWarehouseNo);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.txtWarehouseName);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(802, 195);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "制法信息";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDescription.HotTrack = false;
            this.txtDescription.Location = new System.Drawing.Point(151, 92);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(630, 50);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 94);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 134;
            this.chensLabel2.Text = "制法描述";
            // 
            // txtWarehouseNo
            // 
            this.txtWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseNo.HotTrack = false;
            this.txtWarehouseNo.Location = new System.Drawing.Point(151, 43);
            this.txtWarehouseNo.Name = "txtWarehouseNo";
            this.txtWarehouseNo.Size = new System.Drawing.Size(243, 23);
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
            this.chensLabel9.Text = "制法编码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(400, 45);
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
            this.label13.Location = new System.Drawing.Point(787, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 17);
            this.label13.TabIndex = 129;
            this.label13.Text = "*";
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.BackColor = System.Drawing.Color.White;
            this.txtWarehouseName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarehouseName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWarehouseName.HotTrack = false;
            this.txtWarehouseName.Location = new System.Drawing.Point(481, 43);
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
            this.chensLabel3.Location = new System.Drawing.Point(419, 45);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 2;
            this.chensLabel3.Text = "制法名称";
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
            // cbbWarehouseStatus
            // 
            this.cbbWarehouseStatus.BackColor = System.Drawing.Color.White;
            this.cbbWarehouseStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbWarehouseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWarehouseStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbWarehouseStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbWarehouseStatus.FormattingEnabled = true;
            this.cbbWarehouseStatus.HotTrack = false;
            this.cbbWarehouseStatus.Location = new System.Drawing.Point(151, 156);
            this.cbbWarehouseStatus.Name = "cbbWarehouseStatus";
            this.cbbWarehouseStatus.Size = new System.Drawing.Size(262, 25);
            this.cbbWarehouseStatus.TabIndex = 9;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(65, 159);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 135;
            this.chensLabel8.Text = "所属建筑";
            // 
            // FrmP2BFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 253);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Name = "FrmP2BFile";
            this.Text = "新增制法";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tcFile.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensTabControl tcFile;
        private System.Windows.Forms.TabPage tpBasic;
        private ChensControl.ChensComboBox cbbWarehouseStatus;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensTextBox txtDescription;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtWarehouseNo;
        private ChensControl.ChensLabel chensLabel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensTextBox txtWarehouseName;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel1;
    }
}