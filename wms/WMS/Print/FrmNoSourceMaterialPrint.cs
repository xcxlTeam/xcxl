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
    public partial class FrmNoSourceMaterialPrint : Form
    {
        WebService.MaterialLabel_Model currentDetail;
        WebService.Vendor vendor;
        public FrmNoSourceMaterialPrint()
        {
            InitializeComponent();
        }
        void GetMaterialLabelInfo()
        {
            string strErrMsg = "";
            try
            {
                if (txtMaterialNo.Text.Trim().Length == 0 && txtMaterialDesc.Text.Trim().Length == 0 && txtcinvstd.Text.Trim().Length == 0)
                {
                    MessageBox.Show("请输入物料信息后按回车获取数据");
                    return;
                }
                currentDetail = null;
                if (!WMS.Common.WMSWebService.service.GetMaterialLabelInfo(txtMaterialNo.Text, txtMaterialDesc.Text, txtcinvstd.Text, ref currentDetail, ref strErrMsg))
                {
                    MessageBox.Show("获取物料数据失败");
                    return;
                }
                if(currentDetail == null)
                {
                    MessageBox.Show("获取物料数据失败");
                    return;
                }
                txtMaterialNo.Text = currentDetail.materialno;
                txtMaterialDesc.Text = currentDetail.materialdesc;
                txtcinvstd.Text = currentDetail.invstd;
                txtCurrentSum.Text = "1";
                txtPackQty.Text = "1";
                txtEndPackQty.Text = "1";
                txtCount.Text = "1";
                txtPrintQty.Text = "1";
                txtMaterialNo.ReadOnly = true;
                txtMaterialDesc.ReadOnly = true;
                txtcinvstd.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            currentDetail = null;
            txtMaterialNo.Text = "";
            txtMaterialDesc.Text = "";
            txtcinvstd.Text = "";
            txtCurrentSum.Text = "";
            txtPackQty.Text = "";
            txtEndPackQty.Text = "";
            txtCount.Text = "";
            txtPrintQty.Text = "";
            txtMaterialNo.ReadOnly = false;
            txtMaterialDesc.ReadOnly = false;
            txtcinvstd.ReadOnly = false;

        }

        private void txtMaterialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetMaterialLabelInfo();
            }
        }

        private void txtMaterialDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetMaterialLabelInfo();
            }

        }

        private void txtcinvstd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetMaterialLabelInfo();
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
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtEndPackQty.Text))
                {
                    MessageBox.Show("尾箱包装量必须是正整数");
                    return;
                }
                if (Convert.ToInt16(txtPackQty.Text) > Convert.ToInt16(txtCurrentSum.Text))
                {
                    MessageBox.Show("包装量不得大于本批数量");
                    return;
                }
                //自动计算箱数和尾箱包装量
                if (Convert.ToInt16(txtCurrentSum.Text) > 0 && Convert.ToInt16(txtPackQty.Text) > 0)
                {
                    txtCount.Text = (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtPackQty.Text)) > 0 ? (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtPackQty.Text) + 1).ToString("F0") : (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtPackQty.Text)).ToString("F0");
                    txtEndPackQty.Text = (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtPackQty.Text)) == 0 ? Convert.ToInt16(txtPackQty.Text).ToString("F0") : (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtPackQty.Text)).ToString("F0");
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
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtEndPackQty.Text))
                {
                    MessageBox.Show("尾箱包装量必须是正整数");
                    return;
                }
                if (Convert.ToInt16(txtEndPackQty.Text) > Convert.ToInt16(txtCurrentSum.Text))
                {
                    MessageBox.Show("包装量不得大于本批数量");
                    return;
                }
                if (Convert.ToInt16(txtCurrentSum.Text) > 0 && Convert.ToInt16(txtEndPackQty.Text) > 0)
                {
                    txtCount.Text = ((Convert.ToInt16(txtCurrentSum.Text) - Convert.ToInt16(txtEndPackQty.Text)) / Convert.ToInt16(txtPackQty.Text) + 1).ToString("F0");

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
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtEndPackQty.Text))
                {
                    MessageBox.Show("尾箱包装量必须是正整数");
                    return;
                }
                //自动计算包装量和尾箱包装量
                //if (Convert.ToInt16(txtCurrentSum.Text) > 0 && Convert.ToInt16(txtCount.Text) > 0)
                //{
                //    txtPackQty.Text = (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtCount.Text)).ToString("F0");
                //    txtEndPackQty.Text = (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtCount.Text)) == 0 ? (Convert.ToInt16(txtCurrentSum.Text) / Convert.ToInt16(txtCount.Text)).ToString("F0") : (Convert.ToInt16(txtCurrentSum.Text) % Convert.ToInt16(txtCount.Text)).ToString("F0");
                //}
                if (Convert.ToInt16(txtCurrentSum.Text) != ((Convert.ToInt16(txtPackQty.Text) * (Convert.ToInt16(txtCount.Text) - 1)) + Convert.ToInt16(txtEndPackQty.Text)))
                {
                    MessageBox.Show("本批数量和当前包装量及箱数不匹配");
                    return;
                }
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
                    if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtEndPackQty.Text))
                    {
                        MessageBox.Show("尾箱包装量必须是正整数");
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
                    if (Convert.ToInt16(txtPackQty.Text) > Convert.ToInt16(txtCurrentSum.Text))
                    {
                        MessageBox.Show("包装量不得大于本批数量");
                        return;
                    }
                    if (Convert.ToInt16(txtEndPackQty.Text) > Convert.ToInt16(txtCurrentSum.Text))
                    {
                        MessageBox.Show("包装量不得大于本批数量");
                        return;
                    }
                    if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtCurrentSum.Text))
                    {
                        MessageBox.Show("本批数量必须是正整数");
                        return;
                    }
                    if (Convert.ToInt16(txtCurrentSum.Text) != ((Convert.ToInt16(txtPackQty.Text) * (Convert.ToInt16(txtCount.Text) - 1)) + Convert.ToInt16(txtEndPackQty.Text)))
                    {
                        MessageBox.Show("本批数量和当前包装量及箱数不匹配");
                        return;
                    }
                    if(checkBox1.Checked)
                    {
                        if(txtWhereWarehouseNo.Text.Trim().Equals("") || txtWhereHouseNo.Text.Trim().Equals("") || txtWhereAreaNo.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("请输入仓库货位信息");
                            return;
                        }
                        if (WMS.Common.WMSWebService.service.CheckbProxyWhBycWhCode(txtWhereWarehouseNo.Text, ref strErrMsg))
                        {
                            if(vendor == null)
                            {
                                MessageBox.Show("仓库是代管仓请输入供应商信息");
                                return;
                            }
                        }
                    }
                    WebService.MaterialLabel_Model label = new WebService.MaterialLabel_Model();
                    label.prdversion = "3";
                    label.labeltype = "00";

                    label.materialno = currentDetail.materialno;
                    label.materialdesc = currentDetail.materialdesc;
                    label.invstd = currentDetail.invstd;
                    label.batchno = dtpBatchNo.Value.ToString("yyMMdd");
                    WebService.Stock_Model stmodel = null; 
                    if(checkBox1.Checked)
                    {
                        stmodel.WarehouseNo = txtWhereWarehouseNo.Text;
                        stmodel.HouseNo = txtWhereHouseNo.Text;
                        stmodel.AreaNo = txtWhereAreaNo.Text;
                        if(vendor != null)
                        {
                            label.cvencode = vendor.cVenCode;
                            label.cvenabbname = vendor.cVenAbbName;
                        }
                    }
                    List<WebService.MaterialLabel_Model> label_lst = null;
                    if (!WMS.Common.WMSWebService.service.CreateMaterialBarcodeForNull(label, stmodel, Convert.ToInt16(txtCount.Text), txtPackQty.Text, txtEndPackQty.Text, ref label_lst, ref strErrMsg))
                    {
                        MessageBox.Show("生成条码失败:" + strErrMsg);
                        return;
                    }
                    int printqty = Convert.ToInt16(txtPrintQty.Text);
                    int count = Convert.ToInt16(txtCount.Text);
                    for (int j = 0; j < printqty; j++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string printStr = "";
                            //将文本框中的内容按行转成图片
                            StringBuilder ReturnBarcodeCMD = new StringBuilder(10240);
                            if (checkBox1.Checked)
                            {
                                RawPrinterHelper.GETFONTHEX("货位：" + label_lst[i].Locale, "宋体", "txt1", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            if (label_lst[i].cvenabbname.Length > 0)
                            {
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
                            RawPrinterHelper.GETFONTHEX("生产日期：" + dtpBatchNo.Value.ToString("yyyy/MM/dd"), "宋体", "txt9", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX("包装量：" + label_lst[i].outpackqty, "宋体", "txt10", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX("箱号:" + label_lst[i].Remark, "宋体", "txt11", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX(label_lst[i].BarcodeExpress, "宋体", "txt12", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            printStr += "^XA^MMT^PW559^LL0559^LS0";
                            if (checkBox1.Checked)
                            {
                                printStr += "^FT160,66^XGtxt1,1,1^FS";
                            }
                            if (label_lst[i].cvenabbname.Length > 0)
                            {
                                printStr += "^FT160,120^XGtxt2,1,1^FS";
                                if (label_lst[i].cvenabbname.Length > 6)
                                {
                                    printStr += "^FT270,150^XGtxt3,1,1^FS";
                                }
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
                            printStr += "^FT400,500^BQN,2,4";
                            printStr += "^FDMA," + label_lst[i].barcode + "^FS";
                            printStr += "^PQ1,0,1,Y^XZ";
                            if (checkBox1.Checked)
                            {
                                printStr += "^XA^IDtxt1^FS^XZ";
                            }
                            if (label_lst[i].cvenabbname.Length > 0)
                            {
                                printStr += "^XA^IDtxt2^FS^XZ";
                                if (label_lst[i].cvenabbname.Length > 6)
                                {
                                    printStr += "^XA^IDtxt3^FS^XZ";
                                }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtWhereWarehouseNo.ReadOnly = false;
                txtWhereHouseNo.ReadOnly = false;
                txtWhereAreaNo.ReadOnly = false;
            }
            else
            {
                txtWhereWarehouseNo.ReadOnly = true;
                txtWhereHouseNo.ReadOnly = true;
                txtWhereAreaNo.ReadOnly = true;
            }
        }

        private void txtSupCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //验证和获取供应商信息
            try
            {
                string strErrMsg = null;
                if (WMS.Common.WMSWebService.service.GetVendorByCode(txtSupCode.Text, ref vendor, ref strErrMsg))
                {
                    txtSupName.Text = vendor.cVenAbbName;
                }
                else
                {
                    MessageBox.Show("供应商代码错误");
                    vendor = null;
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
