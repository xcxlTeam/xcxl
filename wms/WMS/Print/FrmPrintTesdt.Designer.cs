namespace WMS.Print
{
    partial class FrmPrintTesdt
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
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.nbCheckedOffset = new ChensControl.ChensNumberBox();
            this.nbCheckedMargin = new ChensControl.ChensNumberBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.nbPictrueRightPad = new ChensControl.ChensNumberBox();
            this.nbPictrueTopPad = new ChensControl.ChensNumberBox();
            this.nbMinRowMargin = new ChensControl.ChensNumberBox();
            this.nbBasicRowHeigh = new ChensControl.ChensNumberBox();
            this.nbBaiscColMargin = new ChensControl.ChensNumberBox();
            this.nbBasicFontSize = new ChensControl.ChensNumberBox();
            this.txtBasicFontName = new ChensControl.ChensTextBox();
            this.nbHeigh = new ChensControl.ChensNumberBox();
            this.nbWidth = new ChensControl.ChensNumberBox();
            this.nbStartY = new ChensControl.ChensNumberBox();
            this.nbStartX = new ChensControl.ChensNumberBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbCheckedOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCheckedMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPictrueRightPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPictrueTopPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbMinRowMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbBasicRowHeigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbBaiscColMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbBasicFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbHeigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbStartX)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrint,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(44, 21);
            this.tsmiPrint.Text = "打印";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Visible = false;
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // nbCheckedOffset
            // 
            this.nbCheckedOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbCheckedOffset.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbCheckedOffset.Location = new System.Drawing.Point(404, 281);
            this.nbCheckedOffset.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbCheckedOffset.Name = "nbCheckedOffset";
            this.nbCheckedOffset.Size = new System.Drawing.Size(50, 23);
            this.nbCheckedOffset.TabIndex = 47;
            this.nbCheckedOffset.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nbCheckedMargin
            // 
            this.nbCheckedMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbCheckedMargin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbCheckedMargin.Location = new System.Drawing.Point(182, 281);
            this.nbCheckedMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbCheckedMargin.Name = "nbCheckedMargin";
            this.nbCheckedMargin.Size = new System.Drawing.Size(50, 23);
            this.nbCheckedMargin.TabIndex = 46;
            this.nbCheckedMargin.Value = new decimal(new int[] {
            115,
            0,
            0,
            0});
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(330, 283);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(56, 17);
            this.chensLabel11.TabIndex = 45;
            this.chensLabel11.Text = "勾选偏移";
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(108, 283);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(68, 17);
            this.chensLabel10.TabIndex = 44;
            this.chensLabel10.Text = "复选框间距";
            // 
            // nbPictrueRightPad
            // 
            this.nbPictrueRightPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbPictrueRightPad.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbPictrueRightPad.Location = new System.Drawing.Point(404, 213);
            this.nbPictrueRightPad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbPictrueRightPad.Name = "nbPictrueRightPad";
            this.nbPictrueRightPad.Size = new System.Drawing.Size(50, 23);
            this.nbPictrueRightPad.TabIndex = 43;
            this.nbPictrueRightPad.Value = new decimal(new int[] {
            280,
            0,
            0,
            0});
            // 
            // nbPictrueTopPad
            // 
            this.nbPictrueTopPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbPictrueTopPad.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbPictrueTopPad.Location = new System.Drawing.Point(182, 213);
            this.nbPictrueTopPad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbPictrueTopPad.Name = "nbPictrueTopPad";
            this.nbPictrueTopPad.Size = new System.Drawing.Size(50, 23);
            this.nbPictrueTopPad.TabIndex = 42;
            this.nbPictrueTopPad.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nbMinRowMargin
            // 
            this.nbMinRowMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbMinRowMargin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbMinRowMargin.Location = new System.Drawing.Point(614, 145);
            this.nbMinRowMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbMinRowMargin.Name = "nbMinRowMargin";
            this.nbMinRowMargin.Size = new System.Drawing.Size(50, 23);
            this.nbMinRowMargin.TabIndex = 41;
            this.nbMinRowMargin.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // nbBasicRowHeigh
            // 
            this.nbBasicRowHeigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbBasicRowHeigh.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbBasicRowHeigh.Location = new System.Drawing.Point(404, 145);
            this.nbBasicRowHeigh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbBasicRowHeigh.Name = "nbBasicRowHeigh";
            this.nbBasicRowHeigh.Size = new System.Drawing.Size(50, 23);
            this.nbBasicRowHeigh.TabIndex = 40;
            this.nbBasicRowHeigh.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // nbBaiscColMargin
            // 
            this.nbBaiscColMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbBaiscColMargin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbBaiscColMargin.Location = new System.Drawing.Point(182, 147);
            this.nbBaiscColMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbBaiscColMargin.Name = "nbBaiscColMargin";
            this.nbBaiscColMargin.Size = new System.Drawing.Size(50, 23);
            this.nbBaiscColMargin.TabIndex = 39;
            this.nbBaiscColMargin.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // nbBasicFontSize
            // 
            this.nbBasicFontSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbBasicFontSize.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbBasicFontSize.Location = new System.Drawing.Point(834, 77);
            this.nbBasicFontSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbBasicFontSize.Name = "nbBasicFontSize";
            this.nbBasicFontSize.Size = new System.Drawing.Size(50, 23);
            this.nbBasicFontSize.TabIndex = 38;
            this.nbBasicFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // txtBasicFontName
            // 
            this.txtBasicFontName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBasicFontName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasicFontName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBasicFontName.HotTrack = false;
            this.txtBasicFontName.Location = new System.Drawing.Point(614, 77);
            this.txtBasicFontName.Name = "txtBasicFontName";
            this.txtBasicFontName.Size = new System.Drawing.Size(100, 23);
            this.txtBasicFontName.TabIndex = 37;
            this.txtBasicFontName.Text = "黑体";
            this.txtBasicFontName.TextEnabled = false;
            // 
            // nbHeigh
            // 
            this.nbHeigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbHeigh.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbHeigh.Location = new System.Drawing.Point(461, 77);
            this.nbHeigh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbHeigh.Name = "nbHeigh";
            this.nbHeigh.Size = new System.Drawing.Size(50, 23);
            this.nbHeigh.TabIndex = 36;
            this.nbHeigh.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // nbWidth
            // 
            this.nbWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbWidth.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbWidth.Location = new System.Drawing.Point(404, 77);
            this.nbWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbWidth.Name = "nbWidth";
            this.nbWidth.Size = new System.Drawing.Size(50, 23);
            this.nbWidth.TabIndex = 35;
            this.nbWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // nbStartY
            // 
            this.nbStartY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbStartY.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbStartY.Location = new System.Drawing.Point(239, 77);
            this.nbStartY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbStartY.Name = "nbStartY";
            this.nbStartY.Size = new System.Drawing.Size(50, 23);
            this.nbStartY.TabIndex = 34;
            this.nbStartY.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // nbStartX
            // 
            this.nbStartX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nbStartX.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.nbStartX.Location = new System.Drawing.Point(182, 77);
            this.nbStartX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbStartX.Name = "nbStartX";
            this.nbStartX.Size = new System.Drawing.Size(50, 23);
            this.nbStartX.TabIndex = 33;
            this.nbStartX.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(330, 215);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(68, 17);
            this.chensLabel9.TabIndex = 32;
            this.chensLabel9.Text = "图片右间距";
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(108, 215);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(68, 17);
            this.chensLabel8.TabIndex = 31;
            this.chensLabel8.Text = "图片上间距";
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(552, 147);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 30;
            this.chensLabel7.Text = "最小行高";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(330, 147);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 29;
            this.chensLabel6.Text = "基准行高";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(108, 147);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(44, 17);
            this.chensLabel5.TabIndex = 28;
            this.chensLabel5.Text = "列间距";
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(772, 79);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 27;
            this.chensLabel4.Text = "基准字号";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(552, 79);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 26;
            this.chensLabel3.Text = "基准字体";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(330, 79);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 25;
            this.chensLabel2.Text = "纸张尺寸";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(108, 79);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 24;
            this.chensLabel1.Text = "起始位置";
            // 
            // FrmPrintTesdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 523);
            this.Controls.Add(this.nbCheckedOffset);
            this.Controls.Add(this.nbCheckedMargin);
            this.Controls.Add(this.chensLabel11);
            this.Controls.Add(this.chensLabel10);
            this.Controls.Add(this.nbPictrueRightPad);
            this.Controls.Add(this.nbPictrueTopPad);
            this.Controls.Add(this.nbMinRowMargin);
            this.Controls.Add(this.nbBasicRowHeigh);
            this.Controls.Add(this.nbBaiscColMargin);
            this.Controls.Add(this.nbBasicFontSize);
            this.Controls.Add(this.txtBasicFontName);
            this.Controls.Add(this.nbHeigh);
            this.Controls.Add(this.nbWidth);
            this.Controls.Add(this.nbStartY);
            this.Controls.Add(this.nbStartX);
            this.Controls.Add(this.chensLabel9);
            this.Controls.Add(this.chensLabel8);
            this.Controls.Add(this.chensLabel7);
            this.Controls.Add(this.chensLabel6);
            this.Controls.Add(this.chensLabel5);
            this.Controls.Add(this.chensLabel4);
            this.Controls.Add(this.chensLabel3);
            this.Controls.Add(this.chensLabel2);
            this.Controls.Add(this.chensLabel1);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmPrintTesdt";
            this.Text = "打印测试";
            this.Load += new System.EventHandler(this.FrmPrintTesdt_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbCheckedOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbCheckedMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPictrueRightPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPictrueTopPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbMinRowMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbBasicRowHeigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbBaiscColMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbBasicFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbHeigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbStartX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensNumberBox nbCheckedOffset;
        private ChensControl.ChensNumberBox nbCheckedMargin;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensNumberBox nbPictrueRightPad;
        private ChensControl.ChensNumberBox nbPictrueTopPad;
        private ChensControl.ChensNumberBox nbMinRowMargin;
        private ChensControl.ChensNumberBox nbBasicRowHeigh;
        private ChensControl.ChensNumberBox nbBaiscColMargin;
        private ChensControl.ChensNumberBox nbBasicFontSize;
        private ChensControl.ChensTextBox txtBasicFontName;
        private ChensControl.ChensNumberBox nbHeigh;
        private ChensControl.ChensNumberBox nbWidth;
        private ChensControl.ChensNumberBox nbStartY;
        private ChensControl.ChensNumberBox nbStartX;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
    }
}