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
    public partial class FrmTempTrans : Form
    {
        WMS.WebService.SaleBillVouch_Model head;
        List<WMS.WebService.SaleBillDetails_Model> body;
        public FrmTempTrans()
        {
            InitializeComponent();
        }

        void InitTextBox(WMS.WebService.ArrayOfString list)
        {
            this.txtQueryWhereSoCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtQueryWhereSoCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (string str in list)
            {
                ac.Add(str);
            }
            this.txtQueryWhereSoCode.AutoCompleteCustomSource = ac;
            this.txtQueryWhereSoCode.Enabled = true;
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string strErrMsg;
                WMS.WebService.ArrayOfString list;
                if (WMS.Common.WMSWebService.service.GetSaleBillVouchCodeByCustomer(txtCustomer.Text, out list, out strErrMsg))
                {
                    InitTextBox(list);
                }
                else
                {
                    MessageBox.Show(strErrMsg);
                    txtCustomer.Text = "";
                    txtCustomer.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strErrMsg;
            if (WMS.Common.WMSWebService.service.GetSaleBillVouchByCode(txtQueryWhereSoCode.Text, out head, out strErrMsg))
            {
                dataGridView1.DataSource = head.details;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Name.Equals("ssbvcode"))
                    {
                        dataGridView1.Columns[i].HeaderText = "销售发票号";
                        continue;
                    }
                    if (dataGridView1.Columns[i].Name.Equals("ssorowno"))
                    {
                        dataGridView1.Columns[i].HeaderText = "销售订单行号";
                        continue;
                    }
                    if (dataGridView1.Columns[i].Name.Equals("ssbvrowno"))
                    {
                        dataGridView1.Columns[i].HeaderText = "销售发票行号";
                        continue;
                    }
                    if (dataGridView1.Columns[i].Name.Equals("ssocode"))
                    {
                        dataGridView1.Columns[i].HeaderText = "销售订单号";
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
                    if (dataGridView1.Columns[i].Name.Equals("ssoqty"))
                    {
                        dataGridView1.Columns[i].HeaderText = "销售订单数量";
                        continue;
                    }
                    if (dataGridView1.Columns[i].Name.Equals("ssbvqty"))
                    {
                        dataGridView1.Columns[i].HeaderText = "销售发票数量";
                        continue;
                    }
                    if (dataGridView1.Columns[i].Name.Equals("cWhName"))
                    {
                        dataGridView1.Columns[i].HeaderText = "仓库";
                        continue;
                    }
                    dataGridView1.Columns[i].Visible = false;
                }
            }
            else
            {
                MessageBox.Show(strErrMsg);
                txtQueryWhereSoCode.SelectAll();
                txtQueryWhereSoCode.Focus();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (head != null && dataGridView1.SelectedRows != null && dataGridView1.SelectedRows[0] != null && dataGridView1.SelectedRows[0].Index >= 0)
            {
                //先获取历史借调数据
                string strErrMsg;
                if(WMS.Common.WMSWebService.service.GetOldSaleBillVouch(head.details[dataGridView1.SelectedRows[0].Index], out body, out strErrMsg))
                {
                    if(body != null && body.Count > 0)
                    {
                        dataGridView2.DataSource = body;
                        for (int i = 0; i < dataGridView2.Columns.Count; i++)
                        {
                            if (dataGridView2.Columns[i].Name.Equals("dsorowno"))
                            {
                                dataGridView2.Columns[i].HeaderText = "被借销售订单行号";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("dsocode"))
                            {
                                dataGridView2.Columns[i].HeaderText = "被借销售订单号";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("cinvcode"))
                            {
                                dataGridView2.Columns[i].HeaderText = "物料编码";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("cinvname"))
                            {
                                dataGridView2.Columns[i].HeaderText = "物料名称";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("cinvstd"))
                            {
                                dataGridView2.Columns[i].HeaderText = "规格型号";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("dsoqty"))
                            {
                                dataGridView2.Columns[i].HeaderText = "可被借数量";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("qty"))
                            {
                                dataGridView2.Columns[i].HeaderText = "借调数量";
                                continue;
                            }
                            if (dataGridView2.Columns[i].Name.Equals("RealQty"))
                            {
                                dataGridView2.Columns[i].HeaderText = "实际借调数量";
                                continue;
                            }
                            dataGridView2.Columns[i].Visible = false;
                        }
                        return;
                    }
                }
                decimal detailqty;
                if(!decimal.TryParse(txtDetailQty.Text,out detailqty))
                {
                    MessageBox.Show("请先输入本次借调数量");
                    txtDetailQty.SelectAll();
                    txtDetailQty.Focus();
                    return;
                }
                head.details[dataGridView1.SelectedRows[0].Index].qty = detailqty;
                if(WMS.Common.WMSWebService.service.GetSaleBillDetailsForTrans(head.details[dataGridView1.SelectedRows[0].Index], out body, out strErrMsg))
                {
                    dataGridView2.DataSource = body;
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        if (dataGridView2.Columns[i].Name.Equals("dsorowno"))
                        {
                            dataGridView2.Columns[i].HeaderText = "被借销售订单行号";
                            continue;
                        }
                        if (dataGridView2.Columns[i].Name.Equals("dsocode"))
                        {
                            dataGridView2.Columns[i].HeaderText = "被借销售订单号";
                            continue;
                        }
                        if (dataGridView2.Columns[i].Name.Equals("cinvcode"))
                        {
                            dataGridView2.Columns[i].HeaderText = "物料编码";
                            continue;
                        }
                        if (dataGridView2.Columns[i].Name.Equals("cinvname"))
                        {
                            dataGridView2.Columns[i].HeaderText = "物料名称";
                            continue;
                        }
                        if (dataGridView2.Columns[i].Name.Equals("cinvstd"))
                        {
                            dataGridView2.Columns[i].HeaderText = "规格型号";
                            continue;
                        }
                        if (dataGridView2.Columns[i].Name.Equals("dsoqty"))
                        {
                            dataGridView2.Columns[i].HeaderText = "可被借数量";
                            continue;
                        }
                        dataGridView2.Columns[i].Visible = false;
                    }
                }
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (body != null && dataGridView2.SelectedRows != null && dataGridView2.SelectedRows[0] != null && dataGridView2.SelectedRows[0].Index >= 0)
            {
                if (body[dataGridView2.SelectedRows[0].Index].creater == null || body[dataGridView2.SelectedRows[0].Index].creater == "")
                {
                    button2.Enabled = true;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    dataGridView1_Click(null, null);
                }
                else
                {
                    button2.Enabled = false;
                    if(body[dataGridView2.SelectedRows[0].Index].verifydate != null && body[dataGridView2.SelectedRows[0].Index].verifydate != "")
                    {
                        button3.Enabled = false;
                        button4.Enabled = false;
                        if(body[dataGridView2.SelectedRows[0].Index].RealQty > 0)
                        {
                            button5.Enabled = false;
                        }
                        else
                        {
                            button5.Enabled = true;
                        }
                        dataGridView1_Click(null, null);
                    }
                    else
                    {
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = false;
                        dataGridView1_Click(null, null);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (body != null && dataGridView2.SelectedRows != null && dataGridView2.SelectedRows[0] != null && dataGridView2.SelectedRows[0].Index >= 0)
            {
                string strErrMsg;
                if (WMS.Common.WMSWebService.service.SaveTempTrans(Common.Common_Var.CurrentUser.UserName, body[dataGridView2.SelectedRows[0].Index], out strErrMsg))
                {
                    MessageBox.Show("保存成功");
                    body[dataGridView2.SelectedRows[0].Index].creater = Common.Common_Var.CurrentUser.UserName;
                    button2.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = false;
                    dataGridView1_Click(null, null);
                }
                else
                {
                    MessageBox.Show("保存失败:" + strErrMsg);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (body != null && dataGridView2.SelectedRows != null && dataGridView2.SelectedRows[0] != null && dataGridView2.SelectedRows[0].Index >= 0)
            {
                string strErrMsg;
                if (WMS.Common.WMSWebService.service.VerifyTempTrans(body[dataGridView2.SelectedRows[0].Index], out strErrMsg))
                {
                    MessageBox.Show("审核成功");
                    body[dataGridView2.SelectedRows[0].Index].verifydate = DateTime.Today.ToShortDateString();
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = true;
                    dataGridView1_Click(null, null);
                }
                else
                {
                    MessageBox.Show("审核失败:" + strErrMsg);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (body != null && dataGridView2.SelectedRows != null && dataGridView2.SelectedRows[0] != null && dataGridView2.SelectedRows[0].Index >= 0)
            {
                string strErrMsg;
                if (WMS.Common.WMSWebService.service.DelTempTrans(body[dataGridView2.SelectedRows[0].Index], out strErrMsg))
                {
                    MessageBox.Show("删除成功");
                    button2.Enabled = false;
                    button3.Enabled = false;
                    dataGridView1_Click(null, null);
                }
                else
                {
                    MessageBox.Show("删除失败:" + strErrMsg);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (body != null && dataGridView2.SelectedRows != null && dataGridView2.SelectedRows[0] != null && dataGridView2.SelectedRows[0].Index >= 0 && body[dataGridView2.SelectedRows[0].Index].RealQty == 0)
            {
                string strErrMsg;
                if (WMS.Common.WMSWebService.service.GiveUpTempTrans(body[dataGridView2.SelectedRows[0].Index], out strErrMsg))
                {
                    MessageBox.Show("弃审成功");
                    body[dataGridView2.SelectedRows[0].Index].verifydate = null;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    button5.Enabled = false;
                    dataGridView1_Click(null, null);
                }
                else
                {
                    MessageBox.Show("弃审失败:" + strErrMsg);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTempTransQuery frm = new FrmTempTransQuery();
            frm.ShowDialog();
        }
    }
}
