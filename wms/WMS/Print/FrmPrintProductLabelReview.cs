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
    public partial class FrmPrintProductLabelReview : Common.FrmBasic
    {
        List<WebService.ProductLabel_Model> label_lst;
        public FrmPrintProductLabelReview()
        {
            InitializeComponent();
        }



        private void txtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tsmiPrint_Click(null, null);
            }
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            //WebService.ProductLabel_Model labelModel = null;
            //string strErrMsg = "";
            //string serialno = txtVoucherNo.Text.Trim();
            //if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtQty.Text))
            //{
            //    MessageBox.Show("数量必须是正整数");
            //    return;
            //}
            //if (JingXinWMS.Common.WMSWebService.service.RePrintByBarcode(serialno, Convert.ToInt16(txtQty.Text), ref label_lst, ref strErrMsg))
            //{
            //    reportViewer1.LocalReport.EnableExternalImages = true;
            //    reportViewer1.LocalReport.DataSources.Clear();
            //    reportViewer1.LocalReport.DataSources.Clear();
            //    foreach (WebService.ProductLabel_Model labelModel in label_lst)
            //    {
            //        labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.barcode));
            //    }
                
            //    ReportDataSource rds = new ReportDataSource("DataSet1", label_lst);

            //    reportViewer1.LocalReport.DataSources.Add(rds);

            //    reportViewer1.LocalReport.Refresh();
            //    this.reportViewer1.RefreshReport();
            //    this.reportViewer1.RefreshReport();
            //}
            //else
            //{
            //    MessageBox.Show(strErrMsg);
            //    label_lst = null;
            //}
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            string serialno = txtVoucherNo.Text.Trim();
            if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtQty.Text))
            {
                MessageBox.Show("数量必须是正整数");
                return;
            }
            if (WMS.Common.WMSWebService.service.RePrintByBarcode(chkOuter.Checked,serialno, Convert.ToInt16(txtQty.Text), ref label_lst, ref strErrMsg))
            {
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Clear();
                bool isDifferent = false;
                foreach (WebService.ProductLabel_Model labelModel in label_lst)
                {
                    if (labelModel.prdversion != null && labelModel.prdversion != "")
                    {
                        if (labelModel.prdversion.Equals("0"))
                        {
                            labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.barcode));
                            labelModel.smallQR = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.BarcodeExpress));
                        }
                        else if(labelModel.prdversion.Equals("1"))
                        {
                            labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.BarcodeExpress));
                        }
                        else
                        {
                            labelModel.smallQR = Print_Func.ConvertImageToString(new BarCode128().EncodeBarcode(labelModel.BarcodeExpress, 300, 50, false));//Print_Func.CreateQRCode(labelModel.BarcodeExpress)
                            labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(@"http://www.shimge-pump.com/?sn=" + labelModel.BarcodeExpress));
                        }
                    }
                    else
                    {
                        labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.barcode));
                    }
                    
                    //labelModel.smallQR = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.BarcodeExpress));
                    if (!isDifferent && label_lst[0].invstd.Equals(labelModel.invstd) && label_lst[0].ordercode.Equals(labelModel.ordercode))
                    {
                        isDifferent = false;
                    }
                    else
                    {
                        isDifferent = true;
                    }
                    if (labelModel.outpackqty.Equals("1") || labelModel.outpackqty.Equals("0001"))
                    {
                        labelModel.outpackqty = "";
                    }
                }
                if(isDifferent)
                {
                    txtcinvstd.Text = "";
                    txtcinvstd.Enabled = false;
                    txtOrderCode.Text = "";
                    txtOrderCode.Enabled = false;
                    //txtSupCode.Text = "";
                    //txtSupCode.Enabled = false;
                    MessageBox.Show("该批条码不是同一批次");
                }
                else
                {
                    txtcinvstd.Text = label_lst[0].invstd;
                    txtcinvstd.Enabled = true;
                    txtOrderCode.Text = label_lst[0].ordercode;
                    txtOrderCode.Enabled = true;
                    //txtSupCode.Text = label_lst[0].CUName;
                    //txtSupCode.Enabled = true;
                    //if(label_lst[0].Remark.Equals("内部使用"))
                    //{
                    //    chkRemark.Checked = true;
                    //}
                    //else
                    //{
                    //    chkRemark.Checked = false;
                    //}
                }
                ReportDataSource rds = new ReportDataSource("DataSet1", label_lst);

                reportViewer1.LocalReport.DataSources.Add(rds);
                if (label_lst[0].prdversion != null && label_lst[0].prdversion != "")
                {
                    if (label_lst[0].prdversion.Equals("0"))
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report3.rdlc";
                    }
                    else if (label_lst[0].prdversion.Equals("1"))
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report5.rdlc";
                    }
                    else
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report5.rdlc";
                    }
                    //reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report4.rdlc";
                }
                else
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report2.rdlc";
                }
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show(strErrMsg);
                label_lst = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtcinvstd.Enabled)
            {
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Clear();

                foreach (WebService.ProductLabel_Model labelModel in label_lst)
                {
                    labelModel.invstd = txtcinvstd.Text;
                    labelModel.ordercode = txtOrderCode.Text;
                    labelModel.smallQR = Print_Func.ConvertImageToString(new BarCode128().EncodeBarcode(labelModel.BarcodeExpress, 300, 50, false));//Print_Func.CreateQRCode(labelModel.BarcodeExpress)
                    if(labelModel.outpackqty.Equals(""))
                    {
                        labelModel.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@0001@" + labelModel.BarcodeExpress;
                    }
                    else
                    {
                        labelModel.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@" + Convert.ToInt16(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + labelModel.BarcodeExpress;
                    }
                    //labelModel.CUName = txtSupCode.Text;
                    //if (chkRemark.Checked)
                    //{
                    //    labelModel.Remark = "内部使用";
                    //}
                    //else
                    //{
                    //    labelModel.Remark = "";
                    //}
                    if (labelModel.prdversion != null && labelModel.prdversion != "")
                    {
                        if (labelModel.prdversion.Equals("0"))
                        {
                            labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.barcode));
                            labelModel.smallQR = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.BarcodeExpress));
                        }
                        else if (labelModel.prdversion.Equals("1"))
                        {
                            labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.BarcodeExpress));
                        }
                        else
                        {
                            labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(@"http://www.shimge-pump.com/?sn=" + labelModel.BarcodeExpress));
                        }
                    }
                    else
                    {
                        labelModel.qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(labelModel.barcode));
                    }
                }
                
                string strErrMsg = "";
                if (!WMS.Common.WMSWebService.service.RePrintChangeSave(label_lst, ref strErrMsg))
                {
                    MessageBox.Show(strErrMsg);
                }
                foreach (WebService.ProductLabel_Model labelModel in label_lst)
                {
                    if(labelModel.outpackqty.Equals("1") || labelModel.outpackqty.Equals("0001"))
                    {
                        labelModel.outpackqty = "";
                    }
                }
                ReportDataSource rds = new ReportDataSource("DataSet1", label_lst);

                reportViewer1.LocalReport.DataSources.Add(rds);
                if (label_lst[0].prdversion != null && label_lst[0].prdversion != "")
                {
                    if (label_lst[0].prdversion.Equals("0"))
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report3.rdlc";
                    }
                    else if (label_lst[0].prdversion.Equals("1"))
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report5.rdlc";
                    }
                    else
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report5.rdlc";
                    }
                    //reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report4.rdlc";
                }
                else
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = @"JingXinWMS.Print.Report2.rdlc";
                }
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtcinvstd.Enabled)
            {
                string strErrMsg = "";
                if (!WMS.Common.WMSWebService.service.PrintDelete(label_lst, ref strErrMsg))
                {
                    MessageBox.Show(strErrMsg);
                }
            }
        }
    }
}
