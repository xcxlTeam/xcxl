using WMS.WebService;
using WMS.Print;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.ReportView
{
    public partial class FrmCensorshipPrinting : Common.FrmBasic
    {
        DeliveryReceive_Model _header;
        List<DeliveryReceiveDetail_Model> _detail;

        public FrmCensorshipPrinting()
        {
            InitializeComponent();
        }
        public FrmCensorshipPrinting(DeliveryReceive_Model drMain, List<DeliveryReceiveDetail_Model> lstDetail)
        {
            InitializeComponent();

            _header = drMain;
            _detail = lstDetail;
        }

        private void FrmInnerBarcodePrinting_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmCensorshipPrinting_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitForm()
        {
            InitReportData();
        }

        private void InitReportData()
        {
            try
            {
                bsHeader.DataSource = _header;
                bsDetail.DataSource = _detail;

                rvPrint.LocalReport.EnableExternalImages = true;
                rvPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CensorshipHeader", bsHeader));
                rvPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CensorshipDetail", bsDetail));

                rvPrint.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rvPrint_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            string strError = string.Empty;
            if (!Print_Func.PrintQuality(_header, ref strError))
            {
                MessageBox.Show(strError);
                e.Cancel = true;
                return;
            }
        }
    }
}
