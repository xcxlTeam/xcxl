using WMS.WebService;
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
    public partial class FrmMaterialBarcodeReport : Form
    {
        List<WebService.BarcodeReport_Model> reportModel;
        List<WebService.BarcodeReport_RowDetail> RowDetails;
        public FrmMaterialBarcodeReport()
        {
            InitializeComponent();
        }

        private void FrmMaterialBarcodeReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string barcode = null, voucherno = null, Socode = null, ordercode = null, materialno = null, materialdesc = null, materialstd = null, strErrMsg = null;
            if(txtBarcode.Text.Trim().Length > 0)
            {
                barcode = txtBarcode.Text.Trim();
            }
            if (txtvoucherno.Text.Trim().Length > 0)
            {
                voucherno = txtvoucherno.Text.Trim();
            }
            if (txtSocode.Text.Trim().Length > 0)
            {
                Socode = txtSocode.Text.Trim();
            }
            if (txtCovenantcode.Text.Trim().Length > 0)
            {
                ordercode = txtCovenantcode.Text.Trim();
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

            if(!WMS.Common.WMSWebService.service.QueryMaterialBarcodeReport(barcode,voucherno,Socode,ordercode,null,materialno,materialdesc,materialstd,out reportModel,out strErrMsg))
            {
                MessageBox.Show("查询失败:" + strErrMsg);
                return;
            }
            dataGridView1.DataSource = reportModel;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name.Equals("voucherno"))
                {
                    dataGridView1.Columns[i].HeaderText = "采购订单";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("rowno"))
                {
                    dataGridView1.Columns[i].HeaderText = "采购订单行号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("SoCode"))
                {
                    dataGridView1.Columns[i].HeaderText = "到货号";
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
                    dataGridView1.Columns[i].HeaderText = "入库单号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("plantno"))
                {
                    dataGridView1.Columns[i].HeaderText = "出库单号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("batchno"))
                {
                    dataGridView1.Columns[i].HeaderText = "批次号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("outpackqty"))
                {
                    dataGridView1.Columns[i].HeaderText = "外箱包装量";
                    continue;
                }
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
                if (dataGridView1.Columns[i].Name.Equals("barcodeQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "已打印条码个数";
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "F2";
                    continue;
                }
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (reportModel != null && dataGridView1.SelectedRows.Count > 0)
            {
                string strErrMsg = string.Empty;
                if (!WMS.Common.WMSWebService.service.QueryBarcodeDetailsReportRowDetail(reportModel[dataGridView1.SelectedRows[0].Index], out RowDetails, out strErrMsg))
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
                chensLabel12.Text = "统计数量:" + RowDetails.Count.ToString();
                chensLabel13.Text = "统计数量:" + RowDetails.Count.ToString();
            }
        }

        private void chensButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //筛选
                if (RowDetails != null && RowDetails.Count > 0)
                {
                    if (txtLocBarcode.Text.Trim().Length > 0)//定位
                    {
                        foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                        {
                            dgvr.Selected = false;
                        }
                        foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                        {
                            if (dgvr.Cells["serialno"].Value.Equals(txtLocBarcode.Text.Trim().ToUpper()))
                            {
                                txtLocBarcode.Text = dgvr.Cells["serialno"].Value.ToString();
                                dgvr.Selected = true;
                                dataGridView2.CurrentCell = dgvr.Cells[0];
                                break;
                            }
                        }
                    }
                    List<WebService.BarcodeReport_RowDetail> QueryDetail;
                    if (cmbIFlag.SelectedItem != null)
                    {
                        QueryDetail = new List<BarcodeReport_RowDetail>();
                        foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                        {
                            if (dgvr.Cells["iFlag"].Value.Equals(cmbIFlag.SelectedItem.ToString()))
                            {
                                QueryDetail.Add(RowDetails[dgvr.Index]);
                            }
                        }

                        dataGridView2.DataSource = QueryDetail;
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
                        chensLabel12.Text = "统计数量:" + QueryDetail.Count.ToString();
                    }

                    if (txtLocAreano.Text.Length > 0)
                    {
                        if (cmbIFlag.SelectedItem != null)
                        {
                            QueryDetail = new List<BarcodeReport_RowDetail>();
                            foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                            {
                                if (dgvr.Cells["areano"].Value != null && dgvr.Cells["areano"].Value.ToString().Equals(txtLocAreano.Text) && dgvr.Cells["iFlag"].Value.Equals(cmbIFlag.SelectedItem.ToString()))
                                {
                                    QueryDetail.Add(RowDetails[dgvr.Index]);
                                }
                            }
                        }
                        else
                        {
                            QueryDetail = new List<BarcodeReport_RowDetail>();
                            foreach (DataGridViewRow dgvr in dataGridView2.Rows)
                            {
                                if (dgvr.Cells["areano"].Value != null && dgvr.Cells["areano"].Value.Equals(txtLocAreano.Text))
                                {
                                    QueryDetail.Add(RowDetails[dgvr.Index]);
                                }
                            }
                        }

                        dataGridView2.DataSource = QueryDetail;
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
                        chensLabel13.Text = "统计数量:" + QueryDetail.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
