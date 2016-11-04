using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Query
{
    public partial class FrmQueryStockSumByWHcode : Common.FrmBasic
    {
        public FrmQueryStockSumByWHcode()
        {
            InitializeComponent();
        }
        private void FrmQueryStockSumByWHcode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void FrmQueryStockSumByWHcode_Load(object sender, EventArgs e)
        {
            Common.Common_Func.SetSearchBtn(this, txtWarehouseNo, btnSearch, tsmiSearch);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtWarehouseNo.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请输入仓库编码");
                txtWarehouseNo.Focus();
                return;
            }
            string strErrMsg = null;
            List<WebService.Stock_Model> list = null;
            if(!WMS.Common.WMSWebService.service.QueryStockSumByWHcode(txtWarehouseNo.Text, out list, out strErrMsg))
            {
                MessageBox.Show("查询失败:" + strErrMsg);
                return;
            }
            dataGridView1.DataSource = list;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name.Equals("MaterialNo"))
                {
                    dataGridView1.Columns[i].HeaderText = "物料编码";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("MaterialDesc"))
                {
                    dataGridView1.Columns[i].HeaderText = "物料名称";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("MaterialStd"))
                {
                    dataGridView1.Columns[i].HeaderText = "规格型号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("Qty"))
                {
                    dataGridView1.Columns[i].HeaderText = "数量";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExportList();
        }

        private void ExportList()
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dataGridView1);
        }
    }
}
