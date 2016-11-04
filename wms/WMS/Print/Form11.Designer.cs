namespace WMS.Print
{
    partial class Form11
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
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.chensTextBox3 = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chensComboBox2 = new ChensControl.ChensComboBox();
            this.chensComboBox1 = new ChensControl.ChensComboBox();
            this.chensCheckBox2 = new ChensControl.ChensCheckBox();
            this.chensCheckBox1 = new ChensControl.ChensCheckBox();
            this.chensTextBox2 = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtPackQty = new ChensControl.ChensTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentSum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCount = new ChensControl.ChensTextBox();
            this.lblReserveUser = new ChensControl.ChensLabel();
            this.chensTextBox1 = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.btnGetMaterial = new ChensControl.ChensButton();
            this.txtSupCode = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtSupName = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtBatchNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.gbBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiPrint});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(992, 29);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(68, 21);
            this.tsmiImport.Text = "导入物料";
            this.tsmiImport.Visible = false;
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(80, 21);
            this.tsmiPrint.Text = "生成并打印";
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.chensTextBox3);
            this.gbBottom.Controls.Add(this.chensLabel9);
            this.gbBottom.Controls.Add(this.checkBox2);
            this.gbBottom.Controls.Add(this.chensComboBox2);
            this.gbBottom.Controls.Add(this.chensComboBox1);
            this.gbBottom.Controls.Add(this.chensCheckBox2);
            this.gbBottom.Controls.Add(this.chensCheckBox1);
            this.gbBottom.Controls.Add(this.chensTextBox2);
            this.gbBottom.Controls.Add(this.chensLabel7);
            this.gbBottom.Controls.Add(this.txtPackQty);
            this.gbBottom.Controls.Add(this.textBox1);
            this.gbBottom.Controls.Add(this.chensLabel5);
            this.gbBottom.Controls.Add(this.label1);
            this.gbBottom.Controls.Add(this.txtCurrentSum);
            this.gbBottom.Controls.Add(this.label11);
            this.gbBottom.Controls.Add(this.txtCount);
            this.gbBottom.Controls.Add(this.lblReserveUser);
            this.gbBottom.Controls.Add(this.chensTextBox1);
            this.gbBottom.Controls.Add(this.chensLabel8);
            this.gbBottom.Controls.Add(this.btnGetMaterial);
            this.gbBottom.Controls.Add(this.txtSupCode);
            this.gbBottom.Controls.Add(this.chensLabel1);
            this.gbBottom.Controls.Add(this.txtSupName);
            this.gbBottom.Controls.Add(this.chensLabel6);
            this.gbBottom.Controls.Add(this.txtBatchNo);
            this.gbBottom.Controls.Add(this.chensLabel4);
            this.gbBottom.Controls.Add(this.txtMaterialDesc);
            this.gbBottom.Controls.Add(this.chensLabel3);
            this.gbBottom.Controls.Add(this.txtMaterialNo);
            this.gbBottom.Controls.Add(this.chensLabel2);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 29);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(992, 743);
            this.gbBottom.TabIndex = 8;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "打印参数";
            // 
            // chensTextBox3
            // 
            this.chensTextBox3.BackColor = System.Drawing.Color.White;
            this.chensTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox3.Enabled = false;
            this.chensTextBox3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox3.HotTrack = false;
            this.chensTextBox3.Location = new System.Drawing.Point(99, 185);
            this.chensTextBox3.Name = "chensTextBox3";
            this.chensTextBox3.Size = new System.Drawing.Size(409, 23);
            this.chensTextBox3.TabIndex = 65;
            this.chensTextBox3.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(25, 187);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 64;
            this.chensLabel9.Text = "英文名称";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(445, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(51, 21);
            this.checkBox2.TabIndex = 63;
            this.checkBox2.Text = "称重";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chensComboBox2
            // 
            this.chensComboBox2.BackColor = System.Drawing.Color.White;
            this.chensComboBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chensComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensComboBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensComboBox2.FormattingEnabled = true;
            this.chensComboBox2.HotTrack = false;
            this.chensComboBox2.Location = new System.Drawing.Point(99, 371);
            this.chensComboBox2.Name = "chensComboBox2";
            this.chensComboBox2.Size = new System.Drawing.Size(112, 25);
            this.chensComboBox2.TabIndex = 62;
            // 
            // chensComboBox1
            // 
            this.chensComboBox1.BackColor = System.Drawing.Color.White;
            this.chensComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chensComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensComboBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensComboBox1.FormattingEnabled = true;
            this.chensComboBox1.HotTrack = false;
            this.chensComboBox1.Location = new System.Drawing.Point(99, 339);
            this.chensComboBox1.Name = "chensComboBox1";
            this.chensComboBox1.Size = new System.Drawing.Size(112, 25);
            this.chensComboBox1.TabIndex = 61;
            // 
            // chensCheckBox2
            // 
            this.chensCheckBox2.AutoSize = true;
            this.chensCheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensCheckBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensCheckBox2.Location = new System.Drawing.Point(45, 372);
            this.chensCheckBox2.Name = "chensCheckBox2";
            this.chensCheckBox2.Size = new System.Drawing.Size(48, 21);
            this.chensCheckBox2.TabIndex = 60;
            this.chensCheckBox2.Text = "包材";
            this.chensCheckBox2.Textn = "包材";
            this.chensCheckBox2.UseVisualStyleBackColor = true;
            // 
            // chensCheckBox1
            // 
            this.chensCheckBox1.AutoSize = true;
            this.chensCheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensCheckBox1.Location = new System.Drawing.Point(45, 340);
            this.chensCheckBox1.Name = "chensCheckBox1";
            this.chensCheckBox1.Size = new System.Drawing.Size(48, 21);
            this.chensCheckBox1.TabIndex = 59;
            this.chensCheckBox1.Text = "原料";
            this.chensCheckBox1.Textn = "原料";
            this.chensCheckBox1.UseVisualStyleBackColor = true;
            // 
            // chensTextBox2
            // 
            this.chensTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox2.HotTrack = false;
            this.chensTextBox2.Location = new System.Drawing.Point(358, 70);
            this.chensTextBox2.Name = "chensTextBox2";
            this.chensTextBox2.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox2.TabIndex = 58;
            this.chensTextBox2.TextEnabled = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(284, 72);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 57;
            this.chensLabel7.Text = "原厂批次";
            // 
            // txtPackQty
            // 
            this.txtPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPackQty.HotTrack = false;
            this.txtPackQty.Location = new System.Drawing.Point(99, 256);
            this.txtPackQty.Name = "txtPackQty";
            this.txtPackQty.Size = new System.Drawing.Size(150, 23);
            this.txtPackQty.TabIndex = 45;
            this.txtPackQty.TextEnabled = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 226);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 23);
            this.textBox1.TabIndex = 56;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(25, 262);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(32, 17);
            this.chensLabel5.TabIndex = 46;
            this.chensLabel5.Text = "净重";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "皮重";
            // 
            // txtCurrentSum
            // 
            this.txtCurrentSum.Location = new System.Drawing.Point(99, 223);
            this.txtCurrentSum.Name = "txtCurrentSum";
            this.txtCurrentSum.Size = new System.Drawing.Size(150, 23);
            this.txtCurrentSum.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 51;
            this.label11.Text = "本批数量";
            // 
            // txtCount
            // 
            this.txtCount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCount.HotTrack = false;
            this.txtCount.Location = new System.Drawing.Point(99, 295);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(150, 23);
            this.txtCount.TabIndex = 50;
            this.txtCount.TextEnabled = false;
            // 
            // lblReserveUser
            // 
            this.lblReserveUser.AutoSize = true;
            this.lblReserveUser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblReserveUser.Location = new System.Drawing.Point(25, 298);
            this.lblReserveUser.Name = "lblReserveUser";
            this.lblReserveUser.Size = new System.Drawing.Size(32, 17);
            this.lblReserveUser.TabIndex = 49;
            this.lblReserveUser.Text = "张数";
            // 
            // chensTextBox1
            // 
            this.chensTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox1.HotTrack = false;
            this.chensTextBox1.Location = new System.Drawing.Point(358, 262);
            this.chensTextBox1.Name = "chensTextBox1";
            this.chensTextBox1.Size = new System.Drawing.Size(138, 23);
            this.chensTextBox1.TabIndex = 47;
            this.chensTextBox1.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(284, 259);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 48;
            this.chensLabel8.Text = "打印份数";
            // 
            // btnGetMaterial
            // 
            this.btnGetMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnGetMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetMaterial.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnGetMaterial.ForeColor = System.Drawing.Color.White;
            this.btnGetMaterial.Location = new System.Drawing.Point(316, 17);
            this.btnGetMaterial.Name = "btnGetMaterial";
            this.btnGetMaterial.Size = new System.Drawing.Size(100, 30);
            this.btnGetMaterial.TabIndex = 25;
            this.btnGetMaterial.Text = "获取物料信息";
            this.btnGetMaterial.UseVisualStyleBackColor = false;
            // 
            // txtSupCode
            // 
            this.txtSupCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupCode.HotTrack = false;
            this.txtSupCode.Location = new System.Drawing.Point(99, 108);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(150, 23);
            this.txtSupCode.TabIndex = 7;
            this.txtSupCode.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 110);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(68, 17);
            this.chensLabel1.TabIndex = 17;
            this.chensLabel1.Text = "供应商代码";
            // 
            // txtSupName
            // 
            this.txtSupName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupName.HotTrack = false;
            this.txtSupName.Location = new System.Drawing.Point(358, 110);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(150, 23);
            this.txtSupName.TabIndex = 8;
            this.txtSupName.TextEnabled = false;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(284, 112);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(68, 17);
            this.chensLabel6.TabIndex = 9;
            this.chensLabel6.Text = "起始流水号";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBatchNo.HotTrack = false;
            this.txtBatchNo.Location = new System.Drawing.Point(99, 66);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(150, 23);
            this.txtBatchNo.TabIndex = 6;
            this.txtBatchNo.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 68);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(32, 17);
            this.chensLabel4.TabIndex = 5;
            this.chensLabel4.Text = "批号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.Enabled = false;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(99, 153);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(409, 23);
            this.txtMaterialDesc.TabIndex = 5;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 155);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 3;
            this.chensLabel3.Text = "中文名称";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.Enabled = false;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(99, 22);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 4;
            this.txtMaterialNo.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 23);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "物料编号";
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.msMain);
            this.Name = "Form11";
            this.Text = "Form11";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensButton btnGetMaterial;
        private ChensControl.ChensTextBox txtSupCode;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtSupName;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtBatchNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox chensTextBox2;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtPackQty;
        private System.Windows.Forms.TextBox textBox1;
        private ChensControl.ChensLabel chensLabel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentSum;
        private System.Windows.Forms.Label label11;
        private ChensControl.ChensTextBox txtCount;
        private ChensControl.ChensLabel lblReserveUser;
        private ChensControl.ChensTextBox chensTextBox1;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensComboBox chensComboBox2;
        private ChensControl.ChensComboBox chensComboBox1;
        private ChensControl.ChensCheckBox chensCheckBox2;
        private ChensControl.ChensCheckBox chensCheckBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private ChensControl.ChensTextBox chensTextBox3;
        private ChensControl.ChensLabel chensLabel9;
    }
}