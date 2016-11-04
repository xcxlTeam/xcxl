namespace WMS.Print
{
    partial class FrmStockLabelPrint
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
            this.dSProductLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_ProductLabel = new WMS.Print.DS_ProductLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dSProductLabelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_ProductLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // dSProductLabelBindingSource
            // 
            this.dSProductLabelBindingSource.DataSource = this.dS_ProductLabel;
            this.dSProductLabelBindingSource.Position = 0;
            // 
            // dS_ProductLabel
            // 
            this.dS_ProductLabel.DataSetName = "DS_ProductLabel";
            this.dS_ProductLabel.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dSProductLabelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JingXinWMS.Print.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(592, 448);
            this.reportViewer1.TabIndex = 1;
            // 
            // FrmStockLabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 448);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmStockLabelPrint";
            this.Text = "库存标签打印";
            this.Load += new System.EventHandler(this.FrmStockLabelPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSProductLabelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_ProductLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dSProductLabelBindingSource;
        private DS_ProductLabel dS_ProductLabel;
    }
}