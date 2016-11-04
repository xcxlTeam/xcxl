namespace WMS.Print
{
    partial class FrmPrinterSet
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
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.cbbOutDPI = new ChensControl.ChensComboBox();
            this.cbbInnerDPI = new ChensControl.ChensComboBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.nudOutPrinter = new System.Windows.Forms.NumericUpDown();
            this.nudInnerPrinter = new System.Windows.Forms.NumericUpDown();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtInnerPrinter = new ChensControl.ChensTextBox();
            this.txtOutPrinter = new ChensControl.ChensTextBox();
            this.lblInnerPrinter = new ChensControl.ChensLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblOutPrinter = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.tcFile = new ChensControl.ChensTabControl();
            this.msMain.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutPrinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInnerPrinter)).BeginInit();
            this.tcFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(570, 25);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(80, 21);
            this.tsmiSave.Text = "保存并关闭";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.cbbOutDPI);
            this.tpBasic.Controls.Add(this.cbbInnerDPI);
            this.tpBasic.Controls.Add(this.chensLabel7);
            this.tpBasic.Controls.Add(this.chensLabel6);
            this.tpBasic.Controls.Add(this.nudOutPrinter);
            this.tpBasic.Controls.Add(this.nudInnerPrinter);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtInnerPrinter);
            this.tpBasic.Controls.Add(this.txtOutPrinter);
            this.tpBasic.Controls.Add(this.lblInnerPrinter);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.lblOutPrinter);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpBasic.Size = new System.Drawing.Size(562, 331);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "打印机信息";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // cbbOutDPI
            // 
            this.cbbOutDPI.BackColor = System.Drawing.Color.White;
            this.cbbOutDPI.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbOutDPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOutDPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbOutDPI.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbOutDPI.FormattingEnabled = true;
            this.cbbOutDPI.HotTrack = false;
            this.cbbOutDPI.Location = new System.Drawing.Point(195, 162);
            this.cbbOutDPI.Name = "cbbOutDPI";
            this.cbbOutDPI.Size = new System.Drawing.Size(300, 25);
            this.cbbOutDPI.TabIndex = 4;
            // 
            // cbbInnerDPI
            // 
            this.cbbInnerDPI.BackColor = System.Drawing.Color.White;
            this.cbbInnerDPI.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbInnerDPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbInnerDPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbInnerDPI.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbInnerDPI.FormattingEnabled = true;
            this.cbbInnerDPI.HotTrack = false;
            this.cbbInnerDPI.Location = new System.Drawing.Point(195, 82);
            this.cbbInnerDPI.Name = "cbbInnerDPI";
            this.cbbInnerDPI.Size = new System.Drawing.Size(300, 25);
            this.cbbInnerDPI.TabIndex = 2;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(30, 165);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(159, 17);
            this.chensLabel7.TabIndex = 139;
            this.chensLabel7.Text = "【8㎝*6㎝】标签打印机点数";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(30, 85);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(159, 17);
            this.chensLabel6.TabIndex = 138;
            this.chensLabel6.Text = "【5㎝*3㎝】标签打印机点数";
            // 
            // nudOutPrinter
            // 
            this.nudOutPrinter.Location = new System.Drawing.Point(195, 278);
            this.nudOutPrinter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudOutPrinter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOutPrinter.Name = "nudOutPrinter";
            this.nudOutPrinter.Size = new System.Drawing.Size(300, 23);
            this.nudOutPrinter.TabIndex = 6;
            this.nudOutPrinter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudInnerPrinter
            // 
            this.nudInnerPrinter.Location = new System.Drawing.Point(195, 239);
            this.nudInnerPrinter.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudInnerPrinter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInnerPrinter.Name = "nudInnerPrinter";
            this.nudInnerPrinter.Size = new System.Drawing.Size(300, 23);
            this.nudInnerPrinter.TabIndex = 5;
            this.nudInnerPrinter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(30, 241);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(159, 17);
            this.chensLabel4.TabIndex = 134;
            this.chensLabel4.Text = "【5㎝*3㎝】标签单次打印数";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(30, 280);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(159, 17);
            this.chensLabel5.TabIndex = 135;
            this.chensLabel5.Text = "【8㎝*6㎝】标签单次打印数";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 205);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 133;
            this.chensLabel2.Text = "连打设置";
            // 
            // txtInnerPrinter
            // 
            this.txtInnerPrinter.BackColor = System.Drawing.Color.White;
            this.txtInnerPrinter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtInnerPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInnerPrinter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtInnerPrinter.HotTrack = false;
            this.txtInnerPrinter.Location = new System.Drawing.Point(195, 43);
            this.txtInnerPrinter.Name = "txtInnerPrinter";
            this.txtInnerPrinter.Size = new System.Drawing.Size(300, 23);
            this.txtInnerPrinter.TabIndex = 1;
            this.txtInnerPrinter.TextEnabled = false;
            // 
            // txtOutPrinter
            // 
            this.txtOutPrinter.BackColor = System.Drawing.Color.White;
            this.txtOutPrinter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOutPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutPrinter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOutPrinter.HotTrack = false;
            this.txtOutPrinter.Location = new System.Drawing.Point(195, 123);
            this.txtOutPrinter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOutPrinter.Name = "txtOutPrinter";
            this.txtOutPrinter.Size = new System.Drawing.Size(300, 23);
            this.txtOutPrinter.TabIndex = 3;
            this.txtOutPrinter.TextEnabled = false;
            // 
            // lblInnerPrinter
            // 
            this.lblInnerPrinter.AutoSize = true;
            this.lblInnerPrinter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblInnerPrinter.Location = new System.Drawing.Point(30, 45);
            this.lblInnerPrinter.Name = "lblInnerPrinter";
            this.lblInnerPrinter.Size = new System.Drawing.Size(159, 17);
            this.lblInnerPrinter.TabIndex = 2;
            this.lblInnerPrinter.Text = "【5㎝*3㎝】标签打印机名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(501, 49);
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
            this.label13.Location = new System.Drawing.Point(501, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 17);
            this.label13.TabIndex = 129;
            this.label13.Text = "*";
            // 
            // lblOutPrinter
            // 
            this.lblOutPrinter.AutoSize = true;
            this.lblOutPrinter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblOutPrinter.Location = new System.Drawing.Point(30, 125);
            this.lblOutPrinter.Name = "lblOutPrinter";
            this.lblOutPrinter.Size = new System.Drawing.Size(159, 17);
            this.lblOutPrinter.TabIndex = 2;
            this.lblOutPrinter.Text = "【8㎝*6㎝】标签打印机名称";
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
            this.tcFile.Size = new System.Drawing.Size(570, 364);
            this.tcFile.TabIndex = 3;
            this.tcFile.TabStop = false;
            // 
            // FrmPrinterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 389);
            this.Controls.Add(this.tcFile);
            this.Controls.Add(this.msMain);
            this.Name = "FrmPrinterSet";
            this.Text = "打印机设置";
            this.Load += new System.EventHandler(this.FrmPrinterSet_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutPrinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInnerPrinter)).EndInit();
            this.tcFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.TabPage tpBasic;
        private ChensControl.ChensTextBox txtInnerPrinter;
        private ChensControl.ChensTextBox txtOutPrinter;
        private ChensControl.ChensLabel lblInnerPrinter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private ChensControl.ChensLabel lblOutPrinter;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTabControl tcFile;
        private System.Windows.Forms.NumericUpDown nudOutPrinter;
        private System.Windows.Forms.NumericUpDown nudInnerPrinter;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensComboBox cbbOutDPI;
        private ChensControl.ChensComboBox cbbInnerDPI;
    }
}