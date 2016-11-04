namespace WMS.ReportView
{
    partial class FrmCensorshipPrinting
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bsHeader = new System.Windows.Forms.BindingSource(this.components);
            this.rvPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsDetail = new System.Windows.Forms.BindingSource(this.components);
            this.chensMenuStrip1 = new ChensControl.ChensMenuStrip();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bsHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).BeginInit();
            this.chensMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsHeader
            // 
            this.bsHeader.DataSource = typeof(WMS.WebService.DeliveryReceive_Model);
            // 
            // rvPrint
            // 
            this.rvPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bsHeader;
            this.rvPrint.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPrint.LocalReport.ReportEmbeddedResource = "JingXinWMS.ReportView.CensorshipRDLC.rdlc";
            this.rvPrint.Location = new System.Drawing.Point(0, 0);
            this.rvPrint.Name = "rvPrint";
            this.rvPrint.Size = new System.Drawing.Size(992, 523);
            this.rvPrint.TabIndex = 0;
            this.rvPrint.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            this.rvPrint.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvPrint_Print);
            // 
            // bsDetail
            // 
            this.bsDetail.DataSource = typeof(WMS.WebService.DeliveryReceiveDetail_Model);
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCancel});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(992, 25);
            this.chensMenuStrip1.TabIndex = 1;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            this.chensMenuStrip1.Visible = false;
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // FrmCensorshipPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 523);
            this.Controls.Add(this.rvPrint);
            this.Controls.Add(this.chensMenuStrip1);
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmCensorshipPrinting";
            this.Text = "送检单据打印";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCensorshipPrinting_FormClosed);
            this.Load += new System.EventHandler(this.FrmInnerBarcodePrinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).EndInit();
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPrint;
        private System.Windows.Forms.BindingSource bsHeader;
        private System.Windows.Forms.BindingSource bsDetail;
        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
    }
}