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
    public partial class FrmProductLabelPrint : Form
    {
        List<WebService.ProductLabel_Model> label_lst;
        List<WebService.ProductLabel_Model> label_inner = null;
        List<WebService.ProductLabel_Model> label_outer = null;

        public FrmProductLabelPrint(List<WebService.ProductLabel_Model> label_lst, List<WebService.ProductLabel_Model> label_inner, List<WebService.ProductLabel_Model> label_outer)
        {
            InitializeComponent();
            this.label_lst = label_lst;
            this.label_inner = label_inner;
            this.label_outer = label_outer;
        }

        private void FrmProductLabelPrint_Load(object sender, EventArgs e)
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
            if (label_lst[0].prdversion != null && label_lst[0].prdversion != "")
            {
                if (label_lst[0].prdversion.Equals("0"))
                {
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report3.rdlc";
                }
                else if (label_lst[0].prdversion.Equals("1"))
                {
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report5.rdlc";
                }
                else
                {
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report5.rdlc";
                }
            }
            

            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if(label_inner == null)
            {
                if (!WMS.Common.WMSWebService.service.SaveInnerProductBarcodeForRead(label_outer, ref strErrMsg))//JingXinWMS.Common.WMSWebService.service.CreateInnerProductBarcode(label, Convert.ToInt16(txtBatchQty.Text), ref label_lst, ref strErrMsg)
                {
                    MessageBox.Show("保存失败:" + strErrMsg);
                    return;
                }
                else
                {
                    MessageBox.Show("保存成功");
                    Close();
                }
            }
            else
            {
                if (!WMS.Common.WMSWebService.service.SaveOuterProductBarcodeForRead(label_inner, label_outer, ref strErrMsg))//JingXinWMS.Common.WMSWebService.service.CreateInnerProductBarcode(label, Convert.ToInt16(txtBatchQty.Text), ref label_lst, ref strErrMsg)
                {
                    MessageBox.Show("保存失败:" + strErrMsg);
                    return;
                }
                else
                {
                    MessageBox.Show("保存成功");
                    Close();
                }
            }
        }
    }
}
