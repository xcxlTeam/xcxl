using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Warehouse
{
    public partial class FrmTempTransQuery : Form
    {
        public FrmTempTransQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strErrMsg, cinvcode, cinvstd, ssocode, ssbvcode, dsocode, dsbvcode;
            List<WMS.WebService.SaleBillDetails_Model> list;
            if(txtCinvcode.Text.Trim().Equals(""))
            {
                cinvcode = null;
            }
            else
            {
                cinvcode = txtCinvcode.Text.Trim();
            }
            if (txtCinvstd.Text.Trim().Equals(""))
            {
                cinvstd = null;
            }
            else
            {
                cinvstd = txtCinvstd.Text.Trim();
            }
            if (txtSsocode.Text.Trim().Equals(""))
            {
                ssocode = null;
            }
            else
            {
                ssocode = txtSsocode.Text.Trim();
            }
            if (txtSsbvcode.Text.Trim().Equals(""))
            {
                ssbvcode = null;
            }
            else
            {
                ssbvcode = txtSsbvcode.Text.Trim();
            }
            if (txtDsocode.Text.Trim().Equals(""))
            {
                dsocode = null;
            }
            else
            {
                dsocode = txtDsocode.Text.Trim();
            }
            if (txtDsbvcode.Text.Trim().Equals(""))
            {
                dsbvcode = null;
            }
            else
            {
                dsbvcode = txtDsbvcode.Text.Trim();
            }
            if (WMS.Common.WMSWebService.service.QueryTempTrans(cinvcode, cinvstd, ssocode, ssbvcode, dsocode, dsbvcode, out list, out strErrMsg))
            {
                if (list != null && list.Count > 0)
                {
                    dataGridView1.DataSource = list;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (dataGridView1.Columns[i].Name.Equals("dsorowno"))
                        {
                            dataGridView1.Columns[i].HeaderText = "被借销售订单行号";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("dsocode"))
                        {
                            dataGridView1.Columns[i].HeaderText = "被借销售订单号";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("cinvcode"))
                        {
                            dataGridView1.Columns[i].HeaderText = "物料编码";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("cinvname"))
                        {
                            dataGridView1.Columns[i].HeaderText = "物料名称";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("cinvstd"))
                        {
                            dataGridView1.Columns[i].HeaderText = "规格型号";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("dsoqty"))
                        {
                            dataGridView1.Columns[i].HeaderText = "可被借数量";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("qty"))
                        {
                            dataGridView1.Columns[i].HeaderText = "借调数量";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("RealQty"))
                        {
                            dataGridView1.Columns[i].HeaderText = "实际借调数量";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("creater"))
                        {
                            dataGridView1.Columns[i].HeaderText = "借调人";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("createdate"))
                        {
                            dataGridView1.Columns[i].HeaderText = "生单日期";
                            continue;
                        }
                        if (dataGridView1.Columns[i].Name.Equals("verifydate"))
                        {
                            dataGridView1.Columns[i].HeaderText = "审核日期";
                            continue;
                        }
                        dataGridView1.Columns[i].Visible = false;
                    }
                    return;
                }
            }
            else
            {
                MessageBox.Show(strErrMsg);
            }
        }
    }
}
