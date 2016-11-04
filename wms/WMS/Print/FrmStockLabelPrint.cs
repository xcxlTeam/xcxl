using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmStockLabelPrint : Form
    {
        int model;
        List<WebService.ProductLabel_Model> label_lst;
        public FrmStockLabelPrint()
        {
            InitializeComponent();
        }

        public FrmStockLabelPrint(int model, List<WebService.ProductLabel_Model> label_lst)
        {
            InitializeComponent();
            this.model = model;
            this.label_lst = label_lst;
        }

        private void FrmStockLabelPrint_Load(object sender, EventArgs e)
        {
            foreach (WebService.ProductLabel_Model labelModel in label_lst)
            {
                if (labelModel.outpackqty.Equals("1") || labelModel.outpackqty.Equals("0001"))
                {
                    labelModel.outpackqty = "";
                }
                //labelModel.smallQR = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.BarcodeExpress));
            }


            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", label_lst);
            if (model == 1)
            {
                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report6.rdlc";
            }

            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
