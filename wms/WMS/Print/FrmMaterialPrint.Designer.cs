namespace WMS.Print
{
    partial class FrmMaterialPrint
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
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.btnGetMaterial = new ChensControl.ChensButton();
            this.txtSupCode = new ChensControl.ChensTextBox();
            this.bsCreate = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtPrintQty = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.cbxOther = new ChensControl.ChensCheckBox();
            this.cbxPlatedTin = new ChensControl.ChensCheckBox();
            this.cbxPlatedSilver = new ChensControl.ChensCheckBox();
            this.txtSupName = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtOutPackQty = new ChensControl.ChensTextBox();
            this.lblInnerPackQty = new ChensControl.ChensLabel();
            this.txtBatchNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreate)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiPrint,
            this.tsmiChangePrinter});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(13, 6, 0, 6);
            this.msMain.Size = new System.Drawing.Size(943, 40);
            this.msMain.TabIndex = 5;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(94, 28);
            this.tsmiImport.Text = "导入物料";
            this.tsmiImport.Visible = false;
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(112, 28);
            this.tsmiPrint.Text = "生成并打印";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiChangePrinter
            // 
            this.tsmiChangePrinter.Name = "tsmiChangePrinter";
            this.tsmiChangePrinter.Size = new System.Drawing.Size(112, 28);
            this.tsmiChangePrinter.Text = "设置打印机";
            this.tsmiChangePrinter.Click += new System.EventHandler(this.tsmiChangePrinter_Click);
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.btnGetMaterial);
            this.gbBottom.Controls.Add(this.txtSupCode);
            this.gbBottom.Controls.Add(this.chensLabel1);
            this.gbBottom.Controls.Add(this.txtPrintQty);
            this.gbBottom.Controls.Add(this.chensLabel7);
            this.gbBottom.Controls.Add(this.cbxOther);
            this.gbBottom.Controls.Add(this.cbxPlatedTin);
            this.gbBottom.Controls.Add(this.cbxPlatedSilver);
            this.gbBottom.Controls.Add(this.txtSupName);
            this.gbBottom.Controls.Add(this.chensLabel6);
            this.gbBottom.Controls.Add(this.txtOutPackQty);
            this.gbBottom.Controls.Add(this.lblInnerPackQty);
            this.gbBottom.Controls.Add(this.txtBatchNo);
            this.gbBottom.Controls.Add(this.chensLabel4);
            this.gbBottom.Controls.Add(this.txtMaterialDesc);
            this.gbBottom.Controls.Add(this.chensLabel3);
            this.gbBottom.Controls.Add(this.txtMaterialNo);
            this.gbBottom.Controls.Add(this.chensLabel2);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 40);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbBottom.Size = new System.Drawing.Size(943, 666);
            this.gbBottom.TabIndex = 7;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "打印参数";
            // 
            // btnGetMaterial
            // 
            this.btnGetMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnGetMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetMaterial.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnGetMaterial.ForeColor = System.Drawing.Color.White;
            this.btnGetMaterial.Location = new System.Drawing.Point(685, 41);
            this.btnGetMaterial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnGetMaterial.Name = "btnGetMaterial";
            this.btnGetMaterial.Size = new System.Drawing.Size(157, 42);
            this.btnGetMaterial.TabIndex = 25;
            this.btnGetMaterial.Text = "获取物料信息";
            this.btnGetMaterial.UseVisualStyleBackColor = false;
            this.btnGetMaterial.Click += new System.EventHandler(this.btnGetMaterial_Click);
            // 
            // txtSupCode
            // 
            this.txtSupCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "SUPCODE", true));
            this.txtSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupCode.HotTrack = false;
            this.txtSupCode.Location = new System.Drawing.Point(344, 275);
            this.txtSupCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(313, 31);
            this.txtSupCode.TabIndex = 7;
            this.txtSupCode.TextEnabled = false;
            // 
            // bsCreate
            // 
            this.bsCreate.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(228, 278);
            this.chensLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(100, 24);
            this.chensLabel1.TabIndex = 17;
            this.chensLabel1.Text = "供应商代码";
            // 
            // txtPrintQty
            // 
            this.txtPrintQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPrintQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrintQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "PRINTQTY", true));
            this.txtPrintQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPrintQty.HotTrack = false;
            this.txtPrintQty.Location = new System.Drawing.Point(344, 589);
            this.txtPrintQty.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPrintQty.Name = "txtPrintQty";
            this.txtPrintQty.Size = new System.Drawing.Size(313, 31);
            this.txtPrintQty.TabIndex = 13;
            this.txtPrintQty.TextEnabled = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(228, 589);
            this.chensLabel7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(82, 24);
            this.chensLabel7.TabIndex = 15;
            this.chensLabel7.Text = "打印份数";
            // 
            // cbxOther
            // 
            this.cbxOther.AutoSize = true;
            this.cbxOther.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedOther", true));
            this.cbxOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxOther.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxOther.Location = new System.Drawing.Point(534, 508);
            this.cbxOther.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxOther.Name = "cbxOther";
            this.cbxOther.Size = new System.Drawing.Size(67, 28);
            this.cbxOther.TabIndex = 12;
            this.cbxOther.Text = "其他";
            this.cbxOther.Textn = "其他";
            this.cbxOther.UseVisualStyleBackColor = true;
            this.cbxOther.CheckedChanged += new System.EventHandler(this.cbxOther_CheckedChanged);
            // 
            // cbxPlatedTin
            // 
            this.cbxPlatedTin.AutoSize = true;
            this.cbxPlatedTin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedTin", true));
            this.cbxPlatedTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlatedTin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxPlatedTin.Location = new System.Drawing.Point(409, 508);
            this.cbxPlatedTin.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxPlatedTin.Name = "cbxPlatedTin";
            this.cbxPlatedTin.Size = new System.Drawing.Size(67, 28);
            this.cbxPlatedTin.TabIndex = 11;
            this.cbxPlatedTin.Text = "镀锡";
            this.cbxPlatedTin.Textn = "镀锡";
            this.cbxPlatedTin.UseVisualStyleBackColor = true;
            this.cbxPlatedTin.CheckedChanged += new System.EventHandler(this.cbxPlatedTin_CheckedChanged);
            // 
            // cbxPlatedSilver
            // 
            this.cbxPlatedSilver.AutoSize = true;
            this.cbxPlatedSilver.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCreate, "BPlatedSilver", true));
            this.cbxPlatedSilver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlatedSilver.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbxPlatedSilver.Location = new System.Drawing.Point(283, 508);
            this.cbxPlatedSilver.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxPlatedSilver.Name = "cbxPlatedSilver";
            this.cbxPlatedSilver.Size = new System.Drawing.Size(67, 28);
            this.cbxPlatedSilver.TabIndex = 10;
            this.cbxPlatedSilver.Text = "镀银";
            this.cbxPlatedSilver.Textn = "镀银";
            this.cbxPlatedSilver.UseVisualStyleBackColor = true;
            this.cbxPlatedSilver.CheckedChanged += new System.EventHandler(this.cbxPlatedSilver_CheckedChanged);
            // 
            // txtSupName
            // 
            this.txtSupName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "SUPNAME", true));
            this.txtSupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupName.HotTrack = false;
            this.txtSupName.Location = new System.Drawing.Point(344, 352);
            this.txtSupName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(313, 31);
            this.txtSupName.TabIndex = 8;
            this.txtSupName.TextEnabled = false;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(228, 354);
            this.chensLabel6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(100, 24);
            this.chensLabel6.TabIndex = 9;
            this.chensLabel6.Text = "供应商名称";
            // 
            // txtOutPackQty
            // 
            this.txtOutPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOutPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutPackQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "OUTPACKQTY", true));
            this.txtOutPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOutPackQty.HotTrack = false;
            this.txtOutPackQty.Location = new System.Drawing.Point(344, 428);
            this.txtOutPackQty.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtOutPackQty.Name = "txtOutPackQty";
            this.txtOutPackQty.Size = new System.Drawing.Size(313, 31);
            this.txtOutPackQty.TabIndex = 9;
            this.txtOutPackQty.TextEnabled = false;
            // 
            // lblInnerPackQty
            // 
            this.lblInnerPackQty.AutoSize = true;
            this.lblInnerPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblInnerPackQty.Location = new System.Drawing.Point(228, 431);
            this.lblInnerPackQty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInnerPackQty.Name = "lblInnerPackQty";
            this.lblInnerPackQty.Size = new System.Drawing.Size(100, 24);
            this.lblInnerPackQty.TabIndex = 7;
            this.lblInnerPackQty.Text = "外箱包装量";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "BATCHNO", true));
            this.txtBatchNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBatchNo.HotTrack = false;
            this.txtBatchNo.Location = new System.Drawing.Point(344, 199);
            this.txtBatchNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(313, 31);
            this.txtBatchNo.TabIndex = 6;
            this.txtBatchNo.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(228, 202);
            this.chensLabel4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(82, 24);
            this.chensLabel4.TabIndex = 5;
            this.chensLabel4.Text = "生产批号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "MATERIALDESC", true));
            this.txtMaterialDesc.Enabled = false;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(344, 123);
            this.txtMaterialDesc.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(313, 31);
            this.txtMaterialDesc.TabIndex = 5;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(228, 126);
            this.chensLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(82, 24);
            this.chensLabel3.TabIndex = 3;
            this.chensLabel3.Text = "物料描述";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreate, "MATERIALNO", true));
            this.txtMaterialNo.Enabled = false;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(344, 48);
            this.txtMaterialNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(313, 31);
            this.txtMaterialNo.TabIndex = 4;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialNo_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(228, 49);
            this.chensLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(82, 24);
            this.chensLabel2.TabIndex = 1;
            this.chensLabel2.Text = "物料编号";
            // 
            // FrmMaterialPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 706);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FrmMaterialPrint";
            this.Text = "物料标签打印";
            this.Load += new System.EventHandler(this.FrmMaterialPrint_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrinter;
        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensTextBox txtSupCode;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtPrintQty;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensCheckBox cbxOther;
        private ChensControl.ChensCheckBox cbxPlatedTin;
        private ChensControl.ChensCheckBox cbxPlatedSilver;
        private ChensControl.ChensTextBox txtSupName;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtOutPackQty;
        private ChensControl.ChensLabel lblInnerPackQty;
        private ChensControl.ChensTextBox txtBatchNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel2;
        private System.Windows.Forms.BindingSource bsCreate;
        private ChensControl.ChensButton btnGetMaterial;
    }
}