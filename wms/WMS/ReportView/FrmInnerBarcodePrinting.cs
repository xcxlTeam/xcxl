using WMS.WebService;
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
    public partial class FrmInnerBarcodePrinting : Common.FrmBasic
    {
        public FrmInnerBarcodePrinting(List<Barcode_Model> lstBarcode)
        {
            InitializeComponent();

            Barcode_ModelBindingSource.DataSource = lstBarcode;
        }

        private void FrmInnerBarcodePrinting_Load(object sender, EventArgs e)
        {
            rvPrint.LocalReport.EnableExternalImages = true;
            rvPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Barcode_ModelBindingSource));
            this.rvPrint.RefreshReport();
        }
    }
}
