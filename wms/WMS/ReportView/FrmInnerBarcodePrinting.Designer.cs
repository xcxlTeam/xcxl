﻿namespace WMS.ReportView
{
    partial class FrmInnerBarcodePrinting
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
            this.rvPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Barcode_ModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Barcode_ModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvPrint
            // 
            this.rvPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Barcode_ModelBindingSource;
            this.rvPrint.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPrint.LocalReport.ReportEmbeddedResource = "JingXinWMS.ReportView.InnerBarcodeRDLC.rdlc";
            this.rvPrint.Location = new System.Drawing.Point(0, 0);
            this.rvPrint.Name = "rvPrint";
            this.rvPrint.Size = new System.Drawing.Size(992, 523);
            this.rvPrint.TabIndex = 0;
            // 
            // Barcode_ModelBindingSource
            // 
            this.Barcode_ModelBindingSource.DataSource = typeof(WMS.WebService.Barcode_Model);
            // 
            // FrmInnerBarcodePrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 523);
            this.Controls.Add(this.rvPrint);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmInnerBarcodePrinting";
            this.Text = "内盒标签打印";
            this.Load += new System.EventHandler(this.FrmInnerBarcodePrinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Barcode_ModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPrint;
        private System.Windows.Forms.BindingSource Barcode_ModelBindingSource;
    }
}