using PrintLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WMS.Print
{
    public partial class FrmOMMaterialPrint : Form
    {
        List<WebService.MaterialLabel_Model> lst;
        WebService.MaterialLabel_Model currentDetail;
        public FrmOMMaterialPrint()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtVoucherNo.Text.Trim().Length <= 0 && txtcvenabbname.Text.Trim().Length <= 0 && dtpStartTime.Checked == false && dtpEndTime.Checked == false)
            //{
            //    MessageBox.Show("请输入查询条件");
            //    return;
            //}
            string strErrMsg = "";
            try
            {
                string StartTime = "";
                if (dtpStartTime.Checked)
                {
                    StartTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
                }
                string EndTime = "";
                if (dtpEndTime.Checked)
                {
                    EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
                }
                //lst = new List<WebService.MaterialLabel_Model>(WMS.Common.WMSWebService.service.GetOMLstForPrint(txtVoucherNo.Text, txtcvenabbname.Text, StartTime, EndTime, ref strErrMsg));
                if (lst != null && lst.Count > 0)
                {
                    bindingSource1.DataSource = lst;
                }
                else
                {
                    MessageBox.Show("获取委外订单数据失败");
                    //txtVoucherNo.SelectAll();
                    //txtVoucherNo.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lst != null && dgvList.SelectedCells.Count > 0)
            {
                txtMaterialNo.Text = lst[dgvList.SelectedCells[0].RowIndex].materialno;
                txtMaterialDesc.Text = lst[dgvList.SelectedCells[0].RowIndex].materialdesc;
                txtcinvstd.Text = lst[dgvList.SelectedCells[0].RowIndex].invstd;
                txtSupCode.Text = lst[dgvList.SelectedCells[0].RowIndex].cvencode; ;
                txtSupName.Text = lst[dgvList.SelectedCells[0].RowIndex].cvenabbname;
                txtCurrentSum.Text = lst[dgvList.SelectedCells[0].RowIndex].ImprintedQTY.ToString();
                txtPackQty.Text = lst[dgvList.SelectedCells[0].RowIndex].ImprintedQTY.ToString();
                txtCount.Text = "1";
                txtPrintQty.Text = "1";  //lst[dgvList.SelectedRows[0].Index].MoQuantity.ToString("F0");
                currentDetail = lst[dgvList.SelectedCells[0].RowIndex];
                string planto = "", strErrMsg = "";

            }
        }

        private void txtCurrentSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCurrentSum.Text))
                {
                    MessageBox.Show("本批数量必须是正整数");
                    return;
                }
                if (Convert.ToInt16(txtCurrentSum.Text) > (int)(currentDetail.ImprintedQTY * 1.05 + 0.5))
                {
                    MessageBox.Show("本批数量大于未打印数量");
                    return;
                }
            }
        }

        private void txtPackQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCurrentSum.Text))
                {
                    MessageBox.Show("本批数量必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCount.Text))
                {
                    MessageBox.Show("箱数必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtPackQty.Text))
                {
                    MessageBox.Show("包装量必须是正整数");
                    return;
                }
                if (Convert.ToInt16(txtPackQty.Text) > (int)(currentDetail.iquantity * 1.05 + 0.5))
                {
                    MessageBox.Show("包装量不得大于订单数量");
                    return;
                }
                //自动计算箱数和尾箱包装量
                if (Convert.ToInt16(txtCurrentSum.Text) > 0 && Convert.ToInt16(txtPackQty.Text) > 0)
                {
                    txtCount.Text = (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtPackQty.Text)) > 0 ? (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtPackQty.Text) + 1).ToString("F0") : (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtPackQty.Text)).ToString("F0");
                }
            }
        }

        private void txtEndPackQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCurrentSum.Text))
                {
                    MessageBox.Show("本批数量必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCount.Text))
                {
                    MessageBox.Show("箱数必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtPackQty.Text))
                {
                    MessageBox.Show("包装量必须是正整数");
                    return;
                }
            }
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCurrentSum.Text))
                {
                    MessageBox.Show("本批数量必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCount.Text))
                {
                    MessageBox.Show("箱数必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtPackQty.Text))
                {
                    MessageBox.Show("包装量必须是正整数");
                    return;
                }
                //自动计算包装量和尾箱包装量
                //if (Convert.ToInt16(txtCurrentSum.Text) > 0 && Convert.ToInt16(txtCount.Text) > 0)
                //{
                //    txtPackQty.Text = (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtCount.Text)).ToString("F0");
                //    txtEndPackQty.Text = (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtCount.Text)) == 0 ? (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtCount.Text)).ToString("F0") : (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtCount.Text)).ToString("F0");
                //}
            }
        }

        private void 采购原料标签打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDetail != null)
            {
                try
                {
                    string strErrMsg = "";
                    if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtPackQty.Text))
                    {
                        MessageBox.Show("包装量必须是正整数");
                        return;
                    }
                    if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCount.Text))
                    {
                        MessageBox.Show("箱数必须是正整数");
                        return;
                    }
                    if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtPrintQty.Text))
                    {
                        MessageBox.Show("打印份数必须是正整数");
                        return;
                    }
                    //验证数量
                    if (Convert.ToInt16(txtPackQty.Text) > (int)(currentDetail.iquantity * 1.05 + 0.5))
                    {
                        MessageBox.Show("包装量不得大于订单数量");
                        return;
                    }
                    if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCurrentSum.Text))
                    {
                        MessageBox.Show("本批数量必须是正整数");
                        return;
                    }
                    if (Convert.ToInt16(txtCurrentSum.Text) > currentDetail.ImprintedQTY)
                    {
                        if (MessageBox.Show("本批数量大于未打印数量,是否继续打印?", "确认", MessageBoxButtons.YesNo).Equals(DialogResult.No))
                        { return; }
                    }
                    WebService.MaterialLabel_Model label = new WebService.MaterialLabel_Model();
                    label.prdversion = "3";
                    label.cpoid = currentDetail.cpoid;
                    label.ivouchrowno = currentDetail.ivouchrowno;
                    label.labeltype = "00";

                    label.materialno = currentDetail.materialno;
                    label.materialdesc = currentDetail.materialdesc;
                    label.invstd = currentDetail.invstd;
                    label.cvencode = currentDetail.cvencode;
                    label.cvenabbname = currentDetail.cvenabbname;
                    List<WebService.MaterialLabel_Model> label_lst = null;
                    int printqty = Convert.ToInt16(txtPrintQty.Text);
                    int count = Convert.ToInt16(txtCount.Text);
                    for (int j = 0; j < printqty; j++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string printStr = "";
                            //将文本框中的内容按行转成图片
                            StringBuilder ReturnBarcodeCMD = new StringBuilder(10240);
                            RawPrinterHelper.GETFONTHEX("委外订单号：" + label_lst[i].cpoid, "宋体", "txt1", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            if (label_lst[i].cvenabbname.Length > 6)
                            {
                                RawPrinterHelper.GETFONTHEX("供应商：" + label_lst[i].cvenabbname.Substring(0, 6), "宋体", "txt2", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                                RawPrinterHelper.GETFONTHEX(label_lst[i].cvenabbname.Substring(6), "宋体", "txt3", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            else
                            {
                                RawPrinterHelper.GETFONTHEX("供应商：" + label_lst[i].cvenabbname, "宋体", "txt2", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            RawPrinterHelper.GETFONTHEX("物料编码：" + label_lst[i].materialno, "宋体", "txt4", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            if (label_lst[i].materialdesc.Length > 8)
                            {
                                RawPrinterHelper.GETFONTHEX("物料名称：" + label_lst[i].materialdesc.Substring(0, 8), "宋体", "txt5", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                                RawPrinterHelper.GETFONTHEX(label_lst[i].materialdesc.Substring(8), "宋体", "txt6", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            else
                            {
                                RawPrinterHelper.GETFONTHEX("物料名称：" + label_lst[i].materialdesc, "宋体", "txt5", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            if (label_lst[i].invstd.Length > 8)
                            {
                                RawPrinterHelper.GETFONTHEX("规格型号：" + label_lst[i].invstd.Substring(0, 8), "宋体", "txt7", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                                RawPrinterHelper.GETFONTHEX(label_lst[i].invstd.Substring(8), "宋体", "txt8", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            else
                            {
                                RawPrinterHelper.GETFONTHEX("规格型号：" + label_lst[i].invstd, "宋体", "txt7", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX("包装量：" + label_lst[i].outpackqty, "宋体", "txt10", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX("箱号:" + label_lst[i].Remark + " 行号:" + label_lst[i].ivouchrowno, "宋体", "txt11", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX(label_lst[i].BarcodeExpress, "宋体", "txt12", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            printStr += "^XA^MMT^PW559^LL0559^LS0";
                            printStr += "^FT160,66^XGtxt1,1,1^FS";
                            printStr += "^FT160,120^XGtxt2,1,1^FS";
                            if (label_lst[i].cvenabbname.Length > 6)
                            {
                                printStr += "^FT270,150^XGtxt3,1,1^FS";
                            }
                            printStr += "^FT32,226^XGtxt4,1,1^FS";
                            printStr += "^FT32,268^XGtxt5,1,1^FS";
                            if (label_lst[i].materialdesc.Length > 8)
                            {
                                printStr += "^FT165,296^XGtxt6,1,1^FS";
                            }
                            printStr += "^FT32,332^XGtxt7,1,1^FS";
                            if (label_lst[i].invstd.Length > 8)
                            {
                                printStr += "^FT165,360^XGtxt8,1,1^FS";
                            }
                            printStr += "^FT32,400^XGtxt9,1,1^FS";
                            printStr += "^FT32,462^XGtxt10,1,1^FS";
                            printStr += "^FT32,522^XGtxt11,1,1^FS";
                            printStr += "^FT350,522^XGtxt12,1,1^FS";
                            printStr += "^FO10,10^GB530,530,4^FS";
                            printStr += "^FO10,170^GB530,0,4^FS";
                            printStr += "^FT45,167^BQN,2,5";
                            printStr += "^FDMA," + label_lst[i].cpoid + "^FS";
                            printStr += "^FT400,500^BQN,2,4";
                            printStr += "^FDMA," + label_lst[i].barcode + "^FS";
                            printStr += "^PQ1,0,1,Y^XZ";
                            printStr += "^XA^IDtxt1^FS^XZ";
                            printStr += "^XA^IDtxt2^FS^XZ";
                            if (label_lst[i].cvenabbname.Length > 6)
                            {
                                printStr += "^XA^IDtxt3^FS^XZ";
                            }
                            printStr += "^XA^IDtxt4^FS^XZ";
                            printStr += "^XA^IDtxt5^FS^XZ";
                            if (label_lst[i].materialdesc.Length > 8)
                            {
                                printStr += "^XA^IDtxt6^FS^XZ";
                            }
                            printStr += "^XA^IDtxt7^FS^XZ";
                            if (label_lst[i].invstd.Length > 8)
                            {
                                printStr += "^XA^IDtxt8^FS^XZ";
                            }
                            printStr += "^XA^IDtxt9^FS^XZ";
                            printStr += "^XA^IDtxt10^FS^XZ";
                            printStr += "^XA^IDtxt11^FS^XZ";
                            printStr += "^XA^IDtxt12^FS^XZ";
                            string xPath = "/configuration/appSettings//add[@key='Printer']";
                            XmlDocument doc = new XmlDocument();
                            string exeFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                            doc.Load(exeFileName + ".exe.config");
                            XmlNode node = doc.SelectSingleNode(xPath);
                            RawPrinterHelper.SendStringToPrinter(node.Attributes["value"].Value.ToString(), printStr);
                            System.Threading.Thread.Sleep(1000);
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
}
