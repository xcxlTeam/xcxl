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
    public partial class FrmBarcodeTrace : Form
    {
        List<WebService.BarcodeTrace_Model> reportModel;
        List<WebService.BarcodeReport_RowDetail> RowDetails;
        public FrmBarcodeTrace()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string barcode = null, voucherno = null, CusName = null, Socode = null, Covenantcode = null, materialno = null, materialdesc = null, materialstd = null, StockOutCode = null, TransMoveCode = null, strErrMsg = null;
            if (txtBarcode.Text.Trim().Length > 0)
            {
                barcode = txtBarcode.Text.Trim();
            }
            if (txtvoucherno.Text.Trim().Length > 0)
            {
                voucherno = txtvoucherno.Text.Trim();
            }
            if (txtCusName.Text.Trim().Length > 0)
            {
                CusName = txtCusName.Text.Trim();
            }
            if (txtSocode.Text.Trim().Length > 0)
            {
                Socode = txtSocode.Text.Trim();
            }
            if (txtCovenantcode.Text.Trim().Length > 0)
            {
                Covenantcode = txtCovenantcode.Text.Trim();
            }
            if (txtMaterialNo.Text.Trim().Length > 0)
            {
                materialno = txtMaterialNo.Text.Trim();
            }
            if (txtMaterialDesc.Text.Trim().Length > 0)
            {
                materialstd = txtMaterialDesc.Text.Trim();
            }
            if (txtMaterialStd.Text.Trim().Length > 0)
            {
                materialstd = txtMaterialStd.Text.Trim();
            }
            if (txtTransMoveCode.Text.Trim().Length > 0)
            {
                TransMoveCode = txtTransMoveCode.Text.Trim();
            }
            if (txtStockOutCode.Text.Trim().Length > 0)
            {
                StockOutCode = txtStockOutCode.Text.Trim();
            }
            if (!WMS.Common.WMSWebService.service.QueryBarcodeTraceReport(barcode, voucherno, CusName, Socode, Covenantcode, materialno, materialdesc, materialstd, StockOutCode, TransMoveCode, out reportModel, out strErrMsg))
            {
                MessageBox.Show("查询失败:" + strErrMsg);
                return;
            }
            dataGridView1.DataSource = reportModel;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name.Equals("voucherno"))
                {
                    dataGridView1.Columns[i].HeaderText = "生产订单";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("rowno"))
                {
                    dataGridView1.Columns[i].HeaderText = "生产订单行号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("SoCode"))
                {
                    dataGridView1.Columns[i].HeaderText = "销售订单号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("materialno"))
                {
                    dataGridView1.Columns[i].HeaderText = "物料编码";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("materialdesc"))
                {
                    dataGridView1.Columns[i].HeaderText = "物料名称";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("materialstd"))
                {
                    dataGridView1.Columns[i].HeaderText = "规格型号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("ordercode"))
                {
                    dataGridView1.Columns[i].HeaderText = "合同号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("plantno"))
                {
                    dataGridView1.Columns[i].HeaderText = "生产线";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("POdate"))
                {
                    dataGridView1.Columns[i].HeaderText = "生产日期";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("StockOutdate"))
                {
                    dataGridView1.Columns[i].HeaderText = "发货日期";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("CusName"))
                {
                    dataGridView1.Columns[i].HeaderText = "发货客户";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("TransMoveCode"))
                {
                    dataGridView1.Columns[i].HeaderText = "调拨单号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("TransMovecwhName"))
                {
                    dataGridView1.Columns[i].HeaderText = "调拨仓库(办事处)";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("StockOutCode"))
                {
                    dataGridView1.Columns[i].HeaderText = "销售发票单据号";
                    continue;
                }
                //if (dataGridView1.Columns[i].Name.Equals("batchno"))
                //{
                //    dataGridView1.Columns[i].HeaderText = "序列号";
                //    continue;
                //}
                //if (dataGridView1.Columns[i].Name.Equals("outpackqty"))
                //{
                //    dataGridView1.Columns[i].HeaderText = "外箱包装量";
                //    continue;
                //}
                if (dataGridView1.Columns[i].Name.Equals("voucherQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "生产订单数量";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("QualifiedInQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "累计入库数量";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("printQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "已打印数量";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("transmoveQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "调拨数量";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("stockoutQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "发货数量";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                //if (dataGridView1.Columns[i].Name.Equals("barcodeQty"))
                //{
                //    dataGridView1.Columns[i].HeaderText = "已打印条码个数";
                //    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                //    continue;
                //}
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void FrmBarcodeTrace_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (reportModel != null && dataGridView1.SelectedRows.Count > 0)
            {
                string strErrMsg = string.Empty;
                if (!WMS.Common.WMSWebService.service.QueryBarcodeTraceReportRowDetail(reportModel[dataGridView1.SelectedRows[0].Index], out RowDetails, out strErrMsg))
                {
                    MessageBox.Show("查询失败:" + strErrMsg);
                    return;
                }
                dataGridView2.DataSource = RowDetails;
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    if (dataGridView2.Columns[i].Name.Equals("innerouter"))
                    {
                        dataGridView2.Columns[i].HeaderText = "标签类型";
                        continue;
                    }
                    if (dataGridView2.Columns[i].Name.Equals("iFlag"))
                    {
                        dataGridView2.Columns[i].HeaderText = "标签状态";
                        continue;
                    }
                    if (dataGridView2.Columns[i].Name.Equals("serialno"))
                    {
                        dataGridView2.Columns[i].HeaderText = "条码短码";
                        continue;
                    }
                    if (dataGridView2.Columns[i].Name.Equals("areano"))
                    {
                        dataGridView2.Columns[i].HeaderText = "货位";
                        continue;
                    }
                    dataGridView2.Columns[i].Visible = false;
                }
                //chensLabel12.Text = "统计数量:" + RowDetails.Count.ToString();
                //chensLabel13.Text = "统计数量:" + RowDetails.Count.ToString();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
        e.RowBounds.Location.Y,
        dataGridView1.RowHeadersWidth - 4,
        e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
        e.RowBounds.Location.Y,
        dataGridView1.RowHeadersWidth - 4,
        e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView2.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView2.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
